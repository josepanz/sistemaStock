using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;


namespace capaPresentacion
{
    public partial class frmProducto : Form
    {
        public string modo;
        public frmProducto()
        {
            InitializeComponent();
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            dgvProducto.AutoGenerateColumns = true;
            cmbMarca.DataSource = Marca.ObtenerMarcas();
            cmbTipoProducto.DataSource = TipoProducto.ObtenerTipoProductos();
            cmbProveedor.DataSource = Proveedor.ObtenerProveedores();
            cmbUnidad.DataSource = UnidadMedida.ObtenerUnidades();
            cmbCategoria.DataSource = Categoria.ObtenerCategorias();

            cmbMarca.SelectedItem = null;
            cmbTipoProducto.SelectedItem = null;
            cmbProveedor.SelectedItem = null;
            cmbUnidad.SelectedItem = null;
            cmbCategoria.SelectedItem = null;

            PanelMantenimiento.Enabled = false;

            ListarProducto();
        }

        private void ListarProducto()
        {
            dgvProducto.DataSource = null;
            dgvProducto.DataSource = Producto.ObtenerProductos();
            dgvProducto.ClearSelection();
            dgvProducto.Columns[0].HeaderText = "Código interno";
            dgvProducto.Columns[1].HeaderText = "Descripción";
            dgvProducto.Columns[2].HeaderText = "Código de Barras";
            dgvProducto.Columns[3].HeaderText = "Precio";
            dgvProducto.Columns[4].HeaderText = "Cantidad";
            dgvProducto.Columns[5].HeaderText = "Marca";
            dgvProducto.Columns[6].HeaderText = "Tipo de Producto";
            dgvProducto.Columns[7].HeaderText = "Proveedor";
            dgvProducto.Columns[8].HeaderText = "Unidad de Medida";
            dgvProducto.Columns[9].HeaderText = "Categoria";
            
        }

        private void LimpiarFormulario()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtCodBarra.Text = "";
            nudPrecio.Value = 0;
            nudCantidad.Value = 0;
            cmbMarca.SelectedIndex = -1;
            cmbTipoProducto.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            cmbUnidad.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            txtDescripcion.Focus();
        }

        private Producto ObtenerProductoFormulario()
        {
            Producto pro = new Producto();
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                pro.id = Convert.ToInt32(txtId.Text);

            }
            if (txtDescripcion.Text != "")
            {
                pro.descripcion =txtDescripcion.Text;
            }
            else
            {
                MessageBox.Show("La descripción es obligatoria");
                txtDescripcion.Focus();
                return null;
            }
            if (txtCodBarra.Text != "")
            {
                pro.codBarra = txtCodBarra.Text;
            }
            else
            {
                MessageBox.Show("El código de barras es obligatorio");
                txtCodBarra.Focus();
                return null;
            }
                        
            if (cmbMarca.SelectedItem != null)
            {
                pro.marca = (Marca)cmbMarca.SelectedItem;
            }
            else
            {
                MessageBox.Show("La marca es obligatoria");
                cmbMarca.Focus();
                return null;
            }
            if (cmbTipoProducto.SelectedItem != null)
            {
                pro.tipoProducto = (TipoProducto)cmbTipoProducto.SelectedItem;
            }
            else
            {
                MessageBox.Show("El tipo del producto es obligatorio");
                cmbTipoProducto.Focus();
                return null;
            }
            if (cmbProveedor.SelectedItem != null)
            {
                pro.proveedor = (Proveedor)cmbProveedor.SelectedItem;
            }
            else
            {
                MessageBox.Show("El proveedor es obligatorio");
                cmbTipoProducto.Focus();
                return null;
            }

            if (cmbUnidad.SelectedItem != null)
            {
                pro.unidad = (UnidadMedida)cmbUnidad.SelectedItem;
            }
            else
            {
                MessageBox.Show("La unidad de medida es obligatoria");
                cmbUnidad.Focus();
                return null;
            }

            if (cmbCategoria.SelectedItem != null)
            {
                pro.categoria = (Categoria)cmbCategoria.SelectedItem;
            }
            else
            {
                MessageBox.Show("La categoria es obligatorio");
                cmbCategoria.Focus();
                return null;
            }
            pro.cantidad = (int)nudCantidad.Value;
            pro.precio = (int)nudPrecio.Value;

            return pro;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            modo = "I";
            LimpiarFormulario();
            PanelMantenimiento.Enabled = true;
            PanelConsulta.Enabled = false;

           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedCells.Count > 0)
            {
                Producto pro = (Producto)dgvProducto.CurrentRow.DataBoundItem;
                if (pro != null)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Producto.EliminarProductos(pro);

                        ListarProducto();
                        MessageBox.Show("Registro eliminado", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();            
                        
                        
                    }
                    
                }
                ListarProducto();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            modo = "E";
            Producto pro = new Producto();
            if (dgvProducto.SelectedCells.Count > 0)
            {
                PanelConsulta.Enabled = false;
                PanelMantenimiento.Enabled = true;
                pro = (Producto)dgvProducto.CurrentRow.DataBoundItem;
                //empleado.idPK = Convert.ToInt32(dgvEmpleado.CurrentRow.Cells[0].Value);
                txtId.Text = pro.id.ToString();
                txtCodBarra.Text = pro.codBarra.ToString();
                txtDescripcion.Text = pro.descripcion.ToString();
                nudCantidad.Value = pro.cantidad;
                nudPrecio.Value = pro.precio;
                if (pro.marca != null)
                {
                    cmbMarca.SelectedItem = Marca.ObtenerMarca(pro.marca.id);
                }
                if (pro.proveedor != null)
                {
                    cmbProveedor.SelectedItem = Proveedor.ObtenerProveedor(pro.proveedor.idPK);
                }
                if (pro.categoria != null)
                {
                    cmbCategoria.SelectedItem = Categoria.ObtenerCategoria(pro.categoria.id);
                }
                if (pro.tipoProducto != null)
                {
                    cmbTipoProducto.SelectedItem = TipoProducto.ObtenerTipoProducto(pro.tipoProducto.id);
                }
                if (pro.unidad != null)
                {
                    cmbUnidad.SelectedItem = UnidadMedida.ObtenerUnidad(pro.unidad.id);
                }   
                

            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }

            
        }

                
        private void dgvProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducto.RowCount > 0)
                {
                    Producto pro = (Producto)dgvProducto.CurrentRow.DataBoundItem;

                    if (pro != null)
                    {
                        txtId.Text = Convert.ToString(pro.id);
                        txtDescripcion.Text = pro.descripcion;
                        txtCodBarra.Text = pro.codBarra;
                        nudPrecio.Value = (int)pro.precio;
                        nudCantidad.Value = (int)pro.cantidad;
                        cmbMarca.SelectedItem = pro.marca;
                        cmbTipoProducto.SelectedItem = pro.tipoProducto;
                        cmbProveedor.SelectedItem = pro.proveedor;
                        cmbUnidad.SelectedItem = pro.unidad;
                        cmbCategoria.SelectedItem = pro.categoria;

                    }
                }
                else
                {
                    MessageBox.Show("No hay registros para seleccionar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto pro = null;
                if (modo == "I")
                {
                    pro = ObtenerProductoFormulario();
                    if (pro != null)
                    {
                        Producto.AgregarProductos(pro);
                        MessageBox.Show("Registro insertado correctamente", "Alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarProducto();
                        LimpiarFormulario();
                        PanelMantenimiento.Enabled = false;
                        PanelConsulta.Enabled = true;
                    }
                }
                else if (modo == "E")
                {
                    int index = Convert.ToInt32(dgvProducto.CurrentRow.Cells[0].Value);
                    pro = ObtenerProductoFormulario();
                    if (pro != null)
                    {
                        Producto.EditarProducto(index, pro);
                        MessageBox.Show("Registro editado correctamente", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarProducto();
                        LimpiarFormulario();
                        PanelMantenimiento.Enabled = false;
                        PanelConsulta.Enabled = true;
                    }
                    txtBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            PanelMantenimiento.Enabled = false;
            PanelConsulta.Enabled = true;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            var result = Producto.ObtenerProductos().Where(x => x.descripcion.ToString().Contains(txtBuscar.Text)).ToList();
            dgvProducto.DataSource = result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Contratos
{
    public interface IRepositorioGenerico<Entity> where Entity:class
    {
        int Add(Entity entity);
        int Edit(Entity entity);
        int Remove(int idPK);
        IEnumerable<Entity> GetAll();
    }
}

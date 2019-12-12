USE [master]
GO
/****** Object:  Database [stock]    Script Date: 12/12/2019 13:16:06 ******/
CREATE DATABASE [stock]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'stock', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVER\MSSQL\DATA\stock.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'stock_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVER\MSSQL\DATA\stock_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [stock] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [stock].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [stock] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [stock] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [stock] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [stock] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [stock] SET ARITHABORT OFF 
GO
ALTER DATABASE [stock] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [stock] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [stock] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [stock] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [stock] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [stock] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [stock] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [stock] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [stock] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [stock] SET  DISABLE_BROKER 
GO
ALTER DATABASE [stock] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [stock] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [stock] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [stock] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [stock] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [stock] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [stock] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [stock] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [stock] SET  MULTI_USER 
GO
ALTER DATABASE [stock] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [stock] SET DB_CHAINING OFF 
GO
ALTER DATABASE [stock] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [stock] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [stock] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [stock] SET QUERY_STORE = OFF
GO
USE [stock]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idPK] [int] IDENTITY(1,1) NOT NULL,
	[idNumero] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleRecepcion]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleRecepcion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NULL,
	[cantidadRecibida] [numeric](18, 0) NULL,
	[recepcion_id] [int] NULL,
 CONSTRAINT [PK_DetalleRecepcion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleRemision]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleRemision](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto_id] [int] NULL,
	[cantidadRemitida] [numeric](18, 0) NULL,
	[remision_id] [int] NULL,
 CONSTRAINT [PK_DetalleRemision] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[idPK] [int] IDENTITY(1,1) NOT NULL,
	[idNumero] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[codCargo] [int] NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_Empleado1] PRIMARY KEY CLUSTERED 
(
	[idPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nchar](10) NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motivo]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motivo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nchar](10) NULL,
 CONSTRAINT [PK_Motivo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[codBarra] [varchar](50) NULL,
	[precio] [int] NULL,
	[cantidad] [int] NULL,
	[marca_id] [int] NULL,
	[tipoProducto_id] [int] NULL,
	[proveedor_id] [int] NULL,
	[unidadMedida_id] [int] NULL,
	[categoria_id] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ruc] [varchar](50) NULL,
	[RazonSocial] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Proveedor_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recepcion]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recepcion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaRecepcion] [date] NULL,
	[nroDocumento] [varchar](225) NULL,
	[receptor] [varchar](255) NULL,
	[direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Recepcion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Remision]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Remision](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaRemision] [datetime] NULL,
	[nroDocumento] [varchar](225) NULL,
	[destinatario] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[motivoRemision_id] [int] NULL,
 CONSTRAINT [PK_Remision] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadMedida]    Script Date: 12/12/2019 13:16:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadMedida](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_UnidadMedida_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Empleado1]    Script Date: 12/12/2019 13:16:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Empleado1] ON [dbo].[Empleado]
(
	[idNumero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleRecepcion]  WITH CHECK ADD  CONSTRAINT [FK_DetalleRecepcion_Producto] FOREIGN KEY([producto_id])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[DetalleRecepcion] CHECK CONSTRAINT [FK_DetalleRecepcion_Producto]
GO
ALTER TABLE [dbo].[DetalleRecepcion]  WITH CHECK ADD  CONSTRAINT [FK_DetalleRecepcion_Recepcion] FOREIGN KEY([recepcion_id])
REFERENCES [dbo].[Recepcion] ([id])
GO
ALTER TABLE [dbo].[DetalleRecepcion] CHECK CONSTRAINT [FK_DetalleRecepcion_Recepcion]
GO
ALTER TABLE [dbo].[DetalleRemision]  WITH CHECK ADD  CONSTRAINT [FK_DetalleRemision_Producto] FOREIGN KEY([producto_id])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[DetalleRemision] CHECK CONSTRAINT [FK_DetalleRemision_Producto]
GO
ALTER TABLE [dbo].[DetalleRemision]  WITH CHECK ADD  CONSTRAINT [FK_DetalleRemision_Remision] FOREIGN KEY([remision_id])
REFERENCES [dbo].[Remision] ([id])
GO
ALTER TABLE [dbo].[DetalleRemision] CHECK CONSTRAINT [FK_DetalleRemision_Remision]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Cargo] FOREIGN KEY([codCargo])
REFERENCES [dbo].[Cargo] ([id])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Cargo]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([categoria_id])
REFERENCES [dbo].[Categoria] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Marca] FOREIGN KEY([marca_id])
REFERENCES [dbo].[Marca] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Marca]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Proveedor] FOREIGN KEY([proveedor_id])
REFERENCES [dbo].[Proveedor] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Proveedor]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY([tipoProducto_id])
REFERENCES [dbo].[TipoProducto] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_TipoProducto]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_UnidadMedida] FOREIGN KEY([unidadMedida_id])
REFERENCES [dbo].[UnidadMedida] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_UnidadMedida]
GO
ALTER TABLE [dbo].[Remision]  WITH CHECK ADD  CONSTRAINT [FK_Remision_Motivo] FOREIGN KEY([motivoRemision_id])
REFERENCES [dbo].[Motivo] ([id])
GO
ALTER TABLE [dbo].[Remision] CHECK CONSTRAINT [FK_Remision_Motivo]
GO
USE [master]
GO
ALTER DATABASE [stock] SET  READ_WRITE 
GO

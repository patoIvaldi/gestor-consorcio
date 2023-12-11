USE [master]
GO
/****** Object:  Database [MiEdificio]    Script Date: 10/12/2023 23:21:05 ******/
CREATE DATABASE [MiEdificio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MiEdificio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MiEdificio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MiEdificio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MiEdificio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MiEdificio] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MiEdificio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MiEdificio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MiEdificio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MiEdificio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MiEdificio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MiEdificio] SET ARITHABORT OFF 
GO
ALTER DATABASE [MiEdificio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MiEdificio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MiEdificio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MiEdificio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MiEdificio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MiEdificio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MiEdificio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MiEdificio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MiEdificio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MiEdificio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MiEdificio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MiEdificio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MiEdificio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MiEdificio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MiEdificio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MiEdificio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MiEdificio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MiEdificio] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MiEdificio] SET  MULTI_USER 
GO
ALTER DATABASE [MiEdificio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MiEdificio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MiEdificio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MiEdificio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MiEdificio] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MiEdificio] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MiEdificio] SET QUERY_STORE = OFF
GO
USE [MiEdificio]
GO
/****** Object:  Table [dbo].[AREA_COMUN]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AREA_COMUN](
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](1000) NULL,
	[estaHabilitada] [bit] NULL,
	[IDV] [nvarchar](100) NULL,
 CONSTRAINT [PK_AREA_COMUN] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BITACORA_EVENTO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BITACORA_EVENTO](
	[ID] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](0) NOT NULL,
	[Usuario] [nvarchar](20) NOT NULL,
	[Modulo] [varchar](20) NOT NULL,
	[Operacion] [varchar](20) NOT NULL,
	[Criticidad] [varchar](20) NOT NULL,
	[Detalle] [varchar](200) NULL,
 CONSTRAINT [PK_BITACORA_EVENTO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EXPENSA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXPENSA](
	[id] [int] NOT NULL,
	[fecha_emision] [date] NOT NULL,
	[monto] [float] NOT NULL,
	[periodo] [varchar](7) NOT NULL,
	[esta_paga] [bit] NULL,
	[dni] [bigint] NOT NULL,
	[primer_vencimiento] [date] NULL,
	[segundo_vencimiento] [date] NULL,
	[IDV] [nvarchar](100) NULL,
 CONSTRAINT [PK_EXPENSA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_periodo_dni] UNIQUE NONCLUSTERED 
(
	[periodo] ASC,
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EXPENSA_PAGO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXPENSA_PAGO](
	[id_expensa] [int] NOT NULL,
	[id_pago] [int] NOT NULL,
 CONSTRAINT [PK_EXPENSA_PAGO] PRIMARY KEY CLUSTERED 
(
	[id_expensa] ASC,
	[id_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GANANCIA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GANANCIA](
	[Anio] [int] NOT NULL,
	[Mes] [int] NOT NULL,
	[Ganancia] [bigint] NULL,
	[IDV] [nvarchar](100) NULL,
 CONSTRAINT [PK_GANANCIA] PRIMARY KEY CLUSTERED 
(
	[Anio] ASC,
	[Mes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HASH_GLOBAL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HASH_GLOBAL](
	[Nombre_tabla] [nvarchar](50) NOT NULL,
	[IDV_Global] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_HASH_GLOBAL] PRIMARY KEY CLUSTERED 
(
	[Nombre_tabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDIOMA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDIOMA](
	[Id] [char](2) NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
	[Estandar] [bit] NOT NULL,
	[esta_borrado] [bit] NOT NULL,
 CONSTRAINT [PK_IDIOMA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[METRICA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[METRICA](
	[usuario] [nvarchar](20) NOT NULL,
	[cantReservas] [int] NOT NULL,
	[IDV] [nvarchar](100) NULL,
 CONSTRAINT [PK_METRICA] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAGO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAGO](
	[id] [int] NOT NULL,
	[codSeguridad] [int] NULL,
	[fecha_ejecucion] [datetime] NOT NULL,
	[fecha_vencTarjeta] [date] NULL,
	[forma_de_pago] [varchar](50) NOT NULL,
	[monto] [float] NOT NULL,
	[nombre_tarjeta] [varchar](50) NULL,
	[nro_tarjeta] [bigint] NULL,
	[dni] [bigint] NOT NULL,
	[IDV] [nvarchar](100) NULL,
 CONSTRAINT [PK_PAGO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERFIL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERFIL](
	[Id_rol] [int] NOT NULL,
	[Id_permiso] [int] NOT NULL,
 CONSTRAINT [PK_PERFIL] PRIMARY KEY CLUSTERED 
(
	[Id_rol] ASC,
	[Id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERMISO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISO](
	[Id_permiso] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[esta_borrado] [bit] NULL,
 CONSTRAINT [PK_PERMISO] PRIMARY KEY CLUSTERED 
(
	[Id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERMISO_PERMISO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISO_PERMISO](
	[Id_permiso_padre] [int] NOT NULL,
	[Id_permiso_hijo] [int] NOT NULL,
 CONSTRAINT [PK_PERMISO_PERMISO] PRIMARY KEY CLUSTERED 
(
	[Id_permiso_padre] ASC,
	[Id_permiso_hijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONA](
	[DNI] [bigint] NOT NULL,
	[Apellido] [nvarchar](20) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Fecha_nacimiento] [date] NULL,
	[Nro_departamento] [nvarchar](3) NULL,
	[Telefono] [bigint] NULL,
	[CUIT] [nvarchar](50) NULL,
	[Fecha_fin_concesion] [date] NULL,
	[Fecha_inicio_concesion] [date] NULL,
	[Nombre_empresa] [nvarchar](20) NULL,
	[Razon_social] [nvarchar](20) NULL,
 CONSTRAINT [PK_PERSONA] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVA](
	[Id_Reserva] [int] NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Fecha_creacion] [datetime] NOT NULL,
	[Area] [varchar](100) NOT NULL,
	[Fecha_reserva_inicio] [date] NOT NULL,
	[Hora_reserva_inicio] [time](0) NOT NULL,
	[Fecha_reserva_fin] [date] NOT NULL,
	[Hora_reserva_fin] [time](0) NOT NULL,
	[Usuario] [nvarchar](20) NOT NULL,
	[Feedback] [varchar](1000) NULL,
	[IDV] [nvarchar](100) NULL,
 CONSTRAINT [PK_RESERVA] PRIMARY KEY CLUSTERED 
(
	[Id_Reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVA_CONTROL_CAMBIOS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVA_CONTROL_CAMBIOS](
	[Id] [int] NOT NULL,
	[Fecha_creacion_cambio] [datetime] NOT NULL,
	[esActivo] [bit] NULL,
	[Id_Reserva] [int] NOT NULL,
	[Estado_reserva] [varchar](50) NOT NULL,
	[Fecha_creacion_reserva] [datetime] NOT NULL,
	[Fecha_reserva_inicio] [date] NOT NULL,
	[Hora_reserva_inicio] [time](0) NOT NULL,
	[Fecha_reserva_fin] [date] NOT NULL,
	[Hora_reserva_fin] [time](0) NOT NULL,
	[Usuario_reserva] [nvarchar](20) NOT NULL,
	[Area] [varchar](100) NULL,
	[Feedback] [varchar](1000) NULL,
	[Detalle] [varchar](200) NULL,
 CONSTRAINT [PK_RESERVA_CONTROL_CAMBIOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[Id_rol] [int] NOT NULL,
	[Descripcion] [nchar](20) NOT NULL,
	[esta_borrado] [bit] NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[Id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SEGMENTO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEGMENTO](
	[id] [int] NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[monto] [float] NOT NULL,
	[id_expensa] [int] NOT NULL,
	[IDV] [nvarchar](100) NULL,
 CONSTRAINT [PK_SEGMENTO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRADUCCION]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRADUCCION](
	[nombre_objeto] [varchar](60) NOT NULL,
	[id_idioma] [char](2) NOT NULL,
	[traduccion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TRADUCCION] PRIMARY KEY CLUSTERED 
(
	[nombre_objeto] ASC,
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[Username] [nvarchar](20) NOT NULL,
	[Contraseña] [nvarchar](20) NOT NULL,
	[Cant_intentos] [int] NULL,
	[Esta_bloqueado] [bit] NULL,
	[Fecha_alta] [date] NULL,
	[Mail] [nvarchar](50) NULL,
	[DNI] [bigint] NOT NULL,
	[Id_rol] [int] NULL,
	[IDV] [nvarchar](100) NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AREA_COMUN] ADD  CONSTRAINT [DF_AREA_COMUN_estaHabilitada]  DEFAULT ((1)) FOR [estaHabilitada]
GO
ALTER TABLE [dbo].[GANANCIA] ADD  CONSTRAINT [DF_GANANCIA_Ganancia]  DEFAULT ((0)) FOR [Ganancia]
GO
ALTER TABLE [dbo].[BITACORA_EVENTO]  WITH CHECK ADD  CONSTRAINT [FK_BITACORA_EVENTO_USUARIO] FOREIGN KEY([Usuario])
REFERENCES [dbo].[USUARIO] ([Username])
GO
ALTER TABLE [dbo].[BITACORA_EVENTO] CHECK CONSTRAINT [FK_BITACORA_EVENTO_USUARIO]
GO
ALTER TABLE [dbo].[EXPENSA]  WITH CHECK ADD  CONSTRAINT [FK_EXPENSA_PERSONA] FOREIGN KEY([dni])
REFERENCES [dbo].[PERSONA] ([DNI])
GO
ALTER TABLE [dbo].[EXPENSA] CHECK CONSTRAINT [FK_EXPENSA_PERSONA]
GO
ALTER TABLE [dbo].[EXPENSA_PAGO]  WITH CHECK ADD  CONSTRAINT [FK_EXPENSA_PAGO_EXPENSA] FOREIGN KEY([id_expensa])
REFERENCES [dbo].[EXPENSA] ([id])
GO
ALTER TABLE [dbo].[EXPENSA_PAGO] CHECK CONSTRAINT [FK_EXPENSA_PAGO_EXPENSA]
GO
ALTER TABLE [dbo].[EXPENSA_PAGO]  WITH CHECK ADD  CONSTRAINT [FK_EXPENSA_PAGO_PAGO] FOREIGN KEY([id_pago])
REFERENCES [dbo].[PAGO] ([id])
GO
ALTER TABLE [dbo].[EXPENSA_PAGO] CHECK CONSTRAINT [FK_EXPENSA_PAGO_PAGO]
GO
ALTER TABLE [dbo].[PAGO]  WITH CHECK ADD  CONSTRAINT [FK_PAGO_PERSONA] FOREIGN KEY([dni])
REFERENCES [dbo].[PERSONA] ([DNI])
GO
ALTER TABLE [dbo].[PAGO] CHECK CONSTRAINT [FK_PAGO_PERSONA]
GO
ALTER TABLE [dbo].[PERFIL]  WITH CHECK ADD  CONSTRAINT [FK_PERFIL_PERMISO] FOREIGN KEY([Id_permiso])
REFERENCES [dbo].[PERMISO] ([Id_permiso])
GO
ALTER TABLE [dbo].[PERFIL] CHECK CONSTRAINT [FK_PERFIL_PERMISO]
GO
ALTER TABLE [dbo].[PERFIL]  WITH CHECK ADD  CONSTRAINT [FK_PERFIL_ROL] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[ROL] ([Id_rol])
GO
ALTER TABLE [dbo].[PERFIL] CHECK CONSTRAINT [FK_PERFIL_ROL]
GO
ALTER TABLE [dbo].[PERMISO_PERMISO]  WITH CHECK ADD  CONSTRAINT [FK_PERMISO_PERMISO_PERMISO] FOREIGN KEY([Id_permiso_padre])
REFERENCES [dbo].[PERMISO] ([Id_permiso])
GO
ALTER TABLE [dbo].[PERMISO_PERMISO] CHECK CONSTRAINT [FK_PERMISO_PERMISO_PERMISO]
GO
ALTER TABLE [dbo].[PERMISO_PERMISO]  WITH CHECK ADD  CONSTRAINT [FK_PERMISO_PERMISO_PERMISO1] FOREIGN KEY([Id_permiso_hijo])
REFERENCES [dbo].[PERMISO] ([Id_permiso])
GO
ALTER TABLE [dbo].[PERMISO_PERMISO] CHECK CONSTRAINT [FK_PERMISO_PERMISO_PERMISO1]
GO
ALTER TABLE [dbo].[RESERVA]  WITH CHECK ADD  CONSTRAINT [FK_RESERVA_USUARIO] FOREIGN KEY([Usuario])
REFERENCES [dbo].[USUARIO] ([Username])
GO
ALTER TABLE [dbo].[RESERVA] CHECK CONSTRAINT [FK_RESERVA_USUARIO]
GO
ALTER TABLE [dbo].[RESERVA_CONTROL_CAMBIOS]  WITH CHECK ADD  CONSTRAINT [FK_RESERVA_CONTROL_CAMBIOS_RESERVA] FOREIGN KEY([Id_Reserva])
REFERENCES [dbo].[RESERVA] ([Id_Reserva])
GO
ALTER TABLE [dbo].[RESERVA_CONTROL_CAMBIOS] CHECK CONSTRAINT [FK_RESERVA_CONTROL_CAMBIOS_RESERVA]
GO
ALTER TABLE [dbo].[SEGMENTO]  WITH CHECK ADD  CONSTRAINT [FK_SEGMENTO_EXPENSA] FOREIGN KEY([id_expensa])
REFERENCES [dbo].[EXPENSA] ([id])
GO
ALTER TABLE [dbo].[SEGMENTO] CHECK CONSTRAINT [FK_SEGMENTO_EXPENSA]
GO
ALTER TABLE [dbo].[TRADUCCION]  WITH CHECK ADD  CONSTRAINT [FK_TRADUCCION_IDIOMA] FOREIGN KEY([id_idioma])
REFERENCES [dbo].[IDIOMA] ([Id])
GO
ALTER TABLE [dbo].[TRADUCCION] CHECK CONSTRAINT [FK_TRADUCCION_IDIOMA]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_PERSONA] FOREIGN KEY([DNI])
REFERENCES [dbo].[PERSONA] ([DNI])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_PERSONA]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_ROL] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[ROL] ([Id_rol])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_ROL]
GO
/****** Object:  StoredProcedure [dbo].[ACTIVAR_REG_CAMBIO_RESERVA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ACTIVAR_REG_CAMBIO_RESERVA]
@idCambioReserva int, @idReserva int
AS
BEGIN
	UPDATE RESERVA_CONTROL_CAMBIOS SET esActivo = 0 where Id_Reserva = @idReserva;
	UPDATE RESERVA_CONTROL_CAMBIOS SET esActivo = 1 where Id = @idCambioReserva;
END;
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_IDV_AREA_COMUN]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ACTUALIZAR_IDV_AREA_COMUN]
@idv nvarchar(100),@nombre varchar(100)
as
begin
	UPDATE AREA_COMUN SET idv = @idv where Nombre = @nombre;
end;
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_IDV_EXPENSA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ACTUALIZAR_IDV_EXPENSA]
@idv nvarchar(100),@idExpensa int
as
begin
	UPDATE EXPENSA SET idv = @idv where id = @idExpensa;
end;
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_IDV_GANANCIA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ACTUALIZAR_IDV_GANANCIA]
@idv nvarchar(100),@mes int, @anio int
as
begin
	UPDATE GANANCIA SET idv = @idv where Anio = @anio and Mes = @mes;
end;
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_IDV_METRICA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ACTUALIZAR_IDV_METRICA]
@idv nvarchar(100),@usuario nvarchar(20)
as
begin
	UPDATE METRICA SET idv = @idv where usuario = @usuario;
end;
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_IDV_PAGO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ACTUALIZAR_IDV_PAGO]
@idv nvarchar(100),@idPago int
as
begin
	UPDATE PAGO SET idv = @idv where id = @idPago;
end;
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_IDV_SEGMENTO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ACTUALIZAR_IDV_SEGMENTO]
@idv nvarchar(100),@idSegmento int
as
begin
	UPDATE SEGMENTO SET idv = @idv where id = @idSegmento;
end;
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_IDV_USUARIO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ACTUALIZAR_IDV_USUARIO]
@idv nvarchar(100),@usuario nvarchar(20)
as
begin
	UPDATE USUARIO SET idv = @idv where Username = @usuario;
end;
GO
/****** Object:  StoredProcedure [dbo].[ASOCIAR_PERMISO_PERFIL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASOCIAR_PERMISO_PERFIL]
@idRol int,@idPermiso int
AS
BEGIN
	INSERT INTO PERFIL (Id_rol,Id_permiso) VALUES (@idRol,@idPermiso);
END;
GO
/****** Object:  StoredProcedure [dbo].[ASOCIAR_PERMISO_PERMISO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ASOCIAR_PERMISO_PERMISO]
@idPermisoPadre int,@idPermisoHijo int
AS
BEGIN
	INSERT INTO PERMISO_PERMISO (Id_permiso_padre,Id_permiso_hijo) VALUES (@idPermisoPadre,@idPermisoHijo);
END;
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_IDIOMA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BORRAR_IDIOMA]
@id char(2)
AS
BEGIN
    UPDATE IDIOMA SET esta_borrado = 'true' WHERE id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_PERFIL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BORRAR_PERFIL]
@id int
AS
BEGIN
	--DELETE from PERFIL where Id_rol = @id;
	--UPDATE USUARIO set Id_rol = null where Id_rol = @id;
	UPDATE ROL set esta_borrado = 'true' where Id_rol = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_PERMISO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BORRAR_PERMISO]
@id int
AS
BEGIN
	UPDATE PERMISO set esta_borrado = 'true' where Id_permiso = @id;
	DELETE PERMISO_PERMISO where (Id_permiso_padre = @id OR Id_permiso_hijo = @id);
	DELETE PERFIL where Id_permiso = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_CAMBIOS_RESERVAS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_CAMBIOS_RESERVAS]
@fechaIni Date = null, @fechaFin Date = null,
@usuario nvarchar(20) = null,@estado varchar(50) = null,@esActivo bit = null
AS
BEGIN
    SELECT id,Fecha_creacion_cambio,Id_Reserva,Estado_reserva,Fecha_creacion_reserva,
	Fecha_reserva_inicio,Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario_reserva,
	esActivo,Area,Feedback,Detalle
    FROM RESERVA_CONTROL_CAMBIOS
    WHERE
        ( @fechaIni IS NULL OR Fecha_creacion_cambio >= @fechaIni )
        AND ( @fechaFin IS NULL OR Fecha_creacion_cambio <= @fechaFin )
        AND ( @usuario IS NULL OR Usuario_reserva = @usuario )
        AND ( @estado IS NULL OR Estado_reserva = @estado )
        AND ( @esActivo IS NULL OR esActivo = @esActivo )
    ORDER BY Fecha_creacion_cambio DESC, id_reserva DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_EVENTOS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_EVENTOS]
@fechaIni Date = null, @fechaFin Date = null, @horaIni Time = null,@horaFin Time = null,
@usuario nvarchar(20) = null,@modulo varchar(20) = null,@operacion varchar(20) = null,@criticidad varchar(20) = null
AS
BEGIN
    SELECT id, fecha, hora, usuario, modulo, operacion, criticidad, detalle
    FROM BITACORA_EVENTO
    WHERE
        ( @fechaIni IS NULL OR fecha >= @fechaIni )
        AND ( @horaIni IS NULL OR hora >= @horaIni )
        AND ( @fechaFin IS NULL OR fecha <= @fechaFin )
        AND ( @horaFin IS NULL OR hora <= @horaFin )
        AND ( @usuario IS NULL OR usuario = @usuario )
        AND ( @modulo IS NULL OR modulo = @modulo )
        AND ( @operacion IS NULL OR operacion = @operacion )
        AND ( @criticidad IS NULL OR criticidad = @criticidad )
    ORDER BY fecha DESC, hora DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_EXPENSA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_EXPENSA]
@dni bigint,@periodo varchar(5)
AS
BEGIN
	select id,esta_paga,fecha_emision, idv from EXPENSA where dni = @dni and periodo = @periodo;
END;
GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_EXPENSAS_X_PAGO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_EXPENSAS_X_PAGO]
@idPago int
AS
BEGIN
	select e.id,e.fecha_emision,e.esta_paga,e.dni, e.idv
	from PAGO p
	join EXPENSA_PAGO ep on ep.id_pago = p.id
	join EXPENSA e on e.id = ep.id_expensa
	where p.id = @idPago;
END;
GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_IDV_GLOBAL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[BUSCAR_IDV_GLOBAL]
@idvGlobal nvarchar(100)
as
begin
	select count(*) as total
	from HASH_GLOBAL where idv_global = @idvGlobal;
end;
GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_PAGO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_PAGO]
@dni bigint,@fecha_ejecucion datetime
AS
BEGIN
	select id,codSeguridad,fecha_ejecucion,fecha_vencTarjeta,forma_de_pago,monto,nombre_tarjeta,nro_tarjeta,idv
	from PAGO
	where dni = @dni and fecha_ejecucion = @fecha_ejecucion;
END;
GO
/****** Object:  StoredProcedure [dbo].[CAMBIAR_PASSWORD]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CAMBIAR_PASSWORD]
@Username nvarchar(20), @Password nvarchar(20)
as
begin
update USUARIO
set Contraseña = @Password 
where Username = @Username;
end;
GO
/****** Object:  StoredProcedure [dbo].[CAMBIAR_PERFIL_USUARIO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[CAMBIAR_PERFIL_USUARIO]
@idRol int,@username nvarchar(20)
AS
BEGIN
	UPDATE USUARIO set Id_rol = @idRol where Username = @username;
END;
GO
/****** Object:  StoredProcedure [dbo].[DESASOCIAR_PERMISO_PERFIL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DESASOCIAR_PERMISO_PERFIL]
@idRol int,@idPermiso int
AS
BEGIN
	DELETE PERFIL WHERE Id_rol = @idRol and Id_permiso = @idPermiso;
END;
GO
/****** Object:  StoredProcedure [dbo].[DESBLOQUEAR_USUARIO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DESBLOQUEAR_USUARIO]
@Username nvarchar(20)
as
begin
update USUARIO
set Esta_bloqueado = CASE WHEN Esta_bloqueado = 1 THEN 0 ELSE 1 END,
cant_intentos = CASE WHEN Esta_bloqueado = 1 THEN 0 ELSE cant_intentos END
where Username = @Username;
end;
GO
/****** Object:  StoredProcedure [dbo].[EDITAR_IDIOMA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EDITAR_IDIOMA]
@id char(2), @descripcion nvarchar(20), @es_estandar bit = 'false'
AS
BEGIN
    IF @es_estandar = 1
    BEGIN
        UPDATE IDIOMA SET Estandar = 0;
    END;

    UPDATE IDIOMA SET Descripcion = @descripcion, Estandar = @es_estandar
	WHERE id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[EDITAR_PERFIL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EDITAR_PERFIL]
@id int,@descripcion nvarchar(50)
AS
BEGIN
	UPDATE ROL set Descripcion = @descripcion where Id_rol = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[EDITAR_PERMISO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EDITAR_PERMISO]
@id int,@nombre nvarchar(20),@descripcion nvarchar(50)
AS
BEGIN
	UPDATE PERMISO set Nombre = @nombre, Descripcion = @descripcion where Id_permiso = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[EDITAR_USUARIO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EDITAR_USUARIO]
@Username nvarchar(20),@password nvarchar(20) = null, @nombre nvarchar(20), @apellido nvarchar(20), @dni bigint,
@fechanac date, @nrodepto nvarchar(3) = null,@telefono nvarchar(15) = null, @fechaIniCon date = null,@fechaFinCon date = null, @empresa nvarchar(20) = null,
@razonsocial nvarchar(20) = null,@cuit nvarchar(50) = null, @estaBloqueado bit,@mail nvarchar(50) = null, @rol int,
@idv nvarchar(100) = null
as
begin
Update USUARIO 
set  Contraseña = CASE WHEN @password IS NULL THEN Contraseña ELSE @password END, Mail = @mail, Esta_bloqueado = @estaBloqueado, Id_rol = @rol, IDV = @idv
where Username = @Username;

update PERSONA
set  Nombre = @nombre, Apellido = @apellido, Fecha_nacimiento = @fechanac, Nro_departamento = @nrodepto, Telefono = @telefono,
Fecha_inicio_concesion = @fechaIniCon, Fecha_fin_concesion = @fechaFinCon, Nombre_empresa = @empresa, Razon_social = @razonsocial, CUIT = @cuit
where DNI = @dni;
end;
GO
/****** Object:  StoredProcedure [dbo].[EXISTE_PERMISO_PERFIL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EXISTE_PERMISO_PERFIL]
@idRol int,@idPermiso int
AS
BEGIN
	SELECT Id_rol as cant FROM PERFIL where Id_rol = @idRol and Id_permiso = @idPermiso;
END;
GO
/****** Object:  StoredProcedure [dbo].[EXISTE_PERMISO_PERMISO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[EXISTE_PERMISO_PERMISO]
@idPermisoPadre int,@idPermisoHijo int
AS
BEGIN
	SELECT Id_permiso_padre FROM PERMISO_PERMISO
	where Id_permiso_padre = @idPermisoPadre
	and Id_permiso_hijo = @idPermisoHijo;
END;
GO
/****** Object:  StoredProcedure [dbo].[GENERAR_FEEDBACK]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GENERAR_FEEDBACK]
@idReserva int,@feedback varchar(1000)
AS
BEGIN
	UPDATE RESERVA set feedback = @feedback where Id_Reserva = @idReserva;
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_AREA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_AREA]
@nombre varchar(100),
@descripcion varchar(1000) = null,
@esHabilitada bit = 1,
@idv nvarchar(100) = null
AS
BEGIN
    MERGE INTO AREA_COMUN AS target
    USING (SELECT @nombre AS nombre) AS source
    ON target.nombre = source.nombre
    WHEN MATCHED THEN
        UPDATE SET descripcion = @descripcion, idv = @idv , estaHabilitada = @esHabilitada
    WHEN NOT MATCHED THEN
        INSERT (nombre, descripcion, estaHabilitada, idv)
        VALUES (@nombre, @descripcion, @esHabilitada, @idv);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_BITACORA_EVENTO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_BITACORA_EVENTO]
@fecha date,@hora time(0),@usuario nvarchar(20),@modulo varchar(20),
@operacion varchar(20),@criticidad varchar(20),@detalle varchar(200)
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM BITACORA_EVENTO)
	INSERT INTO BITACORA_EVENTO(Id,Fecha,Hora,Usuario,
				Modulo,Operacion,Criticidad,Detalle)
	VALUES
           (@id,@fecha,@hora,@usuario,
		   @modulo,@operacion,@criticidad,@detalle);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_CAMBIO_RESERVA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_CAMBIO_RESERVA]
@fechaCreacionCambio datetime,@idReserva int,@estadoReserva varchar(50),
@fechaCreacionReserva datetime,@fechaReservaInicio date,@horaReservaInicio time(0),
@fechaReservaFin date,@horaReservaFin time(0),@usuarioReserva nvarchar(20),@area varchar(100),
@feedback varchar(1000)=null,@detalle varchar(200)
AS
BEGIN
	UPDATE RESERVA_CONTROL_CAMBIOS SET esActivo = 0 where Id_Reserva = @idReserva;

	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM RESERVA_CONTROL_CAMBIOS)
	INSERT INTO RESERVA_CONTROL_CAMBIOS(Id,Fecha_creacion_cambio,esActivo,Id_Reserva,
				Estado_reserva,Fecha_creacion_reserva,Fecha_reserva_inicio,
				Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario_reserva,Area,Feedback,Detalle)
	VALUES
           (@id,@fechaCreacionCambio,1,@idReserva,
		   @estadoReserva,@fechaCreacionReserva,@fechaReservaInicio,
		   @horaReservaInicio,@fechaReservaFin,@horaReservaFin,@usuarioReserva,@area,@feedback,@detalle);

END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_EXPENSA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_EXPENSA]
@fechaEmision date,@esta_paga bit, @dni bigint, @monto float,@fvencimiento date, @svencimiento date,@periodo varchar(5),
@idv nvarchar(100) = null
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM EXPENSA)
	INSERT INTO EXPENSA (id,fecha_emision,monto,periodo,esta_paga,dni,primer_vencimiento,segundo_vencimiento,idv)
	VALUES (@id,@fechaEmision,@monto,@periodo,@esta_paga,@dni,@fvencimiento,@svencimiento,@idv);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_HASH_GLOBAL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_HASH_GLOBAL]
@nombreTabla nvarchar(50),
@idvGlobal nvarchar(100)
AS
BEGIN
    MERGE INTO HASH_GLOBAL AS target
    USING (SELECT @nombreTabla AS nombre) AS source
    ON target.nombre_tabla = source.nombre
    WHEN MATCHED THEN
        UPDATE SET idv_global = @idvGlobal
    WHEN NOT MATCHED THEN
        INSERT (nombre_tabla, idv_global)
        VALUES (@nombreTabla, @idvGlobal);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_IDIOMA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_IDIOMA]
@id char(2), @descripcion nvarchar(20), @es_estandar bit = 'false'
AS
BEGIN
    IF @es_estandar = 1
    BEGIN
        UPDATE IDIOMA SET Estandar = 0;
    END;

    INSERT INTO IDIOMA (Id, Descripcion, Estandar, esta_borrado)
    VALUES (@id, @descripcion, @es_estandar, 'false');
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PAGO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_PAGO]
@dni bigint,@codSeguridad int = null,@fecha_ejecucion datetime,@fecha_vencTarjeta date = null,
@forma_de_pago varchar(50),@monto float,@nombre_tarjeta varchar(50) = null,@nro_tarjeta bigint = null,
@idv int = null
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM PAGO)
	INSERT INTO PAGO(id,codSeguridad,fecha_ejecucion,fecha_vencTarjeta,forma_de_pago,monto,nombre_tarjeta,nro_tarjeta,dni,idv)
	VALUES (@id,@codSeguridad,@fecha_ejecucion,@fecha_vencTarjeta,@forma_de_pago,@monto,@nombre_tarjeta,@nro_tarjeta,@dni,@idv);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PERFIL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_PERFIL]
@descripcion nvarchar(50)
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(Id_rol),0)+1 FROM ROL)
	INSERT INTO ROL (Id_rol,Descripcion,esta_borrado)
	VALUES (@id,@descripcion,'false');
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PERMISO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_PERMISO]
@nombre nvarchar(20),@descripcion nvarchar(50)
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(Id_permiso),0)+1 FROM PERMISO)
	INSERT INTO PERMISO(Id_permiso,Nombre,Descripcion,esta_borrado)
	VALUES (@id,@nombre,@descripcion,'false');
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_RESERVA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_RESERVA]
@estado varchar(20),@fechaCreacion datetime,@area varchar(100),@fechaReservaInicio date,
@horaReservaInicio time(0),@fechaReservaFin date,@horaReservaFin time(0),@usuario nvarchar(20),
@feedback varchar(1000) = null,@idv nvarchar(100) = null
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(Id_Reserva),0)+1 FROM RESERVA)
	INSERT INTO RESERVA(Id_Reserva,Estado,Fecha_creacion,area,Fecha_reserva_inicio,
				Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario,feedback,idv)
	VALUES
           (@id,@estado,@fechaCreacion,@area,@fechaReservaInicio,@horaReservaInicio,
		   @fechaReservaFin,@horaReservaFin,@usuario,@feedback,@idv);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_SEGMENTO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_SEGMENTO]
@descripcion varchar(30),@monto float,@idExpensa int,@idv nvarchar(100) = null
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM SEGMENTO)
	INSERT INTO SEGMENTO(id,descripcion,monto,id_expensa,idv)
	VALUES (@id,@descripcion,@monto,@idExpensa,@idv);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_USUARIO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERTAR_USUARIO]
@Username nvarchar(20), @nombre nvarchar(20), @apellido nvarchar(20), @password nvarchar(20), @dni bigint, @cuit nvarchar(50) = null,
@fechanac date = null, @nrodepto nvarchar(3) = null,@telefono nvarchar(15) = null, @fechaIniCon date = null,@fechaFinCon date = null,
@empresa nvarchar(20) = null, @razonsocial nvarchar(20) = null, @estaBloqueado bit,@mail nvarchar(50)  = null, @rol int,
@idv nvarchar(100) = null
as
begin
INSERT INTO PERSONA VALUES (@dni,@apellido,@nombre,@fechanac,@nrodepto,@telefono,@cuit,@fechaFinCon,@fechaIniCon,@empresa,@razonsocial);
INSERT INTO USUARIO VALUES (@Username,@password,0,@estaBloqueado,GETDATE(),@mail,@dni,@rol,@idv);
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_ANIOS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_ANIOS]
as
begin
	select distinct(anio) from GANANCIA
	order by anio desc;
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_AREAS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_AREAS]
as
begin
	select Nombre,Descripcion,estaHabilitada,idv
	from AREA_COMUN;
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_CAMBIOS_RESERVAS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_CAMBIOS_RESERVAS]
@cantRegistros int
AS
BEGIN
	SELECT TOP (@cantRegistros) id,Fecha_creacion_cambio,Id_Reserva,Estado_reserva,Fecha_creacion_reserva,
	Fecha_reserva_inicio,Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario_reserva,
	esActivo,Area,Feedback,Detalle
	FROM RESERVA_CONTROL_CAMBIOS
	order by Fecha_creacion_cambio desc;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_EVENTOS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_EVENTOS]
@cantRegistros int
AS
BEGIN
	SELECT TOP (@cantRegistros) id,fecha,hora,usuario,modulo,operacion,criticidad,detalle
	FROM BITACORA_EVENTO
	order by fecha desc,hora desc;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_EXPENSAS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_EXPENSAS]
@dni bigint
AS
BEGIN
	select id,esta_paga,fecha_emision,idv from expensa where dni = @dni;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_EXPENSAS_TODAS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_EXPENSAS_TODAS]
AS
BEGIN
	select id,esta_paga,fecha_emision, dni,idv from expensa;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_GANANCIAS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_GANANCIAS]
@anio int
AS
BEGIN
	SELECT anio,mes,Ganancia,idv
	FROM GANANCIA
	WHERE (@anio = 0 OR Anio = @anio)
	ORDER BY anio,mes ASC;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_HIJOS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_HIJOS]
@idPadre int
as
begin
select pp.Id_permiso_hijo, p.Descripcion, p.Nombre
from PERMISO_PERMISO pp
inner join PERMISO p on p.Id_permiso = pp.Id_permiso_hijo
where pp.Id_permiso_padre = @idPadre
end
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_IDIOMA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_IDIOMA]
@id char(2)
as
begin
select i.Id from Idioma i where i.Id = @id and esta_borrado = 'false'
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_IDIOMAS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_IDIOMAS]
as
begin
select i.Id, i.Descripcion, i.Estandar from Idioma i where esta_borrado = 'false' order by i.estandar desc
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_METRICAS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_METRICAS]
@ordenamiento bit
AS
BEGIN
    SELECT usuario, cantReservas AS cantidad_reservas, idv
    FROM dbo.METRICA
    ORDER BY
        CASE WHEN @ordenamiento = 1 THEN cantReservas END DESC,
        CASE WHEN @ordenamiento = 0 THEN cantReservas END ASC;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PAGOS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_PAGOS]
@dni bigint
AS
BEGIN
	select id,codSeguridad,fecha_ejecucion,fecha_vencTarjeta,forma_de_pago,monto,nombre_tarjeta,nro_tarjeta,idv
	from PAGO
	where dni = @dni;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PAGOS_TODOS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_PAGOS_TODOS]
AS
BEGIN
	select id,codSeguridad,fecha_ejecucion,fecha_vencTarjeta,forma_de_pago,monto,nombre_tarjeta,nro_tarjeta,idv
	from PAGO;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERFIL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[LISTAR_PERFIL]
@id int
AS
BEGIN
	select Id_rol,Descripcion
	from ROL
	where Id_rol = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERFILES]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_PERFILES]
AS
BEGIN
	select *
	from ROL
	where esta_borrado = 'false';
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERMISO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_PERMISO]
@id int
AS
BEGIN
	select Id_permiso,Descripcion,Nombre from PERMISO where Id_permiso = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERMISOS_SIMPLES]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_PERMISOS_SIMPLES]
AS
BEGIN
	select Id_permiso,Descripcion,Nombre from PERMISO where esta_borrado = 'false';
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERMISOS_X_PERFIL]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_PERMISOS_X_PERFIL]
@id int
as
begin
select perm.Id_permiso, perm.Descripcion, perm.Nombre
from PERFIL p
inner join ROL r on p.Id_rol = r.Id_rol
inner join PERMISO perm on perm.Id_permiso = p.Id_permiso
where r.Id_rol = @id
end
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_RECAUDACION]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_RECAUDACION]
@ordenamiento bit
AS
BEGIN
    SELECT periodo as PERIODO, SUM(monto) AS RECAUDACION
    FROM dbo.EXPENSA
    GROUP BY periodo
    ORDER BY
        CASE WHEN @ordenamiento = 1 THEN SUM(monto) END DESC,
        CASE WHEN @ordenamiento = 0 THEN SUM(monto) END ASC;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_RESERVAS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_RESERVAS]
@cantRegistros int
AS
BEGIN
	SELECT TOP (@cantRegistros) Id_Reserva,Estado,Fecha_creacion,area,Fecha_reserva_inicio,
				Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario,feedback,idv
	FROM RESERVA
	order by Fecha_creacion desc;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_TRADUCCIONES]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[LISTAR_TRADUCCIONES]
@idIdioma char(2)
AS
BEGIN
	SELECT nombre_objeto,traduccion from TRADUCCION where id_idioma = @idIdioma;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_USUARIO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_USUARIO]
@username nvarchar(20)
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail, u.Fecha_alta,
u.Cant_intentos, u.IDV, u.Contraseña
from dbo.PERSONA p
join dbo.USUARIO u on u.DNI = p.DNI
join ROL rol on rol.Id_rol = u.Id_rol
where u.Username = @username
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_USUARIOS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_USUARIOS]
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail, u.Fecha_alta,
u.Cant_intentos, u.IDV, u.Contraseña
from dbo.PERSONA p
join dbo.USUARIO u on u.DNI = p.DNI
join ROL rol on rol.Id_rol = u.Id_rol
end;
GO
/****** Object:  StoredProcedure [dbo].[MODIFICAR_RESERVA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MODIFICAR_RESERVA]
@idReserva int,@estado varchar(20),@area varchar(100),@fechaIni date,
@horaIni time(0),@fechaFin date,@horaFin time(0),@usuario nvarchar(20),
@feedback varchar(1000) = null,@idv nvarchar(100) = null
AS
BEGIN
	UPDATE RESERVA SET Estado = @estado, area = @area, Fecha_reserva_inicio = @fechaIni,
	Hora_reserva_inicio = @horaIni, Fecha_reserva_fin = @fechaFin, Hora_reserva_fin = @horaFin,
	usuario = @usuario, feedback = @feedback, idv = @idv
	WHERE Id_Reserva = @idReserva;
END;
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PERFIL_USUARIO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[OBTENER_PERFIL_USUARIO]
@Username nvarchar(20)
as
begin
select rol.Id_rol, rol.Descripcion from ROL rol
inner join USUARIO u on u.Id_rol = rol.Id_rol
where u.Username = @Username
end;
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_SEGMENTOS]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_SEGMENTOS]
AS
BEGIN
	select id,descripcion,monto,idv from SEGMENTO;
END;
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_SEGMENTOS_EXPENSA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_SEGMENTOS_EXPENSA]
@idExpensa int
AS
BEGIN
	select id,descripcion,monto,idv from SEGMENTO where id_expensa = @idExpensa;
END;
GO
/****** Object:  StoredProcedure [dbo].[SALDAR_EXPENSA]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SALDAR_EXPENSA]
@idPago int,@idExpensa int
AS
BEGIN
	INSERT INTO EXPENSA_PAGO(id_expensa,id_pago)
	VALUES (@idExpensa,@idPago);

	UPDATE EXPENSA set esta_paga = 'true' where id = @idExpensa;
END;
GO
/****** Object:  StoredProcedure [dbo].[SUMAR_INTENTO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SUMAR_INTENTO]
@username nvarchar(20)
AS
BEGIN
    UPDATE USUARIO SET Cant_intentos = Cant_intentos + 1 WHERE Username = @username;
END;
GO
/****** Object:  StoredProcedure [dbo].[VALIDAR_CREDENCIAL_USUARIO]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[VALIDAR_CREDENCIAL_USUARIO]
@Username nvarchar(20), @Password nvarchar(20)
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail, u.Fecha_alta, u.IDV
from USUARIO u
inner join ROL rol on rol.Id_rol = u.Id_rol
inner join PERSONA p on p.DNI = u.DNI
where u.Username = @Username
AND u.Contraseña = @Password
end;
GO
/****** Object:  StoredProcedure [dbo].[VALIDAR_DISPONIBILIDAD]    Script Date: 10/12/2023 23:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[VALIDAR_DISPONIBILIDAD]
@area varchar(100),@fechaIni date,
@horaIni time(0),@fechaFin date,@horaFin time(0),@usuario nvarchar(20)
AS
BEGIN
	SELECT Id_Reserva FROM RESERVA
	WHERE Area = @area
	AND Usuario = @usuario
	AND (((Fecha_reserva_inicio = @fechaIni and Hora_reserva_inicio <= @horaFin and Fecha_reserva_fin = @fechaIni and Hora_reserva_fin >= @horaIni) or
		  (Fecha_reserva_inicio = @fechaFin and Hora_reserva_inicio <= @horaFin and Fecha_reserva_fin = @fechaFin and Hora_reserva_fin >= @horaIni))
		AND estado = 'Pendiente')
	UNION
	SELECT Id_Reserva FROM RESERVA
	WHERE Area = @area
	AND Usuario = @usuario
	AND estado = 'Pendiente'
	;
END;
GO
USE [master]
GO
ALTER DATABASE [MiEdificio] SET  READ_WRITE 
GO

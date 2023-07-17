USE [master]
GO
/****** Object:  Database [MiEdificio]    Script Date: 17/7/2023 15:47:49 ******/
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
/****** Object:  Table [dbo].[EXPENSA]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXPENSA](
	[id] [int] NOT NULL,
	[fecha_emision] [date] NOT NULL,
	[monto] [float] NOT NULL,
	[periodo] [varchar](5) NOT NULL,
	[esta_paga] [bit] NULL,
	[dni] [bigint] NOT NULL,
	[primer_vencimiento] [date] NULL,
	[segundo_vencimiento] [date] NULL,
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
/****** Object:  Table [dbo].[EXPENSA_PAGO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  Table [dbo].[IDIOMA]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  Table [dbo].[PAGO]    Script Date: 17/7/2023 15:47:50 ******/
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
 CONSTRAINT [PK_PAGO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERFIL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  Table [dbo].[PERMISO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  Table [dbo].[PERMISO_PERMISO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  Table [dbo].[PERSONA]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  Table [dbo].[ROL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  Table [dbo].[SEGMENTO]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEGMENTO](
	[id] [int] NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[monto] [float] NOT NULL,
	[id_expensa] [int] NOT NULL,
 CONSTRAINT [PK_SEGMENTO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRADUCCION]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRADUCCION](
	[nombre_objeto] [varchar](40) NOT NULL,
	[id_idioma] [char](2) NOT NULL,
	[traduccion] [varchar](30) NOT NULL,
 CONSTRAINT [PK_TRADUCCION] PRIMARY KEY CLUSTERED 
(
	[nombre_objeto] ASC,
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 17/7/2023 15:47:50 ******/
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
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
ALTER TABLE [dbo].[SEGMENTO]  WITH CHECK ADD  CONSTRAINT [FK_SEGMENTO_EXPENSA] FOREIGN KEY([id_expensa])
REFERENCES [dbo].[EXPENSA] ([id])
GO
ALTER TABLE [dbo].[SEGMENTO] CHECK CONSTRAINT [FK_SEGMENTO_EXPENSA]
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
/****** Object:  StoredProcedure [dbo].[ASOCIAR_PERMISO_PERFIL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[ASOCIAR_PERMISO_PERMISO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[BORRAR_IDIOMA]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[BORRAR_PERFIL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[BORRAR_PERMISO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[BUSCAR_EXPENSA]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_EXPENSA]
@dni bigint,@periodo varchar(5)
AS
BEGIN
	select id,esta_paga,fecha_emision from EXPENSA where dni = @dni and periodo = @periodo;
END;
GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_EXPENSAS_X_PAGO]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_EXPENSAS_X_PAGO]
@idPago int
AS
BEGIN
	select e.id,e.fecha_emision,e.esta_paga,e.dni
	from PAGO p
	join EXPENSA_PAGO ep on ep.id_pago = p.id
	join EXPENSA e on e.id = ep.id_expensa
	where p.id = @idPago;
END;
GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_PAGO]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_PAGO]
@dni bigint,@fecha_ejecucion datetime
AS
BEGIN
	select id,codSeguridad,fecha_ejecucion,fecha_vencTarjeta,forma_de_pago,monto,nombre_tarjeta,nro_tarjeta
	from PAGO
	where dni = @dni and fecha_ejecucion = @fecha_ejecucion;
END;
GO
/****** Object:  StoredProcedure [dbo].[CAMBIAR_PASSWORD]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[CAMBIAR_PERFIL_USUARIO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[DESASOCIAR_PERMISO_PERFIL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[DESBLOQUEAR_USUARIO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[EDITAR_IDIOMA]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[EDITAR_PERFIL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[EDITAR_PERMISO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[EDITAR_USUARIO]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EDITAR_USUARIO]
@Username nvarchar(20),@password nvarchar(20) = null, @nombre nvarchar(20), @apellido nvarchar(20), @dni bigint,
@fechanac date, @nrodepto nvarchar(3) = null,@telefono nvarchar(15) = null, @fechaIniCon date = null,@fechaFinCon date = null, @empresa nvarchar(20) = null,
@razonsocial nvarchar(20) = null,@cuit nvarchar(50) = null, @estaBloqueado bit,@mail nvarchar(50) = null, @rol int
as
begin
Update USUARIO 
set  Contraseña = CASE WHEN @password IS NULL THEN Contraseña ELSE @password END, Mail = @mail, Esta_bloqueado = @estaBloqueado, Id_rol = @rol
where Username = @Username;

update PERSONA
set  Nombre = @nombre, Apellido = @apellido, Fecha_nacimiento = @fechanac, Nro_departamento = @nrodepto, Telefono = @telefono,
Fecha_inicio_concesion = @fechaIniCon, Fecha_fin_concesion = @fechaFinCon, Nombre_empresa = @empresa, Razon_social = @razonsocial, CUIT = @cuit
where DNI = @dni;
end;
GO
/****** Object:  StoredProcedure [dbo].[EXISTE_PERMISO_PERFIL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[EXISTE_PERMISO_PERMISO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[INSERTAR_EXPENSA]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_EXPENSA]
@fechaEmision date,@esta_paga bit, @dni bigint, @monto float,@fvencimiento date, @svencimiento date,@periodo varchar(5)
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM EXPENSA)
	INSERT INTO EXPENSA (id,fecha_emision,monto,periodo,esta_paga,dni,primer_vencimiento,segundo_vencimiento)
	VALUES (@id,@fechaEmision,@monto,@periodo,@esta_paga,@dni,@fvencimiento,@svencimiento);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_IDIOMA]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[INSERTAR_PAGO]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_PAGO]
@dni bigint,@codSeguridad int = null,@fecha_ejecucion datetime,@fecha_vencTarjeta date = null,
@forma_de_pago varchar(50),@monto float,@nombre_tarjeta varchar(50) = null,@nro_tarjeta bigint = null
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM PAGO)
	INSERT INTO PAGO(id,codSeguridad,fecha_ejecucion,fecha_vencTarjeta,forma_de_pago,monto,nombre_tarjeta,nro_tarjeta,dni)
	VALUES (@id,@codSeguridad,@fecha_ejecucion,@fecha_vencTarjeta,@forma_de_pago,@monto,@nombre_tarjeta,@nro_tarjeta,@dni);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PERFIL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[INSERTAR_PERMISO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[INSERTAR_SEGMENTO]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_SEGMENTO]
@descripcion varchar(30),@monto float,@idExpensa int
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM SEGMENTO)
	INSERT INTO SEGMENTO(id,descripcion,monto,id_expensa)
	VALUES (@id,@descripcion,@monto,@idExpensa);
END;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_USUARIO]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERTAR_USUARIO]
@Username nvarchar(20), @nombre nvarchar(20), @apellido nvarchar(20), @password nvarchar(20), @dni bigint, @cuit nvarchar(50) = null,
@fechanac date = null, @nrodepto nvarchar(3) = null,@telefono nvarchar(15) = null, @fechaIniCon date = null,@fechaFinCon date = null,
@empresa nvarchar(20) = null, @razonsocial nvarchar(20) = null, @estaBloqueado bit,@mail nvarchar(50)  = null, @rol int
as
begin
INSERT INTO PERSONA VALUES (@dni,@apellido,@nombre,@fechanac,@nrodepto,@telefono,@cuit,@fechaFinCon,@fechaIniCon,@empresa,@razonsocial);
INSERT INTO USUARIO VALUES (@Username,@password,0,@estaBloqueado,GETDATE(),@mail,@dni,@rol);
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_EXPENSAS]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_EXPENSAS]
@dni bigint
AS
BEGIN
	select id,esta_paga,fecha_emision from expensa where dni = @dni;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_HIJOS]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_IDIOMA]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_IDIOMAS]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_PAGOS]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LISTAR_PAGOS]
@dni bigint
AS
BEGIN
	select id,codSeguridad,fecha_ejecucion,fecha_vencTarjeta,forma_de_pago,monto,nombre_tarjeta,nro_tarjeta
	from PAGO
	where dni = @dni;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERFIL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_PERFILES]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_PERMISO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_PERMISOS_SIMPLES]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_PERMISOS_X_PERFIL]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_TRADUCCIONES]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_USUARIO]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_USUARIO]
@username nvarchar(20)
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail, u.Fecha_alta, u.Cant_intentos
from dbo.PERSONA p
join dbo.USUARIO u on u.DNI = p.DNI
join ROL rol on rol.Id_rol = u.Id_rol
where u.Username = @username
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_USUARIOS]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_USUARIOS]
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail, u.Fecha_alta, u.Cant_intentos
from dbo.PERSONA p
join dbo.USUARIO u on u.DNI = p.DNI
join ROL rol on rol.Id_rol = u.Id_rol
end;
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PERFIL_USUARIO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_SEGMENTOS_EXPENSA]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[OBTENER_SEGMENTOS_EXPENSA]
@idExpensa int
AS
BEGIN
	select id,descripcion,monto from SEGMENTO where id_expensa = @idExpensa;
END;
GO
/****** Object:  StoredProcedure [dbo].[SALDAR_EXPENSA]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[SUMAR_INTENTO]    Script Date: 17/7/2023 15:47:50 ******/
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
/****** Object:  StoredProcedure [dbo].[VALIDAR_CREDENCIAL_USUARIO]    Script Date: 17/7/2023 15:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[VALIDAR_CREDENCIAL_USUARIO]
@Username nvarchar(20), @Password nvarchar(20)
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail, u.Fecha_alta
from USUARIO u
inner join ROL rol on rol.Id_rol = u.Id_rol
inner join PERSONA p on p.DNI = u.DNI
where u.Username = @Username
AND u.Contraseña = @Password
end;
GO
USE [master]
GO
ALTER DATABASE [MiEdificio] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [MiEdificio]    Script Date: 22/6/2023 10:28:19 ******/
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
/****** Object:  Table [dbo].[IDIOMA]    Script Date: 22/6/2023 10:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDIOMA](
	[Id] [char](2) NOT NULL,
	[Descripcion] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_IDIOMA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERFIL]    Script Date: 22/6/2023 10:28:20 ******/
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
/****** Object:  Table [dbo].[PERMISO]    Script Date: 22/6/2023 10:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISO](
	[Id_permiso] [int] NOT NULL,
	[Descripcion] [nchar](20) NULL,
	[Nombre] [nchar](20) NOT NULL,
 CONSTRAINT [PK_PERMISO] PRIMARY KEY CLUSTERED 
(
	[Id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERMISO_PERMISO]    Script Date: 22/6/2023 10:28:20 ******/
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
/****** Object:  Table [dbo].[PERSONA]    Script Date: 22/6/2023 10:28:20 ******/
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
/****** Object:  Table [dbo].[ROL]    Script Date: 22/6/2023 10:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[Id_rol] [int] NOT NULL,
	[Descripcion] [nchar](20) NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[Id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 22/6/2023 10:28:20 ******/
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
	[Idioma] [nvarchar](10) NULL,
	[Mail] [nvarchar](50) NULL,
	[DNI] [bigint] NOT NULL,
	[Id_rol] [int] NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[CAMBIAR_PASSWORD]    Script Date: 22/6/2023 10:28:20 ******/
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
/****** Object:  StoredProcedure [dbo].[EDITAR_USUARIO]    Script Date: 22/6/2023 10:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EDITAR_USUARIO]
@Username nvarchar(20), @nombre nvarchar(20), @apellido nvarchar(20), @dni bigint,
@fechanac date, @nrodepto nvarchar(3) = null,@telefono nvarchar(15) = null, @fechaIniCon date = null,@fechaFinCon date = null, @empresa nvarchar(20) = null, @razonsocial nvarchar(20) = null, @estaBloqueado bit,@mail nvarchar(50) = null
as
begin
Update USUARIO 
set  Mail = @mail, Esta_bloqueado = @estaBloqueado
where Username = @Username;

update PERSONA
set  Nombre = @nombre, Apellido = @apellido, Fecha_nacimiento = @fechanac, Nro_departamento = @nrodepto, Telefono = @telefono,
Fecha_inicio_concesion = @fechaIniCon, Fecha_fin_concesion = @fechaFinCon, Nombre_empresa = @empresa, Razon_social = @razonsocial
where DNI = @dni;
end;
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_USUARIO]    Script Date: 22/6/2023 10:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERTAR_USUARIO]
@Username nvarchar(20), @nombre nvarchar(20), @apellido nvarchar(20), @password nvarchar(20), @dni bigint, @cuit nvarchar(50) = null,
@fechanac date = null, @nrodepto nvarchar(3) = null,@telefono nvarchar(15) = null, @fechaIniCon date = null,@fechaFinCon date = null, @empresa nvarchar(20) = null, @razonsocial nvarchar(20) = null, @estaBloqueado bit,@mail nvarchar(50)  = null
as
begin
INSERT INTO PERSONA VALUES (@dni,@apellido,@nombre,@fechanac,@nrodepto,@telefono,@cuit,@fechaFinCon,@fechaIniCon,@empresa,@razonsocial);
INSERT INTO USUARIO VALUES (@Username,@password,0,@estaBloqueado,GETDATE(),null,@mail,@dni,null);
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_HIJOS]    Script Date: 22/6/2023 10:28:20 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_IDIOMAS]    Script Date: 22/6/2023 10:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_IDIOMAS]
as
begin
select i.Id, i.Descripcion from Idioma i
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PERMISOS_X_PERFIL]    Script Date: 22/6/2023 10:28:20 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_USUARIO]    Script Date: 22/6/2023 10:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_USUARIO]
@username nvarchar(20)
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail
from dbo.PERSONA p
join dbo.USUARIO u on u.DNI = p.DNI
join ROL rol on rol.Id_rol = u.Id_rol
where u.Username = @username
end;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_USUARIOS]    Script Date: 22/6/2023 10:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LISTAR_USUARIOS]
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail
from dbo.PERSONA p
join dbo.USUARIO u on u.DNI = p.DNI
join ROL rol on rol.Id_rol = u.Id_rol
end;
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PERFIL_USUARIO]    Script Date: 22/6/2023 10:28:20 ******/
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
/****** Object:  StoredProcedure [dbo].[VALIDAR_CREDENCIAL_USUARIO]    Script Date: 22/6/2023 10:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[VALIDAR_CREDENCIAL_USUARIO]
@Username nvarchar(20), @Password nvarchar(20)
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail 
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

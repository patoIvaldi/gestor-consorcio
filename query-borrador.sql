select * from dbo.PERSONA;
select * from dbo.ROL;
select * from dbo.PERMISO;
select * from dbo.USUARIO;
select * from dbo.PERFIL;
select * from dbo.PERMISO_PERMISO;


CREATE proc [dbo].[VALIDAR_CREDENCIAL_USUARIO]
@Username nvarchar(20), @Password nvarchar(20)
as
begin
select u.Username, per.Nombre, per.Apellido, rol.Id_rol, rol.Descripcion 
from USUARIO u
inner join ROL rol on rol.Id_rol = u.Id_rol
inner join PERSONA per on per.DNI = u.DNI
where u.Username = @Username
AND u.Contraseña = @Password
end;

CREATE proc [dbo].[LISTAR_PERMISOS_X_PERFIL]
@id int
as
begin
select perm.Id_permiso, perm.Descripcion, perm.Nombre
from PERFIL p
inner join ROL r on p.Id_rol = r.Id_rol
inner join PERMISO perm on perm.Id_permiso = p.Id_permiso
where r.Id_rol = @id
end;

CREATE proc [dbo].[LISTAR_HIJOS]
@idPadre int
as
begin
select pp.Id_permiso_hijo, p.Descripcion, p.Nombre
from PERMISO_PERMISO pp
inner join PERMISO p on p.Id_permiso = pp.Id_permiso_hijo
where pp.Id_permiso_padre = @idPadre
end;
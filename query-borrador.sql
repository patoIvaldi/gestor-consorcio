select * from dbo.PERSONA;
select * from dbo.USUARIO;
select * from dbo.ROL;
select * from dbo.PERMISO;
select * from dbo.PERFIL;
select * from dbo.PERMISO_PERMISO;
select * from dbo.IDIOMA;

CREATE proc [dbo].[CAMBIAR_PASSWORD]
@Username nvarchar(20), @Password nvarchar(20)
as
begin
update USUARIO
set Contraseña = @Password 
where Username = @Username;
end;


alter proc [dbo].[VALIDAR_CREDENCIAL_USUARIO]
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

CREATE proc [dbo].[LISTAR_PERMISOS_X_PERFIL]
@id int
as
begin
select perm.Id_permiso, perm.Descripcion, perm.Nombre
from PERFIL p
inner join ROL r on p.Id_rol = r.Id_rol
inner join PERMISO perm on perm.Id_permiso = p.Id_permiso
where r.Id_rol = '1'
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

alter proc [dbo].[LISTAR_IDIOMAS]
as
begin
select i.Id, i.Descripcion, i.Estandar from Idioma i where esta_borrado = 'false' order by i.estandar desc
end;

alter proc [dbo].[LISTAR_IDIOMA]
@id char(2)
as
begin
select i.Id from Idioma i where i.Id = @id and esta_borrado = 'false'
end;


alter proc [dbo].[LISTAR_USUARIOS]
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail, u.Fecha_alta
from dbo.PERSONA p
join dbo.USUARIO u on u.DNI = p.DNI
join ROL rol on rol.Id_rol = u.Id_rol
end;

alter proc [dbo].[OBTENER_PERFIL_USUARIO]
@Username nvarchar(20)
as
begin
select rol.Id_rol, rol.Descripcion from ROL rol
inner join USUARIO u on u.Id_rol = rol.Id_rol
where u.Username = @Username
end;

alter proc [dbo].[EDITAR_USUARIO]
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

alter proc [dbo].[INSERTAR_USUARIO]
@Username nvarchar(20), @nombre nvarchar(20), @apellido nvarchar(20), @password nvarchar(20), @dni bigint, @cuit nvarchar(50) = null,
@fechanac date = null, @nrodepto nvarchar(3) = null,@telefono nvarchar(15) = null, @fechaIniCon date = null,@fechaFinCon date = null,
@empresa nvarchar(20) = null, @razonsocial nvarchar(20) = null, @estaBloqueado bit,@mail nvarchar(50)  = null, @rol int
as
begin
INSERT INTO PERSONA VALUES (@dni,@apellido,@nombre,@fechanac,@nrodepto,@telefono,@cuit,@fechaFinCon,@fechaIniCon,@empresa,@razonsocial);
INSERT INTO USUARIO VALUES (@Username,@password,0,@estaBloqueado,GETDATE(),@mail,@dni,@rol);
end;

alter proc [dbo].[LISTAR_USUARIO]
@username nvarchar(20)
as
begin
select p.DNI, p.Apellido, p.Nombre, p.Fecha_nacimiento, p.Nro_departamento, p.Telefono, p.CUIT, p.Fecha_inicio_concesion, p.Fecha_fin_concesion,
p.Nombre_empresa, p.Razon_social, rol.Id_rol, rol.Descripcion, u.Username, u.Esta_bloqueado, u.Mail, u.Fecha_alta
from dbo.PERSONA p
join dbo.USUARIO u on u.DNI = p.DNI
join ROL rol on rol.Id_rol = u.Id_rol
where u.Username = @username
end;

alter proc [dbo].[DESBLOQUEAR_USUARIO]
@Username nvarchar(20)
as
begin
update USUARIO
set Esta_bloqueado = CASE WHEN Esta_bloqueado = 1 THEN 0 ELSE 1 END
where Username = @Username;
end;

alter PROC [dbo].[INSERTAR_IDIOMA]
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

ALTER PROC [dbo].[BORRAR_IDIOMA]
@id char(2)
AS
BEGIN
    UPDATE IDIOMA SET esta_borrado = 'true' WHERE id = @id;
END;


ALTER TABLE expensa
ADD CONSTRAINT UC_periodo_dni UNIQUE (periodo,dni);

	/*declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM EXPENSA)
	INSERT INTO EXPENSA (id,fecha_emision,monto,periodo,estado,dni,primer_vencimiento,segundo_vencimiento)
	VALUES (@id,@fechaEmision,@monto,@periodo,@estado,@dni,@fvencimiento,@svencimiento);*/

CREATE PROC [dbo].[INSERTAR_SEGMENTO]
@descripcion varchar(30),@monto float,@idExpensa int
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM SEGMENTO)
	INSERT INTO SEGMENTO(id,descripcion,monto,id_expensa)
	VALUES (@id,@descripcion,@monto,@idExpensa);
END;



select * from expensa;
select * from SEGMENTO;
select * from PERSONA;

select id,estado,fecha_emision from EXPENSA where dni = '999999999' and periodo = '07/2023';


CREATE PROC [dbo].[SALDAR_EXPENSA]
@idPago int,@idExpensa int
AS
BEGIN
	INSERT INTO EXPENSA_PAGO(id_expensa,id_pago)
	VALUES (@idExpensa,@idPago);

	UPDATE EXPENSA set estado = 'true' where id = @idExpensa;
END;

select * from EXPENSA;

alter PROC [dbo].[BUSCAR_EXPENSAS_X_PAGO]
@idPago int
AS
BEGIN
	select e.id,e.fecha_emision,e.esta_paga,e.dni
	from PAGO p
	join EXPENSA_PAGO ep on ep.id_pago = p.id
	join EXPENSA e on e.id = ep.id_expensa
	where p.id = @idPago;
END;

select * from dbo.USUARIO;
select * from dbo.ROL;
select * from dbo.PERMISO;
select * from dbo.PERFIL;
select * from dbo.PERMISO_PERMISO;


CREATE PROC [dbo].[ASOCIAR_PERMISO_PERMISO]
@idPermisoPadre int,@idPermisoHijo int
AS
BEGIN
	INSERT INTO PERMISO_PERMISO (Id_permiso_padre,Id_permiso_hijo) VALUES (@idPermisoPadre,@idPermisoHijo);
END;

create PROC [dbo].[LISTAR_TRADUCCIONES]
@idIdioma char(2)
AS
BEGIN
	SELECT nombre_objeto,traduccion from TRADUCCION where id_idioma = @idIdioma;
END;

select * from TRADUCCION;

alter PROC [dbo].[LISTAR_RESERVAS]
@cantRegistros int
AS
BEGIN
	SELECT TOP (@cantRegistros) Id_Reserva,Estado,Fecha_creacion,area,Fecha_reserva_inicio,
				Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario,feedback
	FROM RESERVA
	order by Fecha_creacion desc;
END;

SELECT * FROM BITACORA_EVENTO;
select * from RESERVA_CONTROL_CAMBIOS;
select * from RESERVA;

alter PROC [dbo].[BUSCAR_CAMBIOS_RESERVAS]
@fechaIni Date = null, @fechaFin Date = null,
@usuario nvarchar(20) = null,@estado varchar(50) = null,@esActivo bit = null
AS
BEGIN
    SELECT id,Fecha_creacion_cambio,Id_Reserva,Estado_reserva,Fecha_creacion_reserva,
	Fecha_reserva_inicio,Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario_reserva,
	esActivo,Detalle
    FROM RESERVA_CONTROL_CAMBIOS
    WHERE
        ( @fechaIni IS NULL OR Fecha_creacion_cambio >= @fechaIni )
        AND ( @fechaFin IS NULL OR Fecha_creacion_cambio <= @fechaFin )
        AND ( @usuario IS NULL OR Usuario_reserva = @usuario )
        AND ( @estado IS NULL OR Estado_reserva = @estado )
        AND ( @esActivo IS NULL OR esActivo = @esActivo )
    ORDER BY Fecha_creacion_reserva DESC;
END;



	SELECT TOP (100) id,Id_Reserva,Estado_reserva,Fecha_creacion_reserva,
	Fecha_reserva_inicio,Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario_reserva,
	esActivo,Detalle
	FROM RESERVA_CONTROL_CAMBIOS
	order by Fecha_creacion_reserva desc;

	select * from BITACORA_EVENTO;

CREATE PROC [dbo].[INSERTAR_CAMBIO_RESERVA]
@fechaCreacionCambio datetime,@idReserva int,@estadoReserva varchar(50),
@fechaCreacionReserva datetime,@fechaReservaInicio date,@horaReservaInicio time(0),
@fechaReservaFin date,@horaReservaFin time(0),@usuarioReserva nvarchar(20),@detalle varchar(200)
AS
BEGIN
	UPDATE RESERVA_CONTROL_CAMBIOS SET esActivo = 0 where Id_Reserva = @idReserva;

	declare @id int
	set @id = (SELECT ISNULL(MAX(id),0)+1 FROM RESERVA_CONTROL_CAMBIOS)
	INSERT INTO RESERVA_CONTROL_CAMBIOS(Id,Fecha_creacion_cambio,esActivo,Id_Reserva,
				Estado_reserva,Fecha_creacion_reserva,Fecha_reserva_inicio,
				Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario_reserva,Detalle)
	VALUES
           (@id,@fechaCreacionCambio,1,@idReserva,
		   @estadoReserva,@fechaCreacionReserva,@fechaReservaInicio,
		   @horaReservaInicio,@fechaReservaFin,@horaReservaFin,@usuarioReserva,@detalle);

END;


alter PROC [dbo].[INSERTAR_RESERVA]
@estado varchar(20),@fechaCreacion datetime,@area varchar(100),@fechaReservaInicio date,
@horaReservaInicio time(0),@fechaReservaFin date,@horaReservaFin time(0),@usuario nvarchar(20),
@feedback varchar(1000) = null
AS
BEGIN
	declare @id int
	set @id = (SELECT ISNULL(MAX(Id_Reserva),0)+1 FROM RESERVA)
	INSERT INTO RESERVA(Id_Reserva,Estado,Fecha_creacion,area,Fecha_reserva_inicio,
				Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario,feedback)
	VALUES
           (@id,@estado,@fechaCreacion,@area,@fechaReservaInicio,@horaReservaInicio,
		   @fechaReservaFin,@horaReservaFin,@usuario,@feedback);
END;

CREATE PROC [dbo].[GENERAR_FEEDBACK]
@idReserva int,@feedback varchar(1000)
AS
BEGIN
	UPDATE RESERVA set feedback = @feedback where Id_Reserva = @idReserva;
END;

CREATE PROC [dbo].[MODIFICAR_RESERVA]
@idReserva int,@estado varchar(20),@area varchar(100),@fechaIni date,
@horaIni time(0),@fechaFin date,@horaFin time(0),@usuario nvarchar(20),
@feedback varchar(1000) = null
AS
BEGIN
	UPDATE RESERVA SET Estado = @estado, area = @area, Fecha_reserva_inicio = @fechaIni,
	Hora_reserva_inicio = @horaIni, Fecha_reserva_fin = @fechaFin, Hora_reserva_fin = @horaFin,
	usuario = @usuario, feedback = @feedback
	WHERE Id_Reserva = @idReserva;
END;

ALTER PROC [dbo].[VALIDAR_DISPONIBILIDAD]
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
	OR estado = 'Pendiente'
	;
END;

ALTER PROC [dbo].[INSERTAR_AREA]
@nombre varchar(100),
@descripcion varchar(1000) = null,
@esHabilitada bit = 1 -- Asignar 1 en lugar de 'true' para el valor de bit
AS
BEGIN
    MERGE INTO AREA_COMUN AS target
    USING (SELECT @nombre AS nombre) AS source
    ON target.nombre = source.nombre
    WHEN MATCHED THEN
        UPDATE SET descripcion = @descripcion, estaHabilitada = @esHabilitada
    WHEN NOT MATCHED THEN
        INSERT (nombre, descripcion, estaHabilitada)
        VALUES (@nombre, @descripcion, @esHabilitada);
END;

CREATE proc [dbo].[LISTAR_AREAS]
as
begin
	select Nombre,Descripcion,estaHabilitada
	from AREA_COMUN;
end;

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

CREATE proc [dbo].[BUSCAR_IDV_GLOBAL]
@idvGlobal nvarchar(100)
as
begin
	select count(*) as total
	from HASH_GLOBAL where idv_global = @idvGlobal;
end;

CREATE proc [dbo].[ACTUALIZAR_IDV_USUARIO]
@idv nvarchar(100),@usuario nvarchar(20)
as
begin
	UPDATE USUARIO SET idv = @idv where Username = @usuario;
end;

CREATE PROC [dbo].[LISTAR_METRICAS]
@ordenamiento bit
AS
BEGIN
    SELECT usuario, cantReservas AS cantidad_reservas
    FROM dbo.METRICA
    ORDER BY
        CASE WHEN @ordenamiento = 1 THEN cantReservas END DESC,
        CASE WHEN @ordenamiento = 0 THEN cantReservas END ASC;
END;
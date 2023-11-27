SELECT * FROM BITACORA_EVENTO where usuario = 'admin' and operacion = 'Insertar';
SELECT * FROM usuario;

-- Declaración de variables para los parámetros
DECLARE @fechaIni Date;  -- Cambia la fecha según tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @fechaFin Date;  -- Cambia la fecha según tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @usuario nvarchar(20);  -- Cambia el nombre de usuario según tu necesidad o deja en NULL si no deseas filtrar por usuario.
DECLARE @estado varchar(50);     -- Cambia el módulo según tu necesidad o deja en NULL si no deseas filtrar por módulo.
DECLARE @esActivo bit;  -- Cambia la operación según tu necesidad o deja en NULL si no deseas filtrar por operación.
DECLARE @criticidad varchar(20);  -- Cambia la criticidad según tu necesidad o deja en NULL si no deseas filtrar por criticidad.
DECLARE @area varchar(100);
DECLARE @horaIni time;
DECLARE @horaFin time;
DECLARE @idReserva int;

-- Asignación de valores a las variables
SET @fechaIni = '2023-11-25';  -- Cambia la fecha según tus necesidades.
SET @fechaFin = '2023-11-25';  -- Cambia la fecha según tus necesidades.
SET @area = 'Salón de usos múltiples (SUM)';
SET @horaIni = '00:00:00';
SET @horaFin = '01:00:00';
SET @usuario = 'propietario';
SET @idReserva = 6;
SET @estado = 'Pendiente';
--SET @esActivo = 1;

-- Ejecución del stored procedure
--EXEC [dbo].[BUSCAR_CAMBIOS_RESERVAS] @fechaIni, @fechaFin, @usuario, @estado, @esActivo;
--EXEC [dbo].[VALIDAR_DISPONIBILIDAD]@area, @fechaIni, @horaIni, @fechaFin, @horaFin, @usuario;
EXEC [dbo].[MODIFICAR_RESERVA] @idReserva, @estado, @area, @fechaIni, @horaIni, @fechaFin, @horaFin, @usuario

select * from RESERVA;
select * from RESERVA_CONTROL_CAMBIOS;
select * from BITACORA_EVENTO order by fecha desc;
select * from AREA_COMUN;

update RESERVA set Estado = @estado, area = @area, Fecha_reserva_inicio = @fechaIni,
Hora_reserva_inicio = @horaIni, Fecha_reserva_fin = @fechaFin, Hora_reserva_fin = @horaFin,
usuario = @usuario, feedback = @feedback
where id = @idReserva;


SELECT * FROM RESERVA
WHERE Area = 'Salón de usos múltiples (SUM)'
AND Usuario = 'propietario'
AND (((Fecha_reserva_inicio = '2023-11-25' and Hora_reserva_inicio <= '10:00:00' and Fecha_reserva_fin = '2023-11-25' and Hora_reserva_fin >= '00:00:00') or
	  (Fecha_reserva_inicio = '2023-11-25' and Hora_reserva_inicio <= '10:00:00' and Fecha_reserva_fin = '2023-11-25' and Hora_reserva_fin >= '00:00:00'))
	AND estado = 'Pendiente')
union
SELECT * FROM RESERVA
WHERE Area = 'Salón de usos múltiples (SUM)'
AND Usuario = 'propietario'
AND estado = 'Pendiente'
;

	SELECT TOP (1) Id_Reserva,Estado,Fecha_creacion,area,Fecha_reserva_inicio,
				Hora_reserva_inicio,Fecha_reserva_fin,Hora_reserva_fin,Usuario,feedback
	FROM RESERVA
	order by Fecha_creacion desc;

select * from reserva where Fecha_reserva_inicio = '2023-11-25' and Hora_reserva_inicio <= '04:00:00' and Fecha_reserva_fin = '2023-11-25' and Hora_reserva_fin >= '03:00:00'
select * from reserva where Fecha_reserva_inicio = '2023-11-25' and Hora_reserva_inicio >= '12:00:00' and Fecha_reserva_fin = '2023-11-25' and Hora_reserva_fin <='12:00:00'

update reserva set estado = 'cancelado' where Id_Reserva = 6;
;

select * from RESERVA_CONTROL_CAMBIOS;
select * from AREA_COMUN;
select * from hash_global;
select * from USUARIO;
select * from persona;
select * from RESERVA;
select * from metrica;

update RESERVA set estado = 'Cancelado'
update usuario set Cant_intentos = 1 where username = 'admin2';
update hash_global set idv_global = '';
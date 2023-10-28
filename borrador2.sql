SELECT * FROM BITACORA_EVENTO where usuario = 'admin' and operacion = 'Insertar';
SELECT * FROM usuario;

-- Declaración de variables para los parámetros
DECLARE @fechaIni Date;  -- Cambia la fecha según tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @fechaFin Date;  -- Cambia la fecha según tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @horaIni Time;    -- Cambia la hora según tu necesidad o deja en NULL si no deseas filtrar por hora.
DECLARE @horaFin Time;    -- Cambia la hora según tu necesidad o deja en NULL si no deseas filtrar por hora.
DECLARE @usuario nvarchar(20);  -- Cambia el nombre de usuario según tu necesidad o deja en NULL si no deseas filtrar por usuario.
DECLARE @modulo varchar(20);     -- Cambia el módulo según tu necesidad o deja en NULL si no deseas filtrar por módulo.
DECLARE @operacion varchar(20);  -- Cambia la operación según tu necesidad o deja en NULL si no deseas filtrar por operación.
DECLARE @criticidad varchar(20);  -- Cambia la criticidad según tu necesidad o deja en NULL si no deseas filtrar por criticidad.

-- Asignación de valores a las variables
--SET @fechaIni = '2023-07-15';  -- Cambia la fecha según tus necesidades.
--SET @fechaFin = '2023-09-15';  -- Cambia la fecha según tus necesidades.
--SET @horaIni = '12:00:00';    -- Cambia la hora según tus necesidades.
--SET @horaFin = '15:00:00';
SET @operacion = 'Insertar';

-- Ejecución del stored procedure
EXEC [dbo].[BUSCAR_EVENTOS] @fechaIni, @fechaFin, @horaIni, @horaFin, @usuario, @modulo, @operacion, @criticidad;
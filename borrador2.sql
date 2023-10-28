SELECT * FROM BITACORA_EVENTO where usuario = 'admin' and operacion = 'Insertar';
SELECT * FROM usuario;

-- Declaraci�n de variables para los par�metros
DECLARE @fechaIni Date;  -- Cambia la fecha seg�n tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @fechaFin Date;  -- Cambia la fecha seg�n tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @horaIni Time;    -- Cambia la hora seg�n tu necesidad o deja en NULL si no deseas filtrar por hora.
DECLARE @horaFin Time;    -- Cambia la hora seg�n tu necesidad o deja en NULL si no deseas filtrar por hora.
DECLARE @usuario nvarchar(20);  -- Cambia el nombre de usuario seg�n tu necesidad o deja en NULL si no deseas filtrar por usuario.
DECLARE @modulo varchar(20);     -- Cambia el m�dulo seg�n tu necesidad o deja en NULL si no deseas filtrar por m�dulo.
DECLARE @operacion varchar(20);  -- Cambia la operaci�n seg�n tu necesidad o deja en NULL si no deseas filtrar por operaci�n.
DECLARE @criticidad varchar(20);  -- Cambia la criticidad seg�n tu necesidad o deja en NULL si no deseas filtrar por criticidad.

-- Asignaci�n de valores a las variables
--SET @fechaIni = '2023-07-15';  -- Cambia la fecha seg�n tus necesidades.
--SET @fechaFin = '2023-09-15';  -- Cambia la fecha seg�n tus necesidades.
--SET @horaIni = '12:00:00';    -- Cambia la hora seg�n tus necesidades.
--SET @horaFin = '15:00:00';
SET @operacion = 'Insertar';

-- Ejecuci�n del stored procedure
EXEC [dbo].[BUSCAR_EVENTOS] @fechaIni, @fechaFin, @horaIni, @horaFin, @usuario, @modulo, @operacion, @criticidad;
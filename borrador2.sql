SELECT * FROM BITACORA_EVENTO where usuario = 'admin' and operacion = 'Insertar';
SELECT * FROM usuario;

-- Declaraci�n de variables para los par�metros
DECLARE @fechaIni Date;  -- Cambia la fecha seg�n tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @fechaFin Date;  -- Cambia la fecha seg�n tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @usuario nvarchar(20);  -- Cambia el nombre de usuario seg�n tu necesidad o deja en NULL si no deseas filtrar por usuario.
DECLARE @estado varchar(50);     -- Cambia el m�dulo seg�n tu necesidad o deja en NULL si no deseas filtrar por m�dulo.
DECLARE @esActivo bit;  -- Cambia la operaci�n seg�n tu necesidad o deja en NULL si no deseas filtrar por operaci�n.
DECLARE @criticidad varchar(20);  -- Cambia la criticidad seg�n tu necesidad o deja en NULL si no deseas filtrar por criticidad.

-- Asignaci�n de valores a las variables
SET @fechaIni = '2023-10-28';  -- Cambia la fecha seg�n tus necesidades.
SET @fechaFin = '2023-10-30';  -- Cambia la fecha seg�n tus necesidades.
--SET @estado = 'Pendiente';
--SET @esActivo = 1;

-- Ejecuci�n del stored procedure
EXEC [dbo].[BUSCAR_CAMBIOS_RESERVAS] @fechaIni, @fechaFin, @usuario, @estado, @esActivo;
SELECT * FROM BITACORA_EVENTO where usuario = 'admin' and operacion = 'Insertar';
SELECT * FROM usuario;

-- Declaración de variables para los parámetros
DECLARE @fechaIni Date;  -- Cambia la fecha según tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @fechaFin Date;  -- Cambia la fecha según tu necesidad o deja en NULL si no deseas filtrar por fecha.
DECLARE @usuario nvarchar(20);  -- Cambia el nombre de usuario según tu necesidad o deja en NULL si no deseas filtrar por usuario.
DECLARE @estado varchar(50);     -- Cambia el módulo según tu necesidad o deja en NULL si no deseas filtrar por módulo.
DECLARE @esActivo bit;  -- Cambia la operación según tu necesidad o deja en NULL si no deseas filtrar por operación.
DECLARE @criticidad varchar(20);  -- Cambia la criticidad según tu necesidad o deja en NULL si no deseas filtrar por criticidad.

-- Asignación de valores a las variables
SET @fechaIni = '2023-10-28';  -- Cambia la fecha según tus necesidades.
SET @fechaFin = '2023-10-30';  -- Cambia la fecha según tus necesidades.
--SET @estado = 'Pendiente';
--SET @esActivo = 1;

-- Ejecución del stored procedure
EXEC [dbo].[BUSCAR_CAMBIOS_RESERVAS] @fechaIni, @fechaFin, @usuario, @estado, @esActivo;
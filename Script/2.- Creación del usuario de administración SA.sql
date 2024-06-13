-- CREA EL USUARIO DE ADMINISTRACIÓN DE LA BASE DE DATOS remesas ayarza
-- Si un usuario no existe, crea el LOGIN y después el USER con el mismo nombre.
-- El usuario deberá cambiar el password la primera vez que ingrese a la base de datos

-- Si el usuario ya existe, procede a eliminarlo y crearlo nuevamente

use master;		-- utiliza la base de datos del sistema para verificar el login

IF NOT EXISTS(SELECT * from sys.syslogins WHERE name='MARCAJE')
BEGIN
	CREATE LOGIN MARCAJE		-- si no existe el usuario, crea el login del usuario nuevo
		WITH PASSWORD = '12345' MUST_CHANGE,
		CHECK_EXPIRATION = ON,
		DEFAULT_LANGUAGE = ENGLISH,
		DEFAULT_DATABASE = BIOMETRICOBD;

	USE BIOMETRICOBD;
	CREATE USER MARCAJE FOR LOGIN MARCAJE;		-- crea el usuario nuevo en la base de datos REMESESAS_AYARZA
END
GO

USE BIOMETRICOBD;
GRANT	BACKUP DATABASE,
		BACKUP LOG,
		CREATE DEFAULT,
		CREATE FUNCTION,
		CREATE PROCEDURE,
		CREATE RULE,
		CREATE ROLE,
		CREATE SCHEMA,
		CREATE TABLE,
		CREATE VIEW,
	    CREATE SYNONYM,
		SELECT,
		UPDATE,
		DELETE TO MARCAJE WITH GRANT OPTION;
GO

ALTER ROLE db_owner ADD MEMBER MARCAJE;

GRANT	SELECT, INSERT, DELETE, UPDATE, ALTER ON SCHEMA :: dbo TO MARCAJE;

GRANT	ALTER ANY USER TO MARCAJE;
GO

use master;
GRANT	ALTER ANY LOGIN TO JAVIER;
GO



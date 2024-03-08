-- Use CasinoDB --
USE CasinoDB
GO

-- Create login for SQL Server authentication
CREATE LOGIN ConnectionUser
    WITH PASSWORD = 'AppConnection!';

-- Assign db_owner role directly to the login
USE CasinoDB;
CREATE USER ConnectionUser
    FOR LOGIN ConnectionUser
    WITH DEFAULT_SCHEMA = dbo;

-- Set db_owner role for the user to grant all permissions
ALTER ROLE db_owner ADD MEMBER ConnectionUser;
GO
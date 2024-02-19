use Skole
go

--CREATE PROCEDURE FindNextAvailableID
--    @TableName NVARCHAR(255),
--    @IDColumn NVARCHAR(255)
--AS
--BEGIN
--    DECLARE @SqlQuery NVARCHAR(MAX);
    
--    SET @SqlQuery = '
--        SELECT MIN(' + QUOTENAME(@IDColumn) + ' + 1) AS next_available_id
--        FROM ' + QUOTENAME(@TableName) + '
--        WHERE NOT EXISTS (
--            SELECT 1
--            FROM ' + QUOTENAME(@TableName) + ' t2
--            WHERE t2.' + QUOTENAME(@IDColumn) + ' = ' + QUOTENAME(@TableName) + '.' + QUOTENAME(@IDColumn) + ' + 1
--        )
--    ';

--    EXEC sp_executesql @SqlQuery;
--END;
--go

--exec FindNextAvailableID 'Students', 'StudentID';
--go

-- ==========================
--			NOT IN USE
-- ==========================
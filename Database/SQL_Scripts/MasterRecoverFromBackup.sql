use master
go

alter database Skole set offline with rollback immediate;
go

restore database SkoleFromBackup from disk = 'C:\Skole\H1\Database_Server\Backups\backup.bak' 
with replace, recovery, 
move 'Skole' to 'C:\Skole\H1\Database_Server\Backups\Skole.mdf', 
move 'Skole_log' to 'C:\Skole\H1\Database_Server\Backups\Skole_log.ldf';
go
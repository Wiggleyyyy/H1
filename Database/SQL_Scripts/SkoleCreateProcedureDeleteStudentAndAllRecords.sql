USE Skole
GO

--create procedure DeleteStudentAndRelatedRecords
--	@StudentID INT = 1
--as
--begin
--	delete from Attendance where StudentID = @StudentID;
--	delete from Grades where StudentID = @StudentID;
--	delete from Enrollments where StudentID = @StudentID;
--	delete from Students where StudentID = @StudentID;
--end;

exec DeleteStudentAndAllRecords '1'
go
--deletes student with ID 1
use Skole
go

create procedure InsertParentAndStudent
	@ParentName VARCHAR(255),
    @ParentContactInfo VARCHAR(255),
    @StudentName VARCHAR(255),
    @StudentDateOfBirth DATE,
    @StudentAddress VARCHAR(255),
    @StudentContactInfo VARCHAR(255),
    @StudentGradeLevel INT
as
begin
	set nocount on;

	insert into Parents (Name, ContactInfo)
	values (@ParentName, @ParentContactInfo);

	declare @ParentID int;
	set @ParentID = SCOPE_IDENTITY();

	insert into Students (Name, DateOfBirth, Address, ContactInfo, GradeLevel, ParentID)
	values	(@StudentName, @StudentDateOfBirth, @StudentAddress, @StudentContactInfo, @StudentGradeLevel, @ParentID);
end
go
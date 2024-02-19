/*
=============================================================
 SKAL OPRETTE EN DATABASE MED NAVN "Skole" FØR SCRIPT VIRKER
=============================================================
*/
use Skole
go

-- Parents Table
CREATE TABLE Parents (
    ParentID INT  PRIMARY KEY,
    Name VARCHAR(255),
    ContactInfo VARCHAR(255)
);

-- Students Table
CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255),
    DateOfBirth DATE,
    Address VARCHAR(255),
    ContactInfo VARCHAR(255),
    ParentID INT,
    FOREIGN KEY (ParentID) REFERENCES Parents(ParentID)
);

-- Teachers Table
CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    Name VARCHAR(255),
    SubjectTaught VARCHAR(255),
    ContactInfo VARCHAR(255),
    OfficeLocation VARCHAR(255)
);

-- Courses Table
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(255),
    Description VARCHAR(255),
    CreditHours INT,
    TeacherID INT,
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);

-- Enrollments Table
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- Grades Table
CREATE TABLE Grades (
    GradeID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    Grade VARCHAR(2), -- Assuming grades like A, B, C, etc.
    ExamScores INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- Attendance Table
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    Date DATE,
    AttendanceStatus VARCHAR(10), -- Assuming statuses like Present, Absent, etc.
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
go

insert into Parents (Name, ContactInfo) VALUES
('Chris Johnson', '555-987-6543'),
('Sophie Turner', '444-555-6666'),
('David Harris', '777-123-4567')
-- More parent data...
-- Inserting sample data into Students table
INSERT INTO Students (Name, DateOfBirth, Address, ContactInfo, ParentID)
VALUES
('John Doe', '2005-05-15', '123 Main St', '111-222-3333', 1),
('Jane Smith', '2004-08-20', '456 Oak St', '444-555-6666', 2),
('Mike Johnson', '2006-02-10', '789 Pine St', '777-888-9999', 3)
-- More student data...

-- Inserting sample data into Teachers table
INSERT INTO Teachers (TeacherID, Name, SubjectTaught, ContactInfo, OfficeLocation)
VALUES
(101, 'Mr. Anderson', 'Math', '555-111-2222', 'Room 301'),
(102, 'Ms. Davis', 'English', '333-444-5555', 'Room 202'),
(103, 'Dr. Rodriguez', 'Science', '666-777-8888', 'Room 401')
-- More teacher data...

-- Inserting sample data into Courses table
INSERT INTO Courses (CourseID, CourseName, Description, CreditHours, TeacherID)
VALUES
(1001, 'Algebra I', 'Introduction to Algebra', 3, 101),
(1002, 'English Literature', 'Classic Literature', 4, 102),
(1003, 'Biology', 'Introduction to Biology', 4, 103)
-- More course data...

-- Inserting sample data into Enrollments table
INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate)
VALUES
(1, 1001, '2023-09-01'),
(2, 1002, '2023-09-02'),
(3, 1003, '2023-09-03')
-- More enrollment data...

-- Inserting sample data into Grades table
INSERT INTO Grades (StudentID, CourseID, Grade, ExamScores)
VALUES
(1, 1001, 'A', 95),
(2, 1002, 'B', 85),
(3, 1003, 'A', 90)
-- More grade data...

-- Inserting sample data into Attendance table
INSERT INTO Attendance (StudentID, CourseID, Date, AttendanceStatus)
VALUES
(1, 1001, '2023-09-10', 'Present'),
(2, 1002, '2023-09-10', 'Present'),
(3, 1003, '2023-09-10', 'Present')
-- More attendance data...
go

--Opret første procedure || Til at indsætte parent og elev
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

--opret anden procedure || til at slette data
create procedure DeleteStudentAndRelatedRecords
	@StudentID INT = 1
as
begin
	delete from Attendance where StudentID = @StudentID;
	delete from Grades where StudentID = @StudentID;
	delete from Enrollments where StudentID = @StudentID;
	delete from Students where StudentID = @StudentID;
end;
go

--Create view
create view [elevOgKarakter] as select Students.Name, Grades.Grade from Students join Grades on Students.StudentID = Grades.StudentID;
go
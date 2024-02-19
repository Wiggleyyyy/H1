use Skole
go

create view [elevOgKarakter] as select Students.Name, Grades.Grade from Students join Grades on Students.StudentID = Grades.StudentID;
go

select * from elevOgKarakter
go

drop view [elevOgKarakter]
go




Create view vStudentDetails
as select Students.StudentId,FirstName,LastName,Email,MobileNumber from Students,StudentsDetails
where Students.StudentId=StudentsDetails.StudentId

select *from vStudentDetails


CREATE TRIGGER TR_StudentUpdate
ON vStudentDetails
INSTEAD OF Update
AS
SET NOCOUNT ON;
declare @id int
declare @FirstName varchar(50)
declare @lastname varchar(50)
declare @Email varchar(50)
declare @MobileNumber int
select @id=StudentId,@FirstName=FirstName,@lastname=LastName,@Email=Email,@MobileNumber=MobileNumber  from inserted
update vStudentDetails set FirstName=@FirstName,LastName=@lastname where StudentId=@id
update vStudentDetails set Email=@Email,MobileNumber=@MobileNumber where StudentId=@id

GO

update vStudentDetails set firstname='Manish',mobilenumber=9825212 where studentid=1
select *from Students
select *from StudentsDetails
select *from vStudentDetails

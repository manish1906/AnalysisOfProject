
ALTER TRIGGER TR_Update
ON vUpdate
INSTEAD OF Update
AS
SET NOCOUNT ON;
declare @id int
declare  @sid int
declare @FirstName varchar(50)
declare @lastname varchar(50)
declare @Email varchar(50)
declare @MobileNumber int
select @id=StudentId,@sid=Id, @FirstName=FirstName,@lastname=LastName,@Email=Email,@MobileNumber=MobileNumber  from inserted
update vUpdate set FirstName=@FirstName,LastName=@lastname where StudentId=@id
update vUpdate set Email=@Email,MobileNumber=@MobileNumber where Id=@sid

GO

update vUpdate set firstname='Manish',mobilenumber=98252 where studentid=1
select *from Students
select *from StudentsDetails
select *from vupdate
CREATE FUNCTION dbo.IntegerListToTable
( @InputList nvarchar(MAX),@Delimiter nchar(1) = N',')
RETURNS @OutputTable TABLE (PositionInList int IDENTITY(1, 1) NOT NULL,IntegerValue int)
AS BEGIN
		INSERT INTO @OutputTable (IntegerValue)
		SELECT Value FROM STRING_SPLIT ( @InputList , @Delimiter );
	RETURN;
END;
GO


SELECT * FROM 
dbo.IntegerListToTable('123,333,44543,24345',',');



CREATE FUNCTION dbo.JoinNames
( @FirstName nvarchar(30), @MiddleName nvarchar(30), @LastName nvarchar(30))
RETURNS @FullName TABLE (FullName nvarchar(max))
AS BEGIN
	INSERT INTO @FullName (FullName)
	SELECT CONCAT(@FirstName , ' ' , @MiddleName , ' ' , @Lastname) AS FullName ;
	RETURN;
END;
GO



SELECT *FROM JoinNames('Parmar','Manish','J');
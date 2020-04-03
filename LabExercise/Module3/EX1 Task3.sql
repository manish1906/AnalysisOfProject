-- Module 3 - Lab Exercise 2 - Implement the Partitioning Strategy


-- Create filegroups
USE HumanResources;
GO
ALTER DATABASE HumanResources ADD FILEGROUP FG0
GO
ALTER DATABASE HumanResources ADD FILE (NAME = F0, FILENAME = 'E:\Downloads\20762C-ENU-Allfiles\Labfiles\Lab03\Starter\SetupFiles\F0.ndf', SIZE = 3MB, FILEGROWTH = 50%) TO FILEGROUP FG0;
GO
ALTER DATABASE HumanResources ADD FILEGROUP FG1
GO
ALTER DATABASE HumanResources ADD FILE (NAME = F1, FILENAME = 'E:\Downloads\20762C-ENU-Allfiles\Labfiles\Lab03\Starter\SetupFiles\F1.ndf', SIZE = 3MB, FILEGROWTH = 50%) TO FILEGROUP FG1;
GO
ALTER DATABASE HumanResources ADD FILEGROUP FG2
GO
ALTER DATABASE HumanResources ADD FILE (NAME = F2, FILENAME = 'E:\Downloads\20762C-ENU-Allfiles\Labfiles\Lab03\Starter\SetupFiles\F2.ndf', SIZE = 3MB, FILEGROWTH = 50%) TO FILEGROUP FG2;
GO
ALTER DATABASE HumanResources ADD FILEGROUP FG3
GO
ALTER DATABASE HumanResources ADD FILE (NAME = F3, FILENAME = 'E:\Downloads\20762C-ENU-Allfiles\Labfiles\Lab03\Starter\SetupFiles\F3.ndf', SIZE = 3MB, FILEGROWTH = 50%) TO FILEGROUP FG3;
GO


-- Create partition function
ALTER PARTITION FUNCTION pfHumanResourcesDates () 
AS RANGE RIGHT 
FOR VALUES ('2018-10-01 00:00','2019-01-01 00:00','2019-04-01 00:00');
	

-- Create partition scheme
CREATE PARTITION SCHEME psHumanResources 
AS PARTITION pfHumanResourcesDates TO (FG0, FG1, FG2, FG3);

use TSQL
-- Create the Timesheet table
CREATE TABLE Timesheet
(
	EmployeeId int NOT NULL,
	ShiftId tinyint NOT NULL,
	RegisteredStartTime datetime NOT NULL,
	RegisteredEndTime datetime NOT NULL,
	CONSTRAINT PK_Timesheet_EmployeeId_ShiftId_ResgisteredStartTime PRIMARY KEY (EmployeeId ASC, ShiftId ASC, RegisteredStartTime)
) ON psHumanResources(RegisteredStartTime);
GO


--Insert data into Timesheet table
INSERT INTO Timesheet
VALUES (1,1, '2018-11-23 07:00', '2018-11-23 15:00');
GO
INSERT INTO Timesheet
VALUES (1,1, '2018-11-25 07:00', '2018-11-25 15:00');
GO
INSERT INTO Timesheet
VALUES (1,1, '2019-02-21 07:00', '2019-02-21 15:00');
GO
INSERT INTO Timesheet
VALUES (1,1, '2019-02-23 07:00', '2019-02-23 15:00');
GO
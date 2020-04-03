-- Module 3 - Lab Exercise 4 - Create Timesheet Table for Compression


-- Drop the Payment.Timesheet table
USE HumanResources;
GO
DROP TABLE Timesheet 
GO



-- Drop the current partition scheme
DROP PARTITION SCHEME [psHumanResources]
GO



-- Drop the current partition function
DROP PARTITION FUNCTION [pfHumanResourcesDates]
GO



-- Create the new partition function with wider date ranges
CREATE PARTITION FUNCTION [pfHumanResourcesDates](datetime) 
AS 
RANGE RIGHT FOR VALUES (N'2012-12-31T00:00:00.000', N'2014-12-31T00:00:00.000', N'2016-12-31T00:00:00.000')
GO



-- Re-create the partition scheme
CREATE PARTITION SCHEME [psHumanResources] AS PARTITION [pfHumanResourcesDates] TO ([FG0], [FG2], [FG3], [FG1])
GO



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



-- Insert data into the Timesheet table
DECLARE @Shift1StartTime datetime, @Shift1EndTime datetime
DECLARE @Shift2StartTime datetime, @Shift2EndTime datetime
DECLARE @Shift3StartTime datetime, @Shift3EndTime datetime

-- Set shift 1 times
SET @Shift1StartTime = '2011-09-30 07:00:00.000'
SET	@Shift1EndTime = '2011-09-30 15:00:00.000'
-- Set shift 2 times
SET @Shift2StartTime = '2011-09-30 15:00:00.000'
SET	@Shift2EndTime = '2011-09-30 23:00:00.000'
-- Set shift 3 times
SET @Shift3StartTime = '2011-09-30 23:00:00.000'
SET	@Shift3EndTime = '2011-10-01 07:00:00.000'

DECLARE @Counter smallint
SET @Counter = 1

WHILE @Counter < 1825
BEGIN 
	-- Increment the start times
	SET @Shift1StartTime = DATEADD(DAY, 1, @Shift1StartTime)
	SET @Shift2StartTime = DATEADD(DAY, 1, @Shift2StartTime)
	SET @Shift3StartTime = DATEADD(DAY, 1, @Shift3StartTime)
	-- Increment the end times
	SET @Shift1EndTime = DATEADD(DAY, 1, @Shift1EndTime)
	SET @Shift2EndTime = DATEADD(DAY, 1, @Shift2EndTime)
	SET @Shift3EndTime = DATEADD(DAY, 1, @Shift3EndTime)

	-- Exclude weekend dates
	IF DATEPART(weekday, @Shift1StartTime) NOT IN (7,1)
	BEGIN
		-- Insert the shift 1 times 
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (1, 1, @Shift1StartTime, @Shift1EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (2, 1, @Shift1StartTime, @Shift1EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (3, 1, @Shift1StartTime, @Shift1EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (4, 1, @Shift1StartTime, @Shift1EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (5, 1, @Shift1StartTime, @Shift1EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (6, 1, @Shift1StartTime, @Shift1EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (7, 1, @Shift1StartTime, @Shift1EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (8, 1, @Shift1StartTime, @Shift1EndTime)

		-- Insert the shift 2 times 
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (11, 2, @Shift2StartTime, @Shift2EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (12, 2, @Shift2StartTime, @Shift2EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (13, 2, @Shift2StartTime, @Shift2EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (14, 2, @Shift2StartTime, @Shift2EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (15, 2, @Shift2StartTime, @Shift2EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (16, 2, @Shift2StartTime, @Shift2EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (17, 2, @Shift2StartTime, @Shift2EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (18, 2, @Shift2StartTime, @Shift2EndTime)

		-- Insert the shift 3 times 
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (21, 3, @Shift3StartTime, @Shift3EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (22, 3, @Shift3StartTime, @Shift3EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (23, 3, @Shift3StartTime, @Shift3EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (24, 3, @Shift3StartTime, @Shift3EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (25, 3, @Shift3StartTime, @Shift3EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (26, 3, @Shift3StartTime, @Shift3EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (27, 3, @Shift3StartTime, @Shift3EndTime)
		INSERT INTO Timesheet (EmployeeId, ShiftId, RegisteredStartTime, RegisteredEndTime)
		VALUES (28, 3, @Shift3StartTime, @Shift3EndTime)
	END

	-- Increment the counter by 1
	SET @Counter = @Counter + 1
END


select*from Timesheet
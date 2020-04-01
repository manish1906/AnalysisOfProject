---------------------------------------------------------------------
-- LAB 02
--
-- Exercise 3
---------------------------------------------------------------------

USE TSQL;
GO

---------------------------------------------------------------------
-- Task 1
-- 
-- Write a script to create a table to store the Competitor data.
---------------------------------------------------------------------

create table Directmarketing.Competitor (
CompetitorId int NOT NULL,
CompetitorName varchar(50) NOT NULL,
Address varchar(max) NOT NULL,
DateEntered date NOT NULL,
primary key (CompetitorId)
);







---------------------------------------------------------------------
-- Task 2
-- 
-- Write a script to create a table to store the TVAdvertisement data.
---------------------------------------------------------------------


create table Directmarketing.TVAdvertisement (
TVAdvertisementId int NOT NULL,
TVStationName varchar(30) NOT NULL,
CityName	varchar(30) NOT NULL,
ScreeningTime datetime NOT NULL,
Cost int NOT NULL
primary key (TVAdvertisementId)
);




---------------------------------------------------------------------
-- Task 3
-- 
-- Write a script to create a table to store the CampaignResponse data.
---------------------------------------------------------------------


create table Directmarketing.CampaignResponse (
CampaignResponseId int NOT NULL,
ResponseReceived datetime NOT NULL,
StartDate date NOT NULL,
EndDate date NOT NULL,
Profit	int NOT NULL

primary key (CampaignResponseId)
);



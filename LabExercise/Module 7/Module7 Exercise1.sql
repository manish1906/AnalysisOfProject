----------------Exercise 1: Create a Columnstore Index on the FactProductInventory Table -------------

----------------Task : Examine the Existing Size of the FactProductInventory Table and Query Performance-------------


SET STATISTICS TIME OFF
GO
USE AdventureWorksDW
GO

sp_spaceused 'dbo.FactProductInventory';
GO

/* data=45552 KB */


SET STATISTICS TIME ON
GO

SELECT p.EnglishProductName
		,d.WeekNumberOfYear
		,d.CalendarYear
		,AVG(fpi.UnitCost) AvgCost
		,SUM(fpi.UnitsOut) TotalUnits
		,MAX(fpi.UnitCost) HighestPrice
FROM dbo.FactProductInventory as fpi
INNER JOIN dbo.DimProduct as p ON fpi.ProductKey = p.ProductKey
INNER JOIN dbo.DimDate as d ON fpi.DateKey = d.DateKey
GROUP BY p.EnglishProductName,
		d.WeekNumberOfYear,
		d.CalendarYear
ORDER BY p.EnglishProductName,
		d.CalendarYear,
		d.WeekNumberOfYear;
GO

/*CPU time = 1953 ms,  elapsed time = 3359 ms*/

------------Task : Create a Columnstore Index on the FactProductInventory Table---------


SET STATISTICS TIME OFF
GO

/****** Add a non-clustered index ******/
CREATE NONCLUSTERED COLUMNSTORE INDEX NCI_FactProductInventory_UnitCost_UnitsOut ON FactProductInventory
(
	ProductKey,
	DateKey,
	UnitCost,
	UnitsOut
)
GO

/* CPU time = 579 ms,  elapsed time = 1974 ms */
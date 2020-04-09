	
	------------Exercise 2: Create a Columnstore Index on the FactInternetSales Table -------------
	
	------------Task 1: Examine the Existing Size of the FactInternetSales Table and Query Performance----------

SET STATISTICS TIME OFF
GO
USE [AdventureWorksDW]
GO

sp_spaceused 'dbo.FactInternetSales'
GO

/*data=615584 KB*/



SET STATISTICS TIME ON
GO

SELECT SalesTerritoryRegion
		,p.EnglishProductName
		,d.WeekNumberOfYear
		,d.CalendarYear
		,SUM(fi.SalesAmount) Revenue
		,AVG(OrderQuantity) AverageQuantity
		,STDEV(UnitPrice) PriceStandardDeviation
		,SUM(TaxAmt) TotalTaxPayable
FROM dbo.FactInternetSales as fi
INNER JOIN dbo.DimProduct as p ON fi.ProductKey = p.ProductKey
INNER JOIN dbo.DimDate as d ON fi.OrderDate = d.FullDateAlternateKey
INNER JOIN dbo.DimSalesTerritory as st on fi.SalesTerritoryKey = st.SalesTerritoryKey
	AND fi.OrderDate BETWEEN '1/1/2007' AND '12/31/2007'
GROUP BY SalesTerritoryRegion, d.CalendarYear, d.WeekNumberOfYear, p.EnglishProductName
ORDER BY SalesTerritoryRegion, SUM(fi.SalesAmount) desc;

----CPU time = 3172 ms,  elapsed time = 4543 ms.---------



-------------Task 2: Create a Columnstore Index on the FactInternetSales Table -------------

/****** All indexes need to be removed before creating a clustered columnstore ******/
SET STATISTICS TIME OFF
GO
USE [AdventureWorksDW]
GO

DROP INDEX [IX_FactIneternetSales_ShipDateKey] ON [dbo].[FactInternetSales];
DROP INDEX [IX_FactInternetSales_CurrencyKey] ON [dbo].[FactInternetSales];
DROP INDEX [IX_FactInternetSales_CustomerKey] ON [dbo].[FactInternetSales];
DROP INDEX [IX_FactInternetSales_DueDateKey] ON [dbo].[FactInternetSales];
DROP INDEX [IX_FactInternetSales_OrderDateKey] ON [dbo].[FactInternetSales];
DROP INDEX [IX_FactInternetSales_ProductKey] ON [dbo].[FactInternetSales];
DROP INDEX [IX_FactInternetSales_PromotionKey] ON [dbo].[FactInternetSales];
GO

/****** All foreign keys need to be removed ******/
ALTER TABLE [dbo].[FactInternetSales] DROP CONSTRAINT [FK_FactInternetSales_DimCustomer];
ALTER TABLE [dbo].[FactInternetSales] DROP CONSTRAINT [FK_FactInternetSales_DimCurrency];
ALTER TABLE [dbo].[FactInternetSales] DROP CONSTRAINT [FK_FactInternetSales_DimDate];
ALTER TABLE [dbo].[FactInternetSales] DROP CONSTRAINT [FK_FactInternetSales_DimDate1];
ALTER TABLE [dbo].[FactInternetSales] DROP CONSTRAINT [FK_FactInternetSales_DimDate2];
ALTER TABLE [dbo].[FactInternetSales] DROP CONSTRAINT [FK_FactInternetSales_DimProduct];
ALTER TABLE [dbo].[FactInternetSales] DROP CONSTRAINT [FK_FactInternetSales_DimPromotion];
ALTER TABLE [dbo].[FactInternetSales] DROP CONSTRAINT [FK_FactInternetSales_DimSalesTerritory];
ALTER TABLE [dbo].[FactInternetSalesReason] DROP CONSTRAINT [FK_FactInternetSalesReason_FactInternetSales]
ALTER TABLE [dbo].[FactInternetSales] DROP CONSTRAINT [PK_FactInternetSales_SalesOrderNumber_SalesOrderLineNumber]
GO


-------------------------------------------------------------------------------
SET STATISTICS TIME OFF
GO
USE [AdventureWorksDW]
GO

CREATE CLUSTERED COLUMNSTORE INDEX CCI_FactInternetSales ON FactInternetSales
GO

/****** Re-create the dropped indexes */
CREATE NONCLUSTERED INDEX [IX_FactInternetSales_PromotionKey] ON [dbo].[FactInternetSales]
(
	[PromotionKey] ASC
)
CREATE NONCLUSTERED INDEX [IX_FactIneternetSales_ShipDateKey] ON [dbo].[FactInternetSales]
(
	[ShipDateKey] ASC
)
CREATE NONCLUSTERED INDEX [IX_FactInternetSales_CurrencyKey] ON [dbo].[FactInternetSales]
(
	[CurrencyKey] ASC
)
CREATE NONCLUSTERED INDEX [IX_FactInternetSales_CustomerKey] ON [dbo].[FactInternetSales]
(
	[CustomerKey] ASC
)
CREATE NONCLUSTERED INDEX [IX_FactInternetSales_DueDateKey] ON [dbo].[FactInternetSales]
(
	[DueDateKey] ASC
)
CREATE NONCLUSTERED INDEX [IX_FactInternetSales_OrderDateKey] ON [dbo].[FactInternetSales]
(
	[OrderDateKey] ASC
)
USE [AdventureWorksDW]
CREATE NONCLUSTERED INDEX [IX_FactInternetSales_ProductKey] ON [dbo].[FactInternetSales]
(
	[ProductKey] ASC
)
CREATE UNIQUE NONCLUSTERED INDEX [PK_FactInternetSales_SalesOrderNumber_SalesOrderLineNumber] ON [dbo].[FactInternetSales]
(
	[SalesOrderNumber] ASC,
	[SalesOrderLineNumber] ASC
)
GO


/****** Re-add the foreign keys ******/
ALTER TABLE [dbo].[FactInternetSales]  WITH CHECK ADD  CONSTRAINT [FK_FactInternetSales_DimCustomer] FOREIGN KEY([CustomerKey])
REFERENCES [dbo].[DimCustomer] ([CustomerKey])
ALTER TABLE [dbo].[FactInternetSales] CHECK CONSTRAINT [FK_FactInternetSales_DimCustomer]

ALTER TABLE [dbo].[FactInternetSales]  WITH CHECK ADD  CONSTRAINT [FK_FactInternetSales_DimCurrency] FOREIGN KEY([CurrencyKey])
REFERENCES [dbo].[DimCurrency] ([CurrencyKey])
ALTER TABLE [dbo].[FactInternetSales] CHECK CONSTRAINT [FK_FactInternetSales_DimCurrency]

ALTER TABLE [dbo].[FactInternetSales]  WITH CHECK ADD  CONSTRAINT [FK_FactInternetSales_DimDate] FOREIGN KEY([OrderDateKey])
REFERENCES [dbo].[DimDate] ([DateKey])
ALTER TABLE [dbo].[FactInternetSales] CHECK CONSTRAINT [FK_FactInternetSales_DimDate]

ALTER TABLE [dbo].[FactInternetSales]  WITH CHECK ADD  CONSTRAINT [FK_FactInternetSales_DimDate1] FOREIGN KEY([DueDateKey])
REFERENCES [dbo].[DimDate] ([DateKey])
ALTER TABLE [dbo].[FactInternetSales] CHECK CONSTRAINT [FK_FactInternetSales_DimDate1]

ALTER TABLE [dbo].[FactInternetSales]  WITH CHECK ADD  CONSTRAINT [FK_FactInternetSales_DimDate2] FOREIGN KEY([ShipDateKey])
REFERENCES [dbo].[DimDate] ([DateKey])
ALTER TABLE [dbo].[FactInternetSales] CHECK CONSTRAINT [FK_FactInternetSales_DimDate2]

ALTER TABLE [dbo].[FactInternetSales]  WITH CHECK ADD  CONSTRAINT [FK_FactInternetSales_DimProduct] FOREIGN KEY([ProductKey])
REFERENCES [dbo].[DimProduct] ([ProductKey])
ALTER TABLE [dbo].[FactInternetSales] CHECK CONSTRAINT [FK_FactInternetSales_DimProduct]

ALTER TABLE [dbo].[FactInternetSales]  WITH CHECK ADD  CONSTRAINT [FK_FactInternetSales_DimPromotion] FOREIGN KEY([PromotionKey])
REFERENCES [dbo].[DimPromotion] ([PromotionKey])
ALTER TABLE [dbo].[FactInternetSales] CHECK CONSTRAINT [FK_FactInternetSales_DimPromotion]

ALTER TABLE [dbo].[FactInternetSales]  WITH CHECK ADD  CONSTRAINT [FK_FactInternetSales_DimSalesTerritory] FOREIGN KEY([SalesTerritoryKey])
REFERENCES [dbo].[DimSalesTerritory] ([SalesTerritoryKey])
ALTER TABLE [dbo].[FactInternetSales] CHECK CONSTRAINT [FK_FactInternetSales_DimSalesTerritory]
GO




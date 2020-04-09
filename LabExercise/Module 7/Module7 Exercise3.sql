----------------Exercise 3: Create a Memory Optimized Columnstore Table ------------
-----------------Task : Enable the Memory Optimization Advisor to Create a Memory Optimized FactInternetSales Table -----------


SET STATISTICS TIME OFF
GO
USE [AdventureWorksDW]
GO

/****** Columnstore index needs to be dropped, also can only have 8 on the in-memory table ******/
DROP INDEX [CCI_FactInternetSales] ON [dbo].[FactInternetSales] WITH ( ONLINE = OFF )
DROP INDEX [PK_FactInternetSales_SalesOrderNumber_SalesOrderLineNumber] ON [dbo].[FactInternetSales]
DROP INDEX [IX_FactInternetSales_DueDateKey] ON [dbo].[FactInternetSales]
DROP INDEX [IX_FactInternetSales_OrderDateKey] ON [dbo].[FactInternetSales]
DROP INDEX [IX_FactIneternetSales_ShipDateKey] ON [dbo].[FactInternetSales]
DROP INDEX [IX_FactInternetSales_CurrencyKey] ON [dbo].[FactInternetSales]
DROP INDEX [IX_FactInternetSales_CustomerKey] ON [dbo].[FactInternetSales]
DROP INDEX [IX_FactInternetSales_ProductKey] ON [dbo].[FactInternetSales]
DROP INDEX [IX_FactInternetSales_PromotionKey] ON [dbo].[FactInternetSales]


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
GO

------------------------- Create a Memory Optimized FactInternetSales Table ------------------------------------
USE [master]
GO

ALTER DATABASE [AdventureWorksDW] ADD FILEGROUP [memory_optimized_filegroup_0] CONTAINS MEMORY_OPTIMIZED_DATA 
GO

ALTER DATABASE [AdventureWorksDW] ADD FILE ( NAME = N'memory_optimized_file_2063267240', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\memory_optimized_file_2063267240' ) TO FILEGROUP [memory_optimized_filegroup_0]
GO

USE [AdventureWorksDW]
GO

EXEC dbo.sp_rename @objname = N'[dbo].[FactInternetSales]', @newname = N'FactInternetSales_old', @objtype = N'OBJECT'
GO

USE [AdventureWorksDW]
GO

SET ANSI_NULLS ON
GO

CREATE TABLE [dbo].[FactInternetSales]
(
	[ProductKey] [int] NOT NULL,
	[OrderDateKey] [int] NOT NULL,
	[DueDateKey] [int] NOT NULL,
	[ShipDateKey] [int] NOT NULL,
	[CustomerKey] [int] NOT NULL,
	[PromotionKey] [int] NOT NULL,
	[CurrencyKey] [int] NOT NULL,
	[SalesTerritoryKey] [int] NOT NULL,
	[SalesOrderNumber] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SalesOrderLineNumber] [tinyint] NOT NULL,
	[RevisionNumber] [tinyint] NOT NULL,
	[OrderQuantity] [smallint] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[ExtendedAmount] [money] NOT NULL,
	[UnitPriceDiscountPct] [float](53) NOT NULL,
	[DiscountAmount] [float](53) NOT NULL,
	[ProductStandardCost] [money] NOT NULL,
	[TotalProductCost] [money] NOT NULL,
	[SalesAmount] [money] NOT NULL,
	[TaxAmt] [money] NOT NULL,
	[Freight] [money] NOT NULL,
	[CarrierTrackingNumber] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CustomerPONumber] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OrderDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[ShipDate] [datetime] NULL,

 CONSTRAINT [FactInternetSales_primaryKey]  PRIMARY KEY NONCLUSTERED HASH 
(
	[SalesOrderNumber],
	[SalesOrderLineNumber]
)WITH ( BUCKET_COUNT = 2097152)
,INDEX CCI_OnlineFactInternetSales CLUSTERED COLUMNSTORE 
)WITH ( MEMORY_OPTIMIZED = ON , DURABILITY = SCHEMA_AND_DATA )

GO

INSERT INTO [AdventureWorksDW].[dbo].[FactInternetSales] ([ProductKey], [OrderDateKey], [DueDateKey], [ShipDateKey], [CustomerKey], [PromotionKey], [CurrencyKey], [SalesTerritoryKey], [SalesOrderNumber], [SalesOrderLineNumber], [RevisionNumber], [OrderQuantity], [UnitPrice], [ExtendedAmount], [UnitPriceDiscountPct], [DiscountAmount], [ProductStandardCost], [TotalProductCost], [SalesAmount], [TaxAmt], [Freight], [CarrierTrackingNumber], [CustomerPONumber], [OrderDate], [DueDate], [ShipDate]) SELECT [ProductKey], [OrderDateKey], [DueDateKey], [ShipDateKey], [CustomerKey], [PromotionKey], [CurrencyKey], [SalesTerritoryKey], [SalesOrderNumber], [SalesOrderLineNumber], [RevisionNumber], [OrderQuantity], [UnitPrice], [ExtendedAmount], [UnitPriceDiscountPct], [DiscountAmount], [ProductStandardCost], [TotalProductCost], [SalesAmount], [TaxAmt], [Freight], [CarrierTrackingNumber], [CustomerPONumber], [OrderDate], [DueDate], [ShipDate] FROM [AdventureWorksDW].[dbo].[FactInternetSales_old] 

GO



USE [master]
GO
/****** Object:  Database [ToyCompanyDB]    Script Date: 27-03-2020 02:46:58 ******/
CREATE DATABASE [ToyCompanyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToyCompanyDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ToyCompanyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToyCompanyDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ToyCompanyDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ToyCompanyDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToyCompanyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToyCompanyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToyCompanyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToyCompanyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ToyCompanyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToyCompanyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ToyCompanyDB] SET  MULTI_USER 
GO
ALTER DATABASE [ToyCompanyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToyCompanyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToyCompanyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToyCompanyDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ToyCompanyDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ToyCompanyDB] SET QUERY_STORE = OFF
GO
USE [ToyCompanyDB]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 27-03-2020 02:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[MobileNumber] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Address] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 27-03-2020 02:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[ShippedDate] [date] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToysDetails]    Script Date: 27-03-2020 02:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToysDetails](
	[ToyId] [int] IDENTITY(1,1) NOT NULL,
	[ToyType] [varchar](50) NOT NULL,
	[ToyPrice] [int] NOT NULL,
	[PlantId] [int] NOT NULL,
 CONSTRAINT [PK_ToysDetails] PRIMARY KEY CLUSTERED 
(
	[ToyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 27-03-2020 02:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ToyId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[TotalPrice] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vOrdersDetails]    Script Date: 27-03-2020 02:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vOrdersDetails] as
select CustomerName,ToyType,Quantity,Orders.Address,Status,ShippedDate,Orders.Totalprice from Customers,ToysDetails,OrderDetails,Orders 
where Customers.CustomerId=Orders.CustomerId and Orders.ToyId = ToysDetails.ToyId 
and OrderDetails.OrderId=Orders.OrderId;
GO
/****** Object:  Table [dbo].[Plants]    Script Date: 27-03-2020 02:46:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plants](
	[PlantId] [int] IDENTITY(1,1) NOT NULL,
	[PlanName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Plants] PRIMARY KEY CLUSTERED 
(
	[PlantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_ToysDetails] FOREIGN KEY([ToyId])
REFERENCES [dbo].[ToysDetails] ([ToyId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_ToysDetails]
GO
ALTER TABLE [dbo].[ToysDetails]  WITH CHECK ADD  CONSTRAINT [FK_ToysDetails_Plants] FOREIGN KEY([PlantId])
REFERENCES [dbo].[Plants] ([PlantId])
GO
ALTER TABLE [dbo].[ToysDetails] CHECK CONSTRAINT [FK_ToysDetails_Plants]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ToysDetails"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 251
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customers"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Orders"
            Begin Extent = 
               Top = 6
               Left = 457
               Bottom = 136
               Right = 627
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderDetails"
            Begin Extent = 
               Top = 6
               Left = 249
               Bottom = 136
               Right = 419
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vOrdersDetails'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vOrdersDetails'
GO
USE [master]
GO
ALTER DATABASE [ToyCompanyDB] SET  READ_WRITE 
GO

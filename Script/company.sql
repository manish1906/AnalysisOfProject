USE [master]
GO
/****** Object:  Database [SoftwareCompanyDB]    Script Date: 28-03-2020 01:58:24 ******/
CREATE DATABASE [SoftwareCompanyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SoftwareCompanyDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SoftwareCompanyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SoftwareCompanyDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SoftwareCompanyDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SoftwareCompanyDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SoftwareCompanyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SoftwareCompanyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SoftwareCompanyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SoftwareCompanyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SoftwareCompanyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SoftwareCompanyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SoftwareCompanyDB] SET  MULTI_USER 
GO
ALTER DATABASE [SoftwareCompanyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SoftwareCompanyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SoftwareCompanyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SoftwareCompanyDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SoftwareCompanyDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SoftwareCompanyDB] SET QUERY_STORE = OFF
GO
USE [SoftwareCompanyDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 28-03-2020 01:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](50) NOT NULL,
	[MobileNumber] [int] NOT NULL,
	[Email] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BussinessUnits]    Script Date: 28-03-2020 01:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BussinessUnits](
	[BussinessUnitId] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [varchar](30) NOT NULL,
	[Location] [varchar](30) NOT NULL,
 CONSTRAINT [PK_BussinessUnits] PRIMARY KEY CLUSTERED 
(
	[BussinessUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 28-03-2020 01:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[AssignManager] [int] NOT NULL,
	[BussinessId] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignProject]    Script Date: 28-03-2020 01:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignProject](
	[AssignId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_AssignProject] PRIMARY KEY CLUSTERED 
(
	[AssignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vAssignProject]    Script Date: 28-03-2020 01:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[vAssignProject] as
select AssignId, EmployeeName, ProjectName,UnitName from 
Projects,BussinessUnits,AssignProject,Employees  where
Employees.EmployeeId=AssignProject.EmployeeId and Projects.ProjectId=AssignProject.ProjectId
and BussinessUnits.BussinessUnitId=Projects.BussinessId
GO
/****** Object:  View [dbo].[vProjectDetails]    Script Date: 28-03-2020 01:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vProjectDetails] as
select ProjectId, ProjectName,Description, EmployeeName as Manager, UnitName from BussinessUnits,Employees ,Projects where EmployeeId=AssignManager 
and BussinessUnitId=BussinessId
GO
/****** Object:  Table [dbo].[OnVacation]    Script Date: 28-03-2020 01:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OnVacation](
	[VacationId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_OnVacation] PRIMARY KEY CLUSTERED 
(
	[VacationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssignProject]  WITH CHECK ADD  CONSTRAINT [FK_AssignProject_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[AssignProject] CHECK CONSTRAINT [FK_AssignProject_Employees]
GO
ALTER TABLE [dbo].[AssignProject]  WITH CHECK ADD  CONSTRAINT [FK_AssignProject_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[AssignProject] CHECK CONSTRAINT [FK_AssignProject_Projects]
GO
ALTER TABLE [dbo].[OnVacation]  WITH CHECK ADD  CONSTRAINT [FK_OnVacation_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[OnVacation] CHECK CONSTRAINT [FK_OnVacation_Employees]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_BussinessUnits] FOREIGN KEY([BussinessId])
REFERENCES [dbo].[BussinessUnits] ([BussinessUnitId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_BussinessUnits]
GO
USE [master]
GO
ALTER DATABASE [SoftwareCompanyDB] SET  READ_WRITE 
GO

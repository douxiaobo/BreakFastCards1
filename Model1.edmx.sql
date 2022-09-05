
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/06/2022 13:12:39
-- Generated from EDMX file: C:\Users\a-xiaobodou\OneDrive - Microsoft\Projects\ASP.NET\BreakfastCards1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BreakfastCards];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Table_ActualQuantity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table_ActualQuantity];
GO
IF OBJECT_ID(N'[dbo].[Table_BreakfastBoolean]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table_BreakfastBoolean];
GO
IF OBJECT_ID(N'[dbo].[Table_FourName]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table_FourName];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Table_ActualQuantity'
CREATE TABLE [dbo].[Table_ActualQuantity] (
    [ID] nvarchar(50)  NOT NULL,
    [Year] nchar(10)  NULL,
    [Month] nchar(10)  NULL,
    [GroupName] nchar(10)  NULL,
    [Cards] nchar(10)  NULL,
    [ActualQuantity] int  NULL,
    [LostCard_Boolean] nchar(10)  NULL
);
GO

-- Creating table 'Table_BreakfastBoolean'
CREATE TABLE [dbo].[Table_BreakfastBoolean] (
    [ID] nvarchar(50)  NOT NULL,
    [Year] nchar(10)  NULL,
    [Month] nchar(10)  NULL,
    [GroupName] nchar(10)  NULL,
    [Cards] nchar(10)  NULL,
    [Data] nchar(10)  NULL,
    [Breakfast_Boolean] nchar(10)  NULL
);
GO

-- Creating table 'Table_FourName'
CREATE TABLE [dbo].[Table_FourName] (
    [ID] nchar(10)  NOT NULL,
    [Date] nvarchar(50)  NULL,
    [GroupName] nvarchar(50)  NULL,
    [Quantity] int  NULL,
    [Manager] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Table_ActualQuantity'
ALTER TABLE [dbo].[Table_ActualQuantity]
ADD CONSTRAINT [PK_Table_ActualQuantity]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Table_BreakfastBoolean'
ALTER TABLE [dbo].[Table_BreakfastBoolean]
ADD CONSTRAINT [PK_Table_BreakfastBoolean]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Table_FourName'
ALTER TABLE [dbo].[Table_FourName]
ADD CONSTRAINT [PK_Table_FourName]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
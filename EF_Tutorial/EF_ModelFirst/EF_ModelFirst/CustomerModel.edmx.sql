
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/06/2020 21:59:40
-- Generated from EDMX file: D:\GIT\EF-MVC\ModelFirst\ModelFirst\CustomerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CustomerDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CustomerProfiles'
CREATE TABLE [dbo].[CustomerProfiles] (
    [CustId] int IDENTITY(1,1) NOT NULL,
    [CustName] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL
);
GO

-- Creating table 'CustomerPurchases'
CREATE TABLE [dbo].[CustomerPurchases] (
    [CustId] int IDENTITY(1,1) NOT NULL,
    [Product] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [PurchaseDate] datetime  NOT NULL,
    [CustomerProfileCustId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustId] in table 'CustomerProfiles'
ALTER TABLE [dbo].[CustomerProfiles]
ADD CONSTRAINT [PK_CustomerProfiles]
    PRIMARY KEY CLUSTERED ([CustId] ASC);
GO

-- Creating primary key on [CustId] in table 'CustomerPurchases'
ALTER TABLE [dbo].[CustomerPurchases]
ADD CONSTRAINT [PK_CustomerPurchases]
    PRIMARY KEY CLUSTERED ([CustId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerProfileCustId] in table 'CustomerPurchases'
ALTER TABLE [dbo].[CustomerPurchases]
ADD CONSTRAINT [FK_CustomerProfileCustomerPurchase]
    FOREIGN KEY ([CustomerProfileCustId])
    REFERENCES [dbo].[CustomerProfiles]
        ([CustId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerProfileCustomerPurchase'
CREATE INDEX [IX_FK_CustomerProfileCustomerPurchase]
ON [dbo].[CustomerPurchases]
    ([CustomerProfileCustId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
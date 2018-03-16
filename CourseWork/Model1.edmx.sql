
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/16/2018 14:41:20
-- Generated from EDMX file: C:\Users\user\Documents\GitHub\CourseWork\CourseWork\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_CustomerOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_UserOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_UserOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonWorker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StavkaSet] DROP CONSTRAINT [FK_PersonWorker];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderOrderEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderEntrySet] DROP CONSTRAINT [FK_OrderOrderEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_MeterOrderEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderEntrySet] DROP CONSTRAINT [FK_MeterOrderEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_MeterTypeMeter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MeterSet] DROP CONSTRAINT [FK_MeterTypeMeter];
GO
IF OBJECT_ID(N'[dbo].[FK_MeterTypeStavka]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StavkaSet] DROP CONSTRAINT [FK_MeterTypeStavka];
GO
IF OBJECT_ID(N'[dbo].[FK_StatusOrderEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderEntrySet] DROP CONSTRAINT [FK_StatusOrderEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_CityStreet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StreetSet] DROP CONSTRAINT [FK_CityStreet];
GO
IF OBJECT_ID(N'[dbo].[FK_HouseAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AddressSet] DROP CONSTRAINT [FK_HouseAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_AddressOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_StreetHouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HouseSet] DROP CONSTRAINT [FK_StreetHouse];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonOrderEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderEntrySet] DROP CONSTRAINT [FK_PersonOrderEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_Company_inherits_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerSet_Company] DROP CONSTRAINT [FK_Company_inherits_Customer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[CustomerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[StavkaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StavkaSet];
GO
IF OBJECT_ID(N'[dbo].[MeterSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MeterSet];
GO
IF OBJECT_ID(N'[dbo].[OrderEntrySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderEntrySet];
GO
IF OBJECT_ID(N'[dbo].[MeterTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MeterTypeSet];
GO
IF OBJECT_ID(N'[dbo].[StatusSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatusSet];
GO
IF OBJECT_ID(N'[dbo].[CitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CitySet];
GO
IF OBJECT_ID(N'[dbo].[StreetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StreetSet];
GO
IF OBJECT_ID(N'[dbo].[HouseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HouseSet];
GO
IF OBJECT_ID(N'[dbo].[AddressSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AddressSet];
GO
IF OBJECT_ID(N'[dbo].[CustomerSet_Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerSet_Company];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Customer_Id] int  NOT NULL,
    [User_Id] int  NOT NULL,
    [Address_Id] int  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserType] int  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Passport] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FIO] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StavkaSet'
CREATE TABLE [dbo].[StavkaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Person_Id] int  NOT NULL,
    [MeterType_Id] int  NOT NULL
);
GO

-- Creating table 'MeterSet'
CREATE TABLE [dbo].[MeterSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [MeterType_Id] int  NOT NULL
);
GO

-- Creating table 'OrderEntrySet'
CREATE TABLE [dbo].[OrderEntrySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RegNumer] nvarchar(max)  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [PersonId] int  NULL,
    [Order_Id] int  NOT NULL,
    [Meter_Id] int  NOT NULL,
    [Status_Id] int  NOT NULL
);
GO

-- Creating table 'MeterTypeSet'
CREATE TABLE [dbo].[MeterTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StatusSet'
CREATE TABLE [dbo].[StatusSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CitySet'
CREATE TABLE [dbo].[CitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StreetSet'
CREATE TABLE [dbo].[StreetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [City_Id] int  NOT NULL
);
GO

-- Creating table 'HouseSet'
CREATE TABLE [dbo].[HouseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Street_Id] int  NOT NULL
);
GO

-- Creating table 'AddressSet'
CREATE TABLE [dbo].[AddressSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Flat] int  NOT NULL,
    [House_Id] int  NOT NULL
);
GO

-- Creating table 'CustomerSet_Company'
CREATE TABLE [dbo].[CustomerSet_Company] (
    [CompanyName] nvarchar(max)  NOT NULL,
    [INN] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StavkaSet'
ALTER TABLE [dbo].[StavkaSet]
ADD CONSTRAINT [PK_StavkaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MeterSet'
ALTER TABLE [dbo].[MeterSet]
ADD CONSTRAINT [PK_MeterSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderEntrySet'
ALTER TABLE [dbo].[OrderEntrySet]
ADD CONSTRAINT [PK_OrderEntrySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MeterTypeSet'
ALTER TABLE [dbo].[MeterTypeSet]
ADD CONSTRAINT [PK_MeterTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatusSet'
ALTER TABLE [dbo].[StatusSet]
ADD CONSTRAINT [PK_StatusSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CitySet'
ALTER TABLE [dbo].[CitySet]
ADD CONSTRAINT [PK_CitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StreetSet'
ALTER TABLE [dbo].[StreetSet]
ADD CONSTRAINT [PK_StreetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HouseSet'
ALTER TABLE [dbo].[HouseSet]
ADD CONSTRAINT [PK_HouseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AddressSet'
ALTER TABLE [dbo].[AddressSet]
ADD CONSTRAINT [PK_AddressSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerSet_Company'
ALTER TABLE [dbo].[CustomerSet_Company]
ADD CONSTRAINT [PK_CustomerSet_Company]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Customer_Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[OrderSet]
    ([Customer_Id]);
GO

-- Creating foreign key on [User_Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_UserOrder]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOrder'
CREATE INDEX [IX_FK_UserOrder]
ON [dbo].[OrderSet]
    ([User_Id]);
GO

-- Creating foreign key on [Person_Id] in table 'StavkaSet'
ALTER TABLE [dbo].[StavkaSet]
ADD CONSTRAINT [FK_PersonWorker]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonWorker'
CREATE INDEX [IX_FK_PersonWorker]
ON [dbo].[StavkaSet]
    ([Person_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'OrderEntrySet'
ALTER TABLE [dbo].[OrderEntrySet]
ADD CONSTRAINT [FK_OrderOrderEntry]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[OrderSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderEntry'
CREATE INDEX [IX_FK_OrderOrderEntry]
ON [dbo].[OrderEntrySet]
    ([Order_Id]);
GO

-- Creating foreign key on [Meter_Id] in table 'OrderEntrySet'
ALTER TABLE [dbo].[OrderEntrySet]
ADD CONSTRAINT [FK_MeterOrderEntry]
    FOREIGN KEY ([Meter_Id])
    REFERENCES [dbo].[MeterSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MeterOrderEntry'
CREATE INDEX [IX_FK_MeterOrderEntry]
ON [dbo].[OrderEntrySet]
    ([Meter_Id]);
GO

-- Creating foreign key on [MeterType_Id] in table 'MeterSet'
ALTER TABLE [dbo].[MeterSet]
ADD CONSTRAINT [FK_MeterTypeMeter]
    FOREIGN KEY ([MeterType_Id])
    REFERENCES [dbo].[MeterTypeSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MeterTypeMeter'
CREATE INDEX [IX_FK_MeterTypeMeter]
ON [dbo].[MeterSet]
    ([MeterType_Id]);
GO

-- Creating foreign key on [MeterType_Id] in table 'StavkaSet'
ALTER TABLE [dbo].[StavkaSet]
ADD CONSTRAINT [FK_MeterTypeStavka]
    FOREIGN KEY ([MeterType_Id])
    REFERENCES [dbo].[MeterTypeSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MeterTypeStavka'
CREATE INDEX [IX_FK_MeterTypeStavka]
ON [dbo].[StavkaSet]
    ([MeterType_Id]);
GO

-- Creating foreign key on [Status_Id] in table 'OrderEntrySet'
ALTER TABLE [dbo].[OrderEntrySet]
ADD CONSTRAINT [FK_StatusOrderEntry]
    FOREIGN KEY ([Status_Id])
    REFERENCES [dbo].[StatusSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StatusOrderEntry'
CREATE INDEX [IX_FK_StatusOrderEntry]
ON [dbo].[OrderEntrySet]
    ([Status_Id]);
GO

-- Creating foreign key on [City_Id] in table 'StreetSet'
ALTER TABLE [dbo].[StreetSet]
ADD CONSTRAINT [FK_CityStreet]
    FOREIGN KEY ([City_Id])
    REFERENCES [dbo].[CitySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityStreet'
CREATE INDEX [IX_FK_CityStreet]
ON [dbo].[StreetSet]
    ([City_Id]);
GO

-- Creating foreign key on [House_Id] in table 'AddressSet'
ALTER TABLE [dbo].[AddressSet]
ADD CONSTRAINT [FK_HouseAddress]
    FOREIGN KEY ([House_Id])
    REFERENCES [dbo].[HouseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HouseAddress'
CREATE INDEX [IX_FK_HouseAddress]
ON [dbo].[AddressSet]
    ([House_Id]);
GO

-- Creating foreign key on [Address_Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_AddressOrder]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[AddressSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressOrder'
CREATE INDEX [IX_FK_AddressOrder]
ON [dbo].[OrderSet]
    ([Address_Id]);
GO

-- Creating foreign key on [Street_Id] in table 'HouseSet'
ALTER TABLE [dbo].[HouseSet]
ADD CONSTRAINT [FK_StreetHouse]
    FOREIGN KEY ([Street_Id])
    REFERENCES [dbo].[StreetSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StreetHouse'
CREATE INDEX [IX_FK_StreetHouse]
ON [dbo].[HouseSet]
    ([Street_Id]);
GO

-- Creating foreign key on [PersonId] in table 'OrderEntrySet'
ALTER TABLE [dbo].[OrderEntrySet]
ADD CONSTRAINT [FK_PersonOrderEntry]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonOrderEntry'
CREATE INDEX [IX_FK_PersonOrderEntry]
ON [dbo].[OrderEntrySet]
    ([PersonId]);
GO

-- Creating foreign key on [Id] in table 'CustomerSet_Company'
ALTER TABLE [dbo].[CustomerSet_Company]
ADD CONSTRAINT [FK_Company_inherits_Customer]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO
-- -------------------------------------------------
-- ADDING SUPERUSER
-- -------------------------------------------------
INSERT INTO [dbo].[UserSet] (Login,Password,UserType)
	VALUES ('root','123qwe',0);
GO
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
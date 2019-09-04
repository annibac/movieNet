
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/04/2019 09:38:06
-- Generated from EDMX file: C:\Users\annib\Documents\SCHOOL\Net\MovieNet_CLEAN\MoviesDatabase\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RateSet] DROP CONSTRAINT [FK_UserRate];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMovies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MoviesSet] DROP CONSTRAINT [FK_UserMovies];
GO
IF OBJECT_ID(N'[dbo].[FK_MoviesRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RateSet] DROP CONSTRAINT [FK_MoviesRate];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[MoviesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MoviesSet];
GO
IF OBJECT_ID(N'[dbo].[RateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RateSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [Lastname] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MoviesSet'
CREATE TABLE [dbo].[MoviesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RateSet'
CREATE TABLE [dbo].[RateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Score] bigint  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL,
    [Movies_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MoviesSet'
ALTER TABLE [dbo].[MoviesSet]
ADD CONSTRAINT [PK_MoviesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [PK_RateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [FK_UserRate]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRate'
CREATE INDEX [IX_FK_UserRate]
ON [dbo].[RateSet]
    ([User_Id]);
GO

-- Creating foreign key on [Movies_Id] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [FK_MoviesRate]
    FOREIGN KEY ([Movies_Id])
    REFERENCES [dbo].[MoviesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MoviesRate'
CREATE INDEX [IX_FK_MoviesRate]
ON [dbo].[RateSet]
    ([Movies_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
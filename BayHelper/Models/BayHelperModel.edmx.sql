
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/23/2012 15:32:26
-- Generated from EDMX file: C:\dev\A-team-named-L.A.R.S\BayHelper\Models\BayHelperModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BayHelper];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Comment_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_Comment_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_Comment_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_Comment_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_User];
GO
IF OBJECT_ID(N'[dbo].[FK_FinanceDonation_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FinanceDonation] DROP CONSTRAINT [FK_FinanceDonation_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_FinanceDonation_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FinanceDonation] DROP CONSTRAINT [FK_FinanceDonation_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Message_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_Message_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Message_User1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_Message_User1];
GO
IF OBJECT_ID(N'[dbo].[FK_Resource_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Resource] DROP CONSTRAINT [FK_Resource_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_ResourceDonation_Resource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResourceDonation] DROP CONSTRAINT [FK_ResourceDonation_Resource];
GO
IF OBJECT_ID(N'[dbo].[FK_ResourceDonation_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResourceDonation] DROP CONSTRAINT [FK_ResourceDonation_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Task_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Task] DROP CONSTRAINT [FK_Task_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_TimeDonation_Task]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeDonation] DROP CONSTRAINT [FK_TimeDonation_Task];
GO
IF OBJECT_ID(N'[dbo].[FK_TimeDonation_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeDonation] DROP CONSTRAINT [FK_TimeDonation_User];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Organization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Organization];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comment];
GO
IF OBJECT_ID(N'[dbo].[Event]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Event];
GO
IF OBJECT_ID(N'[dbo].[FinanceDonation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FinanceDonation];
GO
IF OBJECT_ID(N'[dbo].[Message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Message];
GO
IF OBJECT_ID(N'[dbo].[Organization]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organization];
GO
IF OBJECT_ID(N'[dbo].[Resource]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Resource];
GO
IF OBJECT_ID(N'[dbo].[ResourceDonation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResourceDonation];
GO
IF OBJECT_ID(N'[dbo].[Task]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Task];
GO
IF OBJECT_ID(N'[dbo].[TimeDonation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeDonation];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressID] int IDENTITY(1,1) NOT NULL,
    [StreetAddress] varchar(200)  NULL,
    [Apt] varchar(10)  NULL,
    [City] varchar(100)  NULL,
    [Zip] varchar(10)  NULL,
    [State] varchar(2)  NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [CommentID] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(200)  NULL,
    [Description] varchar(2500)  NULL,
    [Date] datetime  NULL,
    [UserID] int  NULL,
    [EventID] int  NULL,
    [Rating] int  NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EventID] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(100)  NULL,
    [Description] varchar(2500)  NULL,
    [DateStarted] datetime  NULL,
    [DueDate] datetime  NULL,
    [Status] varchar(50)  NULL,
    [FinanceGoal] int  NULL,
    [AddressID] int  NULL,
    [Creator] int  NULL
);
GO

-- Creating table 'FinanceDonations'
CREATE TABLE [dbo].[FinanceDonations] (
    [FinanceDonation1] int IDENTITY(1,1) NOT NULL,
    [EventID] int  NULL,
    [UserID] int  NULL,
    [Amount] int  NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [MessageID] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(150)  NULL,
    [Description] varchar(2500)  NULL,
    [Writer] int  NULL,
    [Reciever] int  NULL
);
GO

-- Creating table 'Organizations'
CREATE TABLE [dbo].[Organizations] (
    [OrganizationID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NULL,
    [Description] varchar(200)  NULL,
    [Rating] int  NULL,
    [DateRegistered] datetime  NULL
);
GO

-- Creating table 'Resources'
CREATE TABLE [dbo].[Resources] (
    [ResourceID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(200)  NULL,
    [Units] varchar(50)  NULL,
    [AmountRequired] int  NULL,
    [EventID] int  NULL
);
GO

-- Creating table 'ResourceDonations'
CREATE TABLE [dbo].[ResourceDonations] (
    [ResourceDonationID] int IDENTITY(1,1) NOT NULL,
    [ResorceID] int  NULL,
    [UserID] int  NULL,
    [Amount] int  NULL,
    [Location] int  NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [TaskID] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(100)  NULL,
    [Description] varchar(2500)  NULL,
    [TimeEstimate] int  NULL,
    [FinanceEstimate] int  NULL,
    [EventID] int  NULL
);
GO

-- Creating table 'TimeDonations'
CREATE TABLE [dbo].[TimeDonations] (
    [TimeDonationID] int IDENTITY(1,1) NOT NULL,
    [TaskID] int  NULL,
    [UserID] int  NULL,
    [Amount] int  NULL,
    [Date] datetime  NULL,
    [Status] varchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [LastName] varchar(100)  NULL,
    [FirstName] varchar(100)  NULL,
    [Nickname] varchar(100)  NULL,
    [Email] varchar(100)  NULL,
    [AddressID] int  NULL,
    [Rating] int  NULL,
    [DateRegistered] datetime  NULL,
    [OrganizationUser] bit  NULL,
    [OrganizationID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AddressID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressID] ASC);
GO

-- Creating primary key on [CommentID] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([CommentID] ASC);
GO

-- Creating primary key on [EventID] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EventID] ASC);
GO

-- Creating primary key on [FinanceDonation1] in table 'FinanceDonations'
ALTER TABLE [dbo].[FinanceDonations]
ADD CONSTRAINT [PK_FinanceDonations]
    PRIMARY KEY CLUSTERED ([FinanceDonation1] ASC);
GO

-- Creating primary key on [MessageID] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([MessageID] ASC);
GO

-- Creating primary key on [OrganizationID] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [PK_Organizations]
    PRIMARY KEY CLUSTERED ([OrganizationID] ASC);
GO

-- Creating primary key on [ResourceID] in table 'Resources'
ALTER TABLE [dbo].[Resources]
ADD CONSTRAINT [PK_Resources]
    PRIMARY KEY CLUSTERED ([ResourceID] ASC);
GO

-- Creating primary key on [ResourceDonationID] in table 'ResourceDonations'
ALTER TABLE [dbo].[ResourceDonations]
ADD CONSTRAINT [PK_ResourceDonations]
    PRIMARY KEY CLUSTERED ([ResourceDonationID] ASC);
GO

-- Creating primary key on [TaskID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([TaskID] ASC);
GO

-- Creating primary key on [TimeDonationID] in table 'TimeDonations'
ALTER TABLE [dbo].[TimeDonations]
ADD CONSTRAINT [PK_TimeDonations]
    PRIMARY KEY CLUSTERED ([TimeDonationID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AddressID] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_Address]
    FOREIGN KEY ([AddressID])
    REFERENCES [dbo].[Addresses]
        ([AddressID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_Address'
CREATE INDEX [IX_FK_Event_Address]
ON [dbo].[Events]
    ([AddressID]);
GO

-- Creating foreign key on [AddressID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Address]
    FOREIGN KEY ([AddressID])
    REFERENCES [dbo].[Addresses]
        ([AddressID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Address'
CREATE INDEX [IX_FK_User_Address]
ON [dbo].[Users]
    ([AddressID]);
GO

-- Creating foreign key on [EventID] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comment_Event]
    FOREIGN KEY ([EventID])
    REFERENCES [dbo].[Events]
        ([EventID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comment_Event'
CREATE INDEX [IX_FK_Comment_Event]
ON [dbo].[Comments]
    ([EventID]);
GO

-- Creating foreign key on [UserID] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comment_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comment_User'
CREATE INDEX [IX_FK_Comment_User]
ON [dbo].[Comments]
    ([UserID]);
GO

-- Creating foreign key on [Creator] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_User]
    FOREIGN KEY ([Creator])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_User'
CREATE INDEX [IX_FK_Event_User]
ON [dbo].[Events]
    ([Creator]);
GO

-- Creating foreign key on [EventID] in table 'FinanceDonations'
ALTER TABLE [dbo].[FinanceDonations]
ADD CONSTRAINT [FK_FinanceDonation_Event]
    FOREIGN KEY ([EventID])
    REFERENCES [dbo].[Events]
        ([EventID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FinanceDonation_Event'
CREATE INDEX [IX_FK_FinanceDonation_Event]
ON [dbo].[FinanceDonations]
    ([EventID]);
GO

-- Creating foreign key on [EventID] in table 'Resources'
ALTER TABLE [dbo].[Resources]
ADD CONSTRAINT [FK_Resource_Event]
    FOREIGN KEY ([EventID])
    REFERENCES [dbo].[Events]
        ([EventID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Resource_Event'
CREATE INDEX [IX_FK_Resource_Event]
ON [dbo].[Resources]
    ([EventID]);
GO

-- Creating foreign key on [EventID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_Task_Event]
    FOREIGN KEY ([EventID])
    REFERENCES [dbo].[Events]
        ([EventID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Task_Event'
CREATE INDEX [IX_FK_Task_Event]
ON [dbo].[Tasks]
    ([EventID]);
GO

-- Creating foreign key on [UserID] in table 'FinanceDonations'
ALTER TABLE [dbo].[FinanceDonations]
ADD CONSTRAINT [FK_FinanceDonation_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FinanceDonation_User'
CREATE INDEX [IX_FK_FinanceDonation_User]
ON [dbo].[FinanceDonations]
    ([UserID]);
GO

-- Creating foreign key on [Writer] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_Message_User]
    FOREIGN KEY ([Writer])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Message_User'
CREATE INDEX [IX_FK_Message_User]
ON [dbo].[Messages]
    ([Writer]);
GO

-- Creating foreign key on [Reciever] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_Message_User1]
    FOREIGN KEY ([Reciever])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Message_User1'
CREATE INDEX [IX_FK_Message_User1]
ON [dbo].[Messages]
    ([Reciever]);
GO

-- Creating foreign key on [OrganizationID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Organization]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[Organizations]
        ([OrganizationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Organization'
CREATE INDEX [IX_FK_User_Organization]
ON [dbo].[Users]
    ([OrganizationID]);
GO

-- Creating foreign key on [ResorceID] in table 'ResourceDonations'
ALTER TABLE [dbo].[ResourceDonations]
ADD CONSTRAINT [FK_ResourceDonation_Resource]
    FOREIGN KEY ([ResorceID])
    REFERENCES [dbo].[Resources]
        ([ResourceID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ResourceDonation_Resource'
CREATE INDEX [IX_FK_ResourceDonation_Resource]
ON [dbo].[ResourceDonations]
    ([ResorceID]);
GO

-- Creating foreign key on [UserID] in table 'ResourceDonations'
ALTER TABLE [dbo].[ResourceDonations]
ADD CONSTRAINT [FK_ResourceDonation_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ResourceDonation_User'
CREATE INDEX [IX_FK_ResourceDonation_User]
ON [dbo].[ResourceDonations]
    ([UserID]);
GO

-- Creating foreign key on [TaskID] in table 'TimeDonations'
ALTER TABLE [dbo].[TimeDonations]
ADD CONSTRAINT [FK_TimeDonation_Task]
    FOREIGN KEY ([TaskID])
    REFERENCES [dbo].[Tasks]
        ([TaskID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TimeDonation_Task'
CREATE INDEX [IX_FK_TimeDonation_Task]
ON [dbo].[TimeDonations]
    ([TaskID]);
GO

-- Creating foreign key on [UserID] in table 'TimeDonations'
ALTER TABLE [dbo].[TimeDonations]
ADD CONSTRAINT [FK_TimeDonation_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TimeDonation_User'
CREATE INDEX [IX_FK_TimeDonation_User]
ON [dbo].[TimeDonations]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
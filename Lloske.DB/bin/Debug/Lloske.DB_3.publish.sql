﻿/*
Deployment script for Lloske

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Lloske"
:setvar DefaultFilePrefix "Lloske"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[amendment]...';


GO
CREATE TABLE [dbo].[amendment] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [Type]                    SMALLINT         NOT NULL,
    [Amendment_start]         DATE             NOT NULL,
    [Amendment_end]           DATE             NOT NULL,
    [Amendment_minutes]       INT              NOT NULL,
    [FK_Id_User_payroll_data] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Amendment] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[event]...';


GO
CREATE TABLE [dbo].[event] (
    [Id]                               UNIQUEIDENTIFIER NOT NULL,
    [Start_date]                       DATE             NOT NULL,
    [Start_time]                       TIME (7)         NOT NULL,
    [End_time]                         TIME (7)         NOT NULL,
    [Break_duration]                   INT              NOT NULL,
    [Meal]                             INT              NOT NULL,
    [Event_note]                       NVARCHAR (MAX)   NULL,
    [Week_number]                      INT              NOT NULL,
    [FK_id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
    [FK_id_event_team]                 UNIQUEIDENTIFIER NOT NULL,
    [FK_id_event_absence]              UNIQUEIDENTIFIER NOT NULL,
    [FK_id_workplace]                  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[event_absence]...';


GO
CREATE TABLE [dbo].[event_absence] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Absence_type]  SMALLINT         NOT NULL,
    [Absence_hours] INT              NOT NULL,
    [Absence_note]  NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Event_absence] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[event_team]...';


GO
CREATE TABLE [dbo].[event_team] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (100)   NULL,
    [Break_time] INT              NOT NULL,
    CONSTRAINT [PK_Event_team] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[MM_job_position_workplaces]...';


GO
CREATE TABLE [dbo].[MM_job_position_workplaces] (
    [FK_id_job_position]               UNIQUEIDENTIFIER NOT NULL,
    [FK_id_workplace]                  UNIQUEIDENTIFIER NOT NULL,
    [FK_id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_MM_job_position_workplaces] PRIMARY KEY CLUSTERED ([FK_id_job_position] ASC, [FK_id_workplace] ASC, [FK_id_user_personnal_information] ASC)
);


GO
PRINT N'Creating Table [dbo].[MM_organization_user]...';


GO
CREATE TABLE [dbo].[MM_organization_user] (
    [Id]                    UNIQUEIDENTIFIER NOT NULL,
    [FK_PK_id_organization] UNIQUEIDENTIFIER NOT NULL,
    [FK_PK_id_user]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_MM_organization_user] PRIMARY KEY CLUSTERED ([FK_PK_id_organization] ASC, [FK_PK_id_user] ASC)
);


GO
PRINT N'Creating Table [dbo].[MM_workplaces_user]...';


GO
CREATE TABLE [dbo].[MM_workplaces_user] (
    [Main_workplace]                   BIT              NOT NULL,
    [Permission_level]                 SMALLINT         NOT NULL,
    [Visibility]                       BIT              NOT NULL,
    [FK_id_workplace]                  UNIQUEIDENTIFIER NOT NULL,
    [FK_id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_MM_workplace_user] PRIMARY KEY CLUSTERED ([FK_id_workplace] ASC, [FK_id_user_personnal_information] ASC)
);


GO
PRINT N'Creating Table [dbo].[organizations]...';


GO
CREATE TABLE [dbo].[organizations] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[user_contract_information]...';


GO
CREATE TABLE [dbo].[user_contract_information] (
    [Id]                               UNIQUEIDENTIFIER NOT NULL,
    [Contract_type]                    SMALLINT         NULL,
    [Employment_type]                  SMALLINT         NULL,
    [Job_title]                        NVARCHAR (200)   NULL,
    [Organization_entry_date]          DATE             NULL,
    [Contract_start]                   DATETIME2 (7)    NULL,
    [Probation_end_date]               DATE             NULL,
    [Contract_end]                     DATE             NULL,
    [Status]                           SMALLINT         NULL,
    [Professional_category]            SMALLINT         NULL,
    [Last_medical_checkup_date]        DATE             NULL,
    [FK_id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_User_contract_information] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[user_human_ressources_information]...';


GO
CREATE TABLE [dbo].[user_human_ressources_information] (
    [Id]                               UNIQUEIDENTIFIER NOT NULL,
    [Birthdate]                        DATE             NULL,
    [Birthplace]                       NVARCHAR (100)   NULL,
    [Birthland]                        SMALLINT         NULL,
    [Nationality]                      SMALLINT         NULL,
    [Gender]                           SMALLINT         NULL,
    [Address_street]                   NVARCHAR (100)   NULL,
    [Adress_postal_code]               INT              NULL,
    [Adress_city]                      NVARCHAR (50)    NULL,
    [Adress_country]                   SMALLINT         NULL,
    [Iban]                             NVARCHAR (50)    NULL,
    [Bic]                              NVARCHAR (50)    NULL,
    [Social_security_number]           INT              NULL,
    [User_note]                        NVARCHAR (MAX)   NULL,
    [FK_id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_User_human_ressources_information] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[user_payroll_data]...';


GO
CREATE TABLE [dbo].[user_payroll_data] (
    [Id]                            UNIQUEIDENTIFIER NOT NULL,
    [Work_time_measurement]         SMALLINT         NOT NULL,
    [Maximum_contract_hours]        INT              NOT NULL,
    [Id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_User_payroll_data] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[user_personnal_information]...';


GO
CREATE TABLE [dbo].[user_personnal_information] (
    [Id]                       UNIQUEIDENTIFIER NOT NULL,
    [Firstname]                NVARCHAR (100)   NOT NULL,
    [Lastname]                 NVARCHAR (100)   NOT NULL,
    [Payroll_identity]         INT              NULL,
    [Email]                    NVARCHAR (125)   NOT NULL,
    [Phone]                    NVARCHAR (30)    NULL,
    [Is_in_employee_registrer] BIT              NULL,
    [Is_archived]              BIT              NULL,
    [Password_hash]            NVARCHAR (MAX)   NULL,
    [Password_salt]            NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_User_personnal_information] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[workplaces]...';


GO
CREATE TABLE [dbo].[workplaces] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [Name]                NVARCHAR (100)   NOT NULL,
    [FK_id_organizations] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Workplaces] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[workplaces_job_position]...';


GO
CREATE TABLE [dbo].[workplaces_job_position] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (50)    NULL,
    CONSTRAINT [PK_Workplaces_job_position] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Default Constraint unnamed constraint on [dbo].[user_personnal_information]...';


GO
ALTER TABLE [dbo].[user_personnal_information]
    ADD DEFAULT 1 FOR [Is_in_employee_registrer];


GO
PRINT N'Creating Default Constraint unnamed constraint on [dbo].[user_personnal_information]...';


GO
ALTER TABLE [dbo].[user_personnal_information]
    ADD DEFAULT 0 FOR [Is_archived];


GO
PRINT N'Creating Foreign Key [dbo].[FK_Amendment_User_Payroll_Data]...';


GO
ALTER TABLE [dbo].[amendment]
    ADD CONSTRAINT [FK_Amendment_User_Payroll_Data] FOREIGN KEY ([FK_Id_User_payroll_data]) REFERENCES [dbo].[user_payroll_data] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Event_User_personnal_information]...';


GO
ALTER TABLE [dbo].[event]
    ADD CONSTRAINT [FK_Event_User_personnal_information] FOREIGN KEY ([FK_id_user_personnal_information]) REFERENCES [dbo].[user_personnal_information] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Event_Team]...';


GO
ALTER TABLE [dbo].[event]
    ADD CONSTRAINT [FK_Event_Team] FOREIGN KEY ([FK_id_event_team]) REFERENCES [dbo].[event_team] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Event_Event_absence]...';


GO
ALTER TABLE [dbo].[event]
    ADD CONSTRAINT [FK_Event_Event_absence] FOREIGN KEY ([FK_id_event_absence]) REFERENCES [dbo].[event_absence] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Event_Workplaces]...';


GO
ALTER TABLE [dbo].[event]
    ADD CONSTRAINT [FK_Event_Workplaces] FOREIGN KEY ([FK_id_workplace]) REFERENCES [dbo].[workplaces] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_MM_job_position_workplaces_job_position]...';


GO
ALTER TABLE [dbo].[MM_job_position_workplaces]
    ADD CONSTRAINT [FK_MM_job_position_workplaces_job_position] FOREIGN KEY ([FK_id_job_position]) REFERENCES [dbo].[workplaces_job_position] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_MM_job_position_workplaces_workplace_user]...';


GO
ALTER TABLE [dbo].[MM_job_position_workplaces]
    ADD CONSTRAINT [FK_MM_job_position_workplaces_workplace_user] FOREIGN KEY ([FK_id_workplace], [FK_id_user_personnal_information]) REFERENCES [dbo].[MM_workplaces_user] ([FK_id_workplace], [FK_id_user_personnal_information]);


GO
PRINT N'Creating Foreign Key [dbo].[MM_organization_user_Organizations]...';


GO
ALTER TABLE [dbo].[MM_organization_user]
    ADD CONSTRAINT [MM_organization_user_Organizations] FOREIGN KEY ([FK_PK_id_organization]) REFERENCES [dbo].[organizations] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[MM_organization_user_User_personnal_information]...';


GO
ALTER TABLE [dbo].[MM_organization_user]
    ADD CONSTRAINT [MM_organization_user_User_personnal_information] FOREIGN KEY ([FK_PK_id_user]) REFERENCES [dbo].[user_personnal_information] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Workplace_Workplace_user]...';


GO
ALTER TABLE [dbo].[MM_workplaces_user]
    ADD CONSTRAINT [FK_Workplace_Workplace_user] FOREIGN KEY ([FK_id_workplace]) REFERENCES [dbo].[user_personnal_information] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Workplace_user_User_personnal_information]...';


GO
ALTER TABLE [dbo].[MM_workplaces_user]
    ADD CONSTRAINT [FK_Workplace_user_User_personnal_information] FOREIGN KEY ([FK_id_user_personnal_information]) REFERENCES [dbo].[user_personnal_information] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_User_personnal_information_User_contract_information]...';


GO
ALTER TABLE [dbo].[user_contract_information]
    ADD CONSTRAINT [FK_User_personnal_information_User_contract_information] FOREIGN KEY ([FK_id_user_personnal_information]) REFERENCES [dbo].[user_personnal_information] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_User_personnal_inforamtion_User_contract_information]...';


GO
ALTER TABLE [dbo].[user_human_ressources_information]
    ADD CONSTRAINT [FK_User_personnal_inforamtion_User_contract_information] FOREIGN KEY ([FK_id_user_personnal_information]) REFERENCES [dbo].[user_personnal_information] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_User_payroll_data_User_personnal_information]...';


GO
ALTER TABLE [dbo].[user_payroll_data]
    ADD CONSTRAINT [FK_User_payroll_data_User_personnal_information] FOREIGN KEY ([Id_user_personnal_information]) REFERENCES [dbo].[user_personnal_information] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Workplaces_Organizations]...';


GO
ALTER TABLE [dbo].[workplaces]
    ADD CONSTRAINT [FK_Workplaces_Organizations] FOREIGN KEY ([FK_id_organizations]) REFERENCES [dbo].[organizations] ([Id]);


GO
--Permet de supprimer le contenu des tables. Attention il faut le faire dans l'ordre des ForeignKeys
DELETE FROM [amendment];
DELETE FROM [event];
DELETE FROM [event_absenceevent_absence];
DELETE FROM [event_team];
DELETE FROM [MM_job_position_workplaces];
DELETE FROM [MM_organization_user];
DELETE FROM [MM_workplaces_user];
DELETE FROM [organizations];
DELETE FROM [user_contract_information];
DELETE FROM [user_human_ressources_information];
DELETE FROM [user_payroll_data];
DELETE FROM [user_personnal_information];
DELETE FROM [workplaces];
DELETE FROM [workplaces_job_position];



SET IDENTITY_INSERT [user_personnal_information] ON; /* Désactive l'identity -> pour pouvoir mettre vos propres id*/
INSERT INTO [user_personnal_information] ([Id], [Firstname], [Lastname], [Email], [Password_hash])
	VALUES (NEWID(), 'Antoine', 'Tilman', 'antoine_tilman@hotmail.com', 'Test1234=');


GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO

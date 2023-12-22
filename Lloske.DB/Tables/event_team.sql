CREATE TABLE [dbo].[event_team]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100),
	[Break_time] INT NOT NULL,
	CONSTRAINT PK_Event_team PRIMARY KEY ([Id]),
)

CREATE TABLE [dbo].[event_team]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(100),
	[Break_time] DECIMAL NOT NULL,
	CONSTRAINT PK_Event_team PRIMARY KEY ([Id]),
)

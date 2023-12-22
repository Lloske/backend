CREATE TABLE [dbo].[event_absence]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Absence_type] SMALLINT NOT NULL,
	[Absence_hours] INT NOT NULL,
	[Absence_note] NVARCHAR(max),
	CONSTRAINT PK_Event_absence PRIMARY KEY ([Id]),
)

CREATE TABLE [dbo].[organizations]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Organizations PRIMARY KEY ([Id])
)

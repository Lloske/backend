CREATE TABLE [dbo].[workplaces]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [FK_id_organizations] INT NOT NULL,
    CONSTRAINT PK_Workplaces PRIMARY KEY ([Id]),
    CONSTRAINT FK_Workplaces_Organizations FOREIGN KEY (FK_id_organizations) REFERENCES [organizations]([Id])
)

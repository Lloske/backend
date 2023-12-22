CREATE TABLE [dbo].[workplaces]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    [FK_id_organizations] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_Workplaces PRIMARY KEY ([Id]),
    CONSTRAINT FK_Workplaces_Organizations FOREIGN KEY (FK_id_organizations) REFERENCES [organizations]([Id])
)

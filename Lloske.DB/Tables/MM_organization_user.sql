CREATE TABLE [dbo].[MM_organization_user]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[FK_PK_id_organization] UNIQUEIDENTIFIER NOT NULL,
	[FK_PK_id_user] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_MM_organization_user PRIMARY KEY ([FK_PK_id_organization], [FK_PK_id_user]),
	CONSTRAINT MM_organization_user_Organizations FOREIGN KEY (FK_PK_id_organization) REFERENCES [organizations]([Id]),
	CONSTRAINT MM_organization_user_User_personnal_information FOREIGN KEY (FK_PK_id_user) REFERENCES [user_personnal_information]([Id]),
)

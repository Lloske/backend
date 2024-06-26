﻿CREATE TABLE [dbo].[MM_organization_user]
(
	[FK_PK_id_organization] INT NOT NULL IDENTITY,
	[FK_PK_id_user] INT NOT NULL,
	CONSTRAINT PK_MM_organization_user PRIMARY KEY ([FK_PK_id_organization], [FK_PK_id_user]),
	CONSTRAINT MM_organization_user_Organizations FOREIGN KEY (FK_PK_id_organization) REFERENCES [organizations]([Id]),
	CONSTRAINT MM_organization_user_User_personnal_information FOREIGN KEY (FK_PK_id_user) REFERENCES [user_personnal_information]([Id]),
)

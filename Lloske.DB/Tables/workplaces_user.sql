CREATE TABLE [dbo].[workplaces_user]
(
	[Id] INT NOT NULL IDENTITY,
	[Main_workplace] BIT NOT NULL,
	[Permission_level] INT NOT NULL,
	[Visibility] BIT NOT NULL,
	[FK_id_workplace] INT NOT NULL,
	[FK_id_user_personnal_information] INT NOT NULL,
	CONSTRAINT PK_id_workplace_workplaces_user PRIMARY KEY ([Id]),
	CONSTRAINT FK_Workplace_Workplace_user FOREIGN KEY (FK_id_workplace) REFERENCES [user_personnal_information]([Id]),
	CONSTRAINT FK_Workplace_user_User_personnal_information FOREIGN KEY (FK_id_user_personnal_information) REFERENCES [user_personnal_information]([Id]),
)

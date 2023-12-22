CREATE TABLE [dbo].[MM_workplaces_user]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Main_workplace] BIT NOT NULL,
	[Permission_level] SMALLINT NOT NULL,
	[Visibility] BIT NOT NULL,
	[FK_id_workplace] UNIQUEIDENTIFIER NOT NULL,
	[FK_id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_MM_workplace_user PRIMARY KEY ([FK_id_workplace], [FK_id_user_personnal_information]),
	CONSTRAINT FK_Workplace_Workplace_user FOREIGN KEY (FK_id_workplace) REFERENCES [user_personnal_information]([Id]),
	CONSTRAINT FK_Workplace_user_User_personnal_information FOREIGN KEY (FK_id_user_personnal_information) REFERENCES [user_personnal_information]([Id]),
)

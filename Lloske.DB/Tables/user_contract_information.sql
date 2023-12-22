CREATE TABLE [dbo].[user_contract_information]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Contract_type] SMALLINT,
	[Employment_type] SMALLINT,
	[Job_title] NVARCHAR(200),
	[Organization_entry_date] DATE,
	[Contract_start] DATETIME2,
	[Probation_end_date] DATE,
	[Contract_end] DATE,
	[Status] SMALLINT,
	[Professional_category] SMALLINT,
	[Last_medical_checkup_date] DATE,
	[FK_id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_User_contract_information PRIMARY KEY ([Id]),
	CONSTRAINT FK_User_personnal_information_User_contract_information FOREIGN KEY (FK_id_user_personnal_information) REFERENCES [user_personnal_information]([Id]),
)

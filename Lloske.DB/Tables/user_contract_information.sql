CREATE TABLE [dbo].[user_contract_information]
(
	[Id] INT NOT NULL IDENTITY,
	[Contract_type] INT,
	[Employment_type] INT,
	[Job_title] NVARCHAR(200),
	[Organization_entry_date] DATETIME,
	[Contract_start] DATETIME,
	[Probation_end_date] DATETIME,
	[Contract_end] DATETIME,
	[Status] INT,
	[Professional_category] INT,
	[Last_medical_checkup_date] DATETIME,
	[FK_id_user_personnal_information] INT,
	CONSTRAINT PK_User_contract_information PRIMARY KEY ([Id]),
	CONSTRAINT FK_User_personnal_information_User_contract_information FOREIGN KEY (FK_id_user_personnal_information) REFERENCES [user_personnal_information]([Id]),
)

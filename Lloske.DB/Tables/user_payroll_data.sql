CREATE TABLE [dbo].[user_payroll_data]
(
	[Id] INT NOT NULL IDENTITY,
	[Work_time_measurement] SMALLINT,
	[Maximum_contract_hours] SMALLINT,
	[Id_user_personnal_information] INT NOT NULL,
	CONSTRAINT PK_User_payroll_data PRIMARY KEY ([Id]),
	CONSTRAINT FK_User_payroll_data_User_personnal_information FOREIGN KEY ([Id_user_personnal_information]) REFERENCES [user_personnal_information]([Id])
)

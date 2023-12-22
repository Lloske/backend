﻿CREATE TABLE [dbo].[user_payroll_data]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Work_time_measurement] SMALLINT NOT NULL,
	[Maximum_contract_hours] INT NOT NULL,
	[Id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_User_payroll_data PRIMARY KEY ([Id]),
	CONSTRAINT FK_User_payroll_data_User_personnal_information FOREIGN KEY ([Id_user_personnal_information]) REFERENCES [user_personnal_information]([Id])
)

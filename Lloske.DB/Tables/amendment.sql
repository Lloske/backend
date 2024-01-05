CREATE TABLE [dbo].[amendment]
(
	[Id] INT NOT NULL IDENTITY,
	[Type] SMALLINT NOT NULL,
	[Amendment_start] DATE NOT NULL,
	[Amendment_end] DATE NOT NULL,
	[Amendment_minutes] INT NOT NULL,
	[FK_Id_User_payroll_data] INT NOT NULL,
	CONSTRAINT PK_Amendment PRIMARY KEY ([Id]),
	CONSTRAINT FK_Amendment_User_Payroll_Data FOREIGN KEY ([FK_Id_User_payroll_data]) REFERENCES [user_payroll_data]([Id])
)

CREATE TABLE [dbo].[amendment]
(
	[Id] INT NOT NULL IDENTITY,
	[Type] INT NOT NULL,
	[Amendment_start] DATETIME NOT NULL,
	[Amendment_end] DATETIME NOT NULL,
	[Amendment_hours] INT NOT NULL,
	[Id_User_payroll_data] INT NOT NULL,
	CONSTRAINT PK_Amendment PRIMARY KEY ([Id]),
	CONSTRAINT FK_Amendment_User_Payroll_Data FOREIGN KEY ([Id_User_payroll_data]) REFERENCES [user_payroll_data]([Id])
)

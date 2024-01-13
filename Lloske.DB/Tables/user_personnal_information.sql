CREATE TABLE [dbo].[user_personnal_information]
(
	[Id] INT NOT NULL IDENTITY,
	[Firstname] NVARCHAR(100) NOT NULL ,
	[Lastname] NVARCHAR(100) NOT NULL,
	[Payroll_identity] NVARCHAR(100),
	[Email] NVARCHAR(125) NOT NULL,
	[Phone] NVARCHAR(30),
	[Is_in_employee_registrer] BIT DEFAULT 1,
	[Is_archived] BIT DEFAULT 0,
	[Password_hash] NVARCHAR(max),
	[Password_salt] NVARCHAR(max),
	CONSTRAINT PK_User_personnal_information PRIMARY KEY ([Id]),
	CONSTRAINT UK_User__Email UNIQUE ([Email]), -- UNIQUE permet de mettre une contrainte pour que le nom soit unique. On la nomme en commençant par UK
)

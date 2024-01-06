--Permet de supprimer le contenu des tables. Attention il faut le faire dans l'ordre des ForeignKeys
DELETE FROM [MM_job_position_workplaces];
DELETE FROM [MM_organization_user];
DELETE FROM [MM_workplaces_user];
DELETE FROM [workplaces_job_position];
DELETE FROM [event];
DELETE FROM [workplaces];
DELETE FROM [amendment];
DELETE FROM [user_contract_information];
DELETE FROM [user_human_ressources_information];
DELETE FROM [user_payroll_data];
DELETE FROM [organizations];
DELETE FROM [user_personnal_information];
DELETE FROM [event_absence];
DELETE FROM [event_team];

SET IDENTITY_INSERT [user_personnal_information] ON;
INSERT INTO [user_personnal_information] ([Id], [Firstname], [Lastname], [Payroll_identity], [Email], [Phone], [Is_in_employee_registrer], [Is_archived], [Password_hash], [Password_salt])
	VALUES ( 1, 'Antoine', 'Tilman', '1', 'antoine_tilman@hotmail.com', '+32483458986', 1, 0, 'Test1234=', 'Test1234=');
SET IDENTITY_INSERT [user_personnal_information] OFF;
	 
SET IDENTITY_INSERT [user_contract_information] ON;
INSERT INTO [user_contract_information] ([Id], [Contract_type], [Employment_type], [Job_title], [Organization_entry_date], [Contract_start], [Probation_end_date], [Contract_end], [Status], [Professional_category], [Last_medical_checkup_date], [FK_id_user_personnal_information])
	VALUES ( 1, 1, 1, 'Gestionnaire Multifonction', '2017-01-01', '2017-01-01 06:00:00', '2017-04-01', '2017-09-01', 4, 4, '2017-01-01', 1);
SET IDENTITY_INSERT [user_contract_information] OFF;

SET IDENTITY_INSERT [user_human_ressources_information] ON;
INSERT INTO [user_human_ressources_information] ([Id], [Birthdate], [Birthplace], [Birthland], [Nationality], [Gender], [Address_street], [Adress_postal_code], [Adress_city], [Adress_country], [Iban], [Bic], [Social_security_number], [User_note], [FK_id_user_personnal_information])
	VALUES ( 1, '1990-02-22', 'Namur', 56, 56, 1, 'Rue Dewez 47', '5000', 'Namur', 56, 'BE01234567896789', 'BEBBGERC', '90022262072', 'Un mec top', 1);
SET IDENTITY_INSERT [user_human_ressources_information] OFF;

SET IDENTITY_INSERT [user_payroll_data] ON;
INSERT INTO [user_payroll_data] ([Id], [Work_time_measurement], [Maximum_contract_hours], [Id_user_personnal_information])
	VALUES ( 1, 1, 38, 1);
SET IDENTITY_INSERT [user_payroll_data] OFF;
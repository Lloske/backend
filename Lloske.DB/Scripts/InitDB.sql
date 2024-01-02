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


INSERT INTO [user_personnal_information] ([Id], [Firstname], [Lastname], [Payroll_identity], [Email], [Phone], [Is_in_employee_registrer], [Is_archived], [Password_hash], [Password_salt])
	VALUES ( NEWID(), 'Antoine', 'Tilman', 1, 'antoine_tilman@hotmail.com', '+32483458986', 1, 0, 'Test1234=', 'Test1234=');
	 
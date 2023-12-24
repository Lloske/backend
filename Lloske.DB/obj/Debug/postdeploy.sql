--Permet de supprimer le contenu des tables. Attention il faut le faire dans l'ordre des ForeignKeys

INSERT INTO [user_personnal_information] ([Id], [Firstname], [Lastname], [Email], [Password_hash])
	VALUES (NEWID(), 'Antoine', 'Tilman', 'antoine_tilman@hotmail.com', 'Test1234=');
GO

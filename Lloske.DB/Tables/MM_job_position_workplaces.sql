CREATE TABLE [dbo].[MM_job_position_workplaces]
(
	[Id] INT NOT NULL IDENTITY,
	[FK_PK_id_job_position] INT NOT NULL,
	[FK_PK_id_workplaces_user] INT NOT NULL,
	CONSTRAINT PK_MM_job_position_workplaces PRIMARY KEY ([FK_PK_id_job_position], [FK_PK_id_workplaces_user]),
	CONSTRAINT MM_job_position_workplaces_Workplaces_job_position FOREIGN KEY (FK_PK_id_job_position) REFERENCES [workplaces_job_position]([Id]),
	CONSTRAINT MM_job_position_workplaces_Workplaces_user FOREIGN KEY (FK_PK_id_workplaces_user) REFERENCES [workplaces_user]([Id]),
)

CREATE TABLE [dbo].[MM_job_position_workplaces]
(
    [FK_id_job_position] UNIQUEIDENTIFIER NOT NULL,
    [FK_id_workplace] UNIQUEIDENTIFIER NOT NULL,
    [FK_id_user_personnal_information] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_MM_job_position_workplaces PRIMARY KEY ([FK_id_job_position], [FK_id_workplace], [FK_id_user_personnal_information]),
    CONSTRAINT FK_MM_job_position_workplaces_job_position FOREIGN KEY (FK_id_job_position) REFERENCES [workplaces_job_position]([Id]),
    CONSTRAINT FK_MM_job_position_workplaces_workplace_user FOREIGN KEY (FK_id_workplace, FK_id_user_personnal_information) REFERENCES [MM_workplaces_user]([FK_id_workplace], [FK_id_user_personnal_information])
)

CREATE TABLE [dbo].[TaskUser]
(
[TaskId] bigint NOT NULL,
[UserId] bigint NOT NULL,
[ts] rowversion NOT NULL,
CONSTRAINT PK_TaskUser PRIMARY KEY (TaskId, UserId),
CONSTRAINT FK_TaskUser_User_UserId foreign key (UserId) references dbo.[User] (UserId),
CONSTRAINT FK_TaskUser_Task_TaskId foreign key (TaskId) references dbo.Task (TaskId)
)

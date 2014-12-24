CREATE TABLE [dbo].[Task] (
[TaskId] BIGINT IDENTITY (1, 1) NOT NULL,
[Subject] NVARCHAR (100) NOT NULL,
[StartOnDate] DATETIME2 (7) NULL,
[DueOnDate] DATETIME2 (7) NULL,
[CompletedOnDate] DATETIME2 (7) NULL,
[StatusId] BIGINT NOT NULL,
[CreatedOnDate] DATETIME2 (7) NOT NULL,
[CreatedByUserId] bigint NOT NULL,
[ts] rowversion NOT NULL,
CONSTRAINT PK_Task PRIMARY KEY CLUSTERED ([TaskId] ASC),
CONSTRAINT FK_Status_StatusId FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([StatusId]),
CONSTRAINT FK_User_UserId FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[User] ([UserId])
);
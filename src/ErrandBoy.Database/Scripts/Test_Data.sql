declare @statusId int,
	@taskId int,
	@userId int

if not exists (select * from [User] where Username = 'mlopez')
	INSERT into [dbo].[User] ([Firstname], [Lastname], [Username])
	VALUES (N'Mario', N'Lopez', N'mlopez')

if not exists (select * from [User] where Username = 'ckahn')
	INSERT into [dbo].[User] ([Firstname], [Lastname], [Username])
	VALUES (N'Chad', N'Kahn', N'ckahn')

if not exists (select * from [User] where Username = 'mmaria')
	INSERT into [dbo].[User] ([Firstname], [Lastname], [Username])
	VALUES (N'Mia', N'Maria', N'mmaria')

if not exists(select * from dbo.Task where Subject = 'Eat Cake Task 1')
begin
	select top 1 @statusId = StatusId from Status order by StatusId;
	select top 1 @userId = UserId from [User] order by UserId;

	insert into dbo.Task(Subject, StartDate, StatusId, CreatedDate, CreatedUserId)
	values('Eat Cake Task 1', getdate(), @statusId, getdate(), @userId);
	
	set @taskId = SCOPE_IDENTITY();
	
	INSERT [dbo].[TaskUser] ([TaskId], [UserId])
	VALUES (@taskId, @userId)
end
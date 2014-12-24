CREATE TABLE [dbo].[Status]
(
	[StatusId] BIGINT IDENTITY(1,1) NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Ordinal] INT NOT NULL, 
    [ts] ROWVERSION NOT NULL,
	CONSTRAINT [PK_Status] PRIMARY KEY ([StatusId])
)

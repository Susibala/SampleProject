CREATE TABLE [dbo].[tblBooks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BookId] VARCHAR(50) NULL, 
    [Name] VARCHAR(100) NULL, 
    [AuthorName] VARCHAR(100) NULL
)

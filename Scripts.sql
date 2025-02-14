CREATE TABLE [dbo].[DocumentChunks](
	[Id] [uniqueidentifier] NOT NULL,
	[DocumentId] [uniqueidentifier] NOT NULL,
	[Index] [int] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Embedding] [varbinary](8000) NOT NULL,
 CONSTRAINT [PK_DocumentChunks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) 
GO

CREATE TABLE [dbo].[Documents](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[CreationDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))
GO

ALTER TABLE [dbo].[DocumentChunks]  WITH CHECK ADD  CONSTRAINT [FK_DocumentChunks_Documents] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Documents] ([Id])
ON DELETE CASCADE
GO
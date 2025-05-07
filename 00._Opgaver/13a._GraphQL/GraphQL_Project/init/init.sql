-- Create DB
CREATE DATABASE [SampleDB];
GO

-- Use the DB
USE [SampleDB];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create 2 tables
CREATE TABLE [dbo].[Authors](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Authors] ADD  CONSTRAINT [DF_Authors_Id]  DEFAULT (newid()) FOR [Id]
GO

CREATE TABLE [dbo].[Books](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](250) NULL,
	[ReleaseYear] [int] NULL,
	[AuthorId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [DF_Books_Id]  DEFAULT (newid()) FOR [Id]
GO

---- Create relationship
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO

-- Insert sample data
INSERT INTO [dbo].[Authors] (Id, Name) VALUES
('e4f1c9a1-1f3a-4c5a-ae8b-5d0f1a9b5c21', 'J.K. Rowling'),
('b27c9dd7-4a65-4fa3-b0df-b1f5b774e10b', 'George R.R. Martin'),
('3f5070f2-e648-4424-b084-fd9e1c54fa6c', 'Haruki Murakami'),
('9a4a8f0e-fb93-4451-b4f2-16c70b935b2f', 'Chimamanda Ngozi Adichie');
GO

INSERT INTO [dbo].[Books] (Id, Title, ReleaseYear, AuthorId) VALUES
('1c52d9fa-3c7e-47be-8ea6-e6c99dca693a', 'Harry Potter and the Philosopher''s Stone', 1997, 'e4f1c9a1-1f3a-4c5a-ae8b-5d0f1a9b5c21'),
('b839a2cc-e68e-4ff1-9a15-0df4aa2a5e84', 'A Game of Thrones', 1996, 'b27c9dd7-4a65-4fa3-b0df-b1f5b774e10b'),
('d5f3c2fc-70f4-43d7-857c-3e37c80e2927', 'Norwegian Wood', 1987, '3f5070f2-e648-4424-b084-fd9e1c54fa6c'),
('63b67aaf-5f13-4bcb-88f2-15b76934f3a4', 'Half of a Yellow Sun', 2006, '9a4a8f0e-fb93-4451-b4f2-16c70b935b2f');
GO

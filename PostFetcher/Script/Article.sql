use master
if DB_ID('Post') is null
	create database post
use post
go
if OBJECT_ID('post.dbo.Image') is not null
	drop table [dbo].[Image]
go
if OBJECT_ID('post.dbo.Article') is not null
	drop table [dbo].[Article]
go
create table [dbo].[Article](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](4000) NULL,
	[Created] [datetime] NOT NULL,
	[Title] [nvarchar](4000) NULL,
	[Text] text NULL,
	CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED ([ID])
)
go
create table [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleID] [int]  not null,
	[Title] [nvarchar](4000) NULL,
	[File] image not null,
	CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED ([ID]),
	CONSTRAINT [FK_Image_Article] FOREIGN KEY ([ArticleID]) REFERENCES [dbo].[Article]([ID])
)
go
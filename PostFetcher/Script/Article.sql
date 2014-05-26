use master
if DB_ID('Post') is null
	create database post
go
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
	[Author] [nvarchar](100) NULL,
	[Link] [nvarchar](1000) NULL unique,
	[Section] [nvarchar](1000) NULL,
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
if exists(SELECT 1 FROM sys.fulltext_catalogs WHERE name = 'article_catalog')
	drop fulltext catalog article_catalog
go
CREATE FULLTEXT CATALOG article_catalog;
go
if exists(SELECT * FROM sys.fulltext_indexes WHERE object_id=object_id('Article'))
	drop fulltext index on Article
go
CREATE FULLTEXT INDEX ON Article
(
    [Text] Language 1049,
    [Title] Language 1049
)
KEY INDEX [PK_Article] ON article_catalog
WITH CHANGE_TRACKING AUTO
go
if OBJECT_ID('FullTextSearch') is not null
	drop function FullTextSearch
go
create function FullTextSearch(@keyword nvarchar(4000))
returns @RankedArticle table(
	[ID] [int] NOT NULL,
	[Author] [nvarchar](100) NULL,
	[Link] [nvarchar](1000) NULL,
	[Section] [nvarchar](1000) NULL,
	[Created] [datetime] NOT NULL,
	[Title] [nvarchar](4000) NULL,
	[Text] text NULL,
	[rank] int not null
)
as begin
	insert @RankedArticle 
		select a.*, rank from Article a join containstable(Article,([Text],[Title]),@keyword) r on a.id=r.[key]
	return
end
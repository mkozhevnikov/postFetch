use master
if DB_ID('Post') is null
	create database post
use post
go
if OBJECT_ID('post.dbo.Contact') is not null
	drop table [dbo].[Person]
go
if OBJECT_ID('post.dbo.Person') is not null
	drop table [dbo].[Person]
go
create table [dbo].[Person](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](4000) NULL,
	[FirstName] [nvarchar](4000) NULL,
	[MiddleName] [nvarchar](4000) NULL,
	[BirthDate] [datetime] NOT NULL,
	[Sex] [int] NOT NULL,
	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([ID])
)
go
create table [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] not null, 
	[Email] [nvarchar](4000) NULL,
	[Phone] [nvarchar](4000) NULL,
	[Address] [nvarchar](4000) NULL,
	CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([ID]),
	CONSTRAINT [FK_Contact_Person] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person]([ID])
)
go

USE [master]
GO
/****** Object:  Database [FirstProject]    Script Date: 9/16/2017 2:49:31 PM ******/
CREATE DATABASE [FirstProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FirstProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FirstProject.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FirstProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FirstProject_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FirstProject] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FirstProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FirstProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FirstProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FirstProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FirstProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FirstProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [FirstProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FirstProject] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FirstProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FirstProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FirstProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FirstProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FirstProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FirstProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FirstProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FirstProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FirstProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FirstProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FirstProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FirstProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FirstProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FirstProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FirstProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FirstProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FirstProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FirstProject] SET  MULTI_USER 
GO
ALTER DATABASE [FirstProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FirstProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FirstProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FirstProject] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FirstProject]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 9/16/2017 2:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/16/2017 2:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kateqoriya_name] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Kateqoriya] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RelCatAndSor]    Script Date: 9/16/2017 2:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelCatAndSor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kateqoriya_id] [int] NOT NULL,
	[topic_id] [int] NOT NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Review]    Script Date: 9/16/2017 2:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[liked] [tinyint] NOT NULL,
	[user_id] [int] NOT NULL,
	[topic_id] [int] NOT NULL,
	[dislike] [tinyint] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sources]    Script Date: 9/16/2017 2:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sources](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nchar](255) NOT NULL,
	[text] [text] NOT NULL,
	[date] [datetime] NOT NULL,
	[read_count] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[kateqoriya_id] [int] NOT NULL,
	[allow] [bit] NOT NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/16/2017 2:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nchar](50) NOT NULL,
	[email] [nchar](100) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[reytinq] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[RelCatAndSor]  WITH CHECK ADD  CONSTRAINT [FK_RelKatAndTop_Kateqoriya] FOREIGN KEY([kateqoriya_id])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[RelCatAndSor] CHECK CONSTRAINT [FK_RelKatAndTop_Kateqoriya]
GO
ALTER TABLE [dbo].[RelCatAndSor]  WITH CHECK ADD  CONSTRAINT [FK_RelKatAndTop_Topic] FOREIGN KEY([topic_id])
REFERENCES [dbo].[Sources] ([id])
GO
ALTER TABLE [dbo].[RelCatAndSor] CHECK CONSTRAINT [FK_RelKatAndTop_Topic]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Topic] FOREIGN KEY([topic_id])
REFERENCES [dbo].[Sources] ([id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Topic]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Users]
GO
ALTER TABLE [dbo].[Sources]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Sources] CHECK CONSTRAINT [FK_Topic_Users]
GO
USE [master]
GO
ALTER DATABASE [FirstProject] SET  READ_WRITE 
GO

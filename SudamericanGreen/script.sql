USE [master]
GO
/****** Object:  Database [evalucionesTecnicas]    Script Date: 27/8/2020 12:00:11 a. m. ******/
CREATE DATABASE [evalucionesTecnicas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'evalucionesTecnicas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS02\MSSQL\DATA\evalucionesTecnicas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'evalucionesTecnicas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS02\MSSQL\DATA\evalucionesTecnicas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [evalucionesTecnicas] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [evalucionesTecnicas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [evalucionesTecnicas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET ARITHABORT OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [evalucionesTecnicas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [evalucionesTecnicas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [evalucionesTecnicas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [evalucionesTecnicas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [evalucionesTecnicas] SET  MULTI_USER 
GO
ALTER DATABASE [evalucionesTecnicas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [evalucionesTecnicas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [evalucionesTecnicas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [evalucionesTecnicas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [evalucionesTecnicas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [evalucionesTecnicas] SET QUERY_STORE = OFF
GO
USE [evalucionesTecnicas]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [evalucionesTecnicas]
GO
/****** Object:  User [Transx]    Script Date: 27/8/2020 12:00:11 a. m. ******/
CREATE USER [Transx] FOR LOGIN [Transx] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Activo] [bit] NULL,
	[DVH] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[ID_EventoBitacora] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[Fecha] [nvarchar](50) NOT NULL,
	[Hora] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [nvarchar](150) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[ID_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[ID_Direccion] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[ID_Direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVV]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVV](
	[ID_DVV] [int] IDENTITY(1,1) NOT NULL,
	[Tabla] [nvarchar](50) NOT NULL,
	[DVV] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[ID_DVV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[ID_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [nvarchar](50) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[ID_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventoBitacora]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventoBitacora](
	[ID_EventoBitacora] [int] IDENTITY(1,1) NOT NULL,
	[EventoBitacora] [nvarchar](150) NULL,
 CONSTRAINT [PK_EventoBitacora] PRIMARY KEY CLUSTERED 
(
	[ID_EventoBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gerencia]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gerencia](
	[Id_Gerencia] [int] IDENTITY(1,1) NOT NULL,
	[Gerencia] [nvarchar](100) NOT NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Gerencia] PRIMARY KEY CLUSTERED 
(
	[Id_Gerencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Jefatura]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jefatura](
	[Id_Jefatura] [int] IDENTITY(1,1) NOT NULL,
	[Jefatura] [nvarchar](100) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Jefatura] PRIMARY KEY CLUSTERED 
(
	[Id_Jefatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NivelPregunta]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelPregunta](
	[ID_Nivel] [int] IDENTITY(1,1) NOT NULL,
	[Nivel] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_NivelPregunta] PRIMARY KEY CLUSTERED 
(
	[ID_Nivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PDF]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PDF](
	[Id] [int] NOT NULL,
	[path] [nvarchar](150) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pregunta]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pregunta](
	[ID_Pregunta] [int] IDENTITY(1,1) NOT NULL,
	[Pregunta] [nvarchar](max) NOT NULL,
	[Imagen] [nvarchar](100) NULL,
	[ID_Nivel] [int] NOT NULL,
	[Activo] [bit] NULL,
	[ID_TipoPregunta] [int] NULL,
	[SubPregunta] [bit] NULL,
 CONSTRAINT [PK_Pregunta] PRIMARY KEY CLUSTERED 
(
	[ID_Pregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PreguntaCategoria]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaCategoria](
	[ID_Pregunta] [int] NOT NULL,
	[ID_Categoria] [int] NOT NULL,
 CONSTRAINT [PK_PreguntaCategoria] PRIMARY KEY CLUSTERED 
(
	[ID_Pregunta] ASC,
	[ID_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PreguntaSubPregunta]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntaSubPregunta](
	[ID_Pregunta] [int] NOT NULL,
	[ID_SubPregunta] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Respuesta]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuesta](
	[ID_Respuesta] [int] IDENTITY(1,1) NOT NULL,
	[Respuesta] [nvarchar](max) NULL,
	[Orden] [int] NULL,
	[Correcta] [bit] NULL,
	[ID_Pregunta] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Respuesta] PRIMARY KEY CLUSTERED 
(
	[ID_Respuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sector]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sector](
	[Id_Sector] [int] IDENTITY(1,1) NOT NULL,
	[Sector] [nvarchar](100) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Sector] PRIMARY KEY CLUSTERED 
(
	[Id_Sector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sede]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sede](
	[Id_Sede] [int] IDENTITY(1,1) NOT NULL,
	[Sede] [nvarchar](50) NOT NULL,
	[Codigo] [nvarchar](50) NULL,
	[Empresa] [int] NOT NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Sede] PRIMARY KEY CLUSTERED 
(
	[Id_Sede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubPregunta]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubPregunta](
	[ID_Pregunta] [int] NULL,
	[ID_SubPregunta] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoPregunta]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPregunta](
	[ID_TipoPregunta] [int] IDENTITY(1,1) NOT NULL,
	[TipoPregunta] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoPregunta] PRIMARY KEY CLUSTERED 
(
	[ID_TipoPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NULL,
	[DVH] [nvarchar](max) NULL,
	[Activo] [bit] NULL,
	[Bloqueado] [bit] NULL,
	[CantidadIntentos] [int] NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioParaExamen]    Script Date: 27/8/2020 12:00:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioParaExamen](
	[Id] [int] NOT NULL,
	[Id_Sede] [int] NOT NULL,
	[Id_Direccion] [int] NOT NULL,
	[Id_Gerencia] [int] NOT NULL,
	[Id_Jefatura] [int] NOT NULL,
	[Id_Sector] [int] NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Activo] [bit] NULL
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Activo]) VALUES (N'1', N'Administrador', 1)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Activo]) VALUES (N'2', N'CrearPregunta', 1)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Activo]) VALUES (N'3', N'Examen', 1)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Activo]) VALUES (N'4', N'RRHH', 1)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, N'1')
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (4, 5, 1, N'24/8/2020', N'18:52')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (5, 4, 1, N'24/8/2020', N'19:01')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (6, 8, 1, N'24/8/2020', N'19:07')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (7, 8, 1, N'24/8/2020', N'19:08')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (8, 5, 1, N'24/8/2020', N'19:09')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (9, 5, 1, N'24/8/2020', N'19:16')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1002, 5, 1, N'26/08/2020', N'12:14')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1003, 5, 1, N'26/08/2020', N'12:14')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1004, 5, 1, N'26/08/2020', N'12:14')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1005, 5, 1, N'26/08/2020', N'12:14')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1006, 5, 1, N'26/08/2020', N'12:17')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1007, 5, 1, N'26/08/2020', N'12:18')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1008, 5, 1, N'26/08/2020', N'12:19')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1009, 5, 1, N'26/08/2020', N'12:21')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1010, 5, 1, N'26/08/2020', N'12:27')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1011, 5, 1, N'26/08/2020', N'12:31')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1012, 5, 1, N'26/08/2020', N'14:01')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1013, 5, 1, N'26/08/2020', N'14:09')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1014, 5, 1, N'26/08/2020', N'14:16')
INSERT [dbo].[Bitacora] ([ID_Bitacora], [ID_EventoBitacora], [Id], [Fecha], [Hora]) VALUES (1015, 5, 1, N'26/08/2020', N'15:13')
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([ID_Categoria], [Categoria], [Descripcion], [Activo]) VALUES (1, N'IngresoTecnica', N'Pregunta para examen de ingresantes de la Dirección Técnica', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Direccion] ON 

INSERT [dbo].[Direccion] ([ID_Direccion], [Direccion], [Activo]) VALUES (1, N'Tecnica', 1)
INSERT [dbo].[Direccion] ([ID_Direccion], [Direccion], [Activo]) VALUES (2, N'RRHH', 1)
INSERT [dbo].[Direccion] ([ID_Direccion], [Direccion], [Activo]) VALUES (3, N'DAF', 1)
INSERT [dbo].[Direccion] ([ID_Direccion], [Direccion], [Activo]) VALUES (4, N'DIR', 1)
INSERT [dbo].[Direccion] ([ID_Direccion], [Direccion], [Activo]) VALUES (5, N'DALEG', 1)
INSERT [dbo].[Direccion] ([ID_Direccion], [Direccion], [Activo]) VALUES (6, N'Sistemas?', 0)
SET IDENTITY_INSERT [dbo].[Direccion] OFF
SET IDENTITY_INSERT [dbo].[DVV] ON 

INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (1, N'Usuario', N'6B8BDC6FF7D6FA91A5C4E0A4B55E4982B90DAD2EB9369D8BF607CB217DDEB719C6940A9EAF79BEDBFBA598AD2FCDA3EFE8BF16AC8D543251613B7432D4D539F6')
SET IDENTITY_INSERT [dbo].[DVV] OFF
SET IDENTITY_INSERT [dbo].[Empresa] ON 

INSERT [dbo].[Empresa] ([ID_Empresa], [Empresa], [Activo]) VALUES (1, N'Transba', 1)
INSERT [dbo].[Empresa] ([ID_Empresa], [Empresa], [Activo]) VALUES (2, N'Transener', 1)
INSERT [dbo].[Empresa] ([ID_Empresa], [Empresa], [Activo]) VALUES (1002, N'Transpass', 0)
SET IDENTITY_INSERT [dbo].[Empresa] OFF
SET IDENTITY_INSERT [dbo].[EventoBitacora] ON 

INSERT [dbo].[EventoBitacora] ([ID_EventoBitacora], [EventoBitacora]) VALUES (1, N'La cuenta esta Bloqueada')
INSERT [dbo].[EventoBitacora] ([ID_EventoBitacora], [EventoBitacora]) VALUES (2, N'Error Critico V')
INSERT [dbo].[EventoBitacora] ([ID_EventoBitacora], [EventoBitacora]) VALUES (3, N'Error Critico H')
INSERT [dbo].[EventoBitacora] ([ID_EventoBitacora], [EventoBitacora]) VALUES (4, N'Usuario o Contraseña Invalido')
INSERT [dbo].[EventoBitacora] ([ID_EventoBitacora], [EventoBitacora]) VALUES (5, N'Logueado')
INSERT [dbo].[EventoBitacora] ([ID_EventoBitacora], [EventoBitacora]) VALUES (6, N'Deslogueado')
INSERT [dbo].[EventoBitacora] ([ID_EventoBitacora], [EventoBitacora]) VALUES (7, N'Creacion de Cuenta')
INSERT [dbo].[EventoBitacora] ([ID_EventoBitacora], [EventoBitacora]) VALUES (8, N'Captcha invalido')
INSERT [dbo].[EventoBitacora] ([ID_EventoBitacora], [EventoBitacora]) VALUES (9, N'Bloqueada por fin de examen')
SET IDENTITY_INSERT [dbo].[EventoBitacora] OFF
SET IDENTITY_INSERT [dbo].[Gerencia] ON 

INSERT [dbo].[Gerencia] ([Id_Gerencia], [Gerencia], [Activo]) VALUES (1, N'TRN', 1)
INSERT [dbo].[Gerencia] ([Id_Gerencia], [Gerencia], [Activo]) VALUES (2, N'TRS', 1)
INSERT [dbo].[Gerencia] ([Id_Gerencia], [Gerencia], [Activo]) VALUES (3, N'TRM', 1)
INSERT [dbo].[Gerencia] ([Id_Gerencia], [Gerencia], [Activo]) VALUES (4, N'TBN', 1)
INSERT [dbo].[Gerencia] ([Id_Gerencia], [Gerencia], [Activo]) VALUES (5, N'TBS', 1)
INSERT [dbo].[Gerencia] ([Id_Gerencia], [Gerencia], [Activo]) VALUES (6, N'PLANIFICACION Y OPERACIÓN DE RED', 1)
SET IDENTITY_INSERT [dbo].[Gerencia] OFF
SET IDENTITY_INSERT [dbo].[Jefatura] ON 

INSERT [dbo].[Jefatura] ([Id_Jefatura], [Jefatura], [Activo]) VALUES (1, N'Protecciones, Control y
Comunicaciones', 1)
INSERT [dbo].[Jefatura] ([Id_Jefatura], [Jefatura], [Activo]) VALUES (2, N'COT', 1)
INSERT [dbo].[Jefatura] ([Id_Jefatura], [Jefatura], [Activo]) VALUES (3, N'COTDT', 1)
INSERT [dbo].[Jefatura] ([Id_Jefatura], [Jefatura], [Activo]) VALUES (4, N'Estaciones', 1)
INSERT [dbo].[Jefatura] ([Id_Jefatura], [Jefatura], [Activo]) VALUES (5, N'Mantenimiento Estaciones', 1)
INSERT [dbo].[Jefatura] ([Id_Jefatura], [Jefatura], [Activo]) VALUES (6, N'Lineas', 1)
INSERT [dbo].[Jefatura] ([Id_Jefatura], [Jefatura], [Activo]) VALUES (7, N'Proteccioneszz', 0)
SET IDENTITY_INSERT [dbo].[Jefatura] OFF
SET IDENTITY_INSERT [dbo].[NivelPregunta] ON 

INSERT [dbo].[NivelPregunta] ([ID_Nivel], [Nivel], [Activo]) VALUES (1, N'Facil', 1)
INSERT [dbo].[NivelPregunta] ([ID_Nivel], [Nivel], [Activo]) VALUES (2, N'Dificil', 1)
INSERT [dbo].[NivelPregunta] ([ID_Nivel], [Nivel], [Activo]) VALUES (3, N'Medio', 1)
SET IDENTITY_INSERT [dbo].[NivelPregunta] OFF
INSERT [dbo].[PDF] ([Id], [path]) VALUES (1, N'~/PDF/andres.benitez@transener.com.ar.pdf')
SET IDENTITY_INSERT [dbo].[Pregunta] ON 

INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (1, N'En un conductor de un largo determinado L, a medida que aumenta la sección, la resistencia medida en sus extremos:', N'Sin Imagen', 1, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (2, N'Supongamos que tenemos dos probetas de las mismas dimensiones, una de cobre y una de aluminio, la resistencia de la probeta de cobre respecto la de aluminio va a ser	 ', N'Sin Imagen', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (3, N'Qué valor de los representados a continuación es el mayor', N'Sin Imagen', 1, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4, N'Resuelva el siguiente circuito y seleccione la solución correcta:', N'/Imagenes/Pregunta4.png', 3, 1, 3, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5, N'Corriente por la resistencia de 12 ohms', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (6, N'Tensión en la resistencia de 7 ohms', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (7, N'Potencia total que entrega la fuente', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (8, N'Indique las potencias en MW y MVAR que faltan en el diagrama para balancear el circuito, considerar que el signo negativo es entrante a la barra:', N'/Imagenes/Pregunta5.png', 3, 1, 3, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (1009, N'MW:', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (2003, N' MVAR', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (3003, N'Indique los valores de Tensión de pico, y período para una forma de onda senoidal de 220 V eficaces, 50 Hz:', N'Sin Imagen', 3, 1, 3, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (3004, N'V pico', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (3005, N'Periodo', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4003, N'Resuelva el siguiente circuito RLC, siendo R=10 Ohms, L=200mH, C=100uF, VCA=220 <0°, 50 Hz', N'/Imagenes/pregunta7.jpg', 2, 1, 3, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4004, N'Impedancia', N'Sin Imagen', 2, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4006, N'Corriente (sólo magnitud)', N'Sin Imagen', 2, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4007, N'Resuelva el siguiente triángulo de potencias siendo S=10 MVA y φ= 60°', N'/Imagenes/pregunta8.jpg', 3, 1, 3, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4008, N'P=', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4009, N'Q=', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4010, N'Para el siguiente circuito indique la relación correcta entre la corriente de fase (IF) y la corriente de línea (IL):', N'/Imagenes/pregunta9.jpg', 3, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4011, N'Según el siguiente plano, que contactores deben excitarse para que el motor arranque en configuración estrella:', N'/Imagenes/pregunta10.jpg', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4012, N'El aceite de un transformador, cumple las funciones de:', N'Sin Imagen', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4013, N'Que tipo de sistema de enfriamiento corresponde al siguiente diagrama:', N'/Imagenes/pregunta12.jpg', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4014, N'Cuál de las siguientes opciones menciona únicamente protecciones propias de transformadores de AT', N'Sin Imagen', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4015, N'Que la clase de precisión de un TI sea 0,2S significa que:', N'Sin Imagen', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4016, N'Marque las condiciones a la cual puede operar un interruptor de potencia:', N'Sin Imagen', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4017, N'El medio físico por el cual se transmiten las señales de microondas es:', N'Sin Imagen', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4018, N'El secundario de un Transformador de tensión:', N'Sin Imagen', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4019, N'Dado un transformador trifásico 132/33 kV, 45 MVA, cual es la ecuación correcta para calcular la corriente nominal secundaria.', N'Sin Imagen', 3, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4020, N'Se denomina “traba” en un aparato eléctrico a:', N'Sin Imagen', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4021, N'Ordene en forma correcta los enunciados correspondientes a la Reglas de oro:', N'Sin Imagen', 2, 1, 2, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4022, N'borrar', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4023, N'borrar', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (4024, N'borrarSiOSNoso', N'Sin Imagen', 3, 0, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5003, N'Si desea medir magnitudes grandes (de corriente y tensión) utilizaría', N'Sin Imagen', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5004, N'Cuál valor de los representados a continuación es el mayor', N'Sin Imagen', 1, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5005, N'Resuelva el siguiente circuito y seleccione la solución correcta ', N'/Imagenes/pregunta21.jpg', 3, 1, 3, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5006, N'Resistencia de 6 Ohms', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5007, N'Resistencia de 6 Ohms', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5008, N'Resistencia de 3 Ohms', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5009, N'La Potencia total que entrega la fuente', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5010, N'Para la imagen 4 resuelva el siguiente triángulo de potencias siendo S=20 MVA y φ= 60°', N'/Imagenes/pregunta23.jpg', 3, 1, 3, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5011, N'Valor de Q', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (5012, N'Valor de P', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (6003, N'¿Que tipo de sistema de enfriamiento corresponde al siguiente diagrama de la imagen?', N'\imagenes\imagen8.jpg', 2, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (6004, N'En un conductor de un largo determinado L, a medida que disminuye la sección, la resistencia medida en sus extremos:', N'Sin imagen', 1, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (6005, N'Supongamos que tenemos dos probetas de las mismas dimensiones, una de cobre y una de aluminio, la resistencia de la probeta de cobre respecto la de aluminio va a ser:', N'Sin imagen', 1, 0, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (6006, N'¿Cuál valor es el mayor?', N'Sin imagen', 1, 1, 1, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (6007, N'Resuelva el siguiente circuito e indique la solución correcta ', N'Sin imagen', 3, 1, 3, 0)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (6008, N'corriente por la resistencia de 7 Ohms', N'Sin Imagen', 3, 1, 3, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta], [SubPregunta]) VALUES (6009, N' tension por la resistencia de 4 Ohms', N'Sin Imagen', 3, 1, 3, 1)
SET IDENTITY_INSERT [dbo].[Pregunta] OFF
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (1, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (2, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (3, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (8, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (1009, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (2003, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (3003, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (3004, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (3005, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4003, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4004, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4006, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4007, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4008, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4009, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4010, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4011, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4012, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4013, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4014, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4015, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4016, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4017, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4018, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4019, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4020, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4021, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4024, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5003, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5004, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5005, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5006, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5008, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5009, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5010, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5011, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5012, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (6003, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (6004, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (6005, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (6006, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (6007, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (6008, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (6009, 1)
SET IDENTITY_INSERT [dbo].[Respuesta] ON 

INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (1, N'0.7 A', NULL, 1, 5, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2, N'1.3 A', NULL, 0, 5, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3, N'2 A', NULL, 0, 5, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4, N'7 V', NULL, 0, 6, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5, N'20 V', NULL, 0, 6, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (6, N'29 V', NULL, 1, 6, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (7, N'208 W', NULL, 1, 7, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (8, N'51 W', NULL, 0, 7, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (9, N'500 W', NULL, 0, 7, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (1002, N'-5', NULL, 1, 1009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (1003, N'5', NULL, 0, 1009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (1004, N'10', NULL, 0, 1009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (1005, N'-10', NULL, 0, 1009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (1006, N'5', NULL, 1, 2003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (1007, N'10', NULL, 0, 2003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (1008, N'-5', NULL, 0, 2003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (1009, N'-10', NULL, 0, 2003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2002, N'311 v', NULL, 1, 3004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2003, N'220 V', NULL, 0, 3004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2004, N'380 V', NULL, 0, 3004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2005, N'0,02 Seg', NULL, 1, 3005, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2006, N'50 Seg', NULL, 0, 3005, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2007, N'1 Seg', NULL, 0, 3005, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2008, N'Es menor', NULL, 1, 1, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2009, N'Es mayor', NULL, 0, 1, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2010, N'No varía con la sección', NULL, 0, 1, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2011, N'NS/NC', NULL, 0, 1, 0)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2012, N'Es menor', NULL, 1, 2, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2013, N'Es mayor', NULL, 0, 2, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2014, N'Es igual', NULL, 0, 2, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2015, N'5 GΩ', NULL, 1, 3, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2016, N'100 KΩ', NULL, 0, 3, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (2017, N'50000 Ω', NULL, 0, 3, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3002, N'32.5 <72°', NULL, 1, 4004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3003, N'10.5 < 30°', NULL, 0, 4004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3004, N'10 <0°', NULL, 0, 4004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3005, N'6.8 A', NULL, 1, 4006, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3006, N'7.9 A', NULL, 0, 4006, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3007, N'5 A ', NULL, 0, 4006, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3008, N'5MW', NULL, 1, 4008, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3009, N'10MW', NULL, 0, 4008, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3010, N'15MW', NULL, 0, 4008, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3011, N'5MVAR', NULL, 1, 4009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3012, N'10 MVAR', NULL, 0, 4009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3013, N'15MVAR', NULL, 0, 4009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3014, N'IF= √3 IL', NULL, 0, 4010, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3015, N'IL= IF', NULL, 1, 4010, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3016, N'IL= √3 IF', NULL, 0, 4010, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3017, N'IL= 3 IF', NULL, 0, 4010, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3018, N'F1', NULL, 0, 4011, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3019, N'Q1', NULL, 0, 4011, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3020, N'KM1', NULL, 1, 4011, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3021, N'KM2', NULL, 0, 4011, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3022, N'KM3', NULL, 1, 4011, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3023, N'Refrigerar', NULL, 1, 4012, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3024, N'Aislar', NULL, 1, 4012, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3025, N'Hidratar', NULL, 0, 4012, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3026, N'Suspender', NULL, 0, 4012, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3027, N'Hidrogenar', NULL, 0, 4012, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3028, N'OFAF', NULL, 0, 4013, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3029, N'ODAF', NULL, 0, 4013, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3030, N'ONAN', NULL, 1, 4013, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3031, N'OTAN', NULL, 0, 4013, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3032, N'OLAN', NULL, 0, 4013, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3033, N'Contador de descargas, Relé Buchholz, Protección diferencial', NULL, 0, 4014, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3034, N'Contador de descargas, Relé Buchholz, Protección diferencial', NULL, 0, 4014, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3035, N'Relé Buchholz, Imagen térmica, Alivio de presión', NULL, 1, 4014, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3036, N'comúnmente se utiliza para protección con un error de 20% en el rango de 20% a 120% de carga', NULL, 0, 4015, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3037, N'comúnmente se utiliza para medición con un error de 20% en el rango de 20% a 120% de carga', NULL, 1, 4015, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3038, N'comúnmente se utiliza para protección con un error de 20% en el rango de 100% a 120% de carga', NULL, 0, 4015, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3039, N'Sin carga', NULL, 1, 4016, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3040, N'Con carga', NULL, 1, 4016, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3041, N'Con corrientes de falla', NULL, 1, 4016, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3042, N'Fibra Óptica', NULL, 0, 4017, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3043, N'Aire', NULL, 1, 4017, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3044, N'Conductores de potencia', NULL, 0, 4017, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3045, N'Cablecanal', NULL, 0, 4017, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3046, N'Nunca debe quedar abierto', NULL, 1, 4018, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3047, N'Nunca debe quedar cerrado', NULL, 0, 4018, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3048, N'Es indistinto', NULL, 0, 4018, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3049, N'Iprim = 45 MVA / ((√3) * 132 kV)', NULL, 0, 4019, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3050, N'Iprim = 132 kV / ((√3) * 45 MVA)', NULL, 0, 4019, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3051, N'Iprim = 45 MVA / ((√3) * 33 kV)', NULL, 1, 4019, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3052, N'Iprim = 33 kV / ((√3) * 45 MVA)', NULL, 0, 4019, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3053, N'el conjunto de operaciones tendientes a imposibilitar el accionamiento, eliminando las fuentes de energía que produce dicho accionamiento.', NULL, 0, 4020, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3054, N'es el conjunto de acciones tendientes a incluir un dispositivo ajeno al equipo, que se coloca y fija con candado.', NULL, 1, 4020, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3055, N'el conjunto de operaciones que se realizan para retirar un elemento del equipo para asegurar la traba del accionamiento.', NULL, 0, 4020, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3056, N'Apertura', 1, NULL, 4021, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3057, N'bloqueo y traba', 2, NULL, 4021, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3058, N'Verificación de ausencia de tensión', 3, NULL, 4021, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3059, N'Puesta a tierra en cortocircuito', 4, NULL, 4021, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (3060, N'Señalización y delimitación del área de trabajo.', 5, NULL, 4021, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4002, N'Transformadores de medida', NULL, 1, 5003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4003, N'Descargadores', NULL, 0, 5003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4004, N'Bobinas de onda portadora', NULL, 0, 5003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4005, N'1 MΩ', NULL, 1, 5004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4006, N'5000 Ω', NULL, 0, 5004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4007, N'900 KΩ', NULL, 0, 5004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4008, N'1.38 A', NULL, 1, 5006, 1)
GO
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4009, N'0.7 A', NULL, 0, 5006, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4010, N'2 A', NULL, 0, 5006, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4011, N'12.5 V', NULL, 1, 5008, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4012, N'20 V', NULL, 0, 5008, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4013, N'29 V', NULL, 0, 5008, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4014, N'208 W', NULL, 1, 5009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4015, N'51 W', NULL, 0, 5009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4016, N'500 W', NULL, 0, 5009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4017, N'17,32 MVAR', NULL, 1, 5011, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4018, N'5,15 MVAR', NULL, 0, 5011, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4019, N'8,86 MVAR', NULL, 0, 5011, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4020, N'10MW', NULL, 1, 5012, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4021, N'5MW', NULL, 0, 5012, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (4022, N'15MW', NULL, 0, 5012, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5002, N'OFAF', NULL, 1, 6003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5003, N'ODAF', NULL, 0, 6003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5004, N'ONAN', NULL, 0, 6003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5005, N'OLAN', NULL, 0, 6003, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5006, N'Es mayor', NULL, 1, 6004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5007, N'Es menor', NULL, 0, 6004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5008, N'No varía con la sección', NULL, 0, 6004, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5009, N'1.000.000 Ω', NULL, 1, 6006, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5010, N'900 KΩ', NULL, 0, 6006, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5011, N'5000 Ω', NULL, 0, 6006, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5012, N'4.16 A', NULL, 1, 6008, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5013, N'1.38 A', NULL, 0, 6008, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5014, N'0.7 A', NULL, 0, 6008, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5015, N'8.32 V', NULL, 1, 6009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5016, N'29 V', NULL, 0, 6009, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5017, N'12.5 V', NULL, 0, 6009, 1)
SET IDENTITY_INSERT [dbo].[Respuesta] OFF
SET IDENTITY_INSERT [dbo].[Sector] ON 

INSERT [dbo].[Sector] ([Id_Sector], [Sector], [Activo]) VALUES (1, N'Protecciones', 1)
INSERT [dbo].[Sector] ([Id_Sector], [Sector], [Activo]) VALUES (2, N'Control', 1)
INSERT [dbo].[Sector] ([Id_Sector], [Sector], [Activo]) VALUES (3, N'Mediciones', 1)
INSERT [dbo].[Sector] ([Id_Sector], [Sector], [Activo]) VALUES (4, N'Comunicaciones', 1)
INSERT [dbo].[Sector] ([Id_Sector], [Sector], [Activo]) VALUES (5, N'Sector??', 0)
SET IDENTITY_INSERT [dbo].[Sector] OFF
SET IDENTITY_INSERT [dbo].[Sede] ON 

INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (1, N'San Antonio de Areco ', N'AA ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (2, N'Arrecifes ', N'AS ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (3, N'Baradero ', N'BD ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (4, N'Bragado ', N'BG ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (5, N'Barker ', N'BK ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (6, N'Balcarce ', N'BL ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (7, N'Brandsen ', N'BRA ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (8, N'ahía Blanca Urbana ', N'BU ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (9, N'Chacabuco ', N'CB ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (10, N'Chacabuco Industrial ', N'CD ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (11, N'Coronel Pringles ', N'CF ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (12, N'Coronel Dorrego ', N'CG ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (13, N'Chañares ', N'CH ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (14, N'Chivilcoy ', N'CI ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (15, N'Carlos Casares ', N'CJ ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (16, N'Campana 132 kV ', N'CM ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (17, N'Colón ', N'CN ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (18, N'Campana Tres ', N'CP ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (19, N'Coronel Rosales ', N'CR ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (20, N'Capitán Sarmiento ', N'CT ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (21, N'Chascomús ', N'CU ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (22, N'Calera Avellaneda ', N'CV ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (23, N'Coronel Suárez ', N'CZ ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (24, N'Dolores ', N'DO ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (25, N'ESSO ', N'ES ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (26, N'Gonzáles Chaves ', N'GC ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (27, N'General Madariaga ', N'GD ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (28, N'General Villegas ', N'GVI ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (29, N'IMSA ', N'IM ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (30, N'Ingeniero White ', N'IW ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (31, N'Junín ', N'JU ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (32, N'Laprida ', N'LA ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (33, N'Luján Dos ', N'LD ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (34, N'Las Flores ', N'LF ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (35, N'Lincoln ', N'LI ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (36, N'Luján ', N'LJ ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (37, N'Las Armas ', N'LM ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (38, N'Loma Negra ', N'LN ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (39, N'Las Toninas ', N'LO ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (40, N'La Plata ', N'LP ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (41, N'Las Palmas ', N'LS ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (42, N'La Pampita ', N'LT ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (43, N'Mercedes ', N'MD ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (44, N'Monte ', N'ME ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (45, N'Monte Hermoso ', N'MH ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (46, N'Mar de Ajó ', N'MJ ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (47, N'Mar del Plata ', N'MP ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (48, N'Miramar ', N'MR ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (49, N'Mar del Tuyú ', N'MU ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (50, N'Norte Dos ', N'ND ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (51, N'Necochea ', N'NE ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (52, N'Nueve de Julio ', N'NJ ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (53, N'Nueve de Julio Dos ', N'NJD ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (54, N'San Nicolás Urbana ', N'NU ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (55, N'Olavarría 132 kV ', N'OA ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (56, N'Pigué ', N'PF ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (57, N'Pehuajó ', N'PH ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (58, N'Protisa ', N'PJ ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (59, N'Patagones ', N'PK ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (60, N'Pedro Luro ', N'PL ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (61, N'Pinamar ', N'PM ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (62, N'Pergamino ', N'PO ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (63, N'Petroquímica ', N'PQ ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (64, N'Papel Prensa ', N'PS ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (65, N'Punta Alta ', N'PV ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (66, N'Praxair ', N'PX ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (67, N'Quequén ', N'QU ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (68, N'Rojas ', N'RF ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (69, N'Ramallo Industrial ', N'RN ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (70, N'Salto ', N'SA ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (71, N'Saladillo ', N'SB ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (72, N'San Clemente ', N'SE ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (73, N'San Pedro ', N'SH ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (74, N'Siderar ', N'SID ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (75, N'San Nicolás 132 kV ', N'SN ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (76, N'Tandil ', N'TD ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (77, N'Trenque Lauquen ', N'TL ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (78, N'Tornquist ', N'TO ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (79, N'Toyota ', N'TOY ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (80, N'Tres Arroyos ', N'TY ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (81, N'Valeria del Mar ', N'VA ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (82, N'Villa Gesell ', N'VG ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (83, N'Villa Lía ', N'VL ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (84, N'Zárate ', N'ZA ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (85, N'Puerto Bahía Blanca ', N'PBB ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (86, N'Pergamino Industrial ', N'PID ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (87, N'Puerto Potasio ', N'PPO ', 1, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (88, N'Abasto ', N'AB ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (89, N'Arroyo Cabral ', N'AC ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (90, N'Agua del Cajón ', N'AG ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (91, N'Alicurá ', N'AL ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (92, N'Almafuerte ', N'AM ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (93, N'Atucha ', N'AT ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (94, N'Bahía Blanca ', N'BB ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (95, N'El Bracho ', N'BR ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (96, N'Catamarca ', N'CAT ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (97, N'Cerrito de la Costa ', N'CC ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (98, N'El Chocón ', N'CH ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (99, N'Choele Choel ', N'CL ', 2, 1)
GO
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (100, N'Río Coronda 500 kV ', N'CN ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (101, N'Chocón Oeste ', N'CO ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (102, N'El Morejón ', N'EMO ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (103, N'Ezeiza ', N'EZ ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (104, N'Gran Mendoza ', N'GM ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (105, N'Henderson ', N'HE ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (106, N'La Rioja Sur ', N'LA ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (107, N'LAVALLE ', N'LAV ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (108, N'Luján ', N'LU ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (109, N'Malvinas Argentinas ', N'MA ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (110, N'Manuel Belgrano 500 kV ', N'MB ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (111, N'Macachín ', N'MC ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (112, N'Nueva San Juan (Futura) ', N'NSJ ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (113, N'Olavarría ', N'OL ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (114, N'Planicie Banderita ', N'PB ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (115, N'Piedra del Águila ', N'PG ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (116, N'Puelches ', N'PU ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (117, N'Ramallo ', N'RA ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (118, N'General Rodríguez ', N'RD ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (119, N'Río Diamante ', N'RDI ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (120, N'Recreo ', N'RE ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (121, N'Río Grande ', N'RG ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (122, N'Romang ', N'RM ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (123, N'Rosario oeste ', N'RO ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (124, N'Resistencia ', N'RS ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (125, N'Santiago del Estero ', N'SES ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (126, N'San Juancito 500 kV ', N'SO ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (127, N'Santo Tomé ', N'ST ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (128, N'Villa Lía ', N'VL ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (129, N'Coronel Charlone ', N'CCH ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (130, N'Gran Paraná ', N'GPA ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (131, N'Vivoratá ', N'VIV ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (132, N'Veinticinco de Mayo ', N'VM ', 2, 1)
INSERT [dbo].[Sede] ([Id_Sede], [Sede], [Codigo], [Empresa], [Activo]) VALUES (133, N'fff', N'ff', 1, 0)
SET IDENTITY_INSERT [dbo].[Sede] OFF
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (4, 5)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (4, 6)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (4, 7)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (8, 1009)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (8, 2003)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (3003, 3004)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (3003, 3005)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (4003, 4004)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (4003, 4006)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (4007, 4008)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (4007, 4009)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (3003, 4024)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (5005, 5006)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (5005, 5008)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (5005, 5009)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (5010, 5011)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (5010, 5012)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (6007, 6008)
INSERT [dbo].[SubPregunta] ([ID_Pregunta], [ID_SubPregunta]) VALUES (6007, 6009)
SET IDENTITY_INSERT [dbo].[TipoPregunta] ON 

INSERT [dbo].[TipoPregunta] ([ID_TipoPregunta], [TipoPregunta], [Activo]) VALUES (1, N'MultipleChoice', 1)
INSERT [dbo].[TipoPregunta] ([ID_TipoPregunta], [TipoPregunta], [Activo]) VALUES (2, N'Ordenado', 1)
INSERT [dbo].[TipoPregunta] ([ID_TipoPregunta], [TipoPregunta], [Activo]) VALUES (3, N'MultipleChoiceCompuesto', 1)
INSERT [dbo].[TipoPregunta] ([ID_TipoPregunta], [TipoPregunta], [Activo]) VALUES (4, N'VerdaderoFalso', 1)
SET IDENTITY_INSERT [dbo].[TipoPregunta] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [UserName], [Email], [Password], [DVH], [Activo], [Bloqueado], [CantidadIntentos], [Nombre], [Apellido]) VALUES (1, N'andres.benitez@transener.com.ar', N'andres.benitez@transener.com.ar', N'FC78F43E1AA478259790215C1253E197095A17DE01D688E5361B8D5702455A11691C1A05F961D51F661E2A59A484121F39F44E9A1B147DD55EA7FEC6BC1C94B5', N'E8908A5C6D673A16857E799D97C09E971B1AEE80EDF5ADB98257EA7136DE22D353F809606BF5B1ACFFAB17DC365EE93D2E84E951D3809C111077714E5E0F4BBB', 1, 0, 0, N'Andres', N'Benitez')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 27/8/2020 12:00:11 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 27/8/2020 12:00:11 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 27/8/2020 12:00:11 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 27/8/2020 12:00:11 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 27/8/2020 12:00:11 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 27/8/2020 12:00:11 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_Usuario1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_Usuario1]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_EventoBitacora] FOREIGN KEY([ID_EventoBitacora])
REFERENCES [dbo].[EventoBitacora] ([ID_EventoBitacora])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_EventoBitacora]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Usuario] FOREIGN KEY([Id])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Usuario]
GO
ALTER TABLE [dbo].[PDF]  WITH CHECK ADD  CONSTRAINT [FK_PDF_Usuario] FOREIGN KEY([Id])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[PDF] CHECK CONSTRAINT [FK_PDF_Usuario]
GO
ALTER TABLE [dbo].[Pregunta]  WITH CHECK ADD  CONSTRAINT [FK_Pregunta_NivelPregunta] FOREIGN KEY([ID_Nivel])
REFERENCES [dbo].[NivelPregunta] ([ID_Nivel])
GO
ALTER TABLE [dbo].[Pregunta] CHECK CONSTRAINT [FK_Pregunta_NivelPregunta]
GO
ALTER TABLE [dbo].[Pregunta]  WITH CHECK ADD  CONSTRAINT [FK_Pregunta_TipoPregunta] FOREIGN KEY([ID_TipoPregunta])
REFERENCES [dbo].[TipoPregunta] ([ID_TipoPregunta])
GO
ALTER TABLE [dbo].[Pregunta] CHECK CONSTRAINT [FK_Pregunta_TipoPregunta]
GO
ALTER TABLE [dbo].[PreguntaCategoria]  WITH CHECK ADD  CONSTRAINT [FK_PreguntaCategoria_Categoria] FOREIGN KEY([ID_Categoria])
REFERENCES [dbo].[Categoria] ([ID_Categoria])
GO
ALTER TABLE [dbo].[PreguntaCategoria] CHECK CONSTRAINT [FK_PreguntaCategoria_Categoria]
GO
ALTER TABLE [dbo].[PreguntaCategoria]  WITH CHECK ADD  CONSTRAINT [FK_PreguntaCategoria_Pregunta] FOREIGN KEY([ID_Pregunta])
REFERENCES [dbo].[Pregunta] ([ID_Pregunta])
GO
ALTER TABLE [dbo].[PreguntaCategoria] CHECK CONSTRAINT [FK_PreguntaCategoria_Pregunta]
GO
ALTER TABLE [dbo].[Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Respuesta_Pregunta] FOREIGN KEY([ID_Pregunta])
REFERENCES [dbo].[Pregunta] ([ID_Pregunta])
GO
ALTER TABLE [dbo].[Respuesta] CHECK CONSTRAINT [FK_Respuesta_Pregunta]
GO
ALTER TABLE [dbo].[Sede]  WITH CHECK ADD  CONSTRAINT [FK_Sede_Empresa] FOREIGN KEY([Empresa])
REFERENCES [dbo].[Empresa] ([ID_Empresa])
GO
ALTER TABLE [dbo].[Sede] CHECK CONSTRAINT [FK_Sede_Empresa]
GO
ALTER TABLE [dbo].[SubPregunta]  WITH CHECK ADD  CONSTRAINT [FK_SubPregunta_Pregunta] FOREIGN KEY([ID_Pregunta])
REFERENCES [dbo].[Pregunta] ([ID_Pregunta])
GO
ALTER TABLE [dbo].[SubPregunta] CHECK CONSTRAINT [FK_SubPregunta_Pregunta]
GO
ALTER TABLE [dbo].[SubPregunta]  WITH CHECK ADD  CONSTRAINT [FK_SubPregunta_Pregunta1] FOREIGN KEY([ID_SubPregunta])
REFERENCES [dbo].[Pregunta] ([ID_Pregunta])
GO
ALTER TABLE [dbo].[SubPregunta] CHECK CONSTRAINT [FK_SubPregunta_Pregunta1]
GO
ALTER TABLE [dbo].[UsuarioParaExamen]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioParaExamen_Direccion] FOREIGN KEY([Id_Direccion])
REFERENCES [dbo].[Direccion] ([ID_Direccion])
GO
ALTER TABLE [dbo].[UsuarioParaExamen] CHECK CONSTRAINT [FK_UsuarioParaExamen_Direccion]
GO
ALTER TABLE [dbo].[UsuarioParaExamen]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioParaExamen_Gerencia] FOREIGN KEY([Id_Gerencia])
REFERENCES [dbo].[Gerencia] ([Id_Gerencia])
GO
ALTER TABLE [dbo].[UsuarioParaExamen] CHECK CONSTRAINT [FK_UsuarioParaExamen_Gerencia]
GO
ALTER TABLE [dbo].[UsuarioParaExamen]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioParaExamen_Jefatura] FOREIGN KEY([Id_Jefatura])
REFERENCES [dbo].[Jefatura] ([Id_Jefatura])
GO
ALTER TABLE [dbo].[UsuarioParaExamen] CHECK CONSTRAINT [FK_UsuarioParaExamen_Jefatura]
GO
ALTER TABLE [dbo].[UsuarioParaExamen]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioParaExamen_Sector] FOREIGN KEY([Id_Sector])
REFERENCES [dbo].[Sector] ([Id_Sector])
GO
ALTER TABLE [dbo].[UsuarioParaExamen] CHECK CONSTRAINT [FK_UsuarioParaExamen_Sector]
GO
ALTER TABLE [dbo].[UsuarioParaExamen]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioParaExamen_Sede] FOREIGN KEY([Id_Sede])
REFERENCES [dbo].[Sede] ([Id_Sede])
GO
ALTER TABLE [dbo].[UsuarioParaExamen] CHECK CONSTRAINT [FK_UsuarioParaExamen_Sede]
GO
ALTER TABLE [dbo].[UsuarioParaExamen]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioParaExamen_Usuario] FOREIGN KEY([Id])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioParaExamen] CHECK CONSTRAINT [FK_UsuarioParaExamen_Usuario]
GO
USE [master]
GO
ALTER DATABASE [evalucionesTecnicas] SET  READ_WRITE 
GO

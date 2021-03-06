USE [master]
GO
/****** Object:  Database [RRHH_Test]    Script Date: 12/5/2020 11:57:28 ******/
CREATE DATABASE [RRHH_Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RRHH_Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RRHH_Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RRHH_Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RRHH_Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RRHH_Test] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RRHH_Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RRHH_Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RRHH_Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RRHH_Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RRHH_Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RRHH_Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [RRHH_Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RRHH_Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RRHH_Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RRHH_Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RRHH_Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RRHH_Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RRHH_Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RRHH_Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RRHH_Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RRHH_Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RRHH_Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RRHH_Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RRHH_Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RRHH_Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RRHH_Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RRHH_Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RRHH_Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RRHH_Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RRHH_Test] SET  MULTI_USER 
GO
ALTER DATABASE [RRHH_Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RRHH_Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RRHH_Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RRHH_Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RRHH_Test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RRHH_Test] SET QUERY_STORE = OFF
GO
USE [RRHH_Test]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/5/2020 11:57:28 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/5/2020 11:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/5/2020 11:57:28 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/5/2020 11:57:28 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/5/2020 11:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/5/2020 11:57:28 ******/
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
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 12/5/2020 11:57:28 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelPregunta]    Script Date: 12/5/2020 11:57:28 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pregunta]    Script Date: 12/5/2020 11:57:28 ******/
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
 CONSTRAINT [PK_Pregunta] PRIMARY KEY CLUSTERED 
(
	[ID_Pregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntaCategoria]    Script Date: 12/5/2020 11:57:28 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuesta]    Script Date: 12/5/2020 11:57:28 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPregunta]    Script Date: 12/5/2020 11:57:28 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202004201538299_InitialCreate', N'Safari.UI.Web.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C5B6FE336167E2FB0FF41D0D36E915AB9EC0CA681DD22759236D8C905E3A4DDB7012DD10E3112A54A549AA0E82FEB437FD2FE853D942859E245175BB19DA24031160FBF7378F8913C240FF3BF3FFF1A7FFF1CF8D6138E1312D2897D343AB42D4CDDD0237439B153B6F8E683FDFD77FFF86A7CE105CFD6CF85DC0997839A3499D88F8C45A78E93B88F3840C928206E1C26E1828DDC307090173AC78787DF3A47470E06081BB02C6BFC29A58C0438FB013FA7217571C452E45F871EF613F11D4A6619AA7583029C44C8C5137B86162826A387ABD12F783ECAE56DEBCC27086C99617F615B88D2902106969E3E2478C6E2902E67117C40FEFD4B84416E81FC048B169CAEC4BB36E6F09837C659552CA0DC346161D013F0E84478C791ABAFE563BBF41EF8EF02FCCC5E78AB331F4EEC2B0F679F3E853E384056783AF5632E3CB1AF4B1567497483D9A8A838CA212F6380FB2D8CBF8CAA880756E77A07259B8E4787FCBF036B9AFA2C8DF184E294C5C83FB0EED2B94FDCFFE097FBF00BA69393A3F9E2E4C3BBF7C83B79FF6F7CF2AEDA52682BC8D53EC0A7BB388C700CB6E145D97EDB72EAF51CB96259AD5227F70A700906866D5DA3E78F982ED9230C99E30FB675499EB1577C11E47AA004C6115462710A3F6F52DF47731F97E54EA34EFEFF06ADC7EFDE0FA2F5063D9165D6F5927E1838318CAB4FD8CF4A934712E5C3ABD6DF9F85D8651C06FC779D5F79E9E75998C62E6F4C6814B947F112B3BA75636745DE4E94E650C3D3BA40DD7F6A734B557A6B457983D61909858A6D8F86C2DED7D5DB99716751049D97518B7BA48970BAE56A24D53FB06A522BFA1C75A50F8566FD9D67C38B00117F80E9B08316884516240E70D9CA1F42201FA2BD6DBE434902B381F7134A1E1B4C877F0E60FA0CBB690C249D311444AFAEEDEE31A4F8260DE69CFBDBD33558D7DCFF165E229785F105E5B536C6FB18BA5FC2945D50EF1C31FCC0DC0290FFBC2741778041CC39735D9C24974066EC4D4308B50BC02BCA4E8E7BC3F1296AD7E1C8D44724D0C723D264FAB9105DC5247A09252E3188E9629326533F864B42BB995A889A4DCD255A4D15627D4DE560DD2C159266433381563B73A9C1A2BDAC87860FF732D8FD8FF7365BBC4D7341C58D339821F18F98E218A631EF0E318663BAEA812EF3C62E8285ACFBB8D2575F9B324D3F233F1D5AD55AA3219B04861F0D19ECFE8F86CC4CF8FC443C1E9574D80415C200DF495EBFBF6A1F739265DB1E0EB5666E5BF976E600D370394B92D025D928D01C7F89C38BBAFD10C359ED2719796BE4D3106818109DF0250FBE40DB6C9954B7F41CFB9861EBCCCD8F07A7287191A7BA111AE4F530AC58513586AD4E45EAC67DADE804A6E39857427C1394C0482594A9C382509744C86FF59254B3E312C6DB5EEA904BCE71842957D8EA892ECAF58720DC80528FD4296D1E1A3B15C63513D110B59AFABC2D845DF5BB7236B1154EB6C4CE065E8AF8ED5588D9ECB12D90B3D9255D0C301EE8ED82A062AFD29500F2C665DF082AED980C041521D556085AF7D80E085A77C99B2368BE45EDDAFFD27E75DFE859DF286F7F596F74D70EB859F3C79E51338F3DA10E831A3856E9793EE785F89969366760A7D89F2522D49529C2C16798D58F6C56F1AE360E759A4164123501AE88D6022AAE0215206540F530AE38CB6BB44E44113D608B73B7465831F74BB0150EA8D8D52BD18AA0F9E2542667A7DD47D9B2920D0AC93B6D162A381A42C89357BDE11D9C623A97551DD32516EE130D571A263AA3C1412D91ABC149456306F75241CD762FE902B23E21D9465E92C22783978AC60CEE25C1D176276982821E61C1462EAA2FE1030DB6E2A4A35C6DCAB2B193E74A890F63C7905435BE465144E8B2926425BE58B33CC36AFACDAC7FE2519063386EA2C93F2AAD2D35B130464B2C95826AB0F492C4093B470CCD113FE7997A8122A65D5B0DD37FA1B2BA7CAA9D58AC038534FFB7B859D55DE0D7565B351C112897D0C680C734D941BA8601FAEA164F7B433E8A3567F7D3D04F036A0EB1CCB5F31BBC6AFDFC8B8A307624FB95104AF19712E8D69DDFA96BD4613158379531CCFA5D65863039BC8840AB2E3745A56694E290AA8A623AB8DA59D79982999EDD25478AFD7BAB15E175C696484FA902884F3D312A190E0A58A5AC3B6A3D09A58A592FE98E28659A5421A5A21E5656F3496A46560BD6C23378542FD15D839A415245574BBB236B7249AAD09AE235B03536CB65DD5135E92655604D7177EC55EE893C8DEEF1EA65DCBF6CB07CE59BDCCDD62F03C6EBCC89C32C7F95BBFC2A50E5734F2C715BAF8089EF7BC927E34E6F033EE5A71B9BF1C980619E7D6AF7E0F5C9A7F1F2DE8C59BBDCAE4DF04D97FB66BC7EAC7D556E285B3D59A4D45E6EF9A4ADDD586CB3DA1FD528FBAE5CC4B60A3702A35E128683111718CD7EF5A73EC17C2A2F04AE11250B9CB03CA1C33E3E3C3A965EE5ECCF0B1927493C5FB34D353D93A9F7D91672B3E8138ADD4714AB99121BBC2259812A87D057D4C3CF13FBF7ACD669769EC1FF957D3EB0AE92074A7E4DA1E03E4EB1F5879AF9394C567DF3566B4FDF4074F7EAD57F3FE7550FACDB1846CCA97528F9729D1EAEBF8CE8654D5E75036BD67E2FF1760754ED218216551A10EBBF3B981336C89B83C2CA7F06E8F95F7D4DD3BE2BD80851F3766028BC415C687A1BB00E96F15D80073F59F62EA05F63F5EF04D631CDF84680D0FE60F20B81EED3505173874B8D6657B48D2929F3736B86F546E996BB5E9B9444EC8D06BA9A6CDD036E8384EA3598F1C67291075B1D35A9C68361EF92DAAF9E5FBC2F29C5AB648FDD66126F3379B8E172E86F9533BC07596E9AAC9DDD67066F9B6BA693DC3D4FAFEC97FFBB676413B95CBBCFF2DD36D94CC7BC7B4EB65EB9BC7BC6B55DAD9F3B665AE72574E799B96A9291E146467716DC96799B1F9CC30E7F1E0209F288327F30A94FF56A4A536D51B812312B35E798C98A9581A3E855249AD5F66BAB58F01B1B2B649AD51A32339B748BF9BF51B79069D66DC877DC45CEB036E35097C7DD328F35A542BDA51CE15A4B5A52D2DB62D6C6EBF5B794123C88536AA3C77047FC7632800771C99043A747C6AF7ADD0B6B67E52F2DC2FA9D90E50A82FFDD458ADDDAAA59CA5CD145582CDE924585887442738D19F260493D8B1959209741313F63CE5E7C67E776FCA6638EBD2B7A9BB22865D0641CCCFDDA81170F029AF46769CD759BC7B751F6C74B8668029849F8D9FC2DFD2125BE57DA7DA939133240F0E8429CE8F2BE64FC6477F95222DD84B42390705F1914DDE320F2012CB9A533F484D7B10DE8F7112F91FBB23A013481B47744DDEDE3738296310A1281B1AA0F3F81C35EF0FCDDFF01936F822770540000, N'6.1.3-40302')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrador')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Usuario')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1', N'1')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1', N'andres@andres.com', 0, N'ALykyGK2InLFdbbTy8hNj86QqlcbMqJ+aHGZGOwq/rTc96OkxrFJGO75oofTxeETkg==', N'fb884c47-bc2f-47fa-b443-000f5cb4f823', NULL, 0, 0, NULL, 1, 0, N'andres@andres.com')
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([ID_Categoria], [Categoria], [Descripcion], [Activo]) VALUES (1, N'Microinformática', N'Examen para ingresantes de Microinformática', 1)
INSERT [dbo].[Categoria] ([ID_Categoria], [Categoria], [Descripcion], [Activo]) VALUES (2, N'Borrar', N'Borrar', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Categoria], [Descripcion], [Activo]) VALUES (1002, N'Aplicaciones Técnicas', N'Examen de ingreso para Aplicaciones Técnicas de la Gerencia de Sistemas', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[NivelPregunta] ON 

INSERT [dbo].[NivelPregunta] ([ID_Nivel], [Nivel], [Activo]) VALUES (1, N'Bajo', 1)
INSERT [dbo].[NivelPregunta] ([ID_Nivel], [Nivel], [Activo]) VALUES (2, N'Medio', 1)
INSERT [dbo].[NivelPregunta] ([ID_Nivel], [Nivel], [Activo]) VALUES (3, N'Alto', 1)
INSERT [dbo].[NivelPregunta] ([ID_Nivel], [Nivel], [Activo]) VALUES (1008, N'Muy Dificil', 1)
SET IDENTITY_INSERT [dbo].[NivelPregunta] OFF
SET IDENTITY_INSERT [dbo].[Pregunta] ON 

INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (1, N'borrar', N'string', 1, 0, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (2, N'¿Qué comando, disponible en Windows, se mostrará la información de configuración de red de un PC?', NULL, 1, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (3, N'¿Qué es el Registro del sistema?', NULL, 3, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (4, N'¿Qué utilidad de Windows se utiliza para instalar manualmente un controlador de dispositivos?', NULL, 1, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (5, N'¿Cuál es la diferencia entre un disco m2 y SSD?', NULL, 2, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (6, N'Según la RFC1918 que direcciones IP son asignadas para redes privadas ¿Cuáles?
', NULL, 3, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (7, N'Un técnico reemplaza un disco duro interno que se utiliza como unidad secundaria en una PC. Después de conectar el hardware nuevo y encender la PC, aparece el mensaje de error “No se encuentra OS”. ¿Cuál es la causa más probable de dicho mensaje de error?
', NULL, 3, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (9, N'¿Cual seria el orden para el uso del un pendrive?', NULL, 2, 1, 2)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (10, N'¿Cual es el orden para limpiar una notebook?', NULL, 1, 1, 2)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (11, N'Disponemos de 400 máquinas con W7. Es necesario actualizarlas a W10 en un fin de semana. Consulta: ¿En que orden lo haria?', NULL, 1, 1, 2)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (12, N'Windows 10 es un _________ de ___________ creado en el año ________________', NULL, 2, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (13, N'Uno de estas marcas no hacen computadoras', N'', 1, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (1014, N'Que es SAP', NULL, 1, 1, 2)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (1015, N'Según la IEEE, cual IP es privada', N'G://Mi unidad\-uai\TFI\Entregas', 2, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (1016, N'¿Cual es el lenguaje de programación usado por SAP?', N'', 1, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (1017, N'Hola', N'', 1, 0, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (1019, N'Hola', N'C:\Imagenes\martin 1.jpg', 1, 1, 1)
INSERT [dbo].[Pregunta] ([ID_Pregunta], [Pregunta], [Imagen], [ID_Nivel], [Activo], [ID_TipoPregunta]) VALUES (1020, N'Cuales es la nueva luna', N'C:\Imagenes\Santi 3.jpg', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Pregunta] OFF
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (1, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (2, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (3, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (4, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (5, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (6, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (7, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (9, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (10, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (11, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (12, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (13, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (1014, 1002)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (1015, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (1016, 1002)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (1017, 1)
INSERT [dbo].[PreguntaCategoria] ([ID_Pregunta], [ID_Categoria]) VALUES (1020, 1002)
SET IDENTITY_INSERT [dbo].[Respuesta] ON 

INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (5, N'Cuando Windows se bloquea seguido', NULL, 0, 1, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (7, N'Cuando la conexión a Internet se cae continuamente.', NULL, 0, 1, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (8, N'Cuando hace un ruido y se demora en arrancar', NULL, 1, 1, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (9, N'Cunado el Bios hace ruido de 1 pitido', NULL, 0, 1, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (10, N'Colocar el Pendribe', 1, NULL, 9, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (11, N'Presionar Quitar Pendrive con seguridad', 2, NULL, 9, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (12, N'Quitar el pendrive', 3, NULL, 9, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (13, N'El pendrive esta listo para colocar en otra PC', 4, NULL, 9, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (14, N'Apagar La Notebook', 1, NULL, 10, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (15, N'Mojar un paño con limpiador', 2, NULL, 10, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (16, N'Limpiar la Notebook', 3, NULL, 10, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (17, N'Encender la Notebook', 4, NULL, 10, 1)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (18, N'Sap es Sap', 1, NULL, 1014, 0)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (19, N'Respuesta Final', 4, NULL, 1014, 0)
INSERT [dbo].[Respuesta] ([ID_Respuesta], [Respuesta], [Orden], [Correcta], [ID_Pregunta], [Activo]) VALUES (20, N'Respuesta Final 2', 4, NULL, 1014, 1)
SET IDENTITY_INSERT [dbo].[Respuesta] OFF
SET IDENTITY_INSERT [dbo].[TipoPregunta] ON 

INSERT [dbo].[TipoPregunta] ([ID_TipoPregunta], [TipoPregunta], [Activo]) VALUES (1, N'MultipleChoice', 1)
INSERT [dbo].[TipoPregunta] ([ID_TipoPregunta], [TipoPregunta], [Activo]) VALUES (2, N'Ordenado', 1)
INSERT [dbo].[TipoPregunta] ([ID_TipoPregunta], [TipoPregunta], [Activo]) VALUES (3, N'Completar', 0)
INSERT [dbo].[TipoPregunta] ([ID_TipoPregunta], [TipoPregunta], [Activo]) VALUES (4, N'Rellenar', 0)
INSERT [dbo].[TipoPregunta] ([ID_TipoPregunta], [TipoPregunta], [Activo]) VALUES (5, N'Rellenar', 0)
SET IDENTITY_INSERT [dbo].[TipoPregunta] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/5/2020 11:57:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 12/5/2020 11:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 12/5/2020 11:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 12/5/2020 11:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 12/5/2020 11:57:28 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/5/2020 11:57:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
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
USE [master]
GO
ALTER DATABASE [RRHH_Test] SET  READ_WRITE 
GO

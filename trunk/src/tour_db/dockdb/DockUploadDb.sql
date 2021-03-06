USE [master]
GO
/****** Object:  Database [$(DB)]    Script Date: 2/17/2017 3:37:41 AM ******/
CREATE DATABASE [$(DB)]
 
-- CONTAINMENT = NONE
--  ON  PRIMARY 
-- ( NAME = N'$(DB)', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\$(DB).mdf' , SIZE = 9216KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
--  LOG ON 
-- ( NAME = N'$(DB)_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\$(DB)_log.ldf' , SIZE = 5696KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)

GO
ALTER DATABASE [$(DB)] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [$(DB)].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [$(DB)] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [$(DB)] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [$(DB)] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [$(DB)] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [$(DB)] SET ARITHABORT OFF 
GO
ALTER DATABASE [$(DB)] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [$(DB)] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [$(DB)] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [$(DB)] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [$(DB)] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [$(DB)] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [$(DB)] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [$(DB)] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [$(DB)] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [$(DB)] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [$(DB)] SET  DISABLE_BROKER 
GO
ALTER DATABASE [$(DB)] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [$(DB)] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [$(DB)] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [$(DB)] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [$(DB)] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [$(DB)] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [$(DB)] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [$(DB)] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [$(DB)] SET  MULTI_USER 
GO
ALTER DATABASE [$(DB)] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [$(DB)] SET DB_CHAINING OFF 
GO
ALTER DATABASE [$(DB)] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [$(DB)] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [$(DB)]
GO
/****** Object:  Table [dbo].[Airports]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airports](
	[AirportID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[IATA] [nvarchar](255) NULL,
	[ICAO] [nvarchar](255) NULL,
	[Latitude] [nvarchar](255) NULL,
	[Longitude] [nvarchar](255) NULL,
	[Altitude] [nvarchar](255) NULL,
	[Timezone] [nvarchar](255) NULL,
	[DST] [nvarchar](255) NULL,
	[Tzdatabase] [nvarchar](255) NULL,
 CONSTRAINT [PK_Airports] PRIMARY KEY CLUSTERED 
(
	[AirportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](50) NOT NULL,
	[CountryFlag] [varchar](50) NULL,
	[Nationality] [varchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Country__10D160BF250A3DC4] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Newsfeed]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Newsfeed](
	[NewsfeedID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[TourID] [int] NOT NULL,
	[NewsfeedTitle] [varchar](max) NOT NULL,
	[NewsfeedContent] [varchar](max) NULL,
	[NewsfeedDate] [datetime] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Newsfeed__44DBBC3DCF66829A] PRIMARY KEY CLUSTERED 
(
	[NewsfeedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organization](
	[OrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[OrganizationTypeID] [int] NOT NULL,
	[OrganizationName] [varchar](100) NULL,
	[CreateDate] [datetime] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Organiza__CADB0B72570333F2] PRIMARY KEY CLUSTERED 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Organization_Type]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organization_Type](
	[OrganizationTypeID] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationTypeName] [varchar](50) NOT NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_OrganizationTypeID] PRIMARY KEY CLUSTERED 
(
	[OrganizationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TimeZone]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TimeZone](
	[TimeZoneID] [int] IDENTITY(1,1) NOT NULL,
	[TimeZoneName] [nvarchar](60) NULL,
	[TimeZoneAbbr] [nvarchar](30) NULL,
	[TimeZoneUtc] [varchar](30) NULL,
	[TimeGMT] [nvarchar](30) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_TimeZoneList_X] PRIMARY KEY CLUSTERED 
(
	[TimeZoneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tour]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tour](
	[TourID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[OrgID] [int] NOT NULL,
	[TourTypeID] [int] NOT NULL,
	[TourName] [varchar](max) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[TourDescription] [varchar](max) NULL,
	[DestinationCity] [varchar](max) NULL,
	[DestinationCoordinate] [varchar](150) NULL,
	[DateCreated] [datetime] NULL,
	[TargetNo] [int] NULL,
	[Photo] [varchar](max) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Tour__604CEA104D9215E8] PRIMARY KEY CLUSTERED 
(
	[TourID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tour_Activities]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Activities](
	[ActivityID] [int] IDENTITY(1,1) NOT NULL,
	[TourPlanID] [int] NOT NULL,
	[TourID] [int] NOT NULL,
	[ActivityTypeID] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Activities] PRIMARY KEY CLUSTERED 
(
	[ActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Activities_Dining]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Activities_Dining](
	[ActivityDiningID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NOT NULL,
	[DiningName] [nvarchar](50) NULL,
	[DiningPlace] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Activities_Dining_1] PRIMARY KEY CLUSTERED 
(
	[ActivityDiningID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Activities_Lodging]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Activities_Lodging](
	[ActivityLodgingID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NOT NULL,
	[LodgingName] [nvarchar](50) NULL,
	[LodgingPlace] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Activities_Lodging_1] PRIMARY KEY CLUSTERED 
(
	[ActivityLodgingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Activities_Meeting]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Activities_Meeting](
	[ActivityMeetingID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NOT NULL,
	[MeetingName] [nvarchar](50) NULL,
	[MeetingPlace] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Activities_Meeting_1] PRIMARY KEY CLUSTERED 
(
	[ActivityMeetingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Activities_Place]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Activities_Place](
	[ActivityPlaceID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NULL,
	[Latitude] [decimal](18, 0) NULL,
	[Longitude] [decimal](18, 0) NULL,
	[Address] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Activities_Place] PRIMARY KEY CLUSTERED 
(
	[ActivityPlaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_ActivityType]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_ActivityType](
	[ActivityTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityTypeName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_ActivityType] PRIMARY KEY CLUSTERED 
(
	[ActivityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Attachment]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Attachment](
	[AttachmentID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NULL,
	[AttachmentName] [nvarchar](100) NULL,
	[AttachmentPath] [nvarchar](150) NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Attachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Directions]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Directions](
	[TourDirectionID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NULL,
	[TransportationID] [int] NULL,
	[DirectionTypeID] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Directions] PRIMARY KEY CLUSTERED 
(
	[TourDirectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Directions_Path]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Directions_Path](
	[DirectionPathID] [int] IDENTITY(1,1) NOT NULL,
	[TourDirectionID] [int] NOT NULL,
	[AirportID] [int] NULL,
	[TimeZoneID] [int] NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Directions_Path] PRIMARY KEY CLUSTERED 
(
	[DirectionPathID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_DirectionType]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tour_DirectionType](
	[DirectionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DirectionTypeName] [varchar](50) NOT NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Tour_Dir__F06BCF9B2B12C2D6] PRIMARY KEY CLUSTERED 
(
	[DirectionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tour_Note]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tour_Note](
	[TourNoteID] [int] IDENTITY(1,1) NOT NULL,
	[TourID] [int] NOT NULL,
	[TourPlanID] [int] NOT NULL,
	[Note] [varchar](max) NULL,
	[Title] [varchar](50) NULL,
	[URL] [varchar](250) NULL,
	[StartDate] [datetime] NULL,
	[StartTime] [varchar](10) NULL,
	[StartTimeZone] [varchar](50) NULL,
	[StartTimeCounterpart] [varchar](50) NULL,
	[Photo] [varchar](max) NULL,
	[PhotoCaption] [varchar](max) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Note] PRIMARY KEY CLUSTERED 
(
	[TourNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tour_Participant]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Participant](
	[TourID] [int] NOT NULL,
	[EmailAddress] [nvarchar](60) NOT NULL,
	[isOrganizer] [bit] NULL,
	[isParticipant] [bit] NULL,
	[isViewer] [bit] NULL,
	[Status] [nvarchar](15) NULL,
	[DateInvited] [datetime] NULL,
	[DateConfirmed] [datetime] NULL,
	[isConfirmed] [bit] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Participant] PRIMARY KEY CLUSTERED 
(
	[TourID] ASC,
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Plan]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tour_Plan](
	[TourPlanID] [int] IDENTITY(1,1) NOT NULL,
	[TourID] [int] NOT NULL,
	[PlanTypeID] [int] NULL,
	[PlanName] [varchar](200) NULL,
	[PlanDate] [datetime] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Tour_Pla__D7402CA2E3973D46] PRIMARY KEY CLUSTERED 
(
	[TourPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tour_Plan_Category]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tour_Plan_Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Tour_Pla__19093A2BBC8430A4] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tour_Plan_Type]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tour_Plan_Type](
	[TourPlanTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[PlanTypeName] [varchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Tour_Pla__060D009280C12CC3] PRIMARY KEY CLUSTERED 
(
	[TourPlanTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tour_Review]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Review](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[TourID] [int] NULL,
	[ReviewText] [nvarchar](max) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__Tour_Rev__74BC79AE89817B2A] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Transportation_Car]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Transportation_Car](
	[TransportationCarID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationID] [int] NOT NULL,
	[CarType] [nvarchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Transportation_Car_1] PRIMARY KEY CLUSTERED 
(
	[TransportationCarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Transportation_Cruise]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Transportation_Cruise](
	[TransportationCruiseID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationID] [int] NOT NULL,
	[ShipName] [nvarchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Transportation_Cruise_1] PRIMARY KEY CLUSTERED 
(
	[TransportationCruiseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Transportation_Flight]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Transportation_Flight](
	[TransportationFlightID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationID] [int] NOT NULL,
	[FlightNo] [nvarchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Transportation_Flight_1] PRIMARY KEY CLUSTERED 
(
	[TransportationFlightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Transportation_Train]    Script Date: 2/17/2017 3:37:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Transportation_Train](
	[TransportationTrainID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationID] [int] NOT NULL,
	[StationName] [nvarchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Transportation_Train_1] PRIMARY KEY CLUSTERED 
(
	[TransportationTrainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Transportations]    Script Date: 2/17/2017 3:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_Transportations](
	[TransportationID] [int] IDENTITY(1,1) NOT NULL,
	[TourPlanID] [int] NOT NULL,
	[TransportationTypeID] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tour_Transportations] PRIMARY KEY CLUSTERED 
(
	[TransportationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_TransportationType]    Script Date: 2/17/2017 3:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour_TransportationType](
	[TransportationTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationTypeName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TransportationTypeID] PRIMARY KEY CLUSTERED 
(
	[TransportationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tour_Type]    Script Date: 2/17/2017 3:37:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Tour_Type](
	[TourTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TourTypeName] [varchar](50) NULL,
	[isActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TourTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF_Organization_OrganizationTypeID]  DEFAULT ((1)) FOR [OrganizationTypeID]
GO
ALTER TABLE [dbo].[Tour] ADD  CONSTRAINT [DF_Tour_OrgId]  DEFAULT ((0)) FOR [OrgID]
GO
ALTER TABLE [dbo].[Tour_Activities] ADD  CONSTRAINT [DF_Tour_Activities_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Tour_Activities_Place] ADD  CONSTRAINT [DF_Tour_Activities_Place_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Tour_Attachment] ADD  CONSTRAINT [DF_Tour_Attachment_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Tour_Directions] ADD  CONSTRAINT [DF_Tour_Directions_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Tour_Directions_Path] ADD  CONSTRAINT [DF_Tour_Directions_Path_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Newsfeed]  WITH NOCHECK ADD  CONSTRAINT [FK_Newsfeed_Tour] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Tour] ([TourID])
GO
ALTER TABLE [dbo].[Newsfeed] CHECK CONSTRAINT [FK_Newsfeed_Tour]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Organization_Type] FOREIGN KEY([OrganizationTypeID])
REFERENCES [dbo].[Organization_Type] ([OrganizationTypeID])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_Organization_Type]
GO
ALTER TABLE [dbo].[Tour]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Tour_Type] FOREIGN KEY([TourTypeID])
REFERENCES [dbo].[Tour_Type] ([TourTypeID])
GO
ALTER TABLE [dbo].[Tour] CHECK CONSTRAINT [FK_Tour_Tour_Type]
GO
ALTER TABLE [dbo].[Tour_Activities]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Activities_Tour_ActivityType] FOREIGN KEY([ActivityTypeID])
REFERENCES [dbo].[Tour_ActivityType] ([ActivityTypeID])
GO
ALTER TABLE [dbo].[Tour_Activities] CHECK CONSTRAINT [FK_Tour_Activities_Tour_ActivityType]
GO
ALTER TABLE [dbo].[Tour_Activities]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Activities_Tour_Plan] FOREIGN KEY([TourPlanID])
REFERENCES [dbo].[Tour_Plan] ([TourPlanID])
GO
ALTER TABLE [dbo].[Tour_Activities] CHECK CONSTRAINT [FK_Tour_Activities_Tour_Plan]
GO
ALTER TABLE [dbo].[Tour_Activities_Dining]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Activities_Dining_Tour_Activities] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Tour_Activities] ([ActivityID])
GO
ALTER TABLE [dbo].[Tour_Activities_Dining] CHECK CONSTRAINT [FK_Tour_Activities_Dining_Tour_Activities]
GO
ALTER TABLE [dbo].[Tour_Activities_Lodging]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Activities_Lodging_Tour_Activities] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Tour_Activities] ([ActivityID])
GO
ALTER TABLE [dbo].[Tour_Activities_Lodging] CHECK CONSTRAINT [FK_Tour_Activities_Lodging_Tour_Activities]
GO
ALTER TABLE [dbo].[Tour_Activities_Meeting]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Activities_Meeting_Tour_Activities] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Tour_Activities] ([ActivityID])
GO
ALTER TABLE [dbo].[Tour_Activities_Meeting] CHECK CONSTRAINT [FK_Tour_Activities_Meeting_Tour_Activities]
GO
ALTER TABLE [dbo].[Tour_Activities_Place]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Activities_Place_Tour_Activities] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Tour_Activities] ([ActivityID])
GO
ALTER TABLE [dbo].[Tour_Activities_Place] CHECK CONSTRAINT [FK_Tour_Activities_Place_Tour_Activities]
GO
ALTER TABLE [dbo].[Tour_Attachment]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Attachment_Tour_Activities] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Tour_Activities] ([ActivityID])
GO
ALTER TABLE [dbo].[Tour_Attachment] CHECK CONSTRAINT [FK_Tour_Attachment_Tour_Activities]
GO
ALTER TABLE [dbo].[Tour_Directions]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Directions_Tour_Activities] FOREIGN KEY([ActivityID])
REFERENCES [dbo].[Tour_Activities] ([ActivityID])
GO
ALTER TABLE [dbo].[Tour_Directions] CHECK CONSTRAINT [FK_Tour_Directions_Tour_Activities]
GO
ALTER TABLE [dbo].[Tour_Directions]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Directions_Tour_DirectionType] FOREIGN KEY([DirectionTypeID])
REFERENCES [dbo].[Tour_DirectionType] ([DirectionTypeID])
GO
ALTER TABLE [dbo].[Tour_Directions] CHECK CONSTRAINT [FK_Tour_Directions_Tour_DirectionType]
GO
ALTER TABLE [dbo].[Tour_Directions]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Directions_Tour_Transportations] FOREIGN KEY([TransportationID])
REFERENCES [dbo].[Tour_Transportations] ([TransportationID])
GO
ALTER TABLE [dbo].[Tour_Directions] CHECK CONSTRAINT [FK_Tour_Directions_Tour_Transportations]
GO
ALTER TABLE [dbo].[Tour_Directions_Path]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Directions_Path_Airports] FOREIGN KEY([AirportID])
REFERENCES [dbo].[Airports] ([AirportID])
GO
ALTER TABLE [dbo].[Tour_Directions_Path] CHECK CONSTRAINT [FK_Tour_Directions_Path_Airports]
GO
ALTER TABLE [dbo].[Tour_Directions_Path]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Directions_Path_TimeZone] FOREIGN KEY([TimeZoneID])
REFERENCES [dbo].[TimeZone] ([TimeZoneID])
GO
ALTER TABLE [dbo].[Tour_Directions_Path] CHECK CONSTRAINT [FK_Tour_Directions_Path_TimeZone]
GO
ALTER TABLE [dbo].[Tour_Directions_Path]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Directions_Path_Tour_Directions] FOREIGN KEY([TourDirectionID])
REFERENCES [dbo].[Tour_Directions] ([TourDirectionID])
GO
ALTER TABLE [dbo].[Tour_Directions_Path] CHECK CONSTRAINT [FK_Tour_Directions_Path_Tour_Directions]
GO
ALTER TABLE [dbo].[Tour_Note]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Note_Tour_Plan] FOREIGN KEY([TourID])
REFERENCES [dbo].[Tour_Plan] ([TourPlanID])
GO
ALTER TABLE [dbo].[Tour_Note] CHECK CONSTRAINT [FK_Tour_Note_Tour_Plan]
GO
ALTER TABLE [dbo].[Tour_Participant]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Participant_Tour] FOREIGN KEY([TourID])
REFERENCES [dbo].[Tour] ([TourID])
GO
ALTER TABLE [dbo].[Tour_Participant] CHECK CONSTRAINT [FK_Tour_Participant_Tour]
GO
ALTER TABLE [dbo].[Tour_Plan]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Plan_Tour] FOREIGN KEY([TourID])
REFERENCES [dbo].[Tour] ([TourID])
GO
ALTER TABLE [dbo].[Tour_Plan] CHECK CONSTRAINT [FK_Tour_Plan_Tour]
GO
ALTER TABLE [dbo].[Tour_Plan]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Plan_Tour_Plan_Type] FOREIGN KEY([PlanTypeID])
REFERENCES [dbo].[Tour_Plan_Type] ([TourPlanTypeID])
GO
ALTER TABLE [dbo].[Tour_Plan] CHECK CONSTRAINT [FK_Tour_Plan_Tour_Plan_Type]
GO
ALTER TABLE [dbo].[Tour_Review]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Review_Tour] FOREIGN KEY([TourID])
REFERENCES [dbo].[Tour] ([TourID])
GO
ALTER TABLE [dbo].[Tour_Review] CHECK CONSTRAINT [FK_Tour_Review_Tour]
GO
ALTER TABLE [dbo].[Tour_Transportation_Car]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Transportation_Car_Tour_Transportations] FOREIGN KEY([TransportationID])
REFERENCES [dbo].[Tour_Transportations] ([TransportationID])
GO
ALTER TABLE [dbo].[Tour_Transportation_Car] CHECK CONSTRAINT [FK_Tour_Transportation_Car_Tour_Transportations]
GO
ALTER TABLE [dbo].[Tour_Transportation_Cruise]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Transportation_Cruise_Tour_Transportations] FOREIGN KEY([TransportationID])
REFERENCES [dbo].[Tour_Transportations] ([TransportationID])
GO
ALTER TABLE [dbo].[Tour_Transportation_Cruise] CHECK CONSTRAINT [FK_Tour_Transportation_Cruise_Tour_Transportations]
GO
ALTER TABLE [dbo].[Tour_Transportation_Flight]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Transportation_Flight_Tour_Transportations] FOREIGN KEY([TransportationID])
REFERENCES [dbo].[Tour_Transportations] ([TransportationID])
GO
ALTER TABLE [dbo].[Tour_Transportation_Flight] CHECK CONSTRAINT [FK_Tour_Transportation_Flight_Tour_Transportations]
GO
ALTER TABLE [dbo].[Tour_Transportation_Train]  WITH NOCHECK ADD  CONSTRAINT [FK_Tour_Transportation_Train_Tour_Transportations] FOREIGN KEY([TransportationID])
REFERENCES [dbo].[Tour_Transportations] ([TransportationID])
GO
ALTER TABLE [dbo].[Tour_Transportation_Train] CHECK CONSTRAINT [FK_Tour_Transportation_Train_Tour_Transportations]
GO
ALTER TABLE [dbo].[Tour_Transportations]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Transportations_Tour_Plan] FOREIGN KEY([TourPlanID])
REFERENCES [dbo].[Tour_Plan] ([TourPlanID])
GO
ALTER TABLE [dbo].[Tour_Transportations] CHECK CONSTRAINT [FK_Tour_Transportations_Tour_Plan]
GO
ALTER TABLE [dbo].[Tour_Transportations]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Transportations_Tour_TransportationType] FOREIGN KEY([TransportationTypeID])
REFERENCES [dbo].[Tour_TransportationType] ([TransportationTypeID])
GO
ALTER TABLE [dbo].[Tour_Transportations] CHECK CONSTRAINT [FK_Tour_Transportations_Tour_TransportationType]
GO
USE [master]
GO
ALTER DATABASE [$(DB)] SET  READ_WRITE 
GO


ALTER LOGIN sa ENABLE ;
GO
ALTER LOGIN sa WITH PASSWORD = 'Password1*';
GO

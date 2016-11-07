USE [master]
GO
/****** Object:  Database [TechOfficeDev]    Script Date: 11/7/2016 5:27:00 PM ******/
CREATE DATABASE [TechOfficeDev]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TechOfficeDev', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\TechOfficeDev.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TechOfficeDev_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\TechOfficeDev_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TechOfficeDev] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TechOfficeDev].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TechOfficeDev] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TechOfficeDev] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TechOfficeDev] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TechOfficeDev] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TechOfficeDev] SET ARITHABORT OFF 
GO
ALTER DATABASE [TechOfficeDev] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TechOfficeDev] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TechOfficeDev] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TechOfficeDev] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TechOfficeDev] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TechOfficeDev] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TechOfficeDev] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TechOfficeDev] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TechOfficeDev] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TechOfficeDev] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TechOfficeDev] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TechOfficeDev] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TechOfficeDev] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TechOfficeDev] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TechOfficeDev] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TechOfficeDev] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TechOfficeDev] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TechOfficeDev] SET RECOVERY FULL 
GO
ALTER DATABASE [TechOfficeDev] SET  MULTI_USER 
GO
ALTER DATABASE [TechOfficeDev] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TechOfficeDev] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TechOfficeDev] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TechOfficeDev] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TechOfficeDev] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TechOfficeDev', N'ON'
GO
ALTER DATABASE [TechOfficeDev] SET QUERY_STORE = OFF
GO
USE [TechOfficeDev]
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
USE [TechOfficeDev]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[MoTa] [nvarchar](1024) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CongViec_PhoiHop]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongViec_PhoiHop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[HoSoCongViecId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_CongViec_PhoiHop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CongViec_QuaTrinhXuLy]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongViec_QuaTrinhXuLy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GioBanHanh] [tinyint] NOT NULL,
	[PhutBanHanh] [tinyint] NOT NULL,
	[NgayBanHanh] [date] NULL,
	[NoiDung] [text] NULL,
	[NguoiThem] [nvarchar](1024) NULL,
	[NhacNho] [tinyint] NULL,
	[HoSoCongViecId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_CongViec_QuaTrinhXuLy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CongViec_VanBan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongViec_VanBan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoSoCongViecId] [int] NOT NULL,
	[SoVanBan] [nvarchar](255) NOT NULL,
	[NgayBanHanh] [datetime] NULL,
	[NoiDung] [text] NULL,
	[TenCoQuan] [nvarchar](1024) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_CongViec_VanBan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CoQuan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoQuan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NhomCoQuanId] [int] NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[MoTa] [text] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_CoQuan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoSoCongViec]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoSoCongViec](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NgayHetHan] [datetime] NULL,
	[UserPhuTrachId] [int] NOT NULL,
	[UserXuLyId] [int] NOT NULL,
	[LinhVucCongViecId] [int] NOT NULL,
	[Status] [tinyint] NULL,
	[NoiDung] [text] NOT NULL,
	[QuaTrinhXuLy] [text] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_HoSoCongViec] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LinhVucCongViec]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinhVucCongViec](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[MoTa] [nvarchar](1024) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_LinhVucCongViec] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LinhVucThuTuc]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinhVucThuTuc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[MoTa] [nvarchar](1024) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_LinhVucThuTuc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LinhVucVanBan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinhVucVanBan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[MoTa] [nvarchar](1024) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_LinhVucVanBan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiVanBan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiVanBan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[MoTa] [text] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_LoaiVanBan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MucDoHoanThanh]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MucDoHoanThanh](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[MoTa] [nvarchar](1024) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_MucDoHoanThanh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MucTin]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MucTin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[MoTa] [text] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_MucTin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhomCoQuan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomCoQuan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[MoTa] [text] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_NhomCoQuan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[GhiChu] [nvarchar](1024) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TacNghiep]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacNghiep](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NgayHetHan] [datetime] NOT NULL,
	[NgayHoanThanh] [datetime] NULL,
	[NoiDung] [text] NULL,
	[NoiDungTraoDoi] [text] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_TacNghiep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TacNghiep_CoQuanLienQuan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacNghiep_CoQuanLienQuan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TacNghiepId] [int] NOT NULL,
	[CoQuanId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_CoQuanLienQuan_TacNghiep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TacNghiep_TinhHinhThucHien]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacNghiep_TinhHinhThucHien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TacNghiepId] [int] NOT NULL,
	[CoQuanId] [int] NOT NULL,
	[ThoiGian] [int] NOT NULL,
	[MucDoHoanThanh] [nvarchar](255) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_TinhHinhThucHien_TacNghiep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TacNghiep_YKienCoQuan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacNghiep_YKienCoQuan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TacNghiepId] [int] NOT NULL,
	[CoQuanId] [int] NOT NULL,
	[NoiDung] [text] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_YKienCoQuan_TacNghiep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TapTinCongViec]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TapTinCongViec](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoSoCongViecId] [int] NOT NULL,
	[UserUploadId] [int] NOT NULL,
	[Url] [nvarchar](1024) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_TapTinCongViec] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TapTinTacNghiep]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TapTinTacNghiep](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TacNghiepId] [int] NOT NULL,
	[UserUploadId] [int] NOT NULL,
	[Url] [nvarchar](1024) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_TapTinTacNghiep] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TapTinThuTuc]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TapTinThuTuc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ThuTucId] [int] NOT NULL,
	[UserUploadId] [int] NOT NULL,
	[Url] [nvarchar](1024) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_TapTinThuTuc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TapTinVanBan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TapTinVanBan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VanBanId] [int] NOT NULL,
	[UserUploadId] [int] NOT NULL,
	[Url] [nvarchar](1024) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_TapTinVanBan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TapTinYKienCoQuan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TapTinYKienCoQuan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[YKiencoQuanTacNghiepId] [int] NOT NULL,
	[UserUploadId] [int] NOT NULL,
	[Url] [nvarchar](1024) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_TapTinYKienCoQuan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThuTuc]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuTuc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaThuTuc] [nvarchar](255) NOT NULL,
	[NgayBanHanh] [datetime] NULL,
	[TenThuTuc] [nvarchar](1024) NOT NULL,
	[CoQuanThucHienId] [int] NOT NULL,
	[LoaiThuTucId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_ThuTuc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](255) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[ChucVuId] [int] NOT NULL,
	[Password] [nvarchar](1024) NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VanBan]    Script Date: 11/7/2016 5:27:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VanBan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SoVanBan] [nvarchar](255) NOT NULL,
	[TenVanBan] [nvarchar](1024) NOT NULL,
	[NgayBanHanh] [datetime] NOT NULL,
	[CoQuanBanHanhId] [int] NOT NULL,
	[LoaiVanBanId] [int] NOT NULL,
	[LinhVucVanBanId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_VanBan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ChucVu] ADD  CONSTRAINT [DF_ChucVu_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CongViec_PhoiHop] ADD  CONSTRAINT [DF_CongViec_PhoiHop_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CongViec_QuaTrinhXuLy] ADD  CONSTRAINT [DF_CongViec_QuaTrinhXuLy_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CongViec_VanBan] ADD  CONSTRAINT [DF_CongViec_VanBan_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CoQuan] ADD  CONSTRAINT [DF_CoQuan_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[HoSoCongViec] ADD  CONSTRAINT [DF_HoSoCongViec_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LinhVucCongViec] ADD  CONSTRAINT [DF_CLinhVucCongViec_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LinhVucThuTuc] ADD  CONSTRAINT [DF_LinhVucThuTuc_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LinhVucVanBan] ADD  CONSTRAINT [DF_LinhVucVanBan_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LoaiVanBan] ADD  CONSTRAINT [DF_LoaiVanBan_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MucDoHoanThanh] ADD  CONSTRAINT [DF_MucDoHoanThanh_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MucTin] ADD  CONSTRAINT [DF_MucTin_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[NhomCoQuan] ADD  CONSTRAINT [DF_NhomCoQuan_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TacNghiep] ADD  CONSTRAINT [DF_TacNghiep_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TacNghiep_CoQuanLienQuan] ADD  CONSTRAINT [DF_CoQuanLienQuan_TacNghiep_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TacNghiep_TinhHinhThucHien] ADD  CONSTRAINT [DF_TinhHinhThucHien_TacNghiep_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TacNghiep_YKienCoQuan] ADD  CONSTRAINT [DF_YKienCoQuan_TacNghiep_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TapTinCongViec] ADD  CONSTRAINT [DF_TapTinCongViec_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TapTinTacNghiep] ADD  CONSTRAINT [DF_TapTinTacNghiep_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TapTinThuTuc] ADD  CONSTRAINT [DF_TapTinThuTuc_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TapTinVanBan] ADD  CONSTRAINT [DF_TapTinVanBan_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TapTinYKienCoQuan] ADD  CONSTRAINT [DF_TapTinYKienCoQuan_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ThuTuc] ADD  CONSTRAINT [DF_ThuTuc_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[VanBan] ADD  CONSTRAINT [DF_VanBan_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CongViec_PhoiHop]  WITH CHECK ADD  CONSTRAINT [FK_CongViec_PhoiHop_HoSoCongViec] FOREIGN KEY([HoSoCongViecId])
REFERENCES [dbo].[HoSoCongViec] ([Id])
GO
ALTER TABLE [dbo].[CongViec_PhoiHop] CHECK CONSTRAINT [FK_CongViec_PhoiHop_HoSoCongViec]
GO
ALTER TABLE [dbo].[CongViec_PhoiHop]  WITH CHECK ADD  CONSTRAINT [FK_CongViec_PhoiHop_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[CongViec_PhoiHop] CHECK CONSTRAINT [FK_CongViec_PhoiHop_User]
GO
ALTER TABLE [dbo].[CongViec_QuaTrinhXuLy]  WITH CHECK ADD  CONSTRAINT [FK_CongViec_QuaTrinhXuLy_HoSoCongViec] FOREIGN KEY([HoSoCongViecId])
REFERENCES [dbo].[HoSoCongViec] ([Id])
GO
ALTER TABLE [dbo].[CongViec_QuaTrinhXuLy] CHECK CONSTRAINT [FK_CongViec_QuaTrinhXuLy_HoSoCongViec]
GO
ALTER TABLE [dbo].[CongViec_VanBan]  WITH CHECK ADD  CONSTRAINT [FK_CongViec_VanBan_HoSoCongViec] FOREIGN KEY([HoSoCongViecId])
REFERENCES [dbo].[HoSoCongViec] ([Id])
GO
ALTER TABLE [dbo].[CongViec_VanBan] CHECK CONSTRAINT [FK_CongViec_VanBan_HoSoCongViec]
GO
ALTER TABLE [dbo].[CoQuan]  WITH CHECK ADD  CONSTRAINT [FK_CoQuan_NhomCoQuan] FOREIGN KEY([NhomCoQuanId])
REFERENCES [dbo].[NhomCoQuan] ([Id])
GO
ALTER TABLE [dbo].[CoQuan] CHECK CONSTRAINT [FK_CoQuan_NhomCoQuan]
GO
ALTER TABLE [dbo].[HoSoCongViec]  WITH CHECK ADD  CONSTRAINT [FK_HoSoCongViec_LinhVucCongViec] FOREIGN KEY([LinhVucCongViecId])
REFERENCES [dbo].[LinhVucCongViec] ([Id])
GO
ALTER TABLE [dbo].[HoSoCongViec] CHECK CONSTRAINT [FK_HoSoCongViec_LinhVucCongViec]
GO
ALTER TABLE [dbo].[HoSoCongViec]  WITH CHECK ADD  CONSTRAINT [FK_HoSoCongViec_UserPhuTrach] FOREIGN KEY([UserPhuTrachId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[HoSoCongViec] CHECK CONSTRAINT [FK_HoSoCongViec_UserPhuTrach]
GO
ALTER TABLE [dbo].[HoSoCongViec]  WITH CHECK ADD  CONSTRAINT [FK_HoSoCongViec_UserXuLyChinh] FOREIGN KEY([UserXuLyId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[HoSoCongViec] CHECK CONSTRAINT [FK_HoSoCongViec_UserXuLyChinh]
GO
ALTER TABLE [dbo].[TacNghiep_CoQuanLienQuan]  WITH CHECK ADD  CONSTRAINT [FK_TacNghiep_CoQuanLienQuan_CoQuan] FOREIGN KEY([CoQuanId])
REFERENCES [dbo].[CoQuan] ([Id])
GO
ALTER TABLE [dbo].[TacNghiep_CoQuanLienQuan] CHECK CONSTRAINT [FK_TacNghiep_CoQuanLienQuan_CoQuan]
GO
ALTER TABLE [dbo].[TacNghiep_CoQuanLienQuan]  WITH CHECK ADD  CONSTRAINT [FK_TacNghiep_CoQuanLienQuan_TacNghiep] FOREIGN KEY([TacNghiepId])
REFERENCES [dbo].[TacNghiep] ([Id])
GO
ALTER TABLE [dbo].[TacNghiep_CoQuanLienQuan] CHECK CONSTRAINT [FK_TacNghiep_CoQuanLienQuan_TacNghiep]
GO
ALTER TABLE [dbo].[TacNghiep_TinhHinhThucHien]  WITH CHECK ADD  CONSTRAINT [FK_TacNghiep_TinhHinhThucHien_CoQuan] FOREIGN KEY([CoQuanId])
REFERENCES [dbo].[CoQuan] ([Id])
GO
ALTER TABLE [dbo].[TacNghiep_TinhHinhThucHien] CHECK CONSTRAINT [FK_TacNghiep_TinhHinhThucHien_CoQuan]
GO
ALTER TABLE [dbo].[TacNghiep_TinhHinhThucHien]  WITH CHECK ADD  CONSTRAINT [FK_TacNghiep_TinhHinhThucHien_TacNghiep] FOREIGN KEY([TacNghiepId])
REFERENCES [dbo].[TacNghiep] ([Id])
GO
ALTER TABLE [dbo].[TacNghiep_TinhHinhThucHien] CHECK CONSTRAINT [FK_TacNghiep_TinhHinhThucHien_TacNghiep]
GO
ALTER TABLE [dbo].[TacNghiep_YKienCoQuan]  WITH CHECK ADD  CONSTRAINT [FK_TacNghiep_YKienCoQuan_CoQuan] FOREIGN KEY([CoQuanId])
REFERENCES [dbo].[CoQuan] ([Id])
GO
ALTER TABLE [dbo].[TacNghiep_YKienCoQuan] CHECK CONSTRAINT [FK_TacNghiep_YKienCoQuan_CoQuan]
GO
ALTER TABLE [dbo].[TacNghiep_YKienCoQuan]  WITH CHECK ADD  CONSTRAINT [FK_TacNghiep_YKienCoQuan_TacNghiep] FOREIGN KEY([TacNghiepId])
REFERENCES [dbo].[TacNghiep] ([Id])
GO
ALTER TABLE [dbo].[TacNghiep_YKienCoQuan] CHECK CONSTRAINT [FK_TacNghiep_YKienCoQuan_TacNghiep]
GO
ALTER TABLE [dbo].[TapTinCongViec]  WITH CHECK ADD  CONSTRAINT [FK_TapTinCongViec_HoSoCongViec] FOREIGN KEY([HoSoCongViecId])
REFERENCES [dbo].[HoSoCongViec] ([Id])
GO
ALTER TABLE [dbo].[TapTinCongViec] CHECK CONSTRAINT [FK_TapTinCongViec_HoSoCongViec]
GO
ALTER TABLE [dbo].[TapTinCongViec]  WITH CHECK ADD  CONSTRAINT [FK_TapTinCongViec_User] FOREIGN KEY([UserUploadId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TapTinCongViec] CHECK CONSTRAINT [FK_TapTinCongViec_User]
GO
ALTER TABLE [dbo].[TapTinTacNghiep]  WITH CHECK ADD  CONSTRAINT [FK_TapTinTacNghiep_TacNghiep] FOREIGN KEY([TacNghiepId])
REFERENCES [dbo].[TacNghiep] ([Id])
GO
ALTER TABLE [dbo].[TapTinTacNghiep] CHECK CONSTRAINT [FK_TapTinTacNghiep_TacNghiep]
GO
ALTER TABLE [dbo].[TapTinTacNghiep]  WITH CHECK ADD  CONSTRAINT [FK_TapTinTacNghiep_User] FOREIGN KEY([UserUploadId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TapTinTacNghiep] CHECK CONSTRAINT [FK_TapTinTacNghiep_User]
GO
ALTER TABLE [dbo].[TapTinThuTuc]  WITH CHECK ADD  CONSTRAINT [FK_TapTinThuTuc_ThuTuc] FOREIGN KEY([ThuTucId])
REFERENCES [dbo].[ThuTuc] ([Id])
GO
ALTER TABLE [dbo].[TapTinThuTuc] CHECK CONSTRAINT [FK_TapTinThuTuc_ThuTuc]
GO
ALTER TABLE [dbo].[TapTinThuTuc]  WITH CHECK ADD  CONSTRAINT [FK_TapTinThuTuc_User] FOREIGN KEY([UserUploadId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TapTinThuTuc] CHECK CONSTRAINT [FK_TapTinThuTuc_User]
GO
ALTER TABLE [dbo].[TapTinVanBan]  WITH CHECK ADD  CONSTRAINT [FK_TapTinVanBan_User] FOREIGN KEY([UserUploadId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TapTinVanBan] CHECK CONSTRAINT [FK_TapTinVanBan_User]
GO
ALTER TABLE [dbo].[TapTinVanBan]  WITH CHECK ADD  CONSTRAINT [FK_TapTinVanBan_VanBan] FOREIGN KEY([VanBanId])
REFERENCES [dbo].[VanBan] ([Id])
GO
ALTER TABLE [dbo].[TapTinVanBan] CHECK CONSTRAINT [FK_TapTinVanBan_VanBan]
GO
ALTER TABLE [dbo].[TapTinYKienCoQuan]  WITH CHECK ADD  CONSTRAINT [FK_TapTinYKienCoQuan_TacNghiep_YKienCoQuan] FOREIGN KEY([YKiencoQuanTacNghiepId])
REFERENCES [dbo].[TacNghiep_YKienCoQuan] ([Id])
GO
ALTER TABLE [dbo].[TapTinYKienCoQuan] CHECK CONSTRAINT [FK_TapTinYKienCoQuan_TacNghiep_YKienCoQuan]
GO
ALTER TABLE [dbo].[TapTinYKienCoQuan]  WITH CHECK ADD  CONSTRAINT [FK_TapTinYKienCoQuan_User] FOREIGN KEY([UserUploadId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TapTinYKienCoQuan] CHECK CONSTRAINT [FK_TapTinYKienCoQuan_User]
GO
ALTER TABLE [dbo].[ThuTuc]  WITH CHECK ADD  CONSTRAINT [FK_ThuTuc_CoQuan] FOREIGN KEY([CoQuanThucHienId])
REFERENCES [dbo].[CoQuan] ([Id])
GO
ALTER TABLE [dbo].[ThuTuc] CHECK CONSTRAINT [FK_ThuTuc_CoQuan]
GO
ALTER TABLE [dbo].[ThuTuc]  WITH CHECK ADD  CONSTRAINT [FK_ThuTuc_LinhVucThuTuc] FOREIGN KEY([LoaiThuTucId])
REFERENCES [dbo].[LinhVucThuTuc] ([Id])
GO
ALTER TABLE [dbo].[ThuTuc] CHECK CONSTRAINT [FK_ThuTuc_LinhVucThuTuc]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_ChucVu] FOREIGN KEY([ChucVuId])
REFERENCES [dbo].[ChucVu] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_ChucVu]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
ALTER TABLE [dbo].[VanBan]  WITH CHECK ADD  CONSTRAINT [FK_VanBan_CoQuan] FOREIGN KEY([CoQuanBanHanhId])
REFERENCES [dbo].[CoQuan] ([Id])
GO
ALTER TABLE [dbo].[VanBan] CHECK CONSTRAINT [FK_VanBan_CoQuan]
GO
ALTER TABLE [dbo].[VanBan]  WITH CHECK ADD  CONSTRAINT [FK_VanBan_LinhVucVanBan] FOREIGN KEY([LinhVucVanBanId])
REFERENCES [dbo].[LinhVucVanBan] ([Id])
GO
ALTER TABLE [dbo].[VanBan] CHECK CONSTRAINT [FK_VanBan_LinhVucVanBan]
GO
ALTER TABLE [dbo].[VanBan]  WITH CHECK ADD  CONSTRAINT [FK_VanBan_LoaiVanBan] FOREIGN KEY([LoaiVanBanId])
REFERENCES [dbo].[LoaiVanBan] ([Id])
GO
ALTER TABLE [dbo].[VanBan] CHECK CONSTRAINT [FK_VanBan_LoaiVanBan]
GO
USE [master]
GO
ALTER DATABASE [TechOfficeDev] SET  READ_WRITE 
GO

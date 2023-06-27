USE [master]
GO
/****** Object:  Database [QLHV]    Script Date: 6/27/2023 6:16:51 PM ******/
CREATE DATABASE [QLHV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLHV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLHV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLHV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLHV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLHV] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLHV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLHV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLHV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLHV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLHV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLHV] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLHV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLHV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLHV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLHV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLHV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLHV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLHV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLHV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLHV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLHV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLHV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLHV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLHV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLHV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLHV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLHV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLHV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLHV] SET RECOVERY FULL 
GO
ALTER DATABASE [QLHV] SET  MULTI_USER 
GO
ALTER DATABASE [QLHV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLHV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLHV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLHV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLHV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLHV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLHV', N'ON'
GO
ALTER DATABASE [QLHV] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLHV] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLHV]
GO
/****** Object:  Table [dbo].[BangDiem]    Script Date: 6/27/2023 6:16:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDiem](
	[MaHP] [int] IDENTITY(1,1) NOT NULL,
	[MaHV] [int] NULL,
	[MaMH] [int] NULL,
	[Diem] [float] NULL,
	[HeSo] [int] NULL,
	[NamHoc] [int] NULL,
 CONSTRAINT [PK_BangDiem] PRIMARY KEY CLUSTERED 
(
	[MaHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocVien]    Script Date: 6/27/2023 6:16:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien](
	[MaHV] [int] IDENTITY(1,1) NOT NULL,
	[TenHV] [varchar](250) NULL,
	[Lop] [varchar](3) NULL,
 CONSTRAINT [PK_HocVien] PRIMARY KEY CLUSTERED 
(
	[MaHV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 6/27/2023 6:16:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMH] [int] IDENTITY(1,1) NOT NULL,
	[TenMH] [char](255) NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BangDiem] ON 
GO
INSERT [dbo].[BangDiem] ([MaHP], [MaHV], [MaMH], [Diem], [HeSo], [NamHoc]) VALUES (1, 1, 1, 1, 1, 2023)
GO
INSERT [dbo].[BangDiem] ([MaHP], [MaHV], [MaMH], [Diem], [HeSo], [NamHoc]) VALUES (2, 3, 2, 2, 1, 2023)
GO
INSERT [dbo].[BangDiem] ([MaHP], [MaHV], [MaMH], [Diem], [HeSo], [NamHoc]) VALUES (3, 1, 3, 3, 1, 2023)
GO
INSERT [dbo].[BangDiem] ([MaHP], [MaHV], [MaMH], [Diem], [HeSo], [NamHoc]) VALUES (4, 2, 1, 10, 1, 2023)
GO
INSERT [dbo].[BangDiem] ([MaHP], [MaHV], [MaMH], [Diem], [HeSo], [NamHoc]) VALUES (5, 1, 2, 3, 1, 2023)
GO
INSERT [dbo].[BangDiem] ([MaHP], [MaHV], [MaMH], [Diem], [HeSo], [NamHoc]) VALUES (6, 2, 2, 3, 1, 2023)
GO
INSERT [dbo].[BangDiem] ([MaHP], [MaHV], [MaMH], [Diem], [HeSo], [NamHoc]) VALUES (7, 1, 1, 1, 1, 2021)
GO
SET IDENTITY_INSERT [dbo].[BangDiem] OFF
GO
SET IDENTITY_INSERT [dbo].[HocVien] ON 
GO
INSERT [dbo].[HocVien] ([MaHV], [TenHV], [Lop]) VALUES (1, N'nguyen van a', N'7A1')
GO
INSERT [dbo].[HocVien] ([MaHV], [TenHV], [Lop]) VALUES (2, N'nguyen van b', N'7A1')
GO
INSERT [dbo].[HocVien] ([MaHV], [TenHV], [Lop]) VALUES (3, N'nguyen van c', N'7A1')
GO
SET IDENTITY_INSERT [dbo].[HocVien] OFF
GO
SET IDENTITY_INSERT [dbo].[MonHoc] ON 
GO
INSERT [dbo].[MonHoc] ([MaMH], [TenMH]) VALUES (1, N'toan                                                                                                                                                                                                                                                           ')
GO
INSERT [dbo].[MonHoc] ([MaMH], [TenMH]) VALUES (2, N'ly                                                                                                                                                                                                                                                             ')
GO
INSERT [dbo].[MonHoc] ([MaMH], [TenMH]) VALUES (3, N'hoa                                                                                                                                                                                                                                                            ')
GO
INSERT [dbo].[MonHoc] ([MaMH], [TenMH]) VALUES (4, N'sinh                                                                                                                                                                                                                                                           ')
GO
INSERT [dbo].[MonHoc] ([MaMH], [TenMH]) VALUES (5, N'su                                                                                                                                                                                                                                                             ')
GO
INSERT [dbo].[MonHoc] ([MaMH], [TenMH]) VALUES (6, N'dia                                                                                                                                                                                                                                                            ')
GO
INSERT [dbo].[MonHoc] ([MaMH], [TenMH]) VALUES (7, N'tin                                                                                                                                                                                                                                                            ')
GO
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_HocVien] FOREIGN KEY([MaHV])
REFERENCES [dbo].[HocVien] ([MaHV])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_HocVien]
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_MonHoc] FOREIGN KEY([MaMH])
REFERENCES [dbo].[MonHoc] ([MaMH])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_MonHoc]
GO
USE [master]
GO
ALTER DATABASE [QLHV] SET  READ_WRITE 
GO

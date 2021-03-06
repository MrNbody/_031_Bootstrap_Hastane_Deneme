USE [master]
GO
/****** Object:  Database [Hastane]    Script Date: 23.9.2016 13:59:18 ******/
CREATE DATABASE [Hastane]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hastane', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Hastane.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Hastane_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Hastane_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Hastane] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hastane].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hastane] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hastane] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hastane] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hastane] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hastane] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hastane] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hastane] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hastane] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hastane] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hastane] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hastane] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hastane] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hastane] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hastane] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hastane] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hastane] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hastane] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hastane] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hastane] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hastane] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hastane] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hastane] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hastane] SET RECOVERY FULL 
GO
ALTER DATABASE [Hastane] SET  MULTI_USER 
GO
ALTER DATABASE [Hastane] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hastane] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hastane] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hastane] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Hastane] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Hastane', N'ON'
GO
USE [Hastane]
GO
/****** Object:  Table [dbo].[Doktor]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doktor](
	[doktorID] [int] IDENTITY(1,1) NOT NULL,
	[klinikID] [int] NOT NULL,
	[doktorEmail] [nvarchar](50) NOT NULL,
	[doktorAd] [nvarchar](50) NOT NULL,
	[doktorSoyad] [nvarchar](50) NOT NULL,
	[doktorTc] [nvarchar](50) NOT NULL,
	[doktorTel] [nvarchar](50) NOT NULL,
	[doktorCinsiyet] [nvarchar](50) NOT NULL,
	[doktorSifre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Doktor] PRIMARY KEY CLUSTERED 
(
	[doktorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hastane]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastane](
	[hastaneID] [int] IDENTITY(1,1) NOT NULL,
	[ilceID] [int] NOT NULL,
	[hastaneAd] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Hastane] PRIMARY KEY CLUSTERED 
(
	[hastaneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ilce]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ilce](
	[ilceID] [int] IDENTITY(1,1) NOT NULL,
	[sehirID] [int] NOT NULL,
	[ilceAd] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ilce] PRIMARY KEY CLUSTERED 
(
	[ilceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Klinik]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klinik](
	[klinikID] [int] IDENTITY(1,1) NOT NULL,
	[hastaneID] [int] NOT NULL,
	[klinikAd] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Klinik] PRIMARY KEY CLUSTERED 
(
	[klinikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mesai]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesai](
	[mesaiID] [int] IDENTITY(1,1) NOT NULL,
	[doktorID] [int] NOT NULL,
	[mesaiSaat] [time](0) NOT NULL,
 CONSTRAINT [PK_Mesai] PRIMARY KEY CLUSTERED 
(
	[mesaiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Randevu]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Randevu](
	[randevuID] [int] IDENTITY(1,1) NOT NULL,
	[uyeID] [int] NOT NULL,
	[doktorID] [int] NOT NULL,
	[randevuTarihSaat] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Randevu] PRIMARY KEY CLUSTERED 
(
	[randevuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Saat]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Saat](
	[saatID] [int] IDENTITY(1,1) NOT NULL,
	[doktorID] [int] NOT NULL,
	[saatBaslama] [time](0) NOT NULL,
	[saatBitis] [time](0) NOT NULL,
	[saatPeriyot] [time](0) NOT NULL,
	[saatOgleBaslama] [time](0) NOT NULL,
	[saatOgleBitis] [time](0) NOT NULL,
 CONSTRAINT [PK_Saat] PRIMARY KEY CLUSTERED 
(
	[saatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sehir]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sehir](
	[sehirID] [int] IDENTITY(1,1) NOT NULL,
	[sehirAd] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sehir] PRIMARY KEY CLUSTERED 
(
	[sehirID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Uye]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uye](
	[uyeID] [int] IDENTITY(1,1) NOT NULL,
	[uyeEmail] [nvarchar](50) NOT NULL,
	[uyeSifre] [nvarchar](50) NOT NULL,
	[uyeTc] [nvarchar](50) NOT NULL,
	[uyeAd] [nvarchar](50) NOT NULL,
	[uyeSoyad] [nvarchar](50) NOT NULL,
	[uyeCins] [nvarchar](50) NOT NULL,
	[uyeDogumYer] [nvarchar](50) NOT NULL,
	[uyeDogumTarih] [date] NOT NULL,
	[uyeBabaAd] [nvarchar](50) NOT NULL,
	[uyeAnneAd] [nvarchar](50) NOT NULL,
	[uyeTel] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Uye] PRIMARY KEY CLUSTERED 
(
	[uyeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[viewDoktor]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[viewDoktor]
as
select Doktor.doktorID, Doktor.doktorAd+' '+Doktor.doktorSoyad as doktorAd, Klinik.klinikID, Klinik.klinikAd, Hastane.hastaneID, Hastane.hastaneAd, Ilce.ilceID, Ilce.ilceAd, Sehir.sehirID, Sehir.sehirAd from Doktor
inner join Klinik on Klinik.klinikID = Doktor.klinikID
inner join Hastane on Hastane.hastaneID = Klinik.hastaneID
inner join Ilce on Ilce.ilceID = Hastane.ilceID
inner join Sehir on Sehir.sehirID = Ilce.sehirID
GO
/****** Object:  View [dbo].[viewRandevuDetay]    Script Date: 23.9.2016 13:59:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[viewRandevuDetay]
as
select Randevu.uyeID, Uye.uyeAd+' '+Uye.uyeSoyad as uyeAd, Doktor.doktorID, Doktor.doktorAd+' '+Doktor.doktorSoyad as doktorAd, Klinik.klinikID, Klinik.klinikAd, Hastane.hastaneID, Hastane.hastaneAd, Ilce.ilceID, Ilce.ilceAd, Sehir.sehirID, Sehir.sehirAd, Randevu.randevuID, Randevu.randevuTarihSaat from Sehir
inner join Ilce on Ilce.sehirID = Sehir.sehirID
inner join Hastane on Hastane.ilceID = Ilce.ilceID
inner join Klinik on Klinik.hastaneID = Hastane.hastaneID
inner join Doktor on Doktor.klinikID = Klinik.klinikID
inner join Randevu on Randevu.doktorID = Doktor.doktorID
inner join Uye on Uye.uyeID = Randevu.uyeID
GO
ALTER TABLE [dbo].[Doktor]  WITH CHECK ADD  CONSTRAINT [FK_Doktor_Klinik] FOREIGN KEY([klinikID])
REFERENCES [dbo].[Klinik] ([klinikID])
GO
ALTER TABLE [dbo].[Doktor] CHECK CONSTRAINT [FK_Doktor_Klinik]
GO
ALTER TABLE [dbo].[Hastane]  WITH CHECK ADD  CONSTRAINT [FK_Hastane_Ilce] FOREIGN KEY([ilceID])
REFERENCES [dbo].[Ilce] ([ilceID])
GO
ALTER TABLE [dbo].[Hastane] CHECK CONSTRAINT [FK_Hastane_Ilce]
GO
ALTER TABLE [dbo].[Ilce]  WITH CHECK ADD  CONSTRAINT [FK_Ilce_Sehir] FOREIGN KEY([sehirID])
REFERENCES [dbo].[Sehir] ([sehirID])
GO
ALTER TABLE [dbo].[Ilce] CHECK CONSTRAINT [FK_Ilce_Sehir]
GO
ALTER TABLE [dbo].[Klinik]  WITH CHECK ADD  CONSTRAINT [FK_Klinik_Hastane] FOREIGN KEY([hastaneID])
REFERENCES [dbo].[Hastane] ([hastaneID])
GO
ALTER TABLE [dbo].[Klinik] CHECK CONSTRAINT [FK_Klinik_Hastane]
GO
ALTER TABLE [dbo].[Mesai]  WITH CHECK ADD  CONSTRAINT [FK_Mesai_Doktor] FOREIGN KEY([doktorID])
REFERENCES [dbo].[Doktor] ([doktorID])
GO
ALTER TABLE [dbo].[Mesai] CHECK CONSTRAINT [FK_Mesai_Doktor]
GO
ALTER TABLE [dbo].[Randevu]  WITH CHECK ADD  CONSTRAINT [FK_Randevu_Doktor] FOREIGN KEY([doktorID])
REFERENCES [dbo].[Doktor] ([doktorID])
GO
ALTER TABLE [dbo].[Randevu] CHECK CONSTRAINT [FK_Randevu_Doktor]
GO
ALTER TABLE [dbo].[Randevu]  WITH CHECK ADD  CONSTRAINT [FK_Randevu_Uye] FOREIGN KEY([uyeID])
REFERENCES [dbo].[Uye] ([uyeID])
GO
ALTER TABLE [dbo].[Randevu] CHECK CONSTRAINT [FK_Randevu_Uye]
GO
ALTER TABLE [dbo].[Saat]  WITH CHECK ADD  CONSTRAINT [FK_Saat_Doktor] FOREIGN KEY([doktorID])
REFERENCES [dbo].[Doktor] ([doktorID])
GO
ALTER TABLE [dbo].[Saat] CHECK CONSTRAINT [FK_Saat_Doktor]
GO
USE [master]
GO
ALTER DATABASE [Hastane] SET  READ_WRITE 
GO

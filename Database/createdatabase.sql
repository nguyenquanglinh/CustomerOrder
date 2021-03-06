USE [master]
GO
/****** Object:  Database [CustomerOrders]    Script Date: 9/12/2021 7:21:44 PM ******/
CREATE DATABASE [CustomerOrders]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerOrders', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CustomerOrders.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CustomerOrders_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CustomerOrders_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CustomerOrders] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerOrders].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerOrders] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerOrders] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerOrders] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerOrders] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerOrders] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerOrders] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomerOrders] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerOrders] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerOrders] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerOrders] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerOrders] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerOrders] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerOrders] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerOrders] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerOrders] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomerOrders] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerOrders] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerOrders] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerOrders] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerOrders] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerOrders] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerOrders] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerOrders] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CustomerOrders] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerOrders] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerOrders] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerOrders] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerOrders] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CustomerOrders] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CustomerOrders]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/12/2021 7:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Line1] [varchar](50) NULL,
	[Line2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Zip] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order_]    Script Date: 9/12/2021 7:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[CustomerId] [int] NULL,
	[OrderDate] [date] NULL,
	[Quantity] [float] NULL,
	[PricePaid] [float] NULL,
	[ShippedDate] [date] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 9/12/2021 7:21:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[PricePerItem] [float] NULL,
	[AverageCustomerRating] [float] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Order_] ADD  CONSTRAINT [DF_Order_OrderDate]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Order_] ADD  CONSTRAINT [DF_Order_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Order_] ADD  CONSTRAINT [DF_Order_PricePaid]  DEFAULT ((0)) FOR [PricePaid]
GO
ALTER TABLE [dbo].[Order_] ADD  CONSTRAINT [DF_Order_ShippedDate]  DEFAULT (getdate()) FOR [ShippedDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_PricePerItem]  DEFAULT ((0)) FOR [PricePerItem]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_AverageCustomerRating]  DEFAULT ((5)) FOR [AverageCustomerRating]
GO
ALTER TABLE [dbo].[Order_]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Order_] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order_]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Order_] CHECK CONSTRAINT [FK_Order_Product]
GO
USE [master]
GO
ALTER DATABASE [CustomerOrders] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [LibraryManagementSystemDB]    Script Date: 4/25/2016 5:50:33 PM ******/
CREATE DATABASE [LibraryManagementSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryManagementSystemDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LibraryManagementSystemDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LibraryManagementSystemDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LibraryManagementSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LibraryManagementSystemDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryManagementSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryManagementSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryManagementSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [LibraryManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[tbl_supplierLedger]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[tbl_supplierLedger] (@From datetime,@To datetime) AS
SELECT sbp.date,sbp.bill_no,s.supplier_name,sbp.payment_mode,b.bank_name,sbp.check_no,sbp.check_date,sbp.amount FROM tbl_supplierBillPayment AS sbp INNER JOIN tbl_supplier AS s ON sbp.supplier_id = s.id INNER JOIN tbl_bankAccount AS b ON sbp.bank_id = b.id WHERE sbp.date BETWEEN @From and @To 
GO
/****** Object:  Table [dbo].[tbl_bankAccount]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_bankAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bank_code] [varchar](50) NULL,
	[bank_name] [varchar](50) NULL,
	[account_no] [nvarchar](50) NULL,
	[bank_opening_balance] [float] NULL,
 CONSTRAINT [PK_tbl_bankAccount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_bankDeposit]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bankDeposit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[bank_id] [int] NOT NULL,
	[mode] [nvarchar](50) NULL,
	[party_bank_name] [nvarchar](50) NULL,
	[check_no] [nvarchar](50) NULL,
	[district_id] [int] NOT NULL,
	[party_id] [int] NOT NULL,
	[amount] [float] NULL,
 CONSTRAINT [PK_tbl_bankDeposit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_bankWithdraw]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bankWithdraw](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[bank_id] [int] NOT NULL,
	[check_no] [nvarchar](50) NULL,
	[withdrawBy] [nvarchar](50) NULL,
	[amount] [float] NULL,
 CONSTRAINT [PK_tbl_bankWithdraw] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_binder]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_binder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[binder_code] [varchar](50) NULL,
	[binder_name] [varchar](50) NULL,
	[binder_address] [varchar](50) NULL,
	[binder_opening_balance] [float] NULL,
 CONSTRAINT [PK_tbl_binder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_binderOrder]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_binderOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[year] [nvarchar](50) NULL,
	[order_no] [nvarchar](50) NULL,
	[binder_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[quantity] [float] NULL,
	[forma_quantity] [float] NULL,
	[press_id] [int] NOT NULL,
	[forma] [float] NULL,
 CONSTRAINT [PK_tbl_binderOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_binderOrderCancel]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_binderOrderCancel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[year] [nvarchar](50) NULL,
	[binder_id] [int] NOT NULL,
	[order_no] [nvarchar](50) NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[quantity] [float] NULL,
 CONSTRAINT [PK_tbl_binderOrderCancel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_binderReceive]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_binderReceive](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[receive_no] [nvarchar](50) NULL,
	[binder_id] [int] NOT NULL,
	[order_no] [nvarchar](50) NULL,
	[challan_no] [nvarchar](50) NULL,
	[year] [nvarchar](50) NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[quantity] [float] NULL,
 CONSTRAINT [PK_tbl_binderReceive] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_bonus]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bonus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[district_id] [int] NOT NULL,
	[party_id] [int] NOT NULL,
	[amount] [float] NULL,
 CONSTRAINT [PK_tbl_bonus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_book_info]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_book_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book_code] [varchar](50) NULL,
	[book_name] [varchar](50) NULL,
	[book_size] [varchar](50) NULL,
	[book_forma] [float] NULL,
	[book_inar] [float] NULL,
	[press_id] [int] NOT NULL,
	[binder_id] [int] NOT NULL,
	[main_book_id] [int] NOT NULL,
	[book_rate] [float] NULL,
	[book_return_rate] [float] NULL,
	[book_commission] [float] NULL,
	[book_opening_balance] [float] NULL,
	[book_status] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_book_info] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_bookReject]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bookReject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[district_id] [int] NOT NULL,
	[party_id] [int] NOT NULL,
	[reject_no] [nvarchar](50) NULL,
	[year] [nvarchar](50) NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[quantity] [float] NULL,
	[reject_rate] [float] NULL,
	[total] [float] NULL,
 CONSTRAINT [PK_tbl_bookReject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_bookReturn]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bookReturn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[district_id] [int] NOT NULL,
	[party_id] [int] NOT NULL,
	[return_no] [nvarchar](50) NULL,
	[challan_return] [nvarchar](50) NULL,
	[year] [nvarchar](50) NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[quantity] [float] NULL,
	[return_rate] [float] NULL,
	[total] [float] NULL,
	[transport_bill] [float] NULL,
	[less] [float] NULL,
	[net_return] [float] NULL,
 CONSTRAINT [PK_tbl_bookReturn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_bookSales]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bookSales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[district_id] [int] NOT NULL,
	[party_id] [int] NOT NULL,
	[memo_no] [nvarchar](50) NULL,
	[sales_type] [nvarchar](50) NULL,
	[year] [nvarchar](50) NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[quantity] [float] NULL,
	[sales_rate] [float] NULL,
	[total] [float] NULL,
	[packing] [float] NULL,
	[bonus] [float] NULL,
	[total_price] [float] NULL,
	[payment_amount] [float] NULL,
	[dues] [float] NULL,
 CONSTRAINT [PK_tbl_bookSales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_bookSpeciman]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bookSpeciman](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[district_id] [int] NOT NULL,
	[party_id] [int] NOT NULL,
	[memo_no] [nvarchar](50) NULL,
	[year] [nvarchar](50) NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[quantity] [float] NULL,
	[rate] [float] NULL,
	[total] [float] NULL,
 CONSTRAINT [PK_tbl_bookSpeciman] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_coverReceived]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_coverReceived](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[receive_no] [nvarchar](50) NULL,
	[year] [nchar](10) NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[quantity] [float] NULL,
 CONSTRAINT [PK_tbl_coverReceived] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_coverSupply]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_coverSupply](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[supply_no] [nvarchar](50) NULL,
	[binder_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[quantity] [float] NULL,
 CONSTRAINT [PK_tbl_coverSupply] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_district]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_district](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[district_code] [varchar](50) NULL,
	[district_name] [varchar](50) NULL,
	[division_id] [int] NULL,
 CONSTRAINT [PK_tbl_district] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_division]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_division](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[division_code] [varchar](50) NULL,
	[division_name] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_division] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_employee]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employee_code] [varchar](50) NULL,
	[employee_name] [varchar](50) NULL,
	[employee_nationalId] [float] NULL,
	[employee_contactNo] [varchar](50) NULL,
	[employee_address] [varchar](50) NULL,
	[employee_basic_salary] [float] NULL,
	[employee_opening_balance] [float] NULL,
 CONSTRAINT [PK_tbl_employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_employee_salary_entry]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_employee_salary_entry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employee_date] [nchar](10) NULL,
	[employee_year] [int] NULL,
	[employee_month] [varchar](50) NULL,
	[employee_id] [int] NULL,
	[salary_reduce] [float] NULL,
	[bonus] [float] NULL,
	[salary] [float] NULL,
	[remarks] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_employee_salary_entry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_employeeSalaryPayment]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeeSalaryPayment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[year] [float] NULL,
	[month] [nvarchar](50) NULL,
	[employee_id] [int] NOT NULL,
	[payment_mode] [nvarchar](50) NULL,
	[bank_id] [int] NOT NULL,
	[check_no] [nvarchar](50) NULL,
	[check_date] [nchar](10) NULL,
	[amount] [float] NULL,
	[remarks] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_employeeSalaryPayment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_group]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[group_code] [varchar](50) NULL,
	[group_name] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_loan]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_loan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[loan_code] [int] NULL,
	[loan_name] [nvarchar](50) NULL,
	[remarks] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_loan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_main_book]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_main_book](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[main_book_code] [varchar](50) NULL,
	[main_book_name] [varchar](50) NULL,
	[main_book_class] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_main_book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_moneyReceipt]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_moneyReceipt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[mr_no] [nvarchar](50) NULL,
	[district_id] [int] NOT NULL,
	[party_id] [int] NOT NULL,
	[mode] [nvarchar](50) NULL,
	[cheque_no] [nvarchar](50) NULL,
	[cheque_date] [nchar](10) NULL,
	[bank_id] [int] NOT NULL,
	[branch_name] [nvarchar](50) NULL,
	[amount] [float] NULL,
	[remarks] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_moneyReceipt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_other_group]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_other_group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[other_group_code] [varchar](50) NULL,
	[other_group_name] [varchar](50) NULL,
	[other_group_remarks] [varchar](50) NULL,
	[group_id] [int] NOT NULL,
 CONSTRAINT [PK_tbl_other_group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_otherBillPayment]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_otherBillPayment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[other_name_id] [int] NOT NULL,
	[payment_mode] [nvarchar](50) NULL,
	[bank_id] [int] NOT NULL,
	[check_no] [nvarchar](50) NULL,
	[check_date] [nchar](10) NULL,
	[amount] [float] NULL,
	[remarks] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_otherBillPayment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_paper]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_paper](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[paper_code] [varchar](50) NULL,
	[paper_name] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_paper] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_paperOrder]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_paperOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[supplier_id] [int] NOT NULL,
	[slip_no] [nvarchar](50) NULL,
	[press_id] [int] NOT NULL,
	[paper_id] [int] NOT NULL,
	[paper_type] [nvarchar](50) NULL,
	[quantity] [float] NULL,
 CONSTRAINT [PK_tbl_paperOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_paperPrint]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_paperPrint](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[order_no] [nvarchar](50) NULL,
	[press_id] [int] NOT NULL,
	[year] [nvarchar](50) NULL,
	[printing_type] [nvarchar](50) NULL,
	[group_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[plate] [float] NULL,
	[forma] [float] NULL,
	[forma_type] [nvarchar](50) NULL,
	[color_type] [nvarchar](50) NULL,
	[paper_id] [int] NOT NULL,
	[paper_type] [nvarchar](50) NULL,
	[book_quantity] [float] NULL,
	[paper_quantity] [float] NULL,
 CONSTRAINT [PK_tbl_paperPrint] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_paperTransfer]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_paperTransfer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[transfer_no] [nvarchar](50) NULL,
	[from_press_id] [int] NOT NULL,
	[to_press_id] [int] NOT NULL,
	[paper_id] [int] NOT NULL,
	[paper_type] [nvarchar](50) NULL,
	[quantity] [float] NULL,
 CONSTRAINT [PK_tbl_paperTransfer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_party]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_party](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[district_id] [int] NOT NULL,
	[party_code] [varchar](50) NULL,
	[party_name] [varchar](50) NULL,
	[party_propitor] [varchar](50) NULL,
	[party_address] [varchar](50) NULL,
	[party_phone] [varchar](50) NULL,
	[party_email] [varchar](50) NULL,
	[party_web] [varchar](50) NULL,
	[party_opening_balance] [float] NULL,
	[party_date] [date] NULL,
 CONSTRAINT [PK_tbl_party] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_personalLoanPayment]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_personalLoanPayment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[loan_type] [nvarchar](50) NULL,
	[party_id] [int] NOT NULL,
	[amount] [float] NULL,
 CONSTRAINT [PK_tbl_personalLoanPayment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ppLimination]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_ppLimination](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pplimination_code] [varchar](50) NULL,
	[pplimination_name] [varchar](50) NULL,
	[pplimination_address] [varchar](50) NULL,
	[pplimination_opening_balance] [float] NULL,
 CONSTRAINT [PK_tbl_ppLimination] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_press]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_press](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[press_code] [varchar](50) NULL,
	[press_name] [varchar](50) NULL,
	[press_address] [varchar](50) NULL,
	[press_opening_balance] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_press] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_shope]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_shope](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[shope_code] [varchar](50) NULL,
	[shope_name] [varchar](50) NULL,
	[shope_phone] [varchar](50) NULL,
	[shope_address] [varchar](50) NULL,
	[shope_monthly_rent] [float] NULL,
	[shope_opening_balance] [float] NULL,
 CONSTRAINT [PK_tbl_shope] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_spacymenParty]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_spacymenParty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[district_id] [int] NOT NULL,
	[spacymenParty_code] [varchar](50) NULL,
	[spacymenParty_name] [varchar](50) NULL,
	[spacymenParty_address] [varchar](50) NULL,
	[school_name] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_spacymenParty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_supplier]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supplier_code] [varchar](50) NULL,
	[supplier_name] [varchar](50) NULL,
	[supplier_address] [varchar](50) NULL,
	[supplier_opening_balance] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_supplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_supplier_bill_entry]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_supplier_bill_entry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supplier_date] [nchar](10) NULL,
	[bill_date] [nchar](10) NULL,
	[bill_no] [varchar](50) NULL,
	[supplier_type] [varchar](50) NULL,
	[supplier_id] [int] NULL,
	[press_id] [int] NULL,
	[paper_id] [int] NULL,
	[paper_type] [varchar](50) NULL,
	[paper_quantity] [float] NULL,
	[prize] [float] NULL,
	[description] [varchar](50) NULL,
	[bill_amount] [float] NULL,
 CONSTRAINT [PK_tbl_supplier_bill_entry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_supplierBillPayment]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_supplierBillPayment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [nchar](10) NULL,
	[bill_no] [nvarchar](50) NULL,
	[supplier_id] [int] NOT NULL,
	[payment_mode] [nvarchar](50) NULL,
	[bank_id] [int] NOT NULL,
	[check_no] [nvarchar](50) NULL,
	[check_date] [nchar](10) NULL,
	[amount] [float] NULL,
 CONSTRAINT [PK_tbl_supplierBillPayment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](50) NULL,
	[user_password] [varchar](50) NULL,
	[user_type] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_writter]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_writter](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[writter_code] [varchar](50) NULL,
	[writter_name] [varchar](50) NULL,
	[writter_phone] [varchar](50) NULL,
	[writter_address] [varchar](50) NULL,
	[writter_opening_balance] [float] NULL,
 CONSTRAINT [PK_tbl_writter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[tbl_binderOrderView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_binderOrderView] AS
SELECT TOP 1 bi.date,bi.year,bi.order_no,b.binder_name,g.group_code,book.book_code,bi.quantity,bi.forma_quantity,p.press_name,bi.forma FROM tbl_binderOrder as bi INNER JOIN tbl_binder as b ON bi.binder_id = b.id INNER JOIN tbl_group as g ON bi.group_id = g.id INNER JOIN tbl_book_info as book ON bi.book_id = book.id INNER JOIN tbl_press as p ON bi.press_id = p.id Order By bi.id DESC;

GO
/****** Object:  View [dbo].[tbl_binderReceiveView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_binderReceiveView] AS 
SELECT TOP 1 br.date,br.receive_no,b.binder_name,br.order_no,br.challan_no,br.year,g.group_name,bi.book_name,br.quantity FROM tbl_binderReceive as br INNER JOIN tbl_binder as b ON br.binder_id = b.id INNER JOIN tbl_group as g ON br.group_id = g.id INNER JOIN tbl_book_info as bi ON br.book_id = bi.id ORDER BY br.id DESC;
GO
/****** Object:  View [dbo].[tbl_bonusView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[tbl_bonusView] AS
SELECT b.date,d.district_name,p.party_code,p.party_name,b.amount FROM tbl_bonus as b INNER JOIN tbl_district as d ON b.district_id = d.id INNER JOIN tbl_party as p ON b.party_id = p.id;

GO
/****** Object:  View [dbo].[tbl_bookReturnView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_bookReturnView] AS
SELECT TOP 1 br.date,d.district_name,p.party_name,br.return_no,br.challan_return,br.year,g.group_name,bi.book_name,br.quantity,bi.book_rate,bi.book_commission,br.return_rate,br.total,br.transport_bill,br.less,br.net_return FROM tbl_bookReturn as br INNER JOIN tbl_district as d ON br.district_id = d.id INNER JOIN tbl_party as p ON br.party_id = p.id INNER JOIN tbl_group as g ON br.group_id = g.id INNER JOIN tbl_book_info as bi ON br.book_id = bi.id ORDER BY br.id DESC;
GO
/****** Object:  View [dbo].[tbl_bookSalesView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_bookSalesView] AS
SELECT TOP 1 bs.date,d.district_name,p.party_code,bs.memo_no,bs.sales_type,bs.year,g.group_name,bi.book_name,bs.quantity,bi.book_rate,bi.book_commission,bs.sales_rate,bs.total,bs.packing,bs.bonus,bs.total_price,bs.payment_amount,bs.dues FROM tbl_bookSales as bs INNER JOIN tbl_district as d ON bs.district_id = d.id INNER JOIN tbl_party as p ON bs.party_id = p.id INNER JOIN tbl_group as g ON bs.group_id = g.id INNER JOIN tbl_book_info as bi ON bs.book_id = bi.id ORDER BY bs.id DESC;
GO
/****** Object:  View [dbo].[tbl_bookSpecimanView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_bookSpecimanView] AS
SELECT TOP 1 bs.date,d.district_name,p.party_code,bs.memo_no,bs.year,g.group_name,bi.book_name,bs.quantity,bi.book_rate,bi.book_commission,bs.rate,bs.total FROM tbl_bookSpeciman as bs INNER JOIN tbl_district as d ON bs.district_id = d.id INNER JOIN tbl_party as p ON bs.party_id = p.id INNER JOIN tbl_group as g ON bs.group_id = g.id INNER JOIN tbl_book_info as bi ON bs.book_id= bi.id ORDER BY bs.id DESC;
GO
/****** Object:  View [dbo].[tbl_coverReceivedView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_coverReceivedView] AS
SELECT TOP 1 cr.date,cr.receive_no,cr.year,g.group_name,b.book_name,cr.quantity FROM tbl_coverReceived as cr INNER JOIN tbl_group as g ON cr.group_id = g.id INNER JOIN tbl_book_info as b ON cr.book_id = b.id ORDER BY cr.id DESC;
GO
/****** Object:  View [dbo].[tbl_coverSupplyView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_coverSupplyView] AS
SELECT TOP 1 cs.date,cs.supply_no,b.binder_name,g.group_name,bi.book_name,cs.quantity FROM tbl_coverSupply as cs INNER JOIN tbl_binder as b ON cs.binder_id = b.id INNER JOIN tbl_group as g On cs.group_id = g.id INNER JOIN tbl_book_info as bi On cs.book_id = bi.id ORDER BY cs.id DESC;

GO
/****** Object:  View [dbo].[tbl_Dis_view]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[tbl_Dis_view] As
select di.district_code,di.district_name,d.division_name from tbl_district as di inner join tbl_division as d On di.division_id = di.id;



GO
/****** Object:  View [dbo].[tbl_emp_party_bank]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_emp_party_bank] AS
select e.employee_name,e.employee_address,e.employee_nationalId,p.party_name,p.party_email,p.party_web,b.bank_code,b.bank_name from tbl_employee as e inner join tbl_party as p On e.id= p.id inner join tbl_bankAccount as b On p.id = b.id; 


GO
/****** Object:  View [dbo].[tbl_emp_shop]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[tbl_emp_shop] As
select e.employee_code,e.employee_name,e.employee_nationalId,s.shope_code,s.shope_name from tbl_employee as e inner join tbl_shope as s on e.id = s.id;


GO
/****** Object:  View [dbo].[tbl_moneyReceiptView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_moneyReceiptView] AS
SELECT TOP 1 m.date,m.mr_no,d.district_name,p.party_code,p.party_name,m.mode,m.cheque_no,m.cheque_date,bank.bank_name,m.branch_name,m.amount,m.remarks FROM tbl_moneyReceipt as m INNER JOIN tbl_district as d ON m.district_id = d.id INNER JOIN tbl_party as p ON m.party_id = p.id INNER JOIN tbl_bankAccount as bank ON m.bank_id = bank.id ORDER BY m.id DESC;
GO
/****** Object:  View [dbo].[tbl_paperOrderView]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tbl_paperOrderView] AS
SELECT TOP 1 po.date,s.supplier_name,po.slip_no,pr.press_code,pa.paper_name,po.paper_type,po.quantity FROM tbl_paperOrder as po INNER JOIN tbl_supplier as s ON po.supplier_id = s.id INNER JOIN tbl_press as pr ON po.press_id = pr.id INNER JOIN tbl_paper as pa ON po.paper_id = pa.id ORDER BY po.id DESC;
GO
/****** Object:  View [dbo].[tbl_viewPaper]    Script Date: 4/25/2016 5:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[tbl_viewPaper] As
Select Top 1 * From tbl_paper Order by id DESC

GO
SET IDENTITY_INSERT [dbo].[tbl_bankAccount] ON 

INSERT [dbo].[tbl_bankAccount] ([id], [bank_code], [bank_name], [account_no], [bank_opening_balance]) VALUES (1, N'Bank01', N'PubaliBank', N'a123', 14500)
INSERT [dbo].[tbl_bankAccount] ([id], [bank_code], [bank_name], [account_no], [bank_opening_balance]) VALUES (2, N'Bank02', N'SonaliBank', N'b456', 450405010)
INSERT [dbo].[tbl_bankAccount] ([id], [bank_code], [bank_name], [account_no], [bank_opening_balance]) VALUES (3, N'Bank03', N'CityBank', N'c789', 4000)
SET IDENTITY_INSERT [dbo].[tbl_bankAccount] OFF
SET IDENTITY_INSERT [dbo].[tbl_bankDeposit] ON 

INSERT [dbo].[tbl_bankDeposit] ([id], [date], [bank_id], [mode], [party_bank_name], [check_no], [district_id], [party_id], [amount]) VALUES (1, N'02/23/2016', 1, N'Cash', N'A', N'a123', 1, 1, 400)
INSERT [dbo].[tbl_bankDeposit] ([id], [date], [bank_id], [mode], [party_bank_name], [check_no], [district_id], [party_id], [amount]) VALUES (2, N'02/25/2016', 2, N'Online', N'B', N'b4785', 3, 3, 6000)
INSERT [dbo].[tbl_bankDeposit] ([id], [date], [bank_id], [mode], [party_bank_name], [check_no], [district_id], [party_id], [amount]) VALUES (3, N'02/28/2016', 1, N'Check', N'C', N'c8925', 4, 1, 8000)
SET IDENTITY_INSERT [dbo].[tbl_bankDeposit] OFF
SET IDENTITY_INSERT [dbo].[tbl_bankWithdraw] ON 

INSERT [dbo].[tbl_bankWithdraw] ([id], [date], [bank_id], [check_no], [withdrawBy], [amount]) VALUES (1, N'02/23/2016', 1, N'ch012345', N'Samiul Islam', 40000)
INSERT [dbo].[tbl_bankWithdraw] ([id], [date], [bank_id], [check_no], [withdrawBy], [amount]) VALUES (2, N'02/24/2016', 2, N'ch456789', N'Motiur Rahman', 7000)
INSERT [dbo].[tbl_bankWithdraw] ([id], [date], [bank_id], [check_no], [withdrawBy], [amount]) VALUES (3, N'02/25/2016', 3, N'ch789654', N'Mynul Hauque', 12300)
SET IDENTITY_INSERT [dbo].[tbl_bankWithdraw] OFF
SET IDENTITY_INSERT [dbo].[tbl_binder] ON 

INSERT [dbo].[tbl_binder] ([id], [binder_code], [binder_name], [binder_address], [binder_opening_balance]) VALUES (1, N'Bin01', N'AB', N'Dhaka', 0)
INSERT [dbo].[tbl_binder] ([id], [binder_code], [binder_name], [binder_address], [binder_opening_balance]) VALUES (2, N'Bin02', N'CD', N'Comilla', 200)
INSERT [dbo].[tbl_binder] ([id], [binder_code], [binder_name], [binder_address], [binder_opening_balance]) VALUES (3, N'Bin03', N'EF', N'Chittagong', 300)
INSERT [dbo].[tbl_binder] ([id], [binder_code], [binder_name], [binder_address], [binder_opening_balance]) VALUES (4, N'Bin04', N'GH', N'Syllet', 400)
SET IDENTITY_INSERT [dbo].[tbl_binder] OFF
SET IDENTITY_INSERT [dbo].[tbl_binderOrder] ON 

INSERT [dbo].[tbl_binderOrder] ([id], [date], [year], [order_no], [binder_id], [group_id], [book_id], [quantity], [forma_quantity], [press_id], [forma]) VALUES (1, N'02/25/2016', N'2016', N'Or01', 1, 1, 1, 100, 50, 1, 20)
INSERT [dbo].[tbl_binderOrder] ([id], [date], [year], [order_no], [binder_id], [group_id], [book_id], [quantity], [forma_quantity], [press_id], [forma]) VALUES (2, N'02/26/2016', N'2015', N'Or02', 2, 2, 2, 200, 100, 2, 90)
INSERT [dbo].[tbl_binderOrder] ([id], [date], [year], [order_no], [binder_id], [group_id], [book_id], [quantity], [forma_quantity], [press_id], [forma]) VALUES (3, N'02/27/2016', N'2014', N'Or03', 3, 3, 3, 300, 200, 3, 120)
INSERT [dbo].[tbl_binderOrder] ([id], [date], [year], [order_no], [binder_id], [group_id], [book_id], [quantity], [forma_quantity], [press_id], [forma]) VALUES (4, N'02/28/2016', N'2013', N'Or04', 4, 1, 4, 400, 250, 1, 220)
SET IDENTITY_INSERT [dbo].[tbl_binderOrder] OFF
SET IDENTITY_INSERT [dbo].[tbl_binderOrderCancel] ON 

INSERT [dbo].[tbl_binderOrderCancel] ([id], [date], [year], [binder_id], [order_no], [group_id], [book_id], [quantity]) VALUES (1, N'02/25/2016', N'2016', 1, N'Or01', 1, 1, 100)
INSERT [dbo].[tbl_binderOrderCancel] ([id], [date], [year], [binder_id], [order_no], [group_id], [book_id], [quantity]) VALUES (2, N'02/26/2016', N'2015', 2, N'Or02', 2, 2, 200)
INSERT [dbo].[tbl_binderOrderCancel] ([id], [date], [year], [binder_id], [order_no], [group_id], [book_id], [quantity]) VALUES (3, N'02/27/2016', N'2014', 3, N'Or03', 3, 3, 300)
SET IDENTITY_INSERT [dbo].[tbl_binderOrderCancel] OFF
SET IDENTITY_INSERT [dbo].[tbl_binderReceive] ON 

INSERT [dbo].[tbl_binderReceive] ([id], [date], [receive_no], [binder_id], [order_no], [challan_no], [year], [group_id], [book_id], [quantity]) VALUES (1, N'02/25/2016', N'Rc-001', 1, N'o123', N'c123', N'2016', 1, 1, 100)
INSERT [dbo].[tbl_binderReceive] ([id], [date], [receive_no], [binder_id], [order_no], [challan_no], [year], [group_id], [book_id], [quantity]) VALUES (2, N'02/26/2016', N'Rc-002', 2, N'o456', N'c456', N'2015', 2, 2, 200)
INSERT [dbo].[tbl_binderReceive] ([id], [date], [receive_no], [binder_id], [order_no], [challan_no], [year], [group_id], [book_id], [quantity]) VALUES (3, N'02/27/2016', N'Rc-003', 3, N'o789', N'c789', N'2014', 3, 3, 300)
INSERT [dbo].[tbl_binderReceive] ([id], [date], [receive_no], [binder_id], [order_no], [challan_no], [year], [group_id], [book_id], [quantity]) VALUES (4, N'02/27/2016', N'Rc-003', 3, N'o789', N'c789', N'2014', 3, 3, 300)
INSERT [dbo].[tbl_binderReceive] ([id], [date], [receive_no], [binder_id], [order_no], [challan_no], [year], [group_id], [book_id], [quantity]) VALUES (5, N'03/15/2016', N'Rc-004', 4, N'o1054', N'c789', N'2010', 3, 3, 2050)
SET IDENTITY_INSERT [dbo].[tbl_binderReceive] OFF
SET IDENTITY_INSERT [dbo].[tbl_bonus] ON 

INSERT [dbo].[tbl_bonus] ([id], [date], [district_id], [party_id], [amount]) VALUES (1, N'03/01/2016', 1, 1, 5000)
INSERT [dbo].[tbl_bonus] ([id], [date], [district_id], [party_id], [amount]) VALUES (2, N'03/02/2016', 2, 2, 2000)
INSERT [dbo].[tbl_bonus] ([id], [date], [district_id], [party_id], [amount]) VALUES (3, N'03/05/2016', 2, 4, 6000)
SET IDENTITY_INSERT [dbo].[tbl_bonus] OFF
SET IDENTITY_INSERT [dbo].[tbl_book_info] ON 

INSERT [dbo].[tbl_book_info] ([id], [book_code], [book_name], [book_size], [book_forma], [book_inar], [press_id], [binder_id], [main_book_id], [book_rate], [book_return_rate], [book_commission], [book_opening_balance], [book_status]) VALUES (1, N'Book01', N'Bangla', N'10', 10, 14, 1, 1, 1, 120, 0, 10, 200, N'No Comment')
INSERT [dbo].[tbl_book_info] ([id], [book_code], [book_name], [book_size], [book_forma], [book_inar], [press_id], [binder_id], [main_book_id], [book_rate], [book_return_rate], [book_commission], [book_opening_balance], [book_status]) VALUES (2, N'Book02', N'English', N'20', 0, 10, 2, 2, 2, 220, 0, 20, 300, N'No Comment')
INSERT [dbo].[tbl_book_info] ([id], [book_code], [book_name], [book_size], [book_forma], [book_inar], [press_id], [binder_id], [main_book_id], [book_rate], [book_return_rate], [book_commission], [book_opening_balance], [book_status]) VALUES (3, N'Book03', N'Mathmathices', N'05', 15, 12, 3, 3, 3, 320, 5, 15, 100, N'Not Good')
INSERT [dbo].[tbl_book_info] ([id], [book_code], [book_name], [book_size], [book_forma], [book_inar], [press_id], [binder_id], [main_book_id], [book_rate], [book_return_rate], [book_commission], [book_opening_balance], [book_status]) VALUES (4, N'Book04', N'Islamic', N'45Kb', 10, 20, 3, 4, 3, 320, 0, 25, 310, N'Not Good')
SET IDENTITY_INSERT [dbo].[tbl_book_info] OFF
SET IDENTITY_INSERT [dbo].[tbl_bookReject] ON 

INSERT [dbo].[tbl_bookReject] ([id], [date], [district_id], [party_id], [reject_no], [year], [group_id], [book_id], [quantity], [reject_rate], [total]) VALUES (1, N'03/07/2016', 1, 1, N'Rj-001', N'2016', 2, 2, 100, 44, 4400)
INSERT [dbo].[tbl_bookReject] ([id], [date], [district_id], [party_id], [reject_no], [year], [group_id], [book_id], [quantity], [reject_rate], [total]) VALUES (2, N'03/08/2016', 4, 3, N'Rj-002', N'2014', 3, 3, 10, 48, 480)
INSERT [dbo].[tbl_bookReject] ([id], [date], [district_id], [party_id], [reject_no], [year], [group_id], [book_id], [quantity], [reject_rate], [total]) VALUES (3, N'03/09/2016', 2, 4, N'Rj-003', N'2015', 1, 1, 200, 12, 2400)
SET IDENTITY_INSERT [dbo].[tbl_bookReject] OFF
SET IDENTITY_INSERT [dbo].[tbl_bookReturn] ON 

INSERT [dbo].[tbl_bookReturn] ([id], [date], [district_id], [party_id], [return_no], [challan_return], [year], [group_id], [book_id], [quantity], [return_rate], [total], [transport_bill], [less], [net_return]) VALUES (1, N'03/08/2016', 1, 2, N'R-001', N'Yes', N'2016', 1, 1, 5, 12, 60, 10, 30, 40)
INSERT [dbo].[tbl_bookReturn] ([id], [date], [district_id], [party_id], [return_no], [challan_return], [year], [group_id], [book_id], [quantity], [return_rate], [total], [transport_bill], [less], [net_return]) VALUES (2, N'03/09/2016', 2, 3, N'R-002', N'No', N'2014', 2, 2, 100, 44, 4400, 10.5, 21.5, 4389)
INSERT [dbo].[tbl_bookReturn] ([id], [date], [district_id], [party_id], [return_no], [challan_return], [year], [group_id], [book_id], [quantity], [return_rate], [total], [transport_bill], [less], [net_return]) VALUES (3, N'03/10/2016', 4, 4, N'R-003', N'Yes', N'2015', 3, 4, 200, 80, 16000, 20, 100.5, 15919.5)
SET IDENTITY_INSERT [dbo].[tbl_bookReturn] OFF
SET IDENTITY_INSERT [dbo].[tbl_bookSales] ON 

INSERT [dbo].[tbl_bookSales] ([id], [date], [district_id], [party_id], [memo_no], [sales_type], [year], [group_id], [book_id], [quantity], [sales_rate], [total], [packing], [bonus], [total_price], [payment_amount], [dues]) VALUES (1, N'03/07/2016', 1, 1, N'M-001', N'Normal', N'2016', 1, 1, 5, 12, 60, 60, 50, 70, 200, -130)
INSERT [dbo].[tbl_bookSales] ([id], [date], [district_id], [party_id], [memo_no], [sales_type], [year], [group_id], [book_id], [quantity], [sales_rate], [total], [packing], [bonus], [total_price], [payment_amount], [dues]) VALUES (2, N'03/08/2016', 2, 2, N'M-002', N'Anything', N'2014', 2, 2, 100, 44, 4400, 600, 300, 4700, 300, 4400)
INSERT [dbo].[tbl_bookSales] ([id], [date], [district_id], [party_id], [memo_no], [sales_type], [year], [group_id], [book_id], [quantity], [sales_rate], [total], [packing], [bonus], [total_price], [payment_amount], [dues]) VALUES (3, N'03/09/2016', 4, 4, N'M-003', N'Normal', N'2015', 3, 4, 200, 80, 16000, 500.5, 2000, 14500.5, 1450.54, 13049.96)
INSERT [dbo].[tbl_bookSales] ([id], [date], [district_id], [party_id], [memo_no], [sales_type], [year], [group_id], [book_id], [quantity], [sales_rate], [total], [packing], [bonus], [total_price], [payment_amount], [dues]) VALUES (4, N'03/31/2016', 2, 1, N'M-004', N'Normal', N'2010', 3, 1, 400, 12, 4800, 600, 550, 4850, 200, 4650)
SET IDENTITY_INSERT [dbo].[tbl_bookSales] OFF
SET IDENTITY_INSERT [dbo].[tbl_bookSpeciman] ON 

INSERT [dbo].[tbl_bookSpeciman] ([id], [date], [district_id], [party_id], [memo_no], [year], [group_id], [book_id], [quantity], [rate], [total]) VALUES (1, N'03/08/2016', 1, 2, N'M-001', N'2016', 2, 2, 100, 44, 4400)
INSERT [dbo].[tbl_bookSpeciman] ([id], [date], [district_id], [party_id], [memo_no], [year], [group_id], [book_id], [quantity], [rate], [total]) VALUES (2, N'03/09/2016', 3, 3, N'M-002', N'2014', 3, 3, 10, 48, 480)
INSERT [dbo].[tbl_bookSpeciman] ([id], [date], [district_id], [party_id], [memo_no], [year], [group_id], [book_id], [quantity], [rate], [total]) VALUES (3, N'03/10/2016', 4, 4, N'M-003', N'2015', 1, 4, 200, 80, 16000)
SET IDENTITY_INSERT [dbo].[tbl_bookSpeciman] OFF
SET IDENTITY_INSERT [dbo].[tbl_coverReceived] ON 

INSERT [dbo].[tbl_coverReceived] ([id], [date], [receive_no], [year], [group_id], [book_id], [quantity]) VALUES (1, N'02/27/2016', N'Rc-001', N'2016      ', 1, 1, 100)
INSERT [dbo].[tbl_coverReceived] ([id], [date], [receive_no], [year], [group_id], [book_id], [quantity]) VALUES (2, N'02/28/2016', N'Rc-002', N'2014      ', 2, 2, 200)
INSERT [dbo].[tbl_coverReceived] ([id], [date], [receive_no], [year], [group_id], [book_id], [quantity]) VALUES (3, N'02/29/2016', N'Rc-003', N'2015      ', 3, 3, 300)
SET IDENTITY_INSERT [dbo].[tbl_coverReceived] OFF
SET IDENTITY_INSERT [dbo].[tbl_coverSupply] ON 

INSERT [dbo].[tbl_coverSupply] ([id], [date], [supply_no], [binder_id], [group_id], [book_id], [quantity]) VALUES (1, N'02/27/2016', N'Supp-001', 2, 2, 3, 100)
INSERT [dbo].[tbl_coverSupply] ([id], [date], [supply_no], [binder_id], [group_id], [book_id], [quantity]) VALUES (2, N'02/28/2016', N'Supp-002', 3, 3, 4, 200)
INSERT [dbo].[tbl_coverSupply] ([id], [date], [supply_no], [binder_id], [group_id], [book_id], [quantity]) VALUES (3, N'02/29/2016', N'Supp-003', 1, 1, 1, 300)
INSERT [dbo].[tbl_coverSupply] ([id], [date], [supply_no], [binder_id], [group_id], [book_id], [quantity]) VALUES (4, N'03/07/2016', N'Supp-004', 4, 3, 3, 400)
SET IDENTITY_INSERT [dbo].[tbl_coverSupply] OFF
SET IDENTITY_INSERT [dbo].[tbl_district] ON 

INSERT [dbo].[tbl_district] ([id], [district_code], [district_name], [division_id]) VALUES (1, N'Dis01', N'Comilla', 1)
INSERT [dbo].[tbl_district] ([id], [district_code], [district_name], [division_id]) VALUES (2, N'Dis02', N'Feni', 2)
INSERT [dbo].[tbl_district] ([id], [district_code], [district_name], [division_id]) VALUES (3, N'Dis03', N'Badda', 3)
INSERT [dbo].[tbl_district] ([id], [district_code], [district_name], [division_id]) VALUES (4, N'Dis04', N'Rampura', 4)
SET IDENTITY_INSERT [dbo].[tbl_district] OFF
SET IDENTITY_INSERT [dbo].[tbl_division] ON 

INSERT [dbo].[tbl_division] ([id], [division_code], [division_name]) VALUES (1, N'Div01', N'Dhaka')
INSERT [dbo].[tbl_division] ([id], [division_code], [division_name]) VALUES (2, N'Div02', N' Chittagong')
INSERT [dbo].[tbl_division] ([id], [division_code], [division_name]) VALUES (3, N'Div03', N'Rajshai')
INSERT [dbo].[tbl_division] ([id], [division_code], [division_name]) VALUES (4, N'Div04', N'Rangpur')
INSERT [dbo].[tbl_division] ([id], [division_code], [division_name]) VALUES (5, N'Div05', N'Tarashail')
SET IDENTITY_INSERT [dbo].[tbl_division] OFF
SET IDENTITY_INSERT [dbo].[tbl_employee] ON 

INSERT [dbo].[tbl_employee] ([id], [employee_code], [employee_name], [employee_nationalId], [employee_contactNo], [employee_address], [employee_basic_salary], [employee_opening_balance]) VALUES (1, N'Emp01', N'Omar Faruk', 123456, N'01688399348', N'afsadkfjak', 10000, 520)
INSERT [dbo].[tbl_employee] ([id], [employee_code], [employee_name], [employee_nationalId], [employee_contactNo], [employee_address], [employee_basic_salary], [employee_opening_balance]) VALUES (2, N'Emp02', N'Sumon', 456789, N'01831157572', N'Dhaka', 15000, 450)
INSERT [dbo].[tbl_employee] ([id], [employee_code], [employee_name], [employee_nationalId], [employee_contactNo], [employee_address], [employee_basic_salary], [employee_opening_balance]) VALUES (3, N'Emp03', N'Tanvir', 1234567, N'01688399348a', N'sdfsadf', 15000, 520)
INSERT [dbo].[tbl_employee] ([id], [employee_code], [employee_name], [employee_nationalId], [employee_contactNo], [employee_address], [employee_basic_salary], [employee_opening_balance]) VALUES (4, N'Emp04', N'Motiur', 7896, N'01688399348', N'afsdfds', 20000, 520)
INSERT [dbo].[tbl_employee] ([id], [employee_code], [employee_name], [employee_nationalId], [employee_contactNo], [employee_address], [employee_basic_salary], [employee_opening_balance]) VALUES (5, N'Emp05', N'Samiul', 1234568, N'01688399348', N'ghhf', 15000, 520)
INSERT [dbo].[tbl_employee] ([id], [employee_code], [employee_name], [employee_nationalId], [employee_contactNo], [employee_address], [employee_basic_salary], [employee_opening_balance]) VALUES (6, N'Emp06', N'Mynul Hauque', 78963, N'0183575757', N'Chauddagram', 40000, 50000)
SET IDENTITY_INSERT [dbo].[tbl_employee] OFF
SET IDENTITY_INSERT [dbo].[tbl_employee_salary_entry] ON 

INSERT [dbo].[tbl_employee_salary_entry] ([id], [employee_date], [employee_year], [employee_month], [employee_id], [salary_reduce], [bonus], [salary], [remarks]) VALUES (1, N'1900-01-01', 2016, N'January', 1, 1050, 50, 12000, N'Bonus')
INSERT [dbo].[tbl_employee_salary_entry] ([id], [employee_date], [employee_year], [employee_month], [employee_id], [salary_reduce], [bonus], [salary], [remarks]) VALUES (5, N'02/19/2016', 2016, N'December', 5, 550, 300, 15000, N'Bonus')
INSERT [dbo].[tbl_employee_salary_entry] ([id], [employee_date], [employee_year], [employee_month], [employee_id], [salary_reduce], [bonus], [salary], [remarks]) VALUES (6, N'02/20/2016', 2016, N'November', 4, 2110, 300, 10000, N'Overtime')
INSERT [dbo].[tbl_employee_salary_entry] ([id], [employee_date], [employee_year], [employee_month], [employee_id], [salary_reduce], [bonus], [salary], [remarks]) VALUES (7, N'02/21/2016', 2014, N'October', 3, 15000, 100, 200000, N'Bonus')
SET IDENTITY_INSERT [dbo].[tbl_employee_salary_entry] OFF
SET IDENTITY_INSERT [dbo].[tbl_employeeSalaryPayment] ON 

INSERT [dbo].[tbl_employeeSalaryPayment] ([id], [date], [year], [month], [employee_id], [payment_mode], [bank_id], [check_no], [check_date], [amount], [remarks]) VALUES (1, N'02/23/2016', 2016, N'January   ', 3, N'Cash', 2, N'ch012345', N'02/23/2016', 10000, N'Bonus')
INSERT [dbo].[tbl_employeeSalaryPayment] ([id], [date], [year], [month], [employee_id], [payment_mode], [bank_id], [check_no], [check_date], [amount], [remarks]) VALUES (2, N'02/25/2016', 2014, N'February  ', 2, N'Cash', 1, N'ch456789', N'02/25/2016', 8000, N'Overtime')
INSERT [dbo].[tbl_employeeSalaryPayment] ([id], [date], [year], [month], [employee_id], [payment_mode], [bank_id], [check_no], [check_date], [amount], [remarks]) VALUES (3, N'02/26/2016', 2015, N'March     ', 4, N'Check', 2, N'ch012345', N'02/26/2016', 2000, N'Bonus')
INSERT [dbo].[tbl_employeeSalaryPayment] ([id], [date], [year], [month], [employee_id], [payment_mode], [bank_id], [check_no], [check_date], [amount], [remarks]) VALUES (4, N'02/29/2016', 2010, N'December', 5, N'Check', 2, N'ch012345', N'02/29/2016', 8000, N'Overtime')
SET IDENTITY_INSERT [dbo].[tbl_employeeSalaryPayment] OFF
SET IDENTITY_INSERT [dbo].[tbl_group] ON 

INSERT [dbo].[tbl_group] ([id], [group_code], [group_name]) VALUES (1, N'Grp01', N'Science')
INSERT [dbo].[tbl_group] ([id], [group_code], [group_name]) VALUES (2, N'Grp02', N'Commerce')
INSERT [dbo].[tbl_group] ([id], [group_code], [group_name]) VALUES (3, N'Grp03', N'Social')
SET IDENTITY_INSERT [dbo].[tbl_group] OFF
SET IDENTITY_INSERT [dbo].[tbl_loan] ON 

INSERT [dbo].[tbl_loan] ([id], [loan_code], [loan_name], [remarks]) VALUES (1, 1, N'A', N'No Remarks')
INSERT [dbo].[tbl_loan] ([id], [loan_code], [loan_name], [remarks]) VALUES (2, 2, N'B', N'No Yet Com')
SET IDENTITY_INSERT [dbo].[tbl_loan] OFF
SET IDENTITY_INSERT [dbo].[tbl_main_book] ON 

INSERT [dbo].[tbl_main_book] ([id], [main_book_code], [main_book_name], [main_book_class]) VALUES (1, N'MBC01', N'A', N'Five')
INSERT [dbo].[tbl_main_book] ([id], [main_book_code], [main_book_name], [main_book_class]) VALUES (2, N'MBC02', N'B', N'Six')
INSERT [dbo].[tbl_main_book] ([id], [main_book_code], [main_book_name], [main_book_class]) VALUES (3, N'MBC03', N'C', N'Seven')
SET IDENTITY_INSERT [dbo].[tbl_main_book] OFF
SET IDENTITY_INSERT [dbo].[tbl_moneyReceipt] ON 

INSERT [dbo].[tbl_moneyReceipt] ([id], [date], [mr_no], [district_id], [party_id], [mode], [cheque_no], [cheque_date], [bank_id], [branch_name], [amount], [remarks]) VALUES (1, N'03/01/2016', N'Mr-001', 1, 1, N'Cash', N'Ch-001', N'03/02/2016', 1, N'Badda Branch', 50000, N'No Comment')
INSERT [dbo].[tbl_moneyReceipt] ([id], [date], [mr_no], [district_id], [party_id], [mode], [cheque_no], [cheque_date], [bank_id], [branch_name], [amount], [remarks]) VALUES (2, N'03/02/2016', N'Mr-002', 2, 2, N'Cheque', N'Ch-002', N'03/02/2016', 2, N'Malibug Branch', 40000, N'Bed comment')
INSERT [dbo].[tbl_moneyReceipt] ([id], [date], [mr_no], [district_id], [party_id], [mode], [cheque_no], [cheque_date], [bank_id], [branch_name], [amount], [remarks]) VALUES (3, N'03/03/2016', N'Mr-003', 3, 3, N'Online', N'Ch-003', N'03/04/2016', 3, N'Rampura Branch', 20000, N'Good Comment')
INSERT [dbo].[tbl_moneyReceipt] ([id], [date], [mr_no], [district_id], [party_id], [mode], [cheque_no], [cheque_date], [bank_id], [branch_name], [amount], [remarks]) VALUES (4, N'03/16/2016', N'Mr-004', 4, 4, N'T.T', N'Ch-004', N'03/18/2016', 3, N'Tarashail', 500000, N'No Comment')
INSERT [dbo].[tbl_moneyReceipt] ([id], [date], [mr_no], [district_id], [party_id], [mode], [cheque_no], [cheque_date], [bank_id], [branch_name], [amount], [remarks]) VALUES (5, N'03/20/2016', N'Mr-005', 3, 2, N'Online', N'Ch-005', N'03/20/2016', 3, N'Chouddagram', 15000, N'Good Comment')
SET IDENTITY_INSERT [dbo].[tbl_moneyReceipt] OFF
SET IDENTITY_INSERT [dbo].[tbl_other_group] ON 

INSERT [dbo].[tbl_other_group] ([id], [other_group_code], [other_group_name], [other_group_remarks], [group_id]) VALUES (1, N'OG01', N'ABC', N'fsdalfkjdk', 1)
INSERT [dbo].[tbl_other_group] ([id], [other_group_code], [other_group_name], [other_group_remarks], [group_id]) VALUES (2, N'OG02', N'XYZ', N'sadfrwerf', 2)
INSERT [dbo].[tbl_other_group] ([id], [other_group_code], [other_group_name], [other_group_remarks], [group_id]) VALUES (3, N'OG03', N'IJK', N'dfalfjlasdfjowqe', 3)
SET IDENTITY_INSERT [dbo].[tbl_other_group] OFF
SET IDENTITY_INSERT [dbo].[tbl_otherBillPayment] ON 

INSERT [dbo].[tbl_otherBillPayment] ([id], [date], [other_name_id], [payment_mode], [bank_id], [check_no], [check_date], [amount], [remarks]) VALUES (1, N'02/23/2016', 2, N'Cash', 2, N'ch456789', N'02/23/2016', 10000, N'dfgds')
INSERT [dbo].[tbl_otherBillPayment] ([id], [date], [other_name_id], [payment_mode], [bank_id], [check_no], [check_date], [amount], [remarks]) VALUES (2, N'02/22/2016', 1, N'Cash', 1, N'ch012345', N'02/22/2016', 5000, N'ewrwerw')
INSERT [dbo].[tbl_otherBillPayment] ([id], [date], [other_name_id], [payment_mode], [bank_id], [check_no], [check_date], [amount], [remarks]) VALUES (3, N'02/24/2016', 3, N'Check', 2, N'ch012345', N'02/25/2016', 2000, N'cvvcvbv')
INSERT [dbo].[tbl_otherBillPayment] ([id], [date], [other_name_id], [payment_mode], [bank_id], [check_no], [check_date], [amount], [remarks]) VALUES (5, N'02/29/2016', 3, N'Check', 1, N'ch012345', N'02/29/2016', 2000, N'mbnmbnm')
INSERT [dbo].[tbl_otherBillPayment] ([id], [date], [other_name_id], [payment_mode], [bank_id], [check_no], [check_date], [amount], [remarks]) VALUES (6, N'02/28/2016', 3, N'Cash', 3, N'ch789654', N'02/28/2016', 6000, N'sfsadfksadf')
SET IDENTITY_INSERT [dbo].[tbl_otherBillPayment] OFF
SET IDENTITY_INSERT [dbo].[tbl_paper] ON 

INSERT [dbo].[tbl_paper] ([id], [paper_code], [paper_name]) VALUES (1, N'P01', N'Daily Star')
INSERT [dbo].[tbl_paper] ([id], [paper_code], [paper_name]) VALUES (2, N'P02', N'NewsPortal')
INSERT [dbo].[tbl_paper] ([id], [paper_code], [paper_name]) VALUES (3, N'P03', N'ABC')
INSERT [dbo].[tbl_paper] ([id], [paper_code], [paper_name]) VALUES (4, N'P04', N'Daily Star')
SET IDENTITY_INSERT [dbo].[tbl_paper] OFF
SET IDENTITY_INSERT [dbo].[tbl_paperOrder] ON 

INSERT [dbo].[tbl_paperOrder] ([id], [date], [supplier_id], [slip_no], [press_id], [paper_id], [paper_type], [quantity]) VALUES (1, N'02/29/2016', 1, N'Sl-001', 1, 1, N'D/D', 100)
INSERT [dbo].[tbl_paperOrder] ([id], [date], [supplier_id], [slip_no], [press_id], [paper_id], [paper_type], [quantity]) VALUES (2, N'03/01/2016', 2, N'Sl-002', 2, 2, N'D/C', 200)
INSERT [dbo].[tbl_paperOrder] ([id], [date], [supplier_id], [slip_no], [press_id], [paper_id], [paper_type], [quantity]) VALUES (3, N'03/02/2016', 1, N'Sl-003', 3, 3, N'S/D', 300)
SET IDENTITY_INSERT [dbo].[tbl_paperOrder] OFF
SET IDENTITY_INSERT [dbo].[tbl_paperPrint] ON 

INSERT [dbo].[tbl_paperPrint] ([id], [date], [order_no], [press_id], [year], [printing_type], [group_id], [book_id], [plate], [forma], [forma_type], [color_type], [paper_id], [paper_type], [book_quantity], [paper_quantity]) VALUES (1, N'02/28/2016', N'Or01', 1, N'2016', N'Book', 1, 1, 50, 25, N'A', N'White', 1, N'D/D', 10, 10)
INSERT [dbo].[tbl_paperPrint] ([id], [date], [order_no], [press_id], [year], [printing_type], [group_id], [book_id], [plate], [forma], [forma_type], [color_type], [paper_id], [paper_type], [book_quantity], [paper_quantity]) VALUES (2, N'02/29/2016', N'Or02', 2, N'2014', N'Others', 2, 3, 100, 75, N'B', N'Black', 2, N'D/C', 20, 30)
INSERT [dbo].[tbl_paperPrint] ([id], [date], [order_no], [press_id], [year], [printing_type], [group_id], [book_id], [plate], [forma], [forma_type], [color_type], [paper_id], [paper_type], [book_quantity], [paper_quantity]) VALUES (3, N'03/01/2016', N'Or03', 3, N'2015', N'Book', 3, 4, 120, 100, N'D', N'Green', 4, N'S/D', 30, 30)
SET IDENTITY_INSERT [dbo].[tbl_paperPrint] OFF
SET IDENTITY_INSERT [dbo].[tbl_paperTransfer] ON 

INSERT [dbo].[tbl_paperTransfer] ([id], [date], [transfer_no], [from_press_id], [to_press_id], [paper_id], [paper_type], [quantity]) VALUES (1, N'02/28/2016', N'Tr-001', 1, 2, 1, N'D/D', 100)
INSERT [dbo].[tbl_paperTransfer] ([id], [date], [transfer_no], [from_press_id], [to_press_id], [paper_id], [paper_type], [quantity]) VALUES (2, N'02/29/2016', N'Tr-002', 2, 3, 3, N'S/D', 200)
INSERT [dbo].[tbl_paperTransfer] ([id], [date], [transfer_no], [from_press_id], [to_press_id], [paper_id], [paper_type], [quantity]) VALUES (3, N'03/01/2016', N'Tr-003', 3, 1, 4, N'S/D', 300)
INSERT [dbo].[tbl_paperTransfer] ([id], [date], [transfer_no], [from_press_id], [to_press_id], [paper_id], [paper_type], [quantity]) VALUES (4, N'03/05/2016', N'Tr-004', 3, 1, 4, N'S/D', 10)
SET IDENTITY_INSERT [dbo].[tbl_paperTransfer] OFF
SET IDENTITY_INSERT [dbo].[tbl_party] ON 

INSERT [dbo].[tbl_party] ([id], [district_id], [party_code], [party_name], [party_propitor], [party_address], [party_phone], [party_email], [party_web], [party_opening_balance], [party_date]) VALUES (1, 1, N'Pa01', N'ABC', N'Kamrul Islam', N'Dhaka', N'01831157572', N'mofc@gmail.com', N'google.com', 120, CAST(0xE83A0B00 AS Date))
INSERT [dbo].[tbl_party] ([id], [district_id], [party_code], [party_name], [party_propitor], [party_address], [party_phone], [party_email], [party_web], [party_opening_balance], [party_date]) VALUES (2, 1, N'Pa02', N'DEF', N'Milon Khan', N'Comilla', N'01688399348', N'mofcit440@gmail.com', N'youtube.com', 450, CAST(0xE83A0B00 AS Date))
INSERT [dbo].[tbl_party] ([id], [district_id], [party_code], [party_name], [party_propitor], [party_address], [party_phone], [party_email], [party_web], [party_opening_balance], [party_date]) VALUES (3, 2, N'Pa03', N'Parfect', N'Monir khan', N'chittagong', N'01831157572', N'mo@gmail.com', N'facebook.com', 50, CAST(0xE93A0B00 AS Date))
INSERT [dbo].[tbl_party] ([id], [district_id], [party_code], [party_name], [party_propitor], [party_address], [party_phone], [party_email], [party_web], [party_opening_balance], [party_date]) VALUES (4, 3, N'Pa04', N'GHI', N'Hanif Sarder', N'Rajshai', N'01688399348', N'ha@gmail.com', N'twitter.com', 100, CAST(0xED3A0B00 AS Date))
SET IDENTITY_INSERT [dbo].[tbl_party] OFF
SET IDENTITY_INSERT [dbo].[tbl_personalLoanPayment] ON 

INSERT [dbo].[tbl_personalLoanPayment] ([id], [date], [loan_type], [party_id], [amount]) VALUES (2, N'02/22/2016', N'Payment', 2, 5000)
INSERT [dbo].[tbl_personalLoanPayment] ([id], [date], [loan_type], [party_id], [amount]) VALUES (3, N'02/23/2016', N'Loan Takan', 4, 10000)
INSERT [dbo].[tbl_personalLoanPayment] ([id], [date], [loan_type], [party_id], [amount]) VALUES (4, N'02/24/2016', N'Payment', 3, 2000)
SET IDENTITY_INSERT [dbo].[tbl_personalLoanPayment] OFF
SET IDENTITY_INSERT [dbo].[tbl_ppLimination] ON 

INSERT [dbo].[tbl_ppLimination] ([id], [pplimination_code], [pplimination_name], [pplimination_address], [pplimination_opening_balance]) VALUES (1, N'PPL01', N'Plate', N'afdaf', 1203)
INSERT [dbo].[tbl_ppLimination] ([id], [pplimination_code], [pplimination_name], [pplimination_address], [pplimination_opening_balance]) VALUES (2, N'PPL02', N'DEF', N'Comilla', 7890)
SET IDENTITY_INSERT [dbo].[tbl_ppLimination] OFF
SET IDENTITY_INSERT [dbo].[tbl_press] ON 

INSERT [dbo].[tbl_press] ([id], [press_code], [press_name], [press_address], [press_opening_balance]) VALUES (1, N'Pr01', N'DEF', N'safas', N'50')
INSERT [dbo].[tbl_press] ([id], [press_code], [press_name], [press_address], [press_opening_balance]) VALUES (2, N'Pr02', N'EFG', N'afa', N'78920')
INSERT [dbo].[tbl_press] ([id], [press_code], [press_name], [press_address], [press_opening_balance]) VALUES (3, N'Pr03', N'IJK', N'faslfjasf', N'400')
SET IDENTITY_INSERT [dbo].[tbl_press] OFF
SET IDENTITY_INSERT [dbo].[tbl_shope] ON 

INSERT [dbo].[tbl_shope] ([id], [shope_code], [shope_name], [shope_phone], [shope_address], [shope_monthly_rent], [shope_opening_balance]) VALUES (1, N'Sh01', N'BowBazar', N'01688399348', N'DHaka', 120000, 200)
INSERT [dbo].[tbl_shope] ([id], [shope_code], [shope_name], [shope_phone], [shope_address], [shope_monthly_rent], [shope_opening_balance]) VALUES (2, N'Sh02', N'ABC', N'01688399348', N'afasdfsa', 4500, 120)
INSERT [dbo].[tbl_shope] ([id], [shope_code], [shope_name], [shope_phone], [shope_address], [shope_monthly_rent], [shope_opening_balance]) VALUES (4, N'Sh03', N'DEF', N'01688399348', N'gsdfsa', 7890, 1200)
INSERT [dbo].[tbl_shope] ([id], [shope_code], [shope_name], [shope_phone], [shope_address], [shope_monthly_rent], [shope_opening_balance]) VALUES (5, N'Sh04', N'fgbsdg', N'01688399348', N'gdfga', 7890, 10)
SET IDENTITY_INSERT [dbo].[tbl_shope] OFF
SET IDENTITY_INSERT [dbo].[tbl_spacymenParty] ON 

INSERT [dbo].[tbl_spacymenParty] ([id], [district_id], [spacymenParty_code], [spacymenParty_name], [spacymenParty_address], [school_name]) VALUES (1, 1, N'Spc01', N'ABC', N'SDFASF', N'Tarashail High School')
INSERT [dbo].[tbl_spacymenParty] ([id], [district_id], [spacymenParty_code], [spacymenParty_name], [spacymenParty_address], [school_name]) VALUES (2, 2, N'Spc02', N'DEF', N'SDFASF', N'Rampura High School')
INSERT [dbo].[tbl_spacymenParty] ([id], [district_id], [spacymenParty_code], [spacymenParty_name], [spacymenParty_address], [school_name]) VALUES (3, 3, N'Spc-03', N'GHI', N'Dhaka', N'Badda Zilla School')
SET IDENTITY_INSERT [dbo].[tbl_spacymenParty] OFF
SET IDENTITY_INSERT [dbo].[tbl_supplier] ON 

INSERT [dbo].[tbl_supplier] ([id], [supplier_code], [supplier_name], [supplier_address], [supplier_opening_balance]) VALUES (1, N'Supp01', N'Tonmoy', N'Chittagong', N'4563')
INSERT [dbo].[tbl_supplier] ([id], [supplier_code], [supplier_name], [supplier_address], [supplier_opening_balance]) VALUES (2, N'Supp02', N'Sumon', N'Comilla', N'780')
SET IDENTITY_INSERT [dbo].[tbl_supplier] OFF
SET IDENTITY_INSERT [dbo].[tbl_supplier_bill_entry] ON 

INSERT [dbo].[tbl_supplier_bill_entry] ([id], [supplier_date], [bill_date], [bill_no], [supplier_type], [supplier_id], [press_id], [paper_id], [paper_type], [paper_quantity], [prize], [description], [bill_amount]) VALUES (1, N'1900-01-01', N'1900-01-01', N'Bill01', N'Others', 1, 2, 3, N'D/D', 100, 1400, N'dfasfas', 1000)
INSERT [dbo].[tbl_supplier_bill_entry] ([id], [supplier_date], [bill_date], [bill_no], [supplier_type], [supplier_id], [press_id], [paper_id], [paper_type], [paper_quantity], [prize], [description], [bill_amount]) VALUES (6, N'02/18/2016', N'02/19/2016', N'Bill02', N'Paper', 1, 2, 3, N'D/D', 200, 1500, N'sddfsda', 1000)
INSERT [dbo].[tbl_supplier_bill_entry] ([id], [supplier_date], [bill_date], [bill_no], [supplier_type], [supplier_id], [press_id], [paper_id], [paper_type], [paper_quantity], [prize], [description], [bill_amount]) VALUES (7, N'02/18/2016', N'02/18/2016', N'Bill03', N'Others', 2, 3, 2, N'D/C', 100, 1500, N'sdfsfsafa', 1200)
INSERT [dbo].[tbl_supplier_bill_entry] ([id], [supplier_date], [bill_date], [bill_no], [supplier_type], [supplier_id], [press_id], [paper_id], [paper_type], [paper_quantity], [prize], [description], [bill_amount]) VALUES (8, N'02/28/2016', N'02/28/2016', N'Bill04', N'Others', 2, 2, 4, N'S/S', 100, 450, N'Hello', 700)
SET IDENTITY_INSERT [dbo].[tbl_supplier_bill_entry] OFF
SET IDENTITY_INSERT [dbo].[tbl_supplierBillPayment] ON 

INSERT [dbo].[tbl_supplierBillPayment] ([id], [date], [bill_no], [supplier_id], [payment_mode], [bank_id], [check_no], [check_date], [amount]) VALUES (1, N'03/07/2016', N'Bi-001', 1, N'Cash', 1, N'ch012345', N'03/06/2016', 5000)
INSERT [dbo].[tbl_supplierBillPayment] ([id], [date], [bill_no], [supplier_id], [payment_mode], [bank_id], [check_no], [check_date], [amount]) VALUES (2, N'03/08/2016', N'Bi-002', 2, N'Check', 2, N'ch789654', N'03/08/2016', 10000)
INSERT [dbo].[tbl_supplierBillPayment] ([id], [date], [bill_no], [supplier_id], [payment_mode], [bank_id], [check_no], [check_date], [amount]) VALUES (3, N'03/09/2016', N'Bi-003', 1, N'Cash', 1, N'ch456789', N'03/09/2016', 2000)
SET IDENTITY_INSERT [dbo].[tbl_supplierBillPayment] OFF
SET IDENTITY_INSERT [dbo].[tbl_writter] ON 

INSERT [dbo].[tbl_writter] ([id], [writter_code], [writter_name], [writter_phone], [writter_address], [writter_opening_balance]) VALUES (1, N'Wr01', N'Samiul', N'Dhaka', N'01831157575', 10)
INSERT [dbo].[tbl_writter] ([id], [writter_code], [writter_name], [writter_phone], [writter_address], [writter_opening_balance]) VALUES (2, N'Wr02', N'Motiur', N'Comilla', N'01821331943', 20)
INSERT [dbo].[tbl_writter] ([id], [writter_code], [writter_name], [writter_phone], [writter_address], [writter_opening_balance]) VALUES (3, N'Wr02', N'Motiur', N'Comilla', N'01821331943', 20)
INSERT [dbo].[tbl_writter] ([id], [writter_code], [writter_name], [writter_phone], [writter_address], [writter_opening_balance]) VALUES (4, N'Wr03', N'Sumon', N'Chittagong', N'01812362303', 30)
INSERT [dbo].[tbl_writter] ([id], [writter_code], [writter_name], [writter_phone], [writter_address], [writter_opening_balance]) VALUES (5, N'Wr04', N'Tonmoy', N'Rajshai', N'01688399348', 40)
SET IDENTITY_INSERT [dbo].[tbl_writter] OFF
ALTER TABLE [dbo].[tbl_bankDeposit]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bankDeposit_tbl_bankAccount] FOREIGN KEY([bank_id])
REFERENCES [dbo].[tbl_bankAccount] ([id])
GO
ALTER TABLE [dbo].[tbl_bankDeposit] CHECK CONSTRAINT [FK_tbl_bankDeposit_tbl_bankAccount]
GO
ALTER TABLE [dbo].[tbl_bankDeposit]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bankDeposit_tbl_district] FOREIGN KEY([district_id])
REFERENCES [dbo].[tbl_district] ([id])
GO
ALTER TABLE [dbo].[tbl_bankDeposit] CHECK CONSTRAINT [FK_tbl_bankDeposit_tbl_district]
GO
ALTER TABLE [dbo].[tbl_bankDeposit]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bankDeposit_tbl_party] FOREIGN KEY([party_id])
REFERENCES [dbo].[tbl_party] ([id])
GO
ALTER TABLE [dbo].[tbl_bankDeposit] CHECK CONSTRAINT [FK_tbl_bankDeposit_tbl_party]
GO
ALTER TABLE [dbo].[tbl_bankWithdraw]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bankWithdraw_tbl_bankAccount] FOREIGN KEY([bank_id])
REFERENCES [dbo].[tbl_bankAccount] ([id])
GO
ALTER TABLE [dbo].[tbl_bankWithdraw] CHECK CONSTRAINT [FK_tbl_bankWithdraw_tbl_bankAccount]
GO
ALTER TABLE [dbo].[tbl_binderOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderOrder_tbl_binder] FOREIGN KEY([binder_id])
REFERENCES [dbo].[tbl_binder] ([id])
GO
ALTER TABLE [dbo].[tbl_binderOrder] CHECK CONSTRAINT [FK_tbl_binderOrder_tbl_binder]
GO
ALTER TABLE [dbo].[tbl_binderOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderOrder_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_binderOrder] CHECK CONSTRAINT [FK_tbl_binderOrder_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_binderOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderOrder_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_binderOrder] CHECK CONSTRAINT [FK_tbl_binderOrder_tbl_group]
GO
ALTER TABLE [dbo].[tbl_binderOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderOrder_tbl_press] FOREIGN KEY([press_id])
REFERENCES [dbo].[tbl_press] ([id])
GO
ALTER TABLE [dbo].[tbl_binderOrder] CHECK CONSTRAINT [FK_tbl_binderOrder_tbl_press]
GO
ALTER TABLE [dbo].[tbl_binderOrderCancel]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderOrderCancel_tbl_binder] FOREIGN KEY([binder_id])
REFERENCES [dbo].[tbl_binder] ([id])
GO
ALTER TABLE [dbo].[tbl_binderOrderCancel] CHECK CONSTRAINT [FK_tbl_binderOrderCancel_tbl_binder]
GO
ALTER TABLE [dbo].[tbl_binderOrderCancel]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderOrderCancel_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_binderOrderCancel] CHECK CONSTRAINT [FK_tbl_binderOrderCancel_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_binderOrderCancel]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderOrderCancel_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_binderOrderCancel] CHECK CONSTRAINT [FK_tbl_binderOrderCancel_tbl_group]
GO
ALTER TABLE [dbo].[tbl_binderReceive]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderReceive_tbl_binder] FOREIGN KEY([binder_id])
REFERENCES [dbo].[tbl_binder] ([id])
GO
ALTER TABLE [dbo].[tbl_binderReceive] CHECK CONSTRAINT [FK_tbl_binderReceive_tbl_binder]
GO
ALTER TABLE [dbo].[tbl_binderReceive]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderReceive_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_binderReceive] CHECK CONSTRAINT [FK_tbl_binderReceive_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_binderReceive]  WITH CHECK ADD  CONSTRAINT [FK_tbl_binderReceive_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_binderReceive] CHECK CONSTRAINT [FK_tbl_binderReceive_tbl_group]
GO
ALTER TABLE [dbo].[tbl_bonus]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bonus_tbl_district] FOREIGN KEY([district_id])
REFERENCES [dbo].[tbl_district] ([id])
GO
ALTER TABLE [dbo].[tbl_bonus] CHECK CONSTRAINT [FK_tbl_bonus_tbl_district]
GO
ALTER TABLE [dbo].[tbl_bonus]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bonus_tbl_party] FOREIGN KEY([party_id])
REFERENCES [dbo].[tbl_party] ([id])
GO
ALTER TABLE [dbo].[tbl_bonus] CHECK CONSTRAINT [FK_tbl_bonus_tbl_party]
GO
ALTER TABLE [dbo].[tbl_book_info]  WITH CHECK ADD  CONSTRAINT [FK_tbl_book_info_tbl_book_info] FOREIGN KEY([main_book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_book_info] CHECK CONSTRAINT [FK_tbl_book_info_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_book_info]  WITH CHECK ADD  CONSTRAINT [FK_tbl_book_info_tbl_book_info1] FOREIGN KEY([press_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_book_info] CHECK CONSTRAINT [FK_tbl_book_info_tbl_book_info1]
GO
ALTER TABLE [dbo].[tbl_book_info]  WITH CHECK ADD  CONSTRAINT [FK_tbl_book_info_tbl_book_info2] FOREIGN KEY([binder_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_book_info] CHECK CONSTRAINT [FK_tbl_book_info_tbl_book_info2]
GO
ALTER TABLE [dbo].[tbl_bookReject]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookReject_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_bookReject] CHECK CONSTRAINT [FK_tbl_bookReject_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_bookReject]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookReject_tbl_district] FOREIGN KEY([district_id])
REFERENCES [dbo].[tbl_district] ([id])
GO
ALTER TABLE [dbo].[tbl_bookReject] CHECK CONSTRAINT [FK_tbl_bookReject_tbl_district]
GO
ALTER TABLE [dbo].[tbl_bookReject]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookReject_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_bookReject] CHECK CONSTRAINT [FK_tbl_bookReject_tbl_group]
GO
ALTER TABLE [dbo].[tbl_bookReject]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookReject_tbl_party] FOREIGN KEY([party_id])
REFERENCES [dbo].[tbl_party] ([id])
GO
ALTER TABLE [dbo].[tbl_bookReject] CHECK CONSTRAINT [FK_tbl_bookReject_tbl_party]
GO
ALTER TABLE [dbo].[tbl_bookReturn]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookReturn_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_bookReturn] CHECK CONSTRAINT [FK_tbl_bookReturn_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_bookReturn]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookReturn_tbl_district] FOREIGN KEY([district_id])
REFERENCES [dbo].[tbl_district] ([id])
GO
ALTER TABLE [dbo].[tbl_bookReturn] CHECK CONSTRAINT [FK_tbl_bookReturn_tbl_district]
GO
ALTER TABLE [dbo].[tbl_bookReturn]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookReturn_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_bookReturn] CHECK CONSTRAINT [FK_tbl_bookReturn_tbl_group]
GO
ALTER TABLE [dbo].[tbl_bookReturn]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookReturn_tbl_party] FOREIGN KEY([party_id])
REFERENCES [dbo].[tbl_party] ([id])
GO
ALTER TABLE [dbo].[tbl_bookReturn] CHECK CONSTRAINT [FK_tbl_bookReturn_tbl_party]
GO
ALTER TABLE [dbo].[tbl_bookSales]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookSales_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_bookSales] CHECK CONSTRAINT [FK_tbl_bookSales_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_bookSales]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookSales_tbl_district] FOREIGN KEY([district_id])
REFERENCES [dbo].[tbl_district] ([id])
GO
ALTER TABLE [dbo].[tbl_bookSales] CHECK CONSTRAINT [FK_tbl_bookSales_tbl_district]
GO
ALTER TABLE [dbo].[tbl_bookSales]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookSales_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_bookSales] CHECK CONSTRAINT [FK_tbl_bookSales_tbl_group]
GO
ALTER TABLE [dbo].[tbl_bookSales]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookSales_tbl_party] FOREIGN KEY([party_id])
REFERENCES [dbo].[tbl_party] ([id])
GO
ALTER TABLE [dbo].[tbl_bookSales] CHECK CONSTRAINT [FK_tbl_bookSales_tbl_party]
GO
ALTER TABLE [dbo].[tbl_bookSpeciman]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookSpeciman_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_bookSpeciman] CHECK CONSTRAINT [FK_tbl_bookSpeciman_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_bookSpeciman]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookSpeciman_tbl_district] FOREIGN KEY([district_id])
REFERENCES [dbo].[tbl_district] ([id])
GO
ALTER TABLE [dbo].[tbl_bookSpeciman] CHECK CONSTRAINT [FK_tbl_bookSpeciman_tbl_district]
GO
ALTER TABLE [dbo].[tbl_bookSpeciman]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookSpeciman_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_bookSpeciman] CHECK CONSTRAINT [FK_tbl_bookSpeciman_tbl_group]
GO
ALTER TABLE [dbo].[tbl_bookSpeciman]  WITH CHECK ADD  CONSTRAINT [FK_tbl_bookSpeciman_tbl_party] FOREIGN KEY([party_id])
REFERENCES [dbo].[tbl_party] ([id])
GO
ALTER TABLE [dbo].[tbl_bookSpeciman] CHECK CONSTRAINT [FK_tbl_bookSpeciman_tbl_party]
GO
ALTER TABLE [dbo].[tbl_coverReceived]  WITH CHECK ADD  CONSTRAINT [FK_tbl_coverReceived_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_coverReceived] CHECK CONSTRAINT [FK_tbl_coverReceived_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_coverReceived]  WITH CHECK ADD  CONSTRAINT [FK_tbl_coverReceived_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_coverReceived] CHECK CONSTRAINT [FK_tbl_coverReceived_tbl_group]
GO
ALTER TABLE [dbo].[tbl_coverSupply]  WITH CHECK ADD  CONSTRAINT [FK_tbl_coverSupply_tbl_binder] FOREIGN KEY([binder_id])
REFERENCES [dbo].[tbl_binder] ([id])
GO
ALTER TABLE [dbo].[tbl_coverSupply] CHECK CONSTRAINT [FK_tbl_coverSupply_tbl_binder]
GO
ALTER TABLE [dbo].[tbl_coverSupply]  WITH CHECK ADD  CONSTRAINT [FK_tbl_coverSupply_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_coverSupply] CHECK CONSTRAINT [FK_tbl_coverSupply_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_coverSupply]  WITH CHECK ADD  CONSTRAINT [FK_tbl_coverSupply_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_coverSupply] CHECK CONSTRAINT [FK_tbl_coverSupply_tbl_group]
GO
ALTER TABLE [dbo].[tbl_employee_salary_entry]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employee_salary_entry_tbl_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[tbl_employee] ([id])
GO
ALTER TABLE [dbo].[tbl_employee_salary_entry] CHECK CONSTRAINT [FK_tbl_employee_salary_entry_tbl_employee]
GO
ALTER TABLE [dbo].[tbl_employeeSalaryPayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employeeSalaryPayment_tbl_bankAccount] FOREIGN KEY([bank_id])
REFERENCES [dbo].[tbl_bankAccount] ([id])
GO
ALTER TABLE [dbo].[tbl_employeeSalaryPayment] CHECK CONSTRAINT [FK_tbl_employeeSalaryPayment_tbl_bankAccount]
GO
ALTER TABLE [dbo].[tbl_employeeSalaryPayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_employeeSalaryPayment_tbl_employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[tbl_employee] ([id])
GO
ALTER TABLE [dbo].[tbl_employeeSalaryPayment] CHECK CONSTRAINT [FK_tbl_employeeSalaryPayment_tbl_employee]
GO
ALTER TABLE [dbo].[tbl_moneyReceipt]  WITH CHECK ADD  CONSTRAINT [FK_tbl_moneyReceipt_tbl_bankAccount] FOREIGN KEY([bank_id])
REFERENCES [dbo].[tbl_bankAccount] ([id])
GO
ALTER TABLE [dbo].[tbl_moneyReceipt] CHECK CONSTRAINT [FK_tbl_moneyReceipt_tbl_bankAccount]
GO
ALTER TABLE [dbo].[tbl_moneyReceipt]  WITH CHECK ADD  CONSTRAINT [FK_tbl_moneyReceipt_tbl_district] FOREIGN KEY([district_id])
REFERENCES [dbo].[tbl_district] ([id])
GO
ALTER TABLE [dbo].[tbl_moneyReceipt] CHECK CONSTRAINT [FK_tbl_moneyReceipt_tbl_district]
GO
ALTER TABLE [dbo].[tbl_moneyReceipt]  WITH CHECK ADD  CONSTRAINT [FK_tbl_moneyReceipt_tbl_party] FOREIGN KEY([party_id])
REFERENCES [dbo].[tbl_party] ([id])
GO
ALTER TABLE [dbo].[tbl_moneyReceipt] CHECK CONSTRAINT [FK_tbl_moneyReceipt_tbl_party]
GO
ALTER TABLE [dbo].[tbl_other_group]  WITH CHECK ADD  CONSTRAINT [FK_tbl_other_group_tbl_other_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_other_group] ([id])
GO
ALTER TABLE [dbo].[tbl_other_group] CHECK CONSTRAINT [FK_tbl_other_group_tbl_other_group]
GO
ALTER TABLE [dbo].[tbl_otherBillPayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_otherBillPayment_tbl_bankAccount] FOREIGN KEY([bank_id])
REFERENCES [dbo].[tbl_bankAccount] ([id])
GO
ALTER TABLE [dbo].[tbl_otherBillPayment] CHECK CONSTRAINT [FK_tbl_otherBillPayment_tbl_bankAccount]
GO
ALTER TABLE [dbo].[tbl_otherBillPayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_otherBillPayment_tbl_other_group] FOREIGN KEY([other_name_id])
REFERENCES [dbo].[tbl_other_group] ([id])
GO
ALTER TABLE [dbo].[tbl_otherBillPayment] CHECK CONSTRAINT [FK_tbl_otherBillPayment_tbl_other_group]
GO
ALTER TABLE [dbo].[tbl_paperOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperOrder_tbl_paper] FOREIGN KEY([paper_id])
REFERENCES [dbo].[tbl_paper] ([id])
GO
ALTER TABLE [dbo].[tbl_paperOrder] CHECK CONSTRAINT [FK_tbl_paperOrder_tbl_paper]
GO
ALTER TABLE [dbo].[tbl_paperOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperOrder_tbl_press] FOREIGN KEY([press_id])
REFERENCES [dbo].[tbl_press] ([id])
GO
ALTER TABLE [dbo].[tbl_paperOrder] CHECK CONSTRAINT [FK_tbl_paperOrder_tbl_press]
GO
ALTER TABLE [dbo].[tbl_paperOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperOrder_tbl_supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[tbl_supplier] ([id])
GO
ALTER TABLE [dbo].[tbl_paperOrder] CHECK CONSTRAINT [FK_tbl_paperOrder_tbl_supplier]
GO
ALTER TABLE [dbo].[tbl_paperPrint]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperPrint_tbl_book_info] FOREIGN KEY([book_id])
REFERENCES [dbo].[tbl_book_info] ([id])
GO
ALTER TABLE [dbo].[tbl_paperPrint] CHECK CONSTRAINT [FK_tbl_paperPrint_tbl_book_info]
GO
ALTER TABLE [dbo].[tbl_paperPrint]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperPrint_tbl_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[tbl_group] ([id])
GO
ALTER TABLE [dbo].[tbl_paperPrint] CHECK CONSTRAINT [FK_tbl_paperPrint_tbl_group]
GO
ALTER TABLE [dbo].[tbl_paperPrint]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperPrint_tbl_paper] FOREIGN KEY([paper_id])
REFERENCES [dbo].[tbl_paper] ([id])
GO
ALTER TABLE [dbo].[tbl_paperPrint] CHECK CONSTRAINT [FK_tbl_paperPrint_tbl_paper]
GO
ALTER TABLE [dbo].[tbl_paperPrint]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperPrint_tbl_press] FOREIGN KEY([press_id])
REFERENCES [dbo].[tbl_press] ([id])
GO
ALTER TABLE [dbo].[tbl_paperPrint] CHECK CONSTRAINT [FK_tbl_paperPrint_tbl_press]
GO
ALTER TABLE [dbo].[tbl_paperTransfer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperTransfer_tbl_paper] FOREIGN KEY([paper_id])
REFERENCES [dbo].[tbl_paper] ([id])
GO
ALTER TABLE [dbo].[tbl_paperTransfer] CHECK CONSTRAINT [FK_tbl_paperTransfer_tbl_paper]
GO
ALTER TABLE [dbo].[tbl_paperTransfer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperTransfer_tbl_press] FOREIGN KEY([from_press_id])
REFERENCES [dbo].[tbl_press] ([id])
GO
ALTER TABLE [dbo].[tbl_paperTransfer] CHECK CONSTRAINT [FK_tbl_paperTransfer_tbl_press]
GO
ALTER TABLE [dbo].[tbl_paperTransfer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_paperTransfer_tbl_press1] FOREIGN KEY([to_press_id])
REFERENCES [dbo].[tbl_press] ([id])
GO
ALTER TABLE [dbo].[tbl_paperTransfer] CHECK CONSTRAINT [FK_tbl_paperTransfer_tbl_press1]
GO
ALTER TABLE [dbo].[tbl_party]  WITH CHECK ADD  CONSTRAINT [FK_tbl_party_tbl_party1] FOREIGN KEY([district_id])
REFERENCES [dbo].[tbl_party] ([id])
GO
ALTER TABLE [dbo].[tbl_party] CHECK CONSTRAINT [FK_tbl_party_tbl_party1]
GO
ALTER TABLE [dbo].[tbl_personalLoanPayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_personalLoanPayment_tbl_party] FOREIGN KEY([party_id])
REFERENCES [dbo].[tbl_party] ([id])
GO
ALTER TABLE [dbo].[tbl_personalLoanPayment] CHECK CONSTRAINT [FK_tbl_personalLoanPayment_tbl_party]
GO
ALTER TABLE [dbo].[tbl_spacymenParty]  WITH CHECK ADD  CONSTRAINT [FK_tbl_spacymenParty_tbl_spacymenParty] FOREIGN KEY([district_id])
REFERENCES [dbo].[tbl_spacymenParty] ([id])
GO
ALTER TABLE [dbo].[tbl_spacymenParty] CHECK CONSTRAINT [FK_tbl_spacymenParty_tbl_spacymenParty]
GO
ALTER TABLE [dbo].[tbl_supplier_bill_entry]  WITH CHECK ADD  CONSTRAINT [FK_tbl_supplier_bill_entry_tbl_paper] FOREIGN KEY([paper_id])
REFERENCES [dbo].[tbl_paper] ([id])
GO
ALTER TABLE [dbo].[tbl_supplier_bill_entry] CHECK CONSTRAINT [FK_tbl_supplier_bill_entry_tbl_paper]
GO
ALTER TABLE [dbo].[tbl_supplier_bill_entry]  WITH CHECK ADD  CONSTRAINT [FK_tbl_supplier_bill_entry_tbl_press] FOREIGN KEY([press_id])
REFERENCES [dbo].[tbl_press] ([id])
GO
ALTER TABLE [dbo].[tbl_supplier_bill_entry] CHECK CONSTRAINT [FK_tbl_supplier_bill_entry_tbl_press]
GO
ALTER TABLE [dbo].[tbl_supplier_bill_entry]  WITH CHECK ADD  CONSTRAINT [FK_tbl_supplier_bill_entry_tbl_supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[tbl_supplier] ([id])
GO
ALTER TABLE [dbo].[tbl_supplier_bill_entry] CHECK CONSTRAINT [FK_tbl_supplier_bill_entry_tbl_supplier]
GO
ALTER TABLE [dbo].[tbl_supplierBillPayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_supplierBillPayment_tbl_bankAccount] FOREIGN KEY([bank_id])
REFERENCES [dbo].[tbl_bankAccount] ([id])
GO
ALTER TABLE [dbo].[tbl_supplierBillPayment] CHECK CONSTRAINT [FK_tbl_supplierBillPayment_tbl_bankAccount]
GO
ALTER TABLE [dbo].[tbl_supplierBillPayment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_supplierBillPayment_tbl_supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[tbl_supplier] ([id])
GO
ALTER TABLE [dbo].[tbl_supplierBillPayment] CHECK CONSTRAINT [FK_tbl_supplierBillPayment_tbl_supplier]
GO
USE [master]
GO
ALTER DATABASE [LibraryManagementSystemDB] SET  READ_WRITE 
GO

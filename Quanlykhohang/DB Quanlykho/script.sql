USE [quanlykho]
GO
/****** Object:  Table [dbo].[chitiet_nhapkho]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiet_nhapkho](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ma_phieu] [nvarchar](100) NOT NULL,
	[ma_vattu] [nvarchar](100) NOT NULL,
	[sl_vattu] [nvarchar](100) NOT NULL,
	[ghichu] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[donvitinh]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[donvitinh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten_dvt] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[po_number] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[po_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kho]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kho](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ma_kho] [nvarchar](50) NULL,
	[ten_kho] [nvarchar](200) NULL,
	[loai_kho] [nvarchar](200) NULL,
	[ghi_chu] [nvarchar](50) NULL,
 CONSTRAINT [PK__kho__0A2E13A4F6066AFA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khoa]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khoa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ma_khoa] [nvarchar](50) NOT NULL,
	[ten_khoa] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lophop]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lophop](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ma_lop] [nvarchar](100) NOT NULL,
	[ten_lop] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanvien]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanvien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ma_nv] [nvarchar](100) NOT NULL,
	[hoten_nv] [nvarchar](100) NOT NULL,
	[gioitinh_nv] [bit] NOT NULL,
	[std_nv] [int] NOT NULL,
	[diachi_nv] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhapkho]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhapkho](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ma_phieu] [nvarchar](100) NOT NULL,
	[ngay_nhap] [date] NOT NULL,
	[ma_nv] [nvarchar](100) NOT NULL,
	[ma_kho] [nvarchar](100) NOT NULL,
	[lydo] [nvarchar](50) NULL,
 CONSTRAINT [PK__nhapkho__3213E83F7F4292C9] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sinhvien]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sinhvien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ma_sv] [nvarchar](100) NOT NULL,
	[ten_sv] [nvarchar](100) NOT NULL,
	[diachi] [nvarchar](100) NOT NULL,
	[ma_lop] [nvarchar](100) NOT NULL,
	[ma_kh] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vattu]    Script Date: 4/25/2023 8:47:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vattu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ma_vt] [nvarchar](100) NOT NULL,
	[ten_vt] [nvarchar](100) NOT NULL,
	[dvt_vt] [nvarchar](100) NOT NULL,
	[soluong_vt] [int] NOT NULL,
	[loai_vt] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

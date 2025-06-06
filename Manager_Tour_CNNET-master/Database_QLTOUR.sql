CREATE DATABASE TOUR_CNN

USE [TOUR_CNN]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GenerateSoHD]()
RETURNS CHAR(5)
AS
BEGIN
    DECLARE @NextID INT;

    -- Tìm giá trị tự tăng tiếp theo
    SELECT @NextID = COALESCE(MAX(CAST(RIGHT(SoHD, 3) AS INT)), 0) + 1
    FROM HoaDon;

    -- Chuyển đổi giá trị tự tăng thành định dạng "HD01", "HD02", ...
    DECLARE @GeneratedID CHAR(5) = 'HD' + RIGHT('00' + CAST(@NextID AS VARCHAR(2)), 2);

    RETURN @GeneratedID;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [char](5) NOT NULL,
	[TenCV] [nvarchar](20) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[SoHD] [char](5) NOT NULL,
	[MaNV] [char](5) NOT NULL,
	[MaKH] [char](5) NOT NULL,
	[MaTour] [char](5) NOT NULL,
	[NgayLapHD] [date] NULL,
	[ThanhTien] [decimal](18, 0) NOT NULL,
	[SLVe] [int] NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[SoHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [char](5) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[Sdt] [char](11) NOT NULL,
	[Email] [nvarchar](30) NULL,
	[GioiTinh] [nvarchar](3) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAITOUR](
	[MaLoaiTour] [char](5) NOT NULL,
	[TenLoaiTour] [nvarchar](40) NULL,
 CONSTRAINT [PK_LOAITOUR] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](5) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[NgaySinh] [date] NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Sdt] [nvarchar](11) NULL,
	[MaCV] [char](5) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHUONGTIENTOUR](
	[MaPhuongTien] [char](5) NOT NULL,
	[TenPhuongTien] [nvarchar](30) NULL,
 CONSTRAINT [PK_PHUONGTIENTOUR] PRIMARY KEY CLUSTERED 
(
	[MaPhuongTien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenDangNhap] [varchar](30) NOT NULL,
	[MatKhau] [varchar](10) NULL,
	[MaNV] [char](5) NOT NULL,
 CONSTRAINT [PK_TK] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONGTINTOUR](
	[MaTour] [char](5) NOT NULL,
	[TenTour] [nvarchar](40) NULL,
	[MoTaTour] [nvarchar](255) NULL,
	[AnhTour] [nvarchar](40) NULL,
	[GiaTour] [decimal](18, 2) NULL,
	[TGBatDau] [datetime] NULL,
	[TGKetThuc] [datetime] NULL,
	[MaLoaiTour] [char](5) NULL,
	[MaPhuongTien] [char](5) NULL,
	[MaXP] [char](5) NULL,
	[SLVeConLai] [int] NOT NULL,
 CONSTRAINT [PK_THONGTINTOUR] PRIMARY KEY CLUSTERED 
(
	[MaTour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XUATPHATTOUR](
	[MaXP] [char](5) NOT NULL,
	[DiaDiemXP] [nvarchar](40) NULL,
 CONSTRAINT [PK_XUATPHATTOUR] PRIMARY KEY CLUSTERED 
(
	[MaXP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (N'NV   ', N'Nhân Viên')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (N'QL   ', N'Quản Lý')
GO
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD001', N'NV002', N'KH001', N'TO001', CAST(N'2025-05-01' AS Date), CAST(200 AS Decimal(18, 0)), 1)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD002', N'NV003', N'KH005', N'TO003', CAST(N'2025-05-01' AS Date), CAST(700 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD003', N'NV004', N'KH002', N'TO002', CAST(N'2025-05-01' AS Date), CAST(180 AS Decimal(18, 0)), 1)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD004', N'NV005', N'KH003', N'TO001', CAST(N'2025-05-01' AS Date), CAST(400 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD005', N'NV002', N'KH004', N'TO005', CAST(N'2025-05-01' AS Date), CAST(1100 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD006', N'NV003', N'KH005', N'TO004', CAST(N'2025-05-01' AS Date), CAST(1800 AS Decimal(18, 0)), 3)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD007', N'NV004', N'KH006', N'TO002', CAST(N'2025-05-01' AS Date), CAST(360 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD008', N'NV005', N'KH009', N'TO007', CAST(N'2025-05-01' AS Date), CAST(2600 AS Decimal(18, 0)), 4)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD009', N'NV003', N'KH008', N'TO008', CAST(N'2025-05-01' AS Date), CAST(4000 AS Decimal(18, 0)), 5)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD010', N'NV001', N'KH010', N'TO006', CAST(N'2025-05-01' AS Date), CAST(440 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD011', N'NV002', N'KH001', N'TO003', CAST(N'2025-05-01' AS Date), CAST(200 AS Decimal(18, 0)), 3)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD012', N'NV002', N'KH001', N'TO004', CAST(N'2025-05-01' AS Date), CAST(200 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD013', N'NV001', N'KH005', N'TO013', CAST(N'2025-05-01' AS Date), CAST(550 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD014', N'NV002', N'KH002', N'TO014', CAST(N'2025-05-01' AS Date), CAST(750 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD015', N'NV003', N'KH001', N'TO015', CAST(N'2025-05-01' AS Date), CAST(500 AS Decimal(18, 0)), 1)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD016', N'NV001', N'KH006', N'TO016', CAST(N'2025-05-01' AS Date), CAST(680 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD017', N'NV002', N'KH008', N'TO017', CAST(N'2025-05-01' AS Date), CAST(850 AS Decimal(18, 0)), 1)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD018', N'NV003', N'KH007', N'TO018', CAST(N'2025-05-01' AS Date), CAST(700 AS Decimal(18, 0)), 1)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD019', N'NV001', N'KH009', N'TO019', CAST(N'2025-05-01' AS Date), CAST(300 AS Decimal(18, 0)), 1)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD020', N'NV002', N'KH010', N'TO020', CAST(N'2025-05-01' AS Date), CAST(350 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD022', N'NV001', N'KH002', N'TO002', CAST(N'2025-05-01' AS Date), CAST(360 AS Decimal(18, 0)), 2)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD023', N'NV003', N'KH003', N'TO003', CAST(N'2025-05-01' AS Date), CAST(1400 AS Decimal(18, 0)), 4)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD024', N'NV002', N'KH004', N'TO004', CAST(N'2025-05-01' AS Date), CAST(600 AS Decimal(18, 0)), 1)
INSERT [dbo].[HOADON] ([SoHD], [MaNV], [MaKH], [MaTour], [NgayLapHD], [ThanhTien], [SLVe]) VALUES (N'HD025', N'NV001', N'KH005', N'TO005', CAST(N'2025-05-01' AS Date), CAST(1100 AS Decimal(18, 0)), 2)
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH001', N'Nguyen Van Toan', N'0528151123 ', N'vantoan@email.com', N'Nam')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH002', N'Tran Thi Be', N'1234567899 ', N'thibe@email.com', N'Nữ')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH003', N'Le Nhan', N'9876543211 ', N'lnhan@email.com', N'Nam')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH004', N'Le Thi Minh', N'0912345678 ', N'minhle@email.com', N'Nam')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH005', N'Pham Van Hau', N'0987654321 ', N'hau.pham@email.com', N'Nam')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH006', N'Nguyen Anh Tuan', N'0365897412 ', N'tuananh@email.com', N'Nam')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH007', N'Tran Thi Nga', N'0777777777 ', N'ngatran@email.com', N'Nữ')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH008', N'Hoang Van Cuong', N'0123456789 ', N'cuonghoang@email.com', N'Nam')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH009', N'Doan Ngoc Thao', N'0933333333 ', N'thaongoc@email.com', N'Nữ')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [Sdt], [Email], [GioiTinh]) VALUES (N'KH010', N'Vu Thi Hien', N'0888888888 ', N'hienvu@email.com', N'Nữ')
GO
INSERT [dbo].[LOAITOUR] ([MaLoaiTour], [TenLoaiTour]) VALUES (N'TCC  ', N'Cao Cấp')
INSERT [dbo].[LOAITOUR] ([MaLoaiTour], [TenLoaiTour]) VALUES (N'TTC  ', N'Tiêu Chuẩn')
INSERT [dbo].[LOAITOUR] ([MaLoaiTour], [TenLoaiTour]) VALUES (N'TTK  ', N'Tiết Kiệm')
GO
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [DiaChi], [Sdt], [MaCV]) VALUES (N'NV001', N'Lâm Huỳnh Như', N'Nữ', CAST(N'2004-01-26' AS Date), N'nhulam2601@gmail.com', N'Hồng Ngự, Đồng Tháp', N'0822951411', N'QL   ')
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [DiaChi], [Sdt], [MaCV]) VALUES (N'NV002', N'Lê Anh Bắc', N'Nam', CAST(N'2004-01-30' AS Date), N'bacanh123@gmail.com', N'Thanh Hóa', N'0831241393', N'NV   ')
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [DiaChi], [Sdt], [MaCV]) VALUES (N'NV003', N'Nguyễn Nhật Huy', N'Nam', CAST(N'2004-09-04' AS Date), N'nhuy456@gmail.com', N'Tân Phú, TP.HCM', N'0951636578', N'NV   ')
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [DiaChi], [Sdt], [MaCV]) VALUES (N'NV004', N'Nguyễn Tuấn Khanh', N'Nam', CAST(N'2001-08-11' AS Date), N'lamngoc123@gmail.com', N'Long An', N'0916724983', N'NV   ')
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [GioiTinh], [NgaySinh], [Email], [DiaChi], [Sdt], [MaCV]) VALUES (N'NV005', N'Nguyễn Huy Hoàng', N'Nam', CAST(N'2004-04-21' AS Date), N'dinhtoan111@gmail.com', N'Bình Thủy,Cần Thơ', N'0389911722', N'NV   ')
GO
INSERT [dbo].[PHUONGTIENTOUR] ([MaPhuongTien], [TenPhuongTien]) VALUES (N'PT001', N'Máy bay')
INSERT [dbo].[PHUONGTIENTOUR] ([MaPhuongTien], [TenPhuongTien]) VALUES (N'PT002', N'Xe')
GO
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [MaNV]) VALUES (N'nhulam', N'nhulam2601', N'NV001')
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [MaNV]) VALUES (N'bacanh', N'lab3001', N'NV002')
GO
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO001', N'Tour Đà Lạt', N'Tham quan những danh lam thắng cảnh nổi tiếng của Đà Nẵng như Bà Nà Hills, Cầu Rồng và bãi biển Mỹ Khê.', N'danang1.jpg', CAST(200.00 AS Decimal(18, 2)), CAST(N'2025-02-25T10:00:00.000' AS DateTime), CAST(N'2025-02-30T19:00:00.000' AS DateTime), N'TTK  ', N'PT001', N'XP001', 44)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO002', N'Tour Sapa', N'Trải nghiệm cuộc sống vùng cao, khám phá thắng cảnh hùng vĩ và gặp gỡ người dân tộc thiểu số.', N'sapa1.jpg', CAST(180.00 AS Decimal(18, 2)), CAST(N'2025-01-01T16:00:00.000' AS DateTime), CAST(N'2025-01-06T17:00:00.000' AS DateTime), N'TTK  ', N'PT001', N'XP002', 29)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO003', N'Tour Phú Quốc', N'Nghỉ dưỡng tại resort 5 sao, tham quan những bãi biển tuyệt đẹp và thử các món đặc sản đảo ngọc.', N'phuquoc1.jpg', CAST(350.00 AS Decimal(18, 2)), CAST(N'2025-01-10T19:00:00.000' AS DateTime), CAST(N'2025-01-14T08:00:00.000' AS DateTime), N'TTC  ', N'PT002', N'XP003', 24)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO004', N'Tour Singapore', N'Khám phá sự sôi động và hiện đại của Singapore, từ khu vực Merlion đến khu mua sắm Orchard Road.', N'sp1.jpg', CAST(600.00 AS Decimal(18, 2)), CAST(N'2025-01-01T16:00:00.000' AS DateTime), CAST(N'2025-01-06T17:00:00.000' AS DateTime), N'TCC  ', N'PT001', N'XP001',48)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO005', N'Tour Malaysia', N'Trải nghiệm văn hóa đa dạng của Malaysia, từ tháp đôi Petronas đến các đền đài ấn tượng.', N'malaysia1.jpg', CAST(550.00 AS Decimal(18, 2)), CAST(N'2025-01-01T16:00:00.000' AS DateTime), CAST(N'2025-01-06T17:00:00.000' AS DateTime), N'TCC  ', N'PT001', N'XP001', 44)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO006', N'Tour Đà Lạt', N'Tham quan Đà Lạt ngàn hoa, thăm quan Dinh III, Hồ Xuân Hương và thưởng thức cà phê Đà Lạt.', N'dalat1.jpg', CAST(220.00 AS Decimal(18, 2)), CAST(N'2025-01-01T16:00:00.000' AS DateTime), CAST(N'2025-01-06T17:00:00.000' AS DateTime), N'TTC  ', N'PT001', N'XP001', 44)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO007', N'Tour Hàn Quốc', N'Khám phá Seoul, thăm quan khu phố cổ Bukchon Hanok và thử trải nghiệm K-pop.', N'korea1.jpg', CAST(650.00 AS Decimal(18, 2)), CAST(N'2025-01-01T16:00:00.000' AS DateTime), CAST(N'2025-01-06T17:00:00.000' AS DateTime), N'TCC  ', N'PT001', N'XP001', 44)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO008', N'Tour Singapore2', N'Khám phá sự sôi động và hiện đại của Singapore, từ khu vực Merlion đến khu mua sắm Orchard Road.', N'sp1.jpg', CAST(600.00 AS Decimal(18, 2)), CAST(N'2025-01-01T16:00:00.000' AS DateTime), CAST(N'2025-01-06T17:00:00.000' AS DateTime), N'TTC  ', N'PT001', N'XP001', 48)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO009', N'Tour Hội An', N'Thăm quan khu phố cổ Hội An với những ngôi nhà cổ truyền thống và đèn lồng lung linh.', N'hoian1.jpg', CAST(250.00 AS Decimal(18, 2)), CAST(N'2025-01-10T09:00:00.000' AS DateTime), CAST(N'2025-01-15T18:00:00.000' AS DateTime), N'TTC  ', N'PT002', N'XP001', 25)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO010', N'Tour Bali', N'Nghỉ dưỡng tại hòn đảo thiên đàng Bali, khám phá đền Hindu và thưởng thức ẩm thực độc đáo.', N'bali1.jpg', CAST(450.00 AS Decimal(18, 2)), CAST(N'2025-02-01T12:00:00.000' AS DateTime), CAST(N'2025-02-07T20:00:00.000' AS DateTime), N'TCC  ', N'PT002', N'XP002',20)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO011', N'Tour Sydney', N'Khám phá thành phố biển Sydney với những điểm nhấn như Cầu cảng Sydney và Nhà hát Opera.', N'uc1.jpg', CAST(700.00 AS Decimal(18, 2)), CAST(N'2025-02-15T14:00:00.000' AS DateTime), CAST(N'2025-02-20T22:00:00.000' AS DateTime), N'TTC  ', N'PT002', N'XP004',32)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO012', N'Tour Rome', N'Đặt chân đến thành phố lịch sử Rome, thăm Colosseum, Di tích La Mã và Thánh đường Vatican.', N'rome1.jpg', CAST(600.00 AS Decimal(18, 2)), CAST(N'2025-03-01T10:00:00.000' AS DateTime), CAST(N'2025-03-07T18:00:00.000' AS DateTime), N'TTC  ', N'PT002', N'XP003',28)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO013', N'Tour Cairo', N'Khám phá vùng đất của những pharaoh cổ xưa với đặc sản văn hóa và lịch sử.', N'cairo1.jpg', CAST(550.00 AS Decimal(18, 2)), CAST(N'2025-03-15T11:00:00.000' AS DateTime), CAST(N'2025-03-20T19:00:00.000' AS DateTime), N'TTC  ', N'PT001', N'XP001', 25)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO014', N'Tour Kyoto', N'Thăm quan Kyoto - thành phố của các đền đài lịch sử và văn hóa truyền thống.', N'kyoto1.jpg', CAST(750.00 AS Decimal(18, 2)), CAST(N'2025-04-01T13:00:00.000' AS DateTime), CAST(N'2025-04-07T21:00:00.000' AS DateTime), N'TCC  ', N'PT002', N'XP001', 30)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO015', N'Tour Bangkok', N'Khám phá sự huyền bí của thành phố Bangkok với đền Wat Arun và Khu phố đèn đỏ Patpong.', N'bangkok1.jpg', CAST(500.00 AS Decimal(18, 2)), CAST(N'2025-04-15T16:00:00.000' AS DateTime), CAST(N'2025-04-20T23:00:00.000' AS DateTime), N'TCC  ', N'PT002', N'XP002',35)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO016', N'Tour Rio de Janeiro', N'Thưởng thức bãi biển Copacabana và định nghĩa hình ảnh đẹp của Thiên Chúa Kitô.', N'rio1.jpg', CAST(680.00 AS Decimal(18, 2)), CAST(N'2025-04-01T09:00:00.000' AS DateTime), CAST(N'2025-04-07T17:00:00.000' AS DateTime), N'TCC  ', N'PT002', N'XP002',25)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO017', N'Tour Dubai', N'Khám phá sự xa hoa và hiện đại tại Dubai với Tháp Khalifa và khu mua sắm Dubai Mall.', N'dubai1.jpg', CAST(850.00 AS Decimal(18, 2)), CAST(N'2025-04-02T12:00:00.000' AS DateTime), CAST(N'2025-04-20T19:00:00.000' AS DateTime), N'TTC  ', N'PT001', N'XP002',32)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO018', N'Tour Moscow', N'Đặt chân đến thủ đô Moscow nước Nga với Lâu đài Kremlin và Đại lộ Champs-Élysées.', N'moscow1.jpg', CAST(700.00 AS Decimal(18, 2)), CAST(N'2025-04-03T14:00:00.000' AS DateTime), CAST(N'2025-04-07T22:00:00.000' AS DateTime), N'TTC  ', N'PT002', N'XP003',28)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO019', N'Tour Hạ Long', N'Khám phá vịnh Hạ Long kỳ vĩ với những đảo đá lạ mắt và hang động huyền bí.', N'halong1.jpg', CAST(300.00 AS Decimal(18, 2)), CAST(N'2025-04-04T10:00:00.000' AS DateTime), CAST(N'2025-04-20T18:00:00.000' AS DateTime), N'TCC  ', N'PT004', N'XP002', 25)
INSERT [dbo].[THONGTINTOUR] ([MaTour], [TenTour], [MoTaTour], [AnhTour], [GiaTour], [TGBatDau], [TGKetThuc], [MaLoaiTour], [MaPhuongTien], [MaXP], [SLVeConLai]) VALUES (N'TO020', N'Tour Huế - Hội An', N'Trải nghiệm lịch sử và văn hóa Việt Nam tại thành phố cổ Huế và khu phố cổ Hội An.', N'hoian1.jpg', CAST(350.00 AS Decimal(18, 2)), CAST(N'2025-05-04T12:00:00.000' AS DateTime), CAST(N'2025-05-07T20:00:00.000' AS DateTime), N'TCC  ', N'PT002', N'XP003',30)
GO
INSERT [dbo].[XUATPHATTOUR] ([MaXP], [DiaDiemXP]) VALUES (N'XP001', N'TP HCM')
INSERT [dbo].[XUATPHATTOUR] ([MaXP], [DiaDiemXP]) VALUES (N'XP002', N'Hà Nội')
INSERT [dbo].[XUATPHATTOUR] ([MaXP], [DiaDiemXP]) VALUES (N'XP003', N'Hải Phòng')
INSERT [dbo].[XUATPHATTOUR] ([MaXP], [DiaDiemXP]) VALUES (N'XP004', N'Đà Lạt')
INSERT [dbo].[XUATPHATTOUR] ([MaXP], [DiaDiemXP]) VALUES (N'XP005', N'Cần Thơ')
INSERT [dbo].[XUATPHATTOUR] ([MaXP], [DiaDiemXP]) VALUES (N'XP006', N'Nha Trang')
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HD_KH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HD_KH]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HD_NV] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HD_NV]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HD_TTT] FOREIGN KEY([MaTour])
REFERENCES [dbo].[THONGTINTOUR] ([MaTour])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HD_TTT]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NV_CV] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NV_CV]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
ALTER TABLE [dbo].[THONGTINTOUR]  WITH CHECK ADD  CONSTRAINT [FK_THONGTINTOUR] FOREIGN KEY([MaPhuongTien])
REFERENCES [dbo].[PHUONGTIENTOUR] ([MaPhuongTien])
GO
ALTER TABLE [dbo].[THONGTINTOUR] CHECK CONSTRAINT [FK_THONGTINTOUR]
GO
ALTER TABLE [dbo].[THONGTINTOUR]  WITH CHECK ADD  CONSTRAINT [FK_TTT] FOREIGN KEY([MaLoaiTour])
REFERENCES [dbo].[LOAITOUR] ([MaLoaiTour])
GO
ALTER TABLE [dbo].[THONGTINTOUR] CHECK CONSTRAINT [FK_TTT]
GO
ALTER TABLE [dbo].[THONGTINTOUR]  WITH CHECK ADD  CONSTRAINT [FK_TTT_XP] FOREIGN KEY([MaXP])
REFERENCES [dbo].[XUATPHATTOUR] ([MaXP])
GO
ALTER TABLE [dbo].[THONGTINTOUR] CHECK CONSTRAINT [FK_TTT_XP]
GO



SELECT MONTH(HOADON.NgayLapHD) AS NgayLap, SUM(ThanhTien) as TongTienTongCong
                     FROM HOADON
                     WHERE YEAR(HOADON.NgayLapHD) = DATEPART(YEAR, GETDATE())GROUP BY MONTH(HOADON.NgayLapHD)
                    ORDER BY  MONTH(HOADON.NgayLapHD)

SELECT MONTH(HOADON.NgayLapHD) AS NgayLap, SUM(ThanhTien) as TongTienTongCong
                     FROM HOADON
                     WHERE YEAR(HOADON.NgayLapHD) = DATEPART(YEAR, GETDATE())GROUP BY MONTH(HOADON.NgayLapHD)
                    ORDER BY  MONTH(HOADON.NgayLapHD)



SELECT * FROM HOADON

SELECT MaTour, COUNT(MaTour) AS SoLanDat FROM HoaDon GROUP BY MaTour ORDER BY SoLanDat DESC 

--SLVeConLai >= 0
ALTER TABLE THONGTINTOUR
ADD CONSTRAINT CHK_CheckSLVe
CHECK (SLVeConLai >= 0)

--CHECK TG BAT DAU < TG KET THUC
ALTER TABLE THONGTINTOUR
ADD CONSTRAINT CHK_CheckTimeTour
CHECK (TGBatDau < TGKetThuc);



GO
--CHECK SLVe <= SLVeConLai
CREATE TRIGGER trg_CheckSLVeMua
ON HOADON
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN THONGTINTOUR ttt ON i.MaTour = ttt.MaTour
        WHERE i.SLVe > ttt.SLVeConLai
    )
    BEGIN
        RAISERROR(N'Số lượng vé mua không được vượt quá số lượng vé còn lại.', 16, 1);
        ROLLBACK;
    END;
END;










USE [ShopSua]
GO
/****** Object:  Table [dbo].[DatHang]    Script Date: 14/12/2021 4:10:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NhanVien_ID] [int] NULL,
	[KhachHang_ID] [int] NULL,
	[DienThoaiGiaoHang] [nvarchar](11) NULL,
	[DiaChiGiaoHang] [nvarchar](255) NULL,
	[NgayDatHang] [datetime] NULL,
	[TinhTrang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatHang_ChiTiet]    Script Date: 14/12/2021 4:10:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatHang_ChiTiet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DatHang_ID] [int] NULL,
	[Sua_ID] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangSX]    Script Date: 14/12/2021 4:10:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangSX](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenHangSX] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 14/12/2021 4:10:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](255) NULL,
	[DienThoai] [nvarchar](11) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[TenDangNhap] [nvarchar](200) NULL,
	[MatKhau] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSua]    Script Date: 14/12/2021 4:10:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSua](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 14/12/2021 4:10:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](255) NULL,
	[DienThoai] [nvarchar](11) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[TenDangNhap] [nvarchar](200) NULL,
	[MatKhau] [nvarchar](255) NULL,
	[Quyen] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sua]    Script Date: 14/12/2021 4:10:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sua](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HangSX_ID] [int] NULL,
	[LoaiSua_ID] [int] NULL,
	[TenSua] [nvarchar](200) NULL,
	[DonGia] [int] NULL,
	[SoLuong] [int] NULL,
	[AnhMau] [nvarchar](255) NULL,
	[MoTa] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuKho]    Script Date: 14/12/2021 4:10:26 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuKho](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](255) NULL,
	[DienThoai] [nvarchar](11) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[TenDangNhap] [nvarchar](200) NULL,
	[MatKhau] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DatHang] ON 

INSERT [dbo].[DatHang] ([ID], [NhanVien_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (1, NULL, 1, N'0369789999', N'an giang', CAST(N'2021-12-13T14:49:54.850' AS DateTime), 0)
INSERT [dbo].[DatHang] ([ID], [NhanVien_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (2, NULL, 1, N'0369789999', N'an giang', CAST(N'2021-12-13T14:58:58.510' AS DateTime), 0)
INSERT [dbo].[DatHang] ([ID], [NhanVien_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (3, NULL, 1, N'0369789999', N'an giang', CAST(N'2021-12-13T15:19:20.717' AS DateTime), 0)
INSERT [dbo].[DatHang] ([ID], [NhanVien_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (4, NULL, 1, N'0369789998', N'an giang', CAST(N'2021-12-14T09:47:52.690' AS DateTime), 2)
INSERT [dbo].[DatHang] ([ID], [NhanVien_ID], [KhachHang_ID], [DienThoaiGiaoHang], [DiaChiGiaoHang], [NgayDatHang], [TinhTrang]) VALUES (5, NULL, 1017, N'0369789999', N'an giang', CAST(N'2021-12-14T09:55:07.043' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[DatHang] OFF
GO
SET IDENTITY_INSERT [dbo].[DatHang_ChiTiet] ON 

INSERT [dbo].[DatHang_ChiTiet] ([ID], [DatHang_ID], [Sua_ID], [SoLuong], [DonGia]) VALUES (1, 1, 4, 1, 12000)
INSERT [dbo].[DatHang_ChiTiet] ([ID], [DatHang_ID], [Sua_ID], [SoLuong], [DonGia]) VALUES (2, 2, 4, 1, 12000)
INSERT [dbo].[DatHang_ChiTiet] ([ID], [DatHang_ID], [Sua_ID], [SoLuong], [DonGia]) VALUES (3, 3, 4, 1, 12000)
INSERT [dbo].[DatHang_ChiTiet] ([ID], [DatHang_ID], [Sua_ID], [SoLuong], [DonGia]) VALUES (4, 4, 3, 1, 12000)
INSERT [dbo].[DatHang_ChiTiet] ([ID], [DatHang_ID], [Sua_ID], [SoLuong], [DonGia]) VALUES (5, 5, 3, 10, 12000)
INSERT [dbo].[DatHang_ChiTiet] ([ID], [DatHang_ID], [Sua_ID], [SoLuong], [DonGia]) VALUES (6, 5, 4, 3, 12000)
SET IDENTITY_INSERT [dbo].[DatHang_ChiTiet] OFF
GO
SET IDENTITY_INSERT [dbo].[HangSX] ON 

INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (1, N'TH true milk')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (2, N'gold')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (3, N'dalat milk')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (4, N'dutch lady')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (5, N'enfa grow')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (6, N'molo')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (7, N'ông thọ')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (9, N'nuti')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (10, N'NAN')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (11, N'BA VÌ')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (12, N'Ensure')
INSERT [dbo].[HangSX] ([ID], [TenHangSX]) VALUES (13, N'Milk')
SET IDENTITY_INSERT [dbo].[HangSX] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (1, N'Nguyễn Minh Tiến', N'0384349305', N'Long Xuyên', N'tien123', N'f350d780ea8aaa48030b4db64f790c14dbcd757f')
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (2, N'Trương Trần Huy Tín', N'0384349305', N'Long Xuyên', N'tin123', N'8cb2237d0679ca88db6464eac60da96345513964')
INSERT [dbo].[KhachHang] ([ID], [HoVaTen], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (1017, N'tienchodien', N'0365541254', N'sdfsdfghfjh', N'tienchodien', N'7c4a8d09ca3762af61e59520943dc26494f8941b')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSua] ON 

INSERT [dbo].[LoaiSua] ([ID], [TenLoai]) VALUES (2, N'Sữa đặc')
INSERT [dbo].[LoaiSua] ([ID], [TenLoai]) VALUES (3, N'Sữa chua')
INSERT [dbo].[LoaiSua] ([ID], [TenLoai]) VALUES (4, N'Vinamilk')
SET IDENTITY_INSERT [dbo].[LoaiSua] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Quyen]) VALUES (1, N'phúc', N'0395417719', N'an giang', N'tien123', N'f350d780ea8aaa48030b4db64f790c14dbcd757f', 1)
INSERT [dbo].[NhanVien] ([ID], [HoVaTen], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau], [Quyen]) VALUES (2, N'Tín', N'0395215225', N'Hà nội', N'Tinkhungdien', N'8cb2237d0679ca88db6464eac60da96345513964', 0)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[Sua] ON 

INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (3, 1, 2, N'Vinamilk', 12000, 12, N'Storage/suatangchieucao.jpg', N'uống vào là vina ngay')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (4, 1, 2, N'Vfresh', 12000, 12, N'Storage/vfresh.png', N'hehe')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (6, 2, 4, N'abbott grow', 15000, 100, N'Storage/dd5c96a0-755e-4205-8060-d53d4a77359a.jpg', N'cao hơn thông minh hơn mỗi ngày')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (7, 6, 4, N'milo', 10000, 100, N'Storage/a2571240-1f2e-4492-8d93-4cf21ed89507.jpg', N'milo tăng chiều cao vượt bật')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (8, 3, 4, N'dalat milk', 13000, 100, N'Storage/9db79b73-5f91-4197-b962-ce9e359c3ed7.png', N'sữa Đà Lạt uống vào lạnh run')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (9, 4, 4, N'dutch lady ', 14000, 100, N'Storage/855c456e-d125-4265-8b21-22102e71dd66.png', N'uống vào đẹp trai đẹp gái ayyoo')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (10, 7, 2, N'sữa ông Thọ', 19000, 100, N'Storage/98d181a0-b709-40e9-b070-ee1c24f5635f.jpg', N'sữa ông thọ nhưng không phải sữa ông thọ')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (11, 9, 4, N'nuti food', 12000, 100, N'Storage/9f0fb824-659e-49ff-900f-a58484922b70.jpg', N'vừa uống vừa ăn giòn rụm từng giọt sữa 
')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (12, 1, 2, N'Thtrue Milk', 15000, 100, N'Storage/13088704-e8db-437e-bc30-f4e8d9c0168e.jpg', N'uống vào không bao h sai')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (13, 10, 2, N'Sữa Nestle', 56000, 100, N'Storage/f1a3736f-4c3b-4607-b36d-4be524c86fe1.jpg', N'uống vào gian nan')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (14, 11, 4, N'Sữa Ba Vì', 20000, 100, N'Storage/69ce5fe1-c9c6-40d2-84fc-e62ee4ee9c72.jpg', N'Sữa Ba Vì uống vì ba yêu dấu của con ơi')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (15, 12, 2, N'Sữa Ensure', 40000, 100, N'Storage/6c3a1680-e441-41fd-8dbd-b0378d8cc10c.jpg', N'sữa rất ngon nhưng uống rất xui')
INSERT [dbo].[Sua] ([ID], [HangSX_ID], [LoaiSua_ID], [TenSua], [DonGia], [SoLuong], [AnhMau], [MoTa]) VALUES (16, 13, 4, N'UHT Milk', 18000, 100, N'Storage/c5730c87-f026-47c1-86e9-f889c0185548.jpg', N'UHT ( Uống hết tiền )')
SET IDENTITY_INSERT [dbo].[Sua] OFF
GO
ALTER TABLE [dbo].[DatHang]  WITH CHECK ADD FOREIGN KEY([KhachHang_ID])
REFERENCES [dbo].[KhachHang] ([ID])
GO
ALTER TABLE [dbo].[DatHang]  WITH CHECK ADD FOREIGN KEY([NhanVien_ID])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[DatHang_ChiTiet]  WITH CHECK ADD FOREIGN KEY([DatHang_ID])
REFERENCES [dbo].[DatHang] ([ID])
GO
ALTER TABLE [dbo].[DatHang_ChiTiet]  WITH CHECK ADD FOREIGN KEY([Sua_ID])
REFERENCES [dbo].[Sua] ([ID])
GO
ALTER TABLE [dbo].[Sua]  WITH CHECK ADD FOREIGN KEY([HangSX_ID])
REFERENCES [dbo].[HangSX] ([ID])
GO
ALTER TABLE [dbo].[Sua]  WITH CHECK ADD FOREIGN KEY([LoaiSua_ID])
REFERENCES [dbo].[LoaiSua] ([ID])
GO

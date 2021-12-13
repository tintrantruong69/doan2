CREATE TABLE LoaiSua
(
	ID int identity primary key,
	TenLoai nvarchar(200) null
)
GO
CREATE TABLE HangSX
(
	ID int identity primary key,
	TenHangSX nvarchar(200)  null
)

CREATE TABLE Sua
(
	ID int identity primary key,
	HangSX_ID int null,
	LoaiSua_ID int null,
	TenSua nvarchar(200) null,
	DonGia int null,
	SoLuong int null,
	AnhMau nvarchar(255) null,
	MoTa ntext,
	foreign key(HangSX_ID) references dbo.HangSX(id),
	foreign key(LoaiSua_ID) references dbo.LoaiSua(id)
)
GO 
CREATE TABLE NhanVien(
	ID int identity primary key,
	HoVaTen nvarchar(255) null,
	DienThoai nvarchar(11) null,
	DiaChi nvarchar(255) null,
	TenDangNhap nvarchar(200) null,
	MatKhau nvarchar(255) null,
	Quyen bit null
)
GO
CREATE TABLE KhachHang 
(
	ID int identity primary key,
	HoVaTen nvarchar(255) null,
	DienThoai nvarchar(11) null,
	DiaChi nvarchar(255) null,
	TenDangNhap nvarchar(200) null,
	MatKhau nvarchar(255) null
)
Go

CREATE TABLE DatHang
(
	ID int identity primary key,
	NhanVien_ID int null,
	KhachHang_ID int null,	
	DienThoaiGiaoHang nvarchar(11) null,
	DiaChiGiaoHang nvarchar(255) null,
	NgayDatHang datetime null,
	TinhTrang int null,
	foreign key(NhanVien_ID) references dbo.NhanVien(id),
	foreign key(KhachHang_ID) references dbo.KhachHang(id),
)

GO
CREATE TABLE DatHang_ChiTiet
(
	ID int identity primary key,
	DatHang_ID int null,
	Sua_ID int null,
	SoLuong int null,
	DonGia int null,
	foreign key(DatHang_ID) references dbo.DatHang(id),
	foreign key(Sua_ID) references dbo.Sua(id)
)
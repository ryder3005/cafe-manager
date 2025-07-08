CREATE DATABASE QuanLyQuanTraSua;
GO
USE QuanLyQuanTraSua;
GO

-- Bảng LoaiThucUong
CREATE TABLE LoaiThucUong (
    id_loaiThucUong INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(100) NOT NULL UNIQUE, -- Thêm UNIQUE để tránh trùng tên
    TrangThai INT DEFAULT 1 -- 1: Hoạt động, 0: Không hoạt động
);

-- Bảng ThucUong
CREATE TABLE ThucUong (
    id_thucUong INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(100) NOT NULL,
    id_loaiThucUong INT NOT NULL,
    Gia FLOAT NOT NULL CHECK (Gia > 0), -- Thêm CHECK để đảm bảo giá > 0
    TrangThai INT DEFAULT 1, -- 1: Hoạt động, 0: Không hoạt động
    FOREIGN KEY (id_loaiThucUong) REFERENCES LoaiThucUong(id_loaiThucUong)
);
ALTER TABLE ThucUong
ADD Anh VARBINARY(MAX) NULL;
-- Bảng TaiKhoan
CREATE TABLE TaiKhoan (
    TenDangNhap NVARCHAR(100) PRIMARY KEY,
    MatKhau NVARCHAR(1000) NOT NULL,
    Loai NVARCHAR(12) NOT NULL CHECK (Loai IN ('Nhan vien', 'Quan li')), -- Thêm CHECK
    NgayTao DATETIME DEFAULT GETDATE(), -- Thêm cột Ngày tạo
    TrangThai INT DEFAULT 1 -- 1: Hoạt động, 0: Khóa
);

-- Bảng NhanVien
CREATE TABLE NhanVien (
    id_nhanVien INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(100) UNIQUE NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN ('Nam', 'Nu')),
    DienThoai NVARCHAR(11) NOT NULL UNIQUE, -- Thêm UNIQUE cho số điện thoại
    ChucVu NVARCHAR(100) NOT NULL,
    TrangThai INT DEFAULT 1, -- 1: Đang làm, 0: Nghỉ việc
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
);

-- Bảng Ban
CREATE TABLE Ban (
    id_ban INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(100) NOT NULL,
    TrangThai INT DEFAULT 1 -- 1: Trống, 0: Đang dùng
);

-- Bảng HoaDon
CREATE TABLE HoaDon (
    id_hoaDon INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien FLOAT DEFAULT 0 CHECK (TongTien >= 0), -- Thêm CHECK
    TrangThai INT DEFAULT 1, -- 1: Chưa thanh toán, 0: Đã thanh toán
    id_ban INT NOT NULL,
    TenDangNhap NVARCHAR(100), -- Thêm nhân viên lập hóa đơn
    FOREIGN KEY (id_ban) REFERENCES Ban(id_ban),
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
);

-- Bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    id_chiTietHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    id_hoaDon INT NOT NULL,
    id_thucUong INT NOT NULL,
    SoLuong INT DEFAULT 1 CHECK (SoLuong > 0), -- Thêm CHECK
    DonGia FLOAT NOT NULL CHECK (DonGia > 0), -- Thêm DonGia để lưu giá tại thời điểm
    ThanhTien FLOAT NOT NULL CHECK (ThanhTien >= 0), -- Thêm CHECK
    FOREIGN KEY (id_hoaDon) REFERENCES HoaDon(id_hoaDon),
    FOREIGN KEY (id_thucUong) REFERENCES ThucUong(id_thucUong)
);

-- Stored Procedures cho LoaiThucUong
GO
CREATE PROCEDURE InsertLoaiThucUong
    @Ten NVARCHAR(100),
    @TrangThai INT
AS
BEGIN
    INSERT INTO LoaiThucUong (Ten, TrangThai)
    VALUES (@Ten, @TrangThai);
END;
GO

GO
CREATE PROCEDURE UpdateLoaiThucUong
    @id_loaiThucUong INT,
    @Ten NVARCHAR(100),
    @TrangThai INT
AS
BEGIN
    UPDATE LoaiThucUong
    SET Ten = @Ten, TrangThai = @TrangThai
    WHERE id_loaiThucUong = @id_loaiThucUong;
END;
GO

GO
CREATE PROCEDURE DeleteLoaiThucUong
    @id_loaiThucUong INT
AS
BEGIN
    DELETE FROM LoaiThucUong WHERE id_loaiThucUong = @id_loaiThucUong;
END;
GO

-- Stored Procedures cho ThucUong (đã có, chỉ sửa lại)
GO
CREATE PROCEDURE InsertThucUong
    @Ten NVARCHAR(100),
    @id_loaiThucUong INT,
    @Gia FLOAT,
    @TrangThai INT,
    @Anh VARBINARY(MAX) = NULL -- Thêm tham số ảnh, mặc định là NULL
AS
BEGIN
    INSERT INTO ThucUong (Ten, id_loaiThucUong, Gia, TrangThai, Anh)
    VALUES (@Ten, @id_loaiThucUong, @Gia, @TrangThai, @Anh);
END;
GO

GO
CREATE PROCEDURE UpdateThucUong
    @id_thucUong INT,
    @Ten NVARCHAR(100),
    @id_loaiThucUong INT,
    @Gia FLOAT,
    @TrangThai INT,
    @Anh VARBINARY(MAX) = NULL -- Thêm tham số ảnh, mặc định là NULL
AS
BEGIN
    UPDATE ThucUong
    SET Ten = @Ten, 
        id_loaiThucUong = @id_loaiThucUong, 
        Gia = @Gia, 
        TrangThai = @TrangThai,
        Anh = @Anh
    WHERE id_thucUong = @id_thucUong;
END;
GO

GO
CREATE PROCEDURE DeleteThucUong
    @id_thucUong INT
AS
BEGIN
    DELETE FROM ThucUong WHERE id_thucUong = @id_thucUong;
END;
GO

-- Stored Procedures cho Ban
GO
CREATE PROCEDURE InsertBan
    @Ten NVARCHAR(100),
    @TrangThai INT
AS
BEGIN
    INSERT INTO Ban (Ten, TrangThai)
    VALUES (@Ten, @TrangThai);
END;
GO

GO
CREATE PROCEDURE UpdateBan
    @id_ban INT,
    @Ten NVARCHAR(100),
    @TrangThai INT
AS
BEGIN
    UPDATE Ban
    SET Ten = @Ten, TrangThai = @TrangThai
    WHERE id_ban = @id_ban;
END;
GO

GO
CREATE PROCEDURE DeleteBan
    @id_ban INT
AS
BEGIN
    DELETE FROM Ban WHERE id_ban = @id_ban;
END;
GO

-- Stored Procedures cho TaiKhoan
GO
CREATE PROCEDURE InsertTaiKhoan
    @TenDangNhap NVARCHAR(100),
    @MatKhau NVARCHAR(1000),
    @Loai NVARCHAR(12)
AS
BEGIN
    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Loai)
    VALUES (@TenDangNhap, @MatKhau, @Loai);
END;
GO

GO
CREATE PROCEDURE UpdateTaiKhoan
    @TenDangNhap NVARCHAR(100),
    @MatKhau NVARCHAR(1000),
    @Loai NVARCHAR(12),
    @TrangThai INT
AS
BEGIN
    UPDATE TaiKhoan
    SET MatKhau = @MatKhau, Loai = @Loai, TrangThai = @TrangThai
    WHERE TenDangNhap = @TenDangNhap;
END;
GO

GO
CREATE PROCEDURE DeleteTaiKhoan
    @TenDangNhap NVARCHAR(100)
AS
BEGIN
    DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap;
END;
GO

-- Stored Procedures cho NhanVien
GO
CREATE PROCEDURE InsertNhanVien
    @TenDangNhap NVARCHAR(100),
    @HoTen NVARCHAR(100),
    @GioiTinh NVARCHAR(10),
    @DienThoai NVARCHAR(11),
    @ChucVu NVARCHAR(100)
AS
BEGIN
    INSERT INTO NhanVien (TenDangNhap, HoTen, GioiTinh, DienThoai, ChucVu)
    VALUES (@TenDangNhap, @HoTen, @GioiTinh, @DienThoai, @ChucVu);
END;
GO

GO
CREATE PROCEDURE UpdateNhanVien
    @id_nhanVien INT,
    @HoTen NVARCHAR(100),
    @GioiTinh NVARCHAR(10),
    @DienThoai NVARCHAR(11),
    @ChucVu NVARCHAR(100),
    @TrangThai INT
AS
BEGIN
    UPDATE NhanVien
    SET HoTen = @HoTen, GioiTinh = @GioiTinh, DienThoai = @DienThoai, ChucVu = @ChucVu, TrangThai = @TrangThai
    WHERE id_nhanVien = @id_nhanVien;
END;
GO

GO
CREATE PROCEDURE DeleteNhanVien
    @id_nhanVien INT
AS
BEGIN
    DELETE FROM NhanVien WHERE id_nhanVien = @id_nhanVien;
END;
GO

-- Stored Procedures cho HoaDon (đã có, chỉ sửa lại)
GO
CREATE PROCEDURE InsertHoaDon
    @id_ban INT,
    @TenDangNhap NVARCHAR(100),
    @TrangThai INT = 1, -- Mặc định là 1: Chưa thanh toán
    @id_hoaDon INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Thêm hóa đơn vào bảng
    INSERT INTO HoaDon (id_ban, TenDangNhap, TrangThai)
    VALUES (@id_ban, @TenDangNhap, @TrangThai);

    -- Lấy ID vừa được tạo
    SET @id_hoaDon = SCOPE_IDENTITY();
END;


GO
CREATE PROCEDURE UpdateHoaDon
    @id_hoaDon INT,
    @TongTien FLOAT,
    @TrangThai INT
AS
BEGIN
    UPDATE HoaDon
    SET TongTien = @TongTien, TrangThai = @TrangThai
    WHERE id_hoaDon = @id_hoaDon;
END;
GO

GO
CREATE PROCEDURE DeleteHoaDon
    @id_hoaDon INT
AS
BEGIN
    DELETE FROM HoaDon WHERE id_hoaDon = @id_hoaDon;
END;
GO

-- Stored Procedures cho ChiTietHoaDon
GO
CREATE PROCEDURE InsertChiTietHoaDon
    @id_hoaDon INT,
    @id_thucUong INT,
    @SoLuong INT,
    @DonGia FLOAT
AS
BEGIN
    DECLARE @ThanhTien FLOAT = @SoLuong * @DonGia;
    INSERT INTO ChiTietHoaDon (id_hoaDon, id_thucUong, SoLuong, DonGia, ThanhTien)
    VALUES (@id_hoaDon, @id_thucUong, @SoLuong, @DonGia, @ThanhTien);
END;
GO

GO
CREATE PROCEDURE UpdateChiTietHoaDon
    @id_chiTietHoaDon INT,
    @SoLuong INT
AS
BEGIN
    UPDATE ChiTietHoaDon
    SET SoLuong = @SoLuong, ThanhTien = SoLuong * DonGia
    WHERE id_chiTietHoaDon = @id_chiTietHoaDon;
END;
GO

GO
CREATE PROCEDURE DeleteChiTietHoaDon
    @id_chiTietHoaDon INT
AS
BEGIN
    DELETE FROM ChiTietHoaDon WHERE id_chiTietHoaDon = @id_chiTietHoaDon;
END;
GO

-- Trigger tự động cập nhật TongTien trong HoaDon
GO
CREATE TRIGGER UpdateTongTienHoaDon
ON ChiTietHoaDon
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE HoaDon
    SET TongTien = (
        SELECT ISNULL(SUM(ThanhTien), 0)
        FROM ChiTietHoaDon
        WHERE ChiTietHoaDon.id_hoaDon = HoaDon.id_hoaDon
    )
    WHERE id_hoaDon IN (
        SELECT id_hoaDon FROM INSERTED
        UNION
        SELECT id_hoaDon FROM DELETED
    );
END;
GO

-- Stored Procedures Get (đã có, giữ nguyên)
GO
CREATE PROCEDURE GetThucUong AS BEGIN SELECT * FROM ThucUong; END;
GO
CREATE PROCEDURE GetBan AS BEGIN SELECT * FROM Ban; END;
GO
CREATE PROCEDURE GetHoaDon AS BEGIN SELECT * FROM HoaDon; END;
GO
CREATE PROCEDURE GetTaiKhoan AS BEGIN SELECT * FROM TaiKhoan; END;
GO
CREATE PROCEDURE GetNhanVien AS BEGIN SELECT * FROM NhanVien; END;
GO
CREATE PROCEDURE GetChiTietHoaDon AS BEGIN SELECT * FROM ChiTietHoaDon; END;
GO

-- Dữ liệu mẫu
INSERT INTO LoaiThucUong (Ten) VALUES (N'Trà sữa'), (N'Nước ép');
INSERT INTO ThucUong (Ten, id_loaiThucUong, Gia) VALUES (N'Trà sữa thái', 1, 25000), (N'Nước ép cam', 2, 30000);
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Loai) VALUES (N'admin', N'123456', N'Quan li');
INSERT INTO NhanVien (TenDangNhap, HoTen, GioiTinh, DienThoai, ChucVu) VALUES (N'admin', N'Nguyễn Văn A', N'Nam', N'0123456789', N'Quản lý');
INSERT INTO Ban (Ten) VALUES (N'Bàn 1'), (N'Bàn 2');

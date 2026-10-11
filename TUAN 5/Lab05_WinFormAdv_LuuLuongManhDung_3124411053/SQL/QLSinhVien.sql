
IF DB_ID(N'QLSinhVien') IS NULL CREATE DATABASE QLSinhVien;
GO
USE QLSinhVien;
GO

IF OBJECT_ID(N'dbo.Khoa', N'U') IS NULL
CREATE TABLE dbo.Khoa (
    MaKhoa  VARCHAR(10)   NOT NULL PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);
IF OBJECT_ID(N'dbo.Lop', N'U') IS NULL
CREATE TABLE dbo.Lop (
    MaLop  VARCHAR(10)   NOT NULL PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(10)   NOT NULL REFERENCES dbo.Khoa(MaKhoa)
);
IF OBJECT_ID(N'dbo.SinhVien', N'U') IS NULL
CREATE TABLE dbo.SinhVien (
    MaSinhVien VARCHAR(15)   NOT NULL PRIMARY KEY,
    HoTen      NVARCHAR(100) NOT NULL,
    NgaySinh   DATE          NOT NULL,
    MaLop      VARCHAR(10)   NOT NULL REFERENCES dbo.Lop(MaLop)
);
IF OBJECT_ID(N'dbo.MonHoc', N'U') IS NULL
CREATE TABLE dbo.MonHoc (
    MaMonHoc  VARCHAR(10)   NOT NULL PRIMARY KEY,
    TenMonHoc NVARCHAR(100) NOT NULL
);
IF OBJECT_ID(N'dbo.Diem', N'U') IS NULL
CREATE TABLE dbo.Diem (
    MaSinhVien VARCHAR(15) NOT NULL REFERENCES dbo.SinhVien(MaSinhVien),
    MaMonHoc   VARCHAR(10) NOT NULL REFERENCES dbo.MonHoc(MaMonHoc),
    Diem       FLOAT       NOT NULL CHECK (Diem BETWEEN 0 AND 10),
    PRIMARY KEY (MaSinhVien, MaMonHoc)
);
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Khoa)
INSERT dbo.Khoa(MaKhoa, TenKhoa) VALUES
 ('CNTT', N'Công nghệ thông tin'), ('KT', N'Kinh tế'), ('CK', N'Cơ khí'),
 ('HOA', N'Công nghệ hóa học'), ('DT', N'Điện – Điện tử');

IF NOT EXISTS (SELECT 1 FROM dbo.Lop)
INSERT dbo.Lop(MaLop, TenLop, MaKhoa) VALUES
 ('05DHTH1', N'Đại học Tin học 1', 'CNTT'), ('05DHTH2', N'Đại học Tin học 2', 'CNTT'),
 ('05DHKT1', N'Đại học Kinh tế 1', 'KT'),   ('05DHCK1', N'Đại học Cơ khí 1', 'CK'),
 ('05DHHH1', N'Đại học Hóa học 1', 'HOA');

IF NOT EXISTS (SELECT 1 FROM dbo.SinhVien)
INSERT dbo.SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop) VALUES
 ('2001140001', N'Nguyễn Văn An',  '2002-03-15', '05DHTH1'),
 ('2001140002', N'Trần Thị Bình',  '2002-07-21', '05DHTH1'),
 ('2001140003', N'Lê Quang Cường', '2002-11-02', '05DHTH2'),
 ('2001140004', N'Phạm Thu Dung',  '2001-12-30', '05DHKT1'),
 ('2001140005', N'Hoàng Minh Em',  '2002-05-09', '05DHCK1');

IF NOT EXISTS (SELECT 1 FROM dbo.MonHoc)
INSERT dbo.MonHoc(MaMonHoc, TenMonHoc) VALUES
 ('LTNET', N'Lập trình .NET'), ('CSDL', N'Cơ sở dữ liệu'), ('CTDL', N'Cấu trúc dữ liệu'),
 ('MMT', N'Mạng máy tính'),    ('TA1', N'Tiếng Anh 1');

IF NOT EXISTS (SELECT 1 FROM dbo.Diem)
INSERT dbo.Diem(MaSinhVien, MaMonHoc, Diem) VALUES
 ('2001140001', 'LTNET', 8.5), ('2001140001', 'CSDL', 7.0), ('2001140002', 'LTNET', 9.0),
 ('2001140003', 'CTDL', 6.5),  ('2001140004', 'TA1', 8.0);
GO

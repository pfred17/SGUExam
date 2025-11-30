CREATE DATABASE SGUExam2;
GO

USE SGUExam2;
GO

CREATE TABLE [nguoi_dung] (
  [ma_nd] VARCHAR(255) PRIMARY KEY,
  [ten_dang_nhap] VARCHAR(50) UNIQUE NOT NULL,
  [mat_khau] VARCHAR(255) NOT NULL,
  [ho_ten] nvarchar(100) NOT NULL,
  [email] VARCHAR(100) UNIQUE NOT NULL,
  [loai_nd] nvarchar(255) NOT NULL CHECK ([loai_nd] IN (N'Sinh viên', N'Giảng viên', N'Quản trị')),
  [gioi_tinh] TINYINT DEFAULT (1), -- 1: nam, 2: nữ
  [trang_thai] TINYINT DEFAULT (1)
)
GO

CREATE TABLE [nhom_quyen] (
  [ma_nhom_quyen] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ten_nhom_quyen] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [quyen] (
  [ma_quyen] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ten_quyen] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [chuc_nang] (
  [ma_chuc_nang] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ten_chuc_nang] nvarchar(100) NOT NULL
)
GO

CREATE TABLE [nhom_quyen_chuc_nang] (
  [ma_nhom_quyen] BIGINT NOT NULL,
  [ma_chuc_nang] BIGINT NOT NULL,
  [ma_quyen] BIGINT NOT NULL,
  [duoc_phep] TINYINT DEFAULT (0),
  PRIMARY KEY ([ma_nhom_quyen], [ma_chuc_nang], [ma_quyen])
)
GO

CREATE TABLE [nguoi_dung_nhom_quyen] (
  [ma_nd] VARCHAR(255) NOT NULL,
  [ma_nhom_quyen] BIGINT NOT NULL,
  PRIMARY KEY ([ma_nd], [ma_nhom_quyen])
)
GO

CREATE TABLE [mon_hoc] (
  [ma_mh] BIGINT PRIMARY KEY,
  [ten_mh] nvarchar(100) NOT NULL,
  [so_tin_chi] INT NOT NULL,
  [trang_thai] TINYINT DEFAULT (1)
)
GO

CREATE TABLE [chuong] (
  [ma_chuong] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ma_mh] BIGINT,
  [ten_chuong] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [cau_hoi] (
  [ma_cau_hoi] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ma_chuong] BIGINT,
  [noi_dung] nvarchar(255) NOT NULL,
  [do_kho] nvarchar(255) NOT NULL CHECK ([do_kho] IN (N'Dễ', N'Trung bình', N'Khó')),
  [trang_thai] TINYINT DEFAULT (1)
)
GO

CREATE TABLE [dap_an] (
  [ma_dap_an] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ma_cau_hoi] BIGINT,
  [noi_dung] nvarchar(255) NOT NULL,
  [dung] TINYINT DEFAULT (0)
)
GO

CREATE TABLE [nhom_hoc_phan] (
  [ma_nhom] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ma_mh] BIGINT,
  [ten_nhom] nvarchar(100) NOT NULL,
  [ghi_chu] nvarchar(255) NOT NULL,
  [hoc_ky] nvarchar(20) NOT NULL,
  [nam_hoc] nvarchar(20) NOT NULL,
  [trang_thai] TINYINT DEFAULT (1)
)
GO

CREATE TABLE [chi_tiet_nhom_hoc_phan] (
  [ma_nd] VARCHAR(255) NOT NULL,
  [ma_nhom] BIGINT NOT NULL,
  [ma_diem_danh] BIGINT,
  PRIMARY KEY ([ma_nd], [ma_nhom])
)
GO

CREATE TABLE [phan_cong] (
  [ma_pc] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ma_nd] VARCHAR(255),
  [ma_mh] BIGINT,
)
GO

CREATE TABLE [de_thi] (
  [ma_de] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ten_de] nvarchar(255) NOT NULL,
  [thoi_gian_bat_dau] DATETIME,
  [thoi_gian_ket_thuc] DATETIME,
  [thoi_gian_lam_bai] INT,
  [canh_bao_neu_duoi] INT,
  [so_cau_de] INT,
  [so_cau_trung_binh] INT,
  [so_cau_kho] INT,
  [trang_thai] TINYINT DEFAULT (1)
)
GO

CREATE TABLE [de_thi_cau_hinh] (
  [ma_de] BIGINT PRIMARY KEY,
  [tu_dong_lay] TINYINT,
  [xem_diem_sau_thi] TINYINT,
  [xem_dap_an_sau_thi] TINYINT,
  [xem_bai_lam] TINYINT,
  [dao_cau_hoi] TINYINT,
  [dao_dap_an] TINYINT,
  [tu_dong_nop] TINYINT,
  [de_luyen_tap] TINYINT,
  [tinh_diem] TINYINT
)
GO

CREATE TABLE [de_thi_chuong] (
  [ma_de] BIGINT NOT NULL,
  [ma_chuong] BIGINT NOT NULL,
  PRIMARY KEY ([ma_de], [ma_chuong])
)
GO

CREATE TABLE [de_thi_nhom] (
  [ma_de] BIGINT NOT NULL,
  [ma_nhom] BIGINT NOT NULL,
  PRIMARY KEY ([ma_de], [ma_nhom])
)
GO

CREATE TABLE [bai_lam] (
  [ma_bai] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ma_de] BIGINT,
  [ma_nd] VARCHAR(255),
  [thoi_gian_bat_dau] DATETIME,
  [thoi_gian_nop] DATETIME,
  [diem] DECIMAL(5,2)
)
GO

CREATE TABLE [bai_lam_chi_tiet] (
  [ma_bai] BIGINT NOT NULL,
  [ma_cau_hoi] BIGINT NOT NULL,
  [ma_dap_an_chon] BIGINT,
  PRIMARY KEY ([ma_bai], [ma_cau_hoi])
)
GO

CREATE TABLE [diem_danh] (
  [ma_dd] BIGINT PRIMARY KEY IDENTITY(1, 1),
  [ma_nhom] BIGINT,
  [ma_nd] VARCHAR(255),
  [thoi_gian] DATETIME,
  [trang_thai] TINYINT DEFAULT (1)
)
GO

ALTER TABLE [nhom_quyen_chuc_nang] ADD FOREIGN KEY ([ma_nhom_quyen]) REFERENCES [nhom_quyen] ([ma_nhom_quyen])
GO

ALTER TABLE [nhom_quyen_chuc_nang] ADD FOREIGN KEY ([ma_chuc_nang]) REFERENCES [chuc_nang] ([ma_chuc_nang])
GO

ALTER TABLE [nhom_quyen_chuc_nang] ADD FOREIGN KEY ([ma_quyen]) REFERENCES [quyen] ([ma_quyen])
GO

ALTER TABLE [nguoi_dung_nhom_quyen] ADD FOREIGN KEY ([ma_nd]) REFERENCES [nguoi_dung] ([ma_nd])
GO

ALTER TABLE [nguoi_dung_nhom_quyen] ADD FOREIGN KEY ([ma_nhom_quyen]) REFERENCES [nhom_quyen] ([ma_nhom_quyen])
GO

ALTER TABLE [chuong] ADD FOREIGN KEY ([ma_mh]) REFERENCES [mon_hoc] ([ma_mh])
GO

ALTER TABLE [cau_hoi] ADD FOREIGN KEY ([ma_chuong]) REFERENCES [chuong] ([ma_chuong])
GO

ALTER TABLE [dap_an] ADD FOREIGN KEY ([ma_cau_hoi]) REFERENCES [cau_hoi] ([ma_cau_hoi])
GO

ALTER TABLE [nhom_hoc_phan] ADD FOREIGN KEY ([ma_mh]) REFERENCES [mon_hoc] ([ma_mh])
GO

ALTER TABLE [chi_tiet_nhom_hoc_phan] ADD FOREIGN KEY ([ma_nd]) REFERENCES [nguoi_dung] ([ma_nd])
GO

ALTER TABLE [chi_tiet_nhom_hoc_phan] ADD FOREIGN KEY ([ma_nhom]) REFERENCES [nhom_hoc_phan] ([ma_nhom])
GO

ALTER TABLE [phan_cong] ADD FOREIGN KEY ([ma_mh]) REFERENCES [mon_hoc] ([ma_mh])
GO

ALTER TABLE [phan_cong] ADD FOREIGN KEY ([ma_nd]) REFERENCES [nguoi_dung] ([ma_nd])
GO

ALTER TABLE [de_thi_cau_hinh] ADD FOREIGN KEY ([ma_de]) REFERENCES [de_thi] ([ma_de])
GO

ALTER TABLE [de_thi_chuong] ADD FOREIGN KEY ([ma_de]) REFERENCES [de_thi] ([ma_de])
GO

ALTER TABLE [de_thi_chuong] ADD FOREIGN KEY ([ma_chuong]) REFERENCES [chuong] ([ma_chuong])
GO

ALTER TABLE [de_thi_nhom] ADD FOREIGN KEY ([ma_de]) REFERENCES [de_thi] ([ma_de])
GO

ALTER TABLE [de_thi_nhom] ADD FOREIGN KEY ([ma_nhom]) REFERENCES [nhom_hoc_phan] ([ma_nhom])
GO

ALTER TABLE [bai_lam] ADD FOREIGN KEY ([ma_de]) REFERENCES [de_thi] ([ma_de])
GO

ALTER TABLE [bai_lam] ADD FOREIGN KEY ([ma_nd]) REFERENCES [nguoi_dung] ([ma_nd])
GO

ALTER TABLE [bai_lam_chi_tiet] ADD FOREIGN KEY ([ma_bai]) REFERENCES [bai_lam] ([ma_bai])
GO

ALTER TABLE [bai_lam_chi_tiet] ADD FOREIGN KEY ([ma_cau_hoi]) REFERENCES [cau_hoi] ([ma_cau_hoi])
GO

ALTER TABLE [bai_lam_chi_tiet] ADD FOREIGN KEY ([ma_dap_an_chon]) REFERENCES [dap_an] ([ma_dap_an])
GO

ALTER TABLE [diem_danh] ADD FOREIGN KEY ([ma_nhom]) REFERENCES [nhom_hoc_phan] ([ma_nhom])
GO

ALTER TABLE [diem_danh] ADD FOREIGN KEY ([ma_nd]) REFERENCES [nguoi_dung] ([ma_nd])
GO

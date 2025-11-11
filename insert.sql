USE SGUExam;
GO

-- 1. Bảng nhóm quyền
INSERT INTO [nhom_quyen] ([ten_nhom_quyen]) VALUES
(N'Sinh viên'),
(N'Giảng viên'),
(N'Quản trị');
GO

-- 2. Bảng quyền
INSERT INTO [quyen] ([ten_quyen]) VALUES
(N'Xem'),
(N'Thêm'),
(N'Sửa'),
(N'Xóa');
GO

-- 3. Bảng chức năng
INSERT INTO [chuc_nang] ([ten_chuc_nang]) VALUES
(N'Quản lý người dùng'),
(N'Quản lý môn học'),
(N'Quản lý câu hỏi'),
(N'Quản lý đề thi'),
(N'Làm bài thi'),
(N'Xem điểm');
GO

-- 4. Bảng người dùng
INSERT INTO [nguoi_dung] ([ten_dang_nhap], [mat_khau], [ho_ten], [email], [loai_nd], [trang_thai]) VALUES
('admin', '123456', N'Nguyễn Quản Trị', 'admin@sgu.edu.vn', N'Quản trị', 1),
('trangiangvien', '123456', N'Trần Giảng Viên', 'gv01@sgu.edu.vn', N'Giảng viên', 1),
('lesinhvien', '123456', N'Lê Sinh Viên', 'sv01@sgu.edu.vn', N'Sinh viên', 1),
('phamhocvien', '123456', N'Phạm Học Viên', 'sv02@sgu.edu.vn', N'Sinh viên', 1);
GO

-- 5. Liên kết người dùng - nhóm quyền
INSERT INTO [nguoi_dung_nhom_quyen] ([ma_nd], [ma_nhom_quyen]) VALUES
(1, 3), -- admin -> Quản trị
(2, 2), -- giảng viên -> Giảng viên
(3, 1), -- sinh viên -> Sinh viên
(4, 1);
GO

-- 6. Nhóm quyền - chức năng - quyền
INSERT INTO [nhom_quyen_chuc_nang] ([ma_nhom_quyen], [ma_chuc_nang], [ma_quyen], [duoc_phep]) VALUES
-- Quản trị: full quyền
(3, 1, 1, 1), (3, 1, 2, 1), (3, 1, 3, 1), (3, 1, 4, 1),
(3, 2, 1, 1), (3, 2, 2, 1), (3, 2, 3, 1), (3, 2, 4, 1),
(3, 3, 1, 1), (3, 3, 2, 1), (3, 3, 3, 1), (3, 3, 4, 1),
(3, 4, 1, 1), (3, 4, 2, 1), (3, 4, 3, 1), (3, 4, 4, 1),

-- Giảng viên: quản lý môn, câu hỏi, đề thi
(2, 2, 1, 1), (2, 2, 2, 1), (2, 3, 1, 1), (2, 3, 2, 1), (2, 4, 1, 1), (2, 4, 2, 1),

-- Sinh viên: làm bài, xem điểm
(1, 5, 1, 1), (1, 6, 1, 1);
GO

-- 7. Môn học
INSERT INTO [mon_hoc] ([ten_mh], [so_tin_chi], [trang_thai]) VALUES
(N'Cơ sở dữ liệu', 3, 1),
(N'Lập trình C#', 4, 1);
GO

-- 8. Chương
INSERT INTO [chuong] ([ma_mh], [ten_chuong]) VALUES
(1, N'Giới thiệu về CSDL'),
(1, N'Mô hình ERD'),
(2, N'Cấu trúc chương trình C#'),
(2, N'Lập trình hướng đối tượng');
GO

-- 9. Câu hỏi
INSERT INTO [cau_hoi] ([ma_chuong], [noi_dung], [do_kho], [trang_thai]) VALUES
(1, N'CSDL là gì?', N'Dễ', 1),
(2, N'Mô hình ER là gì?', N'Trung bình', 1),
(3, N'Phương thức trong C# là gì?', N'Dễ', 1),
(4, N'Tính kế thừa là gì trong OOP?', N'Khó', 1);
GO

-- 10. Đáp án
INSERT INTO [dap_an] ([ma_cau_hoi], [noi_dung], [dung]) VALUES
(1, N'Hệ thống quản lý dữ liệu', 1),
(1, N'Một ngôn ngữ lập trình', 0),
(2, N'Mô hình biểu diễn quan hệ giữa thực thể', 1),
(3, N'Hàm định nghĩa hành vi của đối tượng', 1),
(4, N'Khả năng chia sẻ thuộc tính và phương thức', 1);
GO

-- 11. Nhóm học phần
INSERT INTO [nhom_hoc_phan] ([ma_mh], [ten_nhom], [hoc_ky], [nam_hoc], [trang_thai]) VALUES
(1, N'Cơ sở lập trình - Nhóm 03', 'HK1', '2025-2026', 1),
(2, N'Lập trình C# - Nhóm 10', 'HK1', '2025-2026', 1);
GO

-- 12. Chi tiết nhóm học phần
INSERT INTO [chi_tiet_nhom_hoc_phan] ([ma_nd], [ma_nhom]) VALUES
(3, 1), (4, 1),
(3, 2), (4, 2);
GO

-- 13. Phân công giảng viên
INSERT INTO [phan_cong] ([ma_nd], [ma_nhom], [vai_tro]) VALUES
(2, 1, N'Giảng dạy'),
(2, 2, N'Giảng dạy');
GO

-- 14. Đề thi
INSERT INTO [de_thi] ([ten_de], [thoi_gian_bat_dau], [thoi_gian_ket_thuc], [thoi_gian_lam_bai],
 [canh_bao_neu_duoi], [so_cau_de], [so_cau_trung_binh], [so_cau_kho], [trang_thai])
VALUES
(N'Đề giữa kỳ CSDL', '2025-11-10 08:00', '2025-11-10 10:00', 60, 40, 2, 1, 1, 1),
(N'Đề giữa kỳ C#', '2025-11-12 08:00', '2025-11-12 10:00', 60, 40, 2, 1, 1, 1);
GO

-- 15. Cấu hình đề thi
INSERT INTO [de_thi_cau_hinh] ([ma_de], [tu_dong_lay], [xem_diem_sau_thi], [xem_dap_an_sau_thi],
 [xem_bai_lam], [dao_cau_hoi], [dao_dap_an], [tu_dong_nop], [de_luyen_tap], [tinh_diem])
VALUES
(1, 1, 1, 1, 1, 1, 1, 1, 0, 1),
(2, 1, 1, 0, 0, 1, 1, 1, 0, 1);
GO

-- 16. Liên kết đề thi - chương
INSERT INTO [de_thi_chuong] ([ma_de], [ma_chuong]) VALUES
(1, 1), (1, 2),
(2, 3), (2, 4);
GO

-- 17. Liên kết đề thi - nhóm học phần
INSERT INTO [de_thi_nhom] ([ma_de], [ma_nhom]) VALUES
(1, 1), (2, 2);
GO

-- 18. Bài làm
INSERT INTO [bai_lam] ([ma_de], [ma_nd], [thoi_gian_bat_dau], [thoi_gian_nop], [diem]) VALUES
(1, 3, '2025-11-10 08:00', '2025-11-10 09:00', 8.5),
(1, 4, '2025-11-10 08:05', '2025-11-10 09:05', 7.0);
GO

-- 19. Bài làm chi tiết
INSERT INTO [bai_lam_chi_tiet] ([ma_bai], [ma_cau_hoi], [ma_dap_an_chon]) VALUES
(1, 1, 1),
(1, 2, 3),
(2, 1, 2),
(2, 2, 3);
GO

-- 20. Điểm danh
INSERT INTO [diem_danh] ([ma_nhom], [ma_nd], [thoi_gian], [trang_thai]) VALUES
(1, 3, GETDATE(), 1),
(1, 4, GETDATE(), 1),
(2, 3, GETDATE(), 1);
GO

-- 21. Thông báo
INSERT INTO [thong_bao] ([ma_nd_gui], [tieu_de], [noi_dung], [thoi_gian_gui]) VALUES
(2, N'Thông báo thi giữa kỳ', N'Sinh viên chú ý thi giữa kỳ vào ngày 10/11.', GETDATE()),
(1, N'Cập nhật hệ thống', N'Hệ thống SGUExam sẽ bảo trì vào cuối tuần.', GETDATE());
GO

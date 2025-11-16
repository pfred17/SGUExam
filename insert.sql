USE SGUExam2;
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
(N'Xóa'),
(N'Tham gia học phần'),
(N'Tham gia thi');
GO

-- 3. Bảng chức năng
INSERT INTO [chuc_nang] ([ten_chuc_nang]) VALUES
(N'Quản lý nhóm học phần'),
(N'Quản lý câu hỏi'),
(N'Quản lý môn học'),
(N'Quản lý phân công'),
(N'Quản lý đề kiểm tra'),
(N'Quản lý điểm danh'),
(N'Phân quyền'),
(N'Quản lý người dùng'),
(N'Làm bài thi'),
(N'Xem điểm');
GO

-- 4. Bảng người dùng
INSERT INTO [nguoi_dung] ([ma_nd], [ten_dang_nhap], [mat_khau], [ho_ten], [email], [loai_nd], [gioi_tinh], [trang_thai]) VALUES
('0000000000', 'admin', '123456', N'Admin', 'admin@sgu.edu.vn', N'Quản trị', 1, 1),
('3122410320','phuc', '123456', N'Huỳnh Lê Phúc', 'gv01@sgu.edu.vn', N'Giảng viên', 1, 1),
('3122410238','phu', '123456', N'Nguyễn Hoàng Phú', 'sv02@sgu.edu.vn', N'Sinh viên', 0, 1),
('3122410233','phong', '123456', N'Đinh Nguyễn Duy Phong', 'sv03@sgu.edu.vn', N'Sinh viên', 1, 1),
('3122410218','de', '123456', N'Hồ Công Đệ', 'sv04@sgu.edu.vn', N'Sinh viên', 0, 1),
('3122413118','canh', '123456', N'Nguyễn Tấn Cảnh', 'sv05@sgu.edu.vn', N'Giảng viên', 0, 1),
('3122410023','bao', '123456', N'Phan Xuân Bảo', 'sv06@sgu.edu.vn', N'Sinh viên', 1, 1);
GO

-- 5. Liên kết người dùng - nhóm quyền
INSERT INTO [nguoi_dung_nhom_quyen] ([ma_nd], [ma_nhom_quyen]) VALUES
('0000000000', 3), -- admin -> Quản trị
('3122410320', 2), -- giảng viên -> Giảng viên
('3122413118', 2),
('3122410238', 1), -- sinh viên -> Sinh viên
('3122410218', 1),
('3122410233', 1),
('3122410023', 1);
GO

-- 6. Nhóm quyền - chức năng - quyền
INSERT INTO [nhom_quyen_chuc_nang] ([ma_nhom_quyen], [ma_chuc_nang], [ma_quyen], [duoc_phep]) VALUES
-- Quản trị: full quyền
(3, 1, 1, 1), (3, 1, 2, 1), (3, 1, 3, 1), (3, 1, 4, 1),
(3, 2, 1, 1), (3, 2, 2, 1), (3, 2, 3, 1), (3, 2, 4, 1),
(3, 3, 1, 1), (3, 3, 2, 1), (3, 3, 3, 1), (3, 3, 4, 1),
(3, 4, 1, 1), (3, 4, 2, 1), (3, 4, 3, 1), (3, 4, 4, 1),
(3, 5, 1, 1), (3, 5, 2, 1), (3, 5, 3, 1), (3, 5, 4, 1),
(3, 6, 1, 1), (3, 6, 2, 1), (3, 6, 3, 1), (3, 6, 4, 1),
(3, 7, 1, 1), (3, 7, 2, 1), (3, 7, 3, 1), (3, 7, 4, 1),
(3, 8, 1, 1), (3, 8, 2, 1), (3, 8, 3, 1), (3, 8, 4, 1),

-- Giảng viên: quản lý học phân, câu hỏi, đề kiểm tra, điểm danh
(2, 1, 1, 1), (2, 1, 2, 1), (2, 1, 3, 1), (2, 1, 4, 1),
(2, 2, 1, 1), (2, 2, 2, 1), (2, 2, 3, 1), (2, 2, 4, 1),
(2, 5, 1, 1), (2, 5, 2, 1), (2, 5, 3, 1), (2, 5, 4, 1),
(2, 6, 1, 1), (2, 6, 2, 1), (2, 6, 3, 1), (2, 6, 4, 1),

-- Sinh viên: Tham gia học phần, Tham gia thi
(1, 1, 5, 1),
(1, 5, 6, 1)
GO


-- 7. Môn học
INSERT INTO [mon_hoc] ([ma_mh], [ten_mh], [so_tin_chi], [trang_thai]) VALUES
(841001, N'Cơ sở dữ liệu', 3, 1),
(841002, N'Lập trình C#', 4, 1),
(841003, N'Trí tuệ nhân tạo', 3, 1),
(841004, N'Máy học', 4, 1),
(841005, N'Lập trình web', 3, 1),
(841006, N'Cơ sở dữ liệu nâng cao', 3, 1),
(841007, N'Phát triển ứng dụng di động', 4, 1),
(841008, N'An toàn thông tin', 3, 1),
(841009, N'Nhập môn lập trình', 3, 1),
(841010, N'Cấu trúc dữ liệu và giải thuật', 3, 1),
(841011, N'Hệ điều hành', 3, 1),
(841012, N'Mạng máy tính', 3, 1),
(841013, N'Đồ họa máy tính', 4, 1),
(841014, N'Phân tích và thiết kế hệ thống', 3, 1),
(841015, N'Quản lý dự án phần mềm', 3, 1),
(841016, N'Lập trình Java', 4, 1),
(841017, N'Thống kê ứng dụng', 3, 1),
(841018, N'Xử lý ảnh và thị giác máy tính', 3, 1),
(841019, N'Tin học văn phòng nâng cao', 2, 1),
(841020, N'Pháp luật đại cương', 2, 1);
GO

-- 8. Chương
INSERT INTO [chuong] ([ma_mh], [ten_chuong]) VALUES
(841001, N'Giới thiệu về CSDL'),
(841001, N'Mô hình ERD'),
(841002, N'Cấu trúc chương trình C#'),
(841002, N'Lập trình hướng đối tượng'),
(841003, N'Giới thiệu về AI'),
(841003, N'Mạng nơ-ron'),
(841004, N'Học có giám sát'),
(841004, N'Học không giám sát'),
(841005, N'HTML & CSS'),
(841005, N'JavaScript cơ bản'),
(841006, N'SQL nâng cao'),
(841006, N'NoSQL'),
(841007, N'Android Layout'),
(841007, N'Kotlin cơ bản'),
(841008, N'Mã hóa dữ liệu'),
(841008, N'Xác thực 2 yếu tố'),
(841009, N'Biến và kiểu dữ liệu'),
(841009, N'Cấu trúc điều khiển'),
(841010, N'Danh sách liên kết'),
(841010, N'Cây nhị phân');
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
INSERT INTO [nhom_hoc_phan] ([ma_mh], [ten_nhom], [ghi_chu], [hoc_ky], [nam_hoc], [trang_thai]) VALUES
(841001, N'CSDL - Nhóm 01', N'Buổi sáng', 'HK1', '2025-2026', 1),
(841001, N'CSDL - Nhóm 02', N'Buổi chiều', 'HK1', '2025-2026', 1),
(841002, N'C# - Nhóm 01', N'Thực hành', 'HK1', '2025-2026', 1),
(841002, N'C# - Nhóm 02', N'Lý thuyết', 'HK1', '2025-2026', 1),
(841003, N'AI - Nhóm 01', N'Nghiên cứu', 'HK1', '2025-2026', 1),
(841004, N'ML - Nhóm 01', N'Thực hành', 'HK1', '2025-2026', 1),
(841005, N'Web - Nhóm 01', N'Dự án', 'HK1', '2025-2026', 1),
(841006, N'CSDL NC - Nhóm 01', N'Nâng cao', 'HK1', '2025-2026', 1),
(841007, N'Mobile - Nhóm 01', N'Android', 'HK1', '2025-2026', 1),
(841008, N'Security - Nhóm 01', N'An ninh', 'HK1', '2025-2026', 1),
(841009, N'Nhập môn - Nhóm 01', N'Cơ bản', 'HK1', '2025-2026', 1),
(841010, N'CTDL - Nhóm 01', N'Thực hành', 'HK1', '2025-2026', 1),
(841011, N'Hệ điều hành - Nhóm 01', N'Linux', 'HK1', '2025-2026', 1),
(841012, N'Mạng - Nhóm 01', N'Thực hành', 'HK1', '2025-2026', 1),
(841013, N'Đồ họa - Nhóm 01', N'OpenGL', 'HK1', '2025-2026', 1),
(841014, N'Java - Nhóm 01', N'Spring', 'HK1', '2025-2026', 1),
(841015, N'Thống kê - Nhóm 01', N'R', 'HK1', '2025-2026', 1),
(841016, N'Xử lý ảnh - Nhóm 01', N'OpenCV', 'HK1', '2025-2026', 1),
(841017, N'Tin học VP - Nhóm 01', N'Excel', 'HK1', '2025-2026', 1),
(841018, N'Pháp luật - Nhóm 01', N'Buổi tối', 'HK1', '2025-2026', 1);
GO
-- 12. Chi tiết nhóm học phần
INSERT INTO [chi_tiet_nhom_hoc_phan] ([ma_nd], [ma_nhom]) VALUES
('3122410238', 3), ('3122410233', 3), ('3122410218', 3), ('3122410023', 3),
('3122410238', 4), ('3122410233', 4), ('3122410218', 4), ('3122410023', 4),
('3122410238', 5), ('3122410233', 5),
('3122410238', 6), ('3122410233', 6),
('3122410238', 7), ('3122410233', 7),
('3122410238', 8), ('3122410233', 8),
('3122410238', 9), ('3122410233', 9),
('3122410238', 10), ('3122410233', 10);
GO

-- 13. Phân công giảng viên
INSERT INTO [phan_cong] ([ma_nd], [ma_mh]) VALUES
('3122410320', 841001),
('3122410320', 841002),
('3122410320', 841003),
('3122410320', 841004),
('3122410320', 841005),
('3122410320', 841006),
('3122410320', 841007),
('3122410320', 841008),
('3122410320', 841009),
('3122410320', 841010),
('3122413118', 841001),
('3122413118', 841002),
('3122413118', 841003),
('3122413118', 841004),
('3122413118', 841005),
('3122413118', 841006),
('3122413118', 841007),
('3122413118', 841008),
('3122413118', 841009),
('3122413118', 841010);
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
(1, '3122410233', '2025-11-10 08:00', '2025-11-10 09:00', 8.5),
(1, '3122410023', '2025-11-10 08:05', '2025-11-10 09:05', 7.0);
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
(1, '3122410023', GETDATE(), 1),
(1, '3122410238', GETDATE(), 1),
(2, '3122410218', GETDATE(), 1);
GO

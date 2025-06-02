-- Tạo CSDL
CREATE DATABASE QLHD COLLATE Vietnamese_CI_AS;
GO

USE QLHD;
GO

-- Bảng Chucnang
CREATE TABLE Chucnang (
    Machucnang NVARCHAR(10) PRIMARY KEY,
    Tenchucnang NVARCHAR(100)
);
INSERT INTO Chucnang VALUES
(N'CN01', N'Phát hành báo'),
(N'CN02', N'Tuyển dụng'),
(N'CN03', N'Quảng cáo'),
(N'CN04', N'Viết bài'),
(N'CN05', N'Biên tập');

-- Bảng Bao
CREATE TABLE Bao (
    Mabao NVARCHAR(10) PRIMARY KEY,
    Tenbao NVARCHAR(100),
    Machucnang NVARCHAR(10),
    Diachi NVARCHAR(200),
    Dienthoai NVARCHAR(15),
    Email NVARCHAR(100),
	CONSTRAINT FK_Bao_Chucnang FOREIGN KEY (Machucnang) REFERENCES Chucnang(Machucnang)
);

INSERT INTO Bao VALUES
(N'B01', N'Báo Tuổi Trẻ', N'CN01', N'60 Lê Lợi, Q.1, TP.HCM', N'02838212345', N'tuoitre@gmail.com'),
(N'B02', N'Báo Thanh Niên', N'CN02', N'268 Lý Thường Kiệt, Q.10, TP.HCM', N'02838654321', N'thanhnien@gmail.com'),
(N'B03', N'Báo Lao Động', N'CN03', N'192 Nam Kỳ Khởi Nghĩa, Q.3', N'02838333456', N'laodong@gmail.com'),
(N'B04', N'Báo Pháp Luật', N'CN04', N'123 Lê Văn Sỹ, Q.Phú Nhuận', N'02839123456', N'phapluat@gmail.com'),
(N'B05', N'Báo Dân Trí', N'CN05', N'45 Trần Hưng Đạo, Q.1', N'02839776655', N'dantri@gmail.com');


-- Bảng Theloai
CREATE TABLE Theloai (
    Matheloai NVARCHAR(10) PRIMARY KEY,
    Tentheloai NVARCHAR(100)
);

INSERT INTO Theloai VALUES
(N'TL01', N'Chính trị'),
(N'TL02', N'Kinh tế'),
(N'TL03', N'Giáo dục'),
(N'TL04', N'Thể thao'),
(N'TL05', N'Giải trí');

-- Bảng Bao_Theloai
CREATE TABLE Bao_Theloai (
    Mabao NVARCHAR(10),
    Matheloai NVARCHAR(10),
    Ngayapdung DATE, 
    Nhuanbut DECIMAL(10,2),
    PRIMARY KEY (Mabao, Matheloai, Ngayapdung),
    FOREIGN KEY (Mabao) REFERENCES Bao(Mabao),
    FOREIGN KEY (Matheloai) REFERENCES Theloai(Matheloai)
);
INSERT INTO Bao_Theloai (Mabao, Matheloai, Ngayapdung, Nhuanbut)
VALUES 
-- B01 - TL01: tháng 1 đến tháng 6/2025
('B01', 'TL01', '2025-01-01', 200000),
('B01', 'TL01', '2025-02-01', 210000),
('B01', 'TL01', '2025-03-01', 220000),
('B01', 'TL01', '2025-04-01', 230000),
('B01', 'TL01', '2025-05-01', 240000),
('B01', 'TL01', '2025-06-01', 250000),

-- B02 - TL02: tháng 1 đến tháng 3/2025
('B02', 'TL02', '2025-01-01', 300000),
('B02', 'TL02', '2025-02-01', 310000),
('B02', 'TL02', '2025-03-01', 320000),

-- B03 - TL03: tháng 4 và 5
('B03', 'TL03', '2025-04-01', 280000),
('B03', 'TL03', '2025-05-01', 290000),

-- B04 - TL04: tháng 1
('B04', 'TL04', '2025-01-01', 400000);
-- Bảng Phongban
CREATE TABLE Phongban (
    Maphong NVARCHAR(10) PRIMARY KEY,
    Tenphong NVARCHAR(100),
    Mabao NVARCHAR(10),
    Dienthoai NVARCHAR(15),
    FOREIGN KEY (Mabao) REFERENCES Bao(Mabao)
);
INSERT INTO Phongban VALUES
(N'PB01', N'Phòng Chính trị', N'B01', N'0281234567'),
(N'PB02', N'Phòng Kinh tế', N'B01', N'0282233445'),
(N'PB03', N'Phòng Giáo dục', N'B02', N'0283322110'),
(N'PB04', N'Phòng Thể thao', N'B03', N'0284455667'),
(N'PB05', N'Phòng Giải trí', N'B04', N'0289988776');

-- Bảng Trinhdo
CREATE TABLE Trinhdo (
    MaTD NVARCHAR(10) PRIMARY KEY,
    TenTD NVARCHAR(100)
);
INSERT INTO Trinhdo VALUES
(N'TD01', N'Cử nhân'),
(N'TD02', N'Thạc sĩ'),
(N'TD03', N'Tiến sĩ'),
(N'TD04', N'Cao đẳng'),
(N'TD05', N'Trung cấp');

-- Bảng Chuyenmon
CREATE TABLE Chuyenmon (
    MaCM NVARCHAR(10) PRIMARY KEY,
    TenCM NVARCHAR(100)
);
INSERT INTO Chuyenmon VALUES
(N'CM01', N'Báo chí'),
(N'CM02', N'Kinh tế học'),
(N'CM03', N'Giáo dục học'),
(N'CM04', N'Thể thao học'),
(N'CM05', N'Văn học');

-- Bảng Chucvu
CREATE TABLE Chucvu (
    Machucvu NVARCHAR(10) PRIMARY KEY,
    Tenchucvu NVARCHAR(100)
);
INSERT INTO Chucvu VALUES
(N'CV01', N'Phóng viên'),
(N'CV02', N'Biên tập viên'),
(N'CV03', N'Trưởng phòng'),
(N'CV04', N'Phó phòng'),
(N'CV05', N'Tổng biên tập');

-- Bảng Nhanvien
CREATE TABLE Nhanvien (
    MaNV NVARCHAR(10) PRIMARY KEY,
    TenNV NVARCHAR(100),
    Mabao NVARCHAR(10),
    Maphong NVARCHAR(10),
    Machucvu NVARCHAR(10),
    Matrinhdo NVARCHAR(10),
    MaCM NVARCHAR(10),
    Diachi NVARCHAR(200),
    Ngaysinh DATE,
    Gioitinh NVARCHAR(10),
    Dienthoai NVARCHAR(15),
    Email NVARCHAR(100),
    FOREIGN KEY (Mabao) REFERENCES Bao(Mabao),
    FOREIGN KEY (Maphong) REFERENCES Phongban(Maphong),
    FOREIGN KEY (Machucvu) REFERENCES Chucvu(Machucvu),
    FOREIGN KEY (Matrinhdo) REFERENCES Trinhdo(MaTD),
    FOREIGN KEY (MaCM) REFERENCES Chuyenmon(MaCM)
);
INSERT INTO Nhanvien VALUES
(N'NV01', N'Nguyễn Văn A', N'B01', N'PB01', N'CV01', N'TD01', N'CM01', N'123 Lê Lợi', '1985-06-10', N'Nam', N'0281234567', N'nva@gmail.com'),
(N'NV02', N'Lê Thị B', N'B02', N'PB03', N'CV02', N'TD02', N'CM03', N'456 Lý Thái Tổ', '1990-04-22', N'Nữ', N'0287654321', N'ltb@gmail.com'),
(N'NV03', N'Trần Văn C', N'B03', N'PB04', N'CV03', N'TD03', N'CM04', N'789 Trần Hưng Đạo', '1982-12-01', N'Nam', N'0289988776', N'tvc@gmail.com'),
(N'NV04', N'Phạm Thị D', N'B04', N'PB05', N'CV02', N'TD01', N'CM05', N'321 Cách Mạng Tháng 8', '1987-11-11', N'Nữ', N'0281111222', N'ptd@gmail.com'),
(N'NV05', N'Võ Văn E', N'B05', N'PB02', N'CV04', N'TD04', N'CM02', N'88 Pasteur', '1993-07-30', N'Nam', N'0283333444', N'vve@gmail.com');


-- Bảng Linhvuchoatdong
CREATE TABLE Linhvuchoatdong (
    MaLVHD NVARCHAR(10) PRIMARY KEY,
    TenLVHD NVARCHAR(100)
);
INSERT INTO Linhvuchoatdong VALUES
(N'LV01', N'Giáo dục'),
(N'LV02', N'Kinh doanh'),
(N'LV03', N'Luật pháp'),
(N'LV04', N'Tài chính'),
(N'LV05', N'Văn hóa');

-- Bảng Khachhang
CREATE TABLE Khachhang (
    MaKH NVARCHAR(10) PRIMARY KEY,
    TenKH NVARCHAR(100),
    Diachi NVARCHAR(200),
    Dienthoai NVARCHAR(15),
    Didong NVARCHAR(15),
    Email NVARCHAR(100),
    MaLVHD NVARCHAR(10), 
    FOREIGN KEY (MaLVHD) REFERENCES Linhvuchoatdong(MaLVHD)
);
INSERT INTO Khachhang VALUES
(N'KH01', N'Công ty ABC', N'12 Trường Chinh', N'0285555111', N'0911222333', N'abc@congty.vn', N'LV01'),
(N'KH02', N'Công ty XYZ', N'34 Nguyễn Trãi', N'0284444222', N'0933444555', N'xyz@congty.vn', N'LV02'),
(N'KH03', N'Trường ĐH QG', N'45 Lê Văn Việt', N'0283333111', N'0922333444', N'dhqg@edu.vn', N'LV01'),
(N'KH04', N'Văn phòng Luật Hòa Bình', N'78 Pasteur', N'0287777666', N'0944555666', N'hoabinh@law.vn', N'LV03'),
(N'KH05', N'Công ty Truyền thông HTV', N'123 Cách Mạng Tháng 8', N'0288888999', N'0955666777', N'htv@media.vn', N'LV05');



-- Bảng Khachguibai
CREATE TABLE Khachguibai (
    Malangui NVARCHAR(10) PRIMARY KEY,
    MaKH NVARCHAR(10),
    Matheloai NVARCHAR(10),
    Mabao NVARCHAR(10),
    Tieude NVARCHAR(200),
    Noidung NTEXT,
    MaNV NVARCHAR(10),
    Ngaydang DATE,
    Nhuanbut DECIMAL(10,2),
    FOREIGN KEY (MaKH) REFERENCES Khachhang(MaKH),
    FOREIGN KEY (Matheloai) REFERENCES Theloai(Matheloai),
    FOREIGN KEY (Mabao) REFERENCES Bao(Mabao),
    FOREIGN KEY (MaNV) REFERENCES Nhanvien(MaNV)
);

-- Bảng TTQuangcao
CREATE TABLE TTQuangcao (
    MaQcao NVARCHAR(10) PRIMARY KEY,
    TenQcao NVARCHAR(100)
);
INSERT INTO TTQuangcao VALUES
(N'QC01', N'Quảng cáo banner'),
(N'QC02', N'Quảng cáo video'),
(N'QC03', N'Quảng cáo nội dung'),
(N'QC04', N'Tài trợ chuyên mục'),
(N'QC05', N'Popup quảng cáo');


-- Bảng Banggia
CREATE TABLE Banggia (
    Mabao NVARCHAR(10),
    MaQcao NVARCHAR(10),
    Dongia DECIMAL(10,2),
    PRIMARY KEY (Mabao, MaQcao),
    FOREIGN KEY (Mabao) REFERENCES Bao(Mabao),
    FOREIGN KEY (MaQcao) REFERENCES TTQuangcao(MaQcao)
);
INSERT INTO Banggia VALUES
(N'B01', N'QC01', 1000000),
(N'B01', N'QC02', 1500000),
(N'B02', N'QC03', 800000),
(N'B03', N'QC04', 1200000),
(N'B04', N'QC05', 500000);

-- Bảng KhachQuangcao
CREATE TABLE KhachQuangcao (
    MalanQC NVARCHAR(10) PRIMARY KEY,
    MaKH NVARCHAR(10),
    Mabao NVARCHAR(10),
    MaNV NVARCHAR(10),
    MaQcao NVARCHAR(10),
    Noidung NTEXT,
    NgayBD DATE,
    NgayKT DATE,
    Tongtien DECIMAL(10,2),
    FOREIGN KEY (MaKH) REFERENCES Khachhang(MaKH),
    FOREIGN KEY (Mabao) REFERENCES Bao(Mabao),
    FOREIGN KEY (MaNV) REFERENCES Nhanvien(MaNV),
    FOREIGN KEY (MaQcao) REFERENCES TTQuangcao(MaQcao)
);

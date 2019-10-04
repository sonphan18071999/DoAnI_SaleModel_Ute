Use PM_Ban_Hang
go
 DROP DATABASE PM_Ban_Hang;


CREATE TABLE [dbo].[Login] (
    [User]     NCHAR (10) NOT NULL,
    [Password] NCHAR (10) NOT NULL,
    [Type]     NCHAR (10) NOT NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([User] ASC)
);

CREATE TABLE [dbo].[SanPham] (
    [MaSP]       NCHAR (10)   NOT NULL,
    [TenSP]      NCHAR (20)   NOT NULL,
    [DonViTinh]  NCHAR (10)   NOT NULL,
    [DonGia]     FLOAT (53)   NOT NULL,
    [SoLuong]    NUMERIC (18) NOT NULL,
    [AnhSanPham] IMAGE        NULL,
    PRIMARY KEY CLUSTERED ([MaSP] ASC)
);
CREATE TABLE [dbo].[DonTam] (
    [MaSP]      NCHAR (10)   NOT NULL,
    [TenSP]     NCHAR (20)   NOT NULL,
    [DonGia]    FLOAT (53)   NOT NULL,
    [SoLuongSP] NUMERIC (18) NOT NULL,
	[MaDon] NUMERIC (18) NOT NULL,
);

CREATE TABLE [dbo].[HoaDon] (
    [MaHD]       NCHAR (10)   NOT NULL,
    [MaKH]       NCHAR (10)   NULL,
    [MaNV]       NCHAR (10)   NULL,
    [Ngay]       DATETIME     NOT NULL,
    [SoLuong]    NUMERIC (18) NOT NULL,
    [AnhSanPham] IMAGE        NOT NULL,
    PRIMARY KEY CLUSTERED ([MaHD] ASC)
);



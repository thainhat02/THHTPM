<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<header>
				<title>Danh mục hóa đơn</title>
			</header>
			<body>
				<h2>PHIẾU MUA HÀNG</h2>
				<div style="border:1px solid black; width=500px; text-align=center;">
				<table border="0">
					<tr>
						<td>
							<b>Hóa đơn: </b><xsl:value-of select="DS/HoaDon/MaHD"/>
						</td>
						<td>
							<b>Ngày bán: </b><xsl:value-of select="DS/HoaDon/NgayBan"/>
						</td>
					</tr>
					<tr>
						<td>
							<b>Loại hàng: </b><xsl:value-of select="DS/HoaDon/LoaiHang/@TenLoai"/>
						</td>
					</tr>
				</table>
				<table border="2" cellpadding="3">
					<tr>
						<td>Mã hàng</td>
						<td>Tên hàng</td>
						<td>Số lượng</td>
						<td>Đơn giá</td>
						<td>Thành tiền</td>
					</tr>
					<xsl:for-each select="DS/HoaDon/LoaiHang/Hang">
						<tr>
							<td>
								<xsl:value-of select="@MaHang"/>
							</td>
							<td>
								<xsl:value-of select="TenHang"/>
							</td>
							<td>
								<xsl:value-of select="SoLuong"/>
							</td>
							<td>
								<xsl:value-of select="DonGia"/>
							</td>
							<td>
								<xsl:value-of select="DonGia*SoLuong"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
				</div>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>

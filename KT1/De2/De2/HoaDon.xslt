<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head></head>
			<body>
				<h3>PHIẾU MUA HÀNG</h3>
				<b>Hóa đơn: </b> <xsl:value-of select="HoaDon/@MaHD"/>
				<br></br>
				<b>Loai Hàng: </b> <xsl:value-of select="HoaDon/LoaiHang/@TenLoai"/>
				<table border="1">
					<tr>
						<th>STT</th>
						<th>Tên hàng</th>
						<th>Số lượng</th>
						<th>Đơn giá</th>
						<th>Thành tiền</th>
					</tr>
					<xsl:for-each select="HoaDon/LoaiHang/Hang">
						<tr>
							<td>
								<xsl:value-of select="position()"/>
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
								<xsl:choose>
									<xsl:when test="SoLuong &gt; 100 and SoLuong &lt;= 200">
										<xsl:value-of select="SoLuong *(DonGia - DonGia*0.2)"/>
									</xsl:when>
									<xsl:when test="SoLuong &gt; 200">
										<xsl:value-of select="SoLuong *(DonGia - DonGia*0.3)"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:value-of select="SoLuong*DonGia"/>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>

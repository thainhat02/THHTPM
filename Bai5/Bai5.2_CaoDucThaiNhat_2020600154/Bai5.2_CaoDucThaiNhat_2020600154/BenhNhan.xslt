<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<body>
				
					<table border="0">
						<tr>
							<td>BỆNH VIỆN ĐA KHOA</td>
							<th>DANH SÁCH BÊNH NHÂN</th>
						</tr>
						<tr>
							<td>
								Khoa: <xsl:value-of select="BVDK/Khoa/TenKhoa"/>
							</td>
							<td>
								Phòng: <xsl:value-of select="BVDK/Khoa/Phong"/>
							</td>
						</tr>
					</table>

					<table border="1">
						<tr>
							<td>Mã số BN</td>
							<td>Họ tên</td>
							<td>Ngày nhập viện</td>
							<td>Số ngày điều trị</td>
							<td>Số tiền phải trả</td>
						</tr>
						<xsl:for-each select="BVDK/Khoa/BenhNhan">
							<tr>
								<td>
									<xsl:value-of select="@MasoBN"/>
								</td>
								<td>
									<xsl:value-of select="HoTen"/>
								</td>
								<td>
									<xsl:value-of select="GioiTinh"/>
								</td>
								<td>
									<xsl:value-of select="NgayNhapVien"/>
								</td>
								<td>
									<xsl:value-of select="15000*NgayDieuTri"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				
				
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>

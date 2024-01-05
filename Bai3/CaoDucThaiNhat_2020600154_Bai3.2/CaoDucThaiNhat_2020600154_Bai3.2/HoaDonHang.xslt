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
						<td>
							BỆNH VIỆN ĐA KHOA
						</td>
						<td>
							<b>DANH SÁCH BỆNH NHÂN</b>						
						</td>
					</tr>
					<tr>
						<td>
							Khoa: <xsl:value-of select="DS/Khoa/TenKhoa"/>
						</td>
					</tr>
				</table>

				<table border="2" cellpadding="10">
					<tr>
						<th>STT</th>
						<th>Họ tên</th>
						<th>Ngày nhập viện</th>
						<th>Số ngày điều trị</th>
						<th>Số tiền phải trả</th>
					</tr>
					<xsl:for-each select="DS/Khoa/Phong/BenhNhan">
					<tr>
						<td>
							<xsl:number value="position()" format="1"/>
						</td>
						<td>
							<xsl:value-of select="TenBN"/>
						</td>
						<td>
							<xsl:value-of select="NgayNhap"/>
						</td>
						<td>
							<xsl:value-of select="SoNgay"/>
						</td>
						<td>
							<xsl:value-of select="15000 * SoNgay"/>
						</td>
					</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>

<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head></head>
			<body>
				<h3>BẢNG TRI TRẢ VIỆN PHÍ</h3>
				<b>Tên bệnh viên: </b> <xsl:value-of select="DS/@TenBV"/>
				<br></br>
				<b>Tên khoa khám: </b> <xsl:value-of select="DS/Khoa/TenKhoa"/>
				<table border ="1">
					<tr>
						<th>STT</th>
						<th>Họ tên</th>
						<th>Số ngày nằm viện</th>
						<th>Viện phí</th>
					</tr>
					<xsl:for-each select="DS/Khoa/BenhNhan">
						<tr>
							<td>
								<xsl:value-of select="position()"/>
							</td>
							<td>
								<xsl:value-of select="HoTen"/>
							</td>
							<td>
								<xsl:value-of select="SoNgay"/>
							</td>
							<td>
								<xsl:choose>
									<xsl:when test="SoNgay &lt;= 10">
										<xsl:value-of select="SoNgay*100000"/>
									</xsl:when>
									<xsl:when test="SoNgay &lt;= 20 and SoNgay &gt; 10">
										<xsl:value-of select="10*100000 + (SoNgay*120000-10*120000)"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:value-of select="10*100000 + 10*120000 +(SoNgay*200000-20*200000)"/>
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

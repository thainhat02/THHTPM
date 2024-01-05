﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<body>
				<table border="1">
					<tr>
						<th>MaLop</th>
						<th>TenLop</th>
					</tr>
					<xsl:for-each select="DS/LopHoc">
						<tr>
							<td>
								<xsl:value-of select="MaLop"/>
							</td>
							<td>
								<xsl:value-of select="TenLop"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>

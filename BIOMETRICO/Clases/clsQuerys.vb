Public Class clsQuerys
    Dim Query As String = Nothing

#Region "Permisos de Menú"
    Public Function PermisosMenu(ByVal pCodigoUsuario As String) As String
        Query = "SELECT OPCION_MENU, S, Q, I, U, P, D
                 FROM USUARIOS_MENU_BIOMETRICO
                 WHERE CODIGO_DE_USUARIO ='" & pCodigoUsuario & "'"
        Return Query
    End Function
    Public Function PermisosBotonesMenu(ByVal pCodigoUsuario As String) As String
        Query = "SELECT OPCION_MENU, S, Q, I, U, P, D
                 FROM USUARIOS_MENU_BIOMETRICO
                 WHERE CODIGO_DE_USUARIO ='" & pCodigoUsuario & "'"
        Return Query
    End Function
#End Region


#Region "Llenar Grid Personal Marcajes"
    Public Function LlenarGridPersonalMarcaje() As String
        Query = "SELECT CODIGO_DE_PERSONAL, NOMBRE_DEL_PERSONAL, LUGAR_DE_TRABAJO, CODIGO_MARCAJE_RELOJ, PERSONAL_ACTIVO
                 FROM VBIO_PERFIL_PERSONAL
                 WHERE CODIGO_DE_PERSONAL > 0
				 AND CODIGO_DE_PERSONAL < 8888
                 AND CODIGO_MARCAJE_RELOJ > 0
                 ORDER BY PERSONAL_ACTIVO DESC, NOMBRE_DEL_PERSONAL"
        Return Query
    End Function

    Public Function LlenarGridBuscarPersonalMarcaje() As String
        Query = "SELECT CODIGO_DE_PERSONAL, NOMBRE_DEL_PERSONAL, LUGAR_DE_TRABAJO, CODIGO_MARCAJE_RELOJ, PERSONAL_ACTIVO
                 FROM VBIO_PERFIL_PERSONAL
                 WHERE CODIGO_DE_PERSONAL > 0
				 AND CODIGO_DE_PERSONAL < 8888
                 AND CODIGO_MARCAJE_RELOJ > 0
                 AND NOMBRE_DEL_PERSONAL LIKE '%' + @Buscar + '%'
                 ORDER BY PERSONAL_ACTIVO DESC, NOMBRE_DEL_PERSONAL"
        Return Query
    End Function
    Public Function LlenarGridMarcajesPersonal(ByVal pCodigoPersonal As Integer) As String
        Query = "SELECT CODIGO_DE_MARCAJE, FECHA_DE_MARCAJE, HORA_DE_MARCAJE, CODIGO_DE_RELOJ
                 FROM VBIO_MARCAJES_EMPLEADOS
                 WHERE CODIGO_DE_PERSONAL =" & pCodigoPersonal & "
                 ORDER BY FECHA_DE_MARCAJE DESC, HORA_DE_MARCAJE ASC"
        Return Query
    End Function
    Public Function LlenarGridTotalMarcajesPersonal(ByVal pFechaInicio As Date, ByVal pFechaFinal As Date) As String
        Dim ConFechaInicio As String = Format(pFechaInicio, "yyyy-MM-dd")
        Dim ConFechaFinal As String = Format(pFechaFinal, "yyyy-MM-dd")
        Query = "SELECT CODIGO_DE_MARCAJE, NOMBRE_DEL_PERSONAL, FECHA_DE_MARCAJE, 
                 MARCA1, MARCA2, MARCA3, MARCA4, MARCA5,
                 MARCA6, MARCA7, MARCA8, MARCA9, MARCA10
                 FROM VBIO_REPORTE_DE_MARCAJES_EMPLEADOS
                 WHERE FECHA_DE_MARCAJE >= '" & ConFechaInicio & "'
                 AND FECHA_DE_MARCAJE <= '" & ConFechaFinal & "'
                 ORDER BY NOMBRE_DEL_PERSONAL, FECHA_DE_MARCAJE DESC"
        Return Query
    End Function
    Public Function BuscarMarcajesPersonal(ByVal pCodigoPersonal As Integer, ByVal pFechaInicio As Date, ByVal pFechaFinal As Date) As String
        Dim ConFechaInicio As String = Format(pFechaInicio, "yyyy-MM-dd")
        Dim ConFechaFinal As String = Format(pFechaFinal, "yyyy-MM-dd")
        Query = "SELECT CODIGO_DE_MARCAJE, FECHA_DE_MARCAJE, HORA_DE_MARCAJE, CODIGO_DE_RELOJ
                 FROM VBIO_MARCAJES_EMPLEADOS
                 WHERE CODIGO_DE_PERSONAL =" & pCodigoPersonal & "
                 AND FECHA_DE_MARCAJE >= '" & ConFechaInicio & "'
                 AND FECHA_DE_MARCAJE <= '" & ConFechaFinal & "'
                 ORDER BY FECHA_DE_MARCAJE DESC, HORA_DE_MARCAJE ASC"
        Return Query
    End Function
#End Region

#Region "Modelos de Reloj"
    Public Function LlenarGridTipoReloj() As String
        Query = "SELECT CODIGO_DE_TIPO, DESCRIPCION_DEL_TIPO FROM MODELOS_DEL_BIOMETRICO"
        Return Query
    End Function

#End Region

#Region "Reportes"
#Region "Reporte de Marcajes del Personal"
    Public Function QueryReporteMarcajesPersonal(ByVal vFechaInicio As Date, ByVal vFechaFinal As Date) As String
        Dim conFechaInicio = Format(vFechaInicio, "yyyy-MM-dd")
        Dim conFechaFinal = Format(vFechaFinal, "yyyy-MM-dd")
        Query = "SELECT CODIGO_DE_MARCAJE, FECHA_DE_MARCAJE, 
                 MARCA1, MARCA2, MARCA3, MARCA4, MARCA5,
                 MARCA6, MARCA7, MARCA8, MARCA9, MARCA10,
                 CODIGO_DE_PERSONAL, NOMBRE_DEL_PERSONAL, 
                 CODIGO_UNIDAD_TRABAJO, PERSONAL_ACTIVO, LUGAR_DE_TRABAJO 
                 FROM VBIO_REPORTE_DE_MARCAJES_EMPLEADOS 
                 WHERE FECHA_DE_MARCAJE >='" & conFechaInicio & "'
                 AND FECHA_DE_MARCAJE <='" & conFechaFinal & "'
                 ORDER BY FECHA_DE_MARCAJE"
        Return Query
    End Function

#End Region
#Region "Reporte de Marcajes por Unidad de Trabajo"
    Public Function QueryReporteMarcajesPersonalUnidad(ByVal vCodigoUnidad As Integer, ByVal vFechaInicio As Date, ByVal vFechaFinal As Date) As String
        Dim conFechaInicio = Format(vFechaInicio, "yyyy-MM-dd")
        Dim conFechaFinal = Format(vFechaFinal, "yyyy-MM-dd")
        Query = "SELECT CODIGO_DE_MARCAJE, FECHA_DE_MARCAJE, 
                 MARCA1, MARCA2, MARCA3, MARCA4, MARCA5,
                 MARCA6, MARCA7, MARCA8, MARCA9, MARCA10,
                 CODIGO_DE_PERSONAL, NOMBRE_DEL_PERSONAL, 
                 CODIGO_UNIDAD_TRABAJO, PERSONAL_ACTIVO, LUGAR_DE_TRABAJO 
                 FROM VBIO_REPORTE_DE_MARCAJES_EMPLEADOS 
                 WHERE FECHA_DE_MARCAJE >='" & conFechaInicio & "'
                 AND FECHA_DE_MARCAJE <='" & conFechaFinal & "'
                 AND CODIGO_UNIDAD_TRABAJO = " & vCodigoUnidad & "
                 ORDER BY FECHA_DE_MARCAJE"
        Return Query
    End Function
#End Region
#End Region
End Class

Imports System.Data.SqlClient

Public Class clsReportes
    Inherits clsConexion
    Dim ds As New DataSet
    Dim Adapter As New SqlDataAdapter

    Dim _query As New clsQuerys

    Public Function ReporteMarcajesPersonal(ByVal vFechaInicio As Date, ByVal vFechaFinal As Date) As DataSet
        Try
            ds = New DataSet
            Adapter = New SqlDataAdapter(_query.QueryReporteMarcajesPersonal(vFechaInicio, vFechaFinal), Me.sqlConec)
            Adapter.Fill(ds, "VBIO_REPORTE_DE_MARCAJES_EMPLEADOS")
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function
    Public Function ReporteMarcajesPersonalUnidad(ByVal vCodigoUnidad As Integer, ByVal vFechaInicio As Date, ByVal vFechaFinal As Date) As DataSet
        Try
            ds = New DataSet
            Adapter = New SqlDataAdapter(_query.QueryReporteMarcajesPersonalUnidad(vCodigoUnidad, vFechaInicio, vFechaFinal), Me.sqlConec)
            Adapter.Fill(ds, "VBIO_REPORTE_DE_MARCAJES_EMPLEADOS")
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function
End Class
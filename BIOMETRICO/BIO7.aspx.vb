Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class BIO7
    Inherits System.Web.UI.Page

    Dim _reporte As New clsReportes
    Dim _query As New clsQuerys
    Dim _archivo As New clsConexion

    Dim vDatSet As DataSet
    Dim vReporte As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

            End If
        Catch ex As Exception
            If Err.Number = 91 Then 'Cuando la variable del inicio de sesión es NULL'
                Mensajes.MensajeExpiracion(Me.Page)
            Else
                Mensajes.MensajeError(Me.Page, ex.Message)
            End If
        End Try
    End Sub
    Private Function ValidarCampoFechas() As Boolean
        If Not IsDate(txtFechaInicio.Text) Then
            Mensajes.MensajeError(Me.Page, "Fecha de Inicio no válida")
        ElseIf Not IsDate(txtFechaFinal.Text) Then
            Mensajes.MensajeError(Me.Page, "Fecha Final no válida")
        Else
            If txtFechaInicio.Text > txtFechaFinal.Text Then
                Mensajes.MensajeError(Me.Page, "Fecha de Inicio no puede ser mayor a la Fecha Final")
            Else
                Return True
            End If
        End If
    End Function
    Protected Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If ValidarCampoFechas() = True Then
            Try
                Dim Directorio As Boolean

                'Directorio
                Directorio = Directory.Exists(_archivo.RutaArchivo + "Reportes de Marcajes")

                If Directorio = False Then
                    Directory.CreateDirectory(_archivo.RutaArchivo + "Reportes de Marcajes")
                End If

                Dim vFechaReporte As String = Format(Date.Now, "ddMMyyyy")
                vDatSet = _reporte.ReporteMarcajesPersonal(txtFechaInicio.Text, txtFechaFinal.Text)
                vReporte = New rptBIO01
                vReporte.SetDataSource(vDatSet)
                Call DatosParametro(txtFechaInicio.Text, txtFechaFinal.Text)
                vReporte.ExportToDisk(ExportFormatType.PortableDocFormat, _archivo.RutaArchivo + "Reportes de Marcajes\Reporte Total de Marcajes " + vFechaReporte + ".pdf")
                MensajeCorrecto(Me.Page, "Reporte Generado")
                Process.Start(_archivo.RutaArchivo + "Reportes de Marcajes\Reporte Total de Marcajes " + vFechaReporte + ".pdf")
            Catch ex As Exception
                If Err.Number = 91 Then 'Cuando la variable del inicio de sesión es NULL'
                    Mensajes.MensajeExpiracion(Me.Page)
                Else
                    Mensajes.MensajeError(Me.Page, ex.Message)
                End If
            End Try
        End If
    End Sub
    Private Sub DatosParametro(ByVal vFechaInicio As Date, ByVal vFechaFinal As Date)
        Dim conFechaInicio As String = Format(vFechaInicio, "dd/MM/yyyy")
        Dim conFechaFinal As String = Format(vFechaFinal, "dd/MM/yyyy")
        vReporte.SetParameterValue("NombreUsuario", Session.Item("uValor").ToString.ToUpper)
        vReporte.SetParameterValue("AreaTexto", conFechaInicio + " al " + conFechaFinal)
    End Sub


End Class
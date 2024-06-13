Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class BIO8
    Inherits System.Web.UI.Page
    Dim _reporte As New clsReportes
    Dim _query As New clsQuerys
    Dim _archivo As New clsConexion
    Dim _cargar As New clsCargarDatos
    Dim _select As New clsSelectUpdateTablas

    Dim vDatSet As DataSet
    Dim vReporte As New ReportDocument

    Public Shared vUnidadTrabajo As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call LlenarComboUnidadTrabajo()
            End If
        Catch ex As Exception
            If Err.Number = 91 Then 'Cuando la variable del inicio de sesión es NULL'
                Mensajes.MensajeExpiracion(Me.Page)
            Else
                Mensajes.MensajeError(Me.Page, ex.Message)
            End If
        End Try
    End Sub
    Private Sub LlenarComboUnidadTrabajo()
        With dplUnidad
            .DataSource = _cargar.LlenarGrid("SELECT CODIGO_UNIDAD_TRABAJO, LUGAR_DE_TRABAJO 
                                              FROM UNIDADES_DE_TRABAJO
                                              ORDER BY LUGAR_DE_TRABAJO")
            .DataTextField = "LUGAR_DE_TRABAJO"
            .DataValueField = "CODIGO_UNIDAD_TRABAJO"
            .DataBind()
        End With
    End Sub
    Private Function ValidarCampoFechas() As Boolean
        If dplUnidad.Text.Trim = "" Then
            Mensajes.MensajeError(Me.Page, "Tiene que seleccionar una Unidad de Trabajo")
        ElseIf Not IsDate(txtFechaInicio.Text) Then
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

                Call _select.SelectUnidadTrabajo(dplUnidad.SelectedValue)

                Dim vFechaReporte As String = Format(Date.Now, "ddMMyyyy")
                vDatSet = _reporte.ReporteMarcajesPersonalUnidad(dplUnidad.SelectedValue, txtFechaInicio.Text, txtFechaFinal.Text)
                vReporte = New rptBIO02
                vReporte.SetDataSource(vDatSet)
                Call DatosParametro(txtFechaInicio.Text, txtFechaFinal.Text)
                vReporte.ExportToDisk(ExportFormatType.PortableDocFormat, _archivo.RutaArchivo + "Reportes de Marcajes\Reporte de Marcajes Unidad " + vUnidadTrabajo + " " + vFechaReporte + ".pdf")
                MensajeCorrecto(Me.Page, "Reporte Generado")
                Process.Start(_archivo.RutaArchivo + "Reportes de Marcajes\Reporte de Marcajes Unidad " + vUnidadTrabajo + " " + vFechaReporte + ".pdf")
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
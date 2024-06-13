Public Class BIO3
    Inherits System.Web.UI.Page

    Dim _cargar As New clsCargarDatos
    Dim _query As New clsQuerys

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
    Private Sub LlenarGrid()
        Try
            With TablaDeDatos
                .DataSource = _cargar.LlenarGrid(_query.LlenarGridTotalMarcajesPersonal(txtFechaInicio.Text.Trim, txtFechaFinal.Text))
                .DataBind()
            End With
        Catch ex As Exception
            If Err.Number = 91 Then 'Cuando la variable del inicio de sesión es NULL'
                Mensajes.MensajeExpiracion(Me.Page)
            Else
                Mensajes.MensajeError(Me.Page, ex.Message)
            End If
        End Try
    End Sub
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If Not IsDate(txtFechaInicio.Text) Then
            Mensajes.MensajeError(Me.Page, "Fecha de Inicio no válida")
        ElseIf Not IsDate(txtFechaFinal.Text) Then
            Mensajes.MensajeError(Me.Page, "Fecha Final no válida")
        Else
            Call LlenarGrid()
        End If
    End Sub
End Class
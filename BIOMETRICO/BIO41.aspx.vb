Public Class BIO41
    Inherits System.Web.UI.Page

    Public Shared vDescripcion As String = ""

    Dim _select As New clsSelectUpdateTablas
    Dim _modifica As New clsUpdateTablas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtCodigo.Text = Session.Item("vCodigoTipo").ToString.Trim
            Call _select.SelectModeloReloj(txtCodigo.Text)
            txtDescripcion.Text = vDescripcion
        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If _modifica.ActualizarModeloReloj(txtCodigo.Text, txtDescripcion.Text) = True Then
            MensajeCorrecto(Me.Page, "Registro Grabado")
            Call LimpiarCajas()
            Response.Redirect("BIO41.aspx")
        End If
    End Sub
    Private Sub LimpiarCajas()
        txtCodigo.Text = Nothing
        txtDescripcion.Text = Nothing
    End Sub
End Class
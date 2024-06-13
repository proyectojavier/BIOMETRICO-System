Public Class BIO
    Inherits System.Web.UI.Page
    Public Shared CodigoUsuario As String
    Public Shared ContraseñaUsuario As String

    Dim _login As New clsLogin
    Dim _properties As New clsUser

    Public Shared vPrivilegios As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            vPrivilegios = 0
            CodigoUsuario = txtCodigoUsuario.Text
            ContraseñaUsuario = txtContraseñaUsuario.Text
            _properties.gUsuario = txtCodigoUsuario.Text.Trim
            _properties.gPassword = txtContraseñaUsuario.Text.Trim
            If _login.Login(_properties) = True Then
                Session("uValor") = txtCodigoUsuario.Text.Trim
                Session("pValor") = txtContraseñaUsuario.Text.Trim
                'Server.Transfer("BIO1.aspx", True)
                Response.Redirect("BIO1.aspx", False)
                'Session.RemoveAll()
            Else
                If vPrivilegios = 99 Then
                    Mensajes.MensajeAdvertencia(Me.Page, "No tiene privilegios asignados")
                End If
            End If
        Catch ex As Exception
            If vPrivilegios = 99 Then
                Mensajes.MensajeAdvertencia(Me.Page, "No tiene privilegios asignados")
            Else
                Mensajes.MensajeError(Me.Page, ex.Message)
            End If
        End Try
    End Sub
End Class

Imports System.Data.SqlClient

Public Class Plantilla
    Inherits System.Web.UI.MasterPage

    Public _con As New clsConexion
    Public _query As New clsQuerys

    Public DatTabla As New DataTable
    Public Adapter As New SqlDataAdapter

    Public PERMISO As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If IsNothing(Session.Item("uValor").ToString) Then
                    Mensajes.MensajeExpiracion(Me.Page)
                Else

                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT CODIGO_DE_USUARIO, LUGAR_DE_TRABAJO 
                                              FROM VADQ_USUARIOS_INVENTARIOS 
                                              WHERE CODIGO_DE_USUARIO = '" & Session.Item("uValor").ToString.Trim & "'", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblNombreUsuario.Text = drfila("CODIGO_DE_USUARIO").ToString.Trim
                        lblLugarTrabajo.Text = drfila("LUGAR_DE_TRABAJO").ToString.Trim
                    Next

                    Dim thisURL As String = Request.Url.Segments(Request.Url.Segments.Count - 1)
                    Select Case thisURL
                        Case "BIO2.aspx", "BIO21.aspx"
                            MenuPersonal.Attributes.Remove("class")
                            personal.Attributes.Remove("class")
                            MenuPersonal.Attributes.Add("class", "nav-item active submenu")
                            personal.Attributes.Add("class", "collapse show")
                            SubPersonal1.Attributes.Add("class", "active")
                        Case "BIO3.aspx"
                            MenuPersonal.Attributes.Remove("class")
                            personal.Attributes.Remove("class")
                            MenuPersonal.Attributes.Add("class", "nav-item active submenu")
                            personal.Attributes.Add("class", "collapse show")
                            SubPersonal2.Attributes.Add("class", "active")
                        Case "BIO4.aspx", "BIO41.aspx"
                            MenuDispositivo.Attributes.Remove("class")
                            dispositivo.Attributes.Remove("class")
                            MenuDispositivo.Attributes.Add("class", "nav-item active submenu")
                            dispositivo.Attributes.Add("class", "collapse show")
                            SubDispositivo1.Attributes.Add("class", "active")
                        Case "BIO5.aspx", "BIO51.aspx"
                            MenuDispositivo.Attributes.Remove("class")
                            dispositivo.Attributes.Remove("class")
                            MenuDispositivo.Attributes.Add("class", "nav-item active submenu")
                            dispositivo.Attributes.Add("class", "collapse show")
                            SubDispositivo2.Attributes.Add("class", "active")
                        Case "BIO6.aspx"
                            MenuCDatos.Attributes.Remove("class")
                            cdatos.Attributes.Remove("class")
                            MenuCDatos.Attributes.Add("class", "nav-item active submenu")
                            cdatos.Attributes.Add("class", "collapse show")
                            SubCDatos1.Attributes.Add("class", "active")
                        Case "BIO7.aspx"
                            MenuReportes.Attributes.Remove("class")
                            rreportes.Attributes.Remove("class")
                            MenuReportes.Attributes.Add("class", "nav-item active submenu")
                            rreportes.Attributes.Add("class", "collapse show")
                            SubRReportes1.Attributes.Add("class", "active")
                        Case "BIO8.aspx"
                            MenuReportes.Attributes.Remove("class")
                            rreportes.Attributes.Remove("class")
                            MenuReportes.Attributes.Add("class", "nav-item active submenu")
                            rreportes.Attributes.Add("class", "collapse show")
                            SubRReportes2.Attributes.Add("class", "active")
                        Case "BIO9.aspx"
                            MenuReportes.Attributes.Remove("class")
                            rreportes.Attributes.Remove("class")
                            MenuReportes.Attributes.Add("class", "nav-item active submenu")
                            rreportes.Attributes.Add("class", "collapse show")
                            SubRReportes3.Attributes.Add("class", "active")
                    End Select
                End If
            End If
        Catch ex As Exception
            If Err.Number = 91 Then 'Cuando la variable del inicio de sesión es NULL'
                Mensajes.MensajeExpiracion(Me.Page)
            Else
                Mensajes.MensajeError(Me.Page, ex.Message)
            End If
        End Try
    End Sub
    Sub HtmlAnchor_Click(sender As Object, e As EventArgs)
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1))
        Response.Cache.SetNoServerCaching()
        Response.Cache.SetNoStore()

        Response.ClearHeaders()
        Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate")
        Response.AddHeader("Pragma", "no-cache")
        Response.Cookies.Clear()
        Response.Expires = -1500
        Response.CacheControl = "no-cache"
        Call LogOut()
    End Sub
    Protected Sub LogOut()
        BIO.CodigoUsuario = ""
        BIO.ContraseñaUsuario = ""
        Session.Abandon()
        Session.Clear()
        Session.RemoveAll()
        FormsAuthentication.SignOut()
        HttpContext.Current.Session.Abandon()
        Mensajes.MensajeCierreSesion(Me.Page)
    End Sub
End Class
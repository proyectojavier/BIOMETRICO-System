Public Class BIO5
    Inherits System.Web.UI.Page

    Dim _con As New clsConexion
    Dim _cargar As New clsCargarDatos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call LlenarGrid()
                Call LlenarComboTipoRelojes()
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
        With TablaDeDatos
            .DataSource = _cargar.LlenarGrid("SELECT CODIGO_DE_RELOJ, DESCRIPCION_DEL_RELOJ, IP_DEL_RELOJ,
                                              RELOJ_EN_USO FROM BIOMETRICOS_DE_MARCAJE")
            .DataBind()
        End With
    End Sub
    Private Sub LlenarComboTipoRelojes()
        With dplRelojes
            .DataSource = _cargar.LlenarGrid("SELECT CODIGO_DE_TIPO, DESCRIPCION_DEL_TIPO 
                                              FROM MODELOS_DEL_BIOMETRICO")
            .DataTextField = "DESCRIPCION_DEL_TIPO"
            .DataValueField = "CODIGO_DE_TIPO"
            .DataBind()
        End With

    End Sub
    Protected Sub OnConsult(sender As Object, e As ImageClickEventArgs)
        Dim button As ImageButton = CType(sender, ImageButton)
        'Get the command argument
        Dim Codigo As Integer = button.CommandArgument
        'SAC021.ParOperacion = SAC021.Operacion.Consultar
        Session("uValor") = Codigo
        Response.Redirect("SAC021.aspx")
    End Sub
    Protected Sub OnUpdate(sender As Object, e As ImageClickEventArgs)
        Dim button As ImageButton = CType(sender, ImageButton)
        'Get the command argument
        Dim Codigo As Integer = button.CommandArgument
        'SAC021.ParOperacion = SAC021.Operacion.Modificar
        Session("uValor") = Codigo
        Response.Redirect("SAC021.aspx")
    End Sub

End Class
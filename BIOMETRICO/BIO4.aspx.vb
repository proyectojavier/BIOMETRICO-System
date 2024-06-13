Public Class BIO4
    Inherits System.Web.UI.Page
    Dim _con As New clsConexion
    Dim _cargar As New clsCargarDatos
    Dim _insert As New clsInsertTablas
    Dim _query As New clsQuerys

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call LlenarGrid()
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
            .DataSource = _cargar.LlenarGrid(_query.LlenarGridTipoReloj)
            .DataBind()
        End With
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If _insert.InsertaModeloReloj(txtDescripcion.Text) = True Then
            MensajeCorrecto(Me.Page, "Registro Grabado")
            txtDescripcion.Text = Nothing
            Call LlenarGrid()
        End If
    End Sub
    Protected Sub OnUpdate(sender As Object, e As ImageClickEventArgs)
        Dim button As ImageButton = CType(sender, ImageButton)
        Dim Codigo As Integer = button.CommandArgument
        Session("vCodigoTipo") = Codigo
        Response.Redirect("BIO41.aspx")
    End Sub
End Class
Public Class BIO2
    Inherits System.Web.UI.Page

    Dim _cargar As New clsCargarDatos
    Dim _query As New clsQuerys

    Dim Arreglo() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If IsNothing(Session.Item("uValor").ToString) Then
                    Mensajes.MensajeExpiracion(Me.Page)
                Else
                    Call LlenarGrid()
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
    Private Sub LlenarGrid()
        With TablaDeDatos
            .DataSource = _cargar.LlenarGrid(_query.LlenarGridPersonalMarcaje)
            .DataBind()
        End With
    End Sub
    Protected Sub TablaDeDatos_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            Dim lCodigo As Label = CType(e.Item.FindControl("lblCodigo"), Label)
            Dim lNombreUnidad As Label = CType(e.Item.FindControl("lblNombrUnidad"), Label)
            Dim lLugarTrabajo As Label = CType(e.Item.FindControl("lblLugarTrabajo"), Label)
            Dim lCodigoMarcaje As Label = CType(e.Item.FindControl("lblCodigoMarcaje"), Label)
            Dim lActivo As Label = CType(e.Item.FindControl("lblActivo"), Label)
            Dim drv As DataRowView = TryCast(e.Item.DataItem, DataRowView)
            Dim Activo As String = Convert.ToString(drv("PERSONAL_ACTIVO"))

            If Activo = "NO" Then
                lCodigo.Attributes.Add("style", "color:#FE2E2E;")
                lNombreUnidad.Attributes.Add("style", "color:#FE2E2E;")
                lLugarTrabajo.Attributes.Add("style", "color:#FE2E2E;")
                lCodigoMarcaje.Attributes.Add("style", "color:#FE2E2E;")
                lActivo.Attributes.Add("style", "color:#FE2E2E;")
            End If
        End If
    End Sub
    Protected Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        With TablaDeDatos
            .DataSource = _cargar.BuscarDatos(_query.LlenarGridBuscarPersonalMarcaje, txtNombre.Text.Trim)
            .DataBind()
        End With
    End Sub
    Protected Sub OnConsult(sender As Object, e As ImageClickEventArgs)
        Dim button As ImageButton = CType(sender, ImageButton)
        Arreglo = button.CommandArgument.Split(";")
        Session("vCodigoPersonal") = Arreglo(0)
        Session("vNombrePersonal") = Arreglo(1)
        Response.Redirect("BIO21.aspx")
    End Sub

End Class
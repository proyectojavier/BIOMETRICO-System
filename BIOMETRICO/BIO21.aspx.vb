Public Class BIO21
    Inherits System.Web.UI.Page

    Dim _cargar As New clsCargarDatos
    Dim _query As New clsQuerys
    Dim _delete As New clsDeleteTablas

    Dim Arreglo() As String

    Dim vCodigoMarcaje As Integer
    Dim vFechaMarcaje As Date
    Dim vHoraMarcaje As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                lblCodigoPersonal.Text = Session.Item("vCodigoPersonal").ToString.Trim
                lblNombrePersonal.Text = Session.Item("vNombrePersonal").ToString.Trim
            End If
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
            Call BuscarFechasMarcajes()
        End If
    End Sub
    Private Sub BuscarFechasMarcajes()
        With TablaDeDatos
            .DataSource = _cargar.LlenarGrid(_query.BuscarMarcajesPersonal(lblCodigoPersonal.Text.Trim, txtFechaInicio.Text, txtFechaFinal.Text))
            .DataBind()
        End With
    End Sub
    Protected Sub OnDelete(sender As Object, e As ImageClickEventArgs)
        Dim button As ImageButton = CType(sender, ImageButton)
        Arreglo = button.CommandArgument.Split(";")
        vCodigoMarcaje = Arreglo(0)
        vFechaMarcaje = Arreglo(1)
        vHoraMarcaje = Arreglo(2)
        Try
            If _delete.EliminarMarcajeEmpleado(vCodigoMarcaje, vFechaMarcaje, vHoraMarcaje) = True Then
                Mensajes.MensajeCorrecto(Me.Page, "Registro Eliminado")
                Call BuscarFechasMarcajes()
            End If
        Catch ex As Exception
            Mensajes.MensajeError(Me.Page, ex.Message)
        End Try
    End Sub

End Class
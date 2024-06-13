Imports ZKSoftwareAPI

Public Class BIO6
    Inherits System.Web.UI.Page

    Dim _con As New clsConexion
    Dim _cargar As New clsCargarDatos
    Dim _select As New clsSelectUpdateTablas
    Dim _insert As New clsInsertTablas

    Dim ds As DataSet
    Dim datTabla As New DataTable

    Dim vCodigoReloj As String = ""

    Public Shared vIPReloj As String = ""
    Public Shared vFechaInicio As Date
    Public Shared vFechaFinal As Date

    Dim vMarcaCodigo As String = ""
    Dim vMarcaFecha As String = ""
    Dim vMarcaHora As String = ""

    Dim vCodigoMarcaje As Label
    Dim vFechaMarcaje As Label
    Dim vHoraMarcaje As Label

    Dim FormatoFechaMarcaje As String

    Dim pCodigoMarcajeBD As Label
    Dim pFechaMarcajeBD As Label
    Dim pHoraMarcajeBD As Label

    Dim ContarMarca As Integer = 0
    Dim ContarMarcaBD As Integer = 0

    Dim ControlRegistro As Integer = 0

    Dim dispositivo As ZKSoftware = New ZKSoftware(Modelo.X628C)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call LlenarComboRelojes()
            End If
        Catch ex As Exception
            If Err.Number = 91 Then 'Cuando la variable del inicio de sesión es NULL'
                Mensajes.MensajeExpiracion(Me.Page)
            Else
                Mensajes.MensajeError(Me.Page, ex.Message)
            End If
        End Try
    End Sub
    Private Sub LlenarGrid(ByVal FechaInicio As Date, ByVal FecchaFinal As Date)
        Dim ConFechaInicio As String = Format(FechaInicio, "yyyy/MM/dd")
        Dim ConFechaFinal As String = Format(FecchaFinal, "yyyy/MM/dd")
        With TablaMarcajesBD
            .DataSource = _cargar.LlenarGrid("SELECT CODIGO_DE_MARCAJE, FECHA_DE_MARCAJE, HORA_DE_MARCAJE
                                              FROM DESCARGA_DE_MARCAJES
                                              WHERE FECHA_DE_MARCAJE >='" & ConFechaInicio & "'
                                              AND FECHA_DE_MARCAJE <='" & ConFechaFinal & "'
                                              AND CODIGO_DE_RELOJ =" & vCodigoReloj & "")
            .DataBind()
        End With
        For Each row As RepeaterItem In TablaMarcajesBD.Items
            ContarMarcaBD += 1
        Next
        lblTotalMarcajesBD.Text = ContarMarcaBD
    End Sub
    Private Sub LlenarComboRelojes()
        With dplRelojes
            .DataSource = _cargar.LlenarGrid("SELECT CODIGO_DE_RELOJ, DESCRIPCION_DEL_RELOJ, IP_DEL_RELOJ 
                                              FROM BIOMETRICOS_DE_MARCAJE
                                              WHERE RELOJ_EN_USO = 'SI'")
            .DataTextField = "DESCRIPCION_DEL_RELOJ"
            .DataValueField = "CODIGO_DE_RELOJ"
            .DataBind()
        End With

    End Sub
    'Private Sub llenarGridMarcajes()
    '    With Repeater1
    '        .DataSource = _cargar.LlenarGrid("SELECT CODIGO_DE_MARCAJE, FECHA_DE_MARCAJE, HORA_DE_MARCAJE 
    '                                          FROM BIOMETRICOS_DE_MARCAJE")
    '        .DataBind()
    '    End With
    'End Sub
    Protected Sub btnConectar_Click(sender As Object, e As EventArgs) Handles btnConectar.Click
        Call Conectar()
    End Sub
    Private Sub Conectar()
        Try
            Call _select.SelectRelojCombo(dplRelojes.SelectedValue)
            If My.Computer.Network.Ping(vIPReloj) Then
                dispositivo = New ZKSoftware(Modelo.X628C)
                If Not dispositivo.DispositivoConectar(vIPReloj, 0, True) = True Then
                    Mensajes.MensajeCorrecto(Me.Page, "Conexión Correcta")
                    dplRelojes.Enabled = False
                    btnConectar.Enabled = False
                    btnDesconectar.Enabled = True
                    btnConsultarMarcaje.Enabled = True
                End If
            Else
                Mensajes.MensajeError(Me.Page, "Ping request timed out.")
            End If
        Catch ex As Exception
            Mensajes.MensajeError(Me.Page, ex.Message)
        End Try
    End Sub

    Protected Sub btnDesconectar_Click(sender As Object, e As EventArgs) Handles btnDesconectar.Click
        If btnConectar.Enabled = True Then
            MsgBox("Aún nose ha conectado a ningún RELOJ", MsgBoxStyle.Critical)
        Else
            dispositivo.DispositivoDesconectar()
            btnConectar.Enabled = True
            btnDesconectar.Enabled = False
            btnConsultarMarcaje.Enabled = False
            btnTransferirMarcaje.Enabled = False

            dplRelojes.Enabled = True

            'Limpiar tabla de Marcajes del Biométrico'
            TablaMarcajesBiometrico.DataSource = Nothing
            TablaMarcajesBiometrico.DataBind()
            lblTotalMarcajes.Text = ""

            'Limpiar tabla de Marcajes de la BD'
            TablaMarcajesBD.DataSource = Nothing
            TablaMarcajesBD.DataBind()
            lblTotalMarcajesBD.Text = ""
        End If
    End Sub
    Protected Sub btnConsultarMarcaje_Click(sender As Object, e As EventArgs) Handles btnConsultarMarcaje.Click
        'Call llenarGridMarcajes()
        Call ConsultarMarcajes()
    End Sub
    Private Sub ConsultarMarcajes()
        Try
            dispositivo.DispositivoConectar(vIPReloj, 0, True)
            dispositivo.DispositivoObtenerRegistrosAsistencias()
            If IsNothing(dispositivo.ListaMarcajes) Then
                Mensajes.MensajeAdvertencia(Me.Page, "No existen registros de MARCAJES")
            Else
                datTabla = New DataTable

                datTabla.Columns.Add("CODIGO_MARCAJE", GetType(String))
                datTabla.Columns.Add("FECHA_MARCAJE", GetType(String))
                datTabla.Columns.Add("HORA_MARCAJE", GetType(String))

                For Each vDatos In dispositivo.ListaMarcajes '// loop del arreglo de los registros del archivo
                    'Lee los archivos y los agrega a la GRID
                    vMarcaCodigo = vDatos.NumeroCredencial

                    vMarcaFecha = vDatos.Dia & "/" & vDatos.Mes & "/" & vDatos.Anio
                    vMarcaHora = vDatos.Hora & ":" & vDatos.Minuto & ":" & vDatos.Segundo

                    FormatoFechaMarcaje = FormatDateTime(vMarcaFecha, DateFormat.ShortDate)

                    datTabla.Rows.Add(vMarcaCodigo, FormatoFechaMarcaje, vMarcaHora)

                    ContarMarca += 1
                Next


                'For rows As Integer = 0 To Repeater1.Items.Count - 1
                '    vCodigoMarcaje = DirectCast(Repeater1.Items(rows).FindControl("lblCodigoMarcaje"), Label)
                '    vFechaMarcaje = DirectCast(Repeater1.Items(rows).FindControl("lblFechaMarcaje"), Label)
                '    vHoraMarcaje = DirectCast(Repeater1.Items(rows).FindControl("lblHoraMarcaje"), Label)

                '    FormatoFechaMarcaje = FormatDateTime(vFechaMarcaje.Text, DateFormat.ShortDate)
                '    FormatoHoraMarcaje = FormatDateTime(vHoraMarcaje.Text, DateFormat.LongTime)

                '    datTabla.Rows.Add(vCodigoMarcaje.Text, FormatoFechaMarcaje, FormatoHoraMarcaje)

                'Next

                TablaMarcajesBiometrico.DataSource = datTabla
                TablaMarcajesBiometrico.DataBind()

                lblTotalMarcajes.Text = ContarMarca
                btnTransferirMarcaje.Enabled = True
            End If
        Catch ex As Exception
            Mensajes.MensajeError(Me.Page, ex.Message)
        End Try
    End Sub
    Protected Sub btnTransferirMarcaje_Click(sender As Object, e As EventArgs) Handles btnTransferirMarcaje.Click
        Try
            If TablaMarcajesBiometrico.Items.Count > 0 Then
                If LecturaCamposGrid() = True Then
                    'If dispositivo.DispositivoBorrarRegistrosAsistencias = True Then
                    Call _select.BusquedaMarcajesReloj(vCodigoReloj, BIO.CodigoUsuario, Date.Now)
                    Mensajes.MensajeCorrecto(Me.Page, "Exportación de Marcajes Generada")
                    Call LlenarGrid(vFechaInicio, vFechaFinal)
                    btnConsultarMarcaje.Enabled = False
                    btnTransferirMarcaje.Enabled = False
                    'End If
                End If
            Else
                Mensajes.MensajeError(Me.Page, "No hay registros de MARCAJES")
            End If
        Catch ex As Exception
            Mensajes.MensajeError(Me.Page, ex.Message)
        End Try
    End Sub
    Private Function LecturaCamposGrid() As Boolean
        Try
            vCodigoReloj = dplRelojes.SelectedValue
            For i As Integer = 0 To TablaMarcajesBiometrico.Items.Count - 1
                'Lee los archivos y los agrega a la GRID
                pCodigoMarcajeBD = DirectCast(TablaMarcajesBiometrico.Items(i).FindControl("lblCodigoMarcaje"), Label)
                pFechaMarcajeBD = DirectCast(TablaMarcajesBiometrico.Items(i).FindControl("lblFechaMarcaje"), Label)
                pHoraMarcajeBD = DirectCast(TablaMarcajesBiometrico.Items(i).FindControl("lblHoraMarcaje"), Label)
                If _insert.InsertaMarcaje(vCodigoReloj, pCodigoMarcajeBD.Text, pFechaMarcajeBD.Text, pHoraMarcajeBD.Text) = True Then
                    ControlRegistro = 1
                Else
                    ControlRegistro = 0
                End If
            Next
            If ControlRegistro = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Mensajes.MensajeError(Me.Page, ex.Message)
        End Try
    End Function

End Class
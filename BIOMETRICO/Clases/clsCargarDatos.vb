Imports System.Data.SqlClient
Public Class clsCargarDatos
    Inherits clsConexion

    Dim DatTable As New DataTable
    Dim Adapter As New SqlDataAdapter
    Dim Comando As New SqlCommand
#Region "Función que se utiliza en los querys del BOTÓN DE BÚSQUEDA"
    Public Function BuscarDatos(ByVal query As String, ByVal Buscar As String) As DataTable
        Try
            DatTable = New DataTable
            Comando = New SqlCommand(query, Me.sqlConec)
            Comando.Parameters.AddWithValue("@Buscar", Buscar)
            Adapter = New SqlDataAdapter(Comando)
            Adapter.Fill(DatTable)
            Me.conectar()
            BuscarDatos = DatTable
            Me.desconectar()
        Catch ex As Exception
            Me.desconectar()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function
#End Region
#Region "Función que llena la GRID DE DATOS de las diferentes tablas"
    Public Function LlenarGrid(ByVal query As String) As DataTable
        Try

            DatTable = New DataTable
            Adapter = New SqlDataAdapter(query, Me.sqlConec)
            Adapter.Fill(DatTable)
            sqlConec.Open()
            LlenarGrid = DatTable
            sqlConec.Close()
        Catch ex As Exception
            sqlConec.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function
#End Region

End Class

Imports System.Data.SqlClient
Public Class clsUpdateTablas
    Inherits clsConexion

    Dim Comando As New SqlCommand
#Region "Modelos de Reloj"
    Public Function ActualizarModeloReloj(ByVal vCodigoTipo As Integer, ByVal vModeloReloj As String) As Boolean
        Try
            Comando = New SqlCommand("dbo.BIOActualizaTipoReloj", sqlConec)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@CodigoTipo", SqlDbType.VarChar, 50).Value = vCodigoTipo
            Comando.Parameters.Add("@DescripcionTipo", SqlDbType.VarChar, 50).Value = vModeloReloj
            Comando.Parameters.Add("@RetornoError", SqlDbType.Int)
            Comando.Parameters.Add("@MensajeError", SqlDbType.VarChar, 70)
            Comando.Parameters.Add("@SQLError", SqlDbType.VarChar, 70)
            Comando.Parameters("@RetornoError").Direction = ParameterDirection.Output
            Comando.Parameters("@MensajeError").Direction = ParameterDirection.Output
            Comando.Parameters("@SQLError").Direction = ParameterDirection.Output
            Call conectar()
            Comando.ExecuteNonQuery()
            Call desconectar()
            If Comando.Parameters("@RetornoError").Value = 0 Then
                Return True
            Else
                MsgBox(Comando.Parameters("@MensajeError").Value.ToString.Trim, MsgBoxStyle.Critical)
                Return False
            End If
        Catch ex As Exception
            Call desconectar()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function
#End Region
End Class

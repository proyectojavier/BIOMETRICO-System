Imports System.Data.SqlClient

Public Class clsDeleteTablas
    Inherits clsConexion

    Dim Comando As New SqlCommand

#Region "Exportación de Marcajes"
    Public Function EliminarMarcajeEmpleado(ByVal pCodigoMarcaje As Integer, ByVal pFechaMarcaje As Date, ByVal pHoraMarcaje As String) As Boolean
        Try
            Comando = New SqlCommand("dbo.BIOEliminarMarcaje", sqlConec)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@CodigoMarcaje", SqlDbType.Int, 8).Value = pCodigoMarcaje
            Comando.Parameters.Add("@FechaMarcaje", SqlDbType.Date).Value = pFechaMarcaje
            Comando.Parameters.Add("@HoraMarcaje", SqlDbType.VarChar).Value = pHoraMarcaje
            Comando.Parameters.Add("@CodigoDeUsuario", SqlDbType.Char, 10).Value = BIO.CodigoUsuario
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
            Throw ex
            Return False
        End Try
    End Function
#End Region
End Class

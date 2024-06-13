Imports System.Data.SqlClient
Public Class clsInsertTablas
    Inherits clsConexion

    Dim Comando As New SqlCommand

#Region "Relojes de Marcaje"
    Public Function InsertaReloj(ByVal vDescripcionReloj As String, ByVal vIPReloj As String, ByVal vTipoReloj As Integer,
                                 ByVal vEnUso As String) As Boolean
        Try
            Comando = New SqlCommand("dbo.RELOJCreaRelojes", sqlConec)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@DescripcionReloj", SqlDbType.VarChar, 50).Value = vDescripcionReloj
            Comando.Parameters.Add("@IPreloj", SqlDbType.VarChar, 15).Value = vIPReloj
            Comando.Parameters.Add("@CodigoDeTipo", SqlDbType.Int, 4).Value = vTipoReloj
            Comando.Parameters.Add("@Uso", SqlDbType.Char, 2).Value = vEnUso
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
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function
#End Region
#Region "Modelos de Reloj"
    Public Function InsertaModeloReloj(ByVal vModeloReloj As String) As Boolean
        Try
            Comando = New SqlCommand("dbo.BIOCreaTipoReloj", sqlConec)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@DescripcionTipo", SqlDbType.VarChar, 50).Value = vModeloReloj
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
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function
#End Region
#Region "Exportación de Marcajes"
    Public Function InsertaMarcaje(ByVal pCodigoReloj As Integer, ByVal pCodigoMarcaje As String, ByVal pFechaMarcaje As Date, ByVal pHoraMarcaje As String) As Boolean
        Try
            Comando = New SqlCommand("dbo.BIODescargaMarcajes", sqlConec)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@CodigoRelog", SqlDbType.Int).Value = pCodigoReloj
            Comando.Parameters.Add("@CodigoMarcaje", SqlDbType.VarChar, 15).Value = pCodigoMarcaje
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
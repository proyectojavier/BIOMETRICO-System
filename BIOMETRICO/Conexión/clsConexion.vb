Imports System.Data.SqlClient
Public Class clsConexion
    Public sqlConec As New SqlConnection("Data Source=DESKTOP-6CB4N01;Initial Catalog=COPEREXDB;
                                            Persist Security Info=True;User ID=" & BIO.CodigoUsuario & ";
                                            Password=" & BIO.ContraseñaUsuario & "")

    Public Sub conectar()
        Try
            sqlConec.Open()
        Catch ex As Exception
            sqlConec.Close()
            Throw ex
        End Try
    End Sub
    Public Sub desconectar()
        Try
            If sqlConec.State = ConnectionState.Open Then
                sqlConec.Close()
            End If
        Catch ex As Exception
            sqlConec.Close()
            Throw ex
        End Try
    End Sub
End Class
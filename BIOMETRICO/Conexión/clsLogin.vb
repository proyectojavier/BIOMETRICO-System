Imports System.Data.SqlClient
Public Class clsLogin
    Public sqlCadena As New SqlConnection
    Dim comando As New SqlCommand

    Public Function Login(ByVal pro As clsUser) As Boolean
        Try
            sqlCadena.ConnectionString = "Data Source=DESKTOP-6CB4N01;
            Initial Catalog=COPEREXDB;Persist Security Info=False;
            Integrated Security=False;User ID=" & pro.gUsuario & ";
            Password = " & pro.gPassword & ""



            sqlCadena.Open()

            comando = New SqlCommand(consulta, sqlCadena) 'Manda llamar el query y la coneccion al darle enter lo ejecuta
            comando.Parameters.AddWithValue("@USER", pro.gUsuario) 'llama la palabra user para evaluar si es correcto
            comando.ExecuteScalar()  'ejecuta el comando solo devuelve un valor
            BIO.vPrivilegios = Convert.ToInt32(comando.ExecuteScalar)
            sqlCadena.Close()
            If BIO.vPrivilegios = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            sqlCadena.Close()
            Throw ex
            Return False
        End Try
    End Function
End Class
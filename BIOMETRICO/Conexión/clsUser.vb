Public Class clsUser
    Dim _usuario As String
    Dim _contraseña As String
    Sub New()

    End Sub

    Public Property gUsuario
        Get
            Return _usuario
        End Get
        Set(value)
            _usuario = value
        End Set
    End Property
    Public Property gPassword
        Get
            Return _contraseña
        End Get
        Set(value)
            _contraseña = value
        End Set
    End Property
    Public Sub New(ByVal User As String, ByVal Pass As String)
        gUsuario = User
        gPassword = Pass
    End Sub
End Class

Public Class Entidad_Empleado
    Private _idempleado As Integer
    Public Property idempleado() As Integer
        Get
            Return _idempleado
        End Get
        Set(ByVal value As Integer)
            _idempleado = value
        End Set
    End Property

    Private _nombres As String
    Public Property nombres() As String
        Get
            Return _nombres
        End Get
        Set(ByVal value As String)
            _nombres = value
        End Set
    End Property


    Private _apellidos As String
    Public Property apellidos() As String
        Get
            Return _apellidos
        End Get
        Set(ByVal value As String)
            _apellidos = value
        End Set
    End Property


    Private _contraseña As String
    Public Property contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property
    Private _id_rol As Integer
    Public Property id_rol() As Integer
        Get
            Return _id_rol
        End Get
        Set(ByVal value As Integer)
            _id_rol = value
        End Set
    End Property


    Private _usuario As String
    Public Property usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property


End Class

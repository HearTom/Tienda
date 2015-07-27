Public Class Entidad_Reporte
    Private _Servidor As String
    Public Property Servidor() As String
        Get
            Return _Servidor
        End Get
        Set(ByVal value As String)
            _Servidor = value
        End Set
    End Property
    Private _BaseDatos As String
    Public Property BaseDatos() As String
        Get
            Return _BaseDatos
        End Get
        Set(ByVal value As String)
            _BaseDatos = value
        End Set
    End Property


    Private _usuario As String = "sa"
    Public Property usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property


    Private _Contraseña As String = "123"
    Public Property Contraseña() As String
        Get
            Return _Contraseña
        End Get
        Set(ByVal value As String)
            _Contraseña = value
        End Set
    End Property
End Class

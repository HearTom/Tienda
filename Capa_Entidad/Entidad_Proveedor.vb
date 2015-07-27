Public Class Entidad_Proveedor
    Private _idproveedor As Integer
    Public Property idproveedor() As Integer
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As Integer)
            _idproveedor = value
        End Set
    End Property


    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _Ruc As String
    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property

    Private _representante As String
    Public Property representante() As String
        Get
            Return _representante
        End Get
        Set(ByVal value As String)
            _representante = value
        End Set
    End Property

    Private _direccion As String
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _telefono As String
    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
End Class

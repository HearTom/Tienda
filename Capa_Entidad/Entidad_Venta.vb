Public Class Entidad_Venta
    Private _idventa As Integer
    Public Property idventa() As Integer
        Get
            Return _idventa
        End Get
        Set(ByVal value As Integer)
            _idventa = value
        End Set
    End Property
    Private _idcliente As Integer
    Public Property idcliente() As Integer
        Get
            Return _idcliente
        End Get
        Set(ByVal value As Integer)
            _idcliente = value
        End Set
    End Property

    Private _idempleado As Integer
    Public Property idempleado() As Integer
        Get
            Return _idempleado
        End Get
        Set(ByVal value As Integer)
            _idempleado = value
        End Set
    End Property

    Private _fecha As String
    Public Property fecha() As String
        Get
            Return _fecha
        End Get
        Set(ByVal value As String)
            _fecha = value
        End Set
    End Property


    Private _idtipoventa As Integer
    Public Property idtipoventa() As Integer
        Get
            Return _idtipoventa
        End Get
        Set(ByVal value As Integer)
            _idtipoventa = value
        End Set
    End Property

  




End Class

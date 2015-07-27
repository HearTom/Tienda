Public Class Entidad_ventadetalle
    Private _idventa As Integer
    Public Property idventa() As Integer
        Get
            Return _idventa
        End Get
        Set(ByVal value As Integer)
            _idventa = value
        End Set
    End Property

    Private _idproducto As Integer
    Public Property idproducto() As Integer
        Get
            Return _idproducto
        End Get
        Set(ByVal value As Integer)
            _idproducto = value
        End Set
    End Property

    Private _precio As Double
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _cancelado As Integer
    Public Property cancelado() As Integer
        Get
            Return _cancelado
        End Get
        Set(ByVal value As Integer)
            _cancelado = value
        End Set
    End Property

    Private _importe As Double
    Public Property importe() As Double
        Get
            Return _importe
        End Get
        Set(ByVal value As Double)
            _importe = value
        End Set
    End Property

    Private _montopagado As Double
    Public Property montopagado() As Double
        Get
            Return _montopagado
        End Get
        Set(ByVal value As Double)
            _montopagado = value
        End Set
    End Property




End Class

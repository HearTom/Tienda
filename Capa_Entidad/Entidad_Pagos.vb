Public Class Entidad_Pagos
    Private _idpagos As Integer
    Public Property idpagos() As Integer
        Get
            Return _idpagos
        End Get
        Set(ByVal value As Integer)
            _idpagos = value
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

    Private _monto As Double
    Public Property monto() As Double
        Get
            Return _monto
        End Get
        Set(ByVal value As Double)
            _monto = value
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





End Class

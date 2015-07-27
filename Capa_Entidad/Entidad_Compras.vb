Public Class Entidad_Compras
    Private _idcompra As Integer
    Public Property idcompra() As String
        Get
            Return _idcompra
        End Get
        Set(ByVal value As String)
            _idcompra = value
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

    Private _idtipocomprobante As Integer
    Public Property idtipocomprobante() As Integer
        Get
            Return _idtipocomprobante
        End Get
        Set(ByVal value As Integer)
            _idtipocomprobante = value
        End Set
    End Property

    Private _idfactura As String
    Public Property idfactura() As String
        Get
            Return _idfactura
        End Get
        Set(ByVal value As String)
            _idfactura = value
        End Set
    End Property

    Private _idproveedor As Integer
    Public Property idproveedor() As Integer
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As Integer)
            _idproveedor = value
        End Set
    End Property

    Private _importetotal As Double
    Public Property importetotal() As Double
        Get
            Return _importetotal
        End Get
        Set(ByVal value As Double)
            _importetotal = value
        End Set
    End Property

    Private _retencion As Double
    Public Property retencion() As Double
        Get
            Return _retencion
        End Get
        Set(ByVal value As Double)
            _retencion = value
        End Set
    End Property


End Class

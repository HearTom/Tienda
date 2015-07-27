Public Class Entidad_Producto
    Private _idproducto As Integer
    Public Property idproducto() As Integer
        Get
            Return _idproducto
        End Get
        Set(ByVal value As Integer)
            _idproducto = value
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

    Private _idcategoria As Integer
    Public Property idcategoria() As Integer
        Get
            Return _idcategoria
        End Get
        Set(ByVal value As Integer)
            _idcategoria = value
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


    Private _stock As Integer
    Public Property stock() As Integer
        Get
            Return _stock
        End Get
        Set(ByVal value As Integer)
            _stock = value
        End Set
    End Property

    Private _foto As String
    Public Property foto() As String
        Get
            Return _foto
        End Get
        Set(ByVal value As String)
            _foto = value
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

End Class

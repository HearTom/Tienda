Public Class Entidad_Tipo_venta
    Private _idtipo_venta As Integer
    Public Property idtipoventa() As Integer
        Get
            Return _idtipo_venta
        End Get
        Set(ByVal value As Integer)
            _idtipo_venta = value
        End Set
    End Property
    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property



End Class

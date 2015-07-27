Public Class Entidad_Categoria
    Private _idcategoria As Integer
    Public Property idcategoria() As Integer
        Get
            Return _idcategoria
        End Get
        Set(ByVal value As Integer)
            _idcategoria = value
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

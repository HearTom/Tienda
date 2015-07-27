Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Categoria
    Public Function Mostrarcategoria() As List(Of Entidad_Categoria)
        Dim lista As New List(Of Entidad_Categoria)
        Dim obj As New Dato_Categoria
        lista = obj.Mostrarcategoria
        Return lista
    End Function

    'Para Agregar una Nueva Categoria'
    Public Sub Nueva_categoria(ByVal registros As Entidad_Categoria)
        Dim Datos As New Dato_Categoria
        Datos.Nueva_Categoria(registros)
    End Sub

    'Para modificar una categoria

    Public Sub Modificar_categoria(ByVal registros As Entidad_Categoria)
        Dim Datos As New Dato_Categoria
        Datos.Modificar_Categoria(registros)
    End Sub

    'Para Eliminar una Categoria'
    Public Sub Eliminar_categoria(ByVal registros As Entidad_Categoria)
        Dim Datos As New Dato_Categoria
        Datos.Eliminar_Categoria(registros)
    End Sub
End Class

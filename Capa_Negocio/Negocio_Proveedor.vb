Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Proveedor
    Public Function Mostrartodosproveedor() As List(Of Entidad_Proveedor)
        Dim lista As New List(Of Entidad_Proveedor)
        Dim obj As New Dato_Proveedor
        lista = obj.Mostrartodosproveedor
        Return lista
    End Function

    'Para agregar un nuevo proveedor'
    Public Sub Nuevo_Proveedor(ByVal registros As Entidad_Proveedor)
        Dim Datos As New Dato_Proveedor
        Datos.Nuevo_Proveedor(registros)
    End Sub

    'Para modificar un proveedor'
    Public Sub Modificar_Proveedor(ByVal registros As Entidad_Proveedor)
        Dim Datos As New Dato_Proveedor
        Datos.Modificar_Proveedor(registros)
    End Sub

End Class

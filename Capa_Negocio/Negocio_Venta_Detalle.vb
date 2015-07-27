Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Venta_Detalle
    Public Sub Nueva_VentaDetalle(ByVal registros As Entidad_ventadetalle)
        Dim Datos As New Dato_Venta_Detalle
        Datos.Nueva_VentaDetalle(registros)
    End Sub

    'para listar lo que debe un cliente determinado
    Public Function listardeuda(ByVal id As Integer) As List(Of Entidad_ventadetalle)
        Dim lista As New List(Of Entidad_ventadetalle)
        Dim obj As New Dato_Venta_Detalle
        lista = obj.listardeuda(id)
        Return lista
    End Function

    'Para actualizar a los clientes que deben'
    Public Sub Actualiza_deudas(ByVal registros As Entidad_ventadetalle)
        Dim Datos As New Dato_Venta_Detalle
        Datos.Actualiza_deudas(registros)
    End Sub
End Class

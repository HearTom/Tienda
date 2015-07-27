Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Compras
    Public Sub Nueva_Compra(ByVal registros As Entidad_Compras)
        Dim Datos As New Dato_Compras
        Datos.Nueva_Compra(registros)
    End Sub

    Public Function pago_rus(ByVal fecha As String) As List(Of Entidad_Compras)
        Dim lista As New List(Of Entidad_Compras)
        Dim obj As New Dato_Compras
        lista = obj.pago_rus(fecha)
        Return lista
    End Function
End Class

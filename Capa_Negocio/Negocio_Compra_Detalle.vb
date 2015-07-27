Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Compra_Detalle
    Public Sub Nueva_Compra_Detalle(ByVal registros As Entidad_Compra_Detalles)
        Dim Datos As New Dato_Compra_detalle
        Datos.Nueva_CompraDetalle(registros)
    End Sub
End Class

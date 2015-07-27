Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Venta
    Public Sub Nueva_Venta(ByVal registros As Entidad_Venta)
        Dim Datos As New Dato_Venta
        Datos.Nueva_Venta(registros)
    End Sub
End Class

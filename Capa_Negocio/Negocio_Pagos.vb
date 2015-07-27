Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Pagos
    'Para registrar un pago'
    Public Sub Nuevo_Pago(ByVal registros As Entidad_Pagos)
        Dim Datos As New Dato_Pagos
        Datos.Nuevo_Pagos(registros)
    End Sub
End Class

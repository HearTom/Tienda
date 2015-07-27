Imports Capa_Entidad
Imports Capa_Datos
Public Class Negocio_reporte

    Public Sub mostrar_reporte()
        Dim datos As New Dato_Reporte
        datos.mostrar_reporte()
    End Sub

    Public Function reporte_cuenta(ByVal param As Integer) As DataTable
        Dim table As DataTable
        Dim datos As New Dato_Reporte
        table = datos.reporte_cuenta(param)
        Return table
    End Function
End Class

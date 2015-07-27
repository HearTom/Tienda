Imports Capa_Entidad
Imports Capa_Datos



Public Class Negocio_Empleado
    'Para El login
    Public Function Validar(ByVal registros As Entidad_Empleado) As Boolean
        Dim valor As Boolean
        Dim obj As New Dato_Empleado
        valor = obj.Validar(registros)

        Return valor
    End Function

    'Para obtener el idempleado
    Public Function obtener_idempleado(ByVal usuario As String) As List(Of Entidad_Empleado)
        Dim lista As New List(Of Entidad_Empleado)
        Dim obj As New Dato_Empleado
        lista = obj.obtener_idempleado(usuario)
        Return lista
    End Function
End Class

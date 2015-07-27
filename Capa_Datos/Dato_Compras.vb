Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Compras
    Public Sub Nueva_Compra(ByVal registros As Entidad_Compras)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("agregarcompra", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idtipocomprobante", registros.idtipocomprobante)
                .AddWithValue("@idfactura", registros.idfactura)
                .AddWithValue("@idproveedor", registros.idproveedor)
                .AddWithValue("@importe_total", registros.importetotal)
                .AddWithValue("@retencion", registros.retencion)
                .AddWithValue("@fecha", registros.fecha)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    Public Function pago_rus(ByVal fecha As String) As List(Of Entidad_Compras)
        Dim lista As New List(Of Entidad_Compras)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_calcularus", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@fecha", fecha)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Compras
                reg.importetotal = IIf(dr.GetValue(0).ToString = "", 0, dr.GetValue(0).ToString())
                reg.retencion = IIf(dr.GetValue(1).ToString = "", 0, dr.GetValue(1).ToString())
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

End Class

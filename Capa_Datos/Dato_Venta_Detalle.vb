Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Venta_Detalle
    Public Sub Nueva_VentaDetalle(ByVal registros As Entidad_ventadetalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_regitrarventadetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idproducto", registros.idproducto)
                .AddWithValue("@precio", registros.precio)
                .AddWithValue("@cantidad", registros.cantidad)
                .AddWithValue("@cancelado", registros.cancelado)


            End With
            cmd.ExecuteNonQuery()
        End Using
    End Sub
    'Metodo que muestra cuando debe un determinado cliente se utiliza en el formulario pagos'
    Public Function listardeuda(ByVal id As Integer) As List(Of Entidad_ventadetalle)
        Dim lista As New List(Of Entidad_ventadetalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_listardeuda1", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idcliente", id)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_ventadetalle
                reg.idventa = dr.GetValue(0).ToString
                reg.idproducto = dr.GetValue(1).ToString()
                reg.importe = dr.GetValue(2).ToString() 'aqui importe representa importe - montopagado'
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    Public Sub Actualiza_deudas(ByVal registros As Entidad_ventadetalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_actualiventadetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idventa", registros.idventa)
                .AddWithValue("@idproducto", registros.idproducto)
                .AddWithValue("@cancelado", registros.cancelado)
                .AddWithValue("@montopagado", registros.montopagado)


            End With
            cmd.ExecuteNonQuery()
        End Using
    End Sub


End Class

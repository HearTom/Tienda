Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Compra_detalle
    Public Sub Nueva_CompraDetalle(ByVal registros As Entidad_Compra_Detalles)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_registrarcompradetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idproducto", registros.idproducto)
                .AddWithValue("@importe", registros.importe)
                .AddWithValue("@cantidad", registros.cantidad)


            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub
End Class

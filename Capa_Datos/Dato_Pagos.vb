Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Pagos
    Public Sub Nuevo_Pagos(ByVal registros As Entidad_Pagos)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_insertarpagos", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idcliente", registros.idcliente)
                .AddWithValue("@monto", registros.monto)
                .AddWithValue("@fecha", registros.fecha)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub
End Class

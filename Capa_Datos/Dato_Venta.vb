Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Venta
    Public Sub Nueva_Venta(ByVal registros As Entidad_Venta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_venta", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idcliente", registros.idcliente)
                .AddWithValue("@idempleado", registros.idempleado)
                .AddWithValue("@idtipoventa", registros.idtipoventa)
                .AddWithValue("@fecha", registros.fecha)
            End With
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class

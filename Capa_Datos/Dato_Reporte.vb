Imports Capa_Entidad
Imports System.Data
Imports System.Data.SqlClient
Public Class Dato_Reporte
    Public Sub mostrar_reporte()
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim entidad As New Entidad_Reporte
            Try
                entidad.BaseDatos = cnn.Database
                entidad.Servidor = cnn.DataSource
            Catch ex As Exception

            End Try
        End Using
    End Sub

    Public Function reporte_cuenta(ByVal param As Integer) As DataTable
        Dim adp As New SqlDataAdapter
        Dim dtDatos As New DataTable
        Dim table As New DataTable
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            adp.SelectCommand = New SqlCommand()
            adp.SelectCommand.Connection = cnn
            adp.SelectCommand.CommandText = "p_mostrarcuenta"
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.Add("@idcliente", SqlDbType.Int, 8).Value = param
            adp.Fill(table)
        End Using

        Return table
    End Function
End Class

Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Categoria
    Public Function Mostrarcategoria() As List(Of Entidad_Categoria)
        Dim lista As New List(Of Entidad_Categoria)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarcategoria", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Categoria
                reg.idcategoria = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                reg.descripcion = dr.GetValue(2).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'Para Agregar una Nueva Categoria'
    Public Sub Nueva_Categoria(ByVal registros As Entidad_Categoria)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevacategoria", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@descripcion", registros.descripcion)
                End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una Categoria'

    Public Sub Modificar_Categoria(ByVal registros As Entidad_Categoria)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarcategoria", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@descripcion", registros.descripcion)
                .AddWithValue("@idcategoria", registros.idcategoria)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar una Categoria'

    Public Sub Eliminar_Categoria(ByVal registros As Entidad_Categoria)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminarcategoria", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idcategoria", registros.idcategoria)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub
End Class

Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Proveedor

    Public Function Mostrartodosproveedor() As List(Of Entidad_Proveedor)
        Dim lista As New List(Of Entidad_Proveedor)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("mostrartodoproveedores", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Proveedor
                reg.idproveedor = dr.GetValue(0).ToString
                reg.nombre = dr.GetValue(1).ToString()
                reg.Ruc = dr.GetValue(2).ToString()
                reg.representante = dr.GetValue(3).ToString()
                reg.direccion = dr.GetValue(4).ToString()
                reg.telefono = dr.GetValue(5).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'para agregar un nuevo proveedor'
    Public Sub Nuevo_Proveedor(ByVal registros As Entidad_Proveedor)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevoproveedor", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@ruc", registros.Ruc)
                .AddWithValue("@representante", registros.representante)
                .AddWithValue("@direccion", registros.direccion)
                .AddWithValue("@telefono", registros.telefono)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'para modificar un nuevo proveedor'
    Public Sub Modificar_Proveedor(ByVal registros As Entidad_Proveedor)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarproveedor", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idproveedor", registros.idproveedor)
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@ruc", registros.Ruc)
                .AddWithValue("@representante", registros.representante)
                .AddWithValue("@direccion", registros.direccion)
                .AddWithValue("@telefono", registros.telefono)
            End With
            cmd.ExecuteNonQuery()
        End Using
    End Sub


End Class

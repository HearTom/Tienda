Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Cliente
    'funcion para mostrar el nombre y apellido del cliente
    Public Function Mostrarcliente() As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_cliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Cliente
                reg.idcliente = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'funcion para mostrar el nombre y apellido del cliente
    Public Function Mostrartodocliente() As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrartodocliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Cliente
                reg.idcliente = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                reg.apellidos = dr.GetValue(2).ToString()
                reg.telefono = dr.GetValue(3).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function


    Public Function buscacliente(ByVal nombre As String) As List(Of Entidad_Cliente)

        Dim lista As New List(Of Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Try
                Dim cmd As New SqlCommand("p_buscacliente", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nombre", nombre)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                While dr.Read
                    Dim reg As New Entidad_Cliente
                    reg.idcliente = dr.GetValue(0).ToString()
                    reg.nombre = dr.GetValue(1).ToString()
                    reg.apellidos = dr.GetValue(2).ToString()
                    reg.telefono = dr.GetValue(3).ToString()
                    lista.Add(reg)
                End While
                dr.Close()
            Catch ex As Exception
            End Try
        End Using

        Return lista

    End Function

    'para agregar un nuevo cliente'
    Public Sub Nuevo_cliente(ByVal registros As Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevocliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@apellido", registros.apellidos)
                .AddWithValue("@telefono", registros.telefono)

            End With
            cmd.ExecuteNonQuery()
            cnn.Close()

        End Using
    End Sub

    'para modificar un cliente'
    Public Sub modificar_cliente(ByVal registros As Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarcliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@apellido", registros.apellidos)
                .AddWithValue("@telefono", registros.telefono)
                .AddWithValue("@idcliente", registros.idcliente)

            End With
            cmd.ExecuteNonQuery()
            cnn.Close()

        End Using
    End Sub
   
End Class

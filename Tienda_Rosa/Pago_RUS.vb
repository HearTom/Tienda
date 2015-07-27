Imports Capa_Negocio
Imports Capa_Entidad
Public Class Pago_RUS
    Dim cuota As Double
    Private Function convertirfecha_ansi(ByVal picker As DateTimePicker) As String
        Dim cadena As String = ""
        cadena = CStr(picker.Value.Year)
        If (picker.Value.Month) < 10 Then
            cadena = cadena + "0" + CStr(picker.Value.Month)
        Else
            cadena = cadena + CStr(picker.Value.Month)
        End If

        If picker.Value.Day < 10 Then
            cadena = cadena + "0" + CStr(picker.Value.Day)
        Else
            cadena = cadena + CStr(picker.Value.Day)
        End If
        Return cadena
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim negocio As New Negocio_Compras
        Dim entidad As New List(Of Entidad_Compras)

        entidad = negocio.pago_rus(Me.convertirfecha_ansi(Me.DateTimePicker1))
        If entidad.Count >= 0 Then
            Dim monto As Double = 0
            Dim compensar As Double = 0
            monto = entidad.Item(0).importetotal
            compensar = entidad.Item(0).retencion
            monto = monto + (monto * 0.25)
            TextBox1.Text = CType(monto, String)
            TextBox2.Text = CType(devolvercategoria(monto), String)
            TextBox3.Text = CType(compensar, String)
            TextBox4.Text = CType(cuota - compensar, String)
        End If

    End Sub

    Private Function devolvercategoria(ByVal monto As Double) As Integer
        Dim categoria As Integer = 0
        If monto >= 0 And monto <= 5000 Then
            categoria = 1
            cuota = 20
        ElseIf monto > 5000 And monto <= 8000 Then
            categoria = 2
            cuota = 50
        ElseIf monto > 8000 And monto <= 13000 Then
            categoria = 3
            cuota = 200
        ElseIf monto > 13000 And monto <= 20000 Then
            categoria = 4
            cuota = 400
        Else
            categoria = 5
            cuota = 600
        End If
        Return categoria
    End Function
End Class
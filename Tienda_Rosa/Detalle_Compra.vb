Public Class Detalle_Compra

  
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Debe de ingresar una cantidad")
            Exit Sub
        End If
        If TextBox1.Text = "0" Then
            MessageBox.Show("Deberia ingresar una cantidad mayor a 0")
            Exit Sub
        End If
        If Not IsNumeric(TextBox1.Text) Then
            MessageBox.Show("La Cantidad no es Valida")
            Exit Sub
        End If



        Dim oreg As New ListViewItem(PictureBox1.Name) 'codigo del producto'

        With oreg
            .SubItems.Add(Label6.Text) 'nombre'
            .SubItems.Add(TextBox1.Text)  'Cantidad'
            .SubItems.Add(NumericUpDown1.Value) 'importe'
            Compras.ListView1.Items.Add(oreg) 'Agregamos todo esto al listview'
        End With
        Compras.Label7.Text = CStr(CDbl(Compras.Label7.Text) + CDbl(NumericUpDown1.Value))
        Compras.verificarcheckboxes()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Dispose()
        Me.Close()
    End Sub


End Class
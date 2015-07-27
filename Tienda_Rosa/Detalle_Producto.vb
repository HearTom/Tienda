Public Class Detalle_Producto

    Private Sub Detalle_Producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False 'con esto desapareces los botones maximizar minimizat y cerrar'
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "Añadir")
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Cancelar")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Dispose()
        Me.Close()
    End Sub

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

        Dim posicion As Integer 'variable que contendra la posicion en la que se repite el listview'
        Dim stock As Integer
        posicion = recorrerlistview(Venta.ListView1)
        ' si es igual a -1 significa que no se repite
        If posicion = -1 Then
            stock = CType(Me.Label2.Text, Integer)
            If stock >= CType(Me.TextBox1.Text, Integer) Then 'Comparamos el stock con la cantidad' 
                Dim oreg As New ListViewItem(Label6.Text) 'nombre  del producto'

                With oreg
                    .SubItems.Add(Label3.Text) 'Precio'
                    .SubItems.Add(TextBox1.Text)  'Cantidad'
                    .SubItems.Add(PictureBox1.Name) 'Codigo del producto'
                    Venta.ListView1.Items.Add(oreg) 'Agregamos todo esto al listview'
                End With
                'Sumamos el total'
                Venta.Label4.Text = CType(CType(Venta.Label4.Text, Double) + (CType(Label3.Text, Double) * CType(TextBox1.Text, Double)), String) 'Multiplicamos el precio por la cantidad'
                Me.Close()
            Else
                MessageBox.Show("No tienes stock suficiente")
            End If

        Else
            stock = CType(Me.Label2.Text, Integer)
            If stock >= (CType(Me.TextBox1.Text, Integer) + CType(Venta.ListView1.Items(posicion).SubItems(2).Text, Integer)) Then
                Venta.ListView1.Items(posicion).SubItems(2).Text = CType(CType(Venta.ListView1.Items(posicion).SubItems(2).Text, Double) + CType(TextBox1.Text, Double), String)
                Venta.Label4.Text = CType(CType(Venta.Label4.Text, Double) + (CType(Label3.Text, Double) * CType(TextBox1.Text, Double)), String)
                Me.Close()
            Else
                MessageBox.Show("No tienes stock suficiente")
            End If

        End If




    End Sub

    'Funcion que recorre el listview para ver si es que se repite algun producto y retorna la posicion en la que se encuentra'
    Private Function recorrerlistview(ByVal listview1 As ListView) As Integer

        Dim nombre As String
        Dim posicion As Integer = -1

        'Recorrermos el listview para saber si ahi un producto que se repite'
        For i = 0 To listview1.Items.Count - 1
            nombre = listview1.Items(i).SubItems(0).Text
            If posicion = -1 Then
                If Label6.Text = nombre Then
                    posicion = i
                Else
                    posicion = -1
                End If
            End If
        Next
        Return posicion
    End Function
End Class
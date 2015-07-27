Imports Capa_Negocio
Imports Capa_Entidad
Imports System.IO
Public Class Principal
    Dim negocio As New Negocio_Producto
    Dim entidad As New List(Of Entidad_Producto)
    Dim contar As Integer = 0
    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarimagenespicturebox()
        'iniciamos label'
        Label10.Size = New System.Drawing.Size(153, 35)
        Label10.AutoSize = False
        Label10.Text = "SLIDE DE IMAGENES"
        Timer1.Enabled = True
        Timer1.Interval = "3000"
        entidad = negocio.productos_pa_comprar
    End Sub
    'Cargar imagenes para los picturebox'
    Private Sub cargarimagenespicturebox()
        If File.Exists(Application.StartupPath + "\imagenes\diseño\ventas.png") Then
            PictureBox8.Load(Application.StartupPath + "\imagenes\diseño\ventas.png")
        End If
        If File.Exists(Application.StartupPath + "\imagenes\diseño\compras.png") Then
            PictureBox5.Load(Application.StartupPath + "\imagenes\diseño\compras.png")
        End If
        If File.Exists(Application.StartupPath + "\imagenes\diseño\search.png") Then
            PictureBox2.Load(Application.StartupPath + "\imagenes\diseño\search.png")
        End If
        If File.Exists(Application.StartupPath + "\imagenes\diseño\pagos.png") Then
            PictureBox4.Load(Application.StartupPath + "\imagenes\diseño\pagos.png")
        End If
        If File.Exists(Application.StartupPath + "\imagenes\diseño\mantenimiento.png") Then
            PictureBox7.Load(Application.StartupPath + "\imagenes\diseño\mantenimiento.png")
        End If
        If File.Exists(Application.StartupPath + "\imagenes\diseño\reportes.png") Then
            PictureBox3.Load(Application.StartupPath + "\imagenes\diseño\reportes.png")
        End If

        If File.Exists(Application.StartupPath + "\imagenes\diseño\KEY.png") Then
            PictureBox6.Load(Application.StartupPath + "\imagenes\diseño\KEY.png")
        End If

        If File.Exists(Application.StartupPath + "\imagenes\diseño\LOCK.png") Then
            PictureBox10.Load(Application.StartupPath + "\imagenes\diseño\LOCK.png")
        End If

    End Sub

   'Cuando entra en el control'
    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox2, Label1)
    End Sub

    'Cuando sale del control'
    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        cambiarcolor(88, 89, 185, PictureBox2, Label1)
    End Sub

    'Cuando entra en el control'

    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox3, Label4)
    End Sub

    'Cuando deja el control'
    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        cambiarcolor(140, 191, 38, PictureBox3, Label4)
    End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        MonstrarCuenta.Show()
    End Sub



    'Funcion para cambiar de color'
    Private Sub cambiarcolor(ByVal red As Integer, ByVal green As Integer, ByVal blue As Integer, ByVal pict As PictureBox, ByVal etiqueta As Label)
        pict.BackColor = Color.FromArgb(CType(CType(red, Byte), Integer), CType(CType(green, Byte), Integer), CType(CType(blue, Byte), Integer))
        etiqueta.BackColor = Color.FromArgb(CType(CType(red, Byte), Integer), CType(CType(green, Byte), Integer), CType(CType(blue, Byte), Integer))
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Compras.Show()
    End Sub

    Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox5, Label2)
    End Sub


    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        cambiarcolor(3, 72, 131, PictureBox5, Label2)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Pagos.Show()
    End Sub

    Private Sub PictureBox8_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox8, Label8)
    End Sub

    Private Sub PictureBox8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseLeave
        cambiarcolor(0, 171, 169, PictureBox8, Label8)
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        Venta.Show()
    End Sub

    Private Sub PictureBox7_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseEnter
        '    cambiarcolor(27, 161, 226, PictureBox7, Label7)
        '    Label14.BackColor = Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        '    Label16.BackColor = Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        '    Label15.BackColor = Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
    End Sub

    Private Sub PictureBox7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseLeave
        'cambiarcolor(110, 21, 95, PictureBox7, Label7)
        'Label14.BackColor = Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(95, Byte), Integer))
        'Label15.BackColor = Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(95, Byte), Integer))
        'Label16.BackColor = Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(95, Byte), Integer))
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        Mantenimiento_Productos.Show()
    End Sub

    Private Sub Label14_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseEnter
        Label14.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label14_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseLeave
        Label14.ForeColor = Color.White
    End Sub

    Private Sub Label15_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseEnter
        Label15.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label15_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseLeave
        Label15.ForeColor = Color.White
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        Mantenimiento_Categoria.Show()
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        Mantenimiento_Proveedores.Show()
    End Sub

    Private Sub Label16_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.MouseEnter
        Label16.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label16_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.MouseLeave
        Label16.ForeColor = Color.White
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        Mantenimiento_Clientes.Show()
    End Sub

    Private Sub Label9_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseEnter
        Label9.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseLeave
        Label9.ForeColor = Color.White
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Pago_RUS.Show()
    End Sub



    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Venta.Show()
    End Sub

    Private Sub Label8_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox8, Label8)
    End Sub


    Private Sub Label8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        cambiarcolor(0, 171, 169, PictureBox8, Label8)
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Compras.Show()
    End Sub

    Private Sub Label2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox5, Label2)
    End Sub


    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        cambiarcolor(3, 72, 131, PictureBox5, Label2)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If contar <> entidad.Count Then
            If File.Exists(Application.StartupPath + "\imagenes\productos\" + entidad(contar).foto) Then
                PictureBox9.Load(Application.StartupPath + "\imagenes\productos\" + entidad(contar).foto)
            End If
            Label10.Text = entidad(contar).nombre & vbCrLf & "STOCK = " & entidad(contar).stock
        Else
            contar = 0
            Exit Sub
        End If

        contar += 1
    End Sub

    Private Sub PictureBox6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox6, Label6)
    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.BackColor = Color.Brown
        Label6.BackColor = Color.Brown
    End Sub


    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Pago_RUS.Show()
    End Sub

    Private Sub Label6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox6, Label6)
    End Sub

    Private Sub Label6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseLeave
        PictureBox6.BackColor = Color.Brown
        Label6.BackColor = Color.Brown
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        MonstrarCuenta.Show()
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox2, Label1)
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        cambiarcolor(88, 89, 185, PictureBox2, Label1)
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        Me.Close()
    End Sub

    Private Sub PictureBox10_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox10, Label11)
    End Sub

    Private Sub PictureBox10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseLeave
        PictureBox10.BackColor = Color.BlueViolet
        Label11.BackColor = Color.BlueViolet
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Me.Close()
    End Sub

    Private Sub Label11_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox10, Label11)
    End Sub

    Private Sub Label11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseLeave
        PictureBox10.BackColor = Color.BlueViolet
        Label11.BackColor = Color.BlueViolet
    End Sub
End Class
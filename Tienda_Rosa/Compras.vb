Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Public Class Compras

    Private txt() As PictureBox
    Private lbl() As Label
    Dim panel As New PanelExtended
    Private Sub Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        'Me.ForeColor = Color.Black
        'Inicializamos el panel'
        panel.AutoScroll = True
        panel.Location = New System.Drawing.Point(480, 85)
        panel.Name = "Panel1"
        panel.Size = New System.Drawing.Size(550, 580)



        'Se agrega al formulario'
        Me.Controls.Add(panel)

        Dim num As Integer
        num = contarproducto()
        mostrarproducto(num)

        ComboBox1.Items.Add("Factura")
        ComboBox1.Items.Add("Boleta de Venta")


        With ListView1
            .View = View.Details
            .Columns.Add("id", 30)
            .Columns.Add("Producto", 230)
            .Columns.Add("Cantidad", 70)
            .Columns.Add("Importe", 70)


        End With

        cargarcombo()
        cargarcombocategoria()
    End Sub

    Private Sub cargarcombo()
        Dim lista As New List(Of Entidad_Proveedor)
        Dim obj As New Negocio_Proveedor
        lista = obj.Mostrartodosproveedor
        ComboBox2.DataSource = lista
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "idproveedor"
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub cargarcombocategoria()
        Dim lista As New List(Of Entidad_Categoria)
        Dim obj As New Negocio_Categoria
        lista = obj.Mostrarcategoria
        ComboBox3.DataSource = lista
        ComboBox3.DisplayMember = "nombre"
        ComboBox3.ValueMember = "idcategoria"
        ComboBox3.SelectedIndex = -1
    End Sub

    Private Sub dibuja(ByVal fin As Integer, ByVal lista As List(Of Entidad_Producto))

        panel.Controls.Clear() 'Eliminamos todos los controles que esten en panel'
        Dim i As Integer
        Dim j As Integer = 0
        Dim contador As Integer = 0
        ReDim txt(fin)
        ReDim lbl(fin)
        Dim constante = 160 'variable que determina el espaciado entre los picturebox'
        Dim constantex = 130

        For i = 1 To fin

            txt(i) = New PictureBox 'instanciamos los picturebox'
            lbl(i) = New Label 'iniciamos el label'

            'Picturebox'
            Me.txt(i).Size = New System.Drawing.Size(130, 130)
            Me.txt(i).Name = lista.Item(i - 1).idproducto
            Me.txt(i).SizeMode = PictureBoxSizeMode.StretchImage
            If File.Exists(My.Application.Info.DirectoryPath + "\imagenes\productos\" + lista.Item(i - 1).foto) Then
                Me.txt(i).Load(My.Application.Info.DirectoryPath + "\imagenes\productos\" + lista.Item(i - 1).foto)
            End If



            contador = contador + 1
            If contador <= 4 Then
                txt(i).Location = New System.Drawing.Point((contador * constantex) - constantex, j * constante) 'para la ubicacion'

            Else
                j = j + 1
                txt(i).Location = New System.Drawing.Point(0, j * constante)
                contador = 1
            End If

            panel.Controls.Add(txt(i))

            lbl(i).Location = New System.Drawing.Point(txt(i).Location.X, txt(i).Location.Y + 130)
            Me.txt(i).Text = lista.Item(i - 1).nombre
            Me.lbl(i).Text = lista.Item(i - 1).nombre
            Me.lbl(i).ForeColor = Color.White
            Me.lbl(i).BackColor = Color.DarkRed
            Me.lbl(i).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl(i).Size = New System.Drawing.Size(130, 30)
            Me.lbl(i).TextAlign = ContentAlignment.TopCenter
            panel.Controls.Add(lbl(i))

            AddHandler txt(i).Click, AddressOf All_filter_click
        Next

    End Sub

    'Asignar un manejador de evento al control creado'
    Private Sub All_filter_click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim picture As PictureBox
        picture = CType(sender, PictureBox)
        Dim obj As New Negocio_Producto
        Dim listaProductos As New List(Of Entidad_Producto)
        listaProductos = obj.preciostock(picture.Name) 'Se Busca el precio y el stock' 
        If File.Exists(picture.ImageLocation) Then
            Detalle_Compra.PictureBox1.Load(picture.ImageLocation) 'copiamos la imagen de un picturebox a otro'
        End If
        Detalle_Compra.PictureBox1.Name = picture.Name
        Detalle_Compra.Label6.Text = picture.Text
        Detalle_Compra.Show() 'Abrimos el formulario detalle producto '
    End Sub

    Private Function contarproducto() As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        valor = obj.contarproductos
        Return valor
    End Function

    'Procedimiento para que se muestren todos los productos en Picturebox'
    Private Sub mostrarproducto(ByVal fin As Integer)
        Dim lista As New List(Of Entidad_Producto)
        Dim obj As New Negocio_Producto
        lista = obj.Mostrartodosproducto
        dibuja(fin, lista)
    End Sub

    Public Sub verificarcheckboxes()
        Dim igv As Double = 0.18
        If CheckBox1.Checked Then
            Label11.Text = Str(Math.Round(CDbl(Label7.Text) * igv, 2))
        Else
            Label11.Text = "0.00"
        End If

        If CheckBox2.Checked Then
            Label12.Text = Str(Math.Round((CDbl(Label7.Text) + CDbl(Label11.Text)) * 0.02, 2))
        Else
            Label12.Text = "0.00"
        End If
        Label14.Text = Str(CDbl(Label7.Text) + CDbl(Label11.Text) + CDbl(Label12.Text))

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        verificarcheckboxes()
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        verificarcheckboxes()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex >= 0 Then
            Label4.Text = ComboBox2.SelectedValue.ToString
        Else
            Label4.Text = ""
        End If

    End Sub

    Private Sub Nueva_Compra()
        'Agregar Compra
        Dim Entidad As New Entidad_Compras
        Dim Negocio As New Negocio_Compras
        

        With Entidad
            .fecha = convertirfecha_ansi(DateTimePicker1)
            .idtipocomprobante = obtenertipocomprobante()
            .idfactura = TextBox3.Text
            .idproveedor = Label4.Text
            .importetotal = CDbl(Label14.Text)
            .retencion = CDbl(Label12.Text)
        End With
        'Agregamos una nueva compra'
        Negocio.Nueva_Compra(Entidad)

        'Para Agregar compra_Detalle'
        Dim Entidad_detalle As New Entidad_Compra_Detalles
        Dim Negocio_detalle As New Negocio_Compra_Detalle

        For i = 0 To ListView1.Items.Count - 1
            
            With Entidad_detalle
                .idproducto = ListView1.Items(i).SubItems(0).Text
                .importe = ListView1.Items(i).SubItems(3).Text
                .cantidad = ListView1.Items(i).SubItems(2).Text
            End With

            'Agregamos la Compra Detalle'
            Negocio_detalle.Nueva_Compra_Detalle(Entidad_detalle)


            'Para Actualizar el Stock'
            Dim Entidad_productos As New Entidad_Producto
            Dim Negocio_productos As New Negocio_Producto

           

            With Entidad_productos
                .stock = ListView1.Items(i).SubItems(2).Text
                .idproducto = ListView1.Items(i).SubItems(0).Text
            End With

            Negocio_productos.Actualiza_Stockcompras(Entidad_productos)

        Next
        MessageBox.Show("Compra Exitosa")


    End Sub

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

    Private Function obtenertipocomprobante()
        Return ComboBox1.SelectedIndex
    End Function

    Private Sub btnvender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvender.Click
        If ComboBox2.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione un proveedor")
            ComboBox2.Focus()
            Exit Sub
        End If

        If ComboBox1.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar un tipo de comprobante")
            ComboBox1.Focus()
            Exit Sub
        End If

        If TextBox3.Text = "" Then
            MessageBox.Show("Ingrese el n° de factura o boleta")
            TextBox3.BackColor = Color.Yellow
            TextBox3.Focus()
            Exit Sub
        End If

        If ListView1.Items.Count <= 0 Then
            MessageBox.Show("Debe seleccionar por lo menos un producto")
            Exit Sub
        End If

        Nueva_Compra()
        limpiar()
    End Sub

  
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim cuenta As Integer
        Dim obj As New Negocio_Producto
        Dim listaProductos As New List(Of Entidad_Producto)
        If CheckBox3.Checked And ComboBox3.SelectedIndex >= 0 Then
            If IsNumeric(ComboBox3.SelectedValue) Then
                listaProductos = obj.buscarnomcat(Me.TextBox2.Text, ComboBox3.SelectedValue)
                cuenta = obj.contarproductospornomycat(Me.TextBox2.Text, ComboBox3.SelectedValue)
                dibuja(cuenta, listaProductos)
            End If

        Else
            listaProductos = obj.buscartodoproducto(Me.TextBox2.Text)
            cuenta = contarproductoporfiltro(TextBox2.Text)
            dibuja(cuenta, listaProductos)
        End If
    End Sub

    'Devuelve la cantidad de productos segun el nombre '
    Private Function contarproductoporfiltro(ByVal nombre As String) As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        valor = obj.contarproductosporfiltro(nombre)
        Return valor
    End Function

    Private Sub verifica(ByVal combo As ComboBox)
        If CheckBox3.Checked And combo.SelectedIndex >= 0 Then
            If IsNumeric(combo.SelectedValue) Then
                Dim cuenta As Integer
                Dim obj As New Negocio_Producto
                Dim listaProductos As New List(Of Entidad_Producto)
                listaProductos = obj.Mostrarproducto(combo.SelectedValue)
                cuenta = contarproductoporcategoria(combo.SelectedValue)
                dibuja(cuenta, listaProductos)
            End If
        End If
    End Sub

    'Devuelve la cantidad de productos segun su categoria '
    Private Function contarproductoporcategoria(ByVal id As Integer) As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        valor = obj.contarproductosporcategoria(id)
        Return valor
    End Function

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        verifica(ComboBox3)
    End Sub

 
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            verifica(ComboBox3)
        Else
            Dim num As Integer
            num = contarproducto()
            mostrarproducto(num)
        End If

    End Sub

    Private Sub limpiar()
        Label4.Text = ""
        ComboBox2.SelectedIndex = -1
        ComboBox1.SelectedIndex = -1
        TextBox3.Text = ""
        TextBox3.BackColor = Color.White
        DateTimePicker1.Value = Now
        ListView1.Items.Clear()
        CheckBox2.Checked = False
        CheckBox1.Checked = False
        Label7.Text = "0.00"
        Label11.Text = "0.00"
        Label12.Text = "0.00"
        Label14.Text = "0.00"
        TextBox2.Text = ""
        CheckBox3.Checked = False
        ComboBox3.SelectedIndex = -1
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 1 Then
            CheckBox2.Enabled = False
            CheckBox2.Checked = False
        Else
            CheckBox2.Enabled = True
        End If
    End Sub
End Class
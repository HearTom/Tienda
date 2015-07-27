Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO

Public Class Venta
    Private txt() As PictureBox
    Private lbl() As Label
    Dim panel As New PanelExtended

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Busca_Clientes.Show()
        Busca_Clientes.Text = "Ventas"
    End Sub

    Private Sub Venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.Coral
        panel.AutoScroll = True
        panel.Location = New System.Drawing.Point(500, 85)
        panel.Name = "Panel1"
        panel.Size = New System.Drawing.Size(540, 580)
        'Se agrega al formulario'
        Me.Controls.Add(panel)

        Dim num As Integer
        num = contarproducto()
        mostrarproducto(num)

        With ListView1
            .View = View.Details
            .Columns.Add("Producto", 230)
            .Columns.Add("Precio", 70)
            .Columns.Add("Cantidad", 70)
            .Columns.Add("Productid", 70)

        End With

        cargarcombo(ComboBox1)
        cargarcombocategoria()

    End Sub


    Private Sub cargarcombo(ByVal combo As ComboBox)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.Mostrarcliente
        combo.DataSource = lista
        combo.DisplayMember = "nombre"
        combo.ValueMember = "idcliente"
        combo.SelectedIndex = -1
    End Sub

    Private Sub cargarcombocategoria()
        Dim lista As New List(Of Entidad_Categoria)
        Dim obj As New Negocio_Categoria
        lista = obj.Mostrarcategoria
        ComboBox2.DataSource = lista
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "idcategoria"
        ComboBox2.SelectedIndex = -1
    End Sub
    'para buscar un producto'
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim cuenta As Integer
        Dim obj As New Negocio_Producto
        Dim listaProductos As New List(Of Entidad_Producto)
        If CheckBox1.Checked And ComboBox2.SelectedIndex >= 0 Then
            If IsNumeric(ComboBox2.SelectedValue) Then
                listaProductos = obj.buscarnomcat(Me.TextBox2.Text, ComboBox2.SelectedValue)
                cuenta = obj.contarproductospornomycat(Me.TextBox2.Text, ComboBox2.SelectedValue)
                dibuja(cuenta, listaProductos)
            End If
           
        Else

            listaProductos = obj.buscartodoproducto(Me.TextBox2.Text)

            cuenta = contarproductoporfiltro(TextBox2.Text)
            dibuja(cuenta, listaProductos)
        End If


    End Sub

    Private Sub btnvender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvender.Click

        If Label5.Text = " " Then
            MessageBox.Show("Debe seleccionar un cliente")
            ComboBox1.Focus()
            Exit Sub
        End If

        If ListView1.Items.Count <= 0 Then
            MessageBox.Show("Debe seleccionar por lo menos un producto")
            Exit Sub
        End If

        'para recuperar el id del empleado
        Dim lista2 As New List(Of Entidad_Empleado)
        Dim obj2 As New Negocio_Empleado
        lista2 = obj2.obtener_idempleado(Mid(Principal.Text, 11, Principal.Text.Length))

        'para saber el tipodeventa'
        Dim tipoventa As Integer
        Dim cancelado As Integer
        If rbtcontado.Checked Then
            tipoventa = 1
            cancelado = 1
        End If

        If rbtcredito.Checked Then
            tipoventa = 2
            cancelado = 0
        End If


        'Agregar Venta
        Dim Entidad As New Entidad_Venta
        Dim Negocio As New Negocio_Venta




        With Entidad
            .idcliente = Label5.Text 'Agregamos idcliente'
            .idempleado = lista2.Item(0).idempleado 'Agregamos idempleado'
            .idtipoventa = tipoventa
            .fecha = Me.convertirfecha_ansi(Me.DateTimePicker1, Me.DateTimePicker2)
        End With
        'llamamos a agregar venta'
        Negocio.Nueva_Venta(Entidad)


        'Para Agregar Venta_Detalle'
        Dim Entidad_detalle As New Entidad_ventadetalle
        Dim Negocio_detalle As New Negocio_Venta_Detalle

        For i = 0 To ListView1.Items.Count - 1
            'Para Obtener el id del producto
            'Dim lista3 As New List(Of Entidad_Producto)
            'Dim obj3 As New Negocio_Producto
            'lista3 = obj3.obtener_idproducto(ListView1.Items(i).SubItems(0).Text)


            With Entidad_detalle
                .idproducto = ListView1.Items(i).SubItems(3).Text
                .precio = ListView1.Items(i).SubItems(1).Text
                .cantidad = ListView1.Items(i).SubItems(2).Text
                .cancelado = cancelado
            End With
            'Agregamos la venta Detalle'
            Negocio_detalle.Nueva_VentaDetalle(Entidad_detalle)



            'Para Actualizar el Stock'
            Dim Entidad_productos As New Entidad_Producto
            Dim Negocio_productos As New Negocio_Producto

            Dim listaProductos As New List(Of Entidad_Producto)
            'Buscamos el precio y el stock'
            listaProductos = Negocio_productos.preciostock(ListView1.Items(i).SubItems(3).Text)

            With Entidad_productos
                .stock = CType(listaProductos.Item(0).stock, Integer) - CType(ListView1.Items(i).SubItems(2).Text, Integer)
                .idproducto = ListView1.Items(i).SubItems(3).Text
            End With

            Negocio_productos.Actualiza_Stock(Entidad_productos)

        Next
        MessageBox.Show("Venta Exitosa")
        limpiar()
    End Sub

    Private Function convertirfecha_ansi(ByVal picker As DateTimePicker, ByVal picker2 As DateTimePicker) As String
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

        If picker2.Value.Hour < 10 Then
            cadena = cadena + " 0" + CStr(picker2.Value.Hour) + ":"
        Else
            cadena = cadena + " " + CStr(picker2.Value.Hour) + ":"
        End If

        If picker2.Value.Minute < 10 Then
            cadena = cadena + "0" + CStr(picker2.Value.Minute) + ":"
        Else
            cadena = cadena + CStr(picker2.Value.Minute) + ":"
        End If

        If picker2.Value.Second < 10 Then
            cadena = cadena + "0" + CStr(picker2.Value.Second)
        Else
            cadena = cadena + CStr(picker2.Value.Second)
        End If
        Return cadena
    End Function



    'Procedimiento para que se muestren todos los productos en Picturebox'
    Private Sub mostrarproducto(ByVal fin As Integer)
        Dim lista As New List(Of Entidad_Producto)
        Dim obj As New Negocio_Producto
        lista = obj.Mostrartodosproducto
        dibuja(fin, lista)
    End Sub

    'metodo para dibujar picturebox en tiempo de ejecucion'
    Private Sub dibuja(ByVal fin As Integer, ByVal lista As List(Of Entidad_Producto))

        panel.Controls.Clear() 'Eliminamos todos los controles que esten en panel'
        Dim i As Integer
        Dim j As Integer = 0
        Dim contador As Integer = 0
        ReDim txt(fin)
        ReDim lbl(fin)
        Dim constante As Integer = 160 'variable que determina el espaciado entre los picturebox'
        Dim constantex As Integer = 130

        For i = 1 To fin

            txt(i) = New PictureBox 'instanciamos los picturebox'
            lbl(i) = New Label 'iniciamos el label'

            'Picturebox'
            Me.txt(i).Size = New System.Drawing.Size(130, 130)
            Me.txt(i).Name = lista.Item(i - 1).idproducto
            Me.txt(i).SizeMode = PictureBoxSizeMode.StretchImage

            If File.Exists(My.Application.Info.DirectoryPath + "\imagenes\productos\" + lista.Item(i - 1).foto) Then 'Comprobamos que el archivo existe'
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

        Detalle_Producto.Label2.Text = listaProductos.Item(0).stock
        Detalle_Producto.Label3.Text = listaProductos.Item(0).precio
        If File.Exists(picture.ImageLocation) Then
            Detalle_Producto.PictureBox1.Load(picture.ImageLocation) 'copiamos la imagen de un picturebox a otro'
        End If
        Detalle_Producto.PictureBox1.Name = picture.Name
        Detalle_Producto.Label6.Text = picture.Text
        Detalle_Producto.Show() 'Abrimos el formulario detalle producto '



    End Sub

    'Funcion que cuenta la cantidad  de productos'
    Private Function contarproducto() As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        valor = obj.contarproductos
        Return valor
    End Function

    'Devuelve la cantidad de productos segun el nombre '
    Private Function contarproductoporfiltro(ByVal nombre As String) As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        valor = obj.contarproductosporfiltro(nombre)
        Return valor
    End Function

    'Devuelve la cantidad de productos segun su categoria '
    Private Function contarproductoporcategoria(ByVal id As Integer) As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        valor = obj.contarproductosporcategoria(id)
        Return valor
    End Function


    'funcion para colorear el listview'
    Public Sub colorearListView(ByRef list As ListView)
        Dim i As Integer

        For i = 0 To list.Items.Count - 1

            If i = Int(i / 2) * 2 Then

                list.Items.Item(i).BackColor = Color.Red

            Else

                list.Items.Item(i).BackColor = Color.Yellow
            End If

        Next

        list.FullRowSelect = True
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex >= 0 Then
            Label5.Text = ComboBox1.SelectedValue.ToString
        Else
            Label5.Text = ""
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        verifica(ComboBox2)
    End Sub

    Private Sub verifica(ByVal combo As ComboBox)
        If CheckBox1.Checked And combo.SelectedIndex >= 0 Then
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            verifica(ComboBox2)
        Else
            Dim num As Integer
            num = contarproducto()
            mostrarproducto(num)
        End If

    End Sub

    Private Sub limpiar()
        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = ""
        rbtcontado.Checked = True
        Me.ListView1.Items.Clear()
        Label4.Text = "0.00"
        Label5.Text = ""
        ComboBox2.SelectedIndex = -1
        CheckBox1.Checked = False
        TextBox2.Text = ""
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Date.Now.ToLocalTime
    End Sub

   

   
  
End Class
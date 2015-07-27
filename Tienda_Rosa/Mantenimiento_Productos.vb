Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Public Class Mantenimiento_Productos
    Dim abre As New OpenFileDialog
    Private Sub Mantenimiento_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = Principal
        Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargarcombo()
        cargarproveedores()
        cargargridview()
    End Sub

    Private Sub personalizargridview(ByVal grid As DataGridView)
        With grid
            .BackgroundColor = Color.White
            .EnableHeadersVisualStyles = False 'desactivar el estilo visual'
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .RowHeadersVisible = False
            .DefaultCellStyle.SelectionBackColor = Color.Yellow
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .AllowUserToResizeRows = False
        End With
    End Sub

    'Para Cargar el Gridview'
    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Producto)
        Dim obj As New Negocio_Producto
        lista = obj.Mostrartodosproducto
        DataGridView1.DataSource = lista
        If DataGridView1.RowCount > 0 Then 'cuando no haya nada en la base de datos'
            Label9.Text = CStr(Me.DataGridView1(0, DataGridView1.RowCount - 1).Value + 1)
        ElseIf DataGridView1.RowCount = 0 Then
            Label9.Text = 1
        End If
    End Sub

    'Para Cargar Al Combobox'
    Private Sub cargarcombo()
        Dim lista As New List(Of Entidad_Categoria)
        Dim obj As New Negocio_Categoria
        lista = obj.Mostrarcategoria
        ComboBox1.DataSource = lista
        ComboBox1.DisplayMember = "nombre"
        ComboBox1.ValueMember = "idcategoria"
        ComboBox1.SelectedIndex = -1
    End Sub
    'para cargar proveedores'
    Private Sub cargarproveedores()
        Dim lista As New List(Of Entidad_Proveedor)
        Dim obj As New Negocio_Proveedor
        lista = obj.Mostrartodosproveedor
        ComboBox2.DataSource = lista
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "idproveedor"
        ComboBox2.SelectedIndex = -1
    End Sub

    'Para Buscar El producto'
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Producto)
        Dim obj As New Negocio_Producto
        lista = obj.buscartodoproducto(TextBox1.Text)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        Label8.Text = Me.DataGridView1(0, fila).Value.ToString()
        TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString()
        NumericUpDown1.Text = Me.DataGridView1(3, fila).Value.ToString()
        NumericUpDown2.Text = Me.DataGridView1(4, fila).Value.ToString()
        If File.Exists(Application.StartupPath + "\imagenes\productos\" + Me.DataGridView1(5, fila).Value.ToString()) Then
            PictureBox1.Load(Application.StartupPath + "\imagenes\productos\" + Me.DataGridView1(5, fila).Value.ToString())
        End If
        buscarencombo(ComboBox2, Me.DataGridView1(6, fila).Value.ToString())
        buscarencombo(ComboBox1, Me.DataGridView1(2, fila).Value.ToString())
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Nuevo" Then
            Button1.Text = "Guardar"
            habilitar_deshabitar(False)
            limpiarcajas()
            Label8.Text = Label9.Text
        ElseIf Button1.Text = "Guardar" Then
            Button1.Text = "Nuevo"
            If ComboBox1.SelectedIndex < 0 Then
                MessageBox.Show("Debe de seleccionar una categoria")
                ComboBox1.Focus()
                Exit Sub
            End If

            If ComboBox2.SelectedIndex < 0 Then
                ComboBox2.Focus()
                MessageBox.Show("debe seleccionar un proveedor")
                Exit Sub
            End If
            nuevo_producto()
            habilitar_deshabitar(True)
            cargargridview()
        End If
    End Sub

    'Metodo para agregar un nuevo producto'
    Private Sub nuevo_producto()
        'Agregar producto
        Dim Entidad As New Entidad_Producto
        Dim Negocio As New Negocio_Producto

        With Entidad
            .nombre = TextBox2.Text
            .idcategoria = ComboBox1.SelectedValue
            .precio = NumericUpDown1.Value
            .stock = NumericUpDown2.Value
            .idproveedor = ComboBox2.SelectedValue
            .foto = IIf(abre.FileName = "", "nd.jpg", Label8.Text + ".jpg")
        End With
        'llamamos a agregar producto'
        Negocio.Agregar_Producto(Entidad)
        redimensionarfotoyguardar()
    End Sub

    Private Sub habilitar_deshabitar(ByVal bol As Boolean)
        Button2.Enabled = bol
        DataGridView1.Enabled = bol
        Button3.Enabled = bol
        TextBox1.Enabled = bol

    End Sub

   

    Private Sub limpiarcajas()
        Label8.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        NumericUpDown1.Value = 0
        NumericUpDown2.Value = 0
        TextBox1.Text = ""
        PictureBox1.Image = Nothing
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub abriropen()
        'Si en el diseño no hemos añadido el Openfiledialog pondremos esto sin el apostrofe al principio:

        abre.Title = "Seleccione su Imagen" 'Título de la ventana que se abrirá para seleccionar el archivo.
        abre.Filter = "Jpg|*.jpg|Png|*.png|Gif|*.gif|Todos los archivos|*.*" 'Tipo de extensiones soportadas, fijaros como en la primera parte se pone el nombre, el que se quiera, después ponemos una barra vertical a modo de separación y ponemos *."extensión", el asterisco significa que nos permitirá cualquier nombre de archivo, la extensión hay que ponerla IGUAL que las que queramos abrir, lo de todos los archivos es opcional..
        abre.FilterIndex = 0 'Elegimos que se quede por defecto la primera extensión a la vista.
        abre.InitialDirectory = "C:\Documents and Settings\" & My.User.Name & "\Escritorio" 'Con esto haremos que el directorio inicial sea nuestro escritorio, podemos modificarlo a nuestro antojo si quisieramos abrirlo en mis documentos o en algún otro lugar lo ponemos y ya está.
        abre.RestoreDirectory = True 'De esta forma, mientras no cerremos la aplicación se "guardará" el último directorio seleccionado para no tener que elegirlo cada vez.
        abre.FileName = "" 'Con esto hacemos que al abrir la ventana no haya un nombre escrito, de la manera contraria en la ventana ya pondria "abre", además que esto nos viene bien para otra cosa que explicaré luego.

        If abre.ShowDialog() = Windows.Forms.DialogResult.OK Then 'Si pulsamos aceptar en la ventanita.
            PictureBox1.ImageLocation = abre.FileName 'La ruta de la imagen que contiene el picturebox es el nombre de archivo del OpenFileDialog.
        End If
    End Sub

    'metodo que redimensiona la foto y la guarda en la aplicacion'

    Private Sub redimensionarfotoyguardar()
        Dim imagenOriginal As Bitmap
        Dim imagenRedimensionada As Bitmap
        If abre.FileName <> "" Then
            imagenOriginal = New Bitmap(abre.FileName)

            'creamos una imagen con las dimensiones que se desean 
            'en este caso la creamos de 300x300 pixels 
            imagenRedimensionada = New Bitmap(300, 300)

            'creamos un objeto graphics desde la nueva imagen 
            Using gr As Graphics = Graphics.FromImage(imagenRedimensionada)

                'en la nueva imagen "pintamos" la antigua imagen con las dimensiones de la nueva imagen 
                gr.DrawImage(imagenOriginal, 0, 0, imagenRedimensionada.Width, imagenRedimensionada.Height)

            End Using

            'se guarda la nueva imagen 
            imagenRedimensionada.Save(Application.StartupPath + "\imagenes\productos\" + Label8.Text + ".jpg")
            imagenRedimensionada.Dispose()
        End If
    End Sub
 
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        abriropen()
    End Sub

    Private Sub buscarencombo(ByVal combo As ComboBox, ByVal cad As String)
        Dim i As Integer
        Dim bol = False
        While i <= combo.Items.Count - 1 And bol = False
            combo.SelectedIndex = i
            If combo.SelectedValue.ToString = cad Then
                combo.SelectedIndex = i
                bol = True
            End If
            i += 1
        End While
      

    End Sub

    'Para modificar un producto'
    Private Sub modificar()
        'modificar producto
        Dim Entidad As New Entidad_Producto
        Dim Negocio As New Negocio_Producto

        With Entidad
            .nombre = TextBox2.Text
            .idcategoria = ComboBox1.SelectedValue
            .precio = NumericUpDown1.Value
            .stock = NumericUpDown2.Value
            .idproveedor = ComboBox2.SelectedValue
            .foto = IIf(devolvercadena() = "nd.jpg", "nd.jpg", Label8.Text + ".jpg")
            .idproducto = Label8.Text
        End With
        'llamamos a agregar producto'
        Negocio.modificar_Producto(Entidad)
        redimensionarfotoyguardar()
    End Sub
   
   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        modificar()
        cargargridview()
    End Sub

 
    'funcion para devolver cadena'
    Private Function devolvercadena() As String
        Dim entero As Integer = 0
        Dim cadena1 As String = ""
        If File.Exists(PictureBox1.ImageLocation) Then
            entero = InStr(PictureBox1.ImageLocation, "nd.jpg")
            If entero <> 0 Then
                cadena1 = Mid(PictureBox1.ImageLocation, entero, PictureBox1.ImageLocation.Length)
            End If
        End If
        
        Return cadena1
    End Function
End Class
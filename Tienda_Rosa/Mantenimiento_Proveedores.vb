Imports Capa_Entidad
Imports Capa_Negocio
Public Class Mantenimiento_Proveedores


    Private Sub Mantenimiento_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.ForeColor = Color.Black
        personalizargridview(Me.DataGridView1)
        DataGridView1.AutoGenerateColumns = False
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

    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Proveedor)
        Dim obj As New Negocio_Proveedor
        lista = obj.Mostrartodosproveedor
        DataGridView1.DataSource = lista
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        Label3.Text = Me.DataGridView1(0, fila).Value.ToString()
        TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString()
        TextBox3.Text = Me.DataGridView1(2, fila).Value.ToString()
        TextBox4.Text = Me.DataGridView1(3, fila).Value.ToString()
        TextBox5.Text = Me.DataGridView1(4, fila).Value.ToString()
        TextBox6.Text = Me.DataGridView1(5, fila).Value.ToString

    End Sub

    Private Sub nuevo_proveedor()
        'Agregar proveedor
        Dim Entidad As New Entidad_Proveedor
        Dim Negocio As New Negocio_Proveedor

        With Entidad
            .nombre = TextBox2.Text
            .Ruc = TextBox3.Text
            .representante = TextBox4.Text
            .direccion = TextBox5.Text
            .telefono = TextBox6.Text
        End With
        'llamamos a agregar Proveedor'
        Negocio.Nuevo_Proveedor(Entidad)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Nuevo" Then
            Button1.Text = "Guardar"
            limpiar()
            deshabilitar()
        ElseIf Button1.Text = "Guardar" Then
            Button1.Text = "Nuevo"
            habilitar()
            nuevo_proveedor()
            cargargridview()
        End If

    End Sub

    Private Sub limpiar()
        Label3.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub

    Private Sub deshabilitar()
        Button2.Enabled = False
        Button3.Enabled = False
        DataGridView1.Enabled = False
        TextBox1.Enabled = False
    End Sub

    Private Sub habilitar()
        Button2.Enabled = True
        Button3.Enabled = True
        DataGridView1.Enabled = True
        TextBox1.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        modificar_proveedor()
        cargargridview()
    End Sub

    Private Sub modificar_proveedor()
        'modificar proveedor
        Dim Entidad As New Entidad_Proveedor
        Dim Negocio As New Negocio_Proveedor

        With Entidad
            .idproveedor = Label3.Text
            .nombre = TextBox2.Text
            .Ruc = TextBox3.Text
            .representante = TextBox4.Text
            .direccion = TextBox5.Text
            .telefono = TextBox6.Text
        End With
        'llamamos a agregar Proveedor'
        Negocio.Modificar_Proveedor(Entidad)
    End Sub
End Class
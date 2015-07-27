Imports Capa_Entidad
Imports Capa_Negocio
Public Class Mantenimiento_Clientes

    Private Sub Mantenimiento_Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
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
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.Mostrartodocliente
        DataGridView1.DataSource = lista
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        Label3.Text = Me.DataGridView1(0, fila).Value.ToString()
        TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString()
        TextBox3.Text = Me.DataGridView1(2, fila).Value.ToString()
        TextBox4.Text = Me.DataGridView1(3, fila).Value.ToString()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Nuevo" Then
            Button1.Text = "Guardar"
            habilitar_deshabilitar(False)
            limpiar()

        Else
            Button1.Text = "Nuevo"
            habilitar_deshabilitar(True)
            nuevo_cliente()
            cargargridview()
        End If
    End Sub

    Private Sub habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
        TextBox1.Enabled = bol
        Button2.Enabled = bol
        Button3.Enabled = bol
    End Sub

    Private Sub limpiar()
        Label3.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub nuevo_cliente()
        'Agregar cliente
        Dim Entidad As New Entidad_Cliente
        Dim Negocio As New Negocio_Cliente

        With Entidad
            .nombre = TextBox2.Text
            .apellidos = TextBox3.Text
            .telefono = TextBox4.Text
        End With
        'llamamos a agregar cliente'
        Negocio.Nuevo_cliente(Entidad)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        modificar_cliente()
        cargargridview()
    End Sub

    Private Sub modificar_cliente()
        'modificar cliente
        Dim Entidad As New Entidad_Cliente
        Dim Negocio As New Negocio_Cliente

        With Entidad
            .nombre = TextBox2.Text
            .apellidos = TextBox3.Text
            .telefono = TextBox4.Text
            .idcliente = Label3.Text
        End With
        'llamamos a modificar cliente'
        Negocio.modificar_cliente(Entidad)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.buscacliente(Me.TextBox1.Text)
        DataGridView1.DataSource = lista
        
    End Sub
End Class

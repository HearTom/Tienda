Imports Capa_Entidad
Imports Capa_Negocio
Public Class Mantenimiento_Categoria

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        modificar_categoria()
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

    Private Sub modificar_categoria()
        Dim Entidad As New Entidad_Categoria
        Dim Negocio As New Negocio_Categoria
        With Entidad
            .nombre = TextBox2.Text
            .descripcion = TextBox3.Text
            .idcategoria = Label3.Text
        End With

        Negocio.Modificar_categoria(Entidad)
    End Sub
    'Nueva Categoria'
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Nuevo" Then
            Button1.Text = "Guardar"
            limpiar()
            Habilitar_deshabilitar(False)
        ElseIf Button1.Text = "Guardar" Then
            Habilitar_deshabilitar(True)
            agregar_categoria()
            cargargridview()
        End If
    End Sub

    Private Sub agregar_categoria()
        Dim Entidad As New Entidad_Categoria
        Dim Negocio As New Negocio_Categoria
        With Entidad
            .nombre = TextBox2.Text
            .descripcion = TextBox3.Text
        End With

        Negocio.Nueva_categoria(Entidad)
    End Sub

    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Categoria)
        Dim obj As New Negocio_Categoria
        lista = obj.Mostrarcategoria
        DataGridView1.DataSource = lista
    End Sub

    Private Sub limpiar()
        Label3.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
        Button2.Enabled = bol
        Button3.Enabled = bol
        TextBox1.Enabled = bol
    End Sub

    

    Private Sub Mantenimiento_Categoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargargridview()
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        Label3.Text = Me.DataGridView1(0, fila).Value.ToString()
        TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString()
        TextBox3.Text = Me.DataGridView1(2, fila).Value.ToString()
    End Sub
End Class
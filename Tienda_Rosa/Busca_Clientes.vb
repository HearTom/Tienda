Imports Capa_Entidad
Imports Capa_Negocio
Imports System.Collections.Generic

Public Class Busca_Clientes

   

    Private Sub Busca_Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'DataGridView1.AutoGenerateColumns = False
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.Mostrarcliente
        'establece que es un formulario hijo de principal
        ListBox1.DataSource = lista
        ListBox1.DisplayMember = "nomyap"
        ListBox1.ValueMember = "idcliente"

        If Me.Text = "Ventas" Then
            Try
                Me.StartPosition = FormStartPosition.Manual
                Me.Location = New System.Drawing.Point(500, 12)
            Catch ex As Exception

            End Try
        ElseIf Me.Text = "Pagos" Then
            Try
             
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.buscacliente(Me.TextBox1.Text)
        ListBox1.DataSource = lista
        ListBox1.DisplayMember = "nomyap"
        ListBox1.ValueMember = "idcliente"

    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        'Dim fila As Integer
        'Dim nombre As String
        'Dim columna As Integer
        'fila = DataGridView1.CurrentCell.RowIndex
        'nombre = Me.DataGridView1(0, fila).Value.ToString()
        'columna = DataGridView1.CurrentCell.ColumnIndex
        If Me.Text = "Ventas" Then
            Try
                Venta.Label5.Text = ListBox1.SelectedValue.ToString
                Venta.ComboBox1.Text = ListBox1.Text

            Catch ex As Exception

            End Try
        ElseIf Me.Text = "Pagos" Then
            Try
                Pagos.Label3.Text = ListBox1.SelectedValue.ToString
                Pagos.ComboBox1.Text = ListBox1.Text
            Catch ex As Exception

            End Try
        End If

       


        Me.Close()
    End Sub

End Class
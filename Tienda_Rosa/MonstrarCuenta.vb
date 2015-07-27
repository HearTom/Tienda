Imports Capa_Entidad
Imports Capa_Negocio
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Public Class MonstrarCuenta
    Dim report As New ReportDocument
    Dim parametro As New ParameterDiscreteValue

    Private Sub MonstrarCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarcombo(ComboBox1)
    End Sub

    Public Sub mostrar(ByVal param As Integer)
        Dim negocias As New Negocio_reporte
        report.Load(Application.StartupPath & "\reportes\muestracuenta2.rpt")
        report.SetDataSource(negocias.reporte_cuenta(param))
        CrystalReportViewer1.ReportSource = report

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


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex >= 0 Then
            If IsNumeric(ComboBox1.SelectedValue.ToString) Then
                mostrar(CInt(ComboBox1.SelectedValue))
            End If
        End If
    End Sub

   
End Class
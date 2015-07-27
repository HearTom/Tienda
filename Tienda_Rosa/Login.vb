Imports Capa_Entidad
Imports Capa_Negocio
Public Class Login

    'Metodo para ver si existe el usuario y contraseña'
    Private Function Validar(ByVal registros As Entidad_Empleado) As Boolean
        Dim valor As Boolean
        Dim obj As New Negocio_Empleado
        valor = obj.Validar(registros)
        Return valor
    End Function

    Private Sub logearse()
        Dim autorizado As Boolean
        Dim registros As New Entidad_Empleado
        With registros
            .usuario = txtusuario.Text
            .contraseña = txtcontraseña.Text
        End With
        autorizado = Validar(registros)

        If autorizado Then
            Principal.Show()
            Principal.Text = "Usuario : " + registros.usuario
            Me.Close()
        Else
            MessageBox.Show("usuario o contraseña incorrecta")
        End If
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        logearse()
    End Sub


    Private Sub txtcontraseña_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            logearse()
        End If
    End Sub

    
End Class

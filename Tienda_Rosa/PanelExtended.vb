'Clase que hereda de la Superclase Panel'
Public Class PanelExtended
    Inherits Panel

    Public Sub New()
        MyBase.DoubleBuffered = True
    End Sub

End Class

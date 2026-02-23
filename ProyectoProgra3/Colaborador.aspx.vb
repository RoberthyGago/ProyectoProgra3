Public Class Colaborador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim persona As New Models.Colaborador()

        'validar campos obligatorios
        If TxtFechaNacimiento.Text = "" Or TxtNombre.Text = "" Then
            lblResultado.Text = "Por favor complete los campos obligatorios."
            Return
        End If

        persona.Nombre = TxtNombre.Text.Trim()
        persona.Apellidos = TxtApellidos.Text.Trim()
        persona.FechaNacimiento = CDate(TxtFechaNacimiento.Text)
        persona.Correo = TxtCorreo.Text.Trim()
        persona.TipoDocumento = DdlTipoDocumento.SelectedItem.Value
        persona.Identificacion = TxtIdentificacion.Text.Trim()
    End Sub
End Class
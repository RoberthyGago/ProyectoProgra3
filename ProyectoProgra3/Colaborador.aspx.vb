Imports ProyectoProgra3.Models

Public Class Colaborador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim colaborador As New Models.Colaborador()

        'validar campos obligatorios
        If TxtFechaNacimiento.Text = "" Or TxtNombre.Text = "" Then
            lblResultado.Text = "Por favor complete los campos obligatorios."
            Return
        End If

        colaborador.Nombre = TxtNombre.Text.Trim()
        colaborador.Apellidos = TxtApellidos.Text.Trim()
        colaborador.FechaNacimiento = CDate(TxtFechaNacimiento.Text)
        colaborador.Correo = TxtCorreo.Text.Trim()
        colaborador.TipoDocumento = DdlTipoDocumento.SelectedItem.Value
        colaborador.Identificacion = TxtIdentificacion.Text.Trim()

        lblResultado.Text = colaborador.Resumen()
    End Sub
End Class
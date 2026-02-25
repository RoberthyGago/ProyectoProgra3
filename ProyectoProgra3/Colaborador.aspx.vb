
Imports ProyectoProgra3.Models
Imports ProyectoProgra3.Utils

Public Class Colaborador
    Inherits System.Web.UI.Page
    Private db As New ColaboradorDB()
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
        colaborador.FechaNacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text.Trim())
        colaborador.Correo = TxtCorreo.Text.Trim()
        colaborador.TipoDocumento = DdlTipoDocumento.SelectedItem.Value
        colaborador.Identificacion = TxtIdentificacion.Text.Trim()

        Dim errorMessage As String = ""
        lblResultado.Text = colaborador.Resumen()
        Dim resultado = db.CrearColaborador(colaborador, errorMessage)


        If resultado Then
            gvColaborador.DataBind()
            SwalUtils.ShowSwal(Me, "Colaborador creado exitosamente")
        Else
            'SwalUtils.ShowSwalError(Me, "Error al crear el Colaborador")
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If

    End Sub
End Class
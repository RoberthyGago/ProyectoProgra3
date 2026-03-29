'code -behind para la página de Colaborador, maneja la lógica de creación de un nuevo colaborador y la interacción con la base de datos a través del modelo ColaboradorDB.

Imports ProyectoProgra3.Utils


Public Class Colaborador
    Inherits System.Web.UI.Page
    Private db As New ColaboradorDB()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs)
        Dim colaborador As New Models.Colaborador()

        'validar campos obligatorios
        If TxtFechaNacimiento.Text = "" Or TxtNombre.Text = "" Then
            'lblResultado.Text = "Por favor complete los campos obligatorios."
            Return
        End If

        colaborador.Nombre = TxtNombre.Text.Trim()
        colaborador.Apellidos = TxtApellidos.Text.Trim()
        colaborador.FechaNacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text.Trim())
        colaborador.Correo = TxtCorreo.Text.Trim()
        colaborador.TipoDocumento = DdlTipoDocumento.SelectedItem.Value
        colaborador.Identificacion = TxtIdentificacion.Text.Trim()

        Dim errorMessage As String = ""
        'l'blResultado.Text = colaborador.Resumen
        'Dim resultado As Boolean
        Dim resultado = db.CrearColaborador(colaborador, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Colaborador creado exitosamente")
            gvColaborador.DataBind() 'actualizamos el GridView para mostrar el nuevo colaborador
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

    Protected Sub gvColaborador_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        e.Cancel = True 'cancelamos el evento de eliminación predeterminado del GridView
        Dim id As Integer = Convert.ToInt32(gvColaborador.DataKeys(e.RowIndex).Value) 'obtenemos el ID de la persona a eliminar  dispar el evento de eliminación personalizado  
        Dim errorMessage As String = ""
        Dim resultado = db.EliminarColaborador(id, errorMessage) 'eliminamos la persona de la base de datos

        If resultado Then
            SwalUtils.ShowSwal(Me, "Persona eliminada exitosamente")
            gvColaborador.DataBind()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

    'estos evento se crean cuando los hago en colaborado.aspx
    Protected Sub gvColaborador_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub gvColaborador_SelectedIndexChanged(sender As Object, e As EventArgs)
        hfID_TRABAJADOR.Value = gvColaborador.DataKeys(gvColaborador.SelectedIndex).Value
        Dim selectedRow As GridViewRow = gvColaborador.SelectedRow
        Dim id As Integer = Convert.ToInt32(gvColaborador.DataKeys(gvColaborador.SelectedIndex).Value)
        Dim errorMessage As String = ""
        Dim colaborador As Models.Colaborador = db.ConsultarColaborador(id, errorMessage)

        If colaborador Is Nothing Then
            SwalUtils.ShowSwalError(Me, If(errorMessage = "", "no se pudo cargar colaborador. ", errorMessage))
            Return
        End If

        TxtNombre.Text = colaborador.Nombre
        TxtApellidos.Text = colaborador.Apellidos
        TxtFechaNacimiento.Text = colaborador.FechaNacimiento.ToString("yyyy-MM-dd") 'formatear la fecha para el control de fecha
        TxtIdentificacion.Text = colaborador.Identificacion
        DdlTipoDocumento.SelectedValue = colaborador.TipoDocumento
        TxtCorreo.Text = colaborador.Correo

        btnGuardar.Visible = False
        btnActualizar.Visible = True
        btnCancelar.Visible = True

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim colaborador As New Models.Colaborador()
        colaborador.ID_TRABAJADOR = Convert.ToInt32(hfID_TRABAJADOR.Value)

        'Validar campos obligatorios 
        If TxtFechaNacimiento.Text = "" Then
            'lblResultado.Text = "Por favor, complete todos los campos obligatorios."
            Return
        End If

        colaborador.Nombre = TxtNombre.Text.Trim()
        colaborador.Apellidos = TxtApellidos.Text.Trim()
        colaborador.FechaNacimiento = TxtFechaNacimiento.Text.Trim()
        colaborador.Correo = TxtCorreo.Text.Trim()
        colaborador.TipoDocumento = DdlTipoDocumento.SelectedItem.Value
        colaborador.Identificacion = TxtIdentificacion.Text.Trim()

        'lblResultado.Text = colaborador.Resumen()
        Dim errorMessage As String = ""
        Dim resultado = db.ActualizarCOLABORADOR(colaborador, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Colaborador actualizado exitosamente.")
            gvColaborador.DataBind()
            btnGuardar.Visible = True
            btnActualizar.Visible = False
            hfID_TRABAJADOR.Value = ""
            LimpiarCampos()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

    Private Sub LimpiarCampos()
        TxtNombre.Text = ""
        TxtApellidos.Text = ""
        TxtFechaNacimiento.Text = ""
        TxtIdentificacion.Text = ""
        DdlTipoDocumento.SelectedIndex = 0
        TxtCorreo.Text = ""
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        'limpiar campos y resetear el formulario
        TxtNombre.Text = ""
        TxtApellidos.Text = ""
        TxtFechaNacimiento.Text = ""
        TxtCorreo.Text = ""
        TxtIdentificacion.Text = ""
        DdlTipoDocumento.SelectedIndex = 0

        btnGuardar.Visible = True
        btnActualizar.Visible = False
        btnCancelar.Visible = False



    End Sub
End Class
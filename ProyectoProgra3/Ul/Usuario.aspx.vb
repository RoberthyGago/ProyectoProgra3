Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports ProyectoProgra3.Models
Imports ProyectoProgra3.Utils

Public Class Usuario
    Inherits System.Web.UI.Page
    Private db As New UsuarioDB()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
        End If
    End Sub

    Private Sub CargarPersonas()
        Dim errorMessage As String = ""
        gvUsuarios.DataSource = db.CargarPersonas(errorMessage)
        gvUsuarios.DataBind()
    End Sub

    Protected Sub gvUsuarios_RowCommand(sender As Object, e As GridViewCommandEventArgs)

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim usuario As New Models.Usuarios()
        If txtIdPersona.Text = "" Or txtUsername.Text = "" Or txtPassword.Text = "" Or ddlRol.SelectedValue = "" Then
            SwalUtils.ShowSwalError(Me, "Por favor, complete todos los campos obligatorios.")
            Return
        End If
        usuario.IdPersona = Convert.ToInt32(txtIdPersona.Text.Trim())
        usuario.Username = txtUsername.Text.Trim()
        usuario.PasswordHash = HashPassword(txtPassword.Text.Trim())
        usuario.Rol = ddlRol.SelectedValue
        usuario.Activo = chkActivo.Checked

        Dim errorMessage As String = ""
        Dim resultado = db.CrearUsuario(usuario, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Usuario creado exitosamente.")
            CargarPersonas()

        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If


    End Sub

    Private Function HashPassword(password As String) As Object
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Return Convert.ToBase64String(bytes)
        End Using
    End Function
End Class
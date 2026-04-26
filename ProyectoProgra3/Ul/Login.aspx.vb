Imports ProyectoProgra3.Utils
Imports ProyectoProgra3.Models

Public Class Login
    Inherits System.Web.UI.Page

    Private dbUsuario As New UsuarioDB()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim errorMessage As String

        Dim encryptor As New Simple3Des("frase$-secreta-123")
        Dim PasswordHash = encryptor.EncryptData(txtPass.Text)

        Dim result = dbUsuario.Login(txtUsername.Text, PasswordHash, errorMessage)

        If result.Rows.Count = 0 Then
            SwalUtils.ShowSwalError(Me, "Error de Login", errorMessage)
        Else
            Dim user = result.Rows(0)
            Session("User") = user("Username")
            Session("Rol") = user("Rol")

            ' 👉 REDIRECCIÓN AQUÍ
            Response.Redirect("~/Colaborador.aspx", False)
        End If
    End Sub
End Class
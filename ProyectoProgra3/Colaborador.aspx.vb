Public Class Colaborador
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Lógica de carga
    End Sub

    ' Este debe coincidir con OnClick="btnGuardar_Click"
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        ' Tu lógica para guardar
    End Sub

    ' Este debe coincidir con OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged"
    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Lógica para cuando tocas el lápiz (Select)
    End Sub

    ' Este debe coincidir con OnRowEditing="gvPersonas_RowEditing"
    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)
        ' Lógica para editar
    End Sub

    ' Este debe coincidir con OnRowDeleting="gvPersonas_RowDeleting"
    Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        ' Lógica para eliminar
    End Sub

End Class
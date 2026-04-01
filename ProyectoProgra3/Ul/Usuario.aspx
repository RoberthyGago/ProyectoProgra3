<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Usuario.aspx.vb" Inherits="ProyectoProgra3.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="form-group">
        <asp:Label ID="lblIdPersona" runat="server" Text="IdPersona" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtIdPersona" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvIdPersona" runat="server"
            ErrorMessage="Es necesario indicar el IdPersona"
            ControlToValidate="txtIdPersona" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
            ErrorMessage="Es necesario indicar el Username"
            ControlToValidate="txtUsername" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
            ErrorMessage="Es necesario indicar el Password"
            ControlToValidate="txtPassword" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label ID="lblRol" runat="server" Text="Definir Rol" CssClass="control-label"></asp:Label>
        <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control">
            <asp:ListItem Text="Rol" Value="" />
            <asp:ListItem Text="Administrador" Value="admin" />
            <asp:ListItem Text="Usuario" Value="user" />

        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvRol" runat="server"
            ErrorMessage="Es necesario seleccionar un rol"
            ControlToValidate="ddlRol" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label ID="lblActivo" runat="server" Text="Activo" CssClass="control-label"></asp:Label>
        <asp:CheckBox ID="chkActivo" runat="server"></asp:CheckBox>
    </div>

    <div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-warning" Visible="false" />
    </div>


    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPersona" OnRowCommand="gvUsuarios_RowCommand" CssClass="table">
        <Columns>
            <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" ReadOnly="True" SortExpression="IdPersona" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="PasswordHash" HeaderText="PasswordHash" SortExpression="PasswordHash" />
            <asp:BoundField DataField="Rol" HeaderText="Rol" SortExpression="Rol" />
            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" SortExpression="Activo" />
        </Columns>
    </asp:GridView>
</asp:Content>

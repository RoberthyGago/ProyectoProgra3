 <%--'etiqueta con la que se configura el aspx--%>
<%@ Page Title="Colaborador" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Colaborador.aspx.vb" Inherits="ProyectoProgra3.Colaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="btn btn-primary" />

<asp:DropDownList ID="DdlTipoDocumento" runat="server"></asp:DropDownList>

<div class="form-group">
    <asp:Label ID="Label1" runat="server" Text="Nombre" CssClass="control-label" ></asp:Label>/>
    <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
</div>

<asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" />

<asp:TextBox ID="TextPrimerApellido" runat="server"></asp:TextBox>
<asp:TextBox ID="TextSegundoApellido" runat="server"></asp:TextBox>


</asp:Content>

<%@ Page Title="Colaborador" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Colaborador.aspx.vb" Inherits="ProyectoProgra3.Colaborador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Tipo Documento" CssClass="control-label"></asp:Label>
        <asp:DropDownList ID="DdlTipoDocumento" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione un tipo de documento" Value="" />
            <asp:ListItem Text="Cédula Fisica" Value="1"></asp:ListItem>
            <asp:ListItem Text="Cédula Jurídica" Value="2" />
            <asp:ListItem Text="Pasaporte" Value="3" />
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label ID="Label6" runat="server" Text="Identificación" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Nombre" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="Apellidos" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Fecha Nacimiento" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Correo" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtCorreo" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
    </div>

    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary my-2" OnClick="BtnGuardar_Click"  />

    <asp:Label ID="lblResultado" runat="server" Text="" CssClass="control-label"></asp:Label>
</asp:Content>

<%@ Page Title="Colaborador" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Colaborador.aspx.vb" Inherits="ProyectoProgra3.Colaborador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hfID_TRABAJADOR" runat="server" />
    <div class="form-group">
        <asp:Label ID="LblTipoDoc" runat="server" Text="Tipo Documento" CssClass="control-label"></asp:Label>
        <asp:DropDownList ID="DdlTipoDocumento" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione un tipo de documento" Value="" />
            <asp:ListItem Text="Cédula Fisica" Value="1"></asp:ListItem>
            <asp:ListItem Text="Cédula Jurídica" Value="2" />
            <asp:ListItem Text="Pasaporte" Value="3" />
        </asp:DropDownList>
    </div>

    <%--Validacion de Tipo documento--%>
    <%--Tiene prioridad sobre el botón--%>
    <asp:RequiredFieldValidator ID="rfvTipoDocumento" runat="server"
        ErrorMessage="Es necesario seleccionar un tipo de documento"
        ControlToValidate="DdlTipoDocumento" Display="Dynamic"></asp:RequiredFieldValidator>

    <div class="form-group">
        <asp:Label ID="LblIdentificacion" runat="server" Text="Identificación" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvIdentificacion" runat="server"
        ErrorMessage="Es necesario indicar la identificación"
        ControlToValidate="TxtIdentificacion" Display="Dynamic"></asp:RequiredFieldValidator>


    <div class="form-group">
        <asp:Label ID="LblNombre" runat="server" Text="Nombre" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
        ErrorMessage="Es necesario indicar el nombre"
        ControlToValidate="TxtNombre" Display="Dynamic"></asp:RequiredFieldValidator>


    <div class="form-group">
        <asp:Label ID="LblApellidos" runat="server" Text="Apellidos" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvApellidos" runat="server"
        ErrorMessage="Es necesario indicar los apellidos"
        ControlToValidate="TxtApellidos" Display="Dynamic"></asp:RequiredFieldValidator>


    <div class="form-group">
        <asp:Label ID="LblFechaNacimiento" runat="server" Text="Fecha Nacimiento" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server"
        ErrorMessage="Es necesario indicar la fecha de nacimiento"
        ControlToValidate="TxtFechaNacimiento" Display="Dynamic"></asp:RequiredFieldValidator>


    <div class="form-group">
        <asp:Label ID="LblCorreo" runat="server" Text="Correo" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtCorreo" runat="server" autocomplete="email" placeholder="nombre@empresa.com" CssClass="form-control" TextMode="Email"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server"
        ErrorMessage="Es necesario indicar el correo"
        ControlToValidate="TxtCorreo" Display="Dynamic"></asp:RequiredFieldValidator>



    <div class="py-3 d-flex gap-2">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" Visible="false" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-warning" OnClick="btnActualizar_Click" visible="false" />
    </div>

    <asp:Label ID="lblResultado" runat="server" Text="" CssClass="control-label"></asp:Label>



    <%--creo eventos nuevos gridview--%>
    <asp:GridView ID="gvColaborador" CssClass="table table-striped table-hover"
        runat="server" AutoGenerateColumns="False" DataKeyNames="ID_TRABAJADOR" DataSourceID="ProyectoProgra3"
        OnRowEditing="gvColaborador_RowEditing"
        OnSelectedIndexChanged="gvColaborador_SelectedIndexChanged"
        OnRowDeleting="gvColaborador_RowDeleting">
        <Columns>
            <asp:BoundField DataField="ID_TRABAJADOR" HeaderText="Id Trabajador"  ControlStyle-CssClass="d-none" InsertVisible="False" visible="False" ReadOnly="True" SortExpression="ID_TRABAJADOR" />
            <asp:BoundField ControlStyle-CssClass="d-none" DataField="TipoDocumento" HeaderText="Tipo Documento" SortExpression="TipoDocumento" />
            <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE" />
            <asp:BoundField DataField="APELLIDOS" HeaderText="Apellidos" SortExpression="APELLIDOS" />
            <asp:BoundField DataField="IDENTIFICACION" HeaderText="Identificación" SortExpression="IDENTIFICACION" />
            <asp:BoundField DataField="FECHA_NACIMIENTO" HeaderText="Fecha Nacimiento" SortExpression="FECHA_NACIMIENTO" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
            <%--<asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary"  EditText="<i class='bi bi-pencil'>"/>--%>
            <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" SelectText="<i class='bi bi-pencil'>" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" DeleteText="<i class='bi bi-trash'>" />
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="ProyectoProgra3" runat="server"
        ConnectionString="<%$ ConnectionStrings:ROBERTHCAConnectionString %>"
        ProviderName="System.Data.SqlClient"
        SelectCommand="SELECT * FROM [COLABORADOR]"></asp:SqlDataSource>


</asp:Content>

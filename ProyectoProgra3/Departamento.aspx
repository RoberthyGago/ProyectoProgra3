<%@ Page Title="Departamento" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Departamento.aspx.vb" Inherits="ProyectoProgra3.DEPARTAMENTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:Label ID="LblNombre_Departamento" runat="server" Text="Nombre Departamento" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtNombre_Departamento" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="rfvNombre_Departamento" runat="server"
        ErrorMessage="Es necesario indicar el nombre del departamento"
        ControlToValidate="TxtNombre_Departamento" Display="Dynamic"></asp:RequiredFieldValidator>

    <div class="form-group">
    <asp:Label ID="LblSalario" runat="server" Text="Salario Base" CssClass="control-label"></asp:Label>
    <asp:TextBox ID="TxtSalario" runat="server" CssClass="form-control"></asp:TextBox>
    </div>


    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardar_Click" />

    <asp:GridView ID="GridView1" CssClass="table table-striped table-hover" runat ="server"
        DataSourceID="ProyectoProgra3"
        AutoGenerateColumns="True">
    </asp:GridView>

    <asp:SqlDataSource ID="ProyectoProgra3" runat="server"
    ConnectionString="<%$ ConnectionStrings:ROBERTHCAConnectionString %>"
    ProviderName="System.Data.SqlClient"
    SelectCommand="SELECT * FROM DEPARTAMENTO"
    InsertCommand="INSERT INTO DEPARTAMENTO (NOMBRE_DEPARTAMENTO, SALARIO_BASE) VALUES (@Nombre, @Salario)">
    
    <InsertParameters>
        <asp:ControlParameter Name="Nombre" ControlID="TxtNombre_Departamento" PropertyName="Text" />
        <asp:ControlParameter Name="Salario" ControlID="TxtSalario" PropertyName="Text" />
    </InsertParameters>

</asp:SqlDataSource>


</asp:Content>

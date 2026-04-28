<%@ Page Title="Planillas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Planillas.aspx.vb" Inherits="ProyectoProgra3.Planillas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Selección de colaborador desde SQL -->
    <div class="form-group">
        <asp:Label ID="LblColaborador" runat="server" Text="Colaborador" CssClass="control-label"></asp:Label>
        <asp:DropDownList ID="ddlColaboradores" runat="server" CssClass="form-select"
            DataTextField="NombreCompleto" DataValueField="ID_TRABAJADOR">
        </asp:DropDownList>
    </div>



    <!-- Horas extras -->
    <asp:Label ID="LblHoras" runat="server" Text="Horas Extras" CssClass="control-label"></asp:Label>
    <asp:TextBox ID="TxthorasExtras" runat="server" CssClass="form-control" Placeholder=""></asp:TextBox>

    <!-- Botón procesar -->
    <asp:Button ID="BtnProcesarPlanilla" runat="server" Text="Procesar Planilla" CssClass="btn btn-primary my-2" OnClick="BtnProcesarPlanilla_Click" />

    <!-- GridView para mostrar deducciones -->
    <asp:GridView ID="gvDeducciones" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
            <asp:BoundField DataField="Monto" HeaderText="Monto" />
        </Columns>
    </asp:GridView>

    <!-- Resultados 
    <asp:TextBox ID="Txtsalario_bruto" runat="server" CssClass="form-control" ReadOnly="true" />
    <asp:TextBox ID="Txtdeducciones" runat="server" CssClass="form-control" ReadOnly="true" />
    <asp:TextBox ID="Txtsalario_neto" runat="server" CssClass="form-control" ReadOnly="true" />
    <asp:TextBox ID="TxtPrueba" runat="server" CssClass="form-control" ReadOnly="true" />-->

</asp:Content>

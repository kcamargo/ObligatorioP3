<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BMAlojamiento.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web12" %>

<asp:Content ID="BajaAlojamiento" ContentPlaceHolderID="MainContent" runat="server">
    <div id="titulo" class="col-lg-10">
        <h1>Eliminar alojamiento</h1>
    </div>
    <div class="col-lg-10">
        <asp:Label ID="labelSeleccionarAlojamiento" runat="server" Text="Seleccione el Alojamiento a eliminar/modificar"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    </div>
    <div class="col-lg-10">
        <asp:Label ID="labelTipoAlojamientoBM" runat="server" Text="Tipo de Alojamiento"></asp:Label>
        <asp:DropDownList ID="ddlTipoAlojamientoBM" runat="server"></asp:DropDownList>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelTipoHabitacionBM" runat="server" Text="Tipo de Habitacion"></asp:Label>
        <asp:DropDownList ID="ddlTipoHabitacionBM" runat="server"></asp:DropDownList>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelBanoBM" runat="server" Text="Tipo de Baño"></asp:Label>
        <asp:DropDownList ID="ddlBanoBM" runat="server"></asp:DropDownList>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelCapacidadBM" runat="server" Text="Capacidad en personas"></asp:Label>
        <textarea id="TextArea1BM" cols="20" rows="2"></textarea>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelCiudadBM" runat="server" Text="Ciudad"></asp:Label>
        <asp:TextBox ID="txtboxCiudadBM" runat="server"></asp:TextBox>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelBarrioBM" runat="server" Text="Barrio"></asp:Label>
        <asp:TextBox ID="txtboxBarrioBM" runat="server"></asp:TextBox>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelServiciosBM" runat="server" Text="Servicios"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxListServiciosBM" runat="server"></asp:CheckBoxList>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Button ID="bttonEliminar" runat="server" Text="Eliminar" /><br />
        <asp:Button ID="bttonModificar" runat="server" Text="Modificar" /><br />
    </div>
    <br>
</asp:Content>

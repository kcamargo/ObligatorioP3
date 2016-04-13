<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaAnuncio.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web15" %>

<asp:Content ID="AltaAnuncio" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div id="titulo" class="col-lg-10">
            <h1>Crear una publicación</h1>
        </div>
        <div class="col-lg-10">
            <asp:Label ID="labelAlojamientoAnuncio" runat="server" Text="Seleccione el Alojamiento a publicar"></asp:Label>
            <asp:DropDownList ID="ddlTipoDeAlojamientoParaAnuncio" runat="server"></asp:DropDownList>
        </div>
        <br>
        <div class="col-lg-10">
            <asp:Label ID="labelNombreAnuncio" runat="server" Text="Nombre del anuncio"></asp:Label>
            <asp:TextBox ID="txtboxNombreAnuncio" runat="server"></asp:TextBox>
        </div>
        <br>
        <div class="col-lg-10">
            <asp:Label ID="labelDescripcionAnuncio" runat="server" Text="Descripción del anuncio"></asp:Label>
            <asp:TextBox ID="txtBoxDescripcionAnuncio" runat="server"></asp:TextBox>
        </div>
        <br>
        <div class="col-lg-10">
            <asp:Label ID="labelDireccionAnuncio1" runat="server" Text="Dirección 1"></asp:Label>
            <asp:TextBox ID="txtBoxDireAnuncio1" runat="server"></asp:TextBox>
        </div>
        <br>
        <div class="col-lg-10">
            <asp:Label ID="labelDireccionAnuncio2" runat="server" Text="Dirección 1"></asp:Label>
            <asp:TextBox ID="txtBoxDireAnuncio2" runat="server"></asp:TextBox>
        </div>
        <br>
        <div class="col-lg-10">
            <asp:Label ID="labelPrecioBaseAnuncio" runat="server" Text="Precio Base"></asp:Label>
            <asp:TextBox ID="txtBoxPrecioBaseAnuncio" runat="server"></asp:TextBox>
        </div>
        <br>
        <div class="col-lg-10">
            <asp:Label ID="labelServiciosAnuncio" runat="server" Text="Feriados Disponibles / Incremento del precio base"></asp:Label>
        </div>
        <br>
        <div class="col-lg-3">
            <asp:CheckBox ID="CheckBoxPrimerQuiEnero" runat="server" Text="Primer Quincena Enero" /><br>
            <asp:CheckBox ID="CheckBoxSegQuiEnero" runat="server" Text="Segunda Quincena Febrero"/><br>
            <asp:CheckBox ID="CheckBoxPrimerQuiFebrero" runat="server" Text="Primer Quincena Febrero"/><br>
            <asp:CheckBox ID="CheckBoxSegQuiFebrero" runat="server" Text="Segunda Quincena Febrero"/>
        </div>
        <div class="col-lg-3">
            <asp:CheckBox ID="CheckBoxCarnaval" runat="server" Text="Carnaval"/><br>
            <asp:CheckBox ID="CheckBoxSemanaTurismo" runat="server" Text="Semana de Turismo"/><br>
            <asp:CheckBox ID="CheckBoxVacInvierno" runat="server" Text="Vacaciones de invierno"/><br>
            <asp:CheckBox ID="CheckBoxVacPrimavera" runat="server" Text="Vacaciones de Primavera"/>
        </div>

        <div class="col-lg-3">
            <asp:CheckBox ID="CheckBoxOtros" runat="server" Text="Otros" /><br>
            <asp:CheckBox ID="CheckBoxAux" runat="server" />
        </div><br>
        <div class="col-lg-3">
            <asp:Button ID="bttnAgregarAnuncio" runat="server" Text="Agregar Anuncio" />
        </div>
    </div>
</asp:Content>

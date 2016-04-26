<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaAlojamiento.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web11" %>

<asp:Content ID="AltaAlojamiento" ContentPlaceHolderID="MainContent" runat="server">
    <div id="titulo" class="col-lg-10">
        <h1>Ingresar nuevo alojamiento</h1>
    </div>
         <div class="col-lg-10">
        <asp:Label ID="labelNombreAlojamiento" runat="server" Text="Nombre Alojamiento"></asp:Label>
        <asp:TextBox ID="txtBoxNombreAlojamiento" runat="server"></asp:TextBox>
    </div><br>
    <div class="col-lg-10">
        <asp:Label ID="labelTipoAlojamiento" runat="server" Text="Tipo de Alojamiento"></asp:Label>
        <asp:DropDownList ID="ddlTipoAlojamiento" runat="server"> </asp:DropDownList>
    </div><br>
    <div class="col-lg-10">
        <asp:Label ID="labelTipoHabitacion" runat="server" Text="Tipo de Habitacion"></asp:Label>
        <asp:DropDownList ID="ddlTipoHabitacion" runat="server">
            <asp:ListItem Value="privada">Privada</asp:ListItem>
            <asp:ListItem Value="compartida">Compartida</asp:ListItem>
        </asp:DropDownList>
    </div><br>
    <div class="col-lg-10">
        <asp:Label ID="labelBano" runat="server" Text="Tipo de Baño"></asp:Label>
        <asp:DropDownList ID="ddlBano" runat="server">
             <asp:ListItem Value="1">Privada</asp:ListItem>
            <asp:ListItem Value="2">Compartida</asp:ListItem>
        </asp:DropDownList>
    </div><br>
    <div class="col-lg-10">
        <asp:Label ID="labelCapacidad" runat="server" Text="Capacidad en personas"></asp:Label>
        <asp:TextBox ID="txtBoxCantidadPersonas" runat="server"></asp:TextBox>
    </div><br>
    <div class="col-lg-10">
        <asp:Label ID="labelCiudad" runat="server" Text="Ciudad"></asp:Label>
        <asp:TextBox ID="txtboxCiudad" runat="server"></asp:TextBox>
    </div><br>
    <div class="col-lg-10">
        <asp:Label ID="labelBarrio" runat="server" Text="Barrio"></asp:Label>
        <asp:TextBox ID="txtboxBarrio" runat="server"></asp:TextBox>
    </div><br>
    <div class="col-lg-10">
        <asp:Label ID="labelServicios" runat="server" Text="Servicios"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxListServicios" runat="server"></asp:CheckBoxList>
    </div><br>
        <div class="col-lg-10">
        <asp:Label ID="LblMensajes" runat="server" ></asp:Label>
    </div><br>
    <div class="col-lg-10">
        <asp:Button ID="bttonAgregar" runat="server" Text="Agregar" OnClick="bttonAgregar_Click" />
    </div><br>
</asp:Content>

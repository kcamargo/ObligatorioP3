<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BMAlojamiento.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web12" %>

<asp:Content ID="BajaAlojamiento" ContentPlaceHolderID="MainContent" runat="server">
    <div id="titulo" class="col-lg-10">
        <h1>Eliminar alojamiento</h1>
    </div>
    <div class="col-lg-10">
        <asp:GridView ID="gdvAlojamientoBM" runat="server" AutoGenerateColumns="False" OnRowDeleting="gdvAlojamientoBM_RowDeleting" OnRowEditing="gdvAlojamientoBM_RowEditing">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="TipoHabitacion" HeaderText="Tipo de Habitacion" />
                <asp:BoundField DataField="TipoBanio" HeaderText="Tipo de Baño" />
                <asp:BoundField DataField="CapacidadXPersona" HeaderText="Capacidad de Personas" />
                <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                <asp:BoundField DataField="Barrio" HeaderText="Barrio" />
                <asp:BoundField DataField="TipoAlojamiento" HeaderText="Tipo de alojamiento" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <br>
    <div>
        <asp:Label ID="mensajes" runat="server"></asp:Label>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelNombreAlojamientoBM" runat="server" Text="Nombre Alojamiento"></asp:Label>
        <asp:TextBox ID="txtBoxNombreAlojamientoBM" runat="server"></asp:TextBox>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelSeleccionarAlojamientoBM" runat="server" Text="Seleccione el Alojamiento a eliminar/modificar"></asp:Label>
        <asp:DropDownList ID="ddlTipoAlojamientoBM" runat="server"></asp:DropDownList>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelTipoHabitacionBM" runat="server" Text="Tipo de Habitacion"></asp:Label>
        <asp:DropDownList ID="ddlTipoHabitacionBM" runat="server">
            <asp:ListItem Value="privada">Privada</asp:ListItem>
            <asp:ListItem Value="compartida">Compartida</asp:ListItem>
        </asp:DropDownList>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelBanoBM" runat="server" Text="Tipo de Baño"></asp:Label>
        <asp:DropDownList ID="ddlBanoBM" runat="server">
            <asp:ListItem Value="privada">Privada</asp:ListItem>
            <asp:ListItem Value="compartida">Compartida</asp:ListItem>
        </asp:DropDownList>
    </div>
    <br>
    <div class="col-lg-10">
        <asp:Label ID="labelCapacidadBM" runat="server" Text="Capacidad en personas"></asp:Label>
        <asp:TextBox ID="txtBoxCapacidadBM" runat="server"></asp:TextBox>
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
    <div>
        <asp:Button ID="btnActualizarBM" runat="server" Text="Actualizar Alojamiento" OnClick="btnActualizarBM_Click" />
    </div>
    <br>
</asp:Content>

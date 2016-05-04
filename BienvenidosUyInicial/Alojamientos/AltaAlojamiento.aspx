<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaAlojamiento.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web11" %>

<asp:Content ID="AltaAlojamiento" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Crear un Alojamiento</h1>

    <% if (mensajes.Text != "")
        { %>
    <div class="alert alert-info">
        <asp:Label ID="mensajes" runat="server"></asp:Label>
    </div>
    <% } %>
    <div class="form-horizontal">
        <h3>Datos del anuncio</h3>

        <div class="form-group">
            <asp:Label ID="labelNombreAlojamiento" CssClass="col-sm-2 control-label" runat="server" Text="Nombre Alojamiento"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtBoxNombreAlojamiento" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelTipoAlojamiento" CssClass="col-sm-2 control-label" runat="server" Text="Tipo de Alojamiento"></asp:Label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlTipoAlojamiento" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelTipoHabitacion" CssClass="col-sm-2 control-label" runat="server" Text="Tipo de Habitacion"></asp:Label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlTipoHabitacion" CssClass="form-control" runat="server">
                    <asp:ListItem Value="privada">Privada</asp:ListItem>
                    <asp:ListItem Value="compartida">Compartida</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelBano" CssClass="col-sm-2 control-label" runat="server" Text="Tipo de Baño"></asp:Label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlBano" CssClass="form-control" runat="server">
                    <asp:ListItem Value="privada">Privada</asp:ListItem>
                    <asp:ListItem Value="compartida">Compartida</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelCapacidad" CssClass="col-sm-2 control-label" runat="server" Text="Capacidad en personas"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtBoxCantidadPersonas" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelCiudad" CssClass="col-sm-2 control-label" runat="server" Text="Ciudad"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtboxCiudad" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelBarrio" CssClass="col-sm-2 control-label" runat="server" Text="Barrio"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtboxBarrio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="labelServicios" CssClass="col-sm-2 control-label" runat="server" Text="Servicios"></asp:Label>
            <div class="col-sm-10">
                <asp:CheckBoxList ID="CheckBoxListServicios" runat="server"></asp:CheckBoxList>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-10">
                <asp:Label ID="LblMensajes" CssClass="col-sm-2 control-label" runat="server"></asp:Label>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-10">
                <asp:Button ID="bttonAgregar" runat="server" Text="Agregar" OnClick="bttonAgregar_Click" />
            </div>
        </div>

    </div>
</asp:Content>

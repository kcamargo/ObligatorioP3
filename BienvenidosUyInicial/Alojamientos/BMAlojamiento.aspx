<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BMAlojamiento.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web12" %>

<asp:Content ID="BajaAlojamiento" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">

        <h1>Administrar Alojamientos</h1>

        <% if (mensajes.Text != "") { %>
            <div class="alert alert-info">
                <asp:Label ID="mensajes" runat="server"></asp:Label>
            </div>
        <% } %>

        <asp:Repeater ID="repAlojamientos" runat="server" OnItemCommand="repAlojamientos_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped table-bordered">
                    <tr>
                        <th>Id</th>
                        <th>Nombre</th>
                        <th>Tipo de Habitación</th>
                        <th>Tipo de Baño</th>
                        <th>Capacidad</th>
                        <th>Ciudad</th>
                        <th>Barrio</th>
                        <th>Tipo de Alojamiento</th>
                        <th>Acciones</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><asp:Label runat="server" ID="Label1" text='<%# Eval("Id") %>' /></td>
                    <td><asp:Label runat="server" ID="Label2" text='<%# Eval("Nombre") %>' /></td>
                    <td><asp:Label runat="server" ID="Label3" text='<%# Eval("TipoHabitacion") %>' /></td>
                    <td><asp:Label runat="server" ID="Label4" text='<%# Eval("TipoBanio") %>' /></td>
                    <td><asp:Label runat="server" ID="Label5" text='<%# Eval("CapacidadXPersona") %>' /></td>
                    <td><asp:Label runat="server" ID="Label6" text='<%# Eval("Ciudad") %>' /></td>
                    <td><asp:Label runat="server" ID="Label7" text='<%# Eval("Barrio") %>' /></td>
                    <td><asp:Label runat="server" ID="Label8" text='<%# Eval("TipoAlojamiento") %>' /></td>
                    <td>
                        <asp:LinkButton CommandName="delete" CommandArgument=<%# Eval("Id") %> runat="server">Eliminar</asp:LinkButton>
                        <asp:LinkButton CommandName="edit" CommandArgument=<%# Eval("Id") %> runat="server">Editar</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>

        <% if(Session["modificacionAlojamientoActiva"] != null) { %>
            <h3>Modificar</h3>
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label ID="labelNombreAlojamientoBM" runat="server" Text="Nombre Alojamiento" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtBoxNombreAlojamientoBM" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="labelSeleccionarAlojamientoBM" runat="server" Text="Seleccione el Alojamiento a eliminar/modificar" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlTipoAlojamientoBM" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="labelTipoHabitacionBM" runat="server" Text="Tipo de Habitacion" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlTipoHabitacionBM" runat="server" CssClass="form-control">
                            <asp:ListItem Value="privada">Privada</asp:ListItem>
                            <asp:ListItem Value="compartida">Compartida</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="labelBanoBM" runat="server" Text="Tipo de Baño" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlBanoBM" runat="server" CssClass="form-control">
                            <asp:ListItem Value="privada">Privada</asp:ListItem>
                            <asp:ListItem Value="compartida">Compartida</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="labelCapacidadBM" runat="server" Text="Capacidad en personas" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtBoxCapacidadBM" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="labelCiudadBM" runat="server" Text="Ciudad" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtboxCiudadBM" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="labelBarrioBM" runat="server" Text="Barrio" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtboxBarrioBM" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="label9" runat="server" Text="Servicios" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <div class="checkbox">
                            <asp:CheckBoxList ID="CheckBoxListServiciosBM" runat="server"></asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnActualizarBM" runat="server" Text="Actualizar Alojamiento" OnClick="btnActualizarBM_Click" CssClass="btn btn-default"/>
                    </div>
                </div>
            </div>
        <% } %>
</asp:Content>

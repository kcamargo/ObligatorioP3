<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaAnuncio.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web15" %>

<asp:Content ID="AltaAnuncio" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Crear una publicación</h1>

    <% if (mensajes.Text != "") { %>
            <div class="alert alert-info">
                <asp:Label ID="mensajes" runat="server"></asp:Label>
            </div>
        <% } %>

    <div class="form-horizontal">
        <h2>Datos del anuncio</h2>
        
        <div class="form-group">
            <asp:Label ID="labelAlojamientoAnuncio" CssClass="col-sm-2 control-label" runat="server" Text="Seleccione el Alojamiento a publicar"></asp:Label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlTipoDeAlojamientoParaAnuncio" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label ID="labelNombreAnuncio" CssClass="col-sm-2 control-label" runat="server" Text="Nombre del anuncio"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtboxNombreAnuncio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label ID="labelDescripcionAnuncio" CssClass="col-sm-2 control-label" runat="server" Text="Descripción del anuncio"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtBoxDescripcionAnuncio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label ID="labelDireccionAnuncio1" CssClass="col-sm-2 control-label" runat="server" Text="Dirección 1"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtBoxDireAnuncio1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label ID="labelPrecioBaseAnuncio" CssClass="col-sm-2 control-label" runat="server" Text="Precio Base"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtBoxPrecioBaseAnuncio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <h2>Precios por temporada</h2>

        <div class="col-md-4">
            <asp:Repeater ID="repTemporadas" runat="server" OnItemCommand="repTemporadas_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered">
                        <tr>
                            <th>Fecha Inicio</th>
                            <th>Fecha Fin</th>
                            <th>Importe</th>
                            <th>Acciones</th>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><asp:Label runat="server" ID="Label1" text='<%# Eval("FechaInicio") %>' /></td>
                        <td><asp:Label runat="server" ID="Label2" text='<%# Eval("FechaFin") %>' /></td>
                        <td><asp:Label runat="server" ID="Label3" text='<%# Eval("Importe") %>' /></td>
                        <td>
                            <asp:LinkButton CommandName="delete" CommandArgument=<%# Eval("Id") %> runat="server">Delete</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-8">

            <div class="col-md-4">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </div>

            <div class="col-md-4">
                <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <asp:TextBox ID="txtBoxImporteXFechaAnuncio" runat="server" CssClass="form-control" placeholder="Importe"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:LinkButton ID="btnAgregarTemporada" runat="server" CssClass="btn btn-default" OnClick="btnAgregarTemporada_Click">Agregar Temporada</asp:LinkButton>
                </div>
            </div>
        </div>

        <h2>Fotos del alojamiento</h2>

        <div class="form-group">
            <asp:Label runat="server" ID="Foto" CssClass="col-sm-2 control-label">Foto</asp:Label>
            <div class="col-sm-10">
                <asp:FileUpload ID="fuFoto1" runat="server" CssClass="form-control"/>
                <asp:FileUpload ID="fuFoto2" runat="server" CssClass="form-control"/>
                <asp:FileUpload ID="fuFoto3" runat="server" CssClass="form-control"/>
                <asp:FileUpload ID="fuFoto4" runat="server" CssClass="form-control"/>
                <asp:FileUpload ID="fuFoto5" runat="server" CssClass="form-control"/>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-10">
                <asp:LinkButton ID="btnSalvarAnuncio" runat="server" Text="Agregar Anuncio" OnClick="btnSalvarAnuncio_Click" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BMAnuncio.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web17" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">

        <h1>Administrar Anuncios</h1>

        <% if (mensajes.Text != "")
            { %>
        <div class="alert alert-info">
            <asp:Label ID="mensajes" runat="server"></asp:Label>
        </div>
        <% } %>

        <asp:Repeater ID="repAnuncios" runat="server" OnItemCommand="repAnuncios_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped table-bordered">
                    <tr>
                        <th>Id</th>
                        <th>Nombre</th>
                        <th>Direccion</th>
                        <th>Precio Base</th>
                        <th>Acciones</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("Id") %>' /></td>
                    <td>
                        <asp:Label runat="server" ID="Label2" Text='<%# Eval("NombreAnuncio") %>' /></td>
                    <td>
                        <asp:Label runat="server" ID="Label3" Text='<%# Eval("Direccion") %>' /></td>
                    <td>
                        <asp:Label runat="server" ID="Label5" Text='<%# Eval("PrecioBase") %>' /></td>
                    <td>
                        <asp:LinkButton CommandName="delete" CommandArgument='<%# Eval("Id") %>' runat="server">Eliminar</asp:LinkButton>
                        <asp:LinkButton CommandName="edit" CommandArgument='<%# Eval("Id") %>' runat="server">Mostrar/Editar</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>

        <% if (Session["modificacionAnuncioActiva"] != null)
            { %>
        <h3>Modificar</h3>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="labelNombreAnuncioBM" runat="server" Text="Nombre Anuncio" CssClass="col-sm-2 control-label"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtBoxNombreAnuncioBM" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="labelDescripcionAnuncioBM" runat="server" Text="Descripcion" CssClass="col-sm-2 control-label"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtBoxDescripcionAnuncioBM" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="labeLPrecioBaseBM" runat="server" Text="Precio base" CssClass="col-sm-2 control-label"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtBoxPrecioBaseBM" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="labelDireccionBM" runat="server" Text="Direccion" CssClass="col-sm-2 control-label"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtBoxDireccionBM" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <% if (Session["foto"] != null)
                { %>
            <div class="form-group">
                <asp:Label ID="lblEliminarFotoBManuncio" runat="server" Text="Eliminar las fotos Existentes" CssClass="col-sm-2 control-label"></asp:Label>
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnEliminarFotoBManuncio" runat="server" Text="Borrar" CssClass="btn btn-default" OnClick="btnEliminarFotoBManuncio_Click" />
                </div>
            </div>

            <% } %>
            <div class="form-group">
                <asp:Label runat="server" ID="Foto" CssClass="col-sm-2 control-label">Foto</asp:Label>
                <div class="col-sm-8">
                    <asp:FileUpload ID="fuFoto1" runat="server" CssClass="form-control" />
                    <asp:FileUpload ID="fuFoto2" runat="server" CssClass="form-control" />
                    <asp:FileUpload ID="fuFoto3" runat="server" CssClass="form-control" />
                    <asp:FileUpload ID="fuFoto4" runat="server" CssClass="form-control" />
                    <asp:FileUpload ID="fuFoto5" runat="server" CssClass="form-control" />
                </div>
            </div>

            <asp:Repeater ID="repRangos" runat="server" OnItemCommand="repRangos_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered">
                        <tr>
                            <th>Id</th>
                            <th>Fecha Inicio</th>
                            <th>Fecha Fin</th>
                            <th>Importe</th>
                            <th>Acciones</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="Label1" Text='<%# Eval("Id") %>' /></td>
                        <td>
                            <asp:Label runat="server" ID="Label2" Text='<%# Eval("FechaInicio") %>' /></td>
                        <td>
                            <asp:Label runat="server" ID="Label3" Text='<%# Eval("FechaFin") %>' /></td>
                        <td>
                            <asp:Label runat="server" ID="Label5" Text='<%# Eval("Importe") %>' /></td>
                        <td>
                            <asp:LinkButton CommandName="delete" CommandArgument='<%# Eval("Id") %>' runat="server">Eliminar</asp:LinkButton>
                            <asp:LinkButton CommandName="edit" CommandArgument='<%# Eval("Id") %>' runat="server">Editar</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <div class="form-group">
                <asp:Label ID="lblFechaInicioBManuncio" runat="server" Text="Fecha de inicio" CssClass="col-sm-2 control-label"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtFechaInicioBManuncio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblFechaFinBManuncio" runat="server" Text="Fecha Fin" CssClass="col-sm-2 control-label"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtFechaFinBManuncio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblImporteBManuncio" runat="server" Text="Importe en Dólares" CssClass="col-sm-2 control-label"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtImporteBManuncio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnActualizarRangosBManuncios" runat="server" Text="Actualizar Rangos" CssClass="btn btn-default" OnClick="btnActualizarRangosBManuncios_Click" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnActualizarAnuncioBM" runat="server" Text="Actualizar Anuncio" CssClass="btn btn-default" OnClick="btnActualizarAnuncioBM_Click" />
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaAnuncio.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web15" %>

<asp:Content ID="AltaAnuncio" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h3>Crear una publicación</h3>
        <hr />
        <div class="form-group">
            <asp:Label ID="labelAlojamientoAnuncio" CssClass="col-md-2" runat="server" Text="Seleccione el Alojamiento a publicar"></asp:Label>
            <div class="col-lg-10">
                <asp:DropDownList ID="ddlTipoDeAlojamientoParaAnuncio" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="labelNombreAnuncio" CssClass="col-md-2" runat="server" Text="Nombre del anuncio"></asp:Label>
            <div class="col-lg-10">
                <asp:TextBox ID="txtboxNombreAnuncio" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="labelDescripcionAnuncio" CssClass="col-md-2" runat="server" Text="Descripción del anuncio"></asp:Label>
            <div class="col-lg-10">
                <asp:TextBox ID="txtBoxDescripcionAnuncio" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="labelDireccionAnuncio1" CssClass="col-md-2" runat="server" Text="Dirección 1"></asp:Label>
            <div class="col-lg-10">
                <asp:TextBox ID="txtBoxDireAnuncio1" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="labelDireccionAnuncio2" CssClass="col-md-2" runat="server" Text="Dirección 2"></asp:Label>
            <div class="col-lg-10">
                <asp:TextBox ID="txtBoxDireAnuncio2" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="labelPrecioBaseAnuncio" CssClass="col-md-2" runat="server" Text="Precio Base"></asp:Label>
            <div class="col-lg-10">
                <asp:TextBox ID="txtBoxPrecioBaseAnuncio" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="Foto" CssClass="col-md-2 control-label">Foto</asp:Label>
            <div class="col-lg-10">
                <asp:TextBox runat="server" ID="txtFoto1" type="file" CssClass="form-control" />
                <asp:TextBox runat="server" ID="txtFoto2" type="file" CssClass="form-control" />
                <asp:TextBox runat="server" ID="TextBox3" type="file" CssClass="form-control" />
                <asp:TextBox runat="server" ID="TextBox4" type="file" CssClass="form-control" />
                <asp:TextBox runat="server" ID="TextBox5" type="file" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-lg-3">
                <asp:Button ID="bttnAgregarAnuncio" runat="server" Text="Agregar Anuncio" OnClick="bttnAgregarAnuncio_Click" />
            </div>
        </div>
        <asp:Panel ID="RangosDeVacaciones" runat="server" Visible="false">
            <div class="form-group">
                <asp:Label ID="labelRangosAnuncio" CssClass="col-md-2" runat="server" Text="Ingrese los distintos rangos de fecha disponible"></asp:Label>
                <div class="col-lg-10"></div>
            </div>
            <div class="form-group">
                <div class="col-lg-10">
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    <br />
                    <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                    <br />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblImporteXFechaAnuncio" CssClass="col-md-2" runat="server" Text="Ingrese el importe para las fechas ingresadas: "></asp:Label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtBoxImporteXFechaAnuncio" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="LblMensajes" CssClass="col-md-2" runat="server"></asp:Label>
                <div class="col-lg-10">
                    <asp:Button ID="btnImporteXfechaAnuncio" runat="server" Text="Ingresar" OnClick="btnImporteXfechaAnuncio_Click" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-10">
                    <asp:GridView ID="gdvImporteXFechaAnuncio" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Id" />
                            <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" />
                            <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" />
                            <asp:BoundField DataField="importe" HeaderText="Importe" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

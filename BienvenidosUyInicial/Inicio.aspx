<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="BienvenidosUyInicial.Formulario_web14" %>

<asp:Content ID="inicio" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <section id="primeraInicio" class="row">
            <div class="row">
                <nav class="col-lg-2 col-md-2 col-sm-3">
                    <ul id="subMenu" class="nav nav-pills nav-stacked">
                        <li role="presentation" class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown"
                                href="Alojamiento/Alojamiento.aspx" role="button">Alojamiento<span class="caret"></span>
                            </a>
                            <ul class="dropdown-menu nav" id="dropdownAlojamiento">
                                <li>
                                    <a href="Alojamientos/AltaAlojamiento.aspx">Nuevo Alojamiento</a>
                                </li>
                                <li>
                                    <a href="Alojamientos/BMAlojamiento.aspx">Eliminar/Modificar Alojamiento</a>
                                </li>
                            </ul>
                        </li>
                        <li role="presentation" class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown"
                                href="Anuncio.aspx" role="button">Publicaciones<span class="caret"></span>
                            </a>
                            <ul class="dropdown-menu nav" id="dropdownAnuncio">
                                <li>
                                    <a href="Anuncio/AltaAnuncio.aspx">Nuevo publicacion</a>
                                </li>
                                <li>
                                    <a href="Anuncio/BMAnuncio.aspx">Eliminar/Modificar publicacion</a>
                                </li>
                            </ul>
                        </li>
                        <li role="presentation" class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown"
                                href="Reserva/Reserva.aspx" role="button">Reservas<span class="caret"></span>
                            </a>
                            <ul class="dropdown-menu nav" id="dropdownReserva">
                                <li>
                                    <a href="Reserva/AltaReserva.aspx">Nueva Reserva</a>
                                </li>
                                <li>
                                    <a href="Reserva/BMReserva.aspx">Eliminar/Modificar Reserva</a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </nav>
                <div class="col-lg-10 col-md-10 col-sm-9">
                    <h1 id="tituloInicio" class="col-lg-10 text-center"><strong>Aca hay que poner algo</strong></h1>
                    <p class="text-justify col-lg-11">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                    Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat
                    </p>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

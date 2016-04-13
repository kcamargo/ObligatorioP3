<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BienvenidosUyInicial._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="primeraHome" class="row">
        <div class="col-lg-12">
            <h1 id="tituloFotos" class="col-lg-12 text-center"><strong>BienvenidosUy - Tu nueva forma de vacacionar</strong></h1>
            <p class="text-justify">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat
            </p>
        </div>
        <article > 
            <div class="row">
                <div class="col-lg-12 hidden-xs">
                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="4"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                            <div class="item active">
                                <img id="fotoSlide1" src="PicturesSlider/Bosque.jpg" class="img-responsive" alt="Bosque" />
                                <div class="carousel-caption">
                                    <h3>Slide 1</h3>
                                </div>
                            </div>
                            <div class="item">
                                <img id="fotoSlide2" src="PicturesSlider/HongKong.jpg" class="img-responsive" alt="Hong Kong" />
                                <div class="carousel-caption">
                                    <h3>Slide 2</h3>
                                </div>
                            </div>
                            <div class="item">
                                <img id="fotoSlide3" src="PicturesSlider/HotelNieve.jpg" class="img-responsive" alt="Hotel" />
                                <div class="carousel-caption">
                                    <h3>Slide 3</h3>
                                </div>
                            </div>
                            <div class="item">
                                <img id="fotoSlide4" src="PicturesSlider/PaisajeNieve.jpg" class="img-responsive" alt="Paisaje" />
                                <div class="carousel-caption">
                                    <h3>Slide 4</h3>
                                </div>
                            </div>
                            <div class="item">
                                <img id="fotoSlide5" src="PicturesSlider/Puente.jpg" class="img-responsive" alt="Puente" />
                                <div class="carousel-caption">
                                    <h3>Slide 5</h3>
                                </div>
                            </div>
                        </div>
                        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>

            </div>
        </article>
        <article>
             <div class="col-lg-6 text-center">
            <h1 id="tituloAnfitrion" class="col-lg-12 text-center"><strong>Enterate aqui, como podes hacer para ser un nuevo anfitrion</strong></h1>
            <p class="text-justify">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat
            </p>
        </div>
             <div class="col-lg-6 text-center">
            <h1 id="tituloX" class="col-lg-12 text-center"><strong>Todavia no sabemos que poner!</strong></h1>
            <p class="text-justify">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat
            </p>
        </div>
        </article>
    </section>



</asp:Content>

﻿using BienvenidosUyBLL.EntidadesNegocio;
using BienvenidosUyBLL.InterfacesRepositorios;
using FabricaRepositorios;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BienvenidosUyInicial.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            if (Session["AltaUsuarioActiva"] == null)
            {
                Session["AltaUsuarioActiva"] = new Usuario();
            }

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            Usuario u = Session["AltaUsuarioActiva"] as Usuario;
            if (u != null)
            {
                u.Email = this.Email.Text;
                u.Contraseña = this.Password.Text;
                u.NombreUsuario = this.Nombre.Text;
                u.ApellidoUsuario = this.Apellido.Text;
                u.Direccion = this.Direccion.Text;
                u.Telefono = this.Telefono.Text;
                u.Descripcion = this.Descripcion.Text;
                if (ddlTipoUusario.SelectedValue == "Anfitrion")
                {
                    u.Rol = Usuario.Roles.Anfitrion;
                }
                else if (ddlTipoUusario.SelectedValue == "Huesped")
                {
                    u.Rol = Usuario.Roles.Husped;
                }
                else
                {
                    u.Rol = Usuario.Roles.Chusma;
                }


                IRepositorioUsuario user = FabricaRepositoriosBienvenidosUy.CrearRepositorioUsuario();
                if (user.Add(u))
                {
                    this.mensaje.Text = "Usuario corretamente ingresado";
                    LimpiarCampos();
                }
                else
                {
                    this.mensaje.Text = "Usuario rechazado";
                    Session["AltaUsuarioActiva"] = new Usuario.Roles();
                }

            }

        }

        protected void LimpiarCampos()
        {
            //Email.Text;
            //Password.Text;
            //Nombre.Text;
            //Apellido.Text;
            //Text;
            //.Telefono.Text;
            //Descripcion.Text;
        }
    }
}
using BienvenidosUyBLL.EntidadesNegocio;
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
    public partial class Login : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


            }
            if (Session["usuarioActivo"] == null)
            {
                Session["usuarioActivo"] = new Usuario();
            }


        }


        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            IRepositorioUsuario ru = FabricaRepositoriosBienvenidosUy.CrearRepositorioUsuario();
            Usuario u = ru.FindByPassword(EmailLogIn.Text, ContraseñaLogIn.Text);
            if (u != null)
            {
                Session["usuarioActivo"] = u;
                Response.Redirect("/inicio");
            }
            else
            {
                mensaje.Text = "El usuario o la contraseña no son correctos";
            }

        }
    }
}
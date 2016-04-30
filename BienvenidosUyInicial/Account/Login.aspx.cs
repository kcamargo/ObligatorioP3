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
using System.Security.Cryptography;

namespace BienvenidosUyInicial.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* if (!Page.IsPostBack)
             {
                if (Session["AutenticaciónActiva"] == null)
             {

             } 

             }


             RegisterHyperLink.NavigateUrl = "Register";
             // Habilite esta opción una vez tenga la confirmación de la cuenta habilitada para la funcionalidad de restablecimiento de contraseña
             //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
             OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
             var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
             if (!String.IsNullOrEmpty(returnUrl))
             {
                 RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
             }
         }*/
        }
        protected bool BuscarSiExiste(string email)
        {
            IRepositorioUsuario ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioUsuario();
     
            if (ro.FindByEmail(email) != null)
            {
                return true;
            }
            else
                return false;

        }
        public bool Validar(string password, string email)
        {
            IRepositorioUsuario ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioUsuario();

            if (ro.Validar(password,email))
            {
                return true;
            }
            else
                return false;

        }

        protected void btnEntrar_click(object sender, EventArgs e)
        {
            Usuario u = Session["AutenticaciónActiva"] as Usuario;
            //string password = u.SHA1Encrypt(ContraseniaLogIn.Text);

           
            if (BuscarSiExiste(EmailLogIn.Text))
            {
                if (Validar(u.SHA1Encrypt(ContraseniaLogIn.Text),EmailLogIn.Text) )
                {
                    this.mensaje.Text = "Ingresado";
                    Session["youreSessionName"] = EmailLogIn;
                    Response.Redirect("./Home.aspx");
                }
            }
            else
            {
                this.mensaje.Text = "No puede ingresar, usated no esta registrado";
                Response.Redirect("Home.aspx?mensaje=Log in solamente es accesible para usuarios registrados");
            }
        }

        protected void LogOut(object sender, EventArgs e)
        {
            // The SignOut method invalidates the authentication cookie.
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void LogIn(object sender, EventArgs e)
        {

            //hello

        }
    }
}
            
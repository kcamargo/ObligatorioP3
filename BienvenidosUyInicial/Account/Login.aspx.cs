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
                //BuscarSiExiste();

            }
            if (Session["AltaAlojamientoActiva"] == null)
            {
                Session["AltaAlojamientoActiva"] = new Alojamiento();
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
        }
        //protected Usuario BuscarSiExiste(string email)
        //{ 
        //    IRepositorioUsuario user = FabricaRepositoriosBienvenidosUy.CrearRepositorioUsuario();
        //    Usuario usuario = user.BuscarUsuario(email);
        //    email = EmailLogIn.Text;
        //    if (usuario != null)
        //    {
        //        return usuario;


        //    }
        //    else {

        //    }

    }

    //protected void btnEntrar_click(object sender, EventArgs e)
    //{


    //    //Al hacer clic se agrega la organización, que se asume ya cuenta con sus direcciones
    //    Usuario u = Session["LogInActiva"] as Usuario;
    //    if (u != null)
    //    {





    //        IRepositorioUsuario ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioUsuario();
    //        if (ro.FindById())
    //            this.mensaje.Text = "Ingresado";

    //        else
    //            this.mensaje.Text = "Rechazado";
    //        Session["LogInActiva"] = new Usuario();
    //    }


    /* if (IsValid)
     {
         // Validar la contraseña del usuario
         var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
         var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

         // Esto no cuenta los errores de inicio de sesión hacia el bloqueo de cuenta
         // Para habilitar los errores de contraseña para desencadenar el bloqueo, cambie a shouldLockout: true
         var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

         switch (result)
         {
             case SignInStatus.Success:
                 IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                 break;
             case SignInStatus.LockedOut:
                 Response.Redirect("/Account/Lockout");
                 break;
             case SignInStatus.RequiresVerification:
                 Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                 Request.QueryString["ReturnUrl"],
                                                 RememberMe.Checked),
                                   true);
                 break;
             case SignInStatus.Failure:
             default:
                 FailureText.Text = "Intento de inicio de sesión no válido";
                 ErrorMessage.Visible = true;
                 break;
         }
     }*/
}

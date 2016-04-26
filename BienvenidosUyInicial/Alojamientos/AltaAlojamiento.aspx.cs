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

namespace BienvenidosUyInicial
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarServicios();
                CargarTipoDeAlojamientos();
            }
            if (Session["AltaAlojamientoActiva"] == null)
            {
                Session["AltaAlojamientoActiva"] = new Alojamiento();
            }

        }
        protected void CargarServicios()
        {
            IRepositorioServicio rs = FabricaRepositoriosBienvenidosUy.CrearRepositorioServicio();
            List<Servicio> todosLosServicios = rs.FindAll();
            if (todosLosServicios != null)
            {
                //Las zonas son estables, y se utilizan varias veces
                //cargadas en session para no ir a buscarlas cada vez que se necesiten
                if (Session["listaServicios"] == null) Session["listaServicios"] = todosLosServicios;
                this.CheckBoxListServicios.DataSource = todosLosServicios;
                this.CheckBoxListServicios.DataValueField = "Id";
                this.CheckBoxListServicios.DataTextField = "Nombre";
                this.CheckBoxListServicios.DataBind();
            }
        }
        protected void CargarTipoDeAlojamientos()
        {
            IRepositorioTipoDeAlojamiento rta = FabricaRepositoriosBienvenidosUy.CrearRepositorioTipoDeAlojamiento();
            List<TipoDeAlojamiento> todosLosTiposAlojamiento = rta.FindAll();
            if (todosLosTiposAlojamiento != null)
            {

                if (Session["listaTipoDeAlojamiento"] == null) Session["listaTipoDeAlojamiento"] = todosLosTiposAlojamiento;
                this.ddlTipoAlojamiento.DataSource = todosLosTiposAlojamiento;
                this.ddlTipoAlojamiento.DataValueField = "Id";
                this.ddlTipoAlojamiento.DataTextField = "Nombre";
                this.ddlTipoAlojamiento.DataBind();
            }
        }
        protected void bttonAgregar_Click(object sender, EventArgs e)
        {
            //Al hacer clic se agrega la organización, que se asume ya cuenta con sus direcciones
            Alojamiento a = Session["AltaAlojamientoActiva"] as Alojamiento;
            if (a != null)
            {
                a.Nombre = this.txtBoxNombreAlojamiento.Text;
                a.TipoAlojamiento = this.ddlTipoAlojamiento.SelectedValue;// ojo devuelve un string
                a.TipoHabitacion = this.ddlTipoHabitacion.SelectedValue == "privada";// this.ConvertirABoolTipoHabitacion(this.ddlTipoHabitacion.SelectedValue);
                a.TipoBanio = this.ConvertirABoolTipoBanio(this.ddlTipoHabitacion.SelectedValue);
                a.CapacidadXPersona = Int32.Parse(this.txtBoxCantidadPersonas.Text);
                a.Ciudad = this.txtboxCiudad.Text;
                a.Barrio = this.txtboxBarrio.Text;
                //CargarListaServicios();



                 IRepositorioAlojamiento ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioAlojamiento();
                if (ro.Add(a))
                    this.LblMensajes.Text = "Ingresado";

                else
                    this.LblMensajes.Text = "Rechazado";
                Session["AltaAlojamientoActiva"] = new Alojamiento();
            }

        }
        protected bool ConvertirABoolTipoHabitacion(string value)
        {
            bool valor = false;
            if (value == "privada")
                valor = true;
            return valor;
        }
        protected bool ConvertirABoolTipoBanio(string value)
        {
            bool valor = false;
            if (value == "Privado")
                valor = true;
            return valor;
        }
        //protected List<Servicio> CargarListaServicios()
        //{
        //    List<Servicio> serviciosSeleccionados = new List<Servicio>();
        //    List<ListItem> lista = this.CheckBoxListServicios.Items.Cast<ListItem>().ToList();
        //    foreach (ListItem item in lista)
        //    {
        //        if (item.Selected)
        //        {
        //            serviciosSeleccionados.Add(item);
        //        }
        //    }
        //    return serviciosSeleccionados;
        //}

    }
}
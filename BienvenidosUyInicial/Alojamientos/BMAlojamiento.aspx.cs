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
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarServiciosBM();
                CargarTipoDeAlojamientosBM();
            }
            if (Session["BMAlojamientoActiva"] == null)
            {
                Session["BMAlojamientoActiva"] = new Alojamiento();
            }
        }

        protected void CargarServiciosBM()
        {
            IRepositorioServicio rs = FabricaRepositoriosBienvenidosUy.CrearRepositorioServicio();
            List<Servicio> todosLosServicios = rs.FindAll();
            if (todosLosServicios != null)
            {
                //Las zonas son estables, y se utilizan varias veces
                //cargadas en session para no ir a buscarlas cada vez que se necesiten
                if (Session["listaServicios"] == null) Session["listaServicios"] = todosLosServicios;
                this.CheckBoxListServiciosBM.DataSource = todosLosServicios;
                this.CheckBoxListServiciosBM.DataValueField = "Id";
                this.CheckBoxListServiciosBM.DataTextField = "Nombre";
                this.CheckBoxListServiciosBM.DataBind();
            }
        }
        protected void CargarTipoDeAlojamientosBM()
        {
            IRepositorioTipoDeAlojamiento rta = FabricaRepositoriosBienvenidosUy.CrearRepositorioTipoDeAlojamiento();
            List<TipoDeAlojamiento> todosLosTiposAlojamiento = rta.FindAll();
            if (todosLosTiposAlojamiento != null)
            {

                if (Session["listaTipoDeAlojamiento"] == null) Session["listaTipoDeAlojamiento"] = todosLosTiposAlojamiento;
                this.ddlTipoAlojamientoBM.DataSource = todosLosTiposAlojamiento;
                this.ddlTipoAlojamientoBM.DataValueField = "Nombre";
                this.ddlTipoAlojamientoBM.DataTextField = "Nombre";
                this.ddlTipoAlojamientoBM.DataBind();
            }
        }
        protected List<Servicio> CargarListaServicios()
        {
            IRepositorioServicio ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioServicio();
            List<Servicio> serviciosSeleccionados = new List<Servicio>();
            List<ListItem> lista = this.CheckBoxListServiciosBM.Items.Cast<ListItem>().ToList();
            foreach (ListItem item in lista)
            {
                if (item.Selected)
                {
                    Servicio servicio = ro.FindById(Int32.Parse(item.Value));
                    serviciosSeleccionados.Add(servicio);
                }
            }
            return serviciosSeleccionados;
        }

        protected void bttonEliminar_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnBuscarNombreAlojamientoBM_Click(object sender, EventArgs e)
        {
            Alojamiento a = new Alojamiento();
            a.Nombre = this.txtBoxBuscarNombreAlojamientoBM.Text;
            IRepositorioAlojamiento ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioAlojamiento();
        }

    }
}
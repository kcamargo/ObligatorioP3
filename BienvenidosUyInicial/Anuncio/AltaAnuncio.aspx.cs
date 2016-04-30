using BienvenidosUyBLL.EntidadesNegocio;
using BienvenidosUyBLL.InterfacesRepositorios;
using FabricaRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Threading.Tasks;

namespace BienvenidosUyInicial
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarAlojamientos();
            }
            if (Session["AltaAnuncioActiva"] == null)
            {
                Session["AltaAnuncioActiva"] = new Anuncio();
            }
            if (Session["listaVacaciones"] == null)
            {
                Session["listaVacaciones"] = new List<Vacaciones>();
            }
            if (Session["AltaVacacionesActiva"] == null)
            {
                Session["AltaVacacionesActiva"] = new Vacaciones();
            }

        }
        protected void CargarAlojamientos()
        {
            IRepositorioAlojamiento ra = FabricaRepositoriosBienvenidosUy.CrearRepositorioAlojamiento();
            List<Alojamiento> todosLosAlojamientos = ra.FindAll();
            if (todosLosAlojamientos != null)
            {
                if (Session["listaAlojamientos"] == null) Session["listaAlojamientos"] = todosLosAlojamientos;
                this.ddlTipoDeAlojamientoParaAnuncio.DataSource = todosLosAlojamientos;
                this.ddlTipoDeAlojamientoParaAnuncio.DataValueField = "Id";
                this.ddlTipoDeAlojamientoParaAnuncio.DataTextField = "Nombre";
                this.ddlTipoDeAlojamientoParaAnuncio.DataBind();
            }
        }

        protected void btnImporteXfechaAnuncio_Click(object sender, EventArgs e)
        {
            Vacaciones v = Session["AltaVacacionesActiva"] as Vacaciones;
            if (v != null)
            {

                v.FechaInicio = Calendar1.SelectedDate;
                v.FechaFin = Calendar2.SelectedDate;
                v.Importe = Int32.Parse(this.txtBoxImporteXFechaAnuncio.Text);
                IRepositorioVacaciones ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioVacaciones();
                if (ro.Add(v))
                {
                    this.LblMensajes.Text = "Ingresado";
                    LimpiarCampos();
                    ListarRangos(v);
                }
                else
                    this.LblMensajes.Text = "Rechazado";
                Session["AltaVacacionesActiva"] = new Vacaciones();
            }
        }
        protected void LimpiarCampos()
        {

            Calendar1.SelectedDates.Clear();
            Calendar2.SelectedDates.Clear();
            this.txtBoxImporteXFechaAnuncio.Text = " ";


        }

        protected void ListarRangos(Vacaciones v)
        {
            List<Vacaciones> lista = Session["listaVacaciones"] as List<Vacaciones>;
            if (lista != null)
            {
                lista.Add(v);
                this.gdvImporteXFechaAnuncio.DataSource = lista;
                this.gdvImporteXFechaAnuncio.DataBind();
            }

        }

        protected Alojamiento BuscarAlojamientoXddl(string s)
        {
            int id = Int32.Parse(s);
            IRepositorioAlojamiento ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioAlojamiento();
            Alojamiento a = ro.FindById(id);
            return a;

        }

        protected void bttnAgregarAnuncio_Click(object sender, EventArgs e)
        {

            Anuncio a = Session["AltaAnuncioActiva"] as Anuncio;
            if (a != null)
            {
                a.Alojamiento = BuscarAlojamientoXddl(ddlTipoDeAlojamientoParaAnuncio.SelectedValue);
                a.NombreAnuncio = this.txtboxNombreAnuncio.Text;
                a.DescripcionAnuncio = this.txtBoxDescripcionAnuncio.Text;
                a.PrecioBase = Int32.Parse(this.txtBoxPrecioBaseAnuncio.Text);
                IRepositorioAnuncio ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioAnuncio();
                if (ro.Add(a))
                {
                    IRepositorioDirecciones rd = FabricaRepositoriosBienvenidosUy.CrearRepositorioDireccion();
                    this.LblMensajes.Text = "Ingresado";
                    LimpiarCampos();
                }
                else
                    this.LblMensajes.Text = "Rechazado";
                Session["AltaAnuncioActiva"] = new Alojamiento();
            }


        }
    }
}

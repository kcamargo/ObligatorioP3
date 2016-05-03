using BienvenidosUyBLL.EntidadesNegocio;
using BienvenidosUyBLL.InterfacesRepositorios;
using FabricaRepositorios;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
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
                ListarAlojamientos();
                CargarServiciosBM();
                CargarTipoDeAlojamientosBM();
            }
        }

        private void ListarAlojamientos()
        {
            IRepositorioAlojamiento ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioAlojamiento();
            List<Alojamiento> listAlojamiento = ro.FindAll();

            this.repAlojamientos.DataSource = listAlojamiento;
            this.repAlojamientos.DataBind();
        }

        protected void CargarServiciosBM()
        {
            IRepositorioServicio rs = FabricaRepositoriosBienvenidosUy.CrearRepositorioServicio();
            List<Servicio> todosLosServicios = rs.FindAll();
            this.CheckBoxListServiciosBM.DataSource = todosLosServicios;
            this.CheckBoxListServiciosBM.DataValueField = "Id";
            this.CheckBoxListServiciosBM.DataTextField = "Nombre";
            this.CheckBoxListServiciosBM.DataBind();
        }

        protected void CargarTipoDeAlojamientosBM()
        {
            IRepositorioTipoDeAlojamiento rta = FabricaRepositoriosBienvenidosUy.CrearRepositorioTipoDeAlojamiento();
            List<TipoDeAlojamiento> todosLosTiposAlojamiento = rta.FindAll();
            this.ddlTipoAlojamientoBM.DataSource = todosLosTiposAlojamiento;
            this.ddlTipoAlojamientoBM.DataValueField = "Nombre";
            this.ddlTipoAlojamientoBM.DataTextField = "Nombre";
            this.ddlTipoAlojamientoBM.DataBind();
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

        protected bool ExisteServicio(string item, List<Servicio> list)
        {
            bool encontrado = false;
            int i = 0;
            while (i < list.Count && !encontrado)
            {
                if (list[i].Id.ToString() == item)
                {
                    encontrado = true;
                }
                i++;
            }
            return encontrado;
        }
        protected void btnActualizarBM_Click(object sender, EventArgs e)
        {
            Alojamiento a = Session["modificacionAlojamientoActiva"] as Alojamiento;
            if (a != null)
            {
                a.Nombre = this.txtBoxNombreAlojamientoBM.Text;
                a.TipoAlojamiento = this.ddlTipoAlojamientoBM.SelectedValue;// ojo devuelve un string
                a.TipoHabitacion = this.ddlTipoHabitacionBM.SelectedValue;
                a.TipoBanio = this.ddlBanoBM.SelectedValue;
                a.CapacidadXPersona = Int32.Parse(this.txtBoxCapacidadBM.Text);
                a.Ciudad = this.txtboxCiudadBM.Text;
                a.Barrio = this.txtboxBarrioBM.Text;
                a.TipoDeServicios = CargarListaServicios();

                IRepositorioAlojamiento ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioAlojamiento();
                if (ro.Update(a))
                {
                    mensajes.Text = "El alojamiento se ha modificado correctamente";
                    Session["modificacionAlojamientoActiva"] = null;
                    LimpiarCampos();
                    ListarAlojamientos();
                }
                else
                {
                    mensajes.Text = "El alojamiento no se ha podido modificar";
                }
            }
        }

        protected void LimpiarCampos()
        {

            this.txtBoxNombreAlojamientoBM.Text = " ";
            this.txtBoxCapacidadBM.Text = " ";
            this.txtboxCiudadBM.Text = " ";
            this.txtboxBarrioBM.Text = " ";

        }

        protected void repAlojamientos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            IRepositorioAlojamiento ra = FabricaRepositoriosBienvenidosUy.CrearRepositorioAlojamiento();
            int id = Int32.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "edit")
            {
                Alojamiento a = ra.FindById(id);
                txtBoxNombreAlojamientoBM.Text = a.Nombre;
                ddlTipoAlojamientoBM.SelectedValue = a.TipoAlojamiento;
                ddlTipoHabitacionBM.SelectedValue = a.TipoHabitacion;
                ddlBanoBM.SelectedValue = a.TipoBanio;
                txtBoxCapacidadBM.Text = a.CapacidadXPersona.ToString();
                txtboxCiudadBM.Text = a.Ciudad;
                txtboxBarrioBM.Text = a.Barrio;

                foreach (ListItem item in CheckBoxListServiciosBM.Items)
                {
                    item.Selected = ExisteServicio(item.Value, a.TipoDeServicios);
                }
                Session["modificacionAlojamientoActiva"] = a;
            }
            else if (e.CommandName == "delete")
            {
                if (ra.Delete(id))
                {
                    ListarAlojamientos();
                    mensajes.Text = "El Alojamiento " + id + " fue eliminado";
                }
                else
                {
                    mensajes.Text = "No fue posible eliminar el alojamiento";
                }

            }
        }

    }
}
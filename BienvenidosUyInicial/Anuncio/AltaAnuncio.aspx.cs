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
                Usuario u = Session["usuarioActivo"] as Usuario;
                if (u == null || !u.Rol.Equals(Usuario.Roles.Anfitrion))
                {
                    Response.Redirect("/inicio");
                }
            }
        }

        private bool SubirFoto(FileUpload fu)
        {
            if (fu.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(fu.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                if (allowedExtensions.Contains(fileExtension))
                {
                    try
                    {
                        fu.PostedFile.SaveAs(FotoURL(fu.FileName));
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private string FotoURL(string fileName)
        {
            return Server.MapPath("~/UploadedImages/") + fileName;
        }

        protected void CargarAlojamientos()
        {
            IRepositorioAlojamiento ra = FabricaRepositoriosBienvenidosUy.CrearRepositorioAlojamiento();
            List<Alojamiento> todosLosAlojamientos = ra.FindAll();
            this.ddlTipoDeAlojamientoParaAnuncio.DataSource = todosLosAlojamientos;
            this.ddlTipoDeAlojamientoParaAnuncio.DataValueField = "Id";
            this.ddlTipoDeAlojamientoParaAnuncio.DataTextField = "Nombre";
            this.ddlTipoDeAlojamientoParaAnuncio.DataBind();
        }

        protected void LimpiarCampos()
        {

            Calendar1.SelectedDates.Clear();
            Calendar2.SelectedDates.Clear();
            this.txtBoxImporteXFechaAnuncio.Text = " ";


        }

        protected void AgregarTemporada(Temporada v)
        {
            List<Temporada> lista = Session["temporadas"] as List<Temporada>;
            if (lista == null) { lista = new List<Temporada>(); }

            lista.Add(v);
            Session["temporadas"] = lista;
        }

        protected Foto CrearFoto(FileUpload fu)
        {
            Foto foto = new BienvenidosUyBLL.EntidadesNegocio.Foto();
            foto.Url = FotoURL(fu.FileName);
            return foto;
        }


        protected void btnSalvarAnuncio_Click(object sender, EventArgs e)
        {
            bool foto1Subida = SubirFoto(fuFoto1);
            bool foto2Subida = SubirFoto(fuFoto2);
            bool foto3Subida = SubirFoto(fuFoto3);
            bool foto4Subida = SubirFoto(fuFoto4);
            bool foto5Subida = SubirFoto(fuFoto5);

            if (!foto1Subida || !foto2Subida || !foto3Subida || !foto4Subida || !foto5Subida)
            {
                mensajes.Text = "Algunas fotos no fueron subidas";
                return;
            }

            Anuncio a = new Anuncio();
            a.Id_Alojamiento = Int32.Parse(ddlTipoDeAlojamientoParaAnuncio.SelectedValue);
            a.NombreAnuncio = this.txtboxNombreAnuncio.Text;
            a.DescripcionAnuncio = this.txtBoxDescripcionAnuncio.Text;
            a.PrecioBase = Int32.Parse(this.txtBoxPrecioBaseAnuncio.Text);
            a.Direccion = txtBoxDireAnuncio1.Text;
            a.Feriados = Session["temporadas"] as List<Temporada>;

            if (fuFoto1.HasFile) { a.FotosAnuncio.Add(CrearFoto(fuFoto1)); }
            if (fuFoto2.HasFile) { a.FotosAnuncio.Add(CrearFoto(fuFoto2)); }
            if (fuFoto3.HasFile) { a.FotosAnuncio.Add(CrearFoto(fuFoto3)); }
            if (fuFoto4.HasFile) { a.FotosAnuncio.Add(CrearFoto(fuFoto4)); }
            if (fuFoto5.HasFile) { a.FotosAnuncio.Add(CrearFoto(fuFoto5)); }

            IRepositorioAnuncio ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioAnuncio();
            if (ro.Add(a))
            {
                mensajes.Text = "El anuncio fue creado correctamente";
                LimpiarCampos();
            }
            else
            {
                mensajes.Text = "Ha ocurrido un error";
            }
        }

        protected void btnAgregarTemporada_Click(object sender, EventArgs e)
        {
            Temporada v = new Temporada();
            v.FechaInicio = Calendar1.SelectedDate;
            v.FechaFin = Calendar2.SelectedDate;
            v.Importe = Int32.Parse(this.txtBoxImporteXFechaAnuncio.Text);

            AgregarTemporada(v);
            ListarTemporadas();
            LimpiarCampos();
        }


        private void ListarTemporadas()
        {
            this.repTemporadas.DataSource = Session["temporadas"];
            this.repTemporadas.DataBind();
        }

        protected void repTemporadas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            

        }

    }
}


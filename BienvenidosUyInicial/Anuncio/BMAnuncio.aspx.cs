using BienvenidosUyBLL.EntidadesNegocio;
using BienvenidosUyBLL.InterfacesRepositorios;
using FabricaRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BienvenidosUyInicial
{
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarAnuncios();
                Usuario u = Session["usuarioActivo"] as Usuario;
                if (u == null || !u.Rol.Equals(Usuario.Roles.Anfitrion))
                {
                    Response.Redirect("/inicio");
                }

            }
            if (Session["foto"] == null)
                Session["foto"] = new Foto();
        }



        private void CargarTemporadas(int id)
        {
            IRepositorioTemporada rt = FabricaRepositoriosBienvenidosUy.CrearRepositorioTemporada();
            List<Temporada> listTemporadas = rt.FindByIdAnuncio(id);

            this.repRangos.DataSource = listTemporadas;
            this.repRangos.DataBind();
        }

        private void CargarImagenes(int id)
        {
            IRepositorioFoto ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioFoto();
            List<Foto> listFotos = ro.FindByIdAnuncio(id);

            this.repAnuncios.DataSource = listFotos;
            this.repAnuncios.DataBind();
        }

        private void CargarAnuncios()
        {
            IRepositorioAnuncio ro = FabricaRepositoriosBienvenidosUy.CrearRepositorioAnuncio();
            List<Anuncio> listAnuncios = ro.FindAll();

            this.repAnuncios.DataSource = listAnuncios;
            this.repAnuncios.DataBind();
        }

        protected void btnActualizarAnuncioBM_Click(object sender, EventArgs e)
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

            a.NombreAnuncio = this.txtBoxNombreAnuncioBM.Text;
            a.DescripcionAnuncio = this.txtBoxDescripcionAnuncioBM.Text;
            a.PrecioBase = Int32.Parse(this.txtBoxPrecioBaseBM.Text);
            a.Direccion = txtBoxDireccionBM.Text;
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
                //LimpiarCampos();
            }
            else
            {
                mensajes.Text = "Ha ocurrido un error";
            }
        }

        protected void LimpiarCampos()
        {
            txtBoxNombreAnuncioBM.Text = " ";
            txtBoxDescripcionAnuncioBM.Text = " ";
            txtBoxPrecioBaseBM.Text = " ";
            txtBoxDireccionBM.Text = " ";

        }

        protected void repAnuncios_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            IRepositorioAnuncio ra = FabricaRepositoriosBienvenidosUy.CrearRepositorioAnuncio();
            int id = Int32.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "edit")
            {
                Anuncio a = ra.FindById(id);
                txtBoxNombreAnuncioBM.Text = a.NombreAnuncio;
                txtBoxDescripcionAnuncioBM.Text = a.DescripcionAnuncio;
                txtBoxPrecioBaseBM.Text = a.PrecioBase.ToString();
                txtBoxDireccionBM.Text = a.Direccion;
                CargarImagenes(id);
                CargarTemporadas(id);


                Session["modificacionAnuncioActiva"] = a;
            }
            else if (e.CommandName == "delete")
            {
                if (ra.Delete(id))
                {
                    CargarAnuncios();
                    mensajes.Text = "El Anuncio " + id + " fue eliminado";
                }
                else
                {
                    mensajes.Text = "No fue posible eliminar el alojamiento";
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

        protected Foto CrearFoto(FileUpload fu)
        {
            Foto foto = new BienvenidosUyBLL.EntidadesNegocio.Foto();
            foto.Url = FotoURL(fu.FileName);
            return foto;
        }

        protected void repRangos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            IRepositorioTemporada rt = FabricaRepositoriosBienvenidosUy.CrearRepositorioTemporada();
            int id = Int32.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "edit")
            {
                Temporada t = rt.FindById(id);
                txtFechaInicioBManuncio.Text = t.FechaInicio.ToString();
                txtFechaFinBManuncio.Text = t.FechaFin.ToString();
                txtImporteBManuncio.Text = t.Importe.ToString();

                Session["modificacionTemporadaActiva"] = t;
            }
            else if (e.CommandName == "delete")
            {
                if (rt.Delete(id))
                {
                    CargarAnuncios();
                    CargarTemporadas(id);
                    mensajes.Text = "El Anuncio " + id + " fue eliminado";
                }
                else
                {
                    mensajes.Text = "No fue posible eliminar el alojamiento";
                }

            }
        }

        protected void btnActualizarRangosBManuncios_Click(object sender, EventArgs e)
        {
            Temporada t = Session["modificacionTemporadaActiva"] as Temporada;
            if (t == null) { t = new Temporada(); }
            t.FechaInicio = Convert.ToDateTime(txtFechaInicioBManuncio.Text);
            t.FechaFin = Convert.ToDateTime(txtFechaFinBManuncio.Text);
            t.Importe = Int32.Parse(txtImporteBManuncio.Text);
            t.Id_anuncio = (Session["modificacionAnuncioActiva"] as Anuncio).Id;

            IRepositorioTemporada rt = FabricaRepositoriosBienvenidosUy.CrearRepositorioTemporada();
            bool resultado = t.Id == 0 ? rt.Add(t) : rt.Update(t);
            if (resultado)
            {
                mensajes.Text = "El rango se actualizo correctamente";
                CargarTemporadas(t.Id_anuncio);
                Session["modificacionTemporadaActiva"] = null;
                //LimpiarCampos();
            }
            else
            {
                mensajes.Text = "Ha ocurrido un error";
            }
        }

        protected void btnEliminarFotoBManuncio_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FabricaRepositorios
{
    public class FabricaRepositoriosBienvenidosUy
    {
        private static string LeerTipoDesdeConfiguracion()
        {
            return System.Configuration.ConfigurationManager.AppSettings["repositorio"];
        }

        public static BienvenidosUyBLL.InterfacesRepositorios.IRepositorioAlojamiento CrearRepositorioAlojamiento()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepoAlojamiento.RepositorioAlojamimentoSQL();
            else if (tipo == "mock")
                return new Repositorios.RepoAlojamiento.RespositorioAlojamientoMock();
            else if (tipo == "texto")
                return new Repositorios.RepoAlojamiento.RepositorioAlojamientoTexto();
            return null;
        }
        public static BienvenidosUyBLL.InterfacesRepositorios.IRepositorioUsuario CrearRepositorioUsuario()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepoUsuario.RepositorioUsuarioSQL();
            else if (tipo == "mock")
                return new Repositorios.RepoUsuario.RepositorioUsuarioMock();
            else if (tipo == "texto")
                return new Repositorios.RepoUsuario.RepositorioUsuarioTexto();
            return null;
        }
        public static BienvenidosUyBLL.InterfacesRepositorios.IRepositorioAnuncio CrearRepositorioAnuncio()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepoAnuncio.RepositorioAnuncioSQL();
            else if (tipo == "mock")
                return new Repositorios.RepoAnuncio.RepositorioAnuncioMock();
            else if (tipo == "texto")
                return new Repositorios.RepoAnuncio.RepositorioAnuncioTexto();
            return null;
        }
        public static BienvenidosUyBLL.InterfacesRepositorios.IRepositorioFoto CrearRepositorioFoto()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepoFoto.RepositorioFotoSQL();
            else if (tipo == "mock")
                return new Repositorios.RepoFoto.RepositorioFotoMock();
            else if (tipo == "texto")
                return new Repositorios.RepoFoto.RepositorioFotoTexto();
            return null;
        }
        public static BienvenidosUyBLL.InterfacesRepositorios.IRepositorioReserva CrearRepositorioReserva()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepoReserva.RepositorioReservaSQL();
            else if (tipo == "mock")
                return new Repositorios.RepoReserva.RepositorioReservaMock();
            else if (tipo == "texto")
                return new Repositorios.RepoReserva.RepositorioReservaTexto();
            return null;
        }
        public static BienvenidosUyBLL.InterfacesRepositorios.IRepositorioServicio CrearRepositorioServicio()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepoServicio.RepositorioServicioSQL();
            else if (tipo == "mock")
                return new Repositorios.RepoServicio.RepositorioServicioMock();
            else if (tipo == "texto")
                return new Repositorios.RepoServicio.RepositorioServicioTexto();
            return null;
        }
        public static BienvenidosUyBLL.InterfacesRepositorios.IRepositorioTipoDeAlojamiento CrearRepositorioTipoDeAlojamiento()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepoTiposDeAlojamiento.RepositorioTiposDeAlojamientoSQL();
            else if (tipo == "mock")
                return new Repositorios.RepoTiposDeAlojamiento.RepositorioTiposDeAlojamientoMock();
            else if (tipo == "texto")
                return new Repositorios.RepoTiposDeAlojamiento.RepositorioTiposDeAlojamientoTexto();
            return null;
        }
        public static BienvenidosUyBLL.InterfacesRepositorios.IRepositorioTemporada CrearRepositorioTemporada()
        {
            string tipo = LeerTipoDesdeConfiguracion();
            if (tipo == "sql")
                return new Repositorios.RepoTemporada.RepositorioTemporadaSQL();
            else if (tipo == "mock")
                return new Repositorios.RepoTemporada.RepositorioTemporadaMock();
            else if (tipo == "texto")
                return new Repositorios.RepoTemporada.RepositorioTemporadaTexto();
            return null;
        }

    }
}

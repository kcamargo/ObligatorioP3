using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;

namespace Repositorios.RepoTemporada
{
    public class RepositorioTemporadaMock : IRepositorioTemporada
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Temporada obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Temporada> FindAll()
        {
            throw new NotImplementedException();
        }

        public BienvenidosUyBLL.EntidadesNegocio.Temporada FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Temporada> FindByIdAlojamiento(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Temporada obj)
        {
            throw new NotImplementedException();
        }

        bool IRepositorio<Temporada>.Add(Temporada obj)
        {
            throw new NotImplementedException();
        }

        bool IRepositorio<Temporada>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        List<Temporada> IRepositorio<Temporada>.FindAll()
        {
            throw new NotImplementedException();
        }

        Temporada IRepositorio<Temporada>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        List<Temporada> IRepositorioTemporada.FindByIdAlojamiento(int id)
        {
            throw new NotImplementedException();
        }

        List<Temporada> IRepositorioTemporada.FindByIdAnuncio(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepositorio<Temporada>.Update(Temporada obj)
        {
            throw new NotImplementedException();
        }
    }
}

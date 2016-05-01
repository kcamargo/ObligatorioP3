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
    }
}

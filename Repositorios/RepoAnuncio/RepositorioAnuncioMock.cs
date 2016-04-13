using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;

namespace Repositorios.RepoAnuncio
{
    public class RepositorioAnuncioMock : IRepositorioAnuncio
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Anuncio obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Anuncio> FindAll()
        {
            throw new NotImplementedException();
        }

        public BienvenidosUyBLL.EntidadesNegocio.Anuncio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Anuncio obj)
        {
            throw new NotImplementedException();
        }
    }
}

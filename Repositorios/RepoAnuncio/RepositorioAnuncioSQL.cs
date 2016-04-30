using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;
using System.Configuration;
using System.Data.SqlClient;

namespace Repositorios.RepoAnuncio
{
    public class RepositorioAnuncioSQL : IRepositorioAnuncio
    {
        public bool Add(Anuncio obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anuncio> FindAll()
        {
            throw new NotImplementedException();
        }

        public Anuncio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Anuncio obj)
        {
            throw new NotImplementedException();
        }
    }
}

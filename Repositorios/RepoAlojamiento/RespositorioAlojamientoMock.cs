using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;
using System.Data.SqlClient;
using UtilidadesBD;

namespace Repositorios.RepoAlojamiento
{
    public class RespositorioAlojamientoMock : IRepositorioAlojamiento
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Alojamiento obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Alojamiento> FindAll()
        {
            throw new NotImplementedException();
        }

        public BienvenidosUyBLL.EntidadesNegocio.Alojamiento FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Alojamiento obj)
        {
            throw new NotImplementedException();
        }
    }
}

using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BienvenidosUyBLL.EntidadesNegocio;
using System.Data.SqlClient;
using UtilidadesBD;
using System.Configuration;

namespace Repositorios.RepoAlojamiento
{
    public class RepositorioAlojamimentoSQL : IRepositorioAlojamiento
    {
        public bool Add(BienvenidosUyBLL.EntidadesNegocio.Alojamiento obj)
        {
            return obj != null && obj.Add();
        }

        public bool Delete(int id)
        {
            Alojamiento o = FindById(id);
            return (o != null && o.Delete());
        }

        public List<BienvenidosUyBLL.EntidadesNegocio.Alojamiento> FindAll()
        {
            throw new NotImplementedException();
        }

        public BienvenidosUyBLL.EntidadesNegocio.Alojamiento FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienvenidosUyBLL.EntidadesNegocio.Alojamiento obj) { return obj != null & obj.Update(); }


    }
}

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
using System.Data;

namespace Repositorios.Direcciones
{
    class IRepositorioDireccionesSQL : IRepositorioDirecciones
    {
        public bool Add(Direccion obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Direccion> FindAll()
        {
            throw new NotImplementedException();
        }

        public Direccion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Direccion obj)
        {
            throw new NotImplementedException();
        }
    }
}

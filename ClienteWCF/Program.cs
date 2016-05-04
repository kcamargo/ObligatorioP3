using BienvenidosUyBLL.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ListarAnunciosClient cliente = new ServiceReference1.ListarAnunciosClient();
            cliente.Open();
            ServiceReference1.Anuncio[] anuncios = cliente.GetAll();
            foreach (ServiceReference1.Anuncio a in anuncios)
                Console.WriteLine(a.NombreAnuncio + ", " + a.DescripcionAnuncio + ", " + a.Direccion + ", " + a.Feriados);
            cliente.Close();
            Console.ReadKey();
        }
    }
}

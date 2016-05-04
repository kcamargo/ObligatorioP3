using BienvenidosUyBLL.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BUYServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ListarAnuncios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ListarAnuncios
    {

        [OperationContract]
        List<Anuncio> GetAll();

        // TODO: agregue aquí sus operaciones de servicio
    }

}

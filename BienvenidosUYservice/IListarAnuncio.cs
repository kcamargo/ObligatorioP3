using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BienvenidosUYservice
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IListarAnuncio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IListarAnuncio
    {

        [OperationContract]
        List<Anuncio> GetAll();

        [OperationContract]
        Anuncio GetAnuncio(int id);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Anuncio
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdAlojamiento { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string NombreAnuncio { get; set; }
        [DataMember]
        public string DescripcionAnuncio { get; set; }
        [DataMember]
        public List<Foto> FotosAnuncio { get; set; }
        [DataMember]
        public int PrecioBase { get; set; }
        [DataMember]
        public List<Temporada> Feriados;
        

    }

    public class Foto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Anuncio { get; set; }
        [DataMember]
        public string Url { get; set; }

    }

    public class Temporada
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public int Importe { get; set; }
        [DataMember]
        public int Id_anuncio { get; set; }

    }
}

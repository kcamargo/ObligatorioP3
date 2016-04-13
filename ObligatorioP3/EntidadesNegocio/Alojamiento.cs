using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesBD;

namespace BienvenidosUyBLL.EntidadesNegocio
{
    public class Alojamiento : IEntity
    {
        #region PROPERTIES

        public int Id { get; set; }

        public List<TipoDeAlojamiento> Tipo;

        public string Nombre { get; set; }
        public bool TipoBanio { get; set; }

        public int CapacidadXPersona { get; set; }

        public string Ciudad { get; set; }

        public string Barrio { get; set; }

        public List<Servicio> TipoDeServicios;


        #endregion

        #region CONSTRUCTOR

        public Alojamiento()
        {
            this.Tipo = new List<TipoDeAlojamiento>();
            this.TipoDeServicios = new List<Servicio>();
        }

        #endregion

        #region Redefiniciones de Object
        public override string ToString()
        {
            string datos = "Id: " + this.Id + " " + this.Nombre + "  " + this.Ciudad + "  " + this.Barrio;
            return datos;
        }
        public override bool Equals(object obj)
        {
            Alojamiento a = obj as Alojamiento;
            if (a != null) return a.Nombre.Trim().ToUpper()
                == this.Nombre.Trim().ToUpper();
            return false;
        }
        #endregion

        #region Cadenas de comando para ACTIVE RECORD //falta terminar, hacerlo despues de crear las tablas en SQL

        private string cadenaInsertAlojamiento = "INSERT INTO Alojamiento VALUES (@nombre)";
        private string cadenaUpdateAlojamiento = "UPDATE  Alojamiento SET nombre=@nombre WHERE id=@id";
        private string cadenaDeleteAlojamiento = "DELETE  Alojamiento WHERE id=@id";

        #endregion

        #region Métodos ACTIVE RECORD

        public bool Add()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaInsertAlojamiento, cn))
                    {
                        // cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                        cn.Open();
                        int afectadas = cmd.ExecuteNonQuery();
                        return afectadas == 1;
                    }
                }
            }
            return false;
        }
        public bool Update()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdateAlojamiento, cn))
                    {
                        //cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                        //cmd.Parameters.AddWithValue("@id", this.Id);
                        cn.Open();
                        int afectadas = cmd.ExecuteNonQuery();
                        return afectadas == 1;
                    }
                }
            }
            return false;
        }
        public bool Delete()
        {

            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaDeleteAlojamiento, cn))
                {

                    //cmd.Parameters.AddWithValue("@id", this.Id);
                    cn.Open();
                    int afectadas = cmd.ExecuteNonQuery();
                    return afectadas == 1;
                }
            }

        }
        public void Load(IDataRecord dr)
        {
            if (dr != null)
            {
                //this.Nombre = dr["nombre"].ToString();
                this.Id = Convert.ToInt32(dr["id"]);
            }
        }
        #endregion

        #region VALIDACIONES

        public bool Validar()
        {
            return true; //this.Nombre.Length >= 3;
        }


        #endregion

        #region REDEFINICIONES DE OBJECT
        public override string ToString()
        {
            return this.Id + " - " ;
        }
        #endregion

    }
}

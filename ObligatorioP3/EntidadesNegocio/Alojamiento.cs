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

        public string TipoAlojamiento { get; set; }

        public string Nombre { get; set; }
        public bool TipoHabitacion { get; set; }//true privada

        public bool TipoBanio { get; set; }//true privado

        public int CapacidadXPersona { get; set; }

        public string Ciudad { get; set; }

        public string Barrio { get; set; }

        public List<Servicio> TipoDeServicios;

        #endregion

        #region CONSTRUCTOR

        public Alojamiento()
        {
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

        private string cadenaInsertAlojamiento = @"INSERT INTO Alojamiento VALUES (@nombre, @tipoHabitacion, @tipoBanio, @capacidadPersonas); SELECT CAST(Scope_Identity() AS INT);";
        private string cadenaUpdateAlojamiento = @"UPDATE  Alojamiento SET nombre=@nombre, tipoHabitacion=tipo@tipoHabitacion, tipoBanio=@tipoBanio, capacidadPersonas=@capacidadPersonas WHERE id=@id";
        private string cadenaDeleteAlojamiento = @"DELETE  Alojamiento WHERE id=@id";

        #endregion

        #region Métodos ACTIVE RECORD

        public bool Add()
        {
            SqlConnection cn = null; SqlTransaction trn = null;
            if (!this.Validar()) return false;
            try
            {
                cn = UtilidadesBD.BdSQL.Conectar();

                //Preparar el comando de inserción de una organización
                SqlCommand cmd = new SqlCommand(cadenaInsertAlojamiento, cn);
                cmd.Parameters.Add(new SqlParameter("@nombre", this.Nombre));
                cmd.Parameters.Add(new SqlParameter("@tipoHabitacion", this.TipoHabitacion));
                cmd.Parameters.Add(new SqlParameter("@tipoBanio", this.TipoBanio));
                cmd.Parameters.Add(new SqlParameter("@capacidadPersonas", this.CapacidadXPersona));

                //Ejecutar el comando para insertar la organización en la tabla maestra
                //y capturar el valor del identity generado para usarlo
                // como FK en las direcciones

                //Antes de ejecutar el comando se le debe asignar la transacción
                BdSQL.AbrirConexion(cn);
                trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                cmd.Transaction = trn;
                this.Id = (int)cmd.ExecuteScalar();
                //Preparar el comando para ingresar las direcciones asociadas
                //La transacción y la conexión permanecen incambiadas
                
                //Si se llegó aquí se asume que podemos completar la transacción
                trn.Commit();
                trn.Dispose();
                trn = null;
                return true;

            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + " Error al guardar la organización " + this.Nombre);
                //Si se produjo un error en cualquier punto de la transacción, deberíamos deshacer todas 
                //las operaciones.
                if (trn != null) trn.Rollback();
                return false;
            }
            finally
            {
                BdSQL.CerrarConexion(cn);
            }
        }
        public bool Update()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdateAlojamiento, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                        cmd.Parameters.AddWithValue("@tipoHabitacion", this.TipoHabitacion);
                        cmd.Parameters.AddWithValue("@tipoBanio", this.TipoBanio);
                        cmd.Parameters.AddWithValue("@capacidadPersonas", this.CapacidadXPersona);
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

                    cmd.Parameters.AddWithValue("@id", this.Id);
                    cn.Open();
                    int afectadas = cmd.ExecuteNonQuery();
                    return afectadas == 1;
                }
            }

        }
        public void Load(IDataRecord dr)
        {
            if (dr == null) return;
            this.Nombre = dr["Nombre"] == DBNull.Value ? null : dr["Nombre"].ToString();
            this.Id = (int)dr["Id"];//este no puede ser dbnull

        }
        #endregion

        #region VALIDACIONES

        public bool Validar()
        {
            return true; //this.Nombre.Length >= 3;
        }


        #endregion

    }
}

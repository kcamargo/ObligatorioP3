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
        public string TipoHabitacion { get; set; }//true privada

        public string TipoBanio { get; set; }//true privado

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

        private string cadenaInsertAlojamiento = @"INSERT INTO Alojamientos VALUES ( @nombre, @tipo_habitacion, @tipo_banio, @capacidad_personas, @ciudad, @barrio, @tipo_alojamiento)SELECT CAST(Scope_Identity() AS INT);";
        private string cadenaUpdateAlojamiento = @"UPDATE  Alojamientos SET nombre=@nombre, tipo_habitacion=@tipo_habitacion, tipo_banio=@tipo_banio, capacidad_personas=@capacidad_personas, ciudad=@ciudad, barrio=@barrio, tipo_alojamiento=@tipo_alojamiento WHERE id=@id";
        private string cadenaDeleteAlojamiento = @"DELETE  Alojamientos WHERE id=@id";
        private string cadenaInsertAlojamientoServicio = @"INSERT INTO alojamientoServicio values(@id_alojamiento, @id_servicio)";
        private string cadenaDeleteAlojamientoServicios = @"DELETE alojamientoServicio WHERE id_alojamiento=@id_alojamiento";

        #endregion

        #region Métodos ACTIVE RECORD


        public bool Add()
        {
            SqlConnection cn = null; SqlTransaction trn = null;
            if (!this.Validar()) return false;
            try
            {
                cn = UtilidadesBD.BdSQL.Conectar();

                SqlCommand cmd = new SqlCommand(cadenaInsertAlojamiento, cn);
                cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                cmd.Parameters.AddWithValue("@tipo_alojamiento", this.TipoAlojamiento);
                cmd.Parameters.AddWithValue("@tipo_habitacion", this.TipoHabitacion);
                cmd.Parameters.AddWithValue("@tipo_banio", this.TipoBanio);
                cmd.Parameters.AddWithValue("@capacidad_personas", this.CapacidadXPersona);
                cmd.Parameters.AddWithValue("@ciudad", this.Ciudad);
                cmd.Parameters.AddWithValue("@barrio", this.Barrio);
                BdSQL.AbrirConexion(cn);
                trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                cmd.Transaction = trn;
                this.Id = (int)cmd.ExecuteScalar();
                cmd.CommandText = cadenaInsertAlojamientoServicio;
                foreach (Servicio s in this.TipoDeServicios)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@id_alojamiento", this.Id));
                    cmd.Parameters.Add(new SqlParameter("@id_servicio", s.Id));
                    cmd.ExecuteNonQuery();
                }

                trn.Commit();
                trn.Dispose();
                trn = null;
                return true;

            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + " Error al guardar el Alojamiento: " + this.Nombre);
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
                        SqlTransaction trn = null;
                        BdSQL.AbrirConexion(cn);
                        trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                        cmd.Transaction = trn;

                        //Update alojamiento
                        cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                        cmd.Parameters.AddWithValue("@tipo_habitacion", this.TipoHabitacion);
                        cmd.Parameters.AddWithValue("@tipo_banio", this.TipoBanio);
                        cmd.Parameters.AddWithValue("@tipo_alojamiento", this.TipoAlojamiento);
                        cmd.Parameters.AddWithValue("@capacidad_Personas", this.CapacidadXPersona);
                        cmd.Parameters.AddWithValue("@ciudad", this.Ciudad);
                        cmd.Parameters.AddWithValue("@barrio", this.Barrio);
                        cmd.Parameters.AddWithValue("@id", this.Id);
                        int afectadas = cmd.ExecuteNonQuery();

                        //Delete alojamiento servicios
                        cmd.Parameters.Clear();
                        cmd.CommandText = cadenaDeleteAlojamientoServicios;
                        cmd.Parameters.AddWithValue("@id_alojamiento", this.Id);
                        cmd.ExecuteNonQuery();

                        //Insert alojamiento servicios
                        cmd.CommandText = cadenaInsertAlojamientoServicio;
                        foreach (Servicio s in this.TipoDeServicios)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@id_alojamiento", this.Id));
                            cmd.Parameters.Add(new SqlParameter("@id_servicio", s.Id));
                            cmd.ExecuteNonQuery();
                        }

                        trn.Commit();
                        trn.Dispose();
                        trn = null;

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
                    SqlTransaction trn = null;
                    BdSQL.AbrirConexion(cn);
                    trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    cmd.Parameters.AddWithValue("@id", this.Id);
                    cmd.Transaction = trn;
                    int afectadas = cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.CommandText = cadenaDeleteAlojamientoServicios;
                    cmd.Parameters.AddWithValue("@id_alojamiento", this.Id);
                    cmd.ExecuteNonQuery();


                    trn.Commit();
                    trn.Dispose();
                    trn = null;

                    return afectadas == 1;
                }
            }

        }
        public void Load(IDataRecord dr)
        {
            if (dr == null) return;
            this.Id = (int)dr["Id"];
            this.Nombre = dr["Nombre"] == DBNull.Value ? null : dr["Nombre"].ToString();
            this.TipoHabitacion = dr["tipo_habitacion"] == DBNull.Value ? null : dr["tipo_habitacion"].ToString();
            this.TipoBanio = dr["tipo_banio"] == DBNull.Value ? null : dr["tipo_banio"].ToString();
            this.CapacidadXPersona = (int)dr["capacidad_personas"];
            this.Ciudad = dr["ciudad"] == DBNull.Value ? null : dr["ciudad"].ToString();
            this.Barrio = dr["barrio"] == DBNull.Value ? null : dr["barrio"].ToString();
            this.TipoAlojamiento = dr["tipo_alojamiento"] == DBNull.Value ? null : dr["tipo_alojamiento"].ToString();
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

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesBD;

namespace BienvenidosUyBLL.EntidadesNegocio
{
    public class Anuncio : IEntity
    {
        #region PROPERTIES
        public int Id { get; set; }

        public Alojamiento Alojamiento { get; set; };

        public List<Direccion> Direcciones { get; set; }

        public string NombreAnuncio { get; set; }

        public string DescripcionAnuncio { get; set; }

        public List<Foto> FotosAnuncio { get; set; }

        public int PrecioBase { get; set; }

        public List<Vacaciones> Feriados;

        #endregion

        #region Cadenas de comando para ACTIVE RECORD //falta terminar, hacerlo despues de crear las tablas en SQL

        private string cadenaInsertAnuncio = @"INSERT INTO Anuncios VALUES (@nombre, @descripcion, @precio_base);SELECT CAST(Scope_Identity() AS INT);";
        private string cadenaInsertDireccionesAnuncio = @"INSERT INTO Direcciones VALUES (@linea1,@linea2);SELECT CAST(Scope_Identity() AS INT);";
        private string cadenaUpdateAnuncio = @"UPDATE  Anuncios SET nombre=@nombre, descripcion=@descripcion, precio_base=@precio_base WHERE id=@id";
        private string cadenaDeleteAnuncio = @"DELETE  Anuncios WHERE id=@id";
        private string cadenaDeleteDireccionAnuncio = @"DELETE  Direcciones WHERE id=@id";

        #endregion

        #region Métodos ACTIVE RECORD

        public void AgregarDireccion(Direccion d)
        {
            if (d.Validar() && !this.Direcciones.Contains(d))
                this.Direcciones.Add(d);

        }
        public bool Add()
        {
            SqlConnection cn = null; SqlTransaction trn = null;
            if (!this.Validar()) return false;
            try
            {
                cn = UtilidadesBD.BdSQL.Conectar();

                SqlCommand cmd = new SqlCommand(cadenaInsertAnuncio, cn);
                cmd.Parameters.Add(new SqlParameter("@nombre", this.NombreAnuncio));
                cmd.Parameters.Add(new SqlParameter("@descripcion", this.DescripcionAnuncio));
                cmd.Parameters.Add(new SqlParameter("@precio_base", this.PrecioBase));

                BdSQL.AbrirConexion(cn);
                trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                cmd.Transaction = trn;
                this.Id = (int)cmd.ExecuteScalar();
                cmd.CommandText = cadenaInsertDireccionesAnuncio;
                foreach (Direccion d in this.Direcciones)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@linea1", d.Linea1));
                    cmd.Parameters.Add(new SqlParameter("@linea2", d.Linea2));
                    cmd.ExecuteNonQuery();
                }

                trn.Commit();
                trn.Dispose();
                trn = null;
                return true;

            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + " Error al guardar el anuncio " + this.NombreAnuncio);
                if (trn != null) trn.Rollback();
                return false;
            }
            finally
            {
                BdSQL.CerrarConexion(cn);
            }
        }
        public bool UpdateAnuncio()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdateAnuncio, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombreAnuncio", this.NombreAnuncio);
                        cmd.Parameters.AddWithValue("@descripcionAnuncio", this.DescripcionAnuncio);
                        cmd.Parameters.AddWithValue("@id", this.Id);
                        cn.Open();
                        int afectadas = cmd.ExecuteNonQuery();
                        return afectadas == 1;
                    }

                }
            }
            return false;
        }
        public bool UpdateDirecciones()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaInsertDireccionesAnuncio, cn))
                    {
                        cmd.CommandText = cadenaInsertDireccionesAnuncio;
                        foreach (Direccion d in this.Direcciones)
                        {
                            cmd.Parameters.AddWithValue("@linea1", d.Linea1);
                            cmd.Parameters.AddWithValue("@linea2", d.Linea2);
                            cn.Open();
                            int afectadas = cmd.ExecuteNonQuery();
                            return afectadas == 1;
                        }
                        
                    }

                }
            }
            return false;
        }

        public bool DeleteAnuncio()
        {
            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaDeleteAnuncio, cn))
                {

                    cmd.Parameters.AddWithValue("@id", this.Id);
                    cn.Open();
                    int afectadas = cmd.ExecuteNonQuery();
                    return afectadas == 1;
                }
            }

        }

        public bool DeleteDireccion()
        {
            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaDeleteDireccionAnuncio, cn))
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
            //El operador condicional u operador ternario tiene la siguiente forma: test ? expression1 : expression2
            //y es análogo a if (dr["Nombre]==DBNull.Value) return null else return dr["Nombre"].ToString();
            this.NombreAnuncio = dr["Nombre"] == DBNull.Value ? null : dr["Nombre"].ToString();
            this.DescripcionAnuncio = dr["Descripcion"] == DBNull.Value ? null : dr["Descripcion"].ToString();
            this.Id = (int)dr["Id"];//este no puede ser dbnull
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
            return this.Id + " - ";
        }
        #endregion

    }
}

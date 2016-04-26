﻿using BienvenidosUyBLL.EntidadesNegocio;
using BienvenidosUyBLL.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UtilidadesBD;

namespace BienvenidosUyBLL.EntidadesNegocio
{
   public class Usuario : IEntity
    {
        #region PROPERTIES
        public int Id { get; set; }

        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string ApellidoUsuario { get; set; }
        public string IdUser { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
        public List<Usuario> lista;
        #endregion

        #region Cadenas de comando para ACTIVE RECORD //falta terminar, hacerlo despues de crear las tablas en SQL

        private string cadenaInsertAnuncio = "INSERT INTO Usuarios VALUES (@NombreUsuario, @ApellidoUsuario,@Contraseña,@Direccion,@Telefono,@Descripcion );SELECT CAST(Scope_Identity() AS INT);";
        private string cadenaUpdateAnuncio = "UPDATE  Usuarios SET nombreUsuario=@NombreUsuario, ApellidoUsuario=@ApellidoUsuario, Contraseña=@Contraseña, Direccion=@Direccion, Telefono=@Telefono, Descripcion=@Descripcion WHERE id=@id";
        private string cadenaDeleteAnuncio = "DELETE  Usuarios WHERE nombreUsuario=@NombreUsuario";


        #endregion

        #region Métodos ACTIVE RECORD

        public bool BuscarUsuario(string email)
        {
            string CADENABUSCAR = "SELECT * FROM Usuario WHERE email=@email";
            Usuario usuarioEncontrado = null;
            bool booleano = false;
            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(CADENABUSCAR, cn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {

                            Usuario U = new Usuario();
                            U.Load(reader);
                            U.Email = email;
                            if (U.Validar())
                            {

                                usuarioEncontrado = U;
                                booleano = true;
                            }
                            else {
                                booleano = false;
                            }
                        }
                    }


                }

            }
            return booleano;
        }
        public bool Add()
        {
            SqlConnection cn = null; SqlTransaction trn = null;
            if (!this.Validar()) return false;
            try
            {
                cn = UtilidadesBD.BdSQL.Conectar();

                //Preparar el comando de inserción de una organización
                SqlCommand cmd = new SqlCommand(cadenaInsertAnuncio, cn);
                cmd.Parameters.Add(new SqlParameter("@nombreUsuario", this.NombreUsuario));
                cmd.Parameters.Add(new SqlParameter("@ApellidoUsuario", this.ApellidoUsuario));
                cmd.Parameters.Add(new SqlParameter("@Contraseña", this.Contraseña));
                cmd.Parameters.Add(new SqlParameter("@Direccion", this.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", this.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", this.Descripcion));

                BdSQL.AbrirConexion(cn);
                trn = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                cmd.Transaction = trn;

                //La transacción y la conexión permanecen incambiadas

                //Si se llegó aquí se asume que podemos completar la transacción
                trn.Commit();
                trn.Dispose();
                trn = null;
                return true;

            }
            catch (Exception ex)
            {
                BdSQL.LoguearError(ex.Message + " Error al guardar el usuario " + this.NombreUsuario);
                if (trn != null) trn.Rollback();
                return false;
            }
            finally
            {
                BdSQL.CerrarConexion(cn);
            }
        }


        public bool UpdateUsuario()
        {
            if (this.Validar())
            {
                using (SqlConnection cn = BdSQL.Conectar())
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaUpdateAnuncio, cn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@nombreUsuario", this.NombreUsuario));
                        cmd.Parameters.Add(new SqlParameter("@ApellidoUsuario", this.ApellidoUsuario));
                        cmd.Parameters.Add(new SqlParameter("@Contraseña", this.Contraseña));
                        cmd.Parameters.Add(new SqlParameter("@Direccion", this.Direccion));
                        cmd.Parameters.Add(new SqlParameter("@Telefono", this.Telefono));
                        cmd.Parameters.Add(new SqlParameter("@Descripcion", this.Descripcion));
                        cn.Open();

                        int afectadas = cmd.ExecuteNonQuery();
                        return afectadas == 1;
                    }

                }
            }
            return false;
        }

        public bool DeleteUsuario()
        {
            using (SqlConnection cn = BdSQL.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(cadenaDeleteAnuncio, cn))
                {

                    cmd.Parameters.AddWithValue("@idUser", this.IdUser);
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
            this.NombreUsuario = dr["NombreUsuario"] == DBNull.Value ? null : dr["NombreUsuario"].ToString();
            this.ApellidoUsuario = dr["ApellidoUsuario"] == DBNull.Value ? null : dr["ApellidoUsuario"].ToString();
            this.Contraseña = dr["Contraseña"] == DBNull.Value ? null : dr["Contraseña"].ToString();
            this.Telefono = dr["Telefono"] == DBNull.Value ? null : dr["Telefono"].ToString();
            this.Descripcion = dr["Descripcion"] == DBNull.Value ? null : dr["Descripcion"].ToString();
            this.Direccion = dr["Direccion"] == DBNull.Value ? null : dr["Direccion"].ToString();
            this.Id = (int)dr["Id"];//este no puede ser dbnull
        }

        #endregion

        #region VALIDACIONES

        public bool Validar()
        {
            return this.NombreUsuario.Length >= 3 && Contraseña.Length>=8;
        }
        #endregion

        #region Encriptación
        static string GetMd5Hash(MD5 md5Hash, string contraseña)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }


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


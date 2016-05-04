using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;


namespace DAL
{
    public class DALBase
    {
        #region Propiedades

        public static string constr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
            }
        }

        #endregion

        #region EjecutaNonQuery

        protected static int ejecutaNonQuery(string consulta, List<SqlParameter> parametros, CommandType cmdType)
        {
            int affected;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = constr;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = consulta;
            command.CommandType = cmdType;

            if (parametros != null)
            {
                command.Parameters.Clear();
                foreach (SqlParameter param in parametros)
                    command.Parameters.Add(param);
            }

            affected = command.ExecuteNonQuery();
            command.Dispose();
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
            return affected;
        }

        #endregion
        protected static SqlDataReader select(List<SqlParameter> parameters, string StoreProcedureoQuery, CommandType tipo)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = constr;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = StoreProcedureoQuery;
            cmd.CommandType = tipo;

            if (parameters != null)
            {
                foreach (SqlParameter p in parameters)
                {
                    cmd.Parameters.Add(p);
                }
            }
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }



    }
}

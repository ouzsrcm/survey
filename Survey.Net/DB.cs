using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Survey.Net
{
    public static class DB
    {
        public static SqlConnection getNewConnection() {

            string sqlConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(sqlConnectionString);
            return con;

        }

        public static DataTable toDT(SqlCommand cmd) {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
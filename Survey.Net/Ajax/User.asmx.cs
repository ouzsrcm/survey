using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace Survey.Net.Ajax
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class User : System.Web.Services.WebService
    {

        [WebMethod(EnableSession=true)]
        public string Info(string UserID)
        {
            string result = "";
            int ID = Convert.ToInt32(UserID.ToString());
            DataTable dt = new DataTable();
            SqlConnection con = DB.getNewConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Firstname, Lastname, UserID FROM tblUser WHERE (UserID = @UserID)", con);
            cmd.Parameters.AddWithValue("@UserID", ID);
            dt = DB.toDT(cmd);
            con.Close();
            con.Dispose();

            if (dt != null && dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["Firstname"].ToString() + " " + dt.Rows[0]["Lastname"].ToString();
            }
            else {
                result = "USER_NOT_FOUND";
            }

            return result;

        }
    }
}
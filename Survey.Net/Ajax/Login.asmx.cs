using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Survey.Net;

namespace Survey.Net.Ajax
{
    /// <summary>
    /// Kullanıcı Girişi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class Login1 : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string Login(string Username, string Password)
        {
            string result = "RES";
            
                Username = Functions.clear(Username);
                Password = Functions.clear(Password);
                   
                SqlConnection con = DB.getNewConnection();
                con.Open();
                
                DataTable dt = new DataTable();
                
                SqlCommand cmd =
                    new SqlCommand("Select tucr.*, tuc.CompanyID From tblUserCredential as tucr Inner Join tblUserCompany as tuc On tucr.UserID = tuc.UserID Where tucr.Username=@username And tucr.Password=@password And tucr.StatusCode=@StatusCode", con);
                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@StatusCode", true);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                con.Dispose();

                if (dt != null && dt.Rows.Count > 0) {
                    result = "USER_LOGIN_SUCCESS";

                    Session["LoggedUser"] = true;
                    Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                    Session["UserCompanyID"] = dt.Rows[0]["CompanyID"].ToString();

                } else {
                    result = "USER_NOT_FOUND";
                }
             
            return result;
        }

        public string LogOut(string UserID) {

            int ID = Convert.ToInt32(UserID.ToString());

            Session["LoggedUser"] = null;
            Session["UserID"] = 0;
            Session.Abandon();

            return "TRUE";

        }

    }
}

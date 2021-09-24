using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Survey.Net.Ajax
{
    /// <summary>
    /// Categories
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    
    public class Categories : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string addCategory(string categoryTitle) {

            string result = "NULL";

            string UserID = Session["UserID"].ToString();
            string companyID = Session["UserCompanyID"].ToString();

            if (categoryTitle != "")
            {

                SqlConnection con = DB.getNewConnection();
                con.Open();

                SqlCommand cmd = new SqlCommand(@"Insert Into tblCategory(CompanyID, UserID, Category, StatusCode) 
                                            Values("+companyID+", "+ UserID +", '"+ categoryTitle +"', 1)", con);

                cmd.ExecuteNonQuery();

                con.Close();
                con.Dispose();
                result = "SUCCESS_ADDED";
                
            }
            else {

                result = "ERROR";

            }
             

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string getList() {

            string result = "";

            DataTable dt = new DataTable();
            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT CategoryID, CompanyID, UserID, Category, StatusCode FROM tblCategory WHERE(StatusCode = 1)", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            if (dt != null) {

                result = JsonConvert.SerializeObject(dt);

            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string deleteCategory(string CategoryID) {

            string result = "NULL";

            if (Session["UserID"] != null && Session["LoggedUser"] != null)
            {

                if (Convert.ToBoolean(Session["LoggedUser"].ToString()) == true)
                {

                    SqlConnection con = DB.getNewConnection();
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Update tblCategory Set StatusCode=0 Where CategoryID=" + CategoryID, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    con.Dispose();
                    cmd.Dispose();

                    result = "SUCCESS_DELETED";

                }

            }

            return result;

        }

        [WebMethod(EnableSession=true)]
        public string editCategory(string CategoryID, string CategoryTitle) {

            string result = "";

            if (CategoryID != "" && CategoryTitle != "") {

                SqlConnection con = DB.getNewConnection();
                con.Open();

                SqlCommand cmd = new SqlCommand("Update tblCategory Set Category='"+CategoryTitle+"' Where CategoryID=" + CategoryID, con);
                cmd.ExecuteNonQuery();

                con.Close();
                con.Dispose();
                cmd.Dispose();

                result = "SUCCESS_EDIT";

            }

            return result;

        }

    }
}

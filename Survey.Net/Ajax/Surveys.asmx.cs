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
    /// Surveys
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Surveys : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string List() {

            string result = "";

            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * From tblSurveyDefinition Where StatusCode=1 And UserID=" + Session["UserID"].ToString(), con);

            DataTable dt = new DataTable();

            dt = DB.toDT(cmd);

            con.Close();
            con.Dispose();
            cmd.Dispose();

            if (dt != null) {

                result = JsonConvert.SerializeObject(dt);

            } else {
                result = "NULL";
            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string getSingleSurvey(int SurveyID) {

            string result = "";

            if (Session["UserID"] != null && Session["LoggedUser"] != null)
            {

                if (Convert.ToBoolean(Session["LoggedUser"].ToString()) == true)
                {

                    SqlConnection con = DB.getNewConnection();
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("Select * From tblSurveyDefinition Where SurveyID=" + SurveyID.ToString() + " And StatusCode=1", con);

                    dt = DB.toDT(cmd);
                    
                    con.Close();
                    con.Dispose();
                    cmd.Dispose();

                    result = JsonConvert.SerializeObject(dt);

                    dt.Dispose();
                }

            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string onAir(int SurveyID = 0, int State = 0)
        {
            string result = "";
            string sql = "";

            if ((Session["UserID"] != null && Session["LoggedUser"] != null) && (SurveyID != 0))
            {

                if (Convert.ToBoolean(Session["LoggedUser"].ToString()) == true)
                {
                    SqlConnection con = DB.getNewConnection();
                    con.Open();

                    sql = "Update tblSurveyDefinition Set IsOnAir=@IsOnAir Where SurveyID=@SurveyID";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@IsOnAir", State);
                    cmd.Parameters.AddWithValue("@SurveyID", SurveyID);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    con.Dispose();
                    cmd.Dispose();

                    result = "SUCCESS";

                }

            }

            return result;
        }

        [WebMethod(EnableSession = true)]
        public string saveEdit(string Title, string Description = "", string BeginDate = "", string EndDate = "", int SurveyID = 0)
        {
            string result = "";
            string sql = "";

            if ((Session["UserID"] != null && Session["LoggedUser"] != null) && (SurveyID != 0)) {

                if (Convert.ToBoolean(Session["LoggedUser"].ToString()) == true)
                {
                    SqlConnection con = DB.getNewConnection();
                    con.Open();

                    sql = "Update tblSurveyDefinition Set SurveyName=@SurveyName, Description=@Desc, BeginDate=@BeginDate, EndDate=@EndDate ";
                    sql += "Where SurveyID=@SurveyID";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@SurveyName", Title);
                    cmd.Parameters.AddWithValue("@Desc", Description);
                    cmd.Parameters.AddWithValue("@BeginDate", BeginDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@SurveyID", SurveyID);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    con.Dispose();
                    cmd.Dispose();

                    result = "SUCCESS_EDITED";

                }

            }

            return result;
        }

        [WebMethod(EnableSession = true)]
        public string saveAdd(string Title, string Description = "", string BeginDate = "", string EndDate = "")
        {
            string result = "";
            string sql = "";

            if (Session["UserID"] != null && Session["LoggedUser"] != null)
            {

                if (Convert.ToBoolean(Session["LoggedUser"].ToString()) == true)
                {
                    SqlConnection con = DB.getNewConnection();
                    con.Open();

                    sql = "Insert Into tblSurveyDefinition(CompanyID, UserID, SurveyName, Description, BeginDate, EndDate, IsOnAir, StatusCode) ";
                    sql += "Values(@CompanyID,  @UserID, @SurveyName, @Desc, @BeginDate, @EndDate, @IsOnAir, @StatusCode)";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@CompanyID", Session["UserCompanyID"].ToString());
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    cmd.Parameters.AddWithValue("@SurveyName", Title);
                    cmd.Parameters.AddWithValue("@Desc", Description);
                    cmd.Parameters.AddWithValue("@BeginDate", BeginDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@IsOnAir", 0);
                    cmd.Parameters.AddWithValue("@StatusCode", 1);
                    
                    cmd.ExecuteNonQuery();

                    con.Close();
                    con.Dispose();
                    cmd.Dispose();

                    result = "SUCCESS_ADDED";

                }

            }

            return result;
        }

        [WebMethod(EnableSession = true)]
        public string deleteSurvey(string SurveyID)
        {

            string result = "NULL";

            if (Session["UserID"] != null && Session["LoggedUser"] != null)
            {

                if (Convert.ToBoolean(Session["LoggedUser"].ToString()) == true)
                {

                    SqlConnection con = DB.getNewConnection();
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Update tblSurveyDefinition Set StatusCode=0 Where SurveyID=" + SurveyID, con);
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
        public string addSurvey(string surveyTitle)
        {
            string result = "SUCCESS_ADDED";

            
            if (surveyTitle != "")
            {
                

                SqlCommand cmd = new SqlCommand("Insert Into table(title) Values(@title)", DB.getNewConnection());

                cmd.Parameters.AddWithValue("@title", surveyTitle);

                cmd.ExecuteNonQuery();
                
                result = "SUCCESS_ADDED";

            }
            else {

                result = "ERROR_NULL_SURVEY_TITLE";

            }
             

            return result;
        }
    }
}

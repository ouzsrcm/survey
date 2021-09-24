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
    /// Summary description for Questions
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Questions : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string getAnswerSlider(string QuestionID)
        {

            string result = "";

            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(@"Select * From tblSurveyQuestionAnswer 
                                    as tsqa Where tsqa.QuestionID=" + QuestionID + " And tsqa.StatusCode=1", con);

            DataTable dt = new DataTable();

            dt = DB.toDT(cmd);

            con.Close();
            con.Dispose();
            cmd.Dispose();

            if (dt != null)
            {

                result = JsonConvert.SerializeObject(dt);

            }
            else
            {
                result = "NULL";
            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string getAnswersSingleSelect(string QuestionID)
        {

            string result = "";

            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(@"Select * From tblSurveyQuestionAnswer 
                                    as tsqa Where tsqa.QuestionID=" + QuestionID + " And tsqa.StatusCode=1", con);

            DataTable dt = new DataTable();

            dt = DB.toDT(cmd);

            con.Close();
            con.Dispose();
            cmd.Dispose();

            if (dt != null)
            {

                result = JsonConvert.SerializeObject(dt);

            }
            else
            {
                result = "NULL";
            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string getAnswersMultiSelect(string QuestionID)
        {

            string result = "";

            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(@"Select * From tblSurveyQuestionAnswer 
                                    as tsqa Where tsqa.QuestionID=" + QuestionID + " And tsqa.StatusCode=1", con);

            DataTable dt = new DataTable();

            dt = DB.toDT(cmd);

            con.Close();
            con.Dispose();
            cmd.Dispose();

            if (dt != null)
            {

                result = JsonConvert.SerializeObject(dt);

            }
            else
            {
                result = "NULL";
            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string getAnswersFreeText(string QuestionID) {

            string result = "";

            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(@"Select * From tblSurveyQuestionAnswer 
                                    as tsqa Where tsqa.QuestionID=" + QuestionID, con);

            DataTable dt = new DataTable();

            dt = DB.toDT(cmd);

            con.Close();
            con.Dispose();
            cmd.Dispose();

            if (dt != null)
            {

                result = JsonConvert.SerializeObject(dt);

            }
            else
            {
                result = "NULL";
            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string getQuestionDetails(string QuestionID) {

            string result = "";

            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand(@"Select tq.Question, tat.AnswerType, tc.Category, tc.CategoryID, tat.AnswerTypeID From tblQuestion as tq 
                                            Inner Join tblCategory as tc On tq.CategoryID = tc.CategoryID 
                                            Inner Join tblAnswerType as tat On tat.AnswerTypeID = tq.AnswerTypeID 
                                        Where tq.QuestionID=" + QuestionID, con);

            DataTable dt = new DataTable();

            dt = DB.toDT(cmd);

            con.Close();
            con.Dispose();
            cmd.Dispose();

            if (dt != null)
            {

                result = JsonConvert.SerializeObject(dt);

            }
            else
            {
                result = "NULL";
            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string addNewQuestion(string Title, string CategoryID, string AnswerTypeID)
        {

            string result = "";
            string sql = "";
            if (Title != "")
            {
                SqlConnection con = DB.getNewConnection();
                con.Open();

                sql = "Insert Into tblQuestion(CompanyID, UserID, CategoryID, Question, AnswerTypeID, StatusCode) ";
                sql += "Values(@CompanyID, @UserID, @CategoryID, @Question, @AnswerTypeID, @StatusCode)";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@CompanyID", Session["UserCompanyID"].ToString());
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@Question", Title);
                cmd.Parameters.AddWithValue("@AnswerTypeID", AnswerTypeID);
                cmd.Parameters.AddWithValue("@StatusCode", 1);

                cmd.ExecuteNonQuery();

                con.Close();
                con.Dispose();
                cmd.Dispose();

                result = "SUCCESS";

            }
            else {
                result = "NULL";
            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string AnswerTypesList() {

            string result = "";

            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * From tblAnswerType", con);

            DataTable dt = new DataTable();

            dt = DB.toDT(cmd);

            con.Close();
            con.Dispose();
            cmd.Dispose();

            if (dt != null)
            {

                result = JsonConvert.SerializeObject(dt);

            }
            else
            {
                result = "NULL";
            }

            return result;

        }

        [WebMethod(EnableSession = true)]
        public string List()
        {
            string result = "";

            DataTable dt = new DataTable();
            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * From tblQuestion Where StatusCode=1", con);
            dt = DB.toDT(cmd);

            if (dt != null) {

                result = JsonConvert.SerializeObject(dt);

            }

            con.Close();
            con.Dispose();
            cmd.Dispose();

            return result;
        }

        [WebMethod(EnableSession = true)]
        public string ListByCategory(int CategoryID)
        {
            string result = "";

            DataTable dt = new DataTable();
            SqlConnection con = DB.getNewConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * From tblQuestion Where StatusCode=1 And CategoryID=" + CategoryID, con);
            dt = DB.toDT(cmd);

            if (dt != null)
            {

                result = JsonConvert.SerializeObject(dt);

            }

            con.Close();
            con.Dispose();
            cmd.Dispose();

            return result;
        }

    }
}

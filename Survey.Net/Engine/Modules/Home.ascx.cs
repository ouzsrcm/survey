using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Survey.Net.Engine.Modules
{
    public partial class Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["LoggedUser"] != null) && 
                    ( Convert.ToBoolean(Session["LoggedUser"].ToString()) == true )) {

                    currUserID.Value = Convert.ToString(Session["UserID"]);
                    currUserCompanyID.Value = Convert.ToString(Session["UserCompanyID"]);

            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Survey.Net
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoggedUser"] != null)
            {
                general.Controls.Add(LoadControl("Engine/Modules/Home.ascx"));
            } else {
                general.Controls.Add(LoadControl("Engine/Modules/Login.ascx"));
            }

        }
    }
}
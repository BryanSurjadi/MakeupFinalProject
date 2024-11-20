using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views
{
    public partial class TesBos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userRole"] == null && Request.Cookies["MakeupFinalProjectLogin"] == null)
            {
                Response.Redirect("~/Views/ProfileViews/Login.aspx");
            }

        }
    }
}
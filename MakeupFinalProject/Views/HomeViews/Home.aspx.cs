using MakeupFinalProject.Controller;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.HomeViews
{
    public partial class Home : System.Web.UI.Page
    {
        public List<User> users = null;
        UserController controller = new UserController(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            users = controller.getAllUser();
            HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];

            if (Session["UserRole"] == null && cok == null)
            {
                Response.Redirect("~/Views/ProfileViews/Login.aspx");
            }
            else if (cok != null)
            {
                string user = cok["username"];
                var ret = controller.GetUser(user);
                Session["Username"] = user;
                Session["UserRole"] = ret.UserRole;
                if (ret.UserRole != "admin")
                {
                    Response.Redirect("~/Views/ProfileViews/Login.aspx");
                }
            }
            else if (Session["UserRole"] != null)
            {
                string ifRole = Session["UserRole"].ToString();
                if (ifRole != "admin")
                {
                    // Redirect to login if not an admin
                    Response.Redirect("~/Views/ProfileViews/Login.aspx");
                }

            }
            if (Session["Username"] == null)
            {
                Response.Redirect("~/Views/ProfileViews/Login.aspx");
            }

            if (!IsPostBack)
            {
                
                userView.DataSource= users;
                userView.DataBind();
                string displayName = Session["Username"].ToString();
                string displayRole = Session["UserRole"].ToString();
                nameLbl.Text = displayName;
                roleLbl.Text = displayRole;

            }
        

        }
    }
}
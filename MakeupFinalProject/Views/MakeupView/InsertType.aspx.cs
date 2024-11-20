using MakeupFinalProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.MakeupView
{
    public partial class InsertType : System.Web.UI.Page
    {
        int typeid;
        UserController userControl = new UserController();
        TypeController typeControl = new TypeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];

            if (Session["Username"] == null && cok == null)
            {
                Response.Redirect("~/Views/ProfileViews/Login.aspx");
            }
            else if (Session["Username"] != null)
            {
                if (Session["UserRole"].ToString() == "customer")
                {
                    Response.Redirect("~/Views/MakeupView/OrderMakeup.aspx");
                }
            }
            else if (cok != null)
            {
                var x = userControl.GetUser(cok["username"]);
                if (x.UserRole == "customer")
                {
                    Response.Redirect("~/Views/MakeupView/OrderMakeup.aspx");
                }
            }

            if (!IsPostBack)
            {

           

            }
        }

   

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
           errorLbl.Text =  typeControl.insert(name);
            errorLbl.Text = "succesfull";
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakeupView/ManageMakeup.aspx");
        }
    }
}
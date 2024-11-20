using MakeupFinalProject.Controller;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.ProfileViews
{
    public partial class Register : System.Web.UI.Page
    {
        UserController controler = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] != null)
            {
                redirectUser(Session["userRole"].ToString());
            }else
            {
                HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];
                if (cok != null)
                {
                    string username = cok["username"];
                    var x = controler.GetUser(username);
                    if (x != null)
                    {
                        Session["UserRole"] = x.UserRole;
                        redirectUser(Session["UserRole"].ToString());
                    }
                }
            }
            if (!IsPostBack) { }
        }

        private void redirectUser(string role)
        {
            if(role == "admin")
            {
                Response.Redirect("~/Views/HomeViews/Home.aspx");
            }
            else if(role == "customer")
            {
                Response.Redirect("~/Views/MakeupView/OrderMakeup.aspx");
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string email = emailTxt.Text;
            string gender = genderList.SelectedValue;
            string password = passTxt.Text;
            string confirmPas= confirmPassTxt.Text;
            DateTime dob = dobCalendar.SelectedDate;

            errorTxt.Text = controler.register(username, email,dob, gender, password, confirmPas);
            if (string.IsNullOrEmpty(errorTxt.Text))
            {
                Session["Username"] = username;
                Session["UserRole"] = "customer";
                Response.Redirect("~/Views/MakeupView/ManageMakeup.aspx");
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfileViews/Login.aspx");
        }
    }
}
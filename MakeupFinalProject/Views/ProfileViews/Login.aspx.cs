
using MakeupFinalProject.Controller;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.ProfileViews
{
    public partial class Login : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["MakeupFinalProjectLogin"];
                if (cookie != null)
                {
                    string username = cookie["username"].ToLower();


                    System.Diagnostics.Debug.WriteLine("Cookie Username: " + username);

                    User checkUser = userController.GetUser(username);

                    if (checkUser != null)
                    {

                        Session["UserRole"] = checkUser.UserRole;
                        System.Diagnostics.Debug.WriteLine("User Role: " + checkUser.UserRole);
                        if (string.Equals(checkUser.UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            Response.Redirect("~/Views/HomeViews/Home.aspx");
                        }
                        else if (string.Equals(checkUser.UserRole, "Customer", StringComparison.OrdinalIgnoreCase))
                        {
                            Response.Redirect("~/Views/MakeupView/OrderMakeup.aspx");
                        }
                    }



                }
            }



        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passTxt.Text;

            bool remem = isRemember.Checked;

            errorLbl.Text = userController.login(username, password);

            User toLogin = null;
            if (string.IsNullOrEmpty(errorLbl.Text))
            {
                toLogin = userController.GetUser(username);
            }
            
            
            if (toLogin != null)
            {
                if (remem)
                {
                    HttpCookie cookie = new HttpCookie("MakeupFinalProjectLogin");
                    cookie["username"] = toLogin.Username;
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);

                    System.Diagnostics.Debug.WriteLine("Cookie Set: " + cookie["username"] + " " + cookie["password"]);
                }

                Session["UserRole"] = toLogin.UserRole;
                Session["Username"] = toLogin.Username;
                if (toLogin.UserRole == "admin")
                {
                    Response.Redirect("~/Views/HomeViews/Home.aspx");
                }
                else if (toLogin.UserRole == "customer")
                {
                    Response.Redirect("~/Views/MakeupView/OrderMakeup.aspx");
                }

            }

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfileViews/Register.aspx");
        }
    }
}
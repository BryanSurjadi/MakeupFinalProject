using MakeupFinalProject.Controller;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.ProfileViews
{
    public partial class Profile : System.Web.UI.Page
    {
        UserController control = new UserController();
        User toUpdate = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];
            if (!IsPostBack)
            {
                if (Session["Username"] == null && cok == null)
                {
                    Response.Redirect("~/Views/ProfileViews/Login.aspx");
                }
                else
                {
                    insertToUpdate(cok);
                    if (toUpdate != null)
                    {
                        loadUserData(toUpdate.Username);
                    }
                    else
                    {
                        Response.Redirect("~/Views/ProfileViews/Login.aspx");
                    }
                }
            }
        }

        protected void insertToUpdate(HttpCookie cok)
        {
            if (Session["Username"] != null)
            {
                toUpdate = control.GetUser(Session["Username"].ToString());
                

            }
            else if (cok != null)
            {
                toUpdate = control.GetUser(cok["username"]);
                
            }
        }

        protected void loadUserData(string username) {
            List<String> x = control.getGender();
            User toEdit= control.GetUser(username);
            if (toEdit != null) 
            {
                usernameTxt.Text = toEdit.Username;
                emailTxt.Text = toEdit.UserEmail;
                genderList.SelectedValue = toEdit.UserGender;
                dobCalendar.SelectedDate = toEdit.UserDOB;
                genderList.DataSource = x;
                genderList.DataBind();
                dobCalendar.DataBind();
            }
            else
            {
                errorLbl.Text = "User not found."; 
            }
        }

        
        protected void updateBtn_Click(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];
            string uname = usernameTxt.Text;
            string email = emailTxt.Text;
            string gender = genderList.SelectedValue;
            DateTime dobh = dobCalendar.SelectedDate;
            insertToUpdate(cok);
            if (toUpdate != null)
            {
                int forUpdate = toUpdate.UserID;
                errorLbl.Text = control.update(forUpdate, uname, email, gender, dobh);

                if (string.IsNullOrEmpty(errorLbl.Text))
                {
                    Session["Username"] = uname;
                    if (cok != null)
                    {
                        cok["username"] = uname;
                        cok.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Set(cok);
                    }
                    errorLbl.Text = "Update Successful";
                    loadUserData(uname);
                }
            }
            else
            {
                Response.Redirect("~/Views/ProfileViews/Login.aspx");
            }
        }

        protected void updatePasswordBtn_Click(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];
            string oldPassword = oldPasswordTxt.Text;
            string newPassword = newPasswordTxt.Text;
            insertToUpdate(cok);

            if (toUpdate != null && toUpdate.UserPassword == oldPassword)
            {
                passwordErrorLbl.Text=control.changePass(toUpdate.UserID,oldPassword, newPassword);
                if (string.IsNullOrEmpty(passwordErrorLbl.Text))
                {
                    passwordErrorLbl.Text = "Password updated successfully";
                    if (cok != null)
                    {
                        cok["password"] = newPassword;
                        cok.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cok);
                    }
                }   
            }
            else
            {
                passwordErrorLbl.Text = "Old password is incorrect";
            }
        }

    }
}
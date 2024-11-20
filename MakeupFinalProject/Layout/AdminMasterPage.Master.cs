using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Layout
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        UserRepository repo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["UserRole"] != null)
                {
                    string role = Session["UserRole"].ToString();
                    setVisible(role);
                }
                
                else
                {
                    Response.Redirect("~/Views/ProfileViews/Login.aspx");
                }

            }
        }

        private void setVisible(string currRole)
        {
            if (currRole == "admin")
            {
                AdminNav.Visible = true;
                CustomerNav.Visible = false;
            }
            else if (currRole == "customer")
            {
                AdminNav.Visible = false;
                CustomerNav.Visible = true;
            }
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomeViews/Home.aspx");
        }

        protected void adminTransactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionViews/TransactionHistory.aspx");
        }

        protected void adminProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfileViews/Profile.aspx");
        }

        protected void manageMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakeupView/ManageMakeup.aspx");
        }

        protected void orderQueueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionViews/HandleTransaction.aspx");
        }

        protected void transactionReportBtn_Click(object sender, EventArgs e)
        {

        }

        protected void adminLogoutButton_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["MakeupFinalProjectLogin"] != null)
            {
                HttpCookie cookie = Request.Cookies["MakeupFinalProjectLogin"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/ProfileViews/Login.aspx");

        }

        protected void orderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakeupView/OrderMakeup.aspx");
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfileViews/Profile.aspx");
        }

        protected void transactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionViews/TransactionHistory.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["MakeupFinalProjectLogin"] != null)
            {
                HttpCookie cookie = Request.Cookies["MakeupFinalProjectLogin"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/ProfileViews/Login.aspx");
        }
    }
}
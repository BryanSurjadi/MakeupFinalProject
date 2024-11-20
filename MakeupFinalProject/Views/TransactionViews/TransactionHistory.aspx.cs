using MakeupFinalProject.Controller;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.TransactionViews
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        UserController userControl = new UserController();
        TransactionHeaderController thControl = new TransactionHeaderController();
        List<TransactionHeader> transList = null;
        User owner=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];
            if (Session["Username"] == null && cok == null)
            {
                Response.Redirect("~/Views/ProfileViews/Login.aspx");
            }else if (Session["UserRole"] != null)
            {
                string uname = Session["Username"].ToString();
                owner = userControl.GetUser(uname);
            }else if (cok != null)
            {
                string uname = cok["username"];
                owner = userControl.GetUser(uname);
            }
            LoadList(owner.UserRole);
        }

        protected void LoadList(string role)
        {
            if(role == "admin")
            {
                transList  = thControl.getAll();
                transactionView.DataSource = transList;
                transactionView.DataBind();
            }
            else if(role == "customer")
            {
                int id = owner.UserID;
                transList = thControl.getFromID(id);
                transactionView.DataSource = transList;
                transactionView.DataBind();
            }
        }

        protected void transactionView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = transactionView.Rows[rowIndex];
                int transactionId = Convert.ToInt32(row.Cells[0].Text);

                Response.Redirect($"~/Views/TransactionViews/TransactionDetails.aspx?transactionId={transactionId}");
            }
        }
    }
}
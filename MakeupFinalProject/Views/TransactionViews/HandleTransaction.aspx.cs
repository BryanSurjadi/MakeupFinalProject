﻿using MakeupFinalProject.Controller;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.TransactionViews
{
    public partial class HandleTransaction : System.Web.UI.Page
    {
        UserController userControl = new UserController();
        TransactionHeaderController thControl = new TransactionHeaderController(); 
        List<TransactionHeader> transList = null;
        User owner = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];
            if (Session["Username"] == null && cok == null)
            {
                Response.Redirect("~/Views/ProfileViews/Login.aspx");
            }
            else if (Session["UserRole"] != null)
            {
                string urole = Session["UserRole"].ToString();
                if(urole == "customer")
                {
                    Response.Redirect("~/Views/MakeupView/OrderMakeup.aspx");
                }
            }
            else if (cok != null)
            {
                string uname = cok["username"];
                owner = userControl.GetUser(uname);
                if(owner.UserRole == "customer")
                {
                    Response.Redirect("~/Views/MakeupView/OrderMakeup.aspx");
                }
            }
            LoadList();
        }

        protected void LoadList()
        {
                transList = thControl.getAll();
                transactionView.DataSource = transList;
                transactionView.DataBind();  
        }

        protected void transactionView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "handleTransaction")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = transactionView.Rows[rowIndex];
                int transactionId = Convert.ToInt32(row.Cells[0].Text);
                thControl.update(transactionId);
                LoadList();
                
            }
        }
    }
}

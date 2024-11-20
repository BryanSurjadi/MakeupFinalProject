using MakeupFinalProject.Controller;
using MakeupFinalProject.Models;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.TransactionViews
{
    public partial class TransactionDetails : System.Web.UI.Page
    {
        UserController userControl = new UserController();
        TransactionHeaderController thControler = new TransactionHeaderController();
        TransactionDetailController tdControler = new TransactionDetailController();
        private User currentUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];
                User currentUser = null;

                if (Session["Username"] != null)
                {
                    currentUser = userControl.GetUser(Session["Username"].ToString());
                }
                else if (cok != null)
                {
                    currentUser = userControl.GetUser(cok["username"]);
                }

                if (currentUser != null && Request.QueryString["TransactionID"] != null)
                {
                    int transactionId;
                    if (int.TryParse(Request.QueryString["TransactionID"], out transactionId))
                    {
                        LoadTransactionDetails(transactionId, currentUser);
                    }
                    else
                    {
                        Response.Redirect("~/Views/TransactionViews/TransactionHistory.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/TransactionViews/TransactionHistory.aspx");
                }
            }
        }

        private void LoadTransactionDetails(int transactionId, User currentUser)
        {
            TransactionHeader header = thControler.getFromTransactionID(transactionId);
            if (header == null || (currentUser.UserRole != "admin" && header.UserID != currentUser.UserID))
            {
                Response.Redirect("~/Views/TransactionViews/TransactionHistory.aspx");
            }

            lblTransactionID.Text = $"Transaction ID: {header.TransactionID}";
            lblUsername.Text = $"Username: {userControl.getUserFromID(header.UserID).Username}";
            lblTransactionDate.Text = $"Transaction Date: {header.TransactionDate.ToShortDateString()}";
            lblStatus.Text = $"Status: {header.Status}";

            var details = tdControler.getByTransactionId(transactionId);
            var detailViewModels = details.Select(d => new
            {
                d.Makeup.MakeupName,
                d.Quantity,
                d.Makeup.MakeupPrice,
                TotalPrice = d.Quantity * d.Makeup.MakeupPrice
            }).ToList();

            transactionDetailsView.DataSource = detailViewModels;
            transactionDetailsView.DataBind();
        }
    }
}
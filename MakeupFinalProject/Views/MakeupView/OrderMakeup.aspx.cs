using MakeupFinalProject.Controller;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.MakeupView
{
    public partial class OrderMakeup : System.Web.UI.Page
    {
        public List<Makeup> makeups = null;
        public List<Cart> carts = null;
        UserController userControl = new UserController();
        MakeupController makeupControl = new MakeupController();
        CartController cartControl = new CartController();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cok = Request.Cookies["MakeupFinalProjectLogin"];

            if (Session["UserRole"] == null && cok == null)
            {
                Response.Redirect("~/Views/ProfileViews/Login.aspx");
            }
            else if (cok != null)
            {
                string user = cok["username"];
                var ret = userControl.GetUser(user);
                Session["Username"] = user;
                Session["UserRole"] = ret.UserRole;
                if (ret.UserRole != "customer")
                {
                    Response.Redirect("~/Views/ProfileViews/Login.aspx");
                }
            }
            else if (Session["UserRole"] != null && Session["Username"] != null)
            {
                string ifRole = Session["UserRole"].ToString();
                if (ifRole != "customer" || Session["Username"] == null)
                {
                    Response.Redirect("~/Views/ProfileViews/Login.aspx");
                }


            }
            if (!IsPostBack)
            {
                LoadMakeupList();
                LoadCartList(); 
            }
        }

        private void LoadMakeupList()
        {
            makeups = makeupControl.GetMakeups();
            MakeupList.DataSource = makeups;
            MakeupList.DataBind();
        }

        private void LoadCartList()
        {
            int id = getUserId();
            carts = cartControl.getCart(id);
            CartList.DataSource = carts;
            CartList.DataBind();
        }

        private int getUserId()
        {
            String x = Session["Username"].ToString();
            int id = userControl.getIdFromUsername(x);
            return id;
        }

        protected void MakeupList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = MakeupList.Rows[rowIndex-1];
                int makeupId = Convert.ToInt32(row.Cells[0].Text);
                TextBox quan = (TextBox)row.FindControl("QuantityTextBox");
                int qty = Convert.ToInt32(quan.Text);
                //no idea gmn bs jalan 
                cartLbl.Text = makeupId.ToString();
                cartLbl2.Text = qty.ToString();
                int userId = getUserId();
                errorLbl.Text =  cartControl.addToCart(userId, makeupId, qty);
                if (string.IsNullOrEmpty(errorLbl.Text))
                {
                    LoadCartList();
                }
            }   
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            int x = getUserId();
            cartControl.deleteCart(x);
            LoadCartList() ;
        }

        protected void coBtn_Click(object sender, EventArgs e)
        {
            int x = getUserId() ;
            cartControl.checkout(x);
            LoadCartList() ;
        }
    }
}

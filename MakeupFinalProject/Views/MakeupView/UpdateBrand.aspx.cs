using MakeupFinalProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.MakeupView
{
    public partial class UpdateBrand : System.Web.UI.Page
    {
        int brandid;
        UserController userControl = new UserController();
        BrandController brandControl = new BrandController();
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

                bool res = int.TryParse(Request.QueryString["brandid"], out brandid);
                if (res)
                {
                    ViewState["brandID"] = brandid;
                    loadData(brandid);
                }
                else
                {
                    Response.Redirect("~/Views/MakeupView/ManageMakeup.aspx");
                }

            }
        }

        protected void loadData(int id)
        {
            var x = brandControl.getBrandFromID(id);
            nameTxt.Text = x.MakeupBrandName;
            rateTxt.Text = x.MakeupBrandRating.ToString();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = (int)ViewState["brandID"];
            string name = nameTxt.Text;
            int rating = 0;
            if(rateTxt.Text != "")
            {
                rating = Convert.ToInt32(rateTxt.Text);
            }
            errorLbl.Text = brandControl.update(id, name,rating);
            if (string.IsNullOrEmpty(errorLbl.Text))
            {
                loadData(id);
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakeupView/ManageMakeup.aspx");
        }
    }
}
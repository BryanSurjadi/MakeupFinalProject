using MakeupFinalProject.Controller;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace MakeupFinalProject.Views.MakeupView
{
    public partial class UpdateMakeup : System.Web.UI.Page
    {
        int makeupid;
        UserController userControl = new UserController();
        MakeupController makeupControl = new MakeupController();
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

                bool res = int.TryParse(Request.QueryString["MakeupID"], out makeupid);
                if (res)
                {
                    ViewState["MakeupID"] = makeupid;
                    loadData(makeupid);
                }
                else {
                    Response.Redirect("~/Views/MakeupView/ManageMakeup.aspx");
                }

            }

        }

        protected void loadData(int id)
        {
            var x = makeupControl.getMakeupFromID(id);
            nameTxt.Text = x.MakeupName;
            priceTxt.Text = x.MakeupPrice.ToString();
            weightTxt.Text = x.MakeupWeight.ToString();
            typeTxt.Text = x.MakeupTypeID.ToString();
            brandTxt.Text = x.MakeupBrandID.ToString();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = (int)ViewState["MakeupID"];
            string name = nameTxt.Text;
            int price = -1;
            int weight = -1;
            int typeid = -1;
            int brandid = -1;
            if (priceTxt.Text != "")
            {
                price = Convert.ToInt32(priceTxt.Text);
            }
            if (weightTxt.Text != "")
            {
                weight = Convert.ToInt32(weightTxt.Text);
            }
            if (typeTxt.Text != "")
            {
                typeid = Convert.ToInt32(typeTxt.Text);
            }
            if (brandTxt.Text != "")
            {
                brandid = Convert.ToInt32(brandTxt.Text);
            }

            errorLbl.Text = makeupControl.updateMakeup(id,name, price, weight, typeid, brandid);
            if (string.IsNullOrEmpty(errorLbl.Text))
            {
                errorLbl.Text = "Successfully Updated";
                loadData(id);
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakeupView/ManageMakeup.aspx");
        }
    }
}
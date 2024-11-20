using MakeupFinalProject.Controller;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.MakeupView
{
    public partial class UpdateType : System.Web.UI.Page
    {
        int typeid;
        UserController userControl = new UserController();
        TypeController typeController = new TypeController();
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

                bool res = int.TryParse(Request.QueryString["typeid"], out typeid);
                if (res)
                {
                    ViewState["typeID"] = typeid;
                    loadData(typeid);
                }
                else
                {
                    Response.Redirect("~/Views/MakeupView/ManageMakeup.aspx");
                }

            }
        }

        protected void loadData(int id)
        {
            var x = typeController.getTypeFromID(id);
            nameTxt.Text = x.MakeupTypeName;
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = (int)ViewState["typeID"];
            string name = nameTxt.Text;
            errorLbl.Text =  typeController.updateType(id, name);
            loadData(id);
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakeupView/ManageMakeup.aspx");
        }
    }

}
using MakeupFinalProject.Controller;
using MakeupFinalProject.Models;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeupFinalProject.Views.MakeupView
{
    public partial class ManageMakeup : System.Web.UI.Page
    {
        public List<Makeup> makeups = null;
        public List<MakeupBrand> brands = null;
        public List<MakeupType> types = null;

        BrandController brandControl = new BrandController();
        MakeupController makeupControl = new MakeupController();
        UserController userControl = new UserController();  
        TypeController typeControl = new TypeController();
        
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
               

                loadStuff();

            }
        }

        protected void loadStuff()
        {
            makeups = makeupControl.GetMakeups();
            makeupList.DataSource = makeups;
            makeupList.DataBind();

            types = typeControl.getAllTypes();
            typeList.DataSource = types;
            typeList.DataBind();

            brands = brandControl.getAllBrands();
            brandList.DataSource = brands;
            brandList.DataBind();

        }

        protected void makeupList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow rows = makeupList.Rows[e.NewEditIndex];
            int MakeupID = Convert.ToInt32(rows.Cells[0].Text);
            Response.Redirect($"~/Views/MakeupView/UpdateMakeup.aspx?MakeupID={MakeupID}");
        }

        protected void makeupList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = makeupList.Rows[e.RowIndex];
            int MakeupID = Convert.ToInt32(rows.Cells[0].Text);
            makeupControl.deleteMakeup(MakeupID);
            loadStuff();
        }

        protected void typeList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow rows = typeList.Rows[e.NewEditIndex];
            int typeid = Convert.ToInt32(rows.Cells[0].Text);
            Response.Redirect($"~/Views/MakeupView/UpdateType.aspx?typeid={typeid}");
        }

        protected void typeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = typeList.Rows[e.RowIndex];
            int typeid = Convert.ToInt32(rows.Cells[0].Text);
            typeControl.delete(typeid);
            loadStuff();
        }

        protected void brandList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow rows = brandList.Rows[e.NewEditIndex];
            int brandid = Convert.ToInt32(rows.Cells[0].Text);
            Response.Redirect($"~/Views/MakeupView/UpdateBrand.aspx?brandid={brandid}");
        }

        protected void brandList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = brandList.Rows[e.RowIndex];
            int brandid = Convert.ToInt32(rows.Cells[0].Text);
            brandControl.delete(brandid);
            loadStuff();
        }

        protected void insertBrandBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakeupView/InsertBrand.aspx");
        }

        protected void insertMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakeupView/InsertMakeup.aspx");
        }

        protected void insertTypeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/MakeupView/InsertType.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace Project_ECommerce
{
    public partial class AddEditCategory : System.Web.UI.Page
    {
        CategoryClass objbll = new CategoryClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = objbll.CategoryList();
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();
            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Insert(0, new ListItem("No Categories Available", "0"));
            }
            else
            {
                DropDownList1.Items.Insert(0, new ListItem("-- Select Category --", ""));
            }
        }
    }
}
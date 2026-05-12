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
    public partial class UserHomePage : System.Web.UI.Page
    {
        CategoryClass objbll = new CategoryClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = objbll.ShowAvailableCategories();
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
            
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int catid = Convert.ToInt32(e.CommandArgument);
            Session["CategoryId"] = catid;
            Response.Redirect("ViewProducts.aspx");
        }
    }
}
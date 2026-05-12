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
    public partial class ViewProducts : System.Web.UI.Page
    {
        ProductClass objbll = new ProductClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int catid = Convert.ToInt32(Session["CategoryId"]);
                DataSet ds = objbll.ShowAvailableProducts(catid);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
            
        }
    }
}
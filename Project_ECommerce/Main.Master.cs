using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_ECommerce
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null)
                {
                    string role = Session["Role"].ToString();

                    if (role == "Admin")
                    {
                        lnkHome.NavigateUrl = "/AdminHomePage.aspx";
                    }
                    else if (role == "User")
                    {
                        lnkHome.NavigateUrl = "/UserHomePage.aspx";
                    }
                }
            }
        }
    }
}
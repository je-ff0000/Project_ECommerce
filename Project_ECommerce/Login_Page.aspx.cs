using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Project_ECommerce
{
    public partial class Login_Page : System.Web.UI.Page
    {
        LoginClass objbll = new LoginClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cid = objbll.GetCountId(TextBox1.Text, TextBox2.Text);
            if (cid == "1")
            {
                string id = objbll.GetId(TextBox1.Text, TextBox2.Text);
                Session["uid"] = id;
                string role = objbll.UserOrAdmin(Convert.ToInt32(id));
                Label1.Text = role;

                if (role == "admin")
                {
                    Response.Redirect("Admin_Homepage.aspx");
                }

                else if (role == "user")
                {
                    Response.Redirect("User_Homepage.aspx");
                }
            }

            else
            {
                Label1.Text = "Invalid username or password";
            }

        }
    }
}
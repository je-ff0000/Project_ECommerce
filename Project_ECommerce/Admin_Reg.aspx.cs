using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BLL;

namespace Project_ECommerce
{
    public partial class Admin_Reg : System.Web.UI.Page
    {
        InsertAdminClass objbll = new InsertAdminClass();
        EmailClass obj2 = new EmailClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string cid = obj2.Check_Email(TextBox2.Text, "admin");

            if (cid == "1")
            {
                Label1.Visible = true;
                Label1.Text = "Please choose another email";
            }

            else
            {
                Label1.Visible = false;
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string maxregid = objbll.CheckMaxRegID();
            int reg_id;
            if (maxregid == "")
            {
                reg_id = 1;
            }

            else
            {
                int newregid = Convert.ToInt32(maxregid);
                reg_id = newregid + 1;
            }

            int i = objbll.InsertAdminDB(reg_id, TextBox1.Text, TextBox2.Text, TextBox3.Text);

            if (i == 1)
            {
                Label2.Text = "Inserted";
            }
        }
    }
}
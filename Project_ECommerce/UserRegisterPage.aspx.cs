using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Project_ECommerce
{
    public partial class UserRegisterPage : System.Web.UI.Page
    {
        EmailClass obj2 = new EmailClass();
        InsertUserClass objbll = new InsertUserClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string cid = obj2.Check_Email(TextBox2.Text, "user");

            if (cid == "1")
            {
                Label2.Visible = true;
                Label2.Text = "Please choose another email";
            }

            else
            {
                Label2.Visible = false;
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

            int i = objbll.InsertUserDB(reg_id, TextBox1.Text, TextBox2.Text, TextBox3.Text, Convert.ToInt64(TextBox4.Text), TextBox5.Text, TextBox6.Text);

            if (i == 1)
            {
                Label1.Text = "Inserted";
            }
        }
    }
}
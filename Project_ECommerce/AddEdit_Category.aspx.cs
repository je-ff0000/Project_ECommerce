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
    public partial class Add_Category : System.Web.UI.Page
    {
        CategoryClass objbll = new CategoryClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = objbll.ShowCategories();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "~/Category_Photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));
            int i = objbll.AddCategory(TextBox1.Text, s, TextBox2.Text, TextBox3.Text);

            if (i == 1)
            {
                Label1.Text = TextBox1.Text + " Added";
            } 
        }
    }
}
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
            if (!IsPostBack)
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
                    DropDownList1.Items.Insert(0, new ListItem("-- No Parent (Top Level) --", ""));
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                Label1.Visible = true;
                Label1.Text = "Upload Image";
            }

            else
            {
                string path = "~/Category_Photos/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(path));
                int i = objbll.AddCategory(TextBox1.Text, path, TextBox2.Text, DropDownList1.SelectedItem.Value);
                if (i == 1)
                {
                    Label2.Visible = true;
                    Label2.Text = "Inserted successfully";
                }
            }
        }
    }
}
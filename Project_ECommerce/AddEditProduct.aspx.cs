using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using BLL;

namespace Project_ECommerce
{
    public partial class AddEditProduct : System.Web.UI.Page
    {
        CategoryClass objcat = new CategoryClass();
        ProductClass objpro = new ProductClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        public void Bind_Grid()
        {
            int catid = Convert.ToInt32(DropDownList1.SelectedValue);
            DataSet ds = objpro.ShowProducts(catid);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        public void LoadCategories()
        {
            DataSet ds = objcat.CategoryList();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                Label1.Visible = true;
                Label1.Text = "Upload Image";
            }

            else
            {
                string id = DropDownList1.SelectedValue;
                string folderPath = "~/Product_Photos/" + id + "/";
                string physicalPath = Server.MapPath(folderPath);
                if (!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                }
                string fileName = FileUpload1.FileName;
                FileUpload1.SaveAs(physicalPath + fileName);

                string dbPath = folderPath + fileName;
                FileUpload1.SaveAs(physicalPath + fileName);
                int i = objpro.AddProduct(Convert.ToInt32(id) , TextBox1.Text, TextBox2.Text, dbPath, TextBox3.Text, Convert.ToInt32(TextBox4.Text), Convert.ToInt32(TextBox5.Text));
                if (i == 1)
                {
                    Label2.Visible = true;
                    Label2.Text = "Inserted successfully";
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_Grid();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}
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
            int catid = Convert.ToInt32(ViewState["CategoryId"]);
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
                DropDownList2.DataSource = ds.Tables[0];
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "Id";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("-- Select Category --", "0"));
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
            int catid = Convert.ToInt32(DropDownList1.SelectedValue);
            ViewState["CategoryId"] = catid;
            Bind_Grid();
            if (Label2.Visible) {
                Label2.Visible = false;
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Panel1.Visible = true;
            GridViewRow r = GridView1.Rows[e.NewSelectedIndex];
            
            TextBox7.Text = r.Cells[3].Text;
            TextBox8.Text = r.Cells[4].Text;
            TextBox9.Text = r.Cells[5].Text;
            TextBox10.Text = r.Cells[6].Text;
            TextBox11.Text = r.Cells[7].Text;
            Image1.ImageUrl = r.Cells[9].Text;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            ViewState["ProductId"] = id;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string imagePath = Image1.ImageUrl;
            int prodid = Convert.ToInt32(ViewState["ProductId"]);
            int catid = Convert.ToInt32(DropDownList2.SelectedValue);
            
            if (FileUpload2.HasFile)
            {
                string path = "~/Product_Photos/" + catid + "/" + FileUpload2.FileName;
                FileUpload2.SaveAs(MapPath(path));
                imagePath = path;
            }

            int i = objpro.UpdateProduct(catid, TextBox7.Text, TextBox8.Text, TextBox9.Text, Convert.ToInt32(TextBox10.Text), Convert.ToInt32(TextBox11.Text), imagePath, prodid);

            if (i == 1)
            {
                Label3.Visible = true;
                Label3.Text = "Updated";
                Bind_Grid();
            }
        }
    }
}
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

                Bind_Grid();

            }
            
        }

        public void Bind_Grid()
        {
            DataSet ds = objbll.ShowCategories();
            GridView1.DataSource = ds;
            GridView1.DataBind();
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

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Panel1.Visible = true;
            GridViewRow r = GridView1.Rows[e.NewSelectedIndex];
            TextBox5.Text = r.Cells[2].Text;
            TextBox6.Text = r.Cells[4].Text;
            Image1.ImageUrl = r.Cells[3].Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string imagePath = Image1.ImageUrl;

            if (FileUpload2.HasFile)
            {
                string path = "~/Category_Photos/" + FileUpload2.FileName;
                FileUpload2.SaveAs(MapPath(path));
                imagePath = path;
            }
            int id = Convert.ToInt32(ViewState["CategoryId"]);
            int i = objbll.UpdateCategory(TextBox5.Text, TextBox6.Text, imagePath, id);

            if(i == 1)
            {
                Label3.Visible = true;
                Label3.Text = "Updated";
                Bind_Grid();
            }
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            ViewState["CategoryId"] = id;
        }
    }
}
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
    public partial class ViewProduct : System.Web.UI.Page
    {
        ProductClass objbll = new ProductClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int prodid = Convert.ToInt32(Session["ProductId"]);
                SqlDataReader dr = objbll.ShowProductDetails(prodid);
                while (dr.Read())
                {
                    Image1.ImageUrl = dr["Image"].ToString();
                    Label1.Text = dr["Name"].ToString();
                    Label2.Text = dr["Description"].ToString();
                    Label3.Text = dr["Price"].ToString();
                }
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid)
            {
                return;
            }

            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                int enteredQty;
                int prodid = Convert.ToInt32(Session["ProductId"]);
                string stock = objbll.GetStock(prodid);
                int availableStock = Convert.ToInt32(stock);

                if(int.TryParse(TextBox1.Text, out enteredQty))
                {
                    if (enteredQty > availableStock)
                    {
                        Label4.Visible = true;
                        Label4.Text = "Maximum stock available: " + stock;
                        TextBox1.Text = stock;
                    }

                    else
                    {
                        Label4.Text = "";
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int quantity;
            int prodid = Convert.ToInt32(Session["ProductId"]);

            int availableStock = Convert.ToInt32(objbll.GetStock(prodid));

            if (int.TryParse(TextBox1.Text, out quantity))
            {
                if(quantity < availableStock)
                {
                    TextBox1.Text = (quantity + 1).ToString();
                    Label4.Text = "";
                }
                else if(quantity == availableStock)
                {
                    Label4.Visible = true;
                    Label4.Text = "Maximum stock available: " + availableStock.ToString();
                }
                
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int quantity;

            if (int.TryParse(TextBox1.Text, out quantity) && quantity - 1 > 0)
            {
                TextBox1.Text = (quantity - 1).ToString();
                Label4.Text = "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
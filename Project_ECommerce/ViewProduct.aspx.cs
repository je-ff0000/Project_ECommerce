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
        ProductClass objpro = new ProductClass();
        CartClass objcart = new CartClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int prodid = Convert.ToInt32(Session["ProductId"]);
                SqlDataReader dr = objpro.ShowProductDetails(prodid);
                while (dr.Read())
                {
                    Image1.ImageUrl = dr["Image"].ToString();
                    Label1.Text = dr["Name"].ToString();
                    Label2.Text = dr["Description"].ToString();
                    Label3.Text = dr["Price"].ToString();
                }

                dr.Close();
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
                string stock = objpro.GetStock(prodid);
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
                        Button2.Text = "Add To Cart";
                        Button2.BackColor = System.Drawing.Color.FromArgb(255, 52, 59);
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int prodid = Convert.ToInt32(Session["ProductId"]);

            int availableStock = Convert.ToInt32(objpro.GetStock(prodid));

            if (int.TryParse(TextBox1.Text, out int quantity))
            {
                Button2.Text = "Add To Cart";
                Button2.BackColor = System.Drawing.Color.FromArgb(255, 204, 0);

                if (quantity < availableStock)
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
            if (int.TryParse(TextBox1.Text, out int quantity) && quantity - 1 > 0)
            {
                TextBox1.Text = (quantity - 1).ToString();
                Label4.Text = "";
                Button2.Text = "Add To Cart";
                Button2.BackColor = System.Drawing.Color.FromArgb(255, 204, 0);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int prodId = Convert.ToInt32(Session["Productid"]);
            int custId = Convert.ToInt32(Session["RegId"]);
            int quantity = Convert.ToInt32(TextBox1.Text);
            
            int i = objcart.AddItemToCart(prodId, custId, quantity, "Active");

            if(i == 1)
            {
                Button2.Text = "Added To Cart";
                Button2.BackColor = System.Drawing.Color.FromArgb(210, 220, 60);
            }
            else
            {
                Label5.Visible = true;
                Label5.Text = "Couldn't add to cart";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class CartClass
    {
        ConnectionClass objdal = new ConnectionClass();
        ProductClass objpro = new ProductClass();
        public int CheckAvailableCart(int custId)
        {
            string str = "select Id from Carts_Tab where User_Id = " + custId;
            string cid = objdal.Fn_Scalar(str);
            if(cid == null)
            {
                return 0;
            }
            return Convert.ToInt32(cid);
        }

        public string CheckItemExistsForUser(int prodId, int cartId)
        {
            string str = "select count(Id) from CartItems_Tab where Product_Id =" + prodId + " and Cart_Id= " + cartId;
            string i = objdal.Fn_Scalar(str);
            return i;
        }
        public int AddItemToCart(int prodId, int custId, int quantity, string status)
        {
            int cartid = Convert.ToInt32(CheckAvailableCart(custId));
            int subTotal = Convert.ToInt32(objpro.GetPrice(prodId)) * quantity;
            if (cartid > 0)
            {
                string itemExists = CheckItemExistsForUser(prodId, cartid);
                if(itemExists == "1")
                {   
                    string updateQuantity = "update CartItems_Tab set Quantity = " + quantity + ", SubTotal= " + subTotal + " where Product_Id =" + prodId + " and Cart_Id=" + cartid;
                    int i = objdal.Fn_NonQuery(updateQuantity);
                    return i;
                }
                else
                {
                    string insertItem = "insert into CartItems_Tab values(" + custId + "," + cartid + "," + prodId + "," + quantity + "," + subTotal + ",'" + status + "')";
                    int crtInsertSuccess = objdal.Fn_NonQuery(insertItem);
                    return crtInsertSuccess;
                }
            }
            else
            {
                string str = "insert into Carts_Tab values(" + custId + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                int i = objdal.Fn_NonQuery(str);
                cartid = Convert.ToInt32(CheckAvailableCart(custId));
                if (i == 1)
                {
                    string insertItem = "insert into CartItems_Tab values(" + custId + "," + cartid + "," + prodId + "," + quantity + "," + subTotal + ",'" + status + "')";
                    int crtInsertSuccess = objdal.Fn_NonQuery(insertItem);
                    return crtInsertSuccess;
                }
                return i;
            }
        }
    }
}

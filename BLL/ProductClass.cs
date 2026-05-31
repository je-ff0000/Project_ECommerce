using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
   public class ProductClass
    {
        ConnectionClass objdal = new ConnectionClass();

        public int AddProduct(int id, string name, string brand, string image, string desc, int price, int stock)
        {
            string s = "insert into Products_Tab values(" + id + ",'" + name + "','" + brand + "','" + desc + "'," + price + "," + stock + ",'available','" + image +"')";
            int i = objdal.Fn_NonQuery(s);

            return i;
        }

        public DataSet ShowProducts(int id)
        {
            string str = "select * from Products_Tab where Category_Id =" + id;
            DataSet ds = objdal.Fn_exeAdapter(str);

            return ds;
        }

        public DataSet ShowAvailableProducts(int id)
        {
            string str = "select * from Products_Tab where Category_Id =" + id + " and Status = 'available'";
            DataSet ds = objdal.Fn_exeAdapter(str);

            return ds;

        }

        public SqlDataReader ShowProductDetails(int id)
        {
            string str = "select * from Products_Tab where Id =" + id;
            SqlDataReader dr = objdal.Fn_SqlReader(str);
            return dr;
        }

        public string GetStock(int id)
        {
            string str = "select Stock from Products_Tab where Id =" + id;

            string i = objdal.Fn_Scalar(str);
            return i;
        }

        public string GetPrice(int id)
        {
            string str = "select Price from Products_Tab where Id =" + id;
            string i = objdal.Fn_Scalar(str);
            return i;
        }

        public int UpdateProduct(int catid, string name, string brand, string desc, int price, int stock, string image, int prodid)
        {
            string str = "update Products_Tab set Category_Id =" + catid + ", Name = '" + name + "', Brand = '" + brand + "', Description = '" + desc + "', Price =" + price + ", Stock =" + stock + ", Image = '" + image + "' where Id = " + prodid;
            int i = objdal.Fn_NonQuery(str);
            return i;
        }
    }
}

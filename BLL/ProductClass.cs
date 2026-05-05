using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
    }
}

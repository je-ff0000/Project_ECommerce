using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class CategoryClass
    {
        ConnectionClass objdal = new ConnectionClass();

        public int AddCategory(string name, string image, string desc, string parent)
        {
            string s = "insert into Category_Tab values('" + name + "','" + image + "','" + desc + "','" + parent + "','available')";
            int i = objdal.Fn_NonQuery(s);

            return i;
        }

        public DataSet ShowCategories()
        {
            string str = "select Name, Image, Description, Status from Category_Tab";
            DataSet ds = objdal.Fn_exeAdapter(str);

            return ds;
        }
    }
}

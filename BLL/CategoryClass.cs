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
            string str = "select * from Category_Tab";
            DataSet ds = objdal.Fn_exeAdapter(str);

            return ds;
        }

        public DataSet CategoryList()
        {
            string str = "select Id, Name from Category_Tab";
            DataSet ds = objdal.Fn_exeAdapter(str);

            return ds;
        }

        public int UpdateCategory(string name, string desc, string path, int id)
        {
            string str = "update Category_Tab set Name = '" + name + "', Description = '" + desc + "', Image = '" + path + "' where Id = " + id;
            int i = objdal.Fn_NonQuery(str);

            return i;
        }
    }
}

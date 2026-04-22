using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class InsertAdminClass
    {
        public int InsertAdminDB(int regid, string name, string email, string password)
        {
            ConnectionClass objdal = new ConnectionClass();

            string ins = "insert into Admin_Tab values(" + regid + ",'" + name + "','" + email + "','" + password + "')";
            int i = objdal.Fn_NonQuery(ins);

            if (i == 1)
            {
                string inslog = "insert into Login_Tab values(" + regid + ",'" + email + "','" + password + "','admin')";
                int j = objdal.Fn_NonQuery(inslog);
            }
            return i;
        }

        public string CheckMaxRegID()
        {
            ConnectionClass objdal = new ConnectionClass();

            string sel = "select max(Reg_Id) from Login_Tab";
            string maxregid = objdal.Fn_Scalar(sel);

            return maxregid;
        }
    }
}

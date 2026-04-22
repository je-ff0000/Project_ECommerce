using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class InsertUserClass
    {
        ConnectionClass objdal = new ConnectionClass();

        public int InsertUserDB(int id, string username,string email,string password, long phone, string address, string status)
        {
            string ins = "insert into User_Tab values(" + id + ",'" + username + "','" + email + "','" + password + "'," + phone + ",'" + address + "','" +  status + "')";
            int i = objdal.Fn_NonQuery(ins);

            if (i == 1)
            {
                string inslog = "insert into Login_Tab values(" + id + ",'" + email + "','" + password + "', 'user')";
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

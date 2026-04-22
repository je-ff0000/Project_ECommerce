using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class LoginClass
    {
        ConnectionClass objdal = new ConnectionClass();

            public string GetCountId(string una, string pw)
            {
                string str = "select count(Reg_Id) from Login_Tab where Email='" + una + "' and Password='" + pw + "'";
                string cid = objdal.Fn_Scalar(str);
                return cid;
            }

            public string UserOrAdmin(int id)
            {
                string str2 = "select Log_Type from Login_Tab where Reg_Id =" + id;
                string logtype = objdal.Fn_Scalar(str2);

                return logtype;
            }

            public string GetId(string una, string pw)
            {
                string s = "select Reg_Id from Login_Tab where Email='" + una + "' and Password='" + pw + "'";
                string id = objdal.Fn_Scalar(s);
                return id;
            }
    }
}

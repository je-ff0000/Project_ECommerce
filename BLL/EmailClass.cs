using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class EmailClass
    {
        ConnectionClass objdal = new ConnectionClass();

        public string Check_Email(string email, string role)
        {
            if (role == "user")
            {
                string s = "select Count(User_Id) from User_Tab where Email='" + email + "'";
                string cid = objdal.Fn_Scalar(s);
                return cid;
            }

            else if (role == "admin")
            {
                string s = "select Count(Admin_Id) from Admin_Tab where Email='" + email + "'";
                string cid = objdal.Fn_Scalar(s);
                return cid;
            }

            else
                return null;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class ConnectionClass
    {
        SqlConnection con;
        SqlCommand cmd;

        public ConnectionClass()
        {
            con = new SqlConnection(@"server=LAPTOP-FJ6P97JK\SQLEXPRESS;database=Project_ASPNET;Integrated security=true");
        }

        public int Fn_NonQuery(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public string Fn_Scalar(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string i = cmd.ExecuteScalar().ToString();
            con.Close();
            return i;
        }

        public SqlDataReader Fn_SqlReader(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public DataSet Fn_exeAdapter(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable Fn_Exedatatable(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}

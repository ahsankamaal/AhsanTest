using AhsanTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AhsanTest.DataAcess
{
    public class DataAccessLayer
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MyCon"].ToString();
            con = new SqlConnection(constring);
        }

        public List<Product> GetAllProduct()
        {
            connection();
            List<Product> productslist = new List<Product>();
            SqlCommand cmd = new SqlCommand("GetAllProduct", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open(); 
            adapter.Fill(dt);   
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                productslist.Add(new Product
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    Size = Convert.ToString(dr["Size"]),
                    MfgDate = Convert.ToDateTime(dr["MfgDate"]),
                    Category = Convert.ToString(dr["Category"]),
                    Price = Convert.ToDecimal(dr["Price"])


                });
            }
            return productslist;
        }

        public List<Product> Search(string name)
        {
            connection();
            List<Product> productslist = new List<Product>();
            SqlCommand cmd = new SqlCommand("Product_SearchProduct", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            SqlParameter param;
            cmd.CommandType = CommandType.StoredProcedure;
            param = new SqlParameter("@ProductName", name);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);

            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                productslist.Add(new Product
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    Size = Convert.ToString(dr["Size"]),
                    MfgDate = Convert.ToDateTime(dr["MfgDate"]),
                    Category = Convert.ToString(dr["Category"]),
                    Price = Convert.ToDecimal(dr["Price"])


                });
            }
            return productslist;
        }
    }
}
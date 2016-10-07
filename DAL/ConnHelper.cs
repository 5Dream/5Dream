﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
 class ConnHelper
    {
        public static List<string> GetDistinceColoum(string strSQL, string str1)
        {
            DataTable dt = GetDataTable(strSQL);
            List<string> strList = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string str = dr[str1].ToString();
                strList.Add(str);
            }
            return strList;

                }
        public static DataTable GetDistinceColoum(string strSQL)
        {
            DataTable dt = GetDataTable(strSQL);
            return dt;
        }
        public static DataSet GetDataSet(string StrSQl)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["AttendanceSystemConnString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(StrSQl, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public static int GetRecordCount(string strSQL)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["AttendanceSystemConnString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            string count = cmd.ExecuteScalar().ToString().Trim();
            if (count == "")
                count = "0";
            conn.Close();
            return Convert.ToInt32(count);
        }
        public static bool ExecuteNoneQueryOperation(string strSQL)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["AttendanceSystemConnString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch
            {
                int i = 0;
                i++;

            }
            conn.Close();
            return true;
       
        }
        public static DataTable GetDataTable(string strSQL)
        {
            DataSet ds = GetDataSet(strSQL);
            ds.CaseSensitive = false;
            return ds.Tables[0];
        }
    }
}

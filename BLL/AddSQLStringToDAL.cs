using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class AddSQLStringToDAL
    {
        public static DataTable UserLogin(string UserID, string UserPWD)
        {
            string strSQL = "select * from TabTeachers where UserID='" + UserID + "'and UserPWD='" + UserPWD + "'";
            DataTable dt = ConnHelper.GetDataTable(strSQL);
            return dt;
        }
        /*
         * 添加教师
         */
        public static bool AddTeacher(string Department, string UserId, string UserPWd, string UserName, string Role, string teachers)
        {

            string strSQL = "";
            if (teachers == "本校教师")
            {
                strSQL = "INSERT INTO TabTeachers (Department,UserId,UserPWD,UserName,Role) VALUES ('" + Department + "','" + UserId + "','" + UserPWd + "','" + UserName + "','" + Role + "')";
            }
            else if (teachers == "外聘教师")
            {
                strSQL = "INSERT INTO TabOtherTeachers (UserId,UserPWD,UserName,Role) VALUES ('" + UserId + "','" + UserPWd + "','" + UserName + "','" + Role + "')";
            }
            else
            {
                return false;
            }
            DAL.ConnHelper.GetDataSet(strSQL);
            return true;
        }

        /*
         * 检查是否重复注册
         */
        public static DataTable Examination(string strTableName, string strl)
        {
            string strSQL = "select * from " + strTableName + " where UserId ='" + strl + "'";
            DataTable dt = ConnHelper.SQLData(strSQL);
            return dt;
        }
      //方法的四个重载
        public static List<string> GetDistinctString(string strTable, string str1)
        {
            string strSQL = BulidSQLDistinctString(strTable, str1);
            return ConnHelper.GetDistinceColoum(strSQL, str1);

        }
         public static List<string> GetDistinctString(string strTable, string str1,string str2)
        {
            string strSQL = BulidSQLDistinctString(strTable,str1,str2);
            return ConnHelper.GetDistinceColoum(strSQL,str1,str2);

        }
        public static List<string> GetDistinctString(string strTable, string str1, string str2,string str3)
        {
            string strSQL = BulidSQLDistinctString(strTable, str1, str2);
            return ConnHelper.GetDistinceColoum(strSQL, str1, str2);

        }
        public static List<string> GetDistinctString(string strTable, string str1, string str2,string str3,string str4,string str5)
        {
            string strSQL = BulidSQLDistinctString(strTable, str1, str2);
            return ConnHelper.GetDistinceColoum(strSQL, str1, str2);

        }

        private static string BulidSQLDistinctString(string strTableName, string str1)
        {
            return "select distinct" + str1 + "from" + strTableName;
        }
        private static string BulidSQLDistinctString(string strTableName, string str1, string str2)
        {
            return "select distinct" + str1 + "from" + strTableName;
        }
        private static string BulidSQLDistinctString(string strTableName, string str1,string str2,string str3)
        {
            return "select distinct" + str1 + "from" + strTableName;
        }
        private static string BulidSQLDistinctString(string strTableName, string str1, string str2,string str3,string str4,string str5)
        {
            return "select distinct" + str1 + "from" + strTableName;
        }

        public static DataTable GetDatatableBySQL(string strSQL)
        {
            return ConnHelper.GetDataTable(strSQL);
        }
        public static DataTable GetDatatableBySQL(string str1, string str2, string str3)
        {
            string strTemp = BuildSQLSelectString(str1, str2, str3);
            return ConnHelper.GetDataTable(strTemp);
        }
        public static DataTable GetDatatableBySQL(string TableName,string str1,string str1Limit,string str2,string str2Limit)
        {
            string strSQL = BuildSQLSelectString(TableName, str1, str1Limit, str2, str2Limit);
            return ConnHelper.GetDataTable(strSQL);
        }
        public static DataTable GetDatableBySQL(string TableName, string str1, string str1Limit, string str2, string str2Limit,string str3,string str3Limit)
        {
            string strSQL = BuildSQLSelectString(TableName, str1, str1Limit, str2, str2Limit,str3,str3Limit);
            return ConnHelper.GetDataTable(strSQL);
        }
        public static DataTable GetDatableBySQL(string TableName, string str1, string str1Limit, string str2, string str2Limit, string str3, string str3Limit,string str4,string str4Limit,string str5,string str5Limit)
        {
            string strSQL = BuildSQLSelectString(TableName, str1, str1Limit, str2, str2Limit, str3, str3Limit,str4,str4Limit,str5,str5Limit);
            return ConnHelper.GetDataTable(strSQL);
        }
        private static string BuildSQLSelectString(string strTableName)
        {
            return "select * from" + strTableName;
        }
        private static string BuildSQLSelectString(string strTableName,string strddl,string strtxt)
        {
            return "select * from" + strTableName + "where" + strddl + "=" + strtxt + "";
        }
         private static string BuildSQLSelectString(string TableName, string str1, string str1Limit, string str2, string str2Limit)
        {
            return "select * from" +TableName + "where" + str1 + "=" + str1Limit + "and"+str2+"="+str2Limit+"order by1";
        }
        private static string BuildSQLSelectString(string TableName, string str1, string str1Limit, string str2, string str2Limit,string str3,string str3Limit)
        {
            return "select * from" + TableName + "where" + str1 + "=" + str1Limit + "and" + str2 + "=" + str2Limit + str3 + "=" + str3Limit+ "order by1";
        }
        private static string BuildSQLSelectString(string TableName, string str1, string str1Limit, string str2, string str2Limit,string str3,string str3Limit,string str4, string str4Limit, string str5, string str5Limit)
        {
            return "select * from" + TableName + "where" + str1 + "=" + str1Limit + "and" + str2 + "=" + str2Limit + str3 + "=" + str3Limit + str4 + "=" + str4Limit + str5 + "=" + str5Limit + "order by1";
        }
        public static bool InsertTabTeachers(string TabName, string str1, string str2) //三重载
        {
            try
            {
                string strSQL = "insert into '" + TabName + "' ('" + str1 + "','" + str2 + "')";
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool InsertTabTeachers(string TabName, string str1, string str2, string str3, string str4, string str5, string str6, string str7, string str8, string str9, string str10, string str11, string str12)
        {
            try
            {
                string strSql = "insert into '" + TabName + "'('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str8 + "','" + str9 + "','" + str10 + "','" + str11 + "','" + str12 + "')";
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool InsertTabTeachers(string TabName, string str1, string str2, string str3, string str4, string str5, string str6, string str7, string str8, string str9, string str10, string str11, string str12, string str13, string str14)
        {
            try
            {
                string strSql = "insert into '" + TabName + "'('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + str8 + "','" + str9 + "','" + str10 + "','" + str11 + "','" + str12 + "','" + str13 + "','" + str14 + "')";
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteTabTeachers(string TabName)
        {
            try
            {
                ConnHelper.GetDataTable("truncate table" + TabName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteTabTeachers(string TabName,string str1)
        {
            try
            {
                ConnHelper.GetDataTable("truncate table" + TabName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteTabTeachers(string TabName,string str1,string str2)
        {
            try
            {
                ConnHelper.GetDataTable("truncate table" + TabName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateTabTeachers(string TableName, string UserPWD, string UserID)
        {
            string strSQL = BuildSQLUpdateString(TableName, UserPWD, UserID);
            return ConnHelper.ExecuteQueryOperation(strSQL);
        }
        private static string BuildSQLUpdateString(string strTableName, string UserPWD, string UserID)
        {
            return "update"+strTableName+"set UserPWD='"+UserPWD+"' where UserID = '"+UserID+"'";
            //
        }
    }
}

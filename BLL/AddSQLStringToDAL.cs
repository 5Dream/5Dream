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
            string strSQL = "select * from TabTeachers where UserID=" + UserID + "and UserPWD=" + UserPWD + "";
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
        public static bool InsertTeachers(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        public static List<string> GetDistinctString(string strTable, string str1)
        {
            string strSQL = BulidSQLDistinctString(strTable, str1);
            return ConnHelper.GetDistinceColoum(strSQL, str1);

        }
        private static string BulidSQLDistinctString(string strTableName, string str1)
        {
            return "select distinct" + str1 + "from" + strTableName;
        }
        
        //系统给予的错误更改
        public static List<string> GetDistinctString(string v1, string v2, string v3, string v4)
        {
            throw new NotImplementedException();
        }
        public static bool DeleDeleteTabTeachers(string v)
        {
            throw new NotImplementedException();
        }
        public static bool InsertTabTeachers(string v1, string weekNumber, string teacherDepaartment, string teacherID, string teacherName, string v2, string week, string time, string course, string area, string v3, string v4, string v5, string v6, string v7)
        {
            throw new NotImplementedException();
        }
        public static DataTable GetDatatableBySQL(string v1,string v2, string v3,string v4,string v5)
        {
            throw new NotImplementedException();
        }
        public static bool InsertTabTeachers(string v1,string v2,string v3,string course,string weekRange,string week,string time,string v4,string v5,string v6,string v7,string v8,string area)
        {
            throw new NotImplementedException();
        }
        public static DataTable GetDatatableBySQL(string v)
        {
            throw new NotImplementedException();
        }

        public static bool DeleteTabTeachers(string v)
        {
            throw new NotImplementedException();
        }
    }
}

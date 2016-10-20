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
        public static DataTable UserLogin(string UserID,string UserPWD)
        {
            string strSQL = "select * from TabTeachers where UserID=" + UserID + "and UserPWD=" + UserPWD + "";
            DataTable dt = ConnHelper.GetDataTable(strSQL);
            return dt;
        }
        /*
         * 添加教师
         */
        public static bool AddTeacher(string Department,string UserId, string UserPWd, string UserName,string Role, string teachers) {

            string strSQL = "";
            if (teachers == "本校教师")
            {
                strSQL = "INSERT INTO TobTeachers (Department,UserId,UserPWD,UserName,Role) VALUES (" + Department+","+UserId + "," + UserPWd + ","+UserName+"," + Role + ")";
            }
            else if (teachers == "外聘教师")
            {
                strSQL = "INSERT INTO TobOtherTeachers (UserId,UserPWD,UserName,Role) VALUES (" + UserId + "," + UserPWd + "," + UserName + "," + Role + ")";
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
        public static DataTable Examination(string strTableName,string strl)
        {
            string strSQL =  "select * from " + strTableName+" where UserId ='"+strl+"'";
            DataTable dt = ConnHelper.SQLData(strSQL);
            return dt;
        }
    }
}

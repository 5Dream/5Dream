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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

namespace DAL
{
    /**
     * 文件导入
     */ 
     
    public class ExcelToSQLServer
    {
        private static DataSet ds;

        /**
         * 检测ds中的列名是否和 定义的列名一致
         */ 

        private static bool CheckExcelTableTeachers()
        {
            try
            {
                string[] str = {"部门","工号","密码","姓名","性别","权限" };
                for (int i = 0; i <= 5; i++)
                {
                    if (ds.Tables["ExcelInfo"].Columns[i].ColumnName.ToString() != str[i])
                    {
                        return false;
                    }
                } 
                    return true;
            }
            catch
            {
                return false;
            }
        }
        /**
         * 获取Sheet 名（集合形式）
         * fileName 文件路径
         */
        private static List<string> GetSheetName(string fileName)
        {
            //读取Excel的Sheet 名
            string str1 = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + fileName + ";Extended Properties = 'Excel 8.0;HDR=NO;IMEX=1';";
            OleDbConnection conn = new OleDbConnection(str1);
            conn.Open();

            List<string> SheetNameList = new List<string>();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            //依次获取所有的Sheet 名
            string SheetName = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SheetName = dt.Rows[i]["TABLE_NAME"].ToString();
                SheetNameList.Add(SheetName);
            }
            conn.Close();
            conn.Dispose();
            return SheetNameList;
        }

        /**
         * 读取Excel到DataSet中
         * fileName 文件路径
         */ 
        public static void ReadExcelToDataSet(string fileName, string strSQL)
        {
            string str1 = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + fileName + ";Extended Properties ='Excel 8.0;HDR=NO;IMEX=1'";
            OleDbConnection conn = new OleDbConnection(str1);
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, conn);
            da.SelectCommand.CommandTimeout = 600;//超时时间 600s？

            ds = new DataSet();
            da.Fill(ds, "ExcelInfo");
            conn.Close(); //关闭接口
            conn.Dispose(); //释放资源
        }

        /**
         * 读取教师 的Excel
         * fileName 文件路径
         * identity 数据的表
         */ 
        public static string ReadTeachersExcel(string fileName,string identity)
        {
            //拿到Sheet 名
            List<string> SheetName = new List<string>();
            SheetName = GetSheetName(fileName);
            string strSQL = "";
            //判断表明
            if (SheetName[0] != "Sheet1$")
            {
                return "指定的Excel文件的工作表名补位“Sheet1”，当前的表明为" + SheetName[0];
            }
            strSQL = "select * from [Sheet1$]";
            //读取到内存中（DataSet）
            ReadExcelToDataSet(fileName, strSQL);

            //if (CheckExcelTableTeachers())
            if(true)
            {
                //将数据导入到数据库中
                TeachersToSQLServer(identity);

                return "文件导入成功";
            }
            else
            {
                //return "选择的Excel文件内容与数据库要求不匹配";
                return ds.Tables["ExcelInfo"].Columns[0].ColumnName.ToString()+ ds.Tables["ExcelInfo"].Columns[1].ColumnName.ToString()+ ds.Tables["ExcelInfo"].Columns[2].ColumnName.ToString()+ ds.Tables["ExcelInfo"].Columns[3].ColumnName.ToString()+ ds.Tables["ExcelInfo"].Columns[4].ColumnName.ToString()+ ds.Tables["ExcelInfo"].Columns[5].ColumnName.ToString();
            }
        }

        /**
         * 将数据导入到SQL数据库中
         * identity 表名
         */
        public static void TeachersToSQLServer(string identity)
        {
            //连接数据库
            string str1 = ConfigurationManager.ConnectionStrings["AttendanceConnString"].ConnectionString;
            SqlConnection conn = new SqlConnection(str1);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            StringBuilder strconn = new StringBuilder();
            //查询ds中的内容（=。=）
            for (int i = 1; i < ds.Tables["ExcelInfo"].Rows.Count; i++)
            {

                strconn.Append("insert into " + identity + "(Department,UserID,UserPWD,UserName,Sex,Role) values(");
                for (int j = 0; j <= 4; j++)
                {
                    strconn.Append("'" + ds.Tables["ExcelInfo"].Rows[i].ItemArray[j].ToString() + "',");
                }
                strconn.Append("'" + ds.Tables["ExcelInfo"].Rows[i].ItemArray[5] + "')");
                string str2 = strconn.ToString();
                cmd.CommandText = str2;
                cmd.ExecuteNonQuery();
                strconn.Remove(0, strconn.Length);
            }
            conn.Close();
            conn.Dispose();
        }

             public static DataTable getDT(string currFilePath)
        {
            string strConn = "data source=192.168.54.22;initial catalog=15softDB06;uid=sa;password=123";
           OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();


            string strSQL = "select * form [Sheet1$]";//读取Excel表
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();//传入数据库

            return dt;
        }
       
    }
}

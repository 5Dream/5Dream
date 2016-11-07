using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Web;
using System.Data;
using BLL;



namespace BLL
{
    public class ExcelToDatabase
    {

        /**
         * 导入文件
         * fileName文件路径
         * identity身份（所用的表名）
         */
        public static string CheckFile(string fileName,string identity)
        {
            int filesize = 0;//文件大小
            string fileextend = "";//扩展名
            //try
            //{
                if (fileName != string.Empty)//判断文件路径是否为扩展名
                {
                    filesize = fileName.Length;
                    if (filesize == 0)
                    {
                        return "导入的Excel文件大小为0，请检查是否正确！";
                    }
                    //fileextend = fileName.Substring(fileName.LastIndexOf(" ") + 1);//检查索引 即 检查文件 扩展名
                    fileextend = System.IO.Path.GetExtension(fileName);
                    fileextend = fileextend.Substring(1, fileextend.Length - 1);
                    
                    //判断格式
                    if (fileextend != "xls")
                    {
                        return "选择的文件格式不正确，只能导入Excel文件";
                        //return fileextend;
                    }
                    else
                    {
                        //格式正确将文件传到服务器中
                        return ToSQLServer(fileName,identity);
                    }

                }
                else
                {
                    return "文件为空，请重新选择！";
                }
            //}
            //catch (Exception e) {
            //    throw e;
            //}
        }

        /**
        * 判断
        */
        public static string ToSQLServer(string fileName, string identity)
        {
            if (identity == "TabTeachers" | identity == "TabOtherTeachers")
            {
                return DAL.ExcelToSQLServer.ReadTeachersExcel(fileName, identity);
            }
            else if (identity == "TabCalendar")
            {
                return DAL.ExcelToSQLServer.ReadCalendarExcel(fileName, identity);
            }
            else
            {
                return DAL.ExcelToSQLServer.ReadCoursesExcel(fileName, identity);
            }
        }

       // /**
       //  * 
       //  */ 
       //public static string Insertsoft(string currFilePath)
       // {
       //     DataTable dt = ExcelToSQLServer.getDT(currFilePath);
           

       //     for(int i = 0; i < dt.Rows.Count; i++)
       //     {
       //         string strSQL = " insert into form (Adress,subject,department,credit,period,classRoom,faculty,stuID,stuName,class,sex,course1,course2，publicSector,Teachers)values('" + dt.Rows[i][2].ToString() + "','" + dt.Rows[i][3].ToString() + "','" + dt.Rows[i][4].ToString() + "','" + dt.Rows[i][5].ToString() + "','" + dt.Rows[i][6].ToString() + "','" + dt.Rows[i][7].ToString() + "','" + dt.Rows[i][8].ToString() + "','" + dt.Rows[i][9].ToString() + "','" + dt.Rows[i][10].ToString() + "','" + dt.Rows[i][11].ToString() + "','" + dt.Rows[i][12].ToString() + "','" + dt.Rows[i][13].ToString() + "','" + dt.Rows[i][14].ToString() + "','" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][1].ToString()+"')";//导入数据表
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
       //         if (ExcelToSQLServer.getDT(strSQL).Rows.Count != 0)
       //         {
       //             return "成功";
       //         }
       //         else
       //         {
       //             return "失败";
       //         }
       //     }
       //     return "失败";
       //     //边读取边拆解进入数据库

       // }
     

        //public static bool InsertTabTeacherd(string v1, string v2, string v3)
        //{
        //    throw new NotImplementedException();
        //}

        //public static bool DeleteTabTeacher(string v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

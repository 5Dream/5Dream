﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using BLL;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Security;
using DAL;
public partial class Admin_AdminSchoolTeacher : System.Web.UI.Page
{
    string currFilePath = string.Empty;//待读取文件全路径
    string currFileExtension = string.Empty;//文件扩展名
   // private object SplitString;//生成本地SplitString
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否是第一次请求
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() == "")
            {
                DropDownList1.Items.Add("教务处");
                DropDownList1.Items.Add("基础教学部");
                DropDownList1.Items.Add("会计系");
                DropDownList1.Items.Add("信息工程系");
                DropDownList1.Items.Add("机械工程系");
                DropDownList1.Items.Add("建筑工程系");
                DropDownList1.Items.Add("经济管理系");
                DropDownList1.Items.Add("食品工程系");
                DropDownList1.Items.Add("商务外语系");
            }
        }

    }

    /**
     * 清除
     */
    private void Clear()
    {
        messige1.Text = "";
        messige2.Text = "";
        messige3.Text = "";
        messige4.Text = "";
        messige5.Text = "";
        messige6.Text = "";
        messige7.Text = "";
    }

    /**
     * 上传文件
     */

    private void Upload(HttpPostedFile file)
    {
        //HttpPostedFile file = this.FileUpload1.PostedFile;
        string fileName = file.FileName;//获取客户端的文件全路径
        string tempPath = @"D:\ASP.NET\GIT\UI\Files\";//获取系统临时文件路径
        fileName = System.IO.Path.GetFileName(fileName);//获取文件名（不带路径）
        this.currFileExtension = System.IO.Path.GetExtension(fileName);//获取文件的扩展名
        //获取时间
        System.DateTime times = new DateTime();
        times = System.DateTime.Now;
        string timeName = times.ToString();
        string[] c = timeName.Split(new char[] { '/', ' ', ':' });
        string timess = "";
        for (int i = 0; i < c.Length; i++)
        {
            timess = timess + c[i];
        }
        this.currFilePath = tempPath + timess + fileName;//服务器端的全路径
        file.SaveAs(this.currFilePath);


    }


    /**
    * 导入 教师按钮 
    */
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Clear();
        string identity = "";//表 
        //如果单选按钮被选中
        if (RadioButton1.Checked | RadioButton2.Checked)
        {
            if (RadioButton1.Checked)
            {
                identity = "TabTeachers";
            }
            else
            {
                identity = "TabOtherTeachers";
            }
            HttpPostedFile file = this.FileUpload1.PostedFile;
            Upload(file);//文件上传
            string path = currFilePath;

            messige1.Text = BLL.ExcelToDatabase.CheckFile(path, identity);
        }
        else
        {
            messige1.Text = "请先选中导入数据是“本校教师”或“外聘教师”";
        }
    }
    /**
     * 教师授课情况导入按钮
     */
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
        string depatrment = "";
        HttpPostedFile file = this.FileUpload2.PostedFile;
        Upload(file);
        string path = currFilePath;
        depatrment = DropDownList1.SelectedItem.ToString();
        messige2.Text = ExcelToDatabase.CheckFile(path, depatrment);


        //Clear();
        //if (DropDownList1.Text != "")
        //{
        //    Upload();//文件上传
        //    string path = currFilePath;

        //    messige2.Text = BLL.ExcelToDatabase.ftefv(path);
        //}
        //else {
        //    messige2.Text = "请先选择所属部门！";
        //}
        ///**
        // * 导入教师授课信息按钮
        // */
    }

   

    private void InserTeacherCourseSimpleMap(List<string> strDistinctTeacherID)
    {
        for (int i = 0; i < strDistinctTeacherID.Count; i++)
        {
            List<string> DS = new List<string>();
            DS = AddSQLStringToDAL.GetDistinctString("Course", "time and area", "TeacherID", strDistinctTeacherID[i].ToString());
            for (int j = 0; j < DS.Count; j++)
            {
                List<string> Result = new List<string>();
                //object SplitString = null;
                Result = SplitString.GetSplitCountAndDetails(DS[j]);
                //生成本地的SplitString
                DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("Course", "TeacherID", strDistinctTeacherID[i].ToString(), "time and area", DS[j].ToString());
                for (int r = 0; r < (Result.Count / 4); r++)
                {
                    String WeekRange = SplitString.GetWithoutWeek(Result[r * 4 + 0].ToString());
                    String week = (Result[r * 4 + 1].ToString());
                    String time = (Result[r * 4 + 2].ToString());
                    String area = (Result[r * 4 + 3].ToString());
                    String course = (Result[r * 4 + 4].ToString());
                    if (AddSQLStringToDAL.InsertTabTeachers("TabTeacherSimpleMap", strDistinctTeacherID[i].ToString(), dt.Rows[0]["TeacherName"].ToString(), course, WeekRange, week, time, DS[j].ToString(), dt.Rows[0]["t4"].ToString(), dt.Rows.Count.ToString(), dt.Rows[0]["t1"].ToString(), dt.Rows[0][""].ToString(), area))
                    {

                    }
                    dt.Clear();

                }
            }
        }
    }

   
    private void Shujuchuli()//对数据的处理
    {
        DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("course");
        foreach (DataRow dr in dt.Rows)
        {
            string[] T = dr[""].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //设置清除数组里的空值

            for (int i = 0; i < T.Length; i++)
            {
                string WeekNumber = "";
                string TeacherDepartment = dr["TeacherDepartment"].ToString();
                string TeacherID = dr["TeacherID"].ToString();
                string TeacherName = dr["TeacherName"].ToString();
                string Week = dr["Week"].ToString();
                switch (Week)
                {
                    case "星期一":
                        WeekNumber = "1";
                        break;
                    case "星期二":
                        WeekNumber = "2";
                        break;
                    case "星期三":
                        WeekNumber = "3";
                        break;
                    case "星期四":
                        WeekNumber = "4";
                        break;
                    case "星期五":
                        WeekNumber = "5";
                        break;
                    case "星期六":
                        WeekNumber = "6";
                        break;
                    case "星期天":
                        WeekNumber = "7";
                        break;
                }
                string time = dr["Time"].ToString();
                string course = dr["Course"].ToString();
                string area = dr["Area"].ToString();
                if (T[i].Length == 1)
                    T[i] = "0" + T[i];
                if (AddSQLStringToDAL.InsertTabTeachers("TabTeacherAttendance", WeekNumber, TeacherDepartment, TeacherID, TeacherName, T[i].ToString(), Week, time, course, area, "没有考勤", "", dr["WithoutWeek"].ToString(), "", ""))
                { }
            }
        }
        messige6.Text = "数据处理完成";

    }

    protected void Button5_Click1(object sender, EventArgs e)
    {
    }
    private void InsertTeacherStatus()
    {
        Clear();
        List<string> str = new List<string>();
        str = AddSQLStringToDAL.GetDistinctString("TabAllCourses", "TeacherID");
        for (int i = 0; i < str.Count; i++)
        {
            if (AddSQLStringToDAL.InsertTabTeachers("TabTeacherstatus", str[i].ToString(), "False"))
            {
                messige5.Text = "正在进行处理";
            }
            messige5.Text = "信息对比完成,接下来....";
            InserTeacherCourseSimpleMap(str);
            messige5.Text = "信息核对完成,请开始处理数据";
        }
    }

    protected void Button6_Click1(object sender, EventArgs e)
    {
        Clear();
        Shujuchuli();
    }

    protected void Button7_Click1(object sender, EventArgs e)
    {

        Clear();
        if (AddSQLStringToDAL.DeleteTabTeachers("TabTeacherstatus") && AddSQLStringToDAL.DeleteTabTeachers("TabTeacherCourseSimpleMap") && AddSQLStringToDAL.DeleteTabTeachers("TabTeacherAttendance") && AddSQLStringToDAL.DeleteTabTeachers("TabStudentAttendance") && AddSQLStringToDAL.DeleteTabTeachers("homework"))
        {
            messige7.Text = "数据清理完毕";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "")
        {
            string[] str = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };
            int[] sum = new int[str.Length];
            sum[0] = Convert.ToInt32(TextBox1.Text.Trim());
            sum[1] = Convert.ToInt32(TextBox2.Text.Trim());
            sum[2] = Convert.ToInt32(TextBox3.Text.Trim());
            sum[3] = Convert.ToInt32(TextBox4.Text.Trim());
            sum[4] = Convert.ToInt32(TextBox5.Text.Trim());
            sum[5] = Convert.ToInt32(TextBox6.Text.Trim());
            sum[6] = Convert.ToInt32(TextBox7.Text.Trim());
            if (AddSQLStringToDAL.DeleteTabTeachers("TabDepartment"))
            {

            }
            for (int i = 0; i < str.Length; i++)
            {
                if (AddSQLStringToDAL.InsertTabTeachers("TabDepartment", str[i], sum[i].ToString()))
                {
                    messige4.Text = "各系部人数设置完毕！";
                }

            }
        }
        else
        {
            messige4.Text = "部分系部人数未设置，请全部设置！";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Clear();
        HttpPostedFile file = this.FileUpload3.PostedFile;
        Upload(file);
        AddSQLStringToDAL.DeleteTabTeachers("TabCalendar");
        messige3.Text = ExcelToDatabase.CheckFile(FileUpload3.FileName.ToString(), "TabCalendar");//传入文件路径获取返回值
    }
    
    protected void Button8_Click(object sender, EventArgs e)
    {
        // 修改重置密码部分@20120508AM
         DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("Tab Teachers");
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["UserID"].ToString() == dt.Rows[0]["UserPWD"].ToString())
            {
                InitialPWD();
            }
        }
        InsertTeacherStatus();
    }
    private void InitialPWD()
    {
        List<string> str = new List<string>();
        str = AddSQLStringToDAL.GetDistinctString("Tab Teachers", "UserID");
        for (int i = 0; i < str.Count; i++)
        {
            if (AddSQLStringToDAL.UpdateTabTeachers("TabTeachers", PWDProcess.MD5Encrypt(str[i].ToString(), PWDProcess.CreateKey(str[i].ToString())), str[i].ToString()))
            {
                messige5.Text = "正在初始化密码......";
            }
        }
    }
}

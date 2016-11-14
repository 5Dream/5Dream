using System;
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

    private void Upload()
    {
        HttpPostedFile file = this.FileUpload1.PostedFile;
        string fileName = file.FileName;//获取客户端的文件全路径
        string tempPath = @"C:\Users\Administrator\Desktop\5Dream\UI\Fill\";//获取系统临时文件路径
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
            Upload();//文件上传
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
        Upload();
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
                if (AddSQLStringToDAL.InsertTabTeachers("", WeekNumber, TeacherDepartment, TeacherID, TeacherName, T[i].ToString(), Week, time, course, area, "没有考勤", "", dr["WithoutWeek"].ToString(), "", ""))
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
        str = AddSQLStringToDAL.GetDistinctString("Course", "TeacherID");
        for (int i = 0; i < str.Count; i++)
        {
            if (AddSQLStringToDAL.InsertTeachers("", str[i].ToString(), "False"))
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

        //BLL.AddSQLStringToDAL AS = new BLL.AddSQLStringToDAL();
        //DataTable dt = AS.getdt("select * from 考勤数据表");
        //DataTable d = new DataTable();
        //d.Columns.Add("承担单位");
        //d.Columns.Add("教师工号");
        //d.Columns.Add("教师姓名");
        //d.Columns.Add("上课时间地点");
        //d.Columns.Add("课程编号");
        //d.Columns.Add("课程名称");
        //d.Columns.Add("每周课程次数");
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    string shujuchuli = dt.Rows[i][3].ToString();
        //    string[] chaifenhoudidian = shujuchuli.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
        //    for (int j = 0; j < chaifenhoudidian.Length; j++)
        //    {
        //        DataRow dr = d.NewRow();
        //        dr["承担单位"] = dt.Rows[i][0];
        //        dr["教师工号"] = dt.Rows[i][1];
        //        dr["教师姓名"] = dt.Rows[i][2];
        //        dr["上课时间地点"] = shujuchuli[j];
        //        dr["课程编号"] = dt.Rows[i][4];
        //        dr["课程名称"] = dt.Rows[i][5];
        //        dr["每周课程次数"] = dt.Rows[i][6];
        //        dr["所属部门"] = dt.Rows[i][7];
        //        dr["学分"] = dt.Rows[i][8];
        //        dr["总学时"] = dt.Rows[i][9];
        //        dr["上课班级名称"] = dt.Rows[i][10];
        //        dr["院系部"] = dt.Rows[i][11];
        //        dr["学生学号"] = dt.Rows[i][12];
        //        dr["学生姓名"] = dt.Rows[i][13];
        //        dr["行政班级"] = dt.Rows[i][14];
        //        dr["性别"] = dt.Rows[i][15];
        //        dr["课程类别1"] = dt.Rows[i][16];
        //        dr["课程类别2"] = dt.Rows[i][17];
        //        d.Rows.Add(dr);
        //    }
        //}

    }

    protected void Button7_Click1(object sender, EventArgs e)
    {

        Clear();
        if (AddSQLStringToDAL.DeleDeleteTabTeachers("TabTeacherstatus") && AddSQLStringToDAL.DeleDeleteTabTeachers("TabTeacherCourseSimpleMap") && AddSQLStringToDAL.DeleDeleteTabTeachers("TabTeacherAttendance") && AddSQLStringToDAL.DeleteTabTeachers("TabStudentAttendance") && AddSQLStringToDAL.DeleteTabTeachers("homework"))
        {
            messige7.Text = "数据清理完毕";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "")
        {
            string sql = "update CountSum set Sum='" + TextBox1.Text + "' where Department='kuaijixi'";
            ExcelToSQLServer.UpdateSQL(sql);
            string sql1 = "update CountSum set Sum='" + TextBox2.Text + "' where Department='xinxigongchengxi'";
            ExcelToSQLServer.UpdateSQL(sql1);
            string sql2 = "update CountSum set Sum='" + TextBox3.Text + "' where Department='jianzhugongchengxi'";
            ExcelToSQLServer.UpdateSQL(sql2);
            string sql3 = "update CountSum set Sum='" + TextBox4.Text + "' where Department='jingjiguanlixi'";
            ExcelToSQLServer.UpdateSQL(sql3);
            string sql4 = "update CountSum set Sum='" + TextBox5.Text + "' where Department='shipingongchengxi'";
            ExcelToSQLServer.UpdateSQL(sql4);
            string sql5 = "update CountSum set Sum='" + TextBox6.Text + "' where Department='jixiegongchengxi'";
            ExcelToSQLServer.UpdateSQL(sql5);
            string sql6 = "update CountSum set Sum='" + TextBox7.Text + "' where Department='shangwuwaiyuxi'";
            ExcelToSQLServer.UpdateSQL(sql6);
            Response.Write("<script>alert('导入成功！')</script>");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }
        else
        {
            Response.Write("<script>alert('请输入完整的数据')</script>");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Clear();
        AddSQLStringToDAL.DeleDeleteTabTeachers("TabCalendar");
        messige3.Text = ExcelToDatabase.CheckFile(FileUpload3.FileName.ToString(), "TabCalendar");//传入文件路径获取返回值
    }
}
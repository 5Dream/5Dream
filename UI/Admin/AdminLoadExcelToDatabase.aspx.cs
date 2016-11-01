using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using BLL;
public partial class Admin_AdminSchoolTeacher : System.Web.UI.Page
{
    string currFilePath = string.Empty;//待读取文件全路径
    string currFileExtension = string.Empty;//文件扩展名

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否是第一次请求
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() == "")
            {

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
        string tempPath =@"C:\Users\Administrator\Desktop\5Dream\UI\Fill\";//获取系统临时文件路径
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
        if (DropDownList1.Text != "")
        {
            Upload();//文件上传
            string path = currFilePath;

            messige2.Text = BLL.ExcelToDatabase.Insertsoft(path);
        }
        else
        {
            messige2.Text = "文件为空，请重新选择！";
        }
    }
        /**
         * 导入校历按钮
         */
    protected void Button3_Click(object sender, EventArgs e)
    {
        HttpPostedFile file2Calendar = this.FileUpload3.PostedFile;
        string file2CalendarFullName= Upload(file2Calendar);//获取路径
        messige3.Text = ExcelToDatabase.CheckFile(file2CalendarFullName.ToString(), "TabCalendar");//导入数据库

    }
    /**
     * 文件上传（二）
     * file ： 通过FileUpload获取的当前路径
     */
    private string  Upload(HttpPostedFile file)
    {
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
        return currFilePath;


    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "")
        {
            string[] str = { "信息与艺术设计系", "会计系", "经济管理系", "食品工程系", "机械工程系", "建筑管理系", "商务外语系" };
            int[] sum = new int[str.Length];
            sum[0] = Convert.ToInt32(TextBox1.Text.Trim());
            sum[1] = Convert.ToInt32(TextBox2.Text.Trim());
            sum[2] = Convert.ToInt32(TextBox3.Text.Trim());
            sum[3] = Convert.ToInt32(TextBox4.Text.Trim());
            sum[4] = Convert.ToInt32(TextBox5.Text.Trim());
            sum[5] = Convert.ToInt32(TextBox5.Text.Trim());
            sum[6] = Convert.ToInt32(TextBox6.Text.Trim());
            if (ExcelToDatabase.DeleteTabTeacher("TabDeparment"))
            {

                for (int i = 0; i < str.Length; i++)
                {
                    if (ExcelToDatabase.InsertTabTeacherd("TabDepartment", str[i], sum[i].ToString()))
                    {
                        messige4.Text = "各系部人数设置完毕";
                    }
                }
            }
        }
        else
        {
            messige4.Text = "部分系部人数未设置，请确认设置";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminSchoolTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    /*
     *下拉事件
     */
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text.ToString() == "本校教师")
        {
        }
        else {
            DropDownList2.Visible = false;
           
        }
    }
    /*
     *确定按钮 
     */
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string teacherType = "";
        if (DropDownList1.Text.ToString() == "本校教师")
        {
            //数据库表名
            teacherType = "TabTeachers";
           
        }
        else
        {
            DropDownList2.Visible = false;
            //数据库表名
            teacherType = "TabOtherTeachers";
        }
        //如果不重复
        if (BLL.AddSQLStringToDAL.Examination(teacherType, TextBox1.Text).Rows.Count == 0)
        {
            if (teacherType == "TabTeachers")
            {
                BLL.AddSQLStringToDAL.AddTeacher(DropDownList2.Text.ToString(), TextBox1.Text, TextBox3.Text, TextBox2.Text, DropDownList3.Text.ToString(), DropDownList1.Text.ToString());
                Response.Write("<script>alert('添加成功')</script>");
                Clear();
            }
            else {
                BLL.AddSQLStringToDAL.AddTeacher(DropDownList2.Text.ToString(), TextBox1.Text, TextBox3.Text, TextBox2.Text, DropDownList3.Text.ToString(), DropDownList1.Text.ToString());
                Response.Write("<script>alert('添加成功')</script>");
                Clear();
            }
          
        }
        else
        {
            //失败
            Clear();
            Response.Write("<script>alert('输入有误!创建失败')</script>");
        }
        Label1.Text = BLL.AddSQLStringToDAL.Examination(teacherType, TextBox1.Text).Rows.Count.ToString();
        DropDownList2.Visible = true;
    }
    /*
     * 取消按钮
     */
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
    /*
     *清除内容 
     */
    private void Clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        DropDownList1.Text = "本校教师";
        DropDownList2.Text = "安全保卫处";
        DropDownList3.Text = "1";
        DropDownList2.Visible = true;
    }
}
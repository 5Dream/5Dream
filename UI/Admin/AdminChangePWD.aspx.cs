using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class Admin_AdminSchoolTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["login"].ToString() != "true")
        {
            Response.Redirect("");
        }
    }
    static DataTable dt = new DataTable();

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")//教师工号为空
        {
            Label2.Text = "教师工号不能为空！";
            return;
        }
        else
        {
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            Button2.Visible = true;

            if (dt.Rows.Count != 0)//查询到的内容
            {
                Label2.Text = "您将对" + dt.Rows[0][0].ToString() + "修改密码";
            }
            else
            {
                Label2.Text = "没有查询到该工号！";
                return;
            }

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text == "" || TextBox3.Text == "")
        {
            Label6.Text = "新密码不能为空！";
            return;
        }
        else
        {
            if (TextBox2.Text != TextBox3.Text)
            {
                Label6.Text = "两次输入的密码不同！";
                return;
            }
        }
        if (TextBox2.Text.Length <8||TextBox3.Text.Length <8)
        {
            Label6.Text = "密码不能少于8位！";
            return;
        }

        
    }
}

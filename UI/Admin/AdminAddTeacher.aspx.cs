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
        if (DropDownList1.Text.ToString() == "本校教师")
        {
            Label1.Text = DropDownList1.Text + "," + DropDownList2.Text + "," + DropDownList3.Text;
        }
        else
        {
            DropDownList2.Visible = false;
            Label1.Text = DropDownList1.Text + "," + DropDownList3.Text;
        }
        DropDownList2.Visible = true;
    }
    /*
     * 取消按钮
     */
    protected void Button2_Click(object sender, EventArgs e)
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
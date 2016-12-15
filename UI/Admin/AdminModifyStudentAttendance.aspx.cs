using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.IO;
using System.Text;

public partial class Admin_AdminSchoolTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CurrentCourse"].ToString() != "")
            {
                InitialOperation();
                Button1.Visible = true;
            }
            else
            {

            }
            if (CheckIsRecord())
            {
                SetControlsVisibleFalse();
                Label8.Text = "您已经录入本次考勤记录";
                Button1.Visible = true;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    private bool CompareWeek()
    {
        int Week = 0;
        int CurrentWeek = 0;
        switch (DateTime.Now.DayOfWeek.ToString())
        {
            case "Monday":
                CurrentWeek = 1;
                break;
            case "Tuesday":
                CurrentWeek = 2;
                break;
            case "Wednesday":
                CurrentWeek = 3;
                break;
            case "Thursday":
                CurrentWeek = 4;
                break;
            case "Friday":
                CurrentWeek = 5;
                break;
            case "Saturday":
                CurrentWeek = 6;
                break;
            case "Sunday":
                CurrentWeek = 7;
                break;
            default:
                CurrentWeek = 0;
                break;
        }
        switch (Session["Week"].ToString())
        {
            case "星期一":
                Week = 1;
                break;
            case "星期二":
                Week = 2;
                break;
            case "星期三":
                Week = 3;
                break;
            case "星期四":
                Week = 4;
                break;
            case "星期五":
                Week = 5;
                break;
            case "星期六":
                Week = 6;
                break;
            case "星期日":
                Week = 7;
                break;
            default:
                Week = 0;
                break;
        }
        if (CurrentWeek > Week)
        {
            return true;
        }
        else if (CurrentWeek == Week)
        {
            int tt = 0;
            switch (Session["Time"].ToString())
            {
                case "1-2节":
                    tt = 10;
                    break;
                case "3-4节":
                    tt = 12;
                    break;
                case "5-6节":
                    tt = 16;
                    break;
                case "7-8节":
                    tt = 18;
                    break;
                case "9-10节":
                    tt = 20;
                    break;
                default:
                    tt = 0;
                    break;
            }
            if (DateTime.Now.Hour >= tt)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }
    private bool CheckIsRecord()
    {
        //缺11个重载，重载那里不会改
        DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("TabTeacherAttendance", "TeacherID", Session["UserID"].ToString(), "CurrentWeek", Session["CurrentWeek"].ToString(),
            "Course", Session["CurrentCourse"].ToString(), "Week", Session["Week"].ToString(), "Time", Session["Time"].ToString());
        if (dt.Rows[0]["IsAttendance"].ToString().Trim() == "未考勤")
            return false;
        else
            return true;
    }
    private void SetControlsVisibleFalse()
    {
        Label8.Visible = false;
        Button2.Visible = false;
        Button3.Visible = false;
        CheckBox1.Visible = false;
        DropDownList1.Visible = false;
        GridView1.Visible = false;
    }
    System.Drawing.Color c;
    protected void rdo_CheckChange(object seder, EventArgs e)
    {
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            Control ctl1 = row.FindControl("RadioButton1");
            Control ctl2 = row.FindControl("RadioButton2");
            Control ctl3 = row.FindControl("RadioButton3");
            Control ctl4 = row.FindControl("RadioButton4");
            Control ctl5 = row.FindControl("RadioButton5");
            TableCellCollection cell = row.Cells;
            if ((ctl1 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor = c;
            }
            if ((ctl2 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor = System.Drawing.Color.Yellow;
            }
            if ((ctl3 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor = System.Drawing.Color.Red;
            }
            if ((ctl4 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor = System.Drawing.Color.Yellow;
            }
            if ((ctl5 as RadioButton).Checked)
            {
                this.GridView1.Rows[row.DataItemIndex].BackColor = System.Drawing.Color.SkyBlue;
            }
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            //鼠标移上去时
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor = currentcolor;");
            //鼠标移开时
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        StringBuilder strLate = new StringBuilder("迟到名单");
        StringBuilder strAbsence = new StringBuilder("旷课名单");
        StringBuilder strEarly= new StringBuilder("早退名单");
        StringBuilder strLeave = new StringBuilder("请假名单");
        int sum = 0;
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            Control ctl2 = row.FindControl("RadioButton2");
            Control ctl3 = row.FindControl("RadioButton3");
            Control ctl4 = row.FindControl("RadioButton4");
            Control ctl5 = row.FindControl("RadioButton5");
            TableCellCollection cell = row.Cells;
            if ((ctl2 as RadioButton).Checked)
            {
                if (AddSQLStringToDAL.InsertTabTeachers("TabStudentAttendance", Session["UserID"].ToString(), Session["UserName"].ToString(),
                    Session["CurrentCourse"].ToString(), Session["CurrentWeek"].ToString(), Session["Week"].ToString(), Session["Time"].ToString(),
                    cell[0].Text.ToString(), cell[1].Text.ToString(), cell[2].Text.ToString(), cell[3].Text.ToString(), "迟到", ""))
                {
                    sum++;
                    strLate.Append(cell[3].Text.ToString() + ";");
                }
            }
            if ((ctl3 as RadioButton).Checked)
            {
                if (AddSQLStringToDAL.InsertTabTeachers("TabStudentAttendance", Session["UserID"].ToString(), Session["UserName"].ToString(),
                   Session["CurrentCourse"].ToString(), Session["CurrentWeek"].ToString(), Session["Week"].ToString(), Session["Time"].ToString(),
                   cell[0].Text.ToString(), cell[1].Text.ToString(), cell[2].Text.ToString(), cell[3].Text.ToString(), "旷课", ""))
                {
                    sum++;
                    strAbsence.Append(cell[3].Text.ToString() + ";");
                }
            }
            if ((ctl4 as RadioButton).Checked)
            {
                if (AddSQLStringToDAL.InsertTabTeachers("TabStudentAttendance", Session["UserID"].ToString(), Session["UserName"].ToString(),
                   Session["CurrentCourse"].ToString(), Session["CurrentWeek"].ToString(), Session["Week"].ToString(), Session["Time"].ToString(),
                   cell[0].Text.ToString(), cell[1].Text.ToString(), cell[2].Text.ToString(), cell[3].Text.ToString(), "早退", ""))
                {
                    sum++;
                    strAbsence.Append(cell[3].Text.ToString() + ";");
                }
            }
            if ((ctl5 as RadioButton).Checked)
            {
                if (AddSQLStringToDAL.InsertTabTeachers("TabStudentAttendance", Session["UserID"].ToString(), Session["UserName"].ToString(),
                   Session["CurrentCourse"].ToString(), Session["CurrentWeek"].ToString(), Session["Week"].ToString(), Session["Time"].ToString(),
                   cell[0].Text.ToString(), cell[1].Text.ToString(), cell[2].Text.ToString(), cell[3].Text.ToString(), "请假", ""))
                {
                    sum++;
                    strAbsence.Append(cell[3].Text.ToString() + ";");
                }
            }
        }
        if (strLate.ToString() == "迟到名单：")
            strLate.Append("无");
        if (strEarly.ToString() == "早退名单：")
            strEarly.Append("无");
        if (strAbsence.ToString() == "旷课名单：")
            strAbsence.Append("无");
        if (strLeave.ToString() == "请假名单：")
            strLeave.Append("无");
        //缺12个重载
        if (AddSQLStringToDAL.UpdateTabTeachers("TabTeachersAttendance", "IsAttendance", "已考勤", "Count", Session["HomeWork"].ToString(), "TeacherID",
            Session["UserID"].ToString(), Session["CurrentWeek"].ToString(), "Week", Session["Week"].ToString(), "Time", Session["Time"].ToString()))
        {
            Label2.Text = strAbsence.ToString();
            Label3.Text = strLate.ToString();
            Label4.Text = strEarly.ToString();
            Label5.Text = strLeave.ToString();
            strLate.Remove(0, strLate.Length);
            strAbsence.Remove(0, strAbsence.Length);
            strEarly.Remove(0, strEarly.Length);
            strLate.Remove(0, strLeave.Length);


            SetControlsVisibleFalse();


            Label7.Text = "本次考勤已经上报成功！本次课您" + Session["HomeWork"].ToString() + "，请返回主页面";
            Button1.Visible = true;
        }

 }
}

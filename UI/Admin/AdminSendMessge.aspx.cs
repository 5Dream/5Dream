using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Collections;
using System.Configuration;
using System.Web.UI.HtmlControls;
using BLL;

public partial class Admin_AdminSchoolTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        List<string> strSum = new List<string>();
        List<string> strID1 = new List<string>();
        List<string> strID2 = new List<string>();
        List<string> strID3 = new List<string>();
        List<string> strID4 = new List<string>();

        if (CheckBox1.Checked == true)
        {
            strID1 = AddSQLStringToDAL.GetDistinctString("TabTeachers", "UserID", "Role", "2");
        }
        if (CheckBox2.Checked == true)
        {
            strID2 = AddSQLStringToDAL.GetDistinctString("TabTeachers", "UserID", "Role", "3");
        }
        if (CheckBox3.Checked == true)
        {
            strID3 = AddSQLStringToDAL.GetDistinctString("TabAllCourses", "TeachersID");
        }
        strSum.AddRange(strID1);
        strSum.AddRange(strID2);
        strSum.AddRange(strID3);

        for (int i = 0; i < strSum.Count; i++)
        {
            for (int j = 0; j < strSum.Count; j++)
            {
                if (i != j)
                {
                    if (strSum[i] == strSum[j])
                        strSum.RemoveAt(j);
                }
            }
        }
        if (strSum.Count > 0)
        {
            for(int i=0;i<strSum.Count;i++)
                {
                //少七个重载
                if (AddSQLStringToDAL.InsertTabTeachers("TabMessage", System.DateTime.Now.ToString(),TextBox1.Text,strSum[i].ToString(),"false","",""))
                    {
                }
            }
            Label1.Text = "信息发送成功！";
            TextBox1.Text = "";

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;

public partial class Register : System.Web.UI.Page
{

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = AddSQLStringToDAL.UserLogin( txtUserID.Text.Trim(),  strPWD.Text.ToString());
        if (dt.Rows.Count == 1)
        {
            string Role = dt.Rows[0]["Role"].ToString();

            Session["UserID"] = dt.Rows[0]["UserName"].ToString();
            Session["Role"] = dt.Rows[0]["Role"].ToString();
            switch (Role)
            {
                case "1":
                    Response.Redirect("Admin/AdminSchoolTeacher.aspx");
                    break;
                case "2":
                    
                    Response.Redirect("Counselor/CounselorChangePWD.aspx");
                    break;
                case "3":
                   
                    Response.Redirect("Depart/DepartChangePWD.aspx");
                    break;
                case "4":
                   
                    Response.Redirect("Teachers/TeachersChangePWD.aspx");
                    break;
                default:
                    break;


            }
        }
        else
        {
           
           // Session["ValidateCode"] = "";
            //lblMessage.Text = "用户名或密码不正确";
            
        }
    }
}
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
        DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("TabTeachers", "UserID", txtUserID.Text.Trim(), "UserPWD", strPWD.Text.ToString());
        if (dt.Rows.Count == 1)
        {
            string Role = dt.Rows[0]["Role"].ToString();
            switch (Role)
            {
                case "1":
                    Session["Role"] = "";
                    Response.Redirect("");
                    break;
                case "2":
                    Session["Role"] = "";
                    Response.Redirect("");
                    break;
                case "3":
                    Session["Role"] = "";
                    Response.Redirect("");
                    break;
                case "4":
                    Session["Role"] = "";
                    Response.Redirect("");
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
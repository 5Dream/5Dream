using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["UserID"].ToString() + "你好，你的权限为" + Session["Role"].ToString() + "。当前在线人数为：" + Application["online"].ToString() + "人。";
    }
}

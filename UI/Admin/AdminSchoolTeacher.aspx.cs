using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using System.Data;


public partial class Admin_AdminSchoolTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() == "")
            {
                //Response.Redirect("");//立即返回浏览器，刷新
            }
            else
            {
                DataTable dt = BLL.AddSQLStringToDAL.GetDatatableBySQL("TabTeachers");
                BindToGridView(dt);
                Label3.Visible = false;
                TextBox1.Visible = false;
            }
        }

    }
  

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (AddSQLStringToDAL.DeleteTabTeachers("TabTeachers", "UserID", GridView1.DataKeys[e.RowIndex].Value.ToString()))
        {
            Bind();
        }
    }
    protected void Bind()
    {
        if (DropDownList1.SelectedItem.ToString() == "所有记录")
        {
            DataTable dt = BLL.AddSQLStringToDAL.GetDatatableBySQL("TabTeachers");
            BindToGridView(dt);
        }
        else if (DropDownList1.SelectedItem.ToString() != "所有记录" && TextBox1.Text!= "")
        {
            DataTable dt = BLL.AddSQLStringToDAL.GetDatatableBySQL("TabTeachers", DropDownListTransform.DDLToString(), TextBox1.Text.Trim());//传递
            BindToGridView(dt);

        }
    }
    protected void BindToGridView(DataTable dt)
    {
        GridView1.DataSource = dt;
        GridView1.DataKeyNames = new string[] { "UserID" };
        GridView1.DataBind();
        
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;//取消编辑
        Bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strUserRole = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
        string strUserID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        if (AddSQLStringToDAL.UpdateTabTeachers("TabTeachers", "Role", strUserRole, "UserID", strUserID))//UPdateTabTeachers缺少五个重载
        {
            GridView1.EditIndex = -1;
            Bind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Bind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.ToString() == "所有记录")
        {
            Label3.Visible = false;
            TextBox1.Visible = false;

        }
        else
        {
            Label3.Visible = true;
            TextBox1.Visible = true;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
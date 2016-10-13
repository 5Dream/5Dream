<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminAddTeacher.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="新增用户页面"></asp:Label>
    <br />
    <style type="text/css">
        table {
            margin:0 auto;
            text-align:center;
                text-size-adjust:100%;
        }
        #AddNewTeacher {
            background:#00ffff;
            border-bottom-width:1px; 
            border-bottom-color:#000000;
        
            width:400px;
            height:400px;
        }
        
    </style>
    <div>
        <table id="AddNewTeacher">
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="教师类型"></asp:Label></td>
                <td>  <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" style="margin-left: 0" Width="144px" DataSourceID="XmlDataSource3" DataTextField="title" DataValueField="title" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="所属部门"></asp:Label></td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" Height="17px" style="margin-left: 0" Width="144px" DataSourceID="XmlDataSource2" DataTextField="title" DataValueField="title">
        </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/xml/AdminDepartmentXML.xml"></asp:XmlDataSource>
                    <asp:XmlDataSource ID="XmlDataSource3" runat="server" DataFile="~/xml/AdminTeacherXML.xml"></asp:XmlDataSource>
                    <asp:Label ID="Label4" runat="server" Text="教师工号"></asp:Label></td>
                <td><asp:TextBox ID="TextBox1" runat="server" Height="17px" style="margin-left: 0" Width="144px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label5" runat="server" Text="教师姓名"></asp:Label></td>
                <td><asp:TextBox ID="TextBox2" runat="server" Height="17px" style="margin-left: 0" Width="144px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label6" runat="server" Text="密码"></asp:Label></td>
                <td><asp:TextBox ID="TextBox3" runat="server" Height="17px" style="margin-left: 0" Width="144px"></asp:TextBox></td>
            </tr>
            <tr>
                <td> 
                    <asp:XmlDataSource ID="XmlDataSource4" runat="server" DataFile="~/xml/AdminRoleXML.xml"></asp:XmlDataSource>
                    <asp:Label ID="Label7" runat="server" Text="权限"></asp:Label></td>
                <td> <asp:DropDownList ID="DropDownList3" runat="server" Height="17px" style="margin-left: 0" Width="144px" DataSourceID="XmlDataSource4" DataTextField="title" DataValueField="title"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Button ID="Button1" runat="server" Text="确定" BorderStyle="Ridge" OnClick="Button1_Click"/></td>
                <td><asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" /></td>
            </tr>


        </table>
    
  </div>
   
</asp:Content>


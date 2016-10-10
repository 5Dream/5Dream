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
            border-bottom-color:#000000;
            border:2px;
        }
    </style>
    <table>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="教师类型"></asp:Label></td>
            <td>  <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" style="margin-left: 0" Width="144px">
    </asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="所属部门"></asp:Label></td>
            <td><asp:DropDownList ID="DropDownList2" runat="server" Height="17px" style="margin-left: 0" Width="144px">
    </asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="教师工号"></asp:Label></td>
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
            <td> <asp:Label ID="Label7" runat="server" Text="权限"></asp:Label></td>
            <td> <asp:DropDownList ID="DropDownList3" runat="server" Height="17px" style="margin-left: 0" Width="144px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Button ID="Button1" runat="server" Text="确定" BorderStyle="Ridge"/></td>
            <td><asp:Button ID="Button2" runat="server" Text="取消" /></td>
        </tr>


    </table>
    
  
   
   
    
    <br />
    
    

    <br />
</asp:Content>


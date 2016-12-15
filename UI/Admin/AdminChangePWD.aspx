<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminChangePWD.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <style type="text/css">
         .LoadExcel{
             background:#00ffff;
             border-bottom-width:1px;
              border-bottom-color:#000000;
              margin:0 auto;
  
              text-size-adjust:100%;
          }
          .top {
              background: cornflowerblue;
              border-bottom-width:1px;
              border-bottom-color: cornflowerblue;
              margin:0 auto;
  
              text-size-adjust:100%;
          }
  
      </style>
    <div class="top">
        <asp:Label ID="Label1" runat="server" Text="修改密码"></asp:Label>
     <div class="LoadExcel"><br />
        <table align="center">
            <tr>
                <td align="left" style="width: 102px">
                    <asp:Label ID="Label2" runat="server" Text="教师工号"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td align="right" style="width: 112px">
                    <asp:Button ID="Button1" runat="server" Text="查询" Width="90px" OnClick="Button1_Click" BorderColor="#FFCCCC"/>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 102px">
                      <asp:Label ID="Label4" runat="server" Text="新密码"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
                </td>
                <td style="width: 112px"></td>
            </tr>
            <tr>
                <td align="left" style="width: 102px">
                   <asp:Label ID="Label5" runat="server" Text="确认新密码"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
                </td>
                <td style="width: 112px"></td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="Label6" runat="server" Text="Label" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="Button2" runat="server" Text="确定"  Width="90px" Visible="False" OnClick="Button2_Click" Height="24px" BorderColor="#FFCCCC"/>
                </td>
            </tr>
        </table>
   <br />
         <br />
        </div>
</asp:Content>


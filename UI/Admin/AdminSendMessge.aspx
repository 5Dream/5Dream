﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminSendMessge.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #TextArea1 {
            height: 285px;
            width: 403px;
        }
           .top {
       background-color:gray;
              border-bottom-width:1px;
              margin:0 auto;
              text-size-adjust:100%;
              font-size:large;
              font-family: Arial,KaiTi;
          }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="top">
    <asp:Label ID="Label1" runat="server" Text="发布通知页面"></asp:Label></div>
    <br/>  
    <asp:Label ID="Label2" runat="server" Text="[lbMessage]"></asp:Label><br/><br/>
    <asp:CheckBox ID="CheckBox1" runat="server" Text="院系领导"/>&nbsp;&nbsp;
    <asp:CheckBox ID="CheckBox2" runat="server"  Text="各系辅导员"/>&nbsp;&nbsp;
    <asp:CheckBox ID="CheckBox3" runat="server" Text="本校所有有课教师" /><br/>
    <br/>
    &nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="263px" Width="395px"></asp:TextBox>

    <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="确  定" Width="85px" BorderColor="#FFCCCC" OnClick="Button1_Click" />

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminOutToExcel.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="导出数据页面"></asp:Label>
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
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    <div class="LoadExcel">
        <asp:Button ID="Button2" runat="server" Text="Button" />
    </div>
     <div class="top">
         <asp:Button ID="Button3" runat="server" Text="Button" />
    </div>
    <div class="LoadExcel">
        <asp:Button ID="Button4" runat="server" Text="Button" />
    </div>
</asp:Content>


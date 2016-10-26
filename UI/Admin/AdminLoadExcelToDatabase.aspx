<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminLoadExcelToDatabase.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label ID="Label1" runat="server" Text="导入数据页面"></asp:Label>
 
     <style type="text/css">
         .LoadExcel{
             background:#00ffff;
             border-bottom-width:1px;
              border-bottom-color:#000000;
              margin:0 auto;
  
              text-size-adjust:100%;
          }
          .top {
              background:#ffd800;
              border-bottom-width:1px;
              border-bottom-color:#ff0000;
              margin:0 auto;
  
              text-size-adjust:100%;
          }
  
      </style>
      <div class="top">
          <asp:Label ID="Label2" runat="server" Text="导入教师基本信息"></asp:Label>
      </div>
      <div class="LoadExcel">
          <asp:RadioButton ID="RadioButton1" runat="server" Text="本校教师" />
          <asp:RadioButton ID="RadioButton2" runat="server" Text="外聘教师" /><br />
          <asp:Label ID="Label3" runat="server" Text="选择要导入的文件"></asp:Label>
  
          <asp:FileUpload ID="FileUpload1" runat="server" Width="460px" />
          <asp:Button ID="Button1" runat="server" Text="导入" Width="90px" OnClick="Button1_Click1" />
  
          <br />
          <asp:Label ID="messige1" runat="server" Text="Label"></asp:Label>
  
      </div>
      <div class="top">
          <asp:Label ID="Label4" runat="server" Text="分系部导入教师信息"></asp:Label>
      </div>
      <div class="LoadExcel">
  
          <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><br/>
  
          <asp:Label ID="Label5" runat="server" Text="选择要导入的文件"></asp:Label>
  
          <asp:FileUpload ID="FileUpload2" runat="server" Width="460px" />
          <asp:Button ID="Button2" runat="server" Text="导入" Width="90px" />
  
          <br />
          <asp:Label ID="messige2" runat="server" Text="Label"></asp:Label>
  
      </div>
      <div class="top">
          <asp:Label ID="Label6" runat="server" Text="导入本学期校历"></asp:Label>
      </div>
      <div class="LoadExcel">
          <asp:Label ID="Label7" runat="server" Text="选择要导入的文件"></asp:Label>
  
  
          <asp:FileUpload ID="FileUpload3" runat="server" Width="460px" />
          <asp:Button ID="Button3" runat="server" Text="导入" Width="90px" />
  
          <br />
          <asp:Label ID="messige3" runat="server" Text="Label"></asp:Label>
  
      </div>
      <div class="top">
          <asp:Label ID="Label8" runat="server" Text="导入各系部总人数"></asp:Label>
      </div>
      <div class="LoadExcel">
          <asp:Label ID="Label9" runat="server" Text="信息与艺术设计系"></asp:Label>
          <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
          <asp:Label ID="Label10" runat="server" Text="会计系"></asp:Label>
          <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
          <asp:Label ID="Label11" runat="server" Text="经济管理系"></asp:Label>
          <asp:TextBox ID="TextBox3" runat="server" Width="100px"></asp:TextBox>
          <asp:Label ID="Label12" runat="server" Text="食品工程系"></asp:Label>
          <asp:TextBox ID="TextBox4" runat="server" Width="100px"></asp:TextBox><br />
          <asp:Label ID="Label13" runat="server" Text="机械工程系                  "></asp:Label>
          <asp:TextBox ID="TextBox5" runat="server" Width="100px"></asp:TextBox>
          <asp:Label ID="Label14" runat="server" Text="建筑工程系"></asp:Label>
          <asp:TextBox ID="TextBox6" runat="server" Width="100px"></asp:TextBox>
          <asp:Label ID="Label15" runat="server" Text="商务外语系"></asp:Label>
          <asp:TextBox ID="TextBox7" runat="server" Width="100px"></asp:TextBox>
          <asp:Button ID="Button4" runat="server" Text="确定" Width="90px" />
          <br />
          <asp:Label ID="messige4" runat="server" Text="Label"></asp:Label>
      </div>
      <div class="top">
        <asp:Label ID="Label16" runat="server" Text="数据处理"></asp:Label>
      </div>
      <div class="LoadExcel">
          <asp:Button ID="Button5" runat="server" Text="分析入库数据" /><br />
          <asp:Button ID="Button6" runat="server" Text="处理入库数据" /><br />
          <asp:Button ID="Button7" runat="server" Text="清空入库数据" />
      </div>
  
  </asp:Content>

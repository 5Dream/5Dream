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
              background: cornflowerblue;
              border-bottom-width:1px;
              border-bottom-color: cornflowerblue;
              margin:0 auto;
  
              text-size-adjust:100%;
          }
  
      </style>
      <div class="top">
          <asp:Label ID="Label2" runat="server" Text="导入教师基本信息"></asp:Label>
      </div>
      <div class="LoadExcel">
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:RadioButton ID="RadioButton1" runat="server" Text="本校教师" />
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
          <asp:RadioButton ID="RadioButton2" runat="server" Text="外聘教师" /><br />
          <asp:Label ID="Label3" runat="server" Text="选择要导入的文件"></asp:Label>
  
          <asp:FileUpload ID="FileUpload1" runat="server" Width="460px" />
           &nbsp;
          <asp:Button ID="Button1" runat="server" Text="导入" Width="90px" OnClick="Button1_Click1" BorderColor="#FFCCCC" />
  
          <br />
          <asp:Label ID="messige1" runat="server"></asp:Label>
  
      </div>
      <div class="top">
          <asp:Label ID="Label4" runat="server" Text="分系部导入教师授课信息"></asp:Label>
      </div>
      <div class="LoadExcel">
   &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
          <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="XmlDataSource2" DataTextField="title" DataValueField="title"></asp:DropDownList><br/>
  
          <asp:Label ID="Label5" runat="server" Text="选择要导入的文件"></asp:Label>
  
          <asp:FileUpload ID="FileUpload2" runat="server" Width="460px" />
           &nbsp;
          <asp:Button ID="Button2" runat="server" Text="导入" Width="90px" OnClick="Button2_Click" BorderColor="#FFCCCC" />
  
          <br />
          <asp:Label ID="messige2" runat="server"></asp:Label>
  
      </div>
      <div class="top">
          <asp:Label ID="Label6" runat="server" Text="导入本学期校历"></asp:Label>
      </div>
      <div class="LoadExcel">
          <asp:Label ID="Label7" runat="server" Text="选择要导入的文件"></asp:Label>
  
  
          <asp:FileUpload ID="FileUpload3" runat="server" Width="460px" />
           &nbsp;
          <asp:Button ID="Button3" runat="server" Text="导入" Width="90px" OnClick="Button3_Click" style="height: 21px" BorderColor="#FFCCCC" />
  
          <br />
          <asp:Label ID="messige3" runat="server"></asp:Label>
  
      </div>
      <div class="top">
          <asp:Label ID="Label8" runat="server" Text="导入各系部总人数"></asp:Label>
      </div>
      <div class="LoadExcel">
          <asp:Label ID="Label9" runat="server" Text="会计系"></asp:Label>
          &nbsp; &nbsp;<asp:Label ID="Label10" runat="server" Text="信息工程系"></asp:Label>
               &nbsp; <asp:Label ID="Label11" runat="server" Text="经济管理系"></asp:Label>
           &nbsp;
            <asp:Label ID="Label12" runat="server" Text="食品工程系"></asp:Label>
            &nbsp; <asp:Label ID="Label13" runat="server" Text="机械工程系"></asp:Label>
            &nbsp;&nbsp; <asp:Label ID="Label18" runat="server" Text="建筑工程系"></asp:Label>
           &nbsp; <asp:Label ID="Label15" runat="server" Text="商务外语系"></asp:Label>
           <br/>
          <asp:TextBox ID="TextBox1" runat="server" Width="60px"></asp:TextBox>
           &nbsp; 
          <asp:TextBox ID="TextBox2" runat="server" Width="60px"></asp:TextBox>
           &nbsp; &nbsp;
          <asp:TextBox ID="TextBox3" runat="server" Width="60px"></asp:TextBox>
           &nbsp;&nbsp;
          <asp:TextBox ID="TextBox4" runat="server" Width="60px"></asp:TextBox>
           &nbsp;&nbsp;&nbsp;
          <asp:TextBox ID="TextBox5" runat="server" Width="60px"></asp:TextBox>
           &nbsp;&nbsp;&nbsp;
          <asp:TextBox ID="TextBox6" runat="server" Width="60px"></asp:TextBox>
           &nbsp; &nbsp; 
          <asp:TextBox ID="TextBox7" runat="server" Width="60px"></asp:TextBox>
          <br/>
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="Button4" runat="server" Text="确定" Width="80px" OnClick="Button4_Click" BorderColor="#FFCCCC"  />
          <br />
          <asp:Label ID="messige4" runat="server"></asp:Label>
      </div>
      <div class="top">
        <asp:Label ID="Label16" runat="server" Text="数据处理"></asp:Label>
      </div>
      <div class="LoadExcel">
          <asp:Button ID="Button5" runat="server" Text="分析入库数据" OnClick="Button5_Click1" BorderColor="#FFCCCC" />
          <asp:Label ID="messige5" runat="server"></asp:Label>
          <br />
          <asp:Button ID="Button6" runat="server" Text="处理入库数据" OnClick="Button6_Click1" BorderColor="#FFCCCC" />
          <asp:Label ID="messige6" runat="server"></asp:Label>
          <br />
          <asp:Button ID="Button7" runat="server" Text="清空入库数据" OnClick="Button7_Click1" BorderColor="#FFCCCC" />
          <asp:Label ID="messige7" runat="server"></asp:Label>
      </div>
  
  </asp:Content>

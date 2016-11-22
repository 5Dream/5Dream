<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminDeleteAllData.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="清空数据页面"></asp:Label>
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
        &nbsp;<asp:Label ID="Label2" runat="server" Text="请选择清空的数据表"></asp:Label>
          </div>
          <div class="LoadExcel">
        <br/>
            <asp:Label ID="Label3" runat="server" Text="“教务处”的数据量"></asp:Label>   &nbsp;&nbsp; &nbsp;
          <asp:TextBox ID="TextBox1" runat="server" Width="204px"></asp:TextBox>
                 &nbsp;
          <asp:Button ID="Button1" runat="server" Text="清空教务处的数据量" Width="199px" BorderColor="#FFCCCC" />
               &nbsp;
          <asp:Label ID="Label4" runat="server" Text="Del1"></asp:Label>
          <br /><br />
          <div class="top">
            &nbsp;<asp:Label ID="Label8" runat="server" Text="请选择清空的数据表（教师信息）"></asp:Label>
        </div>
        <br/>
          <asp:Label ID="Label5" runat="server" Text="“本校教师”的数据量"></asp:Label>   &nbsp; &nbsp;
          <asp:TextBox ID="TextBox2" runat="server" Width="203px"></asp:TextBox>
                 &nbsp;
          <asp:Button ID="Button2" runat="server" Text="清空本校教师的数据量" Width="199px" BorderColor="#FFCCCC" />
               &nbsp;
          <asp:Label ID="Label6" runat="server" Text="Del2"></asp:Label>
          <br/>
           <asp:Label ID="Label9" runat="server" Text="“外聘教师”的数据量"></asp:Label>   &nbsp; &nbsp;
          <asp:TextBox ID="TextBox3" runat="server" Width="203px"></asp:TextBox>   &nbsp;
          <asp:Button ID="Button3" runat="server" Text="清空外聘教师的数据量" Width="199px" BorderColor="#FFCCCC" />
               &nbsp;
          <asp:Label ID="Label10" runat="server" Text="Del3"></asp:Label>
              <br />
          <br />

          <div class="top">
         &nbsp; <asp:Label ID="Label7" runat="server" Text="请选择清空的数据表（学生信息）"></asp:Label>
              </div>
          <br/>&nbsp;<asp:Label ID="Label11" runat="server" Text="“会计系”的数据量"></asp:Label>   &nbsp; &nbsp;
          <asp:TextBox ID="TextBox4" runat="server" Width="203px"></asp:TextBox>   &nbsp;
          <asp:Button ID="Button4" runat="server" Text="清除会计系的数据量"  Width="199px" BorderColor="#FFCCCC"/> &nbsp;
          <asp:Label ID="Label12" runat="server" Text="Del4"></asp:Label><br/>
             <asp:Label ID="Label13" runat="server" Text="“信息工程系”的数据量"></asp:Label> &nbsp;
          <asp:TextBox ID="TextBox5" runat="server" Width="210px"></asp:TextBox>   &nbsp;
          <asp:Button ID="Button5" runat="server" Text="清除信息工程系的数据量" Width="199px" BorderColor="#FFCCCC" /> &nbsp;
          <asp:Label ID="Label14" runat="server" Text="Del5"></asp:Label><br/>
             <asp:Label ID="Label15" runat="server" Text="“经济管理系”的数据量"></asp:Label> &nbsp;
          <asp:TextBox ID="TextBox6" runat="server" Width="210px"></asp:TextBox>   &nbsp;
          <asp:Button ID="Button6" runat="server" Text="清除经济管理系的数据量" Width="199px" BorderColor="#FFCCCC" /> &nbsp;
          <asp:Label ID="Label16" runat="server" Text="Del6"></asp:Label><br/>
             <asp:Label ID="Label17" runat="server" Text="“食品工程系”的数据量"></asp:Label> &nbsp;
          <asp:TextBox ID="TextBox7" runat="server" Width="210px"></asp:TextBox>   &nbsp;
          <asp:Button ID="Button7" runat="server" Text="清除食品工程系的数据量"  Width="199px" BorderColor="#FFCCCC"/> &nbsp;
          <asp:Label ID="Label18" runat="server" Text="Del7"></asp:Label><br/>
             <asp:Label ID="Label19" runat="server" Text="“机械工程系”的数据量"></asp:Label> &nbsp;
          <asp:TextBox ID="TextBox8" runat="server" Width="210px"></asp:TextBox>   &nbsp;
          <asp:Button ID="Button8" runat="server" Text="清除机械工程系的数据量" Width="199px" BorderColor="#FFCCCC" /> &nbsp;
          <asp:Label ID="Label20" runat="server" Text="Del8"></asp:Label><br/>
             <asp:Label ID="Label21" runat="server" Text="“建筑工程系”的数据量"></asp:Label> &nbsp;
          <asp:TextBox ID="TextBox9" runat="server" Width="210px"></asp:TextBox>   &nbsp;
          <asp:Button ID="Button9" runat="server" Text="清除建筑工程系的数据量" Width="199px" BorderColor="#FFCCCC" /> &nbsp;
          <asp:Label ID="Label22" runat="server" Text="Del9"></asp:Label><br/>
             <asp:Label ID="Label23" runat="server" Text="“商务外语系”的数据量"></asp:Label >&nbsp;
          <asp:TextBox ID="TextBox10" runat="server" Width="210px"></asp:TextBox>   &nbsp;
          <asp:Button ID="Button10" runat="server" Text="清除商务外语系的数据量" Width="199px" BorderColor="#FFCCCC"/> &nbsp;
          <asp:Label ID="Label24" runat="server" Text="Del10"></asp:Label>
              <br />
              <br />
              <br/>
          
    </div>
</asp:Content>


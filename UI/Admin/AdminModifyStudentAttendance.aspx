<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminModifyStudentAttendance.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
          .top {
       background-color:gray;
              border-bottom-width:1px;
              margin:0 auto;
              text-size-adjust:100%;
              font-size:large;
              font-family: Arial,KaiTi;
          }
           .LoadExcel{
           
             border-bottom-width:1px;
              border-bottom-color:#000000;
              margin:0 auto;
  
              text-size-adjust:100%;
          }
  
    </style>
    <div class="top">
    <asp:Label ID="Label1" runat="server" Text="学生情况页面"></asp:Label></div>
    <div class="LoadExcel">
    <asp:Label ID="Label2" runat="server" Text="[lbAttendanceMessage]"></asp:Label><br/>
    <asp:Label ID="Label3" runat="server" Text="[lbLateMessage]"></asp:Label><br/>
    <asp:Label ID="Label4" runat="server" Text="[lbEarlyMessage]"></asp:Label><br/>
    <asp:Label ID="Label5" runat="server" Text="[lbLeaveMessage]"></asp:Label><br/>
    <asp:Label ID="Label7" runat="server" Text="[lbResultMessage]"></asp:Label><br/><br/>

    &nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="[lbmessage]"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="返回主页面" BorderColor="#FFCCCC" OnClick="Button1_Click" /> &nbsp;&nbsp;&nbsp;&nbsp
    <asp:Button ID="Button2" runat="server" Text="上报考勤结果" BorderColor="#FFCCCC" OnClick="Button2_Click" />&nbsp;&nbsp
    <asp:CheckBox ID="CheckBox1" runat="server" Text="教学异动" />
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <asp:Button ID="Button3" runat="server" Text="确定" BorderColor="#FFCCCC" Width="46px" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal"
         CellPadding="3" DataKeyNames="StudentsID" DataSourceID="SqlDataSoureAttendanceDetails"  OnRowDataBound="GridView1_RowDataBound" Font-Size="12px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C"/>
        <Columns>
            <asp:BoundField DataField="StudentDepartment" HeaderText="所属系部" ItemStyle-Width="100px" SortExpression="StudentDepartment"/>
             <asp:BoundField DataField="t4" HeaderText="班级" ItemStyle-Width="100px" SortExpression="t4"/>
             <asp:BoundField DataField="StudentID" HeaderText="学号" ItemStyle-Width="100px" SortExpression="StudentID"/>
            <asp:BoundField DataField="StudentName" HeaderText="姓名" ItemStyle-Width="100px" SortExpression="StudentName"/>
            <asp:TemplateField HeaderText="出勤情况">
                <ItemTemplate>
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="g1" Text="正常" Checked="true" AutoPostBack ="true" OnCheckedChanged="rdo_CheckedChanged"/>
                    <asp:RadioButton ID="RadioButton2" runat="server"  GroupName="g1" Text="迟到" Checked="true" AutoPostBack="true" OnCheckedChanged="rdo_CheckedChanged" />
                    <asp:RadioButton ID="RadioButton3" runat="server"  GroupName="g1" Text="旷课" Checked="true" AutoPostBack="true" OnCheckedChanged="rdo_CheckedChanged"/>
                    <asp:RadioButton ID="RadioButton4" runat="server"  GroupName="g1" Text="早退" Checked="true" AutoPostBack="true" OnCheckedChanged="rdo_CheckedChanged"/>
                    <asp:RadioButton ID="RadioButton5" runat="server"  GroupName="g1" Text="请假" Checked="true" AutoPostBack="true" OnCheckedChanged="rdo_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C"/>
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right"/>
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="true" ForeColor="#F7F7F7"/>
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="true" ForeColor="#F7F7F7"/>
        <AlternatingRowStyle BackColor="#F7F7F7"/>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SDBISASConnectionString2 %>" SelectCommand="SELECT DIDTINCT[StudentDepartment],
        [StudentID],[StudentName],[t4]FROM[TabAllCourses]WHERE(([TeacherID]=@TeacherID)AND([Course]=@Course)AND([TimeAndArea]=@TimeAndArea))">
        <SelectParameters>
            <asp:SessionParameter Name="TeacherID" SessionField="UserID" Type="String"/>
              <asp:SessionParameter Name="Course" SessionField="CurrentCourse" Type="String"/>
              <asp:SessionParameter Name="TimeAndArea" SessionField="WeekRange" Type="String"/>
             
        </SelectParameters>

    </asp:SqlDataSource>
        <br />
        <br/>
        </div>
</asp:Content>


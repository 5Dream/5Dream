<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminLoadExcelToDatabase.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label2" runat="server" Text="导入教师基本信息"></asp:Label>
    <br />
    <asp:RadioButton ID="RadioButton1" runat="server" Text="本校教师" />
    <asp:RadioButton ID="RadioButton2" runat="server" Text="外聘教师" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="请选择要导入的文件"></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="导入" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
</asp:Content>


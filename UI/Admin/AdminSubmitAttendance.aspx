<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminSubmitAttendance.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="录入考勤页面"></asp:Label>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table border="0" style="width:100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style="width:100%;height:30px" class="STYLEI">
                        <asp:Label ID="Label2" runat="server" Text="本周授课信息："></asp:Label>
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="width:10%;height:25px" align="center" class="STYLE1">
                    <%#Container.ItemIndex+1 %>&nbsp;</td>
                      <td style="width:40%;height:25px" align="center" class="STYLE1">
                    <%#DataBinder.Eval(Container.DataItem,"Week") %>
                          <%#DataBinder.Eval(Container.DataItem,"Time") %>
                          <%#(DataBinder.Eval(Container.DataItem,"Course")).ToString().Substring(0,(DataBinder.Eval(Container.DataItem,"Course")).ToString().Length-3) %>
                          <asp:TextBox ID="TextBox1" runat="server" Visible="false" Text=' <%#DataBinder.Eval(Container.DataItem,"Course") %>'></asp:TextBox>
                           <asp:TextBox ID="TextBox2" runat="server" Visible="false" Text=' <%#DataBinder.Eval(Container.DataItem,"Week") %>'></asp:TextBox>
                          <asp:TextBox ID="TextBox3" runat="server" Visible="false" Text=' <%#DataBinder.Eval(Container.DataItem,"Time") %>'></asp:TextBox>
                           <asp:TextBox ID="TextBox4" runat="server" Visible="false" Text=' <%#DataBinder.Eval(Container.DataItem,"StudentIDList") %>'></asp:TextBox>
                </td> 
                <td style="width:10px;height:25px;" class="STYLE1">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="布置作业"/>
                </td>
                <td style="width:20%;height:25px" class="STYLE1">
                    <asp:Button ID="Button1" runat="server" Text="考勤" Width="100px" />
                </td>
                <td style="width:10%;height:25px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="1"><hr /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>


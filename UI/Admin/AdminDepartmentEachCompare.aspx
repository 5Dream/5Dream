<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminDepartmentEachCompare.aspx.cs" Inherits="Admin_AdminSchoolTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <style type="text/css">
         .LoadExcel{
           
             border-bottom-width:1px;
              border-bottom-color:#000000;
              margin:0 auto;
  
              text-size-adjust:100%;
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
    <div class="top">
    <asp:Label ID="Label1" runat="server" Text="各系总对比"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="查看各系详单" BorderColor="#FFCCCC" />
        </div>
     <div class="LoadExcel">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBox1" runat="server"  Text="按周次检索" BorderColor="#FFCCCC"/>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:RadioButton ID="RadioButton1" runat="server" Text="本周情况" />
         <asp:RadioButton ID="RadioButton2" runat="server"  Text="上周情况"/>
         <asp:RadioButton ID="RadioButton3" runat="server"  Text="近一个月情况"/>
         <asp:RadioButton ID="RadioButton4" runat="server"  Text="开学至今"/>
         <asp:Button ID="Button2" runat="server" Text="生成图表" BorderColor="#FFCCCC" />
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Horizontal" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
             <AlternatingRowStyle BackColor="#F7F7F7" />
             <Columns>
                 <asp:BoundField HeaderText="系部" DataField="系部" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="在校人数" DataField="在校人数" ItemStyle-Width="90px" >
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="旷课率" DataField="旷课率" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="迟到人数" DataField="迟到人数" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="迟到率" DataField="迟到率" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="早退人数" DataField="早退人数" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="早退率" DataField="早退率" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="请假人数" DataField="请假人数" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="请假率" DataField="请假率" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="总缺勤数" DataField="总缺勤数" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
                 <asp:BoundField HeaderText="总缺勤率" DataField="总缺勤率" ItemStyle-Width="90px">
<ItemStyle Width="90px"></ItemStyle>
                 </asp:BoundField>
             </Columns>
             <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
             <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
             <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
             <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
             <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
             <SortedAscendingCellStyle BackColor="#F4F4FD" />
             <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
             <SortedDescendingCellStyle BackColor="#D8D8F0" />
             <SortedDescendingHeaderStyle BackColor="#3E3277" />
         </asp:GridView>
         <table>
             <tr>
                 <td style="width:100%;height:30px" align="center">
                     <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                 </td>
             </tr>
             <tr>
                 <td align="center" style="width:100%;height:30px">
                     <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                 </td>
             </tr>
              <tr>
                 <td align="center" style="width:100%;height:30px">
                     <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                 </td>
             </tr>
              <tr>
                 <td align="center" style="width:100%;height:30px">
                     <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                 </td>
             </tr>
              <tr>
                 <td align="center" style="width:100%;height:30px">
                     <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                 </td>
             </tr>

         </table>
    </div>
    </asp:Content>


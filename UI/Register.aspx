<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录页面</title>

    <style type="text/css">
        *{
            padding:0;
            margin:0;
        }
        #main {
            width:100%;
            height:660px;
            background-size:100% 100%;
            background-repeat:no-repeat;
            background-image:url(images/ic_register_main_bg.png);
        }
        #nulltop { 
            margin:0 auto;
            width:600px;
            height:150px;
        }
        #card {
            width:700px;
            height:410px;
              margin:0 auto;
               background-image:url(images/ic_register_card.png);
        }
        #top { 
            margin-left:10px;
            width:750px;
            height:192px;
             background-image:url(images/ic_register_top.png);
        }
         #pic{
           width:34%;
           height:200px;
           float:left;
            background-image:url(images/ic_register_pic.png);
       }
        #centent {
        
            width:66%;
            height:218px;
            float:left;
        }
        td{
            text-align:center;
        }
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="nulltop"></div>
        <div id="card">  
            <div id="top"></div>
            <div id="pic"></div>
            <div id="centent">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="UserID" runat="server" Text="用户名" Width="50px"></asp:Label>
                        </td>
                        <td colspan="2"><asp:TextBox ID="txtUserID" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                              <asp:Label ID="UserPWD" runat="server" Text="  密码" Width="50px"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="strPWD" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="验证码" Width="50px"></asp:Label>
                        </td>
                        <td colspan="2">
                              <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><img src="ValidateImage.aspx" alt="验证字符" style="width:80px;height:20px"onclick="this.src=this.src+'?'" /></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="btnLogin" runat="server" Text="登录" Width="50px" OnClick="Button1_Click" />  
                        </td>
                    </tr>
                </table>
                 
            </div>
        </div>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>山东商务职业学院考勤系统</title>

    <style type="text/css">
        *{
            padding:0;
            margin:0 auto;
        }
        #main {
            width:1000px;
            height:650px;
            background-size:100% 100%;
            background-repeat:no-repeat;
            background-image:url(images/ic_register_main1_bg.jpg);
        }
        #nulltop {
            width:1000px;
            height:100px;
            background-size:1000px 100px;
            background-repeat:no-repeat;
            background-image:url(images/nulltop.jpg);
        }
        #contents {
            width:1000px;
            height:450px;
        }
        #side {width:283px;
                  height:226px;
                  background-size:283px 226px;
                  background-repeat:no-repeat;
                  background-image:url(images/denglu.png);
                  position:absolute;
                  top:230px;
                  right:250px;
                  float:right;
        }
        #BG {
            width:270px;
            height:220px;
            float:left;
            padding-left:40px;
            padding-top:40px;

        }
        #footer {
            width:1000px;
            height:100px;
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
        <div id="contents">  
            <div id="side">
                <div id="BG">
                    <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="用户名" Width="50px" Height="26px"></asp:Label>
                        </td>
                        <td colspan="2"><asp:TextBox ID="txtUserID" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                              <asp:Label ID="Label2" runat="server" Text="  密码" Width="50px"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="strPWD" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="验证码" Width="50px"></asp:Label>
                        </td>
                        <td colspan="2">
                              <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
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
                            <asp:Button ID="Button1" runat="server" Text="登录" Width="50px" OnClick="Button1_Click" />  
                        </td>
                    </tr>
                </table>  
                    </div>  
                  
            </div>
            </div>
        <div id="footer"></div>
        </div>
    </form>
</body>
</html>

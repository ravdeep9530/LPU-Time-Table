<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enter_UID.aspx.cs" Inherits="Time_Table.Enter_UID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<style>
body
{
    
    background-image:url('Pics/LP-Page-color2.jpg');
    background-repeat:no-repeat;
    background-attachment:fixed;
    background-position:center;
    font-size: 15px;
    font-family: "Century Gothic", CenturyGothic, AppleGothic, sans-serif;
}

.text
{
  
}
.button
{
    background-color:transparent;
    background-position:center;
    background-repeat:no-repeat;
    background-image:url("Pics/submit.png");
    border-radius:60px;
    border:0;
    cursor:pointer;
    
    }
    
.button:hover{
   
    margin-top:1px;
   
        }
        .input_type
{
	width: 75%;
	padding-right: 30px;
	background: #f8f8f8;
	padding-left: 5px;
	height: 36px;
	font-size: 20px;
	color: #919191;
	border:none;
	-webkit-box-shadow: 5px 1px 1px 0px rgba(50, 50, 50, 0.75);
	-moz-box-shadow: 1px 1px 1px 0px rgba(50, 50, 50, 0.75);
	box-shadow: 1px 1px 1px 0px rgba(50, 50, 50, 0.75);
	background: url(Pics/user_icon.png) right no-repeat #f8f8f8;
}
.input_type:focus
{
	-webkit-box-shadow: 1px 1px 1px 0px rgba(224, 74, 49, 0.75);
	-moz-box-shadow: 1px 1px 1px 0px rgba(224, 74, 49, 0.75);
	box-shadow: 1px 1px 1px 0px rgba(224, 74, 49, 0.75);
}</style>
<body style="background-color: #e9ebee;">
    <form id="form1" runat="server">
    <center><img src="Pics/lpu_logo.png" /></center>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
        <center><asp:Panel  ID="Panel1" runat="server" Height="211px">
           <center> 
           <div style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19); z-index:-1; background-image:url('Pics/login_bx_bg.png');  margin-top:3%; width:50%;  padding:30px;">
              <div style="z-index:1000; opacity:1; background-color:transparent;">
               <asp:Panel ID="Panel2" runat="server" 
                 EnableTheming="True" Height="179px" 
                HorizontalAlign="Center" style="margin-left: 10px; "  Width="325px" Wrap="False">
                <asp:Label ID="Label1" runat="server"  Text="Enter UID " Font-Bold="True" 
                       Font-Size="Larger"></asp:Label><hr /><br />
                       <br />
                <asp:TextBox CssClass="input_type" ID="TextBox1" placeholder="User ID" runat="server" Height="28px"   Width="164px" 
                      ></asp:TextBox><br /><br />
                <asp:Button ID="Button1" CssClass="button"  runat="server" onclick="Button1_Click"  
                       Font-Bold="True" Font-Overline="False" Font-Underline="False" 
                       ForeColor="#3333CC" Width="78px" Height="72px" />
            </asp:Panel></div></center>
        </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </center>
    </div>
    </form>
</body>
</html>

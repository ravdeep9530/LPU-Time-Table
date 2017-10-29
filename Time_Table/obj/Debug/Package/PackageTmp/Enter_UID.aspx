<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enter_UID.aspx.cs" Inherits="Time_Table.Enter_UID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style>
body
{
    background-image:url("Pics/ums_bg.jpg");
    background-position:center;
}
.text
{
   background-color:rgba(238,238,238,0.3);
   box-shadow: 0 2px 8px 0 rgba(0,0,0,0.8),0 6px 20px 0 rgba(0,0,0,0.19);
   
}
.button
{
    background-color:transparent;
    background-position:center;
    background-repeat:no-repeat;
    background-image:url("Pics/submit.png");
    border-radius:60px;
    border:0;
    
    }
    
.button:hover{
   
    margin-top:1px;
   
        }</style>
<body>
    <form id="form1" runat="server">
    <div>
    
        <center><asp:Panel  ID="Panel1" runat="server" Height="211px">
           <center> 
           <div style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19); margin-top:10%; width:50%; padding:30px;">
               <asp:Panel ID="Panel2" runat="server" 
                 EnableTheming="True" Height="179px" 
                HorizontalAlign="Center" style="margin-left: 10px" Width="325px" Wrap="False">
                <asp:Label ID="Label1" runat="server" Text="Enter UID " Font-Bold="True" 
                       Font-Size="Larger"></asp:Label><hr /><br />
                <asp:TextBox CssClass="text" ID="TextBox1" runat="server" Height="28px"   Width="164px" 
                      ></asp:TextBox><br /><br /><br />
                <asp:Button ID="Button1" CssClass="button" runat="server" onclick="Button1_Click"  
                       Font-Bold="True" Font-Overline="False" Font-Underline="False" 
                       ForeColor="#3333CC" Width="78px" Height="72px" />
            </asp:Panel></center>
        </asp:Panel>
        </div>
    </center>
    </div>
    </form>
</body>
</html>

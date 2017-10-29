<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Time_Table_Login.aspx.cs" Inherits="Time_Table.Time_Table_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="CSS/reset.css">
     <link rel="stylesheet" href="CSS/style.css">
     <link rel="Stylesheet" href="CSS/StyleSheet1.css" />
    <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900'>
<link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Montserrat:400,700'>
<link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>
 <script src="js/index.js"></script>
        
</head>
<style>
        body
{
    
    background-image:url('Pics/LP-Page-color2.jpg');
    background-repeat:no-repeat;
    background-attachment:fixed;
    background-position:center;
   

              
     font-family: "Century Gothic", CenturyGothic AppleGothic, sans-serif;
}
body<a href="Time_Table_Login.aspx">Time_Table_Login.aspx</a>
{
     background-image:url('Pics/LP-Page-color2.jpg');
    background-repeat:no-repeat;
    background-attachment:fixed;
    background-position:center;
    
}

</style>
<script>
    function check() {
        var u = document.getElementById('uid').value;
        var p = document.getElementById('pass').value;
        //alert("Please Insert UID Firstly!!");
        if(u=="")
        {
            alert("Please Insert UID Firstly!!");
            document.getElementById('uid').focus();
            return false;
            }
        if (p == "") {
            alert("Please Insert Password Firstly!!");
            document.getElementById('pass').focus();
            return false;
            }


            return true;
       
    }
</script>
<body>
    <form id="form1" runat="server">
   <div class="container">
  <div class="info">
    <h1>Login to TTMS </h1><span>Made with <i>Respect</i> by <a href="http://worldwiki.in">Worldwiki Team</a></span>
  </div>
</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div class="form">
<center>
  <div><img src="Pics/lpu_logo.png"/></div>
  </center>
  <div class="login-form"  >
    <asp:TextBox  runat="server" ID="uid"  placeholder="UID" />
    <asp:TextBox  runat="server" ID="pass"  placeholder="password" TextMode="Password" />
    <asp:Button ID="login_btn" runat="server" Text="login" OnClick="login_val" style=" background-color: #EF3B3A;" OnClientClick=" return check();" CssClass="login_button" />
     </div>
</div>
</ContentTemplate>
    </asp:UpdatePanel>

 

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

        <script src="js/index.js"></script>

    
    
    
 

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

       

 
    </div>
    </form>
</body>
</html>

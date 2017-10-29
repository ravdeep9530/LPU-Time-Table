<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Time_table_manager.aspx.cs" Inherits="Time_Table.Time_table_manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style>
    
#pop
        {
            position: relative;
            background-color: #fefefe;
            margin: auto;
            azimuth:center;
            padding: 30px;
            border: 1px solid #888;
            width: 80%;
            overflow: auto; 
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            -webkit-animation-name: animatetop;
            -webkit-animation-duration: 0.6s;
            animation-name: animatetop;
            animation-duration: 0.6s
}
@-webkit-keyframes animatetop {
            from {top: -300px; opacity: 0} 
            to {top: 0px; opacity: 1}
        }

        @keyframes animatetop {
            from {top: -300px; opacity: 0}
            to {top: 0px; opacity: 1}
        }</style>
        <script>
        function showpop() {
            document.getElementById('pop').style.display = "block";

        }
        function closepop() {
            document.getElementById('pop').style.display = "none";

        }</script>
<body onclick="closepop();">
    <form id="form1" runat="server">
    <center>
    <div style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19); padding:50px; margin-top:100px;">
         <asp:Button ID="Button1" runat="server" Text="Check Load" Font-Bold="True" 
            Height="45px" onclick="Button1_Click" Width="109px" />
        <asp:Button ID="Button2" runat="server" Text="Phase One" Height="44px" 
            Width="97px" onclick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Button" Height="45px" 
            Width="104px" onclick="Button3_Click" />
              
    
   
     <center>
            <div id="pop" style="display:none;">
           
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div></center>
             </div></center>
    </form>    
</body>
</html>

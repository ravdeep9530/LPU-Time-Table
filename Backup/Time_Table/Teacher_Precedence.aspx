<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Precedence.aspx.cs" Inherits="Time_Table.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script>
        function showpop() {
            document.getElementById('pop').style.display = "block";

        }
        function closepop() {
            document.getElementById('pop').style.display = "none";

        }
        function showpop_already() {
            document.getElementById('pop_already').style.display = "block";

        }
        function closepop_already() {
            document.getElementById('pop_already').style.display = "none";

        }
        function showpop_submitted() {
            document.getElementById('pop_submitted').style.display = "block";

        }
        function closepop_submitted() {
            document.getElementById('pop_submitted').style.display = "none";

        }</script>
    <style type="text/css">
        body
        {
            
   background-image:url('Pics/LP-Page-color2.jpg');
    background-repeat:no-repeat;
    background-attachment:fixed;
    background-position:center;
    font-family: "Century Gothic", CenturyGothic, AppleGothic, sans-serif;
        }
        .myButton {
	-moz-box-shadow:inset 0px 1px 0px 0px #ffffff;
	-webkit-box-shadow:inset 0px 1px 0px 0px #ffffff;
	box-shadow:inset 0px 1px 0px 0px #ffffff;
	background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #f9f9f9), color-stop(1, #e9e9e9));
	background:-moz-linear-gradient(top, #f9f9f9 5%, #e9e9e9 100%);
	background:-webkit-linear-gradient(top, #f9f9f9 5%, #e9e9e9 100%);
	background:-o-linear-gradient(top, #f9f9f9 5%, #e9e9e9 100%);
	background:-ms-linear-gradient(top, #f9f9f9 5%, #e9e9e9 100%);
	background:linear-gradient(to bottom, #f9f9f9 5%, #e9e9e9 100%);
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#f9f9f9', endColorstr='#e9e9e9',GradientType=0);
	background-color:#f9f9f9;
	-moz-border-radius:6px;
	-webkit-border-radius:6px;
	border-radius:2px;
	border:1px solid #dcdcdc;
	display:inline-block;
	cursor:pointer;
	color:#666666;
	font-family:Arial;
	font-size:12px;
	font-weight:bold;
	padding:4px 18px;
	text-decoration:none;
	text-shadow:0px 1px 0px #ffffff;
}
.myButton:hover {
	background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #e9e9e9), color-stop(1, #f9f9f9));
	background:-moz-linear-gradient(top, #e9e9e9 5%, #f9f9f9 100%);
	background:-webkit-linear-gradient(top, #e9e9e9 5%, #f9f9f9 100%);
	background:-o-linear-gradient(top, #e9e9e9 5%, #f9f9f9 100%);
	background:-ms-linear-gradient(top, #e9e9e9 5%, #f9f9f9 100%);
	background:linear-gradient(to bottom, #e9e9e9 5%, #f9f9f9 100%);
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#e9e9e9', endColorstr='#f9f9f9',GradientType=0);
	background-color:#e9e9e9;
}
.myButton:active {
	position:relative;
	top:1px;
}
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
#pop_already
        {
            position: relative;
            background-color: #fefefe;
            margin: auto;
            azimuth:center;
            padding: 30px;
            border: 1px solid #888;
            width: 80%;
            color:Red;
            overflow: auto; 
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            -webkit-animation-name: animatetop;
            -webkit-animation-duration: 0.6s;
            animation-name: animatetop;
            animation-duration: 0.6s
}

            #pop_submitted
        {
            position: relative;
            background-color: #fefefe;
            margin: auto;
            azimuth:center;
            padding: 30px;
            border: 1px solid #888;
            width: 80%;
            color:#39b42e;
            overflow: auto; 
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            -webkit-animation-name: animatetop;
            -webkit-animation-duration: 0.6s;
            animation-name: animatetop;
            animation-duration: 0.6s
}
            
        .myLabel {
	-moz-box-shadow:inset 0px 1px 0px 0px #ffffff;
	-webkit-box-shadow:inset 0px 1px 0px 0px #ffffff;
	box-shadow:inset 0px 1px 0px 0px #ffffff;
	background:-webkit-gradient(linear, left top, left bottom, color-stop(0.05, #f9f9f9), color-stop(1, #e9e9e9));
	background:-moz-linear-gradient(top, #f9f9f9 5%, #e9e9e9 100%);
	background:-webkit-linear-gradient(top, #f9f9f9 5%, #e9e9e9 100%);
	background:-o-linear-gradient(top, #f9f9f9 5%, #e9e9e9 100%);
	background:-ms-linear-gradient(top, #f9f9f9 5%, #e9e9e9 100%);
	background:linear-gradient(to bottom, #f9f9f9 5%, #e9e9e9 100%);
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#f9f9f9', endColorstr='#e9e9e9',GradientType=0);
	background-color:#f9f9f9;
	-moz-border-radius:6px;
	-webkit-border-radius:6px;
	border-radius:2px;
	border:1px solid #dcdcdc;
	display:inline-block;
	
	color:#c54c41;
	font-family:Arial;
	font-size:12px;
	font-weight:bold;
	padding:4px 18px;
	text-decoration:none;
	text-shadow:0px 1px 0px #ffffff;
}
       
        .model{
            display: none; 
            position: fixed; 
            z-index: 1;
            left: 0;
            top: 0;
            width: 100%; 
            height: 100%; 
            overflow: auto; 
            background-color: rgb(0,0,0); 
            background-color: rgba(0,0,0,0.4); 
        }
        

        @-webkit-keyframes animatetop {
            from {top: -300px; opacity: 0} 
            to {top: 0px; opacity: 1}
        }

        @keyframes animatetop {
            from {top: -300px; opacity: 0}
            to {top: 0px; opacity: 1}
        }
        
         table {
   
    
	border:medium;
	 box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
	
}

th, td {
    text-align: left;
    padding: 8px;
}

tr:nth-child(even){background-color: #f2f2f2}

th {
    background-color: #4CAF50;
    color: white;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div>
    
        <center>
            <div id="pop" style="display:none; position:absolute; margin-left:7%; z-index:2;">
            <asp:Button ID="Button3" runat="server" Text="Confirm" onclick="Button3_Click" />&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Text="Cancel" onclick="Button4_Click" /><hr>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div></center>
            <center>
            <div id="pop_already" style="display:none; position:absolute; margin-left:7%; z-index:2;">
            <h1>Your Precedence is Already Submitted!!</h1>
            <asp:Button ID="Button6" runat="server" Text="Go Back" onclick="Button5_Click" /><hr>
                
            </div></center>
            <center>
            <div id="pop_submitted" style="display:none; position:absolute; margin-left:7%; z-index:2;">
            <h1>Your Precedence is Submitted Successfully!!</h1>
            <asp:Button ID="Button5" runat="server" Text="Go Back" onclick="Button5_Click1" /><hr>
                
            </div></center>
           <center><img src="Pics/lpu_logo.png" /></center>
           <br />
                    <div style="float:right; position:absolute; margin-top:-13%;  margin-left:85%;">
                        <asp:Button ID="Button2"  runat="server"  onclick="Button2_Click" Text="Logout"
                        Width="139px" Height="40px" BackColor="White" 
                            BorderStyle="Solid" BorderWidth="1px" ForeColor="#FF5050" 
                            CssClass="myButton"  /></div>
                    
        <center>
            
                <table>
                    <tr>
                        <td >
                            <asp:Label ID="Label1" runat="server" 
                Text="UID: " ></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" Height="25px" 
            ontextchanged="TextBox3_TextChanged" 
                Enabled="False" EnableTheming="True" EnableViewState="False"></asp:TextBox></td>
                        <td colspan="2" >
                            <asp:Label ID="Label2" runat="server" style="margin-bottom: 0px" 
                Text="Name:"  Height="19px"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" Height="25px" 
                ontextchanged="TextBox2_TextChanged"  Wrap="False" Enabled="False" EnableTheming="True" 
                EnableViewState="False"></asp:TextBox>
                        </td></tr>

                   <!-- </tr>
                    <tr><td>Choose Domain: </td><td>
                        <asp:DropDownList ID="domain" runat="server" ForeColor="#003366" 
                        Height="40px" Width="300px" AutoPostBack="True" onload="domain_Load" 
                            onselectedindexchanged="domain_SelectedIndexChanged" 
                            ontextchanged="domain_TextChanged" CssClass="myButton"></asp:DropDownList></td></tr>-->
                            <asp:Panel ID="course_drop" runat="server" Width="44px">
                            
                    <tr>
                    <th colspan="1">Preference</th><th>Course Domain</th><th>Course</th>
                        </tr><tr>
                                    <td>
                                        IST</td>
                                    <td>
                                        <asp:DropDownList ID="Course_Domain_1" runat="server" OnTextChanged="Course_Domain_1_change"  AutoPostBack="True" 
                                            CssClass="myButton" ForeColor="#003366" Height="40px" Width="100px">
                                             <asp:ListItem>Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="myButton" 
                                            Enabled="False" ForeColor="#003366" Height="40px" onload="DropDownList1_Load" 
                                            onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                                            ontextchanged="DropDownList1_TextChanged" Width="300px">
                                            <asp:ListItem>SRP001:Select Course</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                    <tr >
                        <td>2ND</td> <td><asp:DropDownList ID="Course_Domain_2" OnTextChanged="Course_Domain_2_change" runat="server" ForeColor="#003366" 
                        Height="40px" Width="100px" AutoPostBack="True"  CssClass="myButton">
                        <asp:ListItem>Select</asp:ListItem></asp:DropDownList></td>
                        <td >
                            <asp:DropDownList ID="DropDownList2" runat="server" ForeColor="#003366" 
                    Height="40px" onload="DropDownList2_Load" Width="300px" 
                                onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                                Enabled="False" CssClass="myButton">
                                <asp:ListItem>SRP001:Select Course</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr >
                        <td>3RD</td>
                         <td><asp:DropDownList ID="Course_Domain_3" runat="server" ForeColor="#003366"  OnTextChanged="Course_Domain_3_change"
                        Height="40px" Width="100px" AutoPostBack="True"  CssClass="myButton">
                        <asp:ListItem>Select</asp:ListItem></asp:DropDownList></td>
                        <td >
                            <asp:DropDownList ID="DropDownList3" runat="server" ForeColor="#003366" 
                    Height="40px" onload="DropDownList3_Load" 
                     Width="300px" onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                                Enabled="False" CssClass="myButton">
                                <asp:ListItem>SRP001:Select Course</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr></asp:Panel>
                  
                    <tr>
                        <td colspan="3">
                            <center><asp:Button ID="Button1" runat="server" Text="Submit" Height="40px" Width="90%"
                         onclick="Button1_Click1" CssClass="myButton" /></center>
                        </td>
                    </tr>
                </table>
                
            </asp:Panel>
        </center>
   
    </div>
    </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

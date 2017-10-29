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
        .style4
        {
            height: 25px;
        }
        .style5
        {
            width: 325px;
        }
        .style7
        {
            width: 120px;
        }
        .style8
        {
            height: 25px;
            width: 120px;
        }
        .style9
        {
            width: 913px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel2" runat="server" Height="16px">
            <asp:Panel ID="Panel3" runat="server" Height="48px" HorizontalAlign="Right" 
                Wrap="False">
                <table><tr><td class="style9"><center></center></center>
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Logout" 
                        Width="139px" />
                    </td></tr></table>
                
            </asp:Panel>
            
            <asp:Panel ID="Panel1" runat="server" BackColor="White" BorderStyle="Double" 
        BorderWidth="1px" Height="573px" CssClass="form_back" HorizontalAlign="Center" Wrap="False" 
                style="margin-top: 20px;">
                <table border="1" cellpadding="15" cellspacing="10" align="center" 
            bgcolor="#EDEDED" style="margin-top: 0px">
                    <tr>
                        <td  class="style5" colspan="2" align="center" dir="ltr" 
                nowrap="nowrap">
                            <asp:Label ID="Label1" runat="server" 
                Text="UID: " Width="100px"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" Height="25px" 
            ontextchanged="TextBox3_TextChanged" Width="189px" 
                Enabled="False" EnableTheming="True" EnableViewState="False"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" style="margin-bottom: 0px" 
                Text="Name:" Width="100px" Height="19px"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" Height="25px" 
                ontextchanged="TextBox2_TextChanged" Width="198px" Wrap="False" Enabled="False" EnableTheming="True" 
                EnableViewState="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" align="center" bgcolor="#0066FF" 
                    
                    
                            style="color: #FFFFFF; text-transform: capitalize; font-variant: normal; font-style: normal; font-weight: bold; text-decoration: underline; padding: inherit; margin: inherit">
                            <asp:Label ID="Label11" runat="server" Text="Precedence 1"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:DropDownList ID="DropDownList1" runat="server" ForeColor="#003366" 
                        Height="40px" onload="DropDownList1_Load" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="300px" 
                                ontextchanged="DropDownList1_TextChanged">
                                <asp:ListItem>SRP001:Select Course</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr >
                        <td  class="style8" align="center" bgcolor="#0066FF" 
                    
                    
                            style="color: #FFFFFF; text-transform: capitalize; font-variant: normal; font-style: normal; font-weight: bold; text-decoration: underline; padding: inherit; margin: inherit">
                            &nbsp;<asp:Label runat="server" Text="Precedence 2" ID="Label3"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:DropDownList ID="DropDownList2" runat="server" ForeColor="#003366" 
                    Height="40px" onload="DropDownList2_Load" Width="300px" 
                                onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                <asp:ListItem>SRP001:Select Course</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr >
                        <td  class="style8" align="center" bgcolor="#0066FF" 
                         
                         
                            style="color: #FFFFFF; text-transform: capitalize; font-variant: normal; font-style: normal; font-weight: bold; text-decoration: underline; padding: inherit; margin: inherit">
                            <asp:Label ID="Label4" runat="server" Text="Precedence 3"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:DropDownList ID="DropDownList3" runat="server" ForeColor="#003366" 
                    Height="40px" onload="DropDownList3_Load" 
                     Width="300px" onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                                <asp:ListItem>SRP001:Select Course</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                  
                    <tr>
                        <td class="style7" align="right" colspan="2" 
                        nowrap="nowrap">
                            <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="#00FF99" Height="40px" 
                        Width="651px" onclick="Button1_Click1" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
    <center>
            <div id="pop" style="display:none;">
            <asp:Button ID="Button3" runat="server" Text="Confirm" onclick="Button3_Click" />&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Text="Cancel" onclick="Button4_Click" /><hr>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div></center>
            <center>
            <div id="pop_already" style="display:none;">
            <h1>Your Precedence is Already Submitted!!</h1>
            <asp:Button ID="Button6" runat="server" Text="Go Back" onclick="Button5_Click" /><hr>
                
            </div></center>
            <center>
            <div id="pop_submitted" style="display:none;">
            <h1>Your Precedence is Submitted Successfully!!</h1>
            <asp:Button ID="Button5" runat="server" Text="Go Back" onclick="Button5_Click1" /><hr>
                
            </div></center>
    </div>
    </form>
</body>
</html>

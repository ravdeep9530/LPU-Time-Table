<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify_By_Uid.aspx.cs" Inherits="Time_Table.Modify_By_Uid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link rel="Stylesheet" href="CSS/StyleSheet1.css" />
</head>
<style>
    body
{
    
    background-image:url('Pics/LP-Page-color2.jpg');
    background-repeat:no-repeat;
    background-attachment:fixed;
    background-position:center;
    font-family: "Century Gothic", CenturyGothic, AppleGothic, sans-serif;
    
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

        </style>
     
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

        <script type="text/javascript">
            document.onkeydown = function (evt) {
                evt = evt || window.event;
                var isEscape = false;
                if ("key" in evt) {
                    isEscape = evt.key == "Escape";
                } else {
                    isEscape = evt.keyCode == 27;
                }
                if (isEscape) {
                    // alert("Escape");
                    Close_add_pop_btn();
                }
            };
            function confirmation() {
                if (confirm("Are you sure you want to delete?"))
                    return true;
                else return false;
            }
            function Show_add_pop() {
                var divv = $(".add_pop");
                
                var top = Math.max($(window).height() / 2 - divv[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - divv[0].offsetWidth / 2, 0);
                divv.css({ top: top, left: left });
                divv.attr("hight", "100%");
                divv.hide();
                divv.slideDown(600);
                
            }
            function Close_add_pop() {
                var divv = $(".add_pop");


                divv.hide();

            }
            function Close_add_pop_btn() {
                var divv = $(".add_pop");
                
               
                divv.slideUp(400);

            }
            function Show_notify_btn() {
                var divv = $("#notify");

                var top = Math.max($(window).height() / 2 - divv[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - divv[0].offsetWidth / 2, 0);
                divv.css({ top: top, left: left });
                divv.fadeIn(500).delay(1500).fadeOut(700);

            }

</script>
<body onload="Close_add_pop();">


    <div class="loading" align="center">
        <br />
        <img src="loading.gif" alt="" />
    </div>

    <form id="form1" runat="server">
    
   


    <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"
 UpdateMode="Conditional">

 <ContentTemplate>
  <div>
    <div class="round-button" style="float:right; right:0;">
    <a href="Time_table_manager.aspx">
        <img src="http://codeitdown.com/media/Home_Icon.svg" alt="Home"  />
    </a>
</div>


                            <div style="background-color:transparent;
        padding: 10px 20px; width:35%; float: left; position:absolute; margin-left:-1.5%;">
        <table bgcolor="white"><tr><td colspan="3" style="text-align:center; background-color:#848325; color:White;"><b>Allocated Load</b></td>
        </tr><tr><td colspan="1">UID:<asp:Label runat="server" ID="T_Uid"></asp:Label></td><td colspan="2">Name:<asp:Label runat="server" ID="T_Name"></asp:Label></td></tr>
        <tr  style="background-color:#3f868c; color:White;"><td >TL:<asp:Label runat="server" ID="T_TL"></asp:Label></td><td>TT:<asp:Label runat="server" ID="T_TT"></asp:Label></td><td>TP:<asp:Label runat="server" ID="T_TP"></asp:Label></td></tr>
        <tr><td  style="background-color:#b3473d; color:White;">Total Load:<asp:Label runat="server" ID="T_Total"></asp:Label></td>
        <td  style="background-color:#b3473d; color:White;">Total Credit:<asp:Label runat="server" ID="T_Credit"></asp:Label></td>
         <td  style="background-color:#b3473d; color:White;">Max Load:<asp:Label runat="server" ID="T_Max"></asp:Label></td></tr></table>
    </div>
 <div style="padding:0%; height:100%; width:100%; top:0; right:0; background-color:rgba(255,255,255,1); position:absolute; " class="add_pop" >
<center><asp:Label runat="server" ID="notify" CssClass="myLabel"   Font-Bold="True" style="padding:2%; position:absolute;"  Font-Size="Medium" ForeColor="#FF9933" Visible="False" Width="50%"></asp:Label></center>
<br />
<br />
 <center><table style="width:25%; padding:2%; border:5px;  border-style:double;" class="myButton">
     <caption
         <br />
         <tr>
             <td>
                 UID:</td>
             <td>
                 <asp:Label ID="add_UID" runat="server"></asp:Label>
             </td>
         </tr>
         <tr>
             <td>
                 Total Allocated Load:</td>
             <td>
                 <asp:Label ID="add_AL" runat="server"></asp:Label>
             </td>
         </tr>
         <tr>
             <td>
                 Total Allocated Credit:</td>
             <td>
                 <asp:Label ID="add_credit" runat="server"></asp:Label>
             </td>
         </tr>
     </caption>
 </table></center>
 <br />
 <hr />
 <center>
 <table><tr><th>Select Domain</th><th>Select Course</th><th>Select Section</th><th>TL</th><th>TT</th><th>TP</th><th>Credit</th></tr>
 <tr><td style="width:15%;"><asp:DropDownList ID="Select_Domain" CssClass="myButton" OnTextChanged="add_Domain" AutoPostBack="true"   runat="server"></asp:DropDownList>
 </td>
 <td style="width:40%;"><asp:DropDownList ID="add_course" CssClass="myButton" OnTextChanged="add_section" AutoPostBack="true"   runat="server"></asp:DropDownList>
 </td><td><asp:DropDownList ID="add_Sec" CssClass="myButton" AutoPostBack="true" OnTextChanged="add_load" Enabled="false" runat="server"></asp:DropDownList>
 <td><asp:Label runat="server" ID="TL"></asp:Label></td><td><asp:Label runat="server" ID="TT"></asp:Label></td>
 <td><asp:Label runat="server" ID="TP"></asp:Label></td><td><asp:Label runat="server" ID="Credit"></asp:Label></td>
 </td></tr>
 <tr><td colspan="6"><center><asp:Button runat="server" Text="Add New" ID="add_new" 
         CssClass="myButton" OnClick="add_new_course" Visible="False"  /></center></td></tr></table>
 </center>
 <center>
<asp:Button CssClass="myButton_edit" runat="server" Text="Close" style=" margin-top:10%; font-size:15px; padding:15px;" OnClick="Close_add_pop_btn" />
</center>
 </div>

    <div>
        
            <center>
                <img src="Pics/lpu_logo.png" /></center>
        
    </center>
    </div>
    <center>
    <br />
    <br />
        <br />
            <br />
            <br />
     <asp:GridView ID="modify"  HeaderStyle-BackColor="#3AC0F2" ShowFooter="true"
            HeaderStyle-ForeColor="White" runat="server" AutoGenerateColumns="false"
            onrowdatabound="modify_RowDataBound" 
            onselectedindexchanged="modify_SelectedIndexChanged" 
            onrowediting="modify_RowEditing" onrowdeleted="modify_RowDeleted" 
            onrowdeleting="modify_RowDeleting" 
            onrowcancelingedit="modify_RowCancelingEdit" onrowupdating="modify_RowUpdating" 
            Font-Size="Small" EmptyDataText="Record Not Found" 
            ShowHeaderWhenEmpty="True" AllowSorting="True">
    <Columns>
    <asp:TemplateField HeaderText="Hash Code">
    <ItemTemplate>
    <asp:Label ID="hash_code" runat="server" Text='<% #Eval("hash") %>'></asp:Label>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Uid">
    <ItemTemplate>
    <asp:Label ID="M_Uid" runat="server" Text='<% #Eval("M_Uid") %>'></asp:Label>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
    <asp:Label ID="M_N" runat="server" Text='<% #Eval("M_Name") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Course Code"><ItemTemplate>
    <asp:Label runat="server" ID="CC_Label" Text='<% #Eval("M_CC") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
    <asp:DropDownList ID="n" runat="server" OnSelectedIndexChanged="dN_TextChange"  AutoPostBack="True" CssClass="myButton"></asp:DropDownList>
    </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Section Number">
    <ItemTemplate>
    <asp:Label runat="server" ID="Sec_Label" Text='<% #Eval("M_SN") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
     <asp:DropDownList ID="SN" runat="server" OnSelectedIndexChanged="SN_TextChanged"  AutoPostBack="True" CssClass="myButton"></asp:DropDownList>
    </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="TL">
    <ItemTemplate>
    <asp:Label ID="M_TL" runat="server" Text='<% #Eval("M_TL") %>'></asp:Label>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="TT">
    <ItemTemplate>
    <asp:Label ID="M_TT" runat="server" Text='<% #Eval("M_TT") %>'></asp:Label>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="TP">
    <ItemTemplate>
    <asp:Label ID="M_TP" runat="server" Text='<% #Eval("M_TP") %>'></asp:Label>
    </ItemTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="Load">
     <ItemTemplate>
     <asp:Label runat="server" ID="AL" Text='<% #Eval("M_AL") %>'></asp:Label>
     </ItemTemplate>
     </asp:TemplateField>
     <asp:TemplateField HeaderText="Credit">
     <ItemTemplate>
     <asp:Label runat="server" ID="Credit" Text='<% #Eval("M_Credit") %>'></asp:Label>
     </ItemTemplate>
     </asp:TemplateField>
     <asp:TemplateField HeaderText="Action">
     <ItemTemplate>
     <asp:LinkButton ID="LinkButton1" CommandName="Edit" CssClass="myButton" runat="server"  Text="Edit" />
     </ItemTemplate>
     <EditItemTemplate>
     <asp:LinkButton ID="update_button" runat="server"  CommandName="Update"   Text="Update" Enabled="False" CssClass="myLabel"></asp:LinkButton><br /><br />
     <asp:LinkButton ID="Delete_button" runat="server" CommandName="Delete" OnClientClick="return confirmation();" CssClass="myButton_edit" Text="Delete"></asp:LinkButton><br /><br />
     <asp:LinkButton ID="Cance_button" runat="server" CommandName="Cancel" CssClass="myButton_edit" Text="Cancel"></asp:LinkButton>
     </EditItemTemplate>
     <FooterTemplate>
<asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="myButton"  OnClick="add_btn" />
</FooterTemplate> 
     </asp:TemplateField>
     
          
            
        
    </Columns>
    <EmptyDataTemplate>
    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="myButton"  OnClick="add_btn" />
    </EmptyDataTemplate>
    </asp:GridView>
    </center>
          </ContentTemplate>
          </asp:UpdatePanel>
         
    </div>
    </div>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
    <div class="modal">
        <div class="center">
            <center><img alt="" src="loading.gif" style="margin-top:15%;" /></center>
        </div>
    </div>
</ProgressTemplate>
</asp:UpdateProgress>
    </form>
    
</body>
</html>

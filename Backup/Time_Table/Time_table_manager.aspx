<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Time_table_manager.aspx.cs"
    Inherits="Time_Table.Time_table_manager" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <link rel="Stylesheet" href="CSS/StyleSheet1.css" />
 
    <title></title>
        <style>
        
    body
{
    
    background-image:url('Pics/LP-Page-color2.jpg');
    background-repeat:no-repeat;
    background-attachment:fixed;
    background-position:center;
   
    
}
        </style>
        </head>
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
            closepop();
        }
    };
    function confirmation() {
        if (confirm("It takes few minutes.Don't refresh or close the page!!"))
            return true;
        else return false;
    }
    function Confirm() {
        if (confirm("Are you Sure!!!"))
            return true;
        else return false;
    }
    function onme() {
        alert("sss");
    }
    
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
  //  $('form').live("submit", function () {
    //    ShowProgress();
   // });
</script>
<script>
    function button_click(objTextBox, objBtnID) {
        if (window.event.keyCode == 13) {
            document.getElementById(objBtnID).focus();
            document.getElementById(objBtnID).click();
        }
    }
    var modal = document.getElementById('open');
    function showpop() {
          document.getElementById('open').style.display = "block";
        document.getElementById('pop').style.display = "block";
        var divv = $("#pop");
       
        
       
        var top = Math.max($(window).height() / 2 - divv[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 2 - divv[0].offsetWidth / 2, 0);
        divv.css({ top: top, left: left });

    }
    function showload() {
        document.getElementById('load').style.display = "block";

    }
    function closeload() {
        document.getElementById('load').style.display = "none";

    }
    function closepop() {
       document.getElementById('open').style.display = "none";
        
        document.getElementById('pop').style.display = "none";

    }</script>
<body>
  
    <form id="form1" runat="server">
   
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
   <div>
        
            <center>
                <img src="Pics/lpu_logo.png" /></center>
        
    </center>
    </div>    
    
    
       
       
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <div id="open" class="modal" style="display:none;"; >
     </div>
     <div id="pop"  style="display: none; background-color: White;  z-index:1000; overflow: auto; position: absolute;">
            <li style="  top: 0%; right:0;   float:right;  position:absolute; list-style: none; cursor: pointer; 
                color: White; display: block;" onclick="closepop();"><img src="Pics/8934.png" width="30px" height="30px" /></li>
            <center>
             <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </center>
            
        
        </div>
   
    <div style="position:absolute; right:0; padding:0;  top:3.5%; width:25%; ">
    <table><tr><td>TL:- Total Number Of Leactures</td></tr>
    <tr><td>TT:- Total Number Of Tutorials</td></tr>
    <tr><td>TP:- Total Number Of Practicals</td></tr></table>
    </div>
    <div style="background-color:transparent;
        padding: 10px 20px; width: 230px; float: left; margin-top:-15%; position:absolute; margin-left:-1.5%;">
        <table bgcolor="white"><tr><td colspan="3" style="text-align:center; background-color:#293955; color:White;  text-shadow: 2px 2px 2px #000;"><b>Pending Load</b></td>
        </tr><tr><td>TL:<asp:Label runat="server" ID="TL"></asp:Label></td><td>TT:<asp:Label runat="server" ID="TT"></asp:Label></td><td>TP:<asp:Label runat="server" ID="TP"></asp:Label></td></tr>
        <tr><th colspan="3" style="background-color:#b3473d; color:White;  text-shadow: 2px 2px 2px #000;">Required Teacher:<asp:Label runat="server" ID="TNT"></asp:Label></th></tr><tr style="padding:0px; margin:0px;"><td style="padding:0px; margin:0px;" colspan="3">
        <asp:Button ID="Button10" runat="server" Text="Check" Height="30px" OnClick="ButtonFinal_Click"
                Width="100%" BackColor="White" BorderStyle="Groove" CssClass="myButton" />
        </td></tr></table>
    </div>
    
        <center>
        <div style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            background-color:transparent; padding: 20px 15px; margin-top: 50px;">
            <asp:Button ID="Button7" runat="server" Text="Optimize Database" Height="44px" Width="146px"
                OnClick="Button7_Click" BackColor="White" BorderStyle="Groove" CssClass="myButton" />
           
            <asp:Button ID="Button2" runat="server" Text="Phase One" Height="44px" Width="126px"
                OnClick="Button2_Click" BackColor="White" BorderStyle="Groove" CssClass="myButton" />
            <asp:Button ID="Button5" runat="server" Text="Phase Two" Height="44px" Width="106px"
                OnClick="Button5_Click" BackColor="White" BorderStyle="Groove" CssClass="myButton" />
            <asp:Button ID="Button6" runat="server" Text="Phase Three" Height="44px" Width="110px"
                OnClick="Button6_Click" BackColor="White" BorderStyle="Groove" CssClass="myButton" />
            <asp:Button ID="Button8" runat="server" Text="Phase Four" Height="44px" OnClick="Button8_Click"
                Width="109px" BackColor="White" BorderStyle="Groove" CssClass="myButton" />
            <asp:Button ID="Button9" runat="server" Text="Domain wise" Height="44px" OnClick="Button8_Click"
                Width="111px" BackColor="White" BorderStyle="Groove" CssClass="myButton" />
                
            <asp:Button ID="Button3" runat="server" Text="Reset" OnClientClick="return Confirm()" Height="44px" Width="104px"
                OnClick="Button3_Click" BackColor="White" BorderStyle="Groove" CssClass="myButton" />
                 <asp:Button ID="Button1" runat="server" Text="Logout" Height="44px" OnClick="Button1_Click"
                Width="116px" BackColor="White" BorderStyle="Groove" CssClass="myButton" />
                
            <br />
           
        </div>
    </center>
    <br />

    <br />
  
      <div  class="div_component">

        <p class="label_heading">
            Check Load By UID</p>
        
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Find" CssClass="myButton" />
        
        
        
    </div>
    
    <div  class="div_component">

        <p class="label_heading">
            Check Load By Domain</p>
        
         <center>
           <asp:DropDownList ID="Check_Domain_List" runat="server" AutoPostBack="True" 
               CssClass="myButton" onload="Load_Check_By_Domain" 
               ontextchanged="Load_Check_By_Domain_TextChanged" Width="120px">
           </asp:DropDownList>
            </center>
        </div>

         <div class="div_component">

        <p class="label_heading">
            Check Load By Section No</p>
        
       <center>
           <asp:DropDownList ID="Check_By_Section" runat="server" AutoPostBack="True" 
               CssClass="myButton" onload="Check_By_Section_Load" 
               ontextchanged="Check_By_Section_TextChanged" Width="120px" ViewStateMode="Enabled" ClientIDMode="Static">
           </asp:DropDownList>
            </center>
        </div>
       
       
         <div class="div_component">
        <p class="label_heading">
            Section Mentor Allocation</p>
        
       <center>
        <asp:Button ID="Section_Mentor_Allocation" runat="server"
            Text="Mentor Allocate" CssClass="myButton" OnClientClick="return confirmation();"
               onclick="Section_Mentor_Allocation_Click"  />
            </center>
        </div>
    <br />
      <br />
       <div style="clear:inherit; margin-top:7%;" class="div_component_large">    
        <p class="label_heading_large">
            IMPORT/EXPORT RECORDS </p>  
            <center>
        <table style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0),0 0px 0px 0 rgba(0,0,0,0);" ><tr ><td >
        <div class="div_component_min" >
        <p class="label_heading">
            Import From Excel Sheet </p>
        
       <center>
        <asp:Button ID="Import" runat="server"
            Text="Import Load" CssClass="myButton" onclick="Import_Click"
                />
                 <asp:Button ID="Button12" runat="server"
            Text="Import Strength" CssClass="myButton" onclick="Button12_Click" 
                />
            </center>
           </div>
           </td>
              
                  
                  
                  
                  <td>
                      <div class="div_component_min">
                          <p class="label_heading">
                              Export To Excel,Pdf,Word,CVS
                          </p>
                          <center>
                              <asp:Button ID="Export" runat="server" CssClass="myButton" 
                                  onclick="Export_Click" Text="Export" />
                          </center>
                      </div>
                  </td>
                  
                          <td >
                             
                                  <div class="div_component_min" style="border-right: 2px double #c9c9c9;">
                                      <p class="label_heading">
                                          Export From Backup&#39;s
                                      </p>
                                      <center>
                                          <asp:DropDownList ID="date_list" runat="server" AutoPostBack="True" 
                                              CssClass="myButton" onload="date_list_Load" 
                                              ontextchanged="date_list_TextChanged">
                                          </asp:DropDownList>
                                          <asp:DropDownList ID="Pre_Db_list" runat="server" AutoPostBack="True" 
                                              CssClass="myButton" Enabled="False" Width="30%" 
                                              ontextchanged="Pre_Db_list_TextChanged">
                                          </asp:DropDownList>
                                          <asp:Button ID="Button11" runat="server" CssClass="myButton" 
                                              onclick="Button11_Click" Text="Export" Enabled="False" />
                                      </center>
                                  </div>
                             
                          </td>
                      
                  
           
        </tr>
       </table>
       </center>
       </div>
       

    </ContentTemplate>
    </asp:UpdatePanel>
   <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
    <div class="modal">
        <div class="center">
            <center><img alt="" src="loading.gif" style="margin-top:15%;" /></center>
        </div>
        </div>
</ProgressTemplate>
</asp:UpdateProgress>
   <!--  <div style="display:block;">
        

        
   <table border='1' cellpadding='5' cellspacing='0'><tr>
    <th><b>UID</b></th><th><b>Name</b></th><th><b>Course Code</b></th><th><b>Course Title</b></th><th><b>Section Number</b></th><th><b>Allocated Load</b></th></tr>
    <tr>
    <td>-->
    <!--
    <asp:GridView ID="modify" HeaderStyle-BackColor="#3AC0F2" 
            HeaderStyle-ForeColor="White" runat="server" AutoGenerateColumns="false" 
            onrowdatabound="modify_RowDataBound" 
            onselectedindexchanged="modify_SelectedIndexChanged" 
            onrowediting="modify_RowEditing" onrowdeleted="modify_RowDeleted" 
            onrowdeleting="modify_RowDeleting" 
            onrowcancelingedit="modify_RowCancelingEdit" onrowupdating="modify_RowUpdating" 
            >
    <Columns>
    <asp:TemplateField HeaderText="Hash Code">
    <ItemTemplate>
    <asp:Label ID="hash_code" runat="server" Text='<% #Eval("hash") %>'></asp:Label>
    </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Uid">
    <ItemTemplate>
    <asp:Label ID="M_Uid" runat="server" Text='<% #Eval("M_Uid") %>'></asp:Label>
    </ItemTemplate></asp:TemplateField>
    
    <asp:BoundField DataField="M_Name" HeaderText="Name" ReadOnly=true />
    
    <asp:TemplateField HeaderText="Course Code"><ItemTemplate>
    <asp:Label runat="server" ID="CC_Label" Text='<% #Eval("M_CC") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
    <asp:DropDownList ID="n" OnSelectedIndexChanged="dN_TextChanged"  runat="server" AutoPostBack="True" CssClass="myButton" Width="350"></asp:DropDownList>
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
     <asp:LinkButton CommandName="Edit" runat="server"  Text="Edit" />
     </ItemTemplate>
     <EditItemTemplate>
     <asp:LinkButton ID="update_button" runat="server" CommandName="Update"  Text="Update"  ></asp:LinkButton>
     <asp:LinkButton ID="Delete_button" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
     <asp:LinkButton ID="Cance_button" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
     </EditItemTemplate>
     </asp:TemplateField>
    </Columns>
    </asp:GridView>-->
    <!--
    </td>
    </tr>
    </table>-->
    <!--<td colspan="6"><asp:DropDownList runat="server" ID="domain_modify"></asp:DropDownList></td></tr><tr><th><b>UID</b></th><th><b>Name</b></th><th><b>Course Code</b></th><th><b>Course Title</b></th><th><b>Section Number</b></th><th><b>Allocated Load</b></th></tr>
    <tr><td><asp:Label runat="server" ID="uid"></asp:Label></td><td><asp:Label runat="server" ID="name"></asp:Label></td><td><asp:DropDownList runat="server" ID="CC"></asp:DropDownList></td>
    <td><asp:DropDownList runat="server" ID="CT"></asp:DropDownList></td><td><asp:DropDownList runat="server" ID="ST"></asp:DropDownList></td><td><asp:Label runat="server" ID="AL"></asp:Label></td></tr>
           
     
</div> --> 
    <p>
        &nbsp;</p>
    </form>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Excel_IE.aspx.cs" Inherits="Time_Table.Excel_IE" %>

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
</style>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    function show_pre_pop() {
        $('#pre_pop').fadeIn("slow");
        document.getElementById('open').style.display = "block";
        return false;
    }
    function hide_pre_pop() {
        $('#pre_pop').hide();
        document.getElementById('open').style.display = "none";
    }
    function show_load_btn() {
        
       // document.getElementById('btn_load').style.display = "block";
    }
  
</script>
<body onload="hide_pre_pop();">
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
   
    <div id="open" class="overlay" style="display:none;"; >
     </div>
    <div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    
    <center>
     <div class="myButton" style="padding-bottom:0.2%; padding-top:1.5%; float:none; right:0; width:100%; top:0; position:fixed; box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);">
     <div class="round-button">
    <a href="Time_table_manager.aspx">
        <img src="http://codeitdown.com/media/Home_Icon.svg" alt="Home"  />
    </a>
</div>
<b>Please Select Excel File: </b>
<asp:FileUpload ID="fileuploadExcel" runat="server" CssClass="myButton" />&nbsp;&nbsp;
<asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click"  CssClass="myButton_edit" />

            <asp:Button runat="server" ID="btn_load"  
             OnClientClick="return show_pre_pop();" CssClass="myButton_edit" 
             Text="Load To Database" Visible="False" />
<br />
<asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label><br />
</div>
</center>  
      
   
        
       <div id="pre_pop" style="  width:30%;  height:44%; padding:1%; top:27%; left:35%; z-index:14; background-color:White; position:absolute; box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);">
       <p class="label_heading">Are You Want Make Previous Database backup copy?</p>
      <center> <table  border=1px cellpadding=0 cellspacing=0 style="border-style:0.5px;  box-shadow: 0 0px 0px 0 rgba(0,0,0,0),0 0px 0px 0 rgba(0,0,0,0);"><tr>
       <td align="center">
           <asp:RadioButton  ID="confirm_backup_yes"  runat="server" 
               Text="Yes" GroupName="confirm" 
               oncheckedchanged="confirm_backup_yes_CheckedChanged" AutoPostBack="True" Checked="False" /></td>
          <td align="center"><asp:RadioButton ID="confirm_backup_no" runat="server" 
                  GroupName="confirm"  Text="No" 
                  oncheckedchanged="confirm_backup_no_CheckedChanged" AutoPostBack="True" /></td>
       </tr>
     
       <tr><td colspan="2" Class="style-4"><asp:Panel runat="server" Visible=false ID="pre_name_panel"><center><font size=1px; >Insert Backup Database Name.(By Default it's Today Date)</font></center><br /><center><asp:TextBox runat="server" 
               ID="Pv_Db_Name" Width=80% 
               CssClass="style-4" placeholder="Insert Database Name" Visible="False" 
               onload="Pv_Db_Name_Load"></asp:TextBox></center></asp:Panel></td></tr>
                
               
          <caption>
              <BR />
              <tr>
                  <td colspan="2">
                      <center>
                          <asp:Button ID="ok" runat="server" OnClientClick="hide_pre_pop();" CssClass="myButton" Text="OK" 
                              Visible="False" Width="30%" onclick="ok_Click" />
                      </center>
                  </td>
              </tr>
          </caption>

       </table>
       </center>
       </div>
       
    <div id="open" class="modal" style="display:none;"; >
     </div>
  
      <div class="loading" align="center">
    Loading. Please wait.<br />
    <br />
    <img src="loading.gif" alt="" />
</div>
      
        
       
   
<br />
<br />
<br />
<br />
<center>
<div style="padding:1%; width:80%;" class="myButton">
<p>Excel Sheet Must be same Columns Header Name.<br /><font color=red>Note:Header Name is Case-senstive.</font></p>
<img src="Pics/header_logo_export.PNG" width="100%" />
</div>
</center>
<br />
<asp:GridView ID="grvExcelData" runat="server" Font-Size="X-Small" 
            onselectedindexchanged="grvExcelData_SelectedIndexChanged" 
            onpageindexchanging="grvExcelData_PageIndexChanging">
<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
</asp:GridView>
</ContentTemplate>

<Triggers>
               <asp:PostBackTrigger ControlID="btnImport"  />
               
           </Triggers>
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
</div>

    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Export_To_Excel.aspx.cs" Inherits="Time_Table.Export_To_Excel"
EnableEventValidation="false" %>

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
<body>
    <form id="form1" runat="server">
    
    <center><div style="padding-bottom:0.6%; padding-top:1.5%; float:none; right:0; width:100%; top:0; position:fixed; box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);"
  class="myButton">
  <div class="round-button">
    <a href="Time_table_manager.aspx">
        <img src="http://codeitdown.com/media/Home_Icon.svg" alt="Home"  />
    </a>
</div>
    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick = "ExportToExcel" CssClass="myButton" />
     <asp:Button ID="btnExportpdf" runat="server" Text="Export To Pdf"  
            CssClass="myButton" onclick="btnExportpdf_Click" />
             <asp:Button ID="btnExportword" runat="server" Text="Export To Word"  
            CssClass="myButton" onclick="btnExportword_Click" />
            <asp:Button ID="btnExportCVS" runat="server" Text="Export To CVS"  
            CssClass="myButton" onclick="btnExportCVS_Click" />
             <asp:Button ID="btnExportText" runat="server" Text="Export To Text"  
            CssClass="myButton" onclick="btnExportText_Click"  />
    </div></center>
    <div><center>
    <br />
    <br />
    <br />
    <br />
   <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
           
             onpageindexchanging="GridView1_PageIndexChanging" 
            PageSize="10" Font-Size="X-Small">
    <Columns>
        <asp:BoundField DataField="Department" HeaderText="Department" 
            ItemStyle-Width="150px" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Section_Number" HeaderText="Section_Number" 
            ItemStyle-Width="100px" >
<ItemStyle Width="100px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Year" HeaderText="Year" ItemStyle-Width="100px" >
<ItemStyle Width="100px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Term" HeaderText="Term" />
        <asp:BoundField DataField="Course_Code" HeaderText="Course Code" />
        <asp:BoundField DataField="Course_Title" HeaderText="Course Title" />
        <asp:BoundField DataField="L" HeaderText="L" />
        <asp:BoundField DataField="T" HeaderText="T" />
        <asp:BoundField DataField="P" HeaderText="P" />
        <asp:BoundField DataField="Groups" HeaderText="Groups" />
        <asp:BoundField DataField="TL" HeaderText="TL" />
        <asp:BoundField DataField="TT" HeaderText="TT" />
        <asp:BoundField DataField="TP" HeaderText="TP" />
        <asp:BoundField DataField="Course_Domain" HeaderText="Course_Domain" />
        <asp:BoundField DataField="Feculty_Name" HeaderText="Feculty Name" />
        <asp:BoundField DataField="UID" HeaderText="U.ID" />
    </Columns>

       
       

       
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="15" />

       
       

       
        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" 
            Font-Size="X-Small" Wrap="True" />

</asp:GridView>
</center>
<br />

    </div>
    </form>
</body>
</html>

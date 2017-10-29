using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace Time_Table
{
    public partial class Excel_IE : System.Web.UI.Page
    {
        string connectionString = "";
        int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Pv_Db_Name.Text = DateTime.Today.Date.ToString("dd_MM_yyyy") + "_database_backup";
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            

            if (fileuploadExcel.HasFile)
            {
                string fileName = Path.GetFileName(fileuploadExcel.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fileuploadExcel.PostedFile.FileName);
                string fileLocation = Server.MapPath("~/uploads/" + fileName);
                fileuploadExcel.SaveAs(fileLocation);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {

                    //Check whether file extension is xls or xslx

                   

                    //Create OleDB Connection and OleDb Command
                    ExToGv(fileExtension,fileLocation);
                   
                }
                else
                {
                    lblMessage.Text = "File Not Supported.Must be .xls or .xlsx .";
                    lblMessage.Visible = true;
                  btn_load.Visible = false;
                }

            }
            else
            {
                lblMessage.Text = "Firstly Select File!! Must be .xls or .xlsx .";
                lblMessage.Visible = true;
            }
            
        }

        protected void ExToGv( String fileExtension,String fileLocation)
        {
            try
            {
                if (fileExtension == ".xls")
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
                }
                else if (fileExtension == ".xlsx")
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=Excel 12.0;";
                }
                btn_load.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "show_load_btn();", true);
                lblMessage.Visible = false;
                OleDbConnection con = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                DataTable dtExcelRecords = new DataTable();
                con.Close();
                con.Open();
                DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                dAdapter.SelectCommand = cmd;
                dAdapter.Fill(dtExcelRecords);
                con.Close();
                grvExcelData.DataSource = dtExcelRecords;
                grvExcelData.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
            }
        }
        protected void confirm_backup_yes_CheckedChanged(object sender, EventArgs e)
        {
            ok.Visible = true;
            Pv_Db_Name.Visible = true;
            pre_name_panel.Visible = true;
            Pv_Db_Name.Focus();
            flag = 1;
        }

        protected void confirm_backup_no_CheckedChanged(object sender, EventArgs e)
        {
            ok.Visible = true;
            Pv_Db_Name.Visible = false;
            pre_name_panel.Visible = false;
        }

        protected void grvExcelData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ok_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "load();", true);
            if(confirm_backup_no.Checked)
            new DatabaseConnectionManager().Insert_Into_Database(grvExcelData, this, lblMessage,0,"");
            if(confirm_backup_yes.Checked)
                new DatabaseConnectionManager().Insert_Into_Database(grvExcelData, this, lblMessage,1,Pv_Db_Name.Text);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1,UpdatePanel1.GetType(), "", "hide_pre_pop();", true);
           

        }

        protected void grvExcelData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvExcelData.PageIndex = e.NewPageIndex;
           // ExToGv();
        }

        protected void Pv_Db_Name_Load(object sender, EventArgs e)
        {
           
        }
    }
}
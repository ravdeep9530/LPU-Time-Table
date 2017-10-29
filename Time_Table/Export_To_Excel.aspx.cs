using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using iTextSharp.tool.xml;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf; 
namespace Time_Table
{
    public partial class Export_To_Excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();
        }
        public void Bind()
        {
            try
            {
                String query=Application["query"].ToString();
                GridView1.DataSource = new DatabaseConnectionManager().Export_To_Excel(query);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                //btnExportpdf.Text = ""+ex.Message;
              //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('" + ex.Message + "');", true);
                Response.Redirect("Time_table_manager.aspx");
            }
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
           /* Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                this.Bind();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }*/
            string fileName = "ExportToExcel_" + DateTime.Now.ToShortDateString() + ".xls",
   contentType = "application/vnd.ms-excel";

            //call 1st export method with fileName and contentType
            ExportFile(fileName, contentType);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnExportpdf_Click(object sender, EventArgs e)
        {
            //GridView1.AllowPaging = false;
            //Bind();
           // btnExportCVS.Text = "ddd";
            GridView1.Font.Size = 10;
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    GridView1.AllowPaging = false;
                    this.Bind();

                    GridView1.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
            
       
        private void ExportFile(string fileName, string contentType)
        {
            //disable paging to export all data and make sure to bind griddata before begin
            GridView1.AllowPaging = false;
            Bind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
            Response.ContentType = contentType;
            StringWriter objSW = new StringWriter();
            HtmlTextWriter objTW = new HtmlTextWriter(objSW);
            GridView1.RenderControl(objTW);
            Response.Write(objSW);
            Response.End();
        }

        //2nd Method: To Export to CSV, Text file
        private void ExportTextBasedFile(string fileName, string contentType)
        {
            //disable paging to export all data and make sure to bind griddata before begin
            GridView1.AllowPaging = false;
            Bind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
            Response.ContentType = contentType;
            StringBuilder objSB = new StringBuilder();
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                objSB.Append(GridView1.Columns[i].HeaderText + ',');
            }
            objSB.Append("\n");
            for (int j = 0; j < GridView1.Rows.Count; j++)
            {
                for (int k = 0; k < GridView1.Columns.Count; k++)
                {
                    objSB.Append(GridView1.Rows[j].Cells[k].Text + ',');
                }
                objSB.Append("\n");
            }
            Response.Write(objSB.ToString());
            Response.End();
        }

        protected void btnExportword_Click(object sender, EventArgs e)
        {
            string fileName = "ExportToWord_" + DateTime.Now.ToShortDateString() + ".doc",
   contentType = "application/ms-word";
            //call 1st export method with fileName and contentType
            ExportFile(fileName, contentType);
        }

        protected void btnExportCVS_Click(object sender, EventArgs e)
        {
            string fileName = "ExportToCSV_" + DateTime.Now.ToShortDateString() + ".csv",
  contentType = "application/text";

            //call 2nd export method with fileName and contentType
            ExportTextBasedFile(fileName, contentType);
        }

        protected void btnExportText_Click(object sender, EventArgs e)
        {
            string fileName = "ExportToText_" + DateTime.Now.ToShortDateString() + ".txt",
    contentType = "application/text";

            //call 2nd export method with fileName and contentType
            ExportTextBasedFile(fileName, contentType);
        }
        }

}
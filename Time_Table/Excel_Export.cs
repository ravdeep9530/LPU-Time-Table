using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Time_Table
{
    public class Excel_Export
    {
        Time_table_manager tm;
        public Excel_Export(Time_table_manager tm,object s,EventArgs e)
        {
            this.tm = tm;
            ExportExcel(s,e);
        }
        public void ExportExcel(object sender, EventArgs e)
        {
            string constr = "Server=localhost;Database=time_table;Uid=root;Password='';";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM load_table"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Load");

                                tm.Response.Clear();
                                tm.Response.Buffer = true;
                                tm.Response.Charset = "";
                                tm.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                tm.Response.AddHeader("content-disposition", "attachment;filename=MySqlExport.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(tm.Response.OutputStream);
                                    tm.Response.Flush();
                                    tm.Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Time_Table
{
    public partial class Time_table_manager : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                Session["uid"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("Time_Table_Login.aspx");
            }

            new DatabaseConnectionManager().GetLoad(this, PlaceHolder1, TL, TT, TP, TNT);

            if (!IsPostBack)
            {
                this.TextBox1.Attributes.Add("onkeypress", "button_click(this,'" + this.Button4.ClientID + "')");
               // this.TextBox2.Attributes.Add("onkeypress", "button_click(this,'" + this.Button10.ClientID + "')");
                date_list.DataSource = new DatabaseConnectionManager().Get_Backup_Queries("SELECT DISTINCT Date FROM Backup_Info", "Date");
                date_list.DataBind();
                date_list.Items.Add("Select Date");
                date_list.Text = "Select Date";
                
            }
                  //  Check_By_Section.Items.Add("Select");
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("uid");
            Response.Redirect("Time_Table_Login.aspx");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            new DatabaseConnectionManager().Phase_One_Load_Allocating(this, PlaceHolder1, "1", "2",UpdatePanel1);
            new DatabaseConnectionManager().GetLoad(this, PlaceHolder1, TL, TT, TP, TNT);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Response.Redirect("http://worldwiki.in");
            new DatabaseConnectionManager().reset();
            new DatabaseConnectionManager().GetLoad(this, PlaceHolder1, TL, TT, TP, TNT);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("http://worldwiki.in");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
               new DatabaseConnectionManager().Modify_By_Uid(TextBox1.Text.Trim(), PlaceHolder1, this,UpdatePanel1);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1,UpdatePanel1.GetType(), "", "alert('Firstly Provide UID!!')", true);
                TextBox1.Focus();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            new DatabaseConnectionManager().Phase_One_Load_Allocating(this, PlaceHolder1, "2", "4",UpdatePanel1);
            new DatabaseConnectionManager().GetLoad(this, PlaceHolder1, TL, TT, TP, TNT);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            new DatabaseConnectionManager().Phase_One_Load_Allocating(this, PlaceHolder1, "3", "5",UpdatePanel1);
            new DatabaseConnectionManager().GetLoad(this, PlaceHolder1, TL, TT, TP, TNT);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {


            new DatabaseConnectionManager().Optimize_Database();
            new DatabaseConnectionManager().GetLoad(this, PlaceHolder1, TL, TT, TP, TNT);

        }


        protected void Button8_Click(object sender, EventArgs e)
        {
            new DatabaseConnectionManager().Domain_Wise_Allocation(UpdatePanel1, this,PlaceHolder1,"7", "0");
            new DatabaseConnectionManager().GetLoad(this, PlaceHolder1, TL, TT, TP, TNT);
        }


        public ArrayList Modify_Load(String Uid, int nn, String Name, ArrayList CC, ArrayList CT, ArrayList SN, ArrayList AL,ArrayList HC,ArrayList TTTP)
        {

            uid.Text = Uid;
            name.Text = Name;
            String s = "";
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] {new DataColumn("hash",typeof(String)),  new DataColumn("M_Uid", typeof(string)),
                            new DataColumn("M_Name", typeof(string)),
                            new DataColumn("M_CC",typeof(String)),new DataColumn("M_SN",typeof(String)),new DataColumn("M_AL",typeof(string)),new DataColumn("M_Credit",typeof(String))});

            int credit = 0;
          //  s += "<table border='1' cellpadding='5' cellspacing='0'><tr><th><b>UID</b></th><th><b>Name</b></th><th><b>Course Code</b></th><th><b>Course Title</b></th><th><b>Section Number</b></th><th><b>Allocated Load</b></th></tr>";
            for (int i = 0; i < nn; i++)
            {

                if (AL[i].ToString() == "0")
                    credit = int.Parse(TTTP[i].ToString()) / 2;
                else
                    credit = int.Parse(AL[i].ToString());
                dt.Rows.Add(HC[i].ToString(),Uid,Name,CC[i].ToString()+":"+CT[i].ToString(),SN[i].ToString(),(int.Parse(AL[i].ToString())+int.Parse(TTTP[i].ToString()))+"",credit+"");
                }
           
            
           // modify_ph.Controls.Add(table);

            modify.DataSource = dt;
            modify.DataBind();
           
             return CC;
                //ClientScript.RegisterStartupScript(this.GetType(), "", "showpop();", true);
        }

        protected void modify_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ArrayList CA = new DatabaseConnectionManager().Get_Query("SELECT DISTINCT Course_Code,Course_Title  FROM load_table where uid!=''", 1);
            ArrayList SA = new DatabaseConnectionManager().Get_Query("SELECT DISTINCT Section_Number FROM load_table WHERE uid!=''", 2);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {

                    DropDownList dN = (e.Row.FindControl("n") as DropDownList);
                    DropDownList SN = (e.Row.FindControl("SN") as DropDownList);
                    //dN.ID = "1";

                    //SN.DataSource = SA;
                    //SN.DataBind();
                    dN.DataSource = CA;
                    
                   Label lc=(e.Row.FindControl("CC_Label") as Label);
                   
                   dN.DataBind();
                }


            }
        }

        protected void dN_TextChanged(object sender, EventArgs e)
        {
           // ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Selected')", true);
            GridViewRow gvrow = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList dd = (DropDownList)gvrow.FindControl("n");
            DropDownList ds = (DropDownList)gvrow.FindControl("SN");
            Label al = (Label)gvrow.FindControl("AL");
            Label cr = (Label)gvrow.FindControl("Credit");
            al.Text = "0";
            cr.Text = "0";
           
                int temp_flag = 0;
                int skip_one = 0;
                String course_code = "";
                String Course_title = "";
                String temp = dd.Text;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j].Equals(':'))
                    {
                        temp_flag = 1;
                    }
                    if (temp_flag == 0)
                    {
                        course_code += temp[j];
                    }
                    else
                    {
                        if (skip_one == 1)
                        {
                            Course_title += temp[j];
                        }
                        skip_one = 1;
                    }
                }
            
                ArrayList sn = new DatabaseConnectionManager().Get_Query("SELECT DISTINCT Section_Number FROM load_table Where Course_Code='"+course_code+"' AND Uid=''",2);
               
                ds.DataSource = sn;
                
                ds.Text = "Select";
                ds.DataBind();
            //  ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('"+Course_title+"')", true);

        }

       

        protected void modify_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Button4.Text = modify.SelectedRow.Cells[0].Text;
            


           
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
        }

        protected void modify_RowEditing(object sender, GridViewEditEventArgs e)
        {
            modify.EditIndex = e.NewEditIndex;
            modify.DataBind();
            
        }

        protected void modify_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow r = modify.Rows[e.RowIndex];
           Label HC = (Label)r.FindControl("hash_code");
           Label AL = (Label)r.FindControl("AL");
           Label CR = (Label)r.FindControl("Credit");
           Label UID = (Label)r.FindControl("M_Uid");
           new DatabaseConnectionManager().Modify_Delete(HC.Text, UID.Text, AL.Text, CR.Text);
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('"+HC.Text+"-"+AL.Text+"="+CR.Text+"-"+UID.Text+"')", true);
        }

        protected void modify_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "", true);
        }

        protected void modify_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            modify.EditIndex = -1;
            modify.DataBind();
        }
        protected void SN_TextChanged(object sender, EventArgs e)
        {
            // ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Selected')", true);
            GridViewRow gvrow = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ds = (DropDownList)gvrow.FindControl("SN");
            DropDownList dd = (DropDownList)gvrow.FindControl("n");
            Label AL = (Label)gvrow.FindControl("AL");
            Label CR = (Label)gvrow.FindControl("Credit");

            int temp_flag = 0;
            int skip_one = 0;
            String course_code = "";
            String Course_title = "";
            String temp = dd.Text;
            for (int j = 0; j < temp.Length; j++)
            {
                if (temp[j].Equals(':'))
                {
                    temp_flag = 1;
                }
                if (temp_flag == 0)
                {
                    course_code += temp[j];
                }
                else
                {
                    if (skip_one == 1)
                    {
                        Course_title += temp[j];
                    }
                    skip_one = 1;
                }
            }
            
            ArrayList sn = new DatabaseConnectionManager().Get_Query("SELECT * FROM load_table Where Course_Code='" + course_code + "' AND Section_Number='"+ds.Text+"'", 3);
            AL.Text = int.Parse(sn[0].ToString()) + int.Parse(sn[1].ToString()) + int.Parse(sn[2].ToString())+"";
            int cre = 0;
            if (sn[0].ToString() != "0")
            {
                cre += int.Parse(sn[0].ToString());
            }
            if(sn[1].ToString() != "0")
            {
                cre += (int.Parse(sn[1].ToString()))/2;
            }
            if (sn[2].ToString() != "0")
            {
                cre += (int.Parse(sn[2].ToString())) / 2;
            }

            CR.Text = cre + "";
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('"+sn[0].ToString()+"-"+sn[1].ToString()+"-"+course_code+"')", true);
        }

        protected void modify_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
        }

        protected void Button10_Click1(object sender, EventArgs e)
        {
          /*  if (TextBox2.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('Firstly Provide UID!!');", true);
                TextBox2.Focus();
            }
            else
            {
                new DatabaseConnectionManager().Add_Allocate(TextBox2.Text, UpdatePanel1, this);
            }*/
        }

        protected void Section_Mentor_Allocation_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(UpdatePanel1,UpdatePanel1.GetType(),"","alert('It  takes few minutes.Must not be refresh or close page!!');",true);
            new DatabaseConnectionManager().Section_Mentoring(UpdatePanel1,PlaceHolder1);
            new DatabaseConnectionManager().GetLoad(this, PlaceHolder1, TL, TT, TP, TNT);
        }

        protected void Check_By_Section_Click(object sender, EventArgs e)
        {
            
              
           
        }

        protected void Check_By_Section_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Check_By_Section.DataSource = new DatabaseConnectionManager().Get_Query("SELECT DISTINCT Section_Number FROM load_table", 2);
                Check_By_Section.DataBind();
            }
        }

        protected void Check_By_Section_TextChanged(object sender, EventArgs e)
        {
          // ScriptManager.RegisterClientScriptBlock(UpdatePanel1,UpdatePanel1.GetType(),"","alert('"+Check_By_Section.Text+"');",true);
            if( Check_By_Section.Text!="Select")
            new DatabaseConnectionManager().Check_By_Section(Check_By_Section.Text, UpdatePanel1, PlaceHolder1,this);
            Check_By_Section.Text = "Select";
    
        }

        protected void Import_Click(object sender, EventArgs e)
        {
            Response.Redirect("Excel_IE.aspx");
        }

        protected void Export_Click(object sender, EventArgs e)
        {
            Application["query"] = "Select * From load_table";
            Response.Redirect("Export_To_Excel.aspx");
        }

        protected void date_list_Load(object sender, EventArgs e)
        {
            
           
        }

        protected void date_list_TextChanged(object sender, EventArgs e)
        {
            if (date_list.Text != "Select Date")
            {
                //ScriptManager.RegisterClientScriptBlock(UpdatePanel1,UpdatePanel1.GetType(),"","alert('sss');",true);
                Pre_Db_list.DataSource = new DatabaseConnectionManager().Get_Backup_Queries("SELECT DB_Name FROM Backup_Info WHERE Date='"+date_list.Text+"'","DB_Name");
                Pre_Db_list.DataBind();
                Pre_Db_list.Enabled = true;
                Pre_Db_list.Items.Add("Select DB-Name");
                Pre_Db_list.Text = "Select DB-Name";
            }
        }

        protected void Pre_Db_list_TextChanged(object sender, EventArgs e)
        {
            if (Pre_Db_list.Text != "Select DB-Name")
            {
                Button11.Enabled = true;
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Application["query"] = "Select * From "+Pre_Db_list.Text+";";
            Response.Redirect("Export_To_Excel.aspx");
        }

        protected void Load_Check_By_Domain(object s,EventArgs e)
        {
            if (!IsPostBack)
            {
                Check_Domain_List.DataSource = new DatabaseConnectionManager().Get_Backup_Queries("SELECT DISTINCT Course_Domain FROM load_table","Course_Domain");
                Check_Domain_List.DataBind();
                Check_Domain_List.Items.Add("Select");
                Check_Domain_List.Text = "Select";
            }
        }
        protected void Load_Check_By_Domain_TextChanged(object s, EventArgs e)
        {
            if (Check_Domain_List.Text != "Select")
            {

                Application["query"] = "Select * From load_table Where Course_Domain='" + Check_Domain_List.Text + "';";
                Response.Redirect("Domain_View.aspx");
            }
        }
        protected void ButtonFinal_Click(object s, EventArgs e)
        {
            Application["query"] = " SELECT * FROM load_table ORDER BY Uid DESC";
            Response.Redirect("Final_Sheet.aspx");
         
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Response.Redirect("Import_strength_sheet.aspx");
        }
    }

    }    
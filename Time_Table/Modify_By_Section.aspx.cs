using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Time_Table
{
    public partial class Modify_By_Section : System.Web.UI.Page
    {
        String uid = "", query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                uid = Application["section"].ToString();
                query = "Select * From load_table WHERE Section_Number='" + uid + "'";
            }
            catch (Exception ex)
            {
                Response.Redirect("Time_table_manager.aspx");
            }
            if(!IsPostBack)
            Bind();
            
            
        }

        protected void Bind()
        {
            GridView_Sections.DataSource = new DatabaseConnectionManager().Export_To_Excel(query);
            GridView_Sections.DataBind();
            
        }
        protected void GridView_Sections_RowEditing(object sender, GridViewEditEventArgs e)
        {
            notify.Visible = false;
            GridView_Sections.EditIndex = e.NewEditIndex;
            Bind();
           GridView_Sections.DataBind();
            
           
           //.DataSource= new DatabaseConnectionManager().Get_Backup_Queries("SELECT DISTINCT Uid FROM teacher_data","UID");

        }

        protected void GridView_Sections_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView_Sections_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList d = (e.Row.FindControl("UID_Drop") as DropDownList);
                    ArrayList al = new DatabaseConnectionManager().Get_Backup_Queries("SELECT DISTINCT Uid FROM teacher_data ORDER BY Uid desc", "Uid");
                    d.DataSource = al;
                    d.DataBind();
                    d.Items.Add("Select");
                    d.Text = "Select";
                   
                }
            }
        }
        public void Add_Name(object s, EventArgs e)
        {
            GridViewRow gvrow = (GridViewRow)((DropDownList)s).NamingContainer;
            DropDownList d=(DropDownList) gvrow.FindControl("UID_Drop");
            Label TN = (Label)gvrow.FindControl("Feculty_Name");
            Label HC = (Label)gvrow.FindControl("Hash_Code");
            LinkButton ab=(LinkButton)gvrow.FindControl("add_button");
             LinkButton ub=(LinkButton)gvrow.FindControl("update_button");
            if (d.Text != "Select")
            {
                //  ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "Alert", "alert('" + d.Text + "')", true);
                ArrayList al = new DatabaseConnectionManager().Get_Backup_Queries("SELECT Teacher_Name FROM teacher_data Where uid='" + d.Text + "'", "Teacher_Name");
                TN.Text = al[0].ToString();
                if (HC.Text == "")
                {
                    ab.Enabled = true;
                }else
                    ub.Enabled = true;

            }
            else
            {
                TN.Text = "";
                ub.Enabled = false;
                ab.Enabled = false;
            }
        }

        protected void GridView_Sections_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           // ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "Alert", "alert('jjj')", true);
            int load=0;
            GridViewRow r = GridView_Sections.Rows[e.RowIndex];
            Label SN = (Label)r.FindControl("Section_Number");
            Label CC = (Label)r.FindControl("Course_Code");
            Label CT = (Label)r.FindControl("Course_Title");
            Label HC = (Label)r.FindControl("Hash_Code");
             Label FN = (Label)r.FindControl("Feculty_Name");
            Label TL = (Label)r.FindControl("TL");
            Label TT = (Label)r.FindControl("TT");
            Label TP= (Label)r.FindControl("TP");
            int cre = 0;
            try{
                load=int.Parse(TL.Text)+int.Parse(TT.Text)+int.Parse(TP.Text);
                
                if (TL.Text != "0")
                {
                    cre += int.Parse(TL.Text);
                }
                if (TT.Text != "0")
                {
                    cre += (int.Parse(TT.Text)) / 2;
                }
                if (TP.Text != "0")
                {
                    cre += (int.Parse(TP.Text)) / 2;
                }
            }catch(Exception ex)
            {
            }
            DropDownList DN = (DropDownList)r.FindControl("UID_Drop");
            new DatabaseConnectionManager().Modify_Update(HC.Text, DN.Text, FN.Text, SN.Text, load + "", CC.Text, CT.Text, cre + "", UpdatePanel1);
            GridView_Sections.EditIndex = -1;
            Bind();
        }

        protected void GridView_Sections_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_Sections.EditIndex = -1;
            Bind();
        }

        protected void GridView_Sections_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow r = GridView_Sections.Rows[e.RowIndex];
            Label SN = (Label)r.FindControl("Section_Number");
            Label CC = (Label)r.FindControl("Course_Code");
            Label CT = (Label)r.FindControl("Course_Title");

            DropDownList DN = (DropDownList)r.FindControl("UID_Drop");
            new DatabaseConnectionManager().modify_add_new_course(DN.Text, SN.Text, CC.Text, CT.Text, UpdatePanel1, notify);
            GridView_Sections.EditIndex = -1;
            Bind();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace Time_Table
{
    public partial class Modify_By_Uid : System.Web.UI.Page
    {
        String uid = "",query="";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                uid = Application["uid"].ToString();
                query = "Select * From load_table WHERE UID='" + uid + "'";
            }
            catch (Exception ex)
            {
                Response.Redirect("Time_table_manager.aspx");
            }
            if(!IsPostBack)
              new DatabaseConnectionManager().Check_Load_By_Uid( query, PlaceHolder1, this);
            banner_update();
            //modify.DataBind();
        }
        public void banner_update()
        {
            T_Uid.Text = uid;
            ArrayList load = new DatabaseConnectionManager().Get_Load(uid);
            T_Total.Text = load[0].ToString();
            T_Credit.Text = load[1].ToString();
            T_Max.Text = load[2].ToString();
        }
        public void Modify_Load(ArrayList Uid, int nn, String Name, ArrayList CC, ArrayList CT, ArrayList SN, ArrayList AL, ArrayList HC, ArrayList TT,ArrayList TP)
        {
            int tl = 0, tt = 0,tp = 0;
            //uid.Text = Uid;
            //name.Text = Name;
            String s = "";
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] {new DataColumn("hash",typeof(String)),  new DataColumn("M_Uid", typeof(string)),
                            new DataColumn("M_Name", typeof(string)),
                            new DataColumn("M_CC",typeof(String)),new DataColumn("M_SN",typeof(String)), new DataColumn("M_TL",typeof(String)),
                             new DataColumn("M_TT",typeof(String)),
                              new DataColumn("M_TP",typeof(String)),new DataColumn("M_AL",typeof(string)),new DataColumn("M_Credit",typeof(String))});
            T_Name.Text = Name;
            int credit = 0;
            //  s += "<table border='1' cellpadding='5' cellspacing='0'><tr><th><b>UID</b></th><th><b>Name</b></th><th><b>Course Code</b></th><th><b>Course Title</b></th><th><b>Section Number</b></th><th><b>Allocated Load</b></th></tr>";
            for (int i = 0; i < nn; i++)
            {

                tp += int.Parse(TP[i].ToString());
                tl += int.Parse(AL[i].ToString());
                tt += int.Parse(TT[i].ToString());
                if (TP[i].ToString() != "0")
                    credit+=int.Parse(TP[i].ToString()) / 2;
                if(AL[i].ToString()!="0")
                    credit += int.Parse(AL[i].ToString());
                if (TT[i].ToString() != "0")
                    credit += int.Parse(TT[i].ToString()) / 2;
                dt.Rows.Add(HC[i].ToString(), Uid[i].ToString(), Name, CC[i].ToString() + ":" + CT[i].ToString(), SN[i].ToString(),AL[i].ToString(),TT[i].ToString(),TP[i].ToString(),int.Parse(AL[i].ToString())+int.Parse(TT[i].ToString())+int.Parse(TP[i].ToString())+"", credit + "");
                credit = 0;
            }

            T_TL.Text = ""+tl;
            T_TT.Text= tt+"";
            T_TP.Text = tp+"";
            
            // modify_ph.Controls.Add(table);
            try
            {
                modify.DataSource = dt;
                modify.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('"+ex.Message+"')", true);
            }
            banner_update();
            //ClientScript.RegisterStartupScript(this.GetType(), "", "showpop();", true);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop();", true);
        }

        protected void modify_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            ArrayList CA = new DatabaseConnectionManager().Get_Query("SELECT DISTINCT Course_Code,Course_Title  FROM load_table where uid!='' AND Group_Label!='5'" , 1);
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

                    Label lc = (e.Row.FindControl("CC_Label") as Label);

                    dN.DataBind();
                }

                banner_update();
            }
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop();", true);
            banner_update();
        }

        protected void dN_TextChange(object sender, EventArgs e)
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

            ArrayList sn = new DatabaseConnectionManager().Get_Query("SELECT DISTINCT Section_Number  FROM load_table where Course_Code='"+course_code+"' AND uid=''", 2);

            ds.DataSource = sn;

            ds.Text = "Select";
            ds.DataBind();
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('"+Course_title+"')", true);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop();", true);

        }



        protected void modify_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Button4.Text = modify.SelectedRow.Cells[0].Text;




        }

        protected void add_btn(object sender, EventArgs e)
        {
          //  ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('ss')", true);
            add_UID.Text = uid;
            ArrayList load= new DatabaseConnectionManager().Get_Load(uid);
            add_AL.Text = load[0].ToString();
            add_credit.Text = load[1].ToString();
            new DatabaseConnectionManager().Load_Domain(Select_Domain);
            Select_Domain.Items.Add("Select");
            Select_Domain.Text = "Select";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1,UpdatePanel1.GetType(),"","Show_add_pop();",true);
        }

        protected void add_new_course(object sender, EventArgs e)
        {
            int temp_flag = 0;
            int skip_one = 0;
            String course_code = "";
            String Course_title = "";
            String temp = add_course.Text;
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
            if (add_course.Text != "Select" && add_Sec.Text != "Select")
            {
                new DatabaseConnectionManager().modify_add_new_course(uid, add_Sec.Text, course_code, Course_title, UpdatePanel1, notify);
                add_course.Text = "Select";
                add_Sec.Text = "Select";
                add_Sec.Enabled = false;
                TL.Text = "" + 0;
                TP.Text = "" + 0;
                TT.Text = "" + 0;
                Credit.Text = "" + 0;
                add_new.Visible = false;
                ArrayList load = new DatabaseConnectionManager().Get_Load(uid);
                add_AL.Text = load[0].ToString();
                add_credit.Text = load[1].ToString();
                banner_update();
            }
            
        }
        protected void Close_add_pop_btn(object s, EventArgs e)
        {
            
           
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop_btn();", true);
            //System.Threading.Thread.Sleep(1000);
            notify.Visible = false;
            new DatabaseConnectionManager().Check_Load_By_Uid(query, PlaceHolder1, this);
        }
        protected void modify_RowEditing(object sender, GridViewEditEventArgs e)
        {
            new DatabaseConnectionManager().Check_Load_By_Uid(query, PlaceHolder1, this);
            
            modify.EditIndex = e.NewEditIndex;
            modify.DataBind();
           
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop();", true);
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
            new DatabaseConnectionManager().Check_Load_By_Uid(query, PlaceHolder1, this);
            modify.EditIndex = -1;
            modify.DataBind();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop();", true);
            //banner_update();
        }

        protected void modify_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
           // ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "", true);
            new DatabaseConnectionManager().Check_Load_By_Uid(query, PlaceHolder1, this);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop();", true);
           // banner_update();
           
        }

        protected void modify_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            new DatabaseConnectionManager().Check_Load_By_Uid(query, PlaceHolder1, this);
            modify.EditIndex = -1;
            modify.DataBind();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop();", true);
           
        }
        protected void SN_TextChanged(object sender, EventArgs e)
        {

            // ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Selected')", true);
            GridViewRow gvrow = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ds = (DropDownList)gvrow.FindControl("SN");
            DropDownList dd = (DropDownList)gvrow.FindControl("n");
            Label AL = (Label)gvrow.FindControl("AL");
            Label CR = (Label)gvrow.FindControl("Credit");
            LinkButton update = (LinkButton)gvrow.FindControl("update_button");
            if (ds.Text != "Select")
            {
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
                    if (ds.Text != "Select")
                    {
                        update.Enabled = true;
                        update.CssClass = "myButton";
                    }
                    else
                        update.Enabled = false;
                }

                ArrayList sn = new DatabaseConnectionManager().Get_Query("SELECT * FROM load_table Where Course_Code='" + course_code + "' AND Section_Number='" + ds.Text + "'", 3);
                AL.Text = int.Parse(sn[0].ToString()) + int.Parse(sn[1].ToString()) + int.Parse(sn[2].ToString()) + "";
                int cre = 0;
                if (sn[0].ToString() != "0")
                {
                    cre += int.Parse(sn[0].ToString());
                }
                if (sn[1].ToString() != "0")
                {
                    cre += (int.Parse(sn[1].ToString())) / 2;
                }
                if (sn[2].ToString() != "0")
                {
                    cre += (int.Parse(sn[2].ToString())) / 2;
                }

                CR.Text = cre + "";
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('"+sn[0].ToString()+"-"+sn[1].ToString()+"-"+course_code+"')", true);

            }
            else
            {
                AL.Text = 0 + "";
                CR.Text = 0 + "";
            }
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop();", true);
        }

        protected void modify_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow r = modify.Rows[e.RowIndex];
            Label HC = (Label)r.FindControl("hash_code");
            Label AL = (Label)r.FindControl("AL");
            Label CR = (Label)r.FindControl("Credit");
            Label UID = (Label)r.FindControl("M_Uid");
            Label Name = (Label)r.FindControl("M_N");
            DropDownList DN = (DropDownList)r.FindControl("n");
            DropDownList SN = (DropDownList)r.FindControl("SN");
            int temp_flag = 0;
            int skip_one = 0;
            String course_code = "";
            String Course_title = "";
            String temp = DN.Text;
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
            //ScriptManager.RegisterClientScriptBlock(UpdatePanel1,UpdatePanel1.GetType(), "", "alert('" + Name.Text +"-"+UID.Text+ "')", true);
            new DatabaseConnectionManager().Modify_Update(HC.Text, UID.Text, Name.Text, SN.Text, AL.Text, course_code,Course_title, CR.Text,UpdatePanel1);
            new DatabaseConnectionManager().Check_Load_By_Uid(query, PlaceHolder1, this);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "Close_add_pop();", true);
            banner_update();
            modify.EditIndex = -1;
            modify.DataBind();
        }
        protected void add_section(Object sender, EventArgs e)
        {
            int temp_flag = 0;
            int skip_one = 0;
            String course_code = "";
            String Course_title = "";
            String temp = add_course.Text;
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

            add_Sec.DataSource= new DatabaseConnectionManager().Get_Query("SELECT DISTINCT Section_Number  FROM load_table where Course_Code='" + course_code + "' AND uid=''", 2);
            add_Sec.DataBind();
            add_Sec.Text = "Select";
            add_Sec.Enabled = true;
        
            
        }
        protected void add_load(Object sender, EventArgs e)
        {
            if (add_Sec.Text != "Select")
            {
                int temp_flag = 0;
                int skip_one = 0;
                String course_code = "";
                String Course_title = "";
                String temp = add_course.Text;
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

                ArrayList sn = new DatabaseConnectionManager().Get_Query("SELECT * FROM load_table Where Course_Code='" + course_code + "' AND Section_Number='" + add_Sec.Text + "'", 3);
                TL.Text = int.Parse(sn[0].ToString()) + "";
                TT.Text = int.Parse(sn[1].ToString()) + "";
                TP.Text = int.Parse(sn[2].ToString()) + "";
                int cre = 0;
                if (sn[0].ToString() != "0")
                {
                    cre += int.Parse(sn[0].ToString());
                }
                if (sn[1].ToString() != "0")
                {
                    cre += (int.Parse(sn[1].ToString())) / 2;
                }
                if (sn[2].ToString() != "0")
                {
                    cre += (int.Parse(sn[2].ToString())) / 2;
                }

                Credit.Text = cre + "";
                add_new.Visible = true;
                add_new.Enabled = true;
            }
            else
            {
                TL.Text = 0+ "";
                TT.Text = 0+ "";
                TP.Text =0 + "";
                Credit.Text = "" + 0;
                add_new.Visible = false;
                
            }
        }

        protected void But_Click(object sender, EventArgs e)
        {
            Response.Redirect("Time_Table_manager.aspx");
        }
        protected void add_Domain(object s, EventArgs e)
        {
            if (Select_Domain.Text != "Select")
            {
                add_course.Enabled = true;
                add_Sec.Enabled = true; 
                add_course.DataSource = new DatabaseConnectionManager().Get_Query("SELECT DISTINCT Course_Code,Course_Title From load_Table Where UID='' AND Course_Domain='" + Select_Domain.Text + "'", 1);
                add_course.DataBind();
                add_course.Text = "Select";
            }
            else
            {
                add_course.Enabled = false;
                add_Sec.Enabled = false;
            }
        }    }
}
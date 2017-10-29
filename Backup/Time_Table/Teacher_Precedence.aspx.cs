using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Time_Table
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        MySqlConnection con;
        String id = "";
        int prece_flag = 0;
        String[] course_list = new String[3];
        int[] precendence_count = new int[3];
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                id = Session["id"].ToString();
                new DatabaseConn().getData_for_teacher_precedence(id, TextBox3, TextBox2);
                if (new DatabaseConn().verify_precedence(TextBox3.Text, this) == 1)
                {

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "showpop_already();", true);
                    Button1.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("Enter_UID.aspx");
            }
            if (!IsPostBack)
            {
                
                new DatabaseConn().Load_Domain(Course_Domain_1);
                new DatabaseConn().Load_Domain(Course_Domain_2);
                new DatabaseConn().Load_Domain(Course_Domain_3);
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /* TextBox1.Text = "Hello";
             if (FileUpload1.HasFile)
             {
                 TextBox1.Text += "File Name:-" + FileUpload1.PostedFile.FileName;
                 TextBox1.Text += "\nFile Size:-" + FileUpload1.PostedFile.ContentLength;
                 TextBox1.Text += "\nFile Type:-" + FileUpload1.PostedFile.ContentType;
                 FileUpload1.SaveAs("D:/6th/Pea Reasioning"+"/s.mp3");
                 TextBox1.Text += "\nFile Saved:-" ;
                
             }
             else
             {*/
            // TextBox1.Text = "Please Select File!--!";

        }


        protected void Chart1_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList1.Text.Equals(DropDownList2.Text) || DropDownList1.Text.Equals(DropDownList3.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('Two Precedence could not be same!!!')", true);
                DropDownList1.Text = "SRP001:Select Course";
            }
        }

        protected void DropDownList1_Load(object sender, EventArgs e)
        {


        }

        protected void DropDownList2_Load(object sender, EventArgs e)
        {
            //   new DatabaseConn().Load_Course(DropDownList2);

        }

        protected void DropDownList3_Load(object sender, EventArgs e)
        {
            // new DatabaseConn().Load_Course(DropDownList3);

        }

        protected void DropDownList4_Load(object sender, EventArgs e)
        {


        }

        protected void DropDownList5_Load(object sender, EventArgs e)
        {


        }



        protected void Button1_Click1(object sender, EventArgs e)
        {
            // prece_flag = 0;

            if (DropDownList1.Text.Equals(DropDownList2.Text) || DropDownList1.Text.Equals(DropDownList3.Text) || DropDownList2.Text.Equals(DropDownList3.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('Two Precedence could not be same!!!')", true);
                DropDownList1.Text = "SRP001:Select Course";
                prece_flag = 1;
            }
            if (prece_flag == 0)
            {
                prece_flag = 0;
               // Page.ClientScript.RegisterStartupScript(this.GetType(), "", "showpop();", true);
                ScriptManager.RegisterStartupScript(UpdatePanel1,UpdatePanel1.GetType(), Guid.NewGuid().ToString(),"showpop();", true);

                if (DropDownList1.Text != "SRP001:Select Course")
                {
                    precendence_count[0]++;
                    course_list[0] = "" + DropDownList1.Text;
                }
                else
                {
                    precendence_count[0] = 0;
                }
                if (DropDownList2.Text != "SRP001:Select Course")
                {
                    precendence_count[1]++;
                    course_list[1] = "" + DropDownList2.Text;
                }
                else
                {
                    precendence_count[1] = 0;
                }
                if (DropDownList3.Text != "SRP001:Select Course")
                {
                    precendence_count[2]++;
                    course_list[2] = "" + DropDownList3.Text;
                }
                else
                {
                    precendence_count[2] = 0;
                }

                string s = "";
                for (int j = 0; j < 3; j++)
                {
                    s += "<table class='mod' border='0.5' cellspacing='0' cellpadding='2px' width='100%'>";
                    if (precendence_count[j] != 0)
                    {

                        s += "<tr ><td><li>Precendence" + (j + 1) + ": " + course_list[j] + "</li></td></tr>";
                    }
                    else
                    {

                        s += "<tr><td><li >Precendence" + (j + 1) + ": System Randomly provide!</li></td></tr>";
                    }
                }
                s += "</table>";
                PlaceHolder1.Controls.Add(new LiteralControl(s));
                //Panel1.Enabled = false;

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("id");
            Response.Redirect("Enter_UID.aspx?status=Logout Successfully!!");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.Text.Equals(DropDownList1.Text) || DropDownList2.Text.Equals(DropDownList3.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('Two Precedence could not be same!!!')", true);
                DropDownList2.Text = "SRP001:Select Course";
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList3.Text.Equals(DropDownList2.Text) || DropDownList3.Text.Equals(DropDownList1.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('Two Precedence could not be same!!!')", true);
                DropDownList3.Text = "SRP001:Select Course";
            }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

          //  Page.ClientScript.RegisterStartupScript(this.GetType(), "", "closepop();", true);
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), "closepop();", true);
           // Panel1.Enabled = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            new DatabaseConn().insert_precedence(this, TextBox3.Text, TextBox2.Text, precendence_count, DropDownList1.Text, DropDownList2.Text, DropDownList3.Text, Course_Domain_1.Text, Course_Domain_2.Text, Course_Domain_3.Text, UpdatePanel1);
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {

            if (DropDownList1.Text.Equals(DropDownList2.Text) || DropDownList1.Text.Equals(DropDownList3.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('Two Precedence could not be same!!!')", true);
                DropDownList1.Text = "SRP001:Select Course";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session.Remove("id");
            Response.Redirect("Enter_UID.aspx?status=Logout Successfully!!");
        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            Session.Remove("id");
            Response.Redirect("Enter_UID.aspx?status=Logout Successfully!!");
        }

        protected void domain_Load(object sender, EventArgs e)
        {
            
            
          
        }

        protected void domain_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        protected void domain_TextChanged(object sender, EventArgs e)
        {
            //ClientScript.RegisterClientScriptBlock(GetType(), "", "alert('WS');", true);
          
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            
            new DatabaseConn().Load_Course(DropDownList2, domain.Text.Trim());
            new DatabaseConn().Load_Course(DropDownList3, domain.Text.Trim());
            DropDownList1.Text = "SRP001:Select Course";
            DropDownList3.Text = "SRP001:Select Course";
            DropDownList2.Text = "SRP001:Select Course";
            course_drop.Visible = true;
        }

        protected void Course_Domain_1_change(object s, EventArgs e)
        {
            DropDownList1.Enabled = true;
            new DatabaseConn().Load_Course(DropDownList1, Course_Domain_1.Text.Trim());
        }
        protected void Course_Domain_2_change(object s, EventArgs e)
        {
            DropDownList2.Enabled = true;
            new DatabaseConn().Load_Course(DropDownList2, Course_Domain_2.Text.Trim());
        }
        protected void Course_Domain_3_change(object s, EventArgs e)
        {
            DropDownList3.Enabled = true;
            new DatabaseConn().Load_Course(DropDownList3, Course_Domain_3.Text.Trim());
        }
    }
}
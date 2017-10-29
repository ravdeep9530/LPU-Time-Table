using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections;

namespace Time_Table
{
    public class DatabaseConn
    {
        MySqlConnection con, con1;
        WebForm1 w1;
        public DatabaseConn()
        {
            string connurl = "Server=localhost;Database=time_table;Uid=root;Password='';";
            con = new MySqlConnection(connurl);
            con1 = new MySqlConnection(connurl);
        }
        public void inserting(WebForm1 w1)
        {
            try
            {

                con.Open();
                con1.Open();
                MySqlCommand cm = con.CreateCommand();
                cm.Connection = con1;
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT DISTINCT Feculty_Name,UID FROM pretable;";
                MySqlDataReader rd = null;
                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                int i = rd.VisibleFieldCount;
                String[] qry = new String[2000];
                int j = 0;
                while (rd.Read())
                {

                    cm.CommandText = "INSERT INTO teacher_data (Uid,Teacher_Name,Max_Load) VALUES('" + rd["UID"] + "','" + rd["Feculty_Name"] + "','18')";

                    cm.ExecuteNonQuery();

                    j++;
                }
                rd.Close();
                cmd.Dispose();
                con.Close();
                con1.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(w1, w1.GetType(), "alertMessage", "alert('dddd')", true);
            }
        }
        public void Load_Course(DropDownList d1,String domain)
        {
            try
            {
                d1.Items.Clear();
                
                d1.Items.Add("SRP001:Select Course");
                con.Open();

                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "Select DISTINCT Course_Code,Course_Title From load_table WHERE Course_Domain='"+domain+"' AND UID=''";
                MySqlDataReader rd = null;
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                //ap.Fill(ds);


                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    d1.Items.Add(rd["Course_Code"] + ":" + rd["Course_Title"]);
                    //TextBox1.Text += rd[""] + "\n";
                }




                //TextBox1.Text = con.State+"";

                con.Close();
            }
            catch (Exception ex)
            {
                // TextBox1.Text = ex.Message;
            }
        }
        public void Load_Domain(DropDownList d1)
        {
            try
            {
               // d1.Items.Clear();
                
                con.Open();

                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "Select DISTINCT Course_Domain From load_table WHERE UID='' AND Group_Label!='3'";
                MySqlDataReader rd = null;
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                //ap.Fill(ds);


                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if(rd["Course_Domain"].ToString()!="");
                    d1.Items.Add(rd["Course_Domain"].ToString());
                    //TextBox1.Text += rd[""] + "\n";
                }




                //TextBox1.Text = con.State+"";

                con.Close();
            }
            catch (Exception ex)
            {
                // TextBox1.Text = ex.Message;
            }
        }
        public void Check_UID(Enter_UID eu, String uid)
        {

            try
            {
                con.Open();
                int flag = 0;
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From teacher_data WHERE Uid='" + uid + "'";
                MySqlDataReader rd = null;
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                //ap.Fill(ds);


                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    flag = 1;
                    eu.Session["id"] = rd["Uid"];
                    eu.Response.Redirect("Teacher_Precedence.aspx");

                }


                if (flag == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(eu, eu.GetType(), "alertMessage", "alert('UID is Not Found!!')", true);
                }

                //TextBox1.Text = con.State+"";

                con.Close();
            }
            catch (Exception ex)
            {
                // TextBox1.Text = ex.Message;
            }
        }
        public void insert_precedence(WebForm1 w1, String Uid, String Name, int[] key, String course_name1, String course_name2, String course_name3, String C_Domain_1, String C_Domain_2, String C_Domain_3, UpdatePanel up)
        {
            try
            {
                //ScriptManager.RegisterClientScriptBlock(w1, w1.GetType(), "alertMessage", "alert('dd "')", true);
                ArrayList CD = new ArrayList();
                String[] course_name = new String[3];
                course_name[0] = course_name1;
                course_name[1] = course_name2;
                course_name[2] = course_name3;
                CD.Add(C_Domain_1);
                CD.Add(C_Domain_2);
                CD.Add(C_Domain_3);
                con.Open();
                int flag = 0;

                for (int i = 0; i < 3; i++)
                {
                    int temp_flag = 0;
                    int skip_one = 0;
                    String course_code = "";
                    String Course_title = "";
                    String temp = course_name[i];
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
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.Connection = con;


                    {
                        //String code=course_name[i].Substring(0,6);
                        // String title=course_name[i].Substring(6);
                        cmd.CommandText = "INSERT INTO teacher_precedence (Uid,Teacher_Name,Course_Code,Course_Title,Maximum_Load,Precedence,Course_Domain) VALUES('" + Uid + "','" + Name + "','" + course_code.Trim() + "','" + Course_title.Trim() + "','18','" + (i + 1) + "','"+CD[i].ToString().Trim()+"')";
                        int ack = cmd.ExecuteNonQuery();

                       // w1.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "showpop_submitted();", true);
                        ScriptManager.RegisterStartupScript(up, up.GetType(), Guid.NewGuid().ToString(), "showpop_submitted();", true);


                    }
                }





                con.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(w1, w1.GetType(), "alertMessage", "alert('-----------" + ex.Message + "')", true);
            }

        }
        public void getData_for_teacher_precedence(String uid, TextBox t_uid, TextBox t_name)
        {
            try
            {
                con.Open();
                int flag = 0;
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From teacher_data WHERE Uid='" + uid + "'";
                MySqlDataReader rd = null;
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                //ap.Fill(ds);


                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    flag = 1;
                    t_uid.Text = rd["Uid"] + "";
                    t_name.Text = rd["Teacher_Name"].ToString();


                }


                if (flag == 1)
                {

                    //ScriptManager.RegisterClientScriptBlock(eu, eu.GetType(), "alertMessage", "alert('UID is Not Found!!')", true);
                }

                //TextBox1.Text = con.State+"";

                con.Close();
            }
            catch (Exception ex)
            {
                // TextBox1.Text = ex.Message;
            }
        }
        public int verify_precedence(String uid, WebForm1 w1)
        {
            try
            {
                con.Open();
                int flag = 0;
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From teacher_precedence WHERE Uid='" + uid + "'";
                MySqlDataReader rd = null;



                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    flag = 1;
                    // ScriptManager.RegisterClientScriptBlock(w1, w1.GetType(), "alertMessage", "alert('UID is Not Found!!')", true);


                }


                if (flag == 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(eu, eu.GetType(), "alertMessage", "alert('UID is Not Found!!')", true);
                    return 1;

                }
                else
                {
                    return 0;
                }

                //TextBox1.Text = con.State+"";

                con.Close();
            }
            catch (Exception ex)
            {
                // TextBox1.Text = ex.Message;
            }
            return 5;
        }
        public int check_val( String uid,String pass)
        {
            try
            {
                con.Open();
                int flag = 0;
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From login_TTMS WHERE Uid='" + uid + "' AND password='"+pass+"'";
                MySqlDataReader rd = null;
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                //ap.Fill(ds);


                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    flag = 1;
                   


                }


                if (flag == 1)
                {
                    return 1;
                    //ScriptManager.RegisterClientScriptBlock(eu, eu.GetType(), "alertMessage", "alert('UID is Not Found!!')", true);
                }
                
                //TextBox1.Text = con.State+"";

                con.Close();
            }
            catch (Exception ex)
            {
                // TextBox1.Text = ex.Message;
            }
            return 0;
        }
    }

}
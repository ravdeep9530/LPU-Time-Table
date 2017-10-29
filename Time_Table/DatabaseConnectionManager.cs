using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
namespace Time_Table
{
    public class DatabaseConnectionManager
    {
        MySqlConnection con, con1, con2, con3, con4;
        Time_table_manager tm;
        
        public DatabaseConnectionManager()
        {
            string connurl = "Server=localhost;Database=time_table;Uid=root;Password='';";
            con = new MySqlConnection(connurl);
            con1 = new MySqlConnection(connurl);
            con2 = new MySqlConnection(connurl);
            con3 = new MySqlConnection(connurl);
            con4 = new MySqlConnection(connurl);
        }
        public void GetLoad(Time_table_manager tm, PlaceHolder ph, Label TLL, Label TTL, Label TPL, Label TNT)
        {
            try
            {
                
                con.Open();

                int TP = 0;
                int TL = 0;
                int TT = 0;
                int sum = 0;
                int No_teacher = 0;

                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From load_table WHERE UID='' AND Group_Label!='5'";
                MySqlDataReader rd = null;
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                //ap.Fill(ds);


                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    try
                    {

                        TP += int.Parse(rd["TP"] + "");
                        TL += int.Parse(rd["TL"] + "");
                        TT += int.Parse(rd["TT"] + "");



                    }
                    catch (Exception ex)
                    {
                    }

                }
                TPL.Text = TP + "";
                TLL.Text = TL + "";
                TTL.Text = TT + "";
                sum = (TP + TL + TT);
                No_teacher = sum / 18;
                TNT.Text = No_teacher + "";
                // ph.Controls.Add(new LiteralControl("<table><tr><th>TOTAL LEACTURE</th><th>TOTAL TUTORIAL</th><th>TOTAL PRACTICLES</th><th>TOTAL</th></tr>"+
                //" <tr><td>" + TL + "</td><td>" + TT + "</td><td>" + TP + "</td><td>" + sum + "</td></tr></table><br/><br/><table style='width:50%;'><tr><th style='text-align:center;'>NUMBER OF REQUIRED TEACHER:" + No_teacher + "</th></tr></table>"));
                // tm.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "showpop();", true);



                //TextBox1.Text = con.State+"";

                con.Close();
            }
            catch (Exception ex)
            {
                // TextBox1.Text = ex.Message;
            }
        }
        public void Get_Domain_Load(Domain_View tm, String domain, Label TLL, Label TTL, Label TPL, Label TNT)
        {
            try
            {

                con.Open();

                int TP = 0;
                int TL = 0;
                int TT = 0;
                int sum = 0;
                int No_teacher = 0;

                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = domain + " AND Group_Label!='5' AND uid=''";//"Select * From load_table WHERE Course_Domain='"+domain+"' AND Group_Label!='5'";
                MySqlDataReader rd = null;
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                //ap.Fill(ds);


                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    try
                    {

                        TP += int.Parse(rd["TP"] + "");
                        TL += int.Parse(rd["TL"] + "");
                        TT += int.Parse(rd["TT"] + "");



                    }
                    catch (Exception ex)
                    {
                    }

                }
                TPL.Text = TP + "";
                TLL.Text = TL + "";
                TTL.Text = TT + "";
                sum = (TP + TL + TT);
                No_teacher = sum / 18;
                TNT.Text = No_teacher + "";
                // ph.Controls.Add(new LiteralControl("<table><tr><th>TOTAL LEACTURE</th><th>TOTAL TUTORIAL</th><th>TOTAL PRACTICLES</th><th>TOTAL</th></tr>"+
                //" <tr><td>" + TL + "</td><td>" + TT + "</td><td>" + TP + "</td><td>" + sum + "</td></tr></table><br/><br/><table style='width:50%;'><tr><th style='text-align:center;'>NUMBER OF REQUIRED TEACHER:" + No_teacher + "</th></tr></table>"));
                // tm.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "showpop();", true);



                //TextBox1.Text = con.State+"";

                con.Close();
            }
            catch (Exception ex)
            {
                // TextBox1.Text = ex.Message;
            }
        }
        public void Phase_One_Load_Allocating(Time_table_manager tm, PlaceHolder ph, String prece, String cond,UpdatePanel up)
        {
            try
            {
                Random rand = new Random();
                //connection opening
                con.Open();
                con1.Open();
                //end
                long hash = 0;
                int flag = 0;
                float TP = 0;
                float TL = 0;
                float TT = 0;
                int sum = 0;
                int Max_Load = 0;
                int Allocated_Load = 0;
                int No_teacher = 0;
                int Deducted_Load = 0;
                int Filter = 0;
                float Credit = 0;
                String Group_Label_v = "";
                int No = 0;
                String Course_Code = "";
                ArrayList Course_Code_List = new ArrayList();
                ArrayList Section_List = new ArrayList();
                ArrayList Domain_List = new ArrayList();
                ArrayList Domain_List_Filter = new ArrayList();
                ArrayList Total_Load = new ArrayList();
                ArrayList UID_Filter = new ArrayList();
                ArrayList Teacher_Name_Filter = new ArrayList();
                ArrayList Course_Code_Filter = new ArrayList();
                ArrayList Group_Label = new ArrayList();
                ArrayList Group_Label_Filter = new ArrayList();
                ArrayList Course_Title = new ArrayList();
                ArrayList Course_Title_Filter = new ArrayList();
                ArrayList Section_Filter = new ArrayList();
                ArrayList Credit_load = new ArrayList();
                ArrayList Credit_load_filter = new ArrayList();
                ArrayList Total_Load_Filter = new ArrayList();
                String Teacher_name = "";
                String UID = "";
                String Section = "";
                String s = "";
                MySqlCommand cmd;
                MySqlCommand cmd1;
                s += "<center><h1><u>Allocated Detail</u></h1></center><br>";
                s += "<table border='1' cellpadding='5' cellspacing='0'><tr><th><b>UID</b></th><th><b>Name</b></th><th><b>Course Code</b></th><th><b>Course Title</b></th><th><b>Section Number</b></th></tr>";
                //cmd
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From load_table WHERE UID='' AND Group_Label!='5' AND Group_Label!='3'";
                MySqlDataReader rd = null;
                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                //end
                while (rd.Read())
                {
                    try
                    {

                        TP = 0;
                        TL = 0;
                        TT = 0;
                        TP += float.Parse(rd["TP"] + "");
                        TL += float.Parse(rd["TL"] + "");
                        TT += float.Parse(rd["TT"] + "");
                        Credit_load.Add((TP / 2) + (TT / 2) + (TL) + "");
                        Domain_List.Add(rd["Course_Domain"] + "");
                        Course_Code = rd["Course_Code"] + "";
                        Section = rd["Section_Number"] + "";
                        Group_Label_v = rd["Group_Label"] + "";
                        Total_Load.Add(TP + TL + TT);
                        Course_Code_List.Add(Course_Code);
                        Section_List.Add(Section);
                        Group_Label.Add(Group_Label_v);
                        Course_Title.Add(rd["Course_Title"] + "");
                       
                       
                    }
                    catch (Exception ex)
                    {
                       // s += +TL + "-" + TT + "-" + TP + "-" + rd["Course_Domain"];
                        //s += ex.Message + "ISttt";
                        //ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                    }
                }
                rd.Close();
                con.Close();
                //s += "<li>"+Course_Code+"</li>";
                //cmd1
                con.Open();

                for (int i = 0; i < Course_Code_List.Count; i++)
                {

                    try
                    {



                        cmd1 = con.CreateCommand();
                        cmd1.Connection = con;
                        cmd1.CommandText = "SELECT * FROM teacher_precedence WHERE Course_Code='" + Course_Code_List[i].ToString() + "' AND Course_Domain='"+Domain_List[i].ToString()+"' AND Precedence='" + prece + "'";
                        MySqlDataReader rd1 = null;

                        rd1 = cmd1.ExecuteReader();

                        while (rd1.Read())
                        {
                            try
                            {
                                Teacher_name = rd1["Teacher_Name"] + "";
                                UID = rd1["Uid"] + "";
                                // s = UID;
                                //  s = "<li>" + UID + ":" + Teacher_name + "-" + Course_Code_List[i].ToString() + "-Section:" + Section_List[i].ToString() + "</li>";
                                //ph.Controls.Add(new LiteralControl(s));
                                UID_Filter.Add(UID);
                                Course_Code_Filter.Add(Course_Code_List[i]);
                                Section_Filter.Add(Section_List[i]);
                                Teacher_Name_Filter.Add(Teacher_name);
                                Total_Load_Filter.Add(Total_Load[i]);
                                Group_Label_Filter.Add(Group_Label[i]);
                                Course_Title_Filter.Add(Course_Title[i]);
                                Credit_load_filter.Add(Credit_load[i]);
                                Domain_List_Filter.Add(Domain_List[i]);
                              //  s += Domain_List[i].ToString()+"$$";
                                //s += "<li>'" + Group_Label_Filter[i].ToString() + "----" + i + "'</li>";
                            }
                            catch (Exception ex)
                            {
                                s += ex.Message;
                            }
                            //ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('" + TP + "')", true);
                        }

                        cmd1.Dispose();
                        rd1.Close();

                    }
                    catch (Exception ex)
                    {
                        s = ex.Message+"--aprox";
                        // ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('jjj" + ex.Message + "')", true);
                    }
                }

                con.Close();
                con.Open();
                for (int i = 0; i < UID_Filter.Count; i++)
                {
                    try
                    {
                        MySqlCommand cmd3;
                        cmd3 = con.CreateCommand();
                        cmd3.Connection = con;
                        cmd3.CommandText = "SELECT * FROM teacher_data WHERE Uid='" + UID_Filter[i] + "'AND No<'" + cond + "'";
                        MySqlDataReader rd3 = null;
                        rd3 = cmd3.ExecuteReader();
                        while (rd3.Read())
                        {
                            flag = 1;
                            Max_Load = int.Parse(rd3["Max_Load"] + "");
                            Allocated_Load = int.Parse(rd3["Allocated_Load"] + "");
                            Deducted_Load = int.Parse(rd3["Deducted_Load"] + "");
                            No = int.Parse(rd3["No"] + "");
                            Credit = float.Parse(rd3["Credit"] + "");
                        }
                        cmd3.Dispose();
                        rd3.Close();
                    }
                    catch (Exception ex)
                    {
                        s = ex.Message + "MYSELF";
                    }
                    //End Cmd3
                    try
                    {
                        con4.Close();
                        con4.Open();
                        MySqlCommand cmd4;
                        cmd4 = con4.CreateCommand();
                        cmd4.Connection = con4;
                        cmd4.CommandText = "SELECT * FROM teacher_load WHERE Section_Name='" + Section_Filter[i].ToString() + "' AND Course_Code='" + Course_Code_Filter[i].ToString() + "'  AND Course_Title='" + Course_Title_Filter[i].ToString() + "' ";
                        MySqlDataReader rd3 = null;
                        rd3 = cmd4.ExecuteReader();
                        while (rd3.Read())
                        {
                            flag = 0;
                            /*  if (Group_Label_Filter[i].ToString().Equals("1") || Group_Label_Filter[i].ToString().Equals("2"))
                              {
                                  flag = 1;
                              }*/
                            //  s += "<li>=========='" + Group_Label_Filter[i].ToString().Substring((Group_Label_Filter[i].ToString().Length)-4, Group_Label_Filter[i].ToString().Length) + "'========</li>";

                        }
                        cmd4.Dispose();
                        rd3.Close();
                    }
                    catch (Exception ex)
                    {
                        s = ex.Message + "MYSELF";
                    }

                    if ((Allocated_Load + Deducted_Load) < Max_Load && flag == 1)
                    {
                      //  s += "<li>'" + UID_Filter[i].ToString() + Course_Code_Filter[i].ToString() + "@" + "----" + i + "#" + Domain_List_Filter[i].ToString() + "'</li>";
                  
                        flag = 0;
                        int load = 0;
                        try
                        {
                            load = int.Parse(Total_Load_Filter[i].ToString());
                            Credit = Credit + float.Parse(Credit_load_filter[i].ToString());
                            //s += "<li>" +  load + "</li>";

                        }
                        catch (Exception ex)
                        {
                        }
                        if (load <= (Max_Load - (Allocated_Load + Deducted_Load)))
                        {   //Cmd2
                            try
                            {
                                // s += "<li>" + UID_Filter[i] + "-" + Section_Filter[i] +"-"+load+"</li>";
                                 hash=rand.Next(0, int.Parse(UID_Filter[i].ToString()));
                                con2.Close();
                                con2.Open();
                                MySqlCommand cmd2;
                                cmd2 = con2.CreateCommand();
                                cmd2.Connection = con2;
                                cmd2.CommandText = "UPDATE  load_table SET Feculty_Name='" + Teacher_Name_Filter[i].ToString() + "',UID='" + UID_Filter[i].ToString() + "',Hash_Code='" + UID_Filter[i].ToString()+""+hash + "' WHERE Course_Code='" + Course_Code_Filter[i].ToString() + "' AND Section_Number='" + Section_Filter[i].ToString() + "' AND Course_Title='" + Course_Title_Filter[i].ToString() + "' AND Course_Domain='"+Domain_List_Filter[i].ToString()+"' AND Group_Label!='5'";
                                cmd2.ExecuteNonQuery();
                                con2.Close();
                                //End cmd2
                            }
                            catch (Exception ex)
                            {
                                s = ex.Message + "cmd2";
                            }
                            //Cmd4
                            try
                            {
                                con4.Close();
                                con4.Open();
                                MySqlCommand cmd4;
                                cmd4 = con4.CreateCommand();
                                cmd4.Connection = con4;
                                cmd4.CommandText = "UPDATE teacher_data SET Allocated_Load='" + (Allocated_Load + load) + "" + "',No='" + (No + 1) + "', Credit='" + Credit + "', Con='" + (Allocated_Load + load) + "" + "',Hash_Code='" + UID_Filter[i].ToString() + "" + hash + "' WHERE Uid='" + UID_Filter[i].ToString() + "'";
                                cmd4.ExecuteNonQuery();
                                con4.Close();
                                //End Cmd4
                            }
                            catch (Exception ex)
                            {
                                s = ex.Message+"sss";
                            }
                            try
                            {
                                con2.Close();
                                con2.Open();
                                MySqlCommand cmd2;
                                cmd2 = con2.CreateCommand();
                                cmd2.Connection = con2;
                                cmd2.CommandText = "INSERT INTO teacher_load (Uid,Teacher_Name,Max_Load,Allocated_Load,Deducted_Load,Section_Name,Course_Code,Course_Title,Hash_Code) VALUES('" + UID_Filter[i] + "','" + Teacher_Name_Filter[i] + "','" + Max_Load + "','" + load + "','" + 0 + "','" + Section_Filter[i].ToString() + "','" + Course_Code_Filter[i].ToString() + "','" + Course_Title_Filter[i].ToString() + "','" + UID_Filter[i].ToString() + "" + hash + "')";
                                cmd2.ExecuteNonQuery();
                                con2.Close();
                                //End Cmd4
                            }
                            catch (Exception ex)
                            {
                                s = ex.Message;
                            }


                            s += "<tr><td>" + UID_Filter[i].ToString() + "</td><td>" + Teacher_Name_Filter[i].ToString() + "</td><td>" + Course_Code_Filter[i].ToString() + "</td><td>" + Course_Title_Filter[i].ToString() + "</td><td>" + Section_Filter[i].ToString() + "</td></tr>";
                        }
                    }
                    //End Cmd1
                }
                s += "</table>";


                //s += "<li>'"+Course_Code+"'->'"+UID+":"+Teacher_name+"'-->Allocated_Load-->'"+Allocated_Load+"'</li>";
                for (int i = 0; i < Course_Code_Filter.Count; i++)
                {
                    // s += "<li>" + Course_Code_Filter[i] +"-"+Teacher_Name_Filter[i]+"-"+UID_Filter[i]+"-"+Total_Load_Filter[i]+ "-" + Section_Filter[i] + "--" + Total_Load[i] + "</li>";
                }
                // Console.WriteLine(s);
                ph.Controls.Add(new LiteralControl(s));

                ScriptManager.RegisterStartupScript(up,up.GetType(), "", "showpop();", true);

                //Connection Closing
                con1.Close();
                con2.Close();
                con3.Close();
                con4.Close();
                //End
            }




            catch (Exception ex)
            {
                // TextBox1.Text = ex.Message;
            }

        }

        public void reset()
        {
            try
            {
                con2.Close();
                con2.Open();
                MySqlCommand cmd2;
                cmd2 = con2.CreateCommand();
                cmd2.Connection = con2;
                cmd2.CommandText = "UPDATE load_table SET Feculty_Name='',UID='',Hash_Code='' WHERE Course_Code!=''; " +
                    "UPDATE load_table SET Group_Label='0' WHERE Group_Label!='0'; TRUNCATE TABLE teacher_load;UPDATE teacher_data SET Allocated_Load=0,Credit='0',Con='0',Section_Mentor='',Hash_Code='';UPDATE teacher_data SET No=0;";
                cmd2.ExecuteNonQuery();
                con2.Close();
                //End Cmd4
                /*
                 ArrayList Course_Code_List = new ArrayList();
                 ArrayList Section_List = new ArrayList();
                 ArrayList Total_Load = new ArrayList();
                
                 ArrayList Course_Code_Filter = new ArrayList();
                 ArrayList Group_Label = new ArrayList();
                 ArrayList Group_Label_Filter = new ArrayList();
                 ArrayList Course_Title = new ArrayList();
                 ArrayList Course_Title_Filter = new ArrayList();
                 ArrayList Section_Filter = new ArrayList();*/
            }
            catch (Exception ex)
            {
                // s = ex.Message;
            }
        }
        public ArrayList Get_Query(String q, int i)
        {
            ArrayList CC_array = new ArrayList();
            ArrayList SN_array = new ArrayList();
            ArrayList AL_array = new ArrayList();
            SN_array.Add("Select");
            CC_array.Add("Select");
            if (i == 1)
            {
                try
                {
                    con.Close();
                    con.Open();
                    MySqlCommand cmd3;
                    cmd3 = con.CreateCommand();
                    cmd3.Connection = con;
                    cmd3.CommandText = q;
                    MySqlDataReader rd3 = null;
                    rd3 = cmd3.ExecuteReader();
                    while (rd3.Read())
                    {
                        CC_array.Add(rd3["Course_Code"] + ":" + rd3["Course_Title"]);


                    }
                    cmd3.Dispose();
                    rd3.Close();
                }
                catch (Exception ex)
                {
                    //s = ex.Message + "MYSELF";
                }
            }
            if(i==2)
            {
                try
                {
                    con.Close();
                    con.Open();
                    MySqlCommand cmd3;
                    cmd3 = con.CreateCommand();
                    cmd3.Connection = con;
                    cmd3.CommandText = q;
                    MySqlDataReader rd3 = null;
                    rd3 = cmd3.ExecuteReader();
                    while (rd3.Read())
                    {

                        SN_array.Add(rd3["Section_Number"] + "");

                    }
                    cmd3.Dispose();
                    rd3.Close();
                }
                catch (Exception ex)
                {
                    //s = ex.Message + "MYSELF";
                }
            }
            if (i == 3)
            {
                try
                {
                    con.Close();
                    con.Open();
                    MySqlCommand cmd3;
                    cmd3 = con.CreateCommand();
                    cmd3.Connection = con;
                    cmd3.CommandText = q;
                    MySqlDataReader rd3 = null;
                    rd3 = cmd3.ExecuteReader();
                    while (rd3.Read())
                    {

                        AL_array.Add(rd3["TL"] + "");
                        AL_array.Add(rd3["TT"] + "");
                        AL_array.Add(rd3["TP"] + "");

                    }
                    cmd3.Dispose();
                    rd3.Close();
                }
                catch (Exception ex)
                {
                    //s = ex.Message + "MYSELF";
                }
                
            }

            if (i == 1)
            {
                /* for (int k = 0; k < CC_array.Count; k++)
                 {
                     for (int j = k; j < CC_array.Count; j++)
                     {
                         if (CC_array[k].Equals(CC_array[j]))
                         {
                             try
                             {
                                 CC_array.RemoveAt(k);
                             }
                             catch (Exception e)
                             {
                             }
                         }
                     }
                 }*/

                return CC_array;
            }
            if(i==2)
            {

                return
                SN_array;
            }
            if (i == 3)
            {
                return AL_array;
            }
            return null;
        }
        public void Optimize_Database()
        {
            String s = "";
            try
            {
                con4.Close();
                con4.Open();
                MySqlCommand cmd4;
                cmd4 = con4.CreateCommand();
                cmd4.Connection = con4;
                cmd4.CommandText = "UPDATE load_table SET Group_Label='1' WHERE Course_Title LIKE '%(G1)%';" +
                                    "UPDATE load_table SET Group_Label='2' WHERE Course_Title LIKE '%(G2)%';" +
                                    "UPDATE load_table SET Group_Label='3' WHERE Course_Code LIKE 'MNT___%' AND UID='';" +
                                    "UPDATE load_table SET Group_Label='4' WHERE T!='0' AND L='0' ;";
                cmd4.ExecuteNonQuery();
                con4.Close();
                //End Cmd4
                MySqlCommand cmd;
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From load_table WHERE T!='0' AND L='0'";
                MySqlDataReader rd = null;
                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                //end
                while (rd.Read())
                {
                    try
                    {
                        con2.Close();
                        con2.Open();
                        MySqlCommand cmd2;
                        cmd2 = con2.CreateCommand();
                        cmd2.Connection = con2;
                        cmd2.CommandText = "UPDATE load_table SET T='" + rd["T"].ToString() + "',TT='" + rd["TT"].ToString() + "' WHERE Section_Number='" + rd["Section_Number"].ToString() + "' AND Course_Code='" + rd["Course_Code"].ToString() + "' AND T='0';" +
                        "UPDATE load_table SET Group_Label='5' WHERE T!='0' AND L='0' AND Section_Number='" + rd["Section_Number"].ToString() + " 'AND Course_Code='" + rd["Course_Code"].ToString() + "' ;";
                        cmd2.ExecuteNonQuery();
                        con2.Close();

                    }
                    catch (Exception ex)
                    {
                        s += ex.Message + "";
                        // tm.Page.ClientScript.RegisterClientScriptBlock(tm.GetType(), "", "alert('" + ex.Message + "');", true);   
                    }
                }

            }
            catch (Exception ex)
            {
                s += ex.Message + "--outer";
                //tm.Page.ClientScript.RegisterClientScriptBlock(tm.GetType(), "", "alert('" + ex.Message + "');", true);
            }
           // ph.Controls.Add(new LiteralControl(s));

          //  ScriptManager.RegisterStartupScript(up,up.GetType(), "", "showpop();", true);
            //  tm.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "closeload();", true);
        }
        public void Check_Load_By_Uid(String query, PlaceHolder ph, Modify_By_Uid Mm)
        {
            ArrayList CC = new ArrayList();
            ArrayList Uid = new ArrayList();
            ArrayList CT = new ArrayList();
            ArrayList SN = new ArrayList();
            ArrayList AL = new ArrayList();
            ArrayList HC = new ArrayList();
            ArrayList ATT = new ArrayList();
            ArrayList ATP = new ArrayList();
            String T_UID = "";
            String T_Name = "";
            int TP, TL, TT;
            int n = 0;
            //String s = "";
            // s += "<table border='1' cellpadding='5' cellspacing='0'><tr><th><b>UID</b></th><th><b>Name</b></th><th><b>Course Code</b></th><th><b>Course Title</b></th><th><b>Section Number</b></th><th><b>Allocated Load</b></th></tr>";
            int flag = 0;
            con.Close();
            con.Open();
            MySqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandText =query;
            MySqlDataReader rd = null;
            cmd2.Connection = con;
            rd = cmd2.ExecuteReader();
            //end
            while (rd.Read())
            {
                try
                {
                    n++;
                    flag = 1;
                    TP = 0;
                    TL = 0;
                    TT = 0;
                    TP += int.Parse(rd["TP"] + "");
                    TL += int.Parse(rd["TL"] + "");
                    TT += int.Parse(rd["TT"] + "");
                    T_Name = rd["Feculty_Name"] + "";
                    CC.Add(rd["Course_Code"].ToString());
                    CT.Add(rd["Course_Title"].ToString());
                    SN.Add(rd["Section_Number"].ToString());
                    HC.Add(rd["Hash_Code"] + "");
                    Uid.Add(rd["UID"]+"");
                    AL.Add(TL);
                    ATT.Add(TT+"");
                    ATP.Add(TP + "");
                    //s += "<tr><td>" + rd["Uid"] + "</td><td>" + rd["Feculty_Name"] + "</td><td>" + rd["Course_Code"] + "</td><td>" + rd["Course_Title"] + "</td><td>" + rd["Section_Number"] + "</td><td>" + TL + TP + TT + "'</td></tr>";



                }
                catch (Exception ex)
                {
                    //ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                }
            }
            //s += "</table>";
            rd.Close();
            con.Close();
            
            Mm.Modify_Load(Uid, n, T_Name, CC, CT, SN, AL, HC,ATT,ATP);
            
            //.Modify_Load(uid, n, T_Name, CC, CT, SN, AL, HC,TTTP);
            //tm.Response.Redirect("Modify_By_Uid.aspx");
            //ph.Controls.Add(new LiteralControl(s));
            //if (flag == 0)
                //ScriptManager.RegisterClientScriptBlock(Mm, Mm.GetType(), "alertMessage", "alert('UID is Not Found!!')", true);
            //  else
            //    tm.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "showpop();", true);

        }

        public ArrayList ff()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < 10; i++)
                al.Add(i + "");
            return al;
        }
        public void Modify_By_Uid(String uid, PlaceHolder ph, Time_table_manager tm,UpdatePanel u)
        {
            //ScriptManager.RegisterClientScriptBlock(u, u.GetType(), "", "alert('" + uid + "');", true);
            int TP, TL, TT;
            String s = "";
            s += "<table border='1' cellpadding='5' cellspacing='0'><tr><th><b>UID</b></th><th><b>Name</b></th><th><b>Course Code</b></th><th><b>Course Title</b></th><th><b>Section Number</b></th><th><b>TL</b></th><th><b>TT</b></th><th><b>TP</b></th></tr>";
            int flag = 0;
            try{
            con.Close();
            con.Open();
            MySqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandText = "Select * From load_table WHERE UID='" + uid + "'";
            MySqlDataReader rd = null;
            cmd2.Connection = con;
            rd = cmd2.ExecuteReader();
            //end
            while (rd.Read())
            {
                try
                {
                    flag = 1;
                    TP = 0;
                    TL = 0;
                    TT = 0;
                    TP += int.Parse(rd["TP"] + "");
                    TL += int.Parse(rd["TL"] + "");
                    TT += int.Parse(rd["TT"] + "");


                    s += "<tr><td>" + rd["Uid"] + "</td><td>" + rd["Feculty_Name"] + "</td><td>" + rd["Course_Code"] + "</td><td>" + rd["Course_Title"] + "</td><td>" + rd["Section_Number"] + "</td><td>" + TL + "<td>" + TT + "</td><td>" + TP + "</td></tr>";

                }

                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                }
            }
            
            s += "<tr><td colspan='8'><center><a href='Modify_By_Uid.aspx' class='myButton'>Edit</a></center></td></tr></table>";
            tm.Application["uid"] = uid;
            rd.Close();
            con.Close();

            ph.Controls.Add(new LiteralControl(s));
            if (flag == 0)
                ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('UID is Not Found!!')", true);
            else     
               // new Modify_By_Uid().Modify_Load
                ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "showpop();", true);
        
            }
            catch (Exception ex)
            {
            }
    }
        public void Modify_Delete(String hash,String uid,String AL,String CR)
        {
          try{
              int T_Load = 0;
              float credit = 0;
              int No = 0;
            MySqlCommand cmd;
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From teacher_data WHERE uid='"+uid+"'";
                MySqlDataReader rd = null;
                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                //end
                while (rd.Read())
                {
                    T_Load = int.Parse(rd["Allocated_Load"].ToString());
                    credit=float.Parse(rd["Credit"].ToString());
                    No = int.Parse(rd["No"].ToString());
                }
                con.Close();
                T_Load = T_Load - int.Parse(AL);
                con4.Close();
                con4.Open();
                MySqlCommand cmd4;
                cmd4 = con4.CreateCommand();
                cmd4.Connection = con4;
                cmd4.CommandText =  "DELETE FROM teacher_load where Hash_Code='" + hash + "';UPDATE load_table SET Uid='',Feculty_Name='',Hash_Code='',Group_Label='0' WHERE Hash_Code='" + hash + "';" +
                                    "UPDATE teacher_data SET Allocated_Load='"+T_Load+""+"',Con='"+T_Load+""+"',Credit='"+(credit-float.Parse(CR))+"',No='"+(No-1)+"' WHERE uid='"+uid+"'; ";
                cmd4.ExecuteNonQuery();
                con4.Close();
                Optimize_Database();
                }catch(Exception ex)
          {
                }
          
                
            }
        public void Modify_Update(String hash, String uid,String FN,String SN, String AL,String CC,String CT, String CR,UpdatePanel up)
        {
           //
            int TP=0, TL=0, TT=0;
            Random r = new Random();
            try
            {
                int max_Load=0;
                int T_Load = 0;
                float credit = 0;
                int No = 0;
                int deduct_Load = 0;
                int cre=0;
                MySqlCommand cmd;
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From teacher_data WHERE uid='" + uid + "'";
                MySqlDataReader rd = null;
                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                //end
                while (rd.Read())
                {
                    T_Load = int.Parse(rd["Allocated_Load"].ToString());
                    credit = float.Parse(rd["Credit"].ToString());
                    No = int.Parse(rd["No"].ToString());
                    max_Load=int.Parse(rd["Max_Load"].ToString());
                    deduct_Load = int.Parse(rd["Deducted_Load"].ToString());
                }
                con.Close();
                 con.Close();
            con.Open();
            MySqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandText = "Select * From load_table WHERE Hash_Code='" + hash + "'";
            MySqlDataReader rd1 = null;
            cmd2.Connection = con;
            rd1 = cmd2.ExecuteReader();
            //end
            while (rd1.Read())
            {
                try
                {
                    TP = 0;
                    TL = 0;
                    TT = 0;
                    TP += int.Parse(rd1["TP"] + "");
                    TL += int.Parse(rd1["TL"] + "");
                    TT += int.Parse(rd1["TT"] + "");
                }
                catch (Exception ex)
                {
                }
            }
            if (TL!= 0)
            {
                cre += TL;
            }
            if (TT != 0)
            {
                cre += TT / 2;
            }
            if (TP!= 0)
            {
                cre += TP / 2;
            }
                 T_Load = T_Load + (int.Parse(AL) - (TL + TT + TP))-deduct_Load;
                 if (T_Load <= max_Load)
                 {
                     try
                     {
                         con2.Close();

                         credit += float.Parse(CR) - cre;
                         con4.Close();
                         con4.Open();
                         MySqlCommand cmd4;
                         cmd4 = con4.CreateCommand();
                         cmd4.Connection = con4;
                         cmd4.CommandText = "UPDATE load_table SET Uid='" + uid + "', Feculty_Name='" + FN + "', Hash_Code='" + uid + "" + r.Next(0, int.Parse(uid)) + "' WHERE Section_Number='" + SN + "' AND Course_Code='" + CC + "' AND Course_Title='" + CT + "' ;" +
                         "UPDATE load_table SET Uid='',Feculty_Name='',Hash_Code='' WHERE Hash_Code='" + hash + "' ;" +
                         "UPDATE teacher_data SET Allocated_Load='" + T_Load + "" + "',Con='" + T_Load + "" + "',Credit='" + credit + "' WHERE uid='" + uid + "'; " +
                         "DELETE FROM teacher_load Where Hash_Code='" + hash + "'; INSERT INTO teacher_load (Uid,Teacher_Name,Max_Load,Allocated_Load,Deducted_Load,Section_Name,Course_Code,Course_Title,Hash_Code) VALUES('" + uid + "','" + FN + "','" + max_Load + "','" + T_Load + "','" + 0 + "','" + SN + "','" + CC + "','" + CT + "','" + uid + "" + r.Next(0, int.Parse(uid)) + "');";

                         cmd4.ExecuteNonQuery();
                         con4.Close();
                     }
                     catch (Exception ex)
                     {
                         ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('" + ex.Message + "')", true);
                     }
                 }
                 else
                 {
                    
                     ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('Maximum Load is " + max_Load + "!!.After this updation Allocated load over the Maximum.'); Close_add_pop();", true);
                 }

           }
           catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('" + ex.Message + "')", true);
            }
           

        }

        public ArrayList Get_Load(String uid)
        {
            ArrayList T_Load = new ArrayList();
            MySqlCommand cmd;
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select * From teacher_data WHERE uid='" + uid + "'";
            MySqlDataReader rd = null;
            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            //end
            while (rd.Read())
            {
                T_Load.Add(rd["Allocated_Load"].ToString());
                T_Load.Add(rd["Credit"].ToString());
                T_Load.Add(rd["Max_Load"].ToString());
               
            }
            con.Close();
            return T_Load;
        }
        public void modify_add_new_course(String uid, String SN, String CC, String CT, UpdatePanel up,Label notify)
        {
            int TP = 0, TL = 0, TT = 0;
            String FN = "";
            Random r = new Random();
            try
            {
                int max_Load = 0;
                int T_Load = 0;
                float credit = 0;
                int No = 0;
                int deduct_Load = 0;
                int cre = 0;
                MySqlCommand cmd;
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From teacher_data WHERE uid='" + uid + "'";
                MySqlDataReader rd = null;
                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                //end
                while (rd.Read())
                {
                    T_Load = int.Parse(rd["Allocated_Load"].ToString());
                    credit = float.Parse(rd["Credit"].ToString());
                    No = int.Parse(rd["No"].ToString());
                    max_Load = int.Parse(rd["Max_Load"].ToString());
                    FN = rd["Teacher_Name"].ToString();
                    deduct_Load = int.Parse(rd["Deducted_Load"].ToString());
                }
                con.Close();
                con.Close();
                con.Open();
                MySqlCommand cmd2;
                cmd2 = con.CreateCommand();
                cmd2.CommandText = "Select * From load_table WHERE Course_Code='" + CC + "' AND Course_Title='"+CT+"' AND Section_Number='"+SN+"'";
                MySqlDataReader rd1 = null;
                cmd2.Connection = con;
                rd1 = cmd2.ExecuteReader();
                //end
                while (rd1.Read())
                {
                    try
                    {
                        TP = 0;
                        TL = 0;
                        TT = 0;
                        TP += int.Parse(rd1["TP"] + "");
                        TL += int.Parse(rd1["TL"] + "");
                        TT += int.Parse(rd1["TT"] + "");
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (TL != 0)
                {
                    cre += TL;
                }
                if (TT != 0)
                {
                    cre += TT / 2;
                }
                if (TP != 0)
                {
                    cre += TP / 2;
                }
                T_Load = T_Load + (TL + TT + TP)-deduct_Load;
                if (T_Load <= max_Load)
                {
                    int h=r.Next(0, int.Parse(uid));
                    try
                    {
                        con2.Close();

                        credit += cre;
                        con4.Close();
                        con4.Open();
                        MySqlCommand cmd4;
                        cmd4 = con4.CreateCommand();
                        cmd4.Connection = con4;
                        cmd4.CommandText = "UPDATE load_table SET Uid='" + uid + "', Feculty_Name='" + FN + "', Hash_Code='" + uid + "" +h+ "' WHERE Section_Number='" + SN + "' AND Course_Code='" + CC + "' AND Course_Title='" + CT + "' ;" +
                        "UPDATE teacher_data SET Allocated_Load='" + T_Load + "" + "',Con='" + T_Load + "" + "',Credit='" + credit + "' WHERE uid='" + uid + "'; " +
                       " INSERT INTO teacher_load (Uid,Teacher_Name,Max_Load,Allocated_Load,Deducted_Load,Section_Name,Course_Code,Course_Title,Hash_Code) VALUES('" + uid + "','" + FN + "','" + max_Load + "','" + T_Load + "','" + 0 + "','" + SN + "','" + CC + "','" + CT + "','" + uid + "" +h+ "');";

                        cmd4.ExecuteNonQuery();
                        con4.Close();
                        notify.Text = "Course Allocated Successfully";
                        notify.Visible = true;
                        ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "Show_notify_btn();", true);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('" + ex.Message + "')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('Maximum Load is " + max_Load + "!!.After this updation Allocated load over the Maximum.')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('" + ex.Message + "')", true);
            }
        }

        public void Add_Allocate(String uid,UpdatePanel u,Time_table_manager tm)
        {
          int flag = 0;
            con.Close();
            con.Open();
            MySqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandText = "Select * From teacher_data WHERE UID='" + uid + "'";
            MySqlDataReader rd = null;
            cmd2.Connection = con;
            rd = cmd2.ExecuteReader();
            //end
            while (rd.Read())
            {
                try
                {
                    flag = 1;
                }
                catch (Exception ex)
                { ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                }
            }
                if (flag == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(u, u.GetType(),"","alert('Uid Not Found!!');",true);
                }
                else
                {
                    tm.Application["uid"] = uid;
                    tm.Response.Redirect("Modify_By_Uid.aspx");
                }
            }
        public void Section_Mentoring(UpdatePanel up,PlaceHolder ph)
        {
            String s = "<center><table><tr><th>UID</th><th>Section Number</th></tr>";
            ArrayList Section_Mentor = new ArrayList();
            ArrayList Teacher_Uid = new ArrayList();
            ArrayList Course_Code = new ArrayList();
            ArrayList Course_Title = new ArrayList();
            MySqlCommand cmd;
            con.Close();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select * From load_table WHERE UID='' AND Group_Label='3'";
            MySqlDataReader rd = null;
            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            //end
            
            while (rd.Read())
            {
                try
                {
                    Section_Mentor.Add(rd["Section_Number"]+"");
                    Course_Code.Add(rd["Course_Code"] + "");
                    Course_Title.Add(rd["Course_Title"]+"");
                 //   s += rd["Section_Number"] + "";
                    
                   
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                }
            }
            rd.Close();
            con.Close(); 
            cmd.Dispose();
            con.Close();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select * From teacher_data Where Section_Mentor=''";
           
            cmd.Connection = con;
            rd = cmd.ExecuteReader();
            //end
            while (rd.Read())
            {
                try
                {
                    Teacher_Uid.Add(rd["UID"] + "");
                    //s += (rd["UID"] + "");

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                }
            }
            rd.Close();
            con.Close();
            cmd.Dispose();
            int temp_flag = 0;
            for (int i = 0; i < Section_Mentor.Count; i++)
            {
                temp_flag = 0;

               // s += "" + i;
                for (int j = 0; j < Teacher_Uid.Count; j++)
                {
                    con.Close();
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "Select * From teacher_data Where Uid='" + Teacher_Uid[j].ToString() + "' AND Section_Mentor=''";
                    cmd.Connection = con;
                    rd = cmd.ExecuteReader();
                    //end
                    while (rd.Read())
                    {
                        try
                        {
                            temp_flag = 1;

                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                        }
                    }
                    rd.Close();
                    con.Close();
                    cmd.Dispose();
                    if (temp_flag == 1)
                    {
                        
                        int temp_flag_I = 0;
                        con.Close();
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "Select * From load_table Where Uid='" + Teacher_Uid[j].ToString() + "' AND Section_Number='" + Section_Mentor[i].ToString() + "'";
                        cmd.Connection = con;
                        rd = cmd.ExecuteReader();
                        //end
                        while (rd.Read())
                        {
                            try
                            {
                                temp_flag_I = 1;
                                break;

                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                            }
                        }
                        rd.Close();
                        con.Close();
                        cmd.Dispose();
                        if (temp_flag_I == 1)
                        {
                            //s += i + "#";
                            int TP = 0, TL = 0, TT = 0;
                            String FN = "";
                            Random r = new Random();
                            try
                            {
                                int max_Load = 0;
                                int T_Load = 0;
                                float credit = 0;
                                int No = 0;
                                int deduct_Load = 0;
                                int cre = 0;
                                //MySqlCommand cmd;
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "Select * From teacher_data WHERE uid='" + Teacher_Uid[j].ToString() + "'";
                                //MySqlDataReader rd = null;
                                cmd.Connection = con;
                                rd = cmd.ExecuteReader();
                                //end
                                while (rd.Read())
                                {
                                    T_Load = int.Parse(rd["Allocated_Load"].ToString());
                                    credit = float.Parse(rd["Credit"].ToString());
                                    No = int.Parse(rd["No"].ToString());
                                    max_Load = int.Parse(rd["Max_Load"].ToString());
                                    FN = rd["Teacher_Name"].ToString();
                                    deduct_Load = int.Parse(rd["Deducted_Load"].ToString());
                                }
                                con.Close();
                                rd.Dispose();
                                con.Close();
                                con.Open();
                                MySqlCommand cmd2;
                                cmd2 = con.CreateCommand();
                                cmd2.CommandText = "Select * From load_table WHERE Course_Code='" + Course_Code[i].ToString() + "' AND  Section_Number='" + Section_Mentor[i].ToString() + "'";
                                MySqlDataReader rd1 = null;
                                cmd2.Connection = con;
                                rd1 = cmd2.ExecuteReader();
                                //end
                                while (rd1.Read())
                                {
                                    try
                                    {
                                        TP = 0;
                                        TL = 0;
                                        TT = 0;
                                        TP += int.Parse(rd1["TP"] + "");
                                        TL += int.Parse(rd1["TL"] + "");
                                        TT += int.Parse(rd1["TT"] + "");
                                        break;
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('check1');", true);
                                    }
                                }
                                try
                                {
                                    if (TL != 0)
                                    {
                                        cre += TL;
                                    }
                                    if (TT != 0)
                                    {
                                        cre += TT / 2;
                                    }
                                    if (TP != 0)
                                    {
                                        cre += TP / 2;
                                    }
                                    T_Load = T_Load + (TL + TT + TP) - deduct_Load;
                                    //s += T_Load + "-";
                                }
                                catch (Exception ex)
                                {
                                    ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('check1');", true);
                                }
                                if (T_Load <= max_Load)
                                {
                                  //  s += Teacher_Uid[j].ToString();
                                    try
                                    {
                                        int h = r.Next(0, int.Parse(Teacher_Uid[j].ToString()));

                                        con2.Close();
                                    //    s += Teacher_Uid[i].ToString();
                                        credit += cre;
                                        con4.Close();
                                        con4.Open();
                                        MySqlCommand cmd4;
                                        cmd4 = con4.CreateCommand();
                                        cmd4.Connection = con4;
                                        cmd4.CommandText = "UPDATE load_table SET Uid='" + Teacher_Uid[j].ToString() + "', Feculty_Name='" + FN + "', Hash_Code='" + Teacher_Uid[j].ToString() + "" + h + "',Group_Label='8' WHERE Section_Number='" + Section_Mentor[i].ToString() + "' AND Course_Code='" + Course_Code[i].ToString() + "' ;" +
                                        "UPDATE teacher_data SET Allocated_Load='" + T_Load + "" + "',Con='" + T_Load + "" + "',Credit='" + credit + "',Section_Mentor='" + Section_Mentor[i].ToString() + "' WHERE uid='" + Teacher_Uid[j].ToString() + "'; " +
                                       " INSERT INTO teacher_load (Uid,Teacher_Name,Max_Load,Allocated_Load,Deducted_Load,Section_Name,Course_Code,Course_Title,Hash_Code) VALUES('" + Teacher_Uid[j].ToString() + "','" + FN + "','" + max_Load + "','" + T_Load + "','" + 0 + "','" + Section_Mentor[i].ToString() + "','" + Course_Code[i].ToString() + "','" + Course_Title[i].ToString() + "','" + Teacher_Uid[j].ToString() + "" + h + "');"
                                       +"INSERT INTO mentor_section_table (Uid,Section_Number) VALUES('"+Teacher_Uid[j]+"','"+Section_Mentor[i]+"')";
                                        try
                                        {
                                            cmd4.ExecuteNonQuery();
                                            s += "<tr><td>" + Teacher_Uid[j].ToString() + "</td><td>" + Section_Mentor[i].ToString() + "</td></tr>";
                                           
                                            Teacher_Uid.RemoveAt(j);
                                            Teacher_Uid.Insert(j, "0");
                                             Section_Mentor.RemoveAt(i);
                                            Section_Mentor.Insert(i,"0");

                                            break;
                                        }
                                        catch (Exception ex)
                                        {
                                            ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('check1');", true);
                                        }
                                        con4.Close();
                                        //           notify.Text = "Course Allocated Successfully";
                                        //         notify.Visible = true;
                                        // ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "Show_notify_btn();", true);
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('" + ex.Message + "')", true);
                                    }
                                }
                                else
                                {
                                    //ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('Maximum Load is " + max_Load + "!!.After this updation Allocated load over the Maximum.')", true);

                                }
                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('" + ex.Message + "')", true);
                            }

                        }

                    }

                }
            }
            s += "</table></center>";
            ph.Controls.Add(new LiteralControl(s));

            ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "showpop();", true);
        }


        public void Check_By_Section(String SN,UpdatePanel up,PlaceHolder ph,Time_table_manager tm)
        {
            int flag = 0;
            int TP, TL, TT;
            String s = "";
            s += "<table border='1' cellpadding='5' cellspacing='0'><tr><th><b>UID</b></th><th><b>Name</b></th><th><b>Course Code</b></th><th><b>Course Title</b></th><th><b>Section Number</b></th><th><b>TL</b></th><th><b>TT</b></th><th><b>TP</b></th></tr>";
            con.Close();
            con.Open();
            MySqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandText = "Select * From load_table WHERE Section_Number='" + SN + "'";
            MySqlDataReader rd = null;
            cmd2.Connection = con;
            rd = cmd2.ExecuteReader();
            //end
            while (rd.Read())
            {
               try{
                 flag = 1;
                    TP = 0;
                    TL = 0;
                    TT = 0;
                    TP += int.Parse(rd["TP"] + "");
                    TL += int.Parse(rd["TL"] + "");
                    TT += int.Parse(rd["TT"] + "");


                    s += "<tr><td>" + rd["Uid"] + "</td><td>" + rd["Feculty_Name"] + "</td><td>" + rd["Course_Code"] + "</td><td>" + rd["Course_Title"] + "</td><td>" + rd["Section_Number"] + "</td><td>" + TL +"<td>"+ TT +"</td><td>"+ TP + "</td></tr>";

                    
                }
                 
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "alertMessage", "alert('Something went wrong!!'" + ex.Message + "'')", true);
                }

            }
            s += " <tr><td colspan='8'><center><a href='Modify_By_Section.aspx' class='myButton'>Edit</a></center></td></tr></table>";
            tm.Application["section"] = SN; 
            
            rd.Close();
            con.Close();

            ph.Controls.Add(new LiteralControl(s));
            if (flag == 0)
            {
                ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('Section Not Found!!');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "showpop();", true);
            }
        }
        public void Insert_Into_Database(GridView GV,Excel_IE up,Label lb,int f,String Pv_Db_Name)
        {
            int flag = 0;
           
 
           if (f == 1)
            {
                try
                {
                    con2.Close();
                    con2.Open();
                    MySqlCommand cmd2;
                    cmd2 = con2.CreateCommand();
                    cmd2.Connection = con2;
                    cmd2.CommandText = "CREATE TABLE " + Pv_Db_Name + " AS SELECT * FROM load_table; INSERT INTO Backup_Info (DB_Name,Date) VALUES('"+Pv_Db_Name+"','"+DateTime.Today.ToString("dd-MM-yyyy")+"');";
                    cmd2.ExecuteNonQuery();
                    cmd2.Dispose();
                    con.Close();
                }catch( Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert("+ex.Message+");", true);
              
                }


            }

            if (GV.HeaderRow.Cells[0].Text.Trim().Equals("Department") || GV.HeaderRow.Cells[1].Text.Trim().Equals("Section_Number") || GV.HeaderRow.Cells[2].Text.Trim().Equals("Year")|| GV.HeaderRow.Cells[3].Text.Trim() == "Term" || GV.HeaderRow.Cells[4].Text.Trim() == "Course Code" || GV.HeaderRow.Cells[5].Text.Trim() == "Course Title" || GV.HeaderRow.Cells[6].Text.Trim()== "L" || GV.HeaderRow.Cells[7].Text.Trim()== "T" || GV.HeaderRow.Cells[8].Text.Trim()== "P" || GV.HeaderRow.Cells[9].Text.Trim() == "Groups" || GV.HeaderRow.Cells[10].Text.Trim() == "TL" || GV.HeaderRow.Cells[11].Text.Trim()== "TT" || GV.HeaderRow.Cells[12].Text.Trim() == "TP" || (GV.HeaderRow.Cells[13].Text.Trim() == "Course_Domain")||GV.HeaderRow.Cells[14].Text.Trim() == "Feculty Name"||GV.HeaderRow.Cells[15].Text.Trim() == "U.ID")
            {
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "", "alert('Excel Sheet Format must be below manner!!!');", true);
                flag = 1;
            }
            if (flag == 0)
            {
               /* con2.Close();
                con2.Open();
                MySqlCommand cmd3;
                cmd3 = con2.CreateCommand();
                cmd3.Connection = con2;
                cmd3.CommandText = "TRUNCATE TABLE load_table;"; 
                cmd3.ExecuteNonQuery();
                con2.Close();*/
            foreach (GridViewRow gr in GV.Rows)
            {
                
                    
                
               
                    if (gr.Cells[0].Text != "Department")
                    {
                        con2.Close();
                        con2.Open();
                        MySqlCommand cmd2;
                        cmd2 = con2.CreateCommand();
                        cmd2.Connection = con2;
                        cmd2.CommandText = "INSERT INTO load_table (Department,Section_Number,Year,Term,Course_Code,Course_Title,L,T,P,Groups,TL,TT,TP,Course_Domain,Feculty_Name,UID) VALUES('" + gr.Cells[0].Text + "','" + gr.Cells[1].Text + "','" + gr.Cells[2].Text + "',"
                            + "'" + gr.Cells[3].Text + "','" + gr.Cells[4].Text + "','" + gr.Cells[5].Text + "','" + gr.Cells[6].Text + "'," +
                            "'" + gr.Cells[7].Text + "','" + gr.Cells[8].Text + "','" + gr.Cells[9].Text + "','" + gr.Cells[10].Text + "'," +
                            "'" + gr.Cells[11].Text + "','" + gr.Cells[12].Text + "','" + gr.Cells[13].Text + "','" + gr.Cells[14].Text + "'," +
                            "'" + gr.Cells[15].Text + "');";
                        cmd2.ExecuteNonQuery();
                        con2.Close();
                    }
                }
            lb.Text = "Excel Sheet Load Successfully.";
              
            lb.Visible = true;
            
            }
        }
        public DataSet Export_To_Excel(String query)
        {

            con.Close();
            con.Open();
            MySqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandText = query;
            using (MySqlDataAdapter sda = new MySqlDataAdapter())
            {

                cmd2.Connection = con;
                sda.SelectCommand = cmd2;
                using (DataSet dt = new DataSet())
                {
                    sda.Fill(dt);
                    return dt;
                     }
            }
        }
        public DataSet Export_To_Excel_Final(String query)
        {
           DataSet dt = new DataSet();
            
            con.Close();
            con.Open();
            MySqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandText = query;
            using (MySqlDataAdapter sda = new MySqlDataAdapter())
            {

                cmd2.Connection = con;
                sda.SelectCommand = cmd2;
               
                    sda.Fill(dt);
                  
                
            }
            dt.Tables[0].Columns.Add("Load", typeof(String));
            dt.Tables[0].Columns.Add("Credit", typeof(String));
          
            for (int i = 0; i < dt.Tables[0].Rows.Count;i++ )
            {
                string uid = dt.Tables[0].Rows[i]["Uid"].ToString();
                con.Close();
                con.Open();
                ArrayList al = new ArrayList();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From teacher_data Where uid='"+uid+"'";
                cmd.Connection = con;
                MySqlDataReader rd;
                rd = cmd.ExecuteReader();
                //end
                while (rd.Read())
                {
                    try
                    {
                        dt.Tables[0].Rows[i]["Load"]=""+rd["Allocated_Load"];
                        dt.Tables[0].Rows[i]["Credit"] = "" + rd["Credit"];
                    }
                    catch (Exception ex)
                    {
                        // ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                    }
                }
                rd.Close();
                con.Close();
                cmd.Dispose();

                
            }
            return dt;
        }
        public ArrayList Get_Backup_Queries(String query,String arg)
        {
             con.Close();
                    con.Open();
                    ArrayList al = new ArrayList();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    MySqlDataReader rd;
                    rd = cmd.ExecuteReader();
                    //end
                    while (rd.Read())
                    {
                        try
                        {
                            al.Add(rd[arg].ToString());
                        }
                        catch (Exception ex)
                        {
                           // ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                        }
                    }
                    rd.Close();
                    con.Close();
                    cmd.Dispose();
                    return al;
           
        }
        public void Domain_Wise_Allocation(UpdatePanel up,Time_table_manager tm,PlaceHolder ph,String cond,String prece)
        {
            try
            {
                Random rand = new Random();
                //connection opening
                con.Open();
                con1.Open();
                //end
                long hash = 0;
                int flag = 0;
                int TP = 0;
                int TL = 0;
                int TT = 0;
                int sum = 0;
                int Max_Load = 0;
                int Allocated_Load = 0;
                int No_teacher = 0;
                int Deducted_Load = 0;
                int Filter = 0;
                float Credit = 0;
                String Group_Label_v = "";
                int No = 0;
                String Course_Code = "";
                ArrayList Course_Code_List = new ArrayList();
                ArrayList Section_List = new ArrayList();
                ArrayList Domain_List = new ArrayList();
                ArrayList Domain_List_Filter = new ArrayList();
                ArrayList Total_Load = new ArrayList();
                ArrayList UID_Filter = new ArrayList();
                ArrayList Teacher_Name_Filter = new ArrayList();
                ArrayList Course_Code_Filter = new ArrayList();
                ArrayList Group_Label = new ArrayList();
                ArrayList Group_Label_Filter = new ArrayList();
                ArrayList Course_Title = new ArrayList();
                ArrayList Course_Title_Filter = new ArrayList();
                ArrayList Section_Filter = new ArrayList();
                ArrayList Credit_load = new ArrayList();
                ArrayList Credit_load_filter = new ArrayList();
                ArrayList Total_Load_Filter = new ArrayList();
                String Teacher_name = "";
                String UID = "";
                String Section = "";
                String s = "";
                MySqlCommand cmd;
                MySqlCommand cmd1;
                s += "<center><h1><u>Allocated Detail</u></h1></center><br>";
                s += "<table border='1' cellpadding='5' cellspacing='0'><tr><th><b>UID</b></th><th><b>Name</b></th><th><b>Course Code</b></th><th><b>Course Title</b></th><th><b>Section Number</b></th></tr>";
                //cmd
                cmd = con.CreateCommand();
                cmd.CommandText = "Select * From load_table WHERE UID='' AND Group_Label!='5' AND Group_Label!='3'";
                MySqlDataReader rd = null;
                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                //end
                while (rd.Read())
                {
                    try
                    {

                        TP = 0;
                        TL = 0;
                        TT = 0;
                        TP += int.Parse(rd["TP"] + "");
                        TL += int.Parse(rd["TL"] + "");
                        TT += int.Parse(rd["TT"] + "");
                        Credit_load.Add((TP / 2) + (TT / 2) + (TL) + "");
                        Domain_List.Add(rd["Course_Domain"] + "");
                        Course_Code = rd["Course_Code"] + "";
                        Section = rd["Section_Number"] + "";
                        Group_Label_v = rd["Group_Label"] + "";
                        Total_Load.Add(TP + TL + TT);
                        Course_Code_List.Add(Course_Code);
                        Section_List.Add(Section);
                        Group_Label.Add(Group_Label_v);
                        Course_Title.Add(rd["Course_Title"] + "");


                    }
                    catch (Exception ex)
                    {
                        // s += +TL + "-" + TT + "-" + TP + "-" + rd["Course_Domain"];
                        //s += ex.Message + "ISttt";
                        //ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('UID is Not Found!!'" + ex.Message + "'')", true);
                    }
                }
                rd.Close();
                con.Close();
                //s += "<li>"+Course_Code+"</li>";
                //cmd1
                con.Open();

                for (int i = 0; i < Domain_List.Count; i++)
                {

                    try
                    {



                        cmd1 = con.CreateCommand();
                        cmd1.Connection = con;
                        cmd1.CommandText = "SELECT * FROM teacher_precedence WHERE Course_Domain='" + Domain_List[i].ToString() + "'";
                        MySqlDataReader rd1 = null;

                        rd1 = cmd1.ExecuteReader();

                        while (rd1.Read())
                        {
                            try
                            {
                                Teacher_name = rd1["Teacher_Name"] + "";
                                UID = rd1["Uid"] + "";
                                // s = UID;
                                //  s = "<li>" + UID + ":" + Teacher_name + "-" + Course_Code_List[i].ToString() + "-Section:" + Section_List[i].ToString() + "</li>";
                                //ph.Controls.Add(new LiteralControl(s));
                                UID_Filter.Add(UID);
                                Course_Code_Filter.Add(Course_Code_List[i]);
                                Section_Filter.Add(Section_List[i]);
                                Teacher_Name_Filter.Add(Teacher_name);
                                Total_Load_Filter.Add(Total_Load[i]);
                                Group_Label_Filter.Add(Group_Label[i]);
                                Course_Title_Filter.Add(Course_Title[i]);
                                Credit_load_filter.Add(Credit_load[i]);
                                Domain_List_Filter.Add(Domain_List[i]);
                                //  s += Domain_List[i].ToString()+"$$";
                                //s += "<li>'" + Group_Label_Filter[i].ToString() + "----" + i + "'</li>";
                            }
                            catch (Exception ex)
                            {
                                s += ex.Message;
                            }
                            //ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('" + TP + "')", true);
                        }

                        cmd1.Dispose();
                        rd1.Close();

                    }
                    catch (Exception ex)
                    {
                        s = ex.Message + "--aprox";
                        // ScriptManager.RegisterClientScriptBlock(tm, tm.GetType(), "alertMessage", "alert('jjj" + ex.Message + "')", true);
                    }
                }

                con.Close();
                con.Open();
                for (int i = 0; i < UID_Filter.Count; i++)
                {
                    try
                    {
                        MySqlCommand cmd3;
                        cmd3 = con.CreateCommand();
                        cmd3.Connection = con;
                        cmd3.CommandText = "SELECT * FROM teacher_data WHERE Uid='" + UID_Filter[i] + "'AND No<'" + cond + "'";
                        MySqlDataReader rd3 = null;
                        rd3 = cmd3.ExecuteReader();
                        while (rd3.Read())
                        {
                            flag = 1;
                            Max_Load = int.Parse(rd3["Max_Load"] + "");
                            Allocated_Load = int.Parse(rd3["Allocated_Load"] + "");
                            Deducted_Load = int.Parse(rd3["Deducted_Load"] + "");
                            No = int.Parse(rd3["No"] + "");
                            Credit = float.Parse(rd3["Credit"] + "");
                        }
                        cmd3.Dispose();
                        rd3.Close();
                    }
                    catch (Exception ex)
                    {
                        s = ex.Message + "MYSELF";
                    }
                    //End Cmd3
                    try
                    {
                        con4.Close();
                        con4.Open();
                        MySqlCommand cmd4;
                        cmd4 = con4.CreateCommand();
                        cmd4.Connection = con4;
                        cmd4.CommandText = "SELECT * FROM teacher_load WHERE Section_Name='" + Section_Filter[i].ToString() + "' AND Course_Code='" + Course_Code_Filter[i].ToString() + "'  AND Course_Title='" + Course_Title_Filter[i].ToString() + "' ";
                        MySqlDataReader rd3 = null;
                        rd3 = cmd4.ExecuteReader();
                        while (rd3.Read())
                        {
                            flag = 0;
                            /*  if (Group_Label_Filter[i].ToString().Equals("1") || Group_Label_Filter[i].ToString().Equals("2"))
                              {
                                  flag = 1;
                              }*/
                            //  s += "<li>=========='" + Group_Label_Filter[i].ToString().Substring((Group_Label_Filter[i].ToString().Length)-4, Group_Label_Filter[i].ToString().Length) + "'========</li>";

                        }
                        cmd4.Dispose();
                        rd3.Close();
                    }
                    catch (Exception ex)
                    {
                        s = ex.Message + "MYSELF";
                    }

                    if ((Allocated_Load + Deducted_Load) < Max_Load && flag == 1)
                    {
                        //  s += "<li>'" + UID_Filter[i].ToString() + Course_Code_Filter[i].ToString() + "@" + "----" + i + "#" + Domain_List_Filter[i].ToString() + "'</li>";

                        flag = 0;
                        int load = 0;
                        try
                        {
                            load = int.Parse(Total_Load_Filter[i].ToString());
                            Credit = Credit + float.Parse(Credit_load_filter[i].ToString());
                            //s += "<li>" +  load + "</li>";

                        }
                        catch (Exception ex)
                        {
                        }
                        if (load <= (Max_Load - (Allocated_Load + Deducted_Load)))
                        {   //Cmd2
                            try
                            {
                                // s += "<li>" + UID_Filter[i] + "-" + Section_Filter[i] +"-"+load+"</li>";
                                hash = rand.Next(0, int.Parse(UID_Filter[i].ToString()));
                                con2.Close();
                                con2.Open();
                                MySqlCommand cmd2;
                                cmd2 = con2.CreateCommand();
                                cmd2.Connection = con2;
                                cmd2.CommandText = "UPDATE  load_table SET Feculty_Name='" + Teacher_Name_Filter[i].ToString() + "',UID='" + UID_Filter[i].ToString() + "',Hash_Code='" + UID_Filter[i].ToString() + "" + hash + "' WHERE Course_Code='" + Course_Code_Filter[i].ToString() + "' AND Section_Number='" + Section_Filter[i].ToString() + "' AND Course_Title='" + Course_Title_Filter[i].ToString() + "' AND Course_Domain='" + Domain_List_Filter[i].ToString() + "' AND Group_Label!='5'";
                                cmd2.ExecuteNonQuery();
                                con2.Close();
                                //End cmd2
                            }
                            catch (Exception ex)
                            {
                                s = ex.Message + "cmd2";
                            }
                            //Cmd4
                            try
                            {
                                con4.Close();
                                con4.Open();
                                MySqlCommand cmd4;
                                cmd4 = con4.CreateCommand();
                                cmd4.Connection = con4;
                                cmd4.CommandText = "UPDATE teacher_data SET Allocated_Load='" + (Allocated_Load + load) + "" + "',No='" + (No + 1) + "', Credit='" + Credit + "', Con='" + (Allocated_Load + load) + "" + "',Hash_Code='" + UID_Filter[i].ToString() + "" + hash + "' WHERE Uid='" + UID_Filter[i].ToString() + "'";
                                cmd4.ExecuteNonQuery();
                                con4.Close();
                                //End Cmd4
                            }
                            catch (Exception ex)
                            {
                                s = ex.Message + "sss";
                            }
                            try
                            {
                                con2.Close();
                                con2.Open();
                                MySqlCommand cmd2;
                                cmd2 = con2.CreateCommand();
                                cmd2.Connection = con2;
                                cmd2.CommandText = "INSERT INTO teacher_load (Uid,Teacher_Name,Max_Load,Allocated_Load,Deducted_Load,Section_Name,Course_Code,Course_Title,Hash_Code) VALUES('" + UID_Filter[i] + "','" + Teacher_Name_Filter[i] + "','" + Max_Load + "','" + load + "','" + 0 + "','" + Section_Filter[i].ToString() + "','" + Course_Code_Filter[i].ToString() + "','" + Course_Title_Filter[i].ToString() + "','" + UID_Filter[i].ToString() + "" + hash + "')";
                                cmd2.ExecuteNonQuery();
                                con2.Close();
                                //End Cmd4
                            }
                            catch (Exception ex)
                            {
                                s = ex.Message;
                            }


                            s += "<tr><td>" + UID_Filter[i].ToString() + "</td><td>" + Teacher_Name_Filter[i].ToString() + "</td><td>" + Course_Code_Filter[i].ToString() + "</td><td>" + Course_Title_Filter[i].ToString() + "</td><td>" + Section_Filter[i].ToString() + "</td></tr>";
                        }
                    }
                    //End Cmd1
                }
                s += "</table>";


                //s += "<li>'"+Course_Code+"'->'"+UID+":"+Teacher_name+"'-->Allocated_Load-->'"+Allocated_Load+"'</li>";
                for (int i = 0; i < Course_Code_Filter.Count; i++)
                {
                    // s += "<li>" + Course_Code_Filter[i] +"-"+Teacher_Name_Filter[i]+"-"+UID_Filter[i]+"-"+Total_Load_Filter[i]+ "-" + Section_Filter[i] + "--" + Total_Load[i] + "</li>";
                }
                // Console.WriteLine(s);
                ph.Controls.Add(new LiteralControl(s));

                ScriptManager.RegisterStartupScript(up, up.GetType(), "", "showpop();", true);

                //Connection Closing
                con1.Close();
                con2.Close();
                con3.Close();
                con4.Close();
                //End
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
                cmd.CommandText = "Select DISTINCT Course_Domain From load_table WHERE UID=''";
                MySqlDataReader rd = null;
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                //ap.Fill(ds);


                cmd.Connection = con;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd["Course_Domain"].ToString() != "") ;
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
    }   
}




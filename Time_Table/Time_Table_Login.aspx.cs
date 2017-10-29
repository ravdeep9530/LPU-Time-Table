using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Time_Table
{
    public partial class Time_Table_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_val(object s, EventArgs e)
        {
            try
            {
                if (new DatabaseConn().check_val(uid.Text, pass.Text) == 1)
                {
                    Session["uid"] = uid.Text;
                    Response.Redirect("Time_table_manager.aspx");
                }
                else
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('Username/Password is Incorrect!!');", true);

            }catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('"+ex.Message+"');", true);

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Time_Table
{
    public partial class Enter_UID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim() != "")
            {
                new DatabaseConn().Check_UID(this, TextBox1.Text.Trim());
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('Firstly Fill Suitable Fields!')", true);
            }
            


        }
    }
}
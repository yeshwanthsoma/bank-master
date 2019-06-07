using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string loginstatus = null;
        if (Session["Role"] != null)
        {
            string sessionstatus = Session["Role"].ToString();
            
            if (sessionstatus != null)
                loginstatus = "Logout";


        }
        else
        {
            loginstatus = "Login";
            
        }
        Button2.Text = loginstatus;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["Role"] != null)
        {
            if (Session["role"].Equals("Manager"))
            {
                Response.Redirect("ManagerMaster.aspx");
            }
            else
            {
                Response.Redirect("Customermaster.aspx");
            }
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("LoginPageMaster.aspx");
        
    }
}

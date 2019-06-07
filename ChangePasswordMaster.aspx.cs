using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _ChangePasswordMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();

        string res = obj.changePass(oldPassword.Text, newPassword1.Text, newPassword2.Text, Session["userId"].ToString());

        Result.Text = res;
    }
}
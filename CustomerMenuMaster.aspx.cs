using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _CustomerMenuMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        account.Text = Session["accountNo"].ToString();
    }

    protected void fundTransfer_Click(object sender, EventArgs e)
    {

        Session["type"] = "FundTransfer";
        Response.Redirect("FundTransferMaster.aspx");
    }

    protected void balanceEnquiry_Click(object sender, EventArgs e)
    {

        ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
        int balance = obj.balanceEnq(long.Parse(account.Text));
        Balance.Text = "Current account balance is " + balance.ToString();


    }

    protected void changePassword_Click(object sender, EventArgs e)
    {

        Response.Redirect("ChangePasswordMaster.aspx");

    }

    protected void miniStatement_Click(object sender, EventArgs e)
    {

        Response.Redirect("MiniStatementMaster.aspx");
    }
}
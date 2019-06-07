using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _ManagerMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("WithdrawMaster.aspx");






    }

    protected void Deposit_Click(object sender, EventArgs e)
    {
        Response.Redirect("DepositMaster.aspx");
    }

    protected void Customer_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageCustomerMaster.aspx");

    }

    protected void Account_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageAccountMaster.aspx");
    }
}
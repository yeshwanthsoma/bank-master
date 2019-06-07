using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _MiniStatementMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
        DataSet ds = obj.ministatement(long.Parse(Session["accountNo"].ToString()));

        Ministate.DataSource = ds;
        Ministate.DataBind();




    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _CustomStatementGridMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
        int acc = int.Parse(Session["accountNo"].ToString());
        DateTime start = DateTime.Parse(Session["startdate"].ToString());
        DateTime end = DateTime.Parse(Session["enddate"].ToString());

        DataSet ds = obj.customstatement(acc, start, end);

        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}
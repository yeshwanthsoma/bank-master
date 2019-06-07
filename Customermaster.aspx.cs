using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Customermaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            Role.Text = Session["role"].ToString();
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            string id = Session["userId"].ToString();
            //var v = obj.printInCust(id);
            //obj.
            //SqlDataReader dr = v;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R5QLBIQ\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
            con.Open();
            string sql = "prints";

            SqlCommand command = new SqlCommand(sql, con);
            SqlParameter param1 = new SqlParameter("@id", id);
            command.Parameters.Add(param1);



            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = command.ExecuteReader();

            GridView1.DataSource = dr;
            GridView1.DataBind();
        }
        else
        {
            Response.Redirect("LoginPageMaster.aspx");
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedRecord;
        int serialNum = Convert.ToInt32(Request.Form["RadioButton1"]);
        selectedRecord = serialNum.ToString();



        Session["accountNo"] = selectedRecord;
        Response.Redirect("Customer2.aspx");
        //Response.Write("<script>alert("+selectedRecord+")</script>");

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomStatementMaster.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string selectedRecord;
        int serialNum = Convert.ToInt32(Request.Form["RadioButton1"]);
        selectedRecord = serialNum.ToString();
        if (selectedRecord == "0")
        {

            ErrorMsg.Text = "Please select an account to edit!!";
            ErrorMsg.Visible = true;
        }

        else
        {
            Session["accountNo"] = selectedRecord;
            Response.Redirect("CustomerMenuMaster.aspx");
            //Response.Write("<script>alert("+selectedRecord+")</script>");
        }
    }
}
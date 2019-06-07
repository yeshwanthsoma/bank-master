using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ServiceReference1;
using System.Data.SqlClient;

public partial class _ManageCustomerMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        add.Visible =false;
        edit.Visible = false;
        delete.Visible = false;
    }

    protected void check_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
        if (custId.Text == "")
            Label2.Text = "Please Enter Customer ID";
        else
        {
           
           DataSet ds= sc.getSpecificCustomer(int.Parse(custId.Text));
            
            if (ds.Tables[0].Rows.Count == 0)
            {
                Label2.Text = "No Customers :(";
                result.DataSource = ds;
                result.DataBind();
                add.Visible = true;
                edit.Visible = false;
                delete.Visible = false;
            }
            else
            {
                Label2.Text = "Customer Already Exists!";

                result.DataSource = ds;
                result.DataBind();
                add.Visible = false;
                edit.Visible = true;
                delete.Visible = true;
            }
        }
    }


    protected void deleteCustomerBtn_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
        int customerID = int.Parse(custId.Text);
        int rows_affected = sc.deleteCustomer(customerID);
        if (rows_affected == 0)
        {
            Label2.Text = "Error while deleting customer";
        }
        else
        {
            Label2.Text = "Customer Deleted!";
        }
    }



    protected void showAllCustomersBtn_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
        DataSet ds = sc.showAll();
        if (ds.Tables[0].Rows.Count == 0)
        {
            Label2.Text = "No Customers :(";
            result.DataSource = ds;
            result.DataBind();
        }
        else
        {
            result.DataSource = ds;
            result.DataBind();
        }
    }

    protected void add_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCustomerMaster.aspx");
    }

    protected void edit_Click(object sender, EventArgs e)
    {
        Session["custId"] = custId.Text;
        Response.Redirect("UpdateCustomerMaster.aspx");
    }
}
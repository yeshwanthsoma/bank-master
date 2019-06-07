using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;


public partial class _ManageAccountMaster : System.Web.UI.Page
{
    //This variable i is used to determine which row number was selected when a radio button is clicked
    public int i;

    //Here we make all the fields used for add and edit account to be invisible 
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = "";
        AccountTypeLabel.Visible = false;
        AccountTypeTextBox.Visible = false;
        DateOfOpeneningLabel.Visible = false;
        DateOfOpeneningTextBox.Visible = false;
        StatusLabel.Visible = false;
        StatusTextBox.Visible = false;
        DateOfEditedLabel.Visible = false;
        DateOfEditedTextBox.Visible = false;
        ClosingDateLabel.Visible = false;
        ClosingDateTextBox.Visible = false;
        AmountLabel.Visible = false;
        AmountTextBox.Visible = false;
        DetailsSubmitButton.Visible = false;
        EditedDetailsSubmitButton.Visible = false;
        DeleteAccountButton.Visible = false;

    }


    /*This function takes customer Id entered in the text box and on clicking the button all available accounts for 
     the corresponding customer Id is displayed by recieving a DataSet and filling the GridView*/
    protected void SubmitButton_Click(object sender, EventArgs e)
    {

        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
        DataSet ds = sc.GetCustomerId(int.Parse(CustomerIdTextBox.Text));

        if (ds.Tables[0].Rows.Count == 0)
        {
            Label2.Text = "No Accounts available for the given customer id.Add a new Customer and come back";
            GridView1.DataSource = ds;
            GridView1.DataBind();


        }

        else
        {
            Label2.Text = "Accounts available are";
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }


    }

    /* AFter entering customer Id only, if manager/staff wants to add an account for the corresponding customer Id
      then this function makes all the required text boxes visible. It also sets system date by default in the
      date of opening and date of edited fields */
    protected void AddButton_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(CustomerIdTextBox.Text))
        {
            Label2.Text = "Please enter customer Id to add account";
        }

        //Making all the fields necessary visible
        else
        {
            AccountTypeLabel.Visible = true;
            AccountTypeTextBox.Visible = true;
            DateOfOpeneningLabel.Visible = true;
            DateOfOpeneningTextBox.Visible = true;
            StatusLabel.Visible = true;
            StatusTextBox.Visible = true;
            DateOfEditedLabel.Visible = true;
            DateOfEditedTextBox.Visible = true;
            ClosingDateLabel.Visible = true;
            ClosingDateTextBox.Visible = true;
            AmountLabel.Visible = true;
            AmountTextBox.Visible = true;
            DetailsSubmitButton.Visible = true;

            DateOfOpeneningTextBox.Text = DateTime.Today.ToString("dd-MM-yyyy");
            DateOfEditedTextBox.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }


    }

    /*This button is displayed at the end, when all text boxes are filled and the manager/staff wants to add the 
     all the values in the text boxes into the database */
    protected void DetailsSubmitButton_Click(object sender, EventArgs e)
    {
        bool returnValue;
        string[] Details = {CustomerIdTextBox.Text,
                            AccountTypeTextBox.Text,
                            DateTime.Today.ToString("dd-MM-yyyy"),
                            StatusTextBox.Text,
                            DateTime.Today.ToString("dd-MM-yyyy"),
                            ClosingDateTextBox.Text,
                            AmountTextBox.Text};

        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
        returnValue = sc.AddAccount(Details);

        if (returnValue)
        {
            Label2.Text = "Account Added successfully";

            //This is to display updated gridview after insertion
            DataSet ds = sc.GetCustomerId(int.Parse(CustomerIdTextBox.Text));
            if (ds.Tables[0].Rows.Count == 0)
            {
                Label2.Text = "No Accounts available";
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }

            else
            {
                Label2.Text = "Accounts available are";
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
        }

        else
        {
            Label2.Text = "Account not Added";
        }



    }

    /*This button is clicked after selecting one of the radio buttons. It checks which radio button is selected and
     then displays the corresponding text boxes forthe managers/staff to enter edited values. This function popualtes 
     the previous values first into the text boxes and then the manager/staff can change those values */
    protected void EditButton_Click(object sender, EventArgs e)
    {
        long selectedRecord;

        selectedRecord = GetSelectedRecord();

        if (selectedRecord == 0)
        {
            Label2.Text = "Please select an account to edit!!";
        }

        //Making all fields visible
        else
        {

            Label2.Text = selectedRecord + "";

            AccountTypeLabel.Visible = true;
            AccountTypeTextBox.Visible = true;
            DateOfOpeneningLabel.Visible = true;
            DateOfOpeneningTextBox.Visible = true;
            StatusLabel.Visible = true;
            StatusTextBox.Visible = true;
            DateOfEditedLabel.Visible = true;
            DateOfEditedTextBox.Visible = true;
            ClosingDateLabel.Visible = true;
            ClosingDateTextBox.Visible = true;
            AmountLabel.Visible = true;
            AmountTextBox.Visible = true;
            EditedDetailsSubmitButton.Visible = true;


            ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
            DataSet ds = sc.GetCustomerId(int.Parse(CustomerIdTextBox.Text));


            //This is to populate existing values into text boxes
            AccountTypeTextBox.Text = ds.Tables[0].Rows[i]["accountType"].ToString();
            DateOfOpeneningTextBox.Text = ds.Tables[0].Rows[i]["DateOfOpen"].ToString();
            StatusTextBox.Text = ds.Tables[0].Rows[i]["status"].ToString();
            DateOfEditedTextBox.Text = ds.Tables[0].Rows[i]["dateOfEdited"].ToString();
            ClosingDateTextBox.Text = ds.Tables[0].Rows[i]["ClosingDate"].ToString();
            AmountTextBox.Text = ds.Tables[0].Rows[i]["amount"].ToString();


        }

    }

    /*This button is pressed after all the edited values are entered and then they are updated in the database.
     The updated table is displayed again*/
    protected void EditedDetailsSubmitButton_Click(object sender, EventArgs e)
    {
        bool returnValue;
        Account editedAccount = new Account();

        editedAccount.customerId = int.Parse(CustomerIdTextBox.Text);
        editedAccount.accountType = AccountTypeTextBox.Text;
        editedAccount.DateOfOpen = DateOfOpeneningTextBox.Text;
        editedAccount.status = StatusTextBox.Text;
        editedAccount.dateOfEdited = DateTime.Today.ToString("dd-MM-yyyy");
        editedAccount.ClosingDate = ClosingDateTextBox.Text;
        editedAccount.amount = int.Parse(AmountTextBox.Text);
        editedAccount.accountNo = GetSelectedRecord();

        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();

        returnValue = sc.EditAccount(editedAccount);

        if (returnValue)
        {
            Label2.Text = "Account Edited successfully";
            DataSet ds = sc.GetCustomerId(int.Parse(CustomerIdTextBox.Text));

            //This if-else is to display the updated table to the manager/staff
            if (ds.Tables[0].Rows.Count == 0)
            {
                Label2.Text = "No Accounts available";
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }

            else
            {
                Label2.Text = "Accounts available are";
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }


        }

        else
        {
            Label2.Text = "Account not edited!!";
        }

    }

    /*This button is clicked after manager/staff wants to delete one account when one if the radio buttons
    is selected. This method then makes the confirm deletion button visible if one radio button is selected */

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        long selectedRecord;

        selectedRecord = GetSelectedRecord();

        if (selectedRecord == 0)
        {
            Label2.Text = "Please select an account to delte!!";
        }

        else
        {
            DeleteAccountButton.Visible = true;
        }

    }


    /*This is the confirm deletion button which actually deletes the row in the database and displays 
      the updated table*/
    protected void DeleteAccountButton_Click(object sender, EventArgs e)
    {
        bool returnValue;
        long accountToBeDeleted = GetSelectedRecord();
        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
        returnValue = sc.DeleteAccount(accountToBeDeleted);
        if (returnValue)
        {
            Label2.Text = "Account deleted successfully";
            DataSet ds = sc.GetCustomerId(int.Parse(CustomerIdTextBox.Text));

            //This if-else displays the updated table after deletion

            if (ds.Tables[0].Rows.Count == 0)
            {
                Label2.Text = "No Accounts available";
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }

            else
            {
                Label2.Text = "Accounts available are";
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }

        }

        else
        {
            Label2.Text = "Account not deleted!!";
        }


    }

    /*This method is called whenever we need to check which radio button is selected and returns the account number
     of the selected row */
    private long GetSelectedRecord()
    {
        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();

        for (i = 0; i < GridView1.Rows.Count; i++)
        {
            RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("RadioButton1");
            if (rb != null)
            {
                if (rb.Checked)
                {

                    DataSet ds = sc.GetCustomerId(int.Parse(CustomerIdTextBox.Text));

                    //Returning the account number of selected row
                    return (long)ds.Tables[0].Rows[i]["accountNo"];
                }
            }
        }

        return 0;
    }





}
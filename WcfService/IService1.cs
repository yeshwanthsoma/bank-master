using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        string checkCre(string userId, string password);

        [OperationContract]
        SqlDataReader printInCust(string id);

        [OperationContract]
        long checkAcc(long acc1);

        [OperationContract]
        int checkAmo(long acc1);
        [OperationContract]
         void transferAdd(int amount, long acc);
        [OperationContract]
         void transferSub(int amount, long acc);
        [OperationContract]
        void insTrans(long acc1, long acc2, int amt, string type, string comment);
        [OperationContract]
        int balanceEnq(long acc);
        [OperationContract]
        string changePass(string old, string new1, string new2, string uid);
        [OperationContract]
        DataSet ministatement(long acc);
        [OperationContract]
        DataSet customstatement(int acc, DateTime start, DateTime end);
        [OperationContract]
        string withdraw(long acc, int amt);
        [OperationContract]
        string deposit(long acc, int amt);
        [OperationContract]
        DataSet GetCustomerId(int customerEnteredId);

        [OperationContract]
        bool AddAccount(string[] d);

        [OperationContract]
        bool EditAccount(Account a);

        [OperationContract]
        bool DeleteAccount(long accountNoToDelete);
        [OperationContract]
        int addCustomer(customer customer);

        [OperationContract]
        DataSet getSpecificCustomer(int custId );

        [OperationContract]
        int deleteCustomer(int custId);

        [OperationContract]
        int updateCustomer(customer customer);

        [OperationContract]
        int addLogin(string userId, string password, string userType);

        [OperationContract]
        DataSet showAll();

        [OperationContract]
        int updateUserId(string newUserID, string oldUserID);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    

    [DataContract]
    public class Account
    {
        [DataMember]
        public long accountNo { get; set; }

        [DataMember]
        public int customerId { get; set; }

        [DataMember]
        public string accountType { get; set; }

        [DataMember]
        public string DateOfOpen { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string dateOfEdited { get; set; }

        [DataMember]
        public string ClosingDate { get; set; }

        [DataMember]
        public int amount { get; set; }

    }

    [DataContract]
    public class customer
    {
        int customerID;
        string customerName;
        char gender;
        string dob;
        string address;
        string state;
        string city;
        string pincode;
        string phoneNo;
        string email;
        string createdDate;
        string editedDate;
        string userID;
        [DataMember]
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        [DataMember]
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        [DataMember]
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        [DataMember]
        public string Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public string Pincode
        {
            get { return pincode; }
            set { pincode = value; }
        }

        [DataMember]
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        [DataMember]
        public string EditedDate
        {
            get { return editedDate; }
            set { editedDate = value; }
        }

        [DataMember]
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
    }





}

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.master" AutoEventWireup="true" CodeFile="ManageAccountMaster.aspx.cs" Inherits="_ManageAccountMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <script type = "text/javascript">

     function RadioCheck(rb) {

        var gv = document.getElementById("<%=GridView1.ClientID%>");
        var rbs = gv.getElementsByTagName("input");
        var row = rb.parentNode.parentNode;
        for (var i = 0; i < rbs.length; i++) {
            if (rbs[i].type == "radio") {
                if (rbs[i].checked && rbs[i] != rb)
                {
                    rbs[i].checked = false;
                    break;
                }
            }
        }
    }    

</script>

    <asp:Label ID="Label1" runat="server" Text="Customer Id"></asp:Label>
        <asp:TextBox ID="CustomerIdTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        <br />
        <br />

        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server">

            <Columns>

            <asp:TemplateField>

            <ItemTemplate>

            <asp:RadioButton ID="RadioButton1" runat="server"  onclick = "RadioCheck(this);"/>

   <%-- <asp:HiddenField ID="HiddenField1" runat="server"

        Value = '<%#Eval("CustomerID")%>' />--%>

            </ItemTemplate>

            </asp:TemplateField>


            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />

        <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" />
        &nbsp;
        <asp:Button ID="EditButton" runat="server" Text="Edit" OnClick="EditButton_Click" />
        &nbsp;
        <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" />

        <asp:Button ID="DeleteAccountButton" runat="server" Text="Click to confirm Deletion" OnClick="DeleteAccountButton_Click" />
        
        <br />
        <br />

        
        <pre>
        <asp:Label ID="AccountTypeLabel" runat="server" Text="Account Type"></asp:Label>
        <asp:TextBox ID="AccountTypeTextBox" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="DateOfOpeneningLabel" runat="server" Text="DateOfOpenening"></asp:Label>
        <asp:TextBox ID="DateOfOpeneningTextBox" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="StatusLabel" runat="server" Text="Status"></asp:Label>
        <asp:TextBox ID="StatusTextBox" runat="server" ></asp:TextBox>
        <br />

        <asp:Label ID="DateOfEditedLabel" runat="server" Text="DateOfEdited"></asp:Label>
        <asp:TextBox ID="DateOfEditedTextBox" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="ClosingDateLabel" runat="server" Text="ClosingDate"></asp:Label>
        <asp:TextBox ID="ClosingDateTextBox" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="AmountLabel" runat="server" Text="Amount"></asp:Label>
        <asp:TextBox ID="AmountTextBox" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="DetailsSubmitButton" runat="server" Text="Submit Details" OnClick="DetailsSubmitButton_Click" />
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        
       
        <asp:Button ID="EditedDetailsSubmitButton" runat="server" Text="Submit Edited Details" OnClick="EditedDetailsSubmitButton_Click" />
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        </pre>
        <pre>
&nbsp;</pre>
        <pre>

        
        </pre>
        <pre>
&nbsp;</pre>
        <pre>

        
        <br/>
        </pre>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cust-form3.aspx.cs" Inherits="Customer_form.Cust_form3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .gridCSS, .gridCSS th, .gridCSS td {
            border-style: solid;
            border-color: inherit;
            border-width: 2px;
            outline: 1px solid;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial;">
            <h1 style="text-align: center; text-decoration: underline; color: midnightblue;">Customer Form</h1>
            <div style="margin: 20px 0px 15px 80px">
                <asp:TextBox ID="name" runat="server" Style="height: 40px; border: 2px solid; outline: 1px solid;" Width="300px" placeholder="Full Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvname" ControlToValidate="name" runat="server" ErrorMessage="Please enter a name" Text="*" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>

                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Company" runat="server" Style="height: 40px; border: 2px solid; outline: 1px solid;" Width="300px" placeholder="Company"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvcompany" ControlToValidate="Company" runat="server" ErrorMessage="Please enter an organisation" Text="*" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>

            </div>
            <div style="margin: 20px 0px 15px 80px">
                <asp:TextBox ID="Email" runat="server" Style="height: 40px; border: 2px solid; outline: 1px solid;" Width="300px" placeholder="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvemail" ControlToValidate="Email" runat="server" ErrorMessage="Please enter a valid Email ID" Text="*" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>

                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="Country" runat="server" Style="height: 45px; border: 2px solid; outline: 1px solid;" Width="308px">
                    <asp:ListItem Value="0">Country</asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>USA</asp:ListItem>
                    <asp:ListItem>UK</asp:ListItem>
                    <asp:ListItem>Australia</asp:ListItem>
                    <asp:ListItem>Indonesia</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvcountry" ControlToValidate="Country" InitialValue="0" runat="server" ErrorMessage="Please select a Country" Text="*" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>

            </div>
            

            <div style="margin: 20px 0px 0px 80px">
                <asp:Button ID="Button1" runat="server" Text="Add Customer" BorderColor="#FF9900" ForeColor="#FF9900" Style="margin-left: 0px; height: 30px;" OnClick="Button1_Click" ValidationGroup="g1"/>
                <br />
      <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="Red" ValidationGroup="g1" />

                <br />
                <asp:TextBox ID="Search" runat="server" placeholder="Type here to search" Style="margin-left: 0px; height: 25px; border: 2px solid; outline: 1px solid;" Width="225px" BorderStyle="Solid"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Search" Style="height: 30px" BorderColor="#FF9900" ForeColor="#FF9900" OnClick="Button2_Click" />
            </div>
            <br />
            <br />
            <div style="margin: 0px 80px 0px 80px;">
                <asp:GridView ID="GridView1" runat="server" CssClass="gridCSS" AutoGenerateColumns="False" DataKeyNames="rollno" Style="border-style: solid; border-color: inherit; border-width: 2px; margin: auto; outline: 1px solid; text-align: center;" Width="100%" OnRowCommand="GridView1_RowCommand" EnableViewState="False" OnRowDataBound="GridView1_RowDataBound" ShowHeaderWhenEmpty="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Full Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Width="100px" Style="text-align: center" Text='<%# Eval("Full_Name") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfveditname" ControlToValidate="TextBox1" Text="*" ForeColor="Red" runat="server" ErrorMessage="Please enter a name"></asp:RequiredFieldValidator>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" ForeColor="#000099" Style="text-align: center" Text='<%# Eval("Full_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Width="100px" Style="text-align: center" Text='<%# Eval("Company") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfveditcompany" ControlToValidate="TextBox2" Text="*" ForeColor="Red" runat="server" ErrorMessage="Please enter an organization"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" ForeColor="#000099" Text='<%# Eval("Company") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Eval("Country") %>' Width="145px" Style="text-align: center">
                                    <asp:ListItem Value="0">Country</asp:ListItem>
                                    <asp:ListItem>India</asp:ListItem>
                                    <asp:ListItem>USA</asp:ListItem>
                                    <asp:ListItem>UK</asp:ListItem>
                                    <asp:ListItem>Australia</asp:ListItem>
                                    <asp:ListItem>Indonesia</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfveditcountry" ControlToValidate="DropDownList1" InitialValue="0" Text="*" ForeColor="Red" runat="server" ErrorMessage="Please select a country"></asp:RequiredFieldValidator>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" ForeColor="#000099" Style="text-align: center" Text='<%# Eval("Country") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Width="100px" Text='<%# Eval("Email") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfveditemail" ControlToValidate="TextBox3" Text="*" ForeColor="Red" runat="server" ErrorMessage="Please enter a valid Email ID"></asp:RequiredFieldValidator>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" ForeColor="#000099" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("rollno") %>' CommandName="UpdateRow">Update</asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="CancelRow" CausesValidation="false">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="EditRow">Edit</asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("rollno") %>' CommandName="DeleteRow">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridView2" CssClass="gridCSS" runat="server" AutoGenerateColumns="False" Style="border-style: solid; border-color: inherit; border-width: 2px; margin: auto; outline: 1px solid; text-align: center;" Width="100%" OnRowDataBound="GridView2_RowDataBound" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                        <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                        <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                        <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                        <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                    </Columns>

                </asp:GridView>
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" />
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Customer-InfoConnectionString %>" DeleteCommand="DELETE FROM [CUSTOMERS] WHERE [rollno] = @rollno" InsertCommand="INSERT INTO [CUSTOMERS] ([Full_Name], [Company], [Country], [Email]) VALUES (@Full_Name, @Company, @Country, @Email)" SelectCommand="SELECT * FROM [CUSTOMERS]" UpdateCommand="UPDATE [CUSTOMERS] SET [Full_Name] = @Full_Name, [Company] = @Company, [Country] = @Country, [Email] = @Email WHERE [rollno] = @rollno">
            <DeleteParameters>
                <asp:Parameter Name="rollno" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Full_Name" Type="String" />
                <asp:Parameter Name="Company" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Full_Name" Type="String" />
                <asp:Parameter Name="Company" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="rollno" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>

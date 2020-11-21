<%@ Page Language="C#" Trace="false" AutoEventWireup="true" CodeBehind="Cust-form.aspx.cs" Inherits="Customer_form.Cust_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .gridCSS, .gridCSS th, .gridCSS td
{
    border:2px solid;
    outline:1px solid;
    height:30px;
    text-align:center;
   
}
    
</style>
</head>

<body>
    
    <form id="form1" runat="server">
        <div style="font-family:Arial">
            
            <h1 style="text-align:center; text-decoration:underline; color:midnightblue;">Customer Form</h1>
            <div style="margin:20px 0px 15px 80px">
                
                <asp:TextBox ID="name" style="height:40px; border:2px solid; outline:1px solid;" Width="300px" placeholder="Full Name" runat="server" BorderStyle="Solid"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvname" ControlToVAlidate="name" runat="server" ErrorMessage="Please enter a name" Text="*" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="company" style="height:40px; border:2px solid; outline:1px solid;" Width="300px" placeholder="Company" runat="server" BorderStyle="Solid"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvcompany" ControlToVAlidate="company" runat="server" ErrorMessage="Please enter an organisation" Text="*" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>

            </div>
            <div style="margin:20px 0px 15px 80px">
                <asp:TextBox ID="email" style="height:40px; border:2px solid; outline:1px solid;" Width="300px" placeholder="Email ID" runat="server" BorderStyle="Solid"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvemail" ControlToVAlidate="email" runat="server" ErrorMessage="Please enter a valid Email ID" Text="*" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="Country" runat="server" style="height:45px; border:2px solid; outline:1px solid;" Width="308px">
                    <asp:ListItem Value="0">Country</asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>USA</asp:ListItem>
                    <asp:ListItem>UK</asp:ListItem>
                    <asp:ListItem>Australia</asp:ListItem>
                    <asp:ListItem>Indonesia</asp:ListItem>

                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvcountry" ControlToVAlidate="Country" InitialValue="0" runat="server" ErrorMessage="Please select a Country" Text="*" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>

            </div>
                <div style="margin:20px 0px 0px 80px">
                <asp:Button ID="Button1" runat="server" Text="Add Customer" OnClick="Button1_Click" BorderColor="#FF9900" ForeColor="#FF9900" style="margin-left: 0px; height:30px;" ValidationGroup="g1"></asp:Button>
                <br /><br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="g1" />
            <asp:TextBox ID="Search" runat="server" placeholder="Type name/company to search" style="margin-left: 0px; height:25px; border:2px solid; outline:1px solid;" Width="225px" BorderStyle="Solid"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" style="height:30px" BorderColor="#FF9900" ForeColor="#FF9900" Text="Search" OnClick="Button2_Click" />
                    </div>
            <br />
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div style="margin:0px 80px 0px 80px;">
                    <asp:Label ID="Searchmsg" runat="server"></asp:Label>
                    
                    <asp:GridView ID="GridView2" runat="server" CssClass="gridCSS" style="margin:auto; border:2px solid; outline:1px solid;" Width="100%" AutoGenerateColumns="False" DataKeyNames="rollno" BorderStyle="Solid" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Full Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Width="100px" style="text-align: center" Text='<%# Eval("Full_Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="Label6" runat="server" ForeColor="#000099" style="text-align: center" Text='<%# Eval("Full_Name") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Width="100px" style="text-align: center" Text='<%# Eval("Company") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="Label7" runat="server" ForeColor="#000099" style="text-align: center" Text='<%# Eval("Company") %>'></asp:Label>
                                </center>
                                        </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList2" runat="server" Width="145px" SelectedValue='<%# Eval("Country") %>'>
                                        <asp:ListItem Value="0">Country</asp:ListItem>
                                        <asp:ListItem>India</asp:ListItem>
                                        <asp:ListItem>USA</asp:ListItem>
                                        <asp:ListItem>UK</asp:ListItem>
                                        <asp:ListItem>Australia</asp:ListItem>
                                        <asp:ListItem>Indonesia</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" ForeColor="#000099" style="text-align: center" Text='<%# Eval("Country") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox9" runat="server" Width="100px" style="text-align: center" Text='<%# Eval("Email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" ForeColor="#000099" style="text-align: center" Text='<%# Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton7" runat="server" CommandArgument='<%# Eval("rollno") %>' CommandName="UpdateSearch">Update</asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton8" runat="server" CommandName="CancelSearch" CausesValidation="false">Cancel</asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton5" runat="server" CommandName="EditSearch">Edit</asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("rollno") %>' CommandName="DeleteSearch">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView4" runat="server" CssClass="gridCSS" style=" margin:auto; border:2px solid; outline:1px solid;" Width="100%" AutoGenerateColumns="false" ShowHeader="False">
                        <Columns>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                <asp:GridView ID="GridView1" CssClass="gridCSS" runat="server" style="margin:auto; border:2px solid; outline:1px solid;" Width="100%" AutoGenerateColumns="False" DataKeyNames="rollno" BorderStyle="Solid" PageSize="6" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    
                    <Columns>
                  
                        <asp:TemplateField HeaderText="Full Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Width="100px" style="text-align: center" Text='<%# Eval("Full_Name") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfveditname" ControlToValidate="TextBox5" Text="*" ForeColor="Red" runat="server" ErrorMessage="Please enter a name"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Full_Name") %>' ForeColor="#000099"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Width="100px" style="text-align: center" Text='<%# Eval("Company") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfveditcompany" ControlToValidate="TextBox2" Text="*" ForeColor="Red" runat="server" ErrorMessage="Please enter an organization"></asp:RequiredFieldValidator>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Company") %>' ForeColor="#000099"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="145px" SelectedValue='<%# Eval("Country") %>'>
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
                                <asp:Label ID="Label3" runat="server" style="text-align: center" Text='<%# Eval("Country") %>' ForeColor="#000099"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Width="100px" Text='<%# Eval("Email") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfveditemail" ControlToValidate="TextBox4" Text="*" ForeColor="Red" runat="server" ErrorMessage="Please enter a valid Email ID"></asp:RequiredFieldValidator>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Email") %>' ForeColor="#000099"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
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
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    
                  
            </asp:GridView>
                    <asp:GridView ID="GridView3" runat="server" CssClass="gridCSS" style=" margin:auto; border:2px solid; outline:1px solid;" Width="100%" AutoGenerateColumns="false" ShowHeader="False">
                        <Columns>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                            <asp:TemplateField ShowHeader="False"></asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red"/>
                    
                </div>
        </div>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Customer-InfoConnectionString %>" SelectCommand="SELECT [rollno], [Full_Name], [Company], [Country], [Email] FROM [CUSTOMERS]" DeleteCommand="DELETE FROM [CUSTOMERS] WHERE [rollno] = @rollno" InsertCommand="INSERT INTO [CUSTOMERS] ([Full_Name], [Company], [Country], [Email]) VALUES (@Full_Name, @Company, @Country, @Email)" UpdateCommand="UPDATE [CUSTOMERS] SET [Full_Name] = @Full_Name, [Company] = @Company, [Country] = @Country, [Email] = @Email WHERE [rollno] = @rollno">
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

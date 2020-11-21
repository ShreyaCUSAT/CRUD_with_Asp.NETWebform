using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Customer_form
{
    public partial class Cust_form3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=desktop-6jc2ojm\sqlexpress;Initial Catalog=Customer-Info;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from dbo.CUSTOMERS";
                con.Close();
                DataTable dt1 = new DataTable();
                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.Fill(dt1);
                ViewState["dataTBL"] = dt1;
                BindData();
                
                
                int count = dt1.Rows.Count;

               
                EnterToGrid(count);
            }
            else
            {
                BindData();
            }

        }
        protected void BindData()
        {
            
            GridView1.DataSource = (DataTable)ViewState["dataTBL"];
            GridView1.DataBind();
            GridView1.Visible = true;
            int count = ((DataTable)ViewState["dataTBL"]).Rows.Count;
            EnterToGrid(count);
        }
        protected void ClearTextBox(Control p)
        {
            foreach (Control ctrl in p.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;
                    if (t != null)
                    {
                        t.Text = string.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBox(ctrl);
                    }
                }
                if (ctrl is DropDownList)
                {
                    DropDownList ddl = ctrl as DropDownList;
                    if (ddl != null)
                    {
                        ddl.SelectedIndex = 0;
                    }
                }
            }
        }
        public void EnterToGrid(int count)
        {



            if (count < 6)
            {
                DataTable dt2 = new DataTable();
                int d = 6 - count;
                for (int i = 0; i < d; i++)
                {
                    DataRow dr1 = dt2.NewRow();
                    dt2.Rows.Add(dr1);

                }
                GridView2.DataSource = dt2;
                GridView2.DataBind();
                GridView2.Visible = true;

            }
            else
            {
                GridView2.Visible = false;
            }
        }

            protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "INSERT INTO CUSTOMERS VALUES('" + name.Text + "','" + Company.Text + "','" + Country.SelectedItem.Value + "','" + Email.Text + "')";

            cmd.ExecuteNonQuery();

            DataTable dt1 = new DataTable();
            SqlDataAdapter dad = new SqlDataAdapter("select *from CUSTOMERS", con);
            dad.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            GridView1.Visible = true;
            ViewState["dataTBL"] = dt1;
            ViewState["IfSearch"] = "";
            BindData();

            ClearTextBox(Page);
            con.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "EditRow")
            {

                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridView1.EditIndex = rowIndex;
                

               


            }
            else if (e.CommandName == "DeleteRow")
            {
                if (ViewState["IfSearch"] == null)
                {
                    CustomerDataAcessLayer.DeleteCustomer(Convert.ToInt32(e.CommandArgument));
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select *from dbo.CUSTOMERS";
                    con.Close();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.Fill(dt1);
                    ViewState["dataTBL"] = dt1;
                    GridView1.EditIndex = -1;
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    int count = dt1.Rows.Count;
                    EnterToGrid(count);
                }
                else
                {
                    CustomerDataAcessLayer.DeleteCustomer(Convert.ToInt32(e.CommandArgument));
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " SELECT * FROM [dbo].[CUSTOMERS] where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("Full_Name", ViewState["IfSearch"].ToString());
                    con.Close();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.Fill(dt1);
                    ViewState["dataTBL"] = dt1;
                    GridView1.EditIndex = -1;
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    int count = dt1.Rows.Count;
                    EnterToGrid(count);
                }
              
            }
            else if (e.CommandName == "CancelRow")
            {
                GridView1.EditIndex = -1;
                

               
            }
            else if (e.CommandName == "UpdateRow")
            {
                if (ViewState["IfSearch"] == null)
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                    int rollno = Convert.ToInt32(e.CommandArgument);
                    string Full_Name = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox1")).Text;
                    string Country = ((DropDownList)GridView1.Rows[rowIndex].FindControl("DropDownList1")).SelectedValue;
                    string Company = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox2")).Text;
                    string Email = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox3")).Text;

                    CustomerDataAcessLayer.UpdateCustomer(rollno, Full_Name, Company, Country, Email);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select *from dbo.CUSTOMERS";
                    con.Close();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.Fill(dt1);
                    ViewState["dataTBL"] = dt1;
                    GridView1.EditIndex = -1;
                    

                }
                else
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                    int rollno = Convert.ToInt32(e.CommandArgument);
                    string Full_Name = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox1")).Text;
                    string Country = ((DropDownList)GridView1.Rows[rowIndex].FindControl("DropDownList1")).SelectedValue;
                    string Company = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox2")).Text;
                    string Email = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox3")).Text;

                    CustomerDataAcessLayer.UpdateCustomer(rollno, Full_Name, Company, Country, Email);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [dbo].[CUSTOMERS] where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("Full_Name", ViewState["IfSearch"].ToString());
                    con.Close();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.Fill(dt1);
                    ViewState["dataTBL"] = dt1;
                    GridView1.EditIndex = -1;
                }

             
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " SELECT * FROM [dbo].[CUSTOMERS] where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("Full_Name", Search.Text);

            DataTable dt1 = new DataTable();
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            ViewState["dataTBL"] = dt1;
            ViewState["IfSearch"] = Search.Text;
            int count = dt1.Rows.Count;
            EnterToGrid(count);
            
            con.Close();
            ClearTextBox(Page);
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell mycell in e.Row.Cells)
            {
                mycell.Style.Add("word-break", "break-all");
                mycell.Width = 160;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell mycell in e.Row.Cells)
            {
                mycell.Style.Add("word-break", "break-all");
                mycell.Width = 160;
            }
        }
    }
}
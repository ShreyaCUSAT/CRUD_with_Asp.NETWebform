using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Customer_form
{
    public partial class Cust_form2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=desktop-6jc2ojm\sqlexpress;Initial Catalog=Customer-Info;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS";
                int count = 0;

                using (SqlCommand cmdCount = new SqlCommand(stmt, con))
                {
                    con.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from dbo.CUSTOMERS";
                con.Close();
                DataTable dt1 = new DataTable();
                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.Fill(dt1);

                GridView1.DataSource = dt1;
                GridView1.DataBind();
                EnterToGrid(count);
                //ViewState["SearchTB"] = "";
                //ViewState["dataTBL"] = dt1;
            }
            /*else
            {
                GridView1.DataSource = ViewState["dataTBL"];
                GridView1.DataBind();
                string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS";
                int count = 0;

                using (SqlCommand cmdCount = new SqlCommand(stmt, con))
                {
                    con.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    con.Close();
                }
                EnterToGrid(count);

            }*/

            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "INSERT INTO CUSTOMERS VALUES('" + name.Text + "','" + company.Text + "','" + Country.SelectedItem.Value + "','" + email.Text + "')";
           
            con.Close();
            DataTable dt1 = new DataTable();
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();

            ViewState["dataTBL"] = dt1;

            string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS";
            int count = 0;

            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();

            using (SqlCommand cmdCount = new SqlCommand(stmt, con))
            {
                con.Open();
                count = (int)cmdCount.ExecuteScalar();
                con.Close();
            }
           
            EnterToGrid(count);
            ClearTextBox(Page);
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
                GridView3.DataSource = dt2;
                GridView3.DataBind();

            }
            
            
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
            int count = 0;

            using (SqlCommand cmdCount = new SqlCommand(stmt, con))
            {
                con.Open();
                cmdCount.Parameters.AddWithValue("Full_Name", Search.Text);
                count = (int)cmdCount.ExecuteScalar();
                con.Close();
            }
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

            EnterToGrid(count);
            con.Close();
            ClearTextBox(Page);
            //ViewState["dataTBL"] = dt1;
            //ViewState["SearchTB"] = Search.Text;
          

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell mycell in e.Row.Cells)
            {
                mycell.Style.Add("word-break", "break-all");
                mycell.Width = 160;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridView1.EditIndex = rowIndex;
                string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS";
                int count = 0;

                using (SqlCommand cmdCount = new SqlCommand(stmt, con))
                {
                    con.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    con.Close();
                }
               
                EnterToGrid(count);

                
            }
            else if (e.CommandName == "DeleteRow")
            {
                CustomerDataAcessLayer.DeleteCustomer(Convert.ToInt32(e.CommandArgument));
                string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS";
                int count = 0;

                using (SqlCommand cmdCount = new SqlCommand(stmt, con))
                {
                    con.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    con.Close();
                }
                EnterToGrid(count);
            }
            else if (e.CommandName == "CancelRow")
            {
                GridView1.EditIndex = -1;
                string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS";
                int count = 0;

                using (SqlCommand cmdCount = new SqlCommand(stmt, con))
                {
                    con.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    con.Close();
                }
                EnterToGrid(count);
            }
            else if (e.CommandName == "UpdateRow")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                int rollno = Convert.ToInt32(e.CommandArgument);
                string Full_Name = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox5")).Text;
                string Country = ((DropDownList)GridView1.Rows[rowIndex].FindControl("DropDownList1")).SelectedValue;
                string Company = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox2")).Text;
                string Email = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox4")).Text;

                CustomerDataAcessLayer.UpdateCustomer(rollno, Full_Name, Company, Country, Email);

                GridView1.EditIndex = -1;
                string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS";
                int count = 0;

                using (SqlCommand cmdCount = new SqlCommand(stmt, con))
                {
                    con.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    con.Close();
                }
                EnterToGrid(count);
            }
        }
    }
}
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

    public partial class Cust_form : System.Web.UI.Page
    {
        //int flagSearch;
        private string SearchText;
        private bool flag;
        SqlConnection con = new SqlConnection(@"Data Source=desktop-6jc2ojm\sqlexpress;Initial Catalog=Customer-Info;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {

            //GridView2.Visible = true;
            //GridView4.Visible = false;

            //GridView1.Attributes.Add("style", "word-break:break-all; word-warp:break-word");
            
            
           
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
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
                EnterToGrid(count);
                ViewState["SerachTB"] = "";
                ViewState["datatbl"] = null;
            }
            if (ViewState["SearchTB"] != null)
            {
                GridView2.Visible = true;
                GridView2.DataSource = (DataTable)ViewState["datatbl"];
                GridView2.DataBind();
            }
            else
            {
                GridView1.Visible = true;
                GridView1.DataSource = (DataTable)ViewState["datatbl"];
                GridView1.DataBind();
            }
           


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //e.Command.CommandTimeout = 60;
            

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           
            cmd.CommandText = "INSERT INTO CUSTOMERS VALUES('" + name.Text + "','" + company.Text + "','" + Country.SelectedItem.Value + "','" + email.Text + "')";
            //roll=Convert.ToInt32(cmd.ExecuteNonQuery());
            //cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt1 = new DataTable();
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            
            string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS";
            int count = 0;

            GridView1.DataSource=SqlDataSource1;
            GridView1.DataBind();

            using (SqlCommand cmdCount = new SqlCommand(stmt, con))
            {
                con.Open();
                count = (int)cmdCount.ExecuteScalar();
                con.Close();
            }
            //roll = roll + 1;
            EnterToGrid(count);
            ClearTextBox(Page);
            //ViewState["SearchTB"] = "";
            ViewState["datatbl"] = dt1;
           
        }
        public void EnterToGrid(int count)
        {
           

         
            if (count < 6)
            {
                DataTable dt2 = new DataTable();
                int d = 6 - count;
                for (int i = 0; i <d; i++)
                {
                    DataRow dr1 = dt2.NewRow();
                    
                    //dr["Actions"] = string.Empty;
                    dt2.Rows.Add(dr1);
                    //LinkButton LinkButton1 = new LinkButton();
                    //LinkButton1.Visible = false;
                    //(LinkButton)row.Cells[15] = false;
                    //LinkButton2.Visible = false;

                }
                GridView3.DataSource = dt2;
                GridView3.DataBind();

            }
            GridView1.Visible = true;
            GridView3.Visible = true;
            GridView2.Visible = false;
            GridView4.Visible = false;
        }
        public void EnterAfterSearch(int count)
        {
            //DataTable dt = new DataTable();


            /*if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " SELECT * FROM [dbo].[CUSTOMERS] where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("Full_Name", SearchText);
            cmd.ExecuteNonQuery();

            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);

           // GridView1.DataSource = CustomerDataAcessLayer.GetallCustomer();*/
            //GridView2.DataSource = data;
            //GridView2.DataBind();
            //con.Close();


            if (count < 6)
            {
                DataTable dt2 = new DataTable();
                int d = 6 - count;
                for (int i = 0; i < d; i++)
                {
                    DataRow dr1 = dt2.NewRow();

                    //dr["Actions"] = string.Empty;
                    dt2.Rows.Add(dr1);
                    //LinkButton LinkButton1 = new LinkButton();
                    //LinkButton1.Visible = false;
                    //(LinkButton)row.Cells[15] = false;
                    //LinkButton2.Visible = false;

                }
                GridView4.DataSource = dt2;
                GridView4.DataBind();

            }
            GridView1.Visible = false;
            GridView3.Visible = false;
            GridView2.Visible = true;
            GridView4.Visible = true;
        }


        /*protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = SqlDataSource1;
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
            
            //GridView1.EditRowStyle.BackColor = System.Drawing.Color.Grey;
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
            GridView1.EditIndex = -1;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
           /
            
            if (con.State == ConnectionState.Closed)
                con.Open();
            string query = "UPDATE CUSTOMERS SET Full_Name=@Full_Name, Company=@Company, Country=@Country, Email=@Email WHERE rollno=@rollno";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //int rowid = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            //int roll = Convert.ToInt32(GridView1.DataKeys[rowid].Values[0]);
            //int roll = Convert.ToInt32(hfrollno.Value);
            //int roll = (int)GridView1.DataKeys[row.RowIndex].Values["rollno"];
            cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
            cmd.Parameters.AddWithValue("@Full_Name", (GridView1.Rows[e.RowIndex].FindControl("TextBox5") as TextBox).Text);
            cmd.Parameters.AddWithValue("@Company", (GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text);
            cmd.Parameters.AddWithValue("@Country", (GridView1.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList).SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Email", (GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox).Text);
            cmd.ExecuteNonQuery();
            
            GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("DeleteRecord", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
            cmd.ExecuteNonQuery();
            //GridView1.EditIndex = -1;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            con.Close();
        }*/

        protected void Button2_Click(object sender, EventArgs e)
        {
            //flagSearch = 1;
            SearchText = Search.Text;
            string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
            int count = 0;

            using (SqlCommand cmdCount = new SqlCommand(stmt, con))
            {
                con.Open();
                cmdCount.Parameters.AddWithValue("Full_Name", SearchText);
                count = (int)cmdCount.ExecuteScalar();
                con.Close();
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " SELECT * FROM [dbo].[CUSTOMERS] where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("Full_Name", SearchText);

            DataTable dt1 = new DataTable();
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();

            EnterToGrid(count);
            con.Close();
            ClearTextBox(Page);
            //ViewState["SearchTB"] = Search.Text;
            //ViewState["datatbl"]=dt1;

            //Searchmsg.Text = "Search Results...";




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
                if(ctrl is DropDownList)
                {
                    DropDownList ddl = ctrl as DropDownList;
                    if (ddl != null)
                    {
                        ddl.SelectedIndex = 0;
                    }
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            {
                if (e.CommandName == "EditRow")
                {
                    //GridView1.Visible = true;
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
                    //GridView1.DataBind();
                        EnterToGrid(count);
                    
                    /*if(flagSearch==1 )
                    {
                        int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                        GridView1.EditIndex = rowIndex;
                        string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
                        int count = 0;

                        using (SqlCommand cmdCount = new SqlCommand(stmt, con))
                        {
                            con.Open();
                            cmdCount.Parameters.AddWithValue("Full_Name", SearchText);
                            count = (int)cmdCount.ExecuteScalar();
                            con.Close();
                        }
                        EnterAfterSearch(count);
                    }*/
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell mycell in e.Row.Cells)
            {
                mycell.Style.Add("word-break", "break-all");
                mycell.Width=160;
            }
        }

       protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            {
                if (e.CommandName == "EditSearch")
                {

                    // Response.Write(SearchText);

                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridView2.EditIndex = rowIndex;
                    string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
                    int count = 0;

                    SqlCommand cmdCount = new SqlCommand(stmt, con);
                    con.Open();
                            cmdCount.Parameters.AddWithValue("Full_Name", ViewState["SearchTB"]);
                            count = (int)cmdCount.ExecuteScalar();
                            con.Close();
                   

                    EnterAfterSearch(count);
                    
                    ViewState["editbtn"] = true;

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
                else if (e.CommandName == "CancelSearch")
                {
                    GridView2.EditIndex = -1;
                    string stmt = "SELECT COUNT(*) FROM dbo.CUSTOMERS where Full_Name like '%'+@Full_Name+'%' OR Company like '%'+@Full_Name+'%'";
                    int count = 0;

                    SqlCommand cmdCount = new SqlCommand(stmt, con);
                    con.Open();
                    cmdCount.Parameters.AddWithValue("Full_Name", ViewState["SearchTB"]);
                    count = (int)cmdCount.ExecuteScalar();
                    con.Close();


                    EnterAfterSearch(count);
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

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell mycell in e.Row.Cells)
            {
                mycell.Style.Add("word-break", "break-all");
                mycell.Width = 160;
            }
        }
    }
}
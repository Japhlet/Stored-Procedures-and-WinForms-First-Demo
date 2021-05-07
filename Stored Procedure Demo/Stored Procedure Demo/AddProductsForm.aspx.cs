using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stored_Procedure_Demo
{
    public partial class AddProductsForm : System.Web.UI.Page
    {
        public static string connectionString = @"Data Source=DITLPT007\SQL2019; Initial Catalog=StoredProceduresTest; Persist Security Info=True;Integrated Security=true;";
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillGrid();
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtProductName == null || txtProductDescription == null || txtProductName.Text.ToString().Trim().Equals("") || 
                    txtProductDescription.Text.ToString().Trim().Equals("")) 
                {
                    InfoLabel.Text = "Please fill all the fields";
                } else
                {
                    con = new SqlConnection(connectionString);
                    cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();

                    cmd.CommandText = "sp_AddProducts";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.ToString());
                    cmd.Parameters.AddWithValue("@ProductDescription", txtProductDescription.Text.ToString());

                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(
                    new SqlCommand("SELECT ProductName, ProductDescription, OnDate FROM Product", con));

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    ProductDataGrid.DataSource = dt;
                    ProductDataGrid.DataBind();

                    adapter.Dispose();
                    con.Close();

                    InfoLabel.Text = "Product added successfully";

                    txtProductName.Text = "";
                    txtProductDescription.Text = ""; 
                }

            } catch (Exception ex)
            {
                InfoLabel.Text = "Error: " + ex.Message.ToString();
            }

        }

        public void FillGrid()
        {
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(
                    new SqlCommand("SELECT ProductName, ProductDescription, OnDate FROM Product", con)
                );

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ProductDataGrid.DataSource = dt;
                ProductDataGrid.DataBind();

                adapter.Dispose();
                con.Close();
            } catch(Exception ex)
            {

            }
        }
    }
}
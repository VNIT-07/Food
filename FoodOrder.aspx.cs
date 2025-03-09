using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace Food
{
    public partial class FoodOrder : System.Web.UI.Page
    {
        SqlConnection con;
        string strcon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FoodBind();
                Response.Write(Session["a"]);
            }

            BindGrid();
        }

        public void FoodBind()
        {
            con = new SqlConnection(strcon);
            string qry = "select * from Tbl_FoodItems";
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlFood.DataSource = ds;
            ddlFood.DataTextField = "FoodName";
            ddlFood.DataValueField = "Food_ID";
            ddlFood.DataBind();
            con.Close();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(strcon);
            string qry = "INSERT INTO Tbl_Orders(Food_ID, Quantity, Order_Date) VALUES (@Food_ID, @Quantity,@Order_Date)";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Food_ID", ddlFood.SelectedValue);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@Order_Date", txtDate.Text);
            con.Open();
            int a = Convert.ToInt16(cmd.ExecuteNonQuery());
            if (a > 0)
            {
                Response.Write("<script>alert('Order Placed Successfully');</script>");
                MessageBox.Show("hello");
            }
            else
            {
                Response.Write("<script>alert('Order Placed Failed');</script>");
            }
            con.Close();
            BindGrid();
        }

        public void BindGrid()
        {
            con = new SqlConnection(strcon);
            string qry = "SELECT Tbl_Orders.Order_ID, " +
                         "Tbl_FoodItems.FoodName, " +
                         "Tbl_FoodItems.Price, " +
                         "Tbl_Orders.Quantity, " +
                         "(Tbl_FoodItems.Price * Tbl_Orders.Quantity) AS TotalPrice, " +
                         "Tbl_Orders.Order_Date " +
                         "FROM Tbl_Orders " +
                         "INNER JOIN Tbl_FoodItems ON Tbl_Orders.Food_ID = Tbl_FoodItems.Food_ID";

            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();

            con.Open();
            sda.Fill(ds);
            con.Close();

            GVData.DataSource = ds;
            GVData.DataBind();
        }


        protected void GVData_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GVData.SelectedRow;
            ViewState["SelectedOrderID"] = row.Cells[1].Text;
            ddlFood.SelectedItem.Text = row.Cells[2].Text;
            txtQuantity.Text = row.Cells[4].Text;
            txtDate.Text = row.Cells[5].Text;

        }

        

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon); 
            string query = "UPDATE Tbl_Orders SET Food_ID = @Food_ID, Quantity = @Quantity, Order_Date = @Order_Date WHERE Order_ID = @Order_ID"; // SQL update query
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Food_ID", ddlFood.SelectedValue);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@Order_Date", txtDate.Text);
            cmd.Parameters.AddWithValue("@Order_ID", ViewState["SelectedOrderID"]);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Order updated successfully')</script>"); 
            BindGrid();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
           
                SqlConnection con = new SqlConnection(strcon); 
                string query = "DELETE FROM Tbl_Orders WHERE Order_ID = @Order_ID"; 
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Order_id", ViewState["SelectedOrderID"]);
                con.Open();
                cmd.ExecuteNonQuery(); 
                con.Close();
                Response.Write("<script>alert('Order deleted successfully!')</script>"); // Show success message
                BindGrid(); 

            }
        }
    }

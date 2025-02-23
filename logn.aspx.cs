using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Food
{
    public partial class logn : System.Web.UI.Page
    {
        SqlConnection con;
        string strcon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string qry = "SELECT * FROM Tbl_login WHERE email=@email AND password=@password";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            con.Open();
            int log = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();


            if(log!=0)
            { 
                MessageBox.Show("login successfully");
                Response.Redirect("FoodOrder.aspx");
                //Session//
            }
            else
            {
                MessageBox.Show("login failed");
            }
        }
    }
}
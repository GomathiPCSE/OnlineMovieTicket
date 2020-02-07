using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication
{
    public partial class ViewForm : System.Web.UI.Page
    {
        public object SqlDataSource1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }
        protected void refreshdata()
        {
            DataTable dataTable;
            dataTable = UserRepositary.refreshdata();
            idGridMovie.DataSource = dataTable;
            idGridMovie.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            int id = Convert.ToInt16(idGridMovie.DataKeys[e.RowIndex].Values["id"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_data where id =@id", con);
            cmd.Parameters.AddWithValue("id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            UserRepositary.refreshdata();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            refreshdata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            refreshdata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

            TextBox txtname = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox txtcity = GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["id"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_updatedata", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("name", txtname.Text);
            cmd.Parameters.AddWithValue("city", txtcity.Text);
            cmd.Parameters.AddWithValue("id", id);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            refreshdata();


        }

    }
}
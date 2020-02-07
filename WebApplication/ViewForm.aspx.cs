using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class ViewForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                refreshdata();
            }
        }
        protected void refreshdata()
        {
            DataTable dataTable;
            dataTable = UserRepositary.refreshdata();
            idGridMovie.DataSource = dataTable;
            idGridMovie.DataBind();
        }
        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(idGridMovie.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            UserRepositary.RowDeleting(id);
            UserRepositary.refreshdata();
        }
        protected void Grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            idGridMovie.EditIndex = e.NewEditIndex;
            refreshdata();
        }

        protected void Grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            idGridMovie.EditIndex = -1;
            refreshdata();
        }

        protected void Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            TextBox txtMovie = idGridMovie.Rows[e.RowIndex].FindControl("txtMovie") as TextBox;
            int id = Convert.ToInt16(idGridMovie.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SP_Update", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie", txtMovie.Text);
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            idGridMovie.EditIndex = -1;
            refreshdata();
        }

    }
}
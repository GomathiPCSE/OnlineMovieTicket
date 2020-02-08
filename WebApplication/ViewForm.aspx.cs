using OnlineMovieTicket.BL;
using System;
using System.Data;
using System.Web.UI.WebControls;
namespace WebApplication
{
    public partial class ViewForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refreshdata();
            }
        }
        protected void Refreshdata()
        {
            DataTable dataTable;
            dataTable = UserBl.Refreshdata();
            idGridMovie.DataSource = dataTable;
            idGridMovie.DataBind();
        }
        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(idGridMovie.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            UserBl.RowDeleting(id);
            UserBl.Refreshdata();
        }
        protected void Grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            idGridMovie.EditIndex = e.NewEditIndex;
            Refreshdata();
        }
        protected void Grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            idGridMovie.EditIndex = -1;
            Refreshdata();
        }
        protected void Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string txtMovie = Convert.ToString((idGridMovie.Rows[e.RowIndex].FindControl("txtMovie") as TextBox).Text);
            int id = Convert.ToInt16(idGridMovie.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            UserBl.RowUpdating(txtMovie,id);
            idGridMovie.EditIndex = -1;
            Refreshdata();
        }
    }
}
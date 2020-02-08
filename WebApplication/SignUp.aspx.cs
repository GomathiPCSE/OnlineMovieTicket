using OnlineMovieTicket.BL;
using OnlineMovieTicket.Entity;
using System;
namespace WebApplication
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SignUp_Click(object sender,EventArgs e)
        {
            string firstName = txtFirst.Text;
            string lastName = txtLast.Text;
            string mobile = txtMobile.Text;
            string mail = txtMail.Text;
            string password = txtPassword.Text;
            string conPassword = txtConPassword.Text;
            UserEntity user = new UserEntity(firstName, lastName, mobile, mail, password, conPassword);
            if (UserBl.Insert(user))
            {
                Response.Redirect("SignIn.aspx");
            }
            else
                Response.Write("Registration failed");
        }
    }
}
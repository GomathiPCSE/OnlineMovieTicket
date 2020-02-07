using System;
namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SignIn(object sender,EventArgs e)
        {
            bool isValid = false;
            string mail = txtUser.Text;
            string password = txtPassword.Text;
            isValid=UserRepositary.Login(mail, password);
            if(isValid)
            {
                Response.Write("Login successfully");
            }
            else
            Response.Write("There is no account...Register your account");
        }
        protected void SignUp(object sender, EventArgs e)
        {
             Response.Redirect ("SignUp.aspx");
        }
    }
}

namespace OnlineMovieTicket.Entity
{
    public class UserEntity
    {
        public string firstName;
        public string secondName;
        public string mobileNumber { get; set; }
        public string mailId { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public UserEntity(string firstName, string secondName, string mobileNumber, string mailId, string password, string confirmPassword)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.mobileNumber = mobileNumber;
            this.mailId = mailId;
            this.password = password;
            this.confirmPassword = confirmPassword;
        }
    }
}

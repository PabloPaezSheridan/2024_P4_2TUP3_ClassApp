using System.ComponentModel.DataAnnotations;

namespace ClassProject_Presentation.Models
{
    public class AuthenticationCredentials
    {
        public string Username { get; set; }
        //[RegularExpression("^(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d]{8,}$")]
        public string Password { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Exam_Dashboard.Api.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
   
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiredDate { get; set; }
 

    }
}

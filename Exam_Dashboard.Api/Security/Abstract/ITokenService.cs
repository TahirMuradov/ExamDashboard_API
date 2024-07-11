using Exam_Dashboard.Api.Models;


namespace Exam_Dashboard.Api.Security.Abstract
{
    public interface ITokenService
    {
        Task<Token> CreateAccessTokenAsync(User User, List<string> roles);
        string CreateRefreshToken();
       public  Task<string> UpdateRefreshTokenAsync(string refreshToken, User user);
    }
}

using Exam_Dashboard.Api.Models;


namespace Exam_Dashboard.Api.Security.Abstract
{
    public interface ITokenService
    {
        Task<Token> CreateAccessTokenAsync(User User, List<string> roles);
        /// <summary>
        /// return UserID
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        string TokenDecoded(string token);
        string CreateRefreshToken();
       public  Task<string> UpdateRefreshTokenAsync(string refreshToken, User user);
    }
}

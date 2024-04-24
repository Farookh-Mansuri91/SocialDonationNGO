using SocialNGO.Infrastructure.Db.Entities;

namespace SocialNGO.Models.Response
{
    public class UserLoginResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserPassword { get; set; }
        public string Token { get; set; }

        public UserLoginResponse(UserLogin user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            UserPassword = user.UserPassword;
            Token = token;
        }
    }

}

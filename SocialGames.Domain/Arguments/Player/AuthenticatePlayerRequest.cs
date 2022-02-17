namespace SocialGames.Domain.Arguments.Player
{
    public class AuthenticatePlayerRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

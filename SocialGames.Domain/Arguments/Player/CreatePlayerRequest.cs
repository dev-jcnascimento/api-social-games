namespace SocialGames.Domain.Arguments.Player
{
    public class CreatePlayerRequest
    {
        public string FirstName{ get;  set; }
        public string LastName { get; set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
    }
}

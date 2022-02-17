namespace SocialGames.Domain.Arguments.Player
{
    public class UpdatePlayerRequest 
    {
        public string FirstName{ get;  set; }
        public string LastName { get; set; }
        public string Email { get;  set; }
        public string Status { get; set; }
    }
}

namespace SocialGames.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public string Message { get; set; }
        protected ResponseBase()
        {
            Message = ("Operation performed successfully!");
        }

        public static explicit operator ResponseBase(Entities.Player entity)
        {
            return new ResponseBase()
            {
            };
        }

        public static explicit operator ResponseBase(Entities.PlatForm entity)
        {
            return new ResponseBase()
            { 
            };
        }
    }
}

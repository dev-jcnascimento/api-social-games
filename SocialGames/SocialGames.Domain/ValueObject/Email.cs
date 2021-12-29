using System;
using System.ComponentModel.DataAnnotations;

namespace SocialGames.Domain.ValueObject
{
    public class Email
    {
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Address { get; private set; }

        protected Email()
        {
        }
        public Email(string address)
        {
            Address = this.ValidarEmail(address);
        }

        private string ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Enter e-mail!");
            }
            return email;
        }
    }

}

using System;
using System.ComponentModel.DataAnnotations;

namespace SocialGames.Domain.ValueObject
{
    public class Email
    {
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
            if (!IsMail(email))
            {
                throw new Exception("E-mail is not valid!");
            }
            return email;
        }
        private bool IsMail(string email)
        {
            bool validEmail = false;
            int indexArr = email.IndexOf('@');
            if (indexArr > 0)
            {
                int indexDot = email.IndexOf('.', indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < email.Length)
                    {
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            validEmail = true;
                        }
                    }
                }
            }
            return validEmail;
        }
    }

}

using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

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
                throw new Exception("Informe um e-mail!");
            }
            //if (IsEmail(email))
            //{
            //    throw new Exception("Informe um e-mail válido");
            //}
            return email;
        }

        //bool IsEmail(string email)
        //{
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public static bool IsEmail(string email)
        //{
        //    byte[] bytes = Encoding.Default.GetBytes(email);
        //    email = Encoding.ASCII.GetString(bytes);


        //    bool validEmail = false;
        //    int indexArr = email.IndexOf('@');
        //    if (indexArr > 0)
        //    {
        //        int indexDot = email.IndexOf('.', indexArr);
        //        if (indexDot - 1 > indexArr)
        //        {
        //            if (indexDot + 1 < email.Length)
        //            {
        //                string indexDot2 = email.Substring(indexDot + 1, 1);
        //                if (indexDot2 != ".")
        //                {
        //                    validEmail = true;
        //                }
        //            }
        //        }
        //    }
        //    return validEmail;
        //}
        //private bool IsEmail(string email)
        //{
        //    if (string.IsNullOrWhiteSpace(email))
        //        return false;
        //    try
        //    {
        //        // Normalize the domain
        //        email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
        //                              RegexOptions.None, TimeSpan.FromMilliseconds(200));

        //        // Examines the domain part of the email and normalizes it.
        //        string DomainMapper(Match match)
        //        {
        //            // Use IdnMapping class to convert Unicode domain names.
        //            var idn = new IdnMapping();

        //            // Pull out and process domain name (throws ArgumentException on invalid)
        //            string domainName = idn.GetAscii(match.Groups[2].Value);

        //            return match.Groups[1].Value + domainName;
        //        }
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {
        //        return false;
        //    }
        //    catch (ArgumentException)
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        return Regex.IsMatch(email,
        //            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        //            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {
        //        return false;
        //    }
        //}
    }

}

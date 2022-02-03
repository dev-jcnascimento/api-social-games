using SocialGames.Domain.Extensions;
using System;

namespace SocialGames.Domain.ValueObject
{
    public class Password
    {
        public string Word { get; private set; }
        protected Password()
        {
        }
        public Password(string word)
        {
            Word = word;

            if (string.IsNullOrEmpty(Word))
            {
                throw new Exception("Enter a Password!");
            }
            if (Word.Length < 6)
            {
                throw new Exception("Enter a password of at least 6 characters.");
            }
            Word = Word.ConvertToMD5();
        }
    }
}

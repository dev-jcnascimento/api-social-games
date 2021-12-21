using SocialGames.Domain.Extension;

namespace SocialGames.Domain.ValueObject
{
    internal class Password
    {
        public string Word { get; private set; }
        public Password(string word)
        {
            Word = word;

            if (string.IsNullOrEmpty(Word))
            {
                throw new Exception("Informe um Password!");
            }
            if (Word.Length > 6)
            {
                throw new Exception("Digite uma senha de no mínimo 6 caraceteres.");
            }
            Word = Word.ConvertToMD5();
        }

    }
}

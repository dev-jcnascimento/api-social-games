using System;

namespace SocialGames.Domain.ValueObject
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        protected Name()
        {
        }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            if (string.IsNullOrEmpty(FirstName) || FirstName.Length > 30)
            {
                throw new Exception("Primeiro Nome não pode está vazio e não pode ser menor que 30 caracteres");
            }
            if (string.IsNullOrEmpty(LastName) || LastName.Length > 30)
            {
                throw new Exception("Nome não está vazio e não pode ser menor que 30 caracteres");
            }
        }
    }
}

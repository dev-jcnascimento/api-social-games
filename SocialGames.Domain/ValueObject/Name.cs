using System.ComponentModel.DataAnnotations;

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
                throw new ValidationException("Name cannot be empty and cannot be shorter than 30 characters.");
            }
            if (string.IsNullOrEmpty(LastName) || LastName.Length > 30)
            {
                throw new ValidationException("Name is not empty and cannot be shorter than 30 characters.");
            }
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}

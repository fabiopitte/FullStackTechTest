using System.Collections.Generic;
using System.Linq;

namespace TestDFO.Domain.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }

        public Dictionary<string, string> ErrorValidation { get; set; }

        public User(int id, string name, int age, string address)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
        }

        public static class ValidatedUser
        {
            public static User Create(int id, string name, int age, string address)
            {
                return new User(id, name, age, address);
            }
        }

        #region Validations

        public bool IsValid()
        {
            Validate();

            return !ErrorValidation.Any();
        }

        private void Validate()
        {
            ErrorValidation = new Dictionary<string, string>();
            ValidateName();
            ValidateAge();
            ValidateAddress();
        }

        private void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
                ErrorValidation.Add("Name", "The Name is required!");
            else if (Name.Length < 2 && Name.Length > 50)
                ErrorValidation.Add("Name", "The MaxLength of Name must be between 2 and 50 characteres");
        }

        private void ValidateAge()
        {
            if (Age < 1)
                ErrorValidation.Add("Age", "The Age is required!");
            if (Age > 130)
                ErrorValidation.Add("Age", "The Age must be between 1 and 130!");
        }

        private void ValidateAddress()
        {
            if (string.IsNullOrEmpty(Address))
                ErrorValidation.Add("Address", "The Address is required!");
            else if (Address.Length > 50)
                ErrorValidation.Add("Address", "The MaxLength of Address must be up to { 50 } characteres");
        }

        #endregion
    }
}

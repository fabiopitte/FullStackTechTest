using System.Collections.Generic;
using TestDFO.Domain.Interface;
using TestDFO.Domain.Models;

namespace TestDFO.Domain
{
    public class UserService : IUserService
    {
        public static List<User> ListUsers
        {
            get
            {
                return new List<User>
                {
                    new User(1, "Stephen Hawking", 20, "Oxford OX1 2JD, United Kingdom"),
                    new User(2, "Amy Winehouse", 29, "30 Camden Square, Enfield, United Kingdom")
                };
            }
        }

        public User Create(User user)
        {
            var newId = ListUsers.Count + 1;

            var newUser = User.ValidatedUser.Create(newId, user.Name, user.Age, user.Address);

            ListUsers.Add(newUser);

            return newUser;
        }

        public User Get(int id)
        {
            var user = default(User);

            user = ListUsers.Find(i => i.Id == id);

            return user;
        }

        public IEnumerable<User> List()
        {
            return ListUsers;
        }

        public User Update(User user)
        {
            var updatedUser = ListUsers.Find(i => i.Id.Equals(user.Id));

            var newUser = new User(updatedUser.Id, user.Name, user.Age, user.Address);

            updatedUser = newUser;

            return updatedUser;
        }
    }
}

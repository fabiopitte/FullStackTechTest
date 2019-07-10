using System.Collections.Generic;
using TestDFO.Domain.Models;

namespace TestDFO.Domain.Interface
{
    public interface IUserService
    {
        User Create(User user);
        User Update(User user);
        User Get(int id);
        IEnumerable<User> List();
    }
}

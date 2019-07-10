using System.Collections.Generic;
using TestDFO.Application.ViewModels;

namespace TestDFO.Application.Interface
{
    public interface IUserAppService
    {
        UserViewModel Create(UserViewModel user);
        UserViewModel Update(UserViewModel user);
        UserViewModel Get(int id);
        IEnumerable<UserViewModel> List();
    }
}

using UserDomain = TestDFO.Domain.Models;
using TestDFO.Application.ViewModels;

namespace TestDFO.Application.Adapters
{
    public class UserAdapter
    {
        public static UserDomain.User ToDomainModel(UserViewModel registerViewModel)
        {
            var user = new UserDomain.User(
                registerViewModel.Id,
                registerViewModel.Name,
                registerViewModel.Age,
                registerViewModel.Address);

            return user;
        }

        public static UserViewModel ToViewModel(UserDomain.User user)
        {
            var userViewModel = new UserViewModel(
                user.Id,
                user.Name,
                user.Age,
                user.Address);

            return userViewModel;
        }
    }
}

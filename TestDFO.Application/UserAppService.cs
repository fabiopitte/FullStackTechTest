using System.Collections.Generic;
using System.Linq;
using TestDFO.Application.Adapters;
using TestDFO.Application.Interface;
using TestDFO.Application.ViewModels;
using TestDFO.Domain.Interface;

namespace TestDFO.Application
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public UserViewModel Get(int id)
        {
            if (id <= 0)
            {
                return new UserViewModel();
            }

            var user = _userService.Get(id);

            return UserAdapter.ToViewModel(user);
        }

        public IEnumerable<UserViewModel> List()
        {
            var listUsers = _userService.List();
            var listViewModel = new List<UserViewModel>();

            listUsers.ToList()
                .ForEach(user =>
                {
                    listViewModel.Add(UserAdapter.ToViewModel(user));
                });

            return listViewModel;
        }

        public UserViewModel Create(UserViewModel user)
        {
            var _user = UserAdapter.ToDomainModel(user);

            if (_user.IsValid())
            {
                _userService.Create(_user);
            }

            return user;
        }

        public UserViewModel Update(UserViewModel user)
        {
            var updatedUser = default(Domain.Models.User);

            var _user = UserAdapter.ToDomainModel(user);

            if (_user.IsValid())
            {
                updatedUser = _userService.Update(_user);

                return UserAdapter.ToViewModel(updatedUser);
            }

            return user;
        }
    }
}

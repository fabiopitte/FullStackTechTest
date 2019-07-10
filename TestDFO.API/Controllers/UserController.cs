using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestDFO.Application.Interface;
using TestDFO.Application.ViewModels;

namespace TestDFO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        // Dependency injection of class userAppService, responsible for validate the user and call the domain
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        // GET api/User
        [HttpGet]
        public IEnumerable<UserViewModel> List()
        {
            return _userAppService.List();
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public ActionResult<UserViewModel> Get(int id)
        {
            var result = _userAppService.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // POST api/User
        [HttpPost]
        public ActionResult<UserViewModel> Post(UserViewModel userViewModel)
        {
            var _userCreated = _userAppService.Create(userViewModel);

            if (_userCreated.Id == 0)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(UserViewModel), new { id = _userCreated.Id }, _userCreated);
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return BadRequest();
            }

            _userAppService.Update(userViewModel);

            return NoContent();
        }
    }
}

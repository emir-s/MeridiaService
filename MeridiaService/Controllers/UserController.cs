using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meridia.Application.Interfaces;
using Meridia.Application.Models.Reponses;
using Meridia.Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace MeridiaService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest user)
        {
            var result = await _userService.CreateUser(user);
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ValidateUserResponse>> ValidateUser(ValidateUserRequest user)
        {
            var result = await _userService.ValidateUser(user);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public ActionResult<string> TestMethod(string test)
        { 
            return test;
        }
    }
}


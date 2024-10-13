using FootyFolio.Model;
using FootyFolio.Service.Common;
using FootyFolioLogic.WebApi.RestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootyFolioLogic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserInfoAsync(Guid id)
        {
            var user = await _userService.GetUserInfoAsync(id);
            if (user == null)   
            {
                return NotFound();
            }

            var userGetRest = new UserGetRest
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };

            return Ok(userGetRest);
        }

        [HttpPost]
        public async Task<ActionResult> InsertUser(User user)
        {
            return await _userService.InsertUserAsync(user) ? Ok("User successfully inserted") : BadRequest("User insertion failed");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserByIdAsync(Guid id, User user)
        {
            return await _userService.UpdateUserByIdAsync(id, user) ? Ok("User successfully updated") : BadRequest("User update failed");
        }

        [HttpGet("{id}/wishlist")]
        public async Task<ActionResult> GetUserWishlistAsync(Guid id)
        {
            var footballers = _userService.GetUserWishlistAsync(id);

            return (footballers == null) ? Ok(footballers) : BadRequest("No Footballers found");
        }

        [HttpPost("{id}")]

        public async Task<ActionResult> InsertFootballerIntoWishlistAsnyc(Guid id, Footballer footballer)
        {
            return await _userService.InsertFootballerIntoWishlistAsnyc(id, footballer) ? Ok("Successfully inserted into wishlist!") : BadRequest("Insertion gone bad");
        } 
    }
}

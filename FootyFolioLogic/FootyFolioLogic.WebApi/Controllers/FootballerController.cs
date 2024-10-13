using FootyFolio.Model;
using FootyFolio.Service.Common;
using FootyFolioLogic.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootyFolioLogic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FootballerController : ControllerBase
    {
        private readonly IFootballerService _footballerService;

        public FootballerController(IFootballerService footballerService)
        {
            _footballerService = footballerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetFootballersAsync(string name = "", bool? isForSale = true)
        {
            FootballerFilter filter = new FootballerFilter()
            {
                Name = name,
                IsForSale = isForSale
            };
            var footballers = await _footballerService.GetFootballersAsync(filter);
            if (footballers == null)
            {
                return NotFound("No footballers found with the specified filter.");
            }

            return Ok(footballers);
        }

        [HttpGet]
        public async Task<ActionResult> GetFootballersByUserId(Guid userId)
        {
            var footballers = await _footballerService.GetFootballersByUserIdAsync(userId);

            return (footballers == null) ? Ok("footballers") : NotFound("No footballers found for this user!");
        }
    }
}

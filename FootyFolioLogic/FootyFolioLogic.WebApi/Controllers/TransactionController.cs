using FootyFolio.Model;
using FootyFolio.Service.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootyFolioLogic.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("insert-transaction")]
        public async Task<IActionResult> InsertTransactionAsync([FromBody] Transaction transaction)
        {
            var result = await _transactionService.InsertTransactionAsync(transaction);

            if (result)
            {
                return Ok("Transaction successful and recorded.");
            }
            else
            {
                return StatusCode(500, "Transaction failed.");
            }
        }
    }
}

using FootyFolio.Model;
using FootyFolio.Service.Common;
using FootyFolioLogic.Service;
using FootyFolioLogic.WebApi.RestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FootyFolioLogic.WebApi.Controllers
{
    [ApiController]
    [Route("webhooks/clerk")]
    public class WebHookController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly string _webhookSecret;

        public WebHookController(IUserService userService)
        {
            _userService = userService;
            _webhookSecret = Environment.GetEnvironmentVariable("CLERK_WEBHOOK_SECRET")
                             ?? throw new Exception("You need a CLERK_WEBHOOK_SECRET in your environment variables.");
        }

        // Webhook handler for Clerk events
        [HttpPost("webhooks/clerk")]
        public async Task<IActionResult> ClerkWebhook()
        {
            var svixId = Request.Headers["svix-id"].ToString();
            var svixTimestamp = Request.Headers["svix-timestamp"].ToString();
            var svixSignature = Request.Headers["svix-signature"].ToString();

            if (string.IsNullOrEmpty(svixId) || string.IsNullOrEmpty(svixTimestamp) || string.IsNullOrEmpty(svixSignature))
            {
                return BadRequest("Error occurred -- missing svix headers.");
            }

            // Get the raw body as string
            string rawBody;
            using (var reader = new StreamReader(Request.Body))
            {
                rawBody = await reader.ReadToEndAsync();
            }

            // Verify webhook signature
            if (!VerifyWebhookSignature(rawBody, svixId, svixTimestamp, svixSignature))
            {
                return BadRequest(new { success = false, message = "Invalid signature." });
            }

            // Parse the payload
            var evt = JObject.Parse(rawBody);
            var eventType = evt["type"]?.ToString();
            var userData = evt["data"];

            if (userData == null || eventType == null)
            {
                return BadRequest(new { success = false, message = "Invalid payload." });
            }

            var userId = userData["id"]?.ToString();
            var username = userData["username"]?.ToString();
            var emailAddresses = userData["email_addresses"];
            var primaryEmailAddressId = userData["primary_email_address_id"]?.ToString();

            var primaryEmailAddress = ExtractClerkPrimaryEmail(emailAddresses, primaryEmailAddressId);

            if (eventType == "user.created")
            {
                var newUser = new User
                {
                    Id = Guid.Parse(userId),
                    Username = username,
                    Email = primaryEmailAddress
                };

                await _userService.InsertUserAsync(newUser);
            }
            else if (eventType == "user.updated")
            {
                var userToUpdate = new User
                {
                    Id = Guid.Parse(userId),
                    Username = username,
                    Email = primaryEmailAddress
                };

                await _userService.UpdateUserByIdAsync(Guid.Parse(userId), userToUpdate);
            }

            return Ok(new { success = true, message = "Webhook processed successfully." });
        }

        // This method verifies the webhook signature using HMAC-SHA256
        private bool VerifyWebhookSignature(string payload, string svixId, string svixTimestamp, string svixSignature)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_webhookSecret)))
            {
                var data = $"{svixId}.{svixTimestamp}.{payload}";
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                var computedSignature = Convert.ToBase64String(hash);

                return svixSignature == computedSignature;
            }
        }

        // Helper method to extract the primary email address from the Clerk payload
        private string ExtractClerkPrimaryEmail(JToken emailAddresses, string primaryEmailAddressId)
        {
            foreach (var emailAddress in emailAddresses)
            {
                if (emailAddress["id"]?.ToString() == primaryEmailAddressId)
                {
                    return emailAddress["email_address"]?.ToString();
                }
            }
            return null;
        }
    }
}

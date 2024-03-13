using Microsoft.AspNetCore.Identity.UI.Services;

namespace Amazon.Utility
{
    public class EmailSender : IEmailSender
    {
        // Fake implementation to avoid the error
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}

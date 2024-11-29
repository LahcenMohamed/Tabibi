using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Infrastructure.Email
{
    public sealed class EmailServices(IConfiguration configuration) : IEmailServices
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<Result<string>> SendEmailAsync(string toEmail, string Message, string? reason)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailHost").Value));
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = reason;
                email.Body = new TextPart(TextFormat.Text)
                {
                    Text = Message
                };

                using var smtp = new SmtpClient();
                smtp.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                await smtp.ConnectAsync(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return Result.Success("success");
            }
            catch (Exception ex)
            {
                return Result.BadRequest<string>(ex.Message);
            }

        }
    }
}

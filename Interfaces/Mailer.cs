using System;
using System.Threading.Tasks;
using JakupovicNL.Models;
using Microsoft.AspNetCore.Http;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace JakupovicNL
{
	public class Mailer : IMailer
	{
		private readonly string _apiKey;
		private readonly SendGridClient _client;

		public Mailer()
		{
			_apiKey = Environment.GetEnvironmentVariable(Startup._sendgridApiKey);
            _client = new SendGridClient(_apiKey);
		}

		public async Task<Response> SendEmail(EmailForm form)
		{
			var from = new EmailAddress(form.EmailAddress, form.Name);
            var subject = "Someone send you a message!";
            var to = new EmailAddress("jakupovicdennis@gmail.com", "Nuss");
            var plainTextContent = form.Message;
            var htmlContent = $"<strong>{form.Message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response =  await _client.SendEmailAsync(msg);

			return response;
		}

	}
}
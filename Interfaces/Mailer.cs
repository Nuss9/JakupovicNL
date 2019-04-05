using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JakupovicNL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace JakupovicNL
{
	public class Mailer : IMailer
	{
		public IConfiguration Configuration { get; set; }
		private readonly string _apiKey;
		private readonly SendGridClient _client;

		public Mailer(IConfiguration config)
		{
			Configuration = config;
			_apiKey = Configuration["Sendgrid:ApiKey"];
			_client = new SendGridClient(_apiKey);
		}

		public async Task<Response> SendEmail(EmailForm form)
		{
			var from = new EmailAddress(form.EmailAddress, form.Name);
			var subject = $"Console request from {form.Name}";
			var to = new EmailAddress("jakupovicdennis@gmail.com", "Nuss");
			var plainTextContent = GeneratePlainTextContent(form.Console, form.Name, form.Message);	
			var htmlContent = System.Net.WebUtility.HtmlEncode(plainTextContent).Replace("\n", "<br/>");
			var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
			var response =  await _client.SendEmailAsync(msg);

			return response;
		}

		public static string GeneratePlainTextContent(string console, string name, string message)
		{
			if(string.IsNullOrWhiteSpace(console)) {
				console = "console of your choice";
			}

			string partA = $"Dear player,\n\n{name} has requested a {console} for his noble quest.\nWould you care to support him?\n\n";
			string partB = $"Additionally, {name} left you a personal message too:\n";
			string partC = $"\"{message}\"\n\n";
			string partD = "Best regards,\nYour faithful messenger";

			StringBuilder sb = new StringBuilder();
			sb.Append(partA);
			if(!string.IsNullOrWhiteSpace(message)) {
				sb.Append(partB);
				sb.Append(partC);
			}
			sb.Append(partD);

			return sb.ToString();
		}
	}
}
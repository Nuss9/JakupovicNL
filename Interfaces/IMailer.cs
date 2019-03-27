using SendGrid;
using System;
using JakupovicNL.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace JakupovicNL
{
	public interface IMailer
	{
		Task<Response> SendEmail(EmailForm form);
	}
}
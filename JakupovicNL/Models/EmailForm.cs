using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JakupovicNL.Models
{
	public class EmailForm
	{
		public Guid Id { get; set; }

		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		[Display(Name = "Your name: ")]
		public string Name { get; set; }

		[Required]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
		[Display(Name = "Your email address: ")]
		public string EmailAddress { get; set; }

		[Display(Name = "Select your console:")]
		public string Console { get; set; }

		[MinLength(2)]
		[MaxLength(50)]
		[Display(Name = "Additional message: ")]
		public string Message { get; set; }

	}
}
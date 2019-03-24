using System;
using System.ComponentModel.DataAnnotations;

namespace JakupovicNL.Models
{
	public class EmailForm
	{
		public Guid Id { get; set; }

		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		[Display(Name = "You name: ")]
		public string Name { get; set; }

		[Required]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
		[Display(Name = "You email address (for cc and replies): ")]
		public string EmailAddress { get; set; }

		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		[Display(Name = "Your message: ")]
		public string Message { get; set; }

	}
}
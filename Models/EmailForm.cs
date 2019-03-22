using System;
using System.ComponentModel.DataAnnotations;

namespace JakupovicNL.Models
{
	public class EmailForm
	{
		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
		public string EmailAddress { get; set; }

		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		public string Message { get; set; }

	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class FormProcessingResult
	{
		public bool IsSuccess { get; set; }
		public List<ValidationResult> Errors { get; set; }
	}

}

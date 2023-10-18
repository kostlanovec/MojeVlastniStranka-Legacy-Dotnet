using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class FormProcessingResult
	{
        /// <summary>
        /// Vrací nebo nastavuje, zda validace proběhlá úspěšně.
        /// </summary>
        public bool IsSuccess
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje list errorů, které se vypíšou uživateli.
        /// </summary>
        public List<ValidationResult> Errors
        {
            get;
            set;
        }
	}

}

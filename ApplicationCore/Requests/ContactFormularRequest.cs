using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
    public class ContactFormularRequest
    {
        /// <summary>
        /// Vrací nebo nastavuje první jméno zákazníka.
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje příjmení zákazníka.
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje email zákazníka.
        /// </summary>
        [EmailAddress]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje telefonní číslo zákazníka.
        /// </summary>
        [Phone]
        public int PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje zprávu od zákazníka.
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        public DateTime date
        {
	        get;
	        set;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName == null)
            {
                yield return new ValidationResult(string.Format(Localization.Resource.ContactForm_Null_FirstName), new string[] { });
            }

            if (LastName == null)
            {
                yield return new ValidationResult(string.Format(Localization.Resource.ContactForm_Null_LastName), new string[] { });
            }

            if (Email == null)
            {
                yield return new ValidationResult(string.Format(Localization.Resource.ContactForm_Null_Email), new string[] { });
            }

            else if (!new EmailAddressAttribute().IsValid(Email))
            {
                yield return new ValidationResult(string.Format(Localization.Resource.ContactForm_Bad_Email));
            }

            if (!new PhoneAttribute().IsValid(PhoneNumber)) // převádíme na string pro validaci
            {
	            yield return new ValidationResult(string.Format(Localization.Resource.ContactForm_Bad_Phone));
            }

		}
    }
}

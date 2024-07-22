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
        public string PhoneNumber
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

        /// <summary>
        /// Vrací nebo nastavuje datum, kdy byl formulář odeslaný
        /// </summary>
        public DateTime DateSend
        {
	        get;
	        set;
        }
	}
}
using System.Collections;

namespace MojeVlastniStranka.ApplicationCore.Dto
{
    public class ContactFormularDto
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
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje telefonní číslo zákazníka.
        /// </summary>
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
    }
}

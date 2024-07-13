namespace MojeVlastniStranka.Common.Dto
{
    public class ContactFormularDto
    {

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
        /// Vrací nebo nastavuje, kdy byl formulář odeslaný.
        /// </summary>
        public DateTime SendTime
        {
            get;
            set;
        }
    }
}

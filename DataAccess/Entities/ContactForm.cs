using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
	[Table(nameof(ContactForm))]
	public class ContactForm
	{
		/// <summary>
		/// Chráněný konstruktor.
		/// </summary>
		protected ContactForm() { }

		/// <summary>
		/// Klíč.
		/// </summary>
		public int Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje křesní jméno.
		/// </summary>
		[Column(TypeName = "nvarchar(20)")]
		public string FirstName
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje přijímení.
		/// </summary>
		[Column(TypeName = "nvarchar(20)")]
		public string LastName
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje email pro odeslání reakce.
		/// </summary>
		[Column(TypeName = "nvarchar(max)")]
		public string Email
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje telefonní číslo.
		/// </summary>
		[Phone]
		public int PhoneNumber
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje text od zákazníka.
		/// </summary>
		[Column(TypeName = "nvarchar(max)")]
		public string FeedBack
		{
			get;
			set;
		}

        /// <summary>
        ///  Vytváří instanci <see cref="ContactForm"/> Vhodný pro uložení do databáze.
        /// </summary>
//#if DEBUG
//		public static ContactForm Create(int id,string firstName, string lastName, string email, int phoneNumber, string feedBack)
//		{
//			var contactForm = new ContactForm()
//			{
//				Id = id,
//				FirstName = firstName,
//				LastName = lastName,
//				Email = email,
//				PhoneNumber = phoneNumber,
//				FeedBack = feedBack
//			};

//			return contactForm;
//        }
//#else
        public static ContactForm Create(string firstName, string lastName, string email, int phoneNumber, string feedBack)
        {
            var contactForm = new ContactForm()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                FeedBack = feedBack
            };

            return contactForm;
        }
//#endif
	}
}

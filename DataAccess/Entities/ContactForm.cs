using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
	[Table(nameof(ContactForm))]
	public class ContactForm : IEntities
	{
		/// <summary>
		/// Chráněný konstruktor.
		/// </summary>
		protected ContactForm() { }

		/// <summary>
		/// Vrací nebo nastavuje Id formuláře.
		/// </summary>
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje email pro odeslání reakce.
		/// </summary>
		[Column(TypeName = "text")]
		public string Email
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje telefonní číslo.
		/// </summary>
		[Phone]
		[Column(TypeName = "text")]
		public string? PhoneNumber
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje text od zákazníka.
		/// </summary>
		[Column(TypeName = "text")]
		public string Message
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje čas.
		/// </summary>
		[Column(TypeName = "timestamp")]
		public DateTime Date
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="ContactForm"/> Vhodný pro uložení do databáze.
		/// </summary>
		public static ContactForm Create(string email, string? phoneNumber, string message, DateTime date)
		{
			var contactForm = new ContactForm()
			{
				Id = Guid.NewGuid(),
				Email = email,
				PhoneNumber = phoneNumber,
				Message = message,
				Date = date
			};

			return contactForm;
		}

	}
}

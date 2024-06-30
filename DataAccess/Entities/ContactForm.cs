using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

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
		[Column(TypeName = "nvarchar(1000)")]
		public string Email
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje telefonní číslo.
		/// </summary>
		[Phone]
		[Column(TypeName = "varchar(20)")]
		public string? PhoneNumber
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje text od zákazníka.
		/// </summary>
		[Column(TypeName = "nvarchar(1000)")]
		public string Message
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje čas.
		/// </summary>
		public DateTime Date
		{
			get;
			set;
		}

		/// <summary>
		///  Vytváří instanci <see cref="ContactForm"/> Vhodný pro uložení do databáze.
		/// </summary>
		public static ContactForm Create(Guid id, string email, string? phoneNumber, string message, DateTime date)
		{
			var contactForm = new ContactForm()
			{
				Id = id,
				Email = email,
				PhoneNumber = phoneNumber,
				Message = message,
				Date = date
			};

			return contactForm;
		}

	}
}

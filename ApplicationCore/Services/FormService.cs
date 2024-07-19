using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class FormService
	{
		private readonly DataContext context;

		public FormService(DataContext context)
		{
			this.context = context;
		}

		///<summary>
		/// Přidá nový formulář do databáze.
		/// </summary>
		public void AddForm(ContactFormularDto contactForm)
		{
			var contactformular = ContactForm.Create(
				contactForm.Email,
				contactForm.PhoneNumber,
				contactForm.Message,
				contactForm.SendTime
			);

			context.ContactForms.Add(contactformular);
			context.SaveChanges();
		}

		/// <summary>
		/// Vrací všechny formuláře, které někdo vyplnil.
		/// </summary>
		public List<ContactForm> GetAllForms()
		{
			return context.ContactForms.ToList();
		}
	}
}

using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class FormService : IFormService
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
			return context.ContactForms.AsNoTracking().ToList();
		}

		/// <summary>
		/// Smaže formulář podle Id.
		/// </summary>
		public void DeleteForm(Guid id)
		{
			var contactForm = context.ContactForms.Find(id);
			if (contactForm != null)
			{
				context.ContactForms.Remove(contactForm);
				context.SaveChanges();
			}
		}
	}
}

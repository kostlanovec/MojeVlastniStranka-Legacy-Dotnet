using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess.Entities;


namespace MojeVlastniStranka.ApplicationCore.Services
{

    public class ContactFormService
    {
	    private readonly DataContext context;
	    public NotificationService NotificationService;

	    public ContactFormService(DataContext context, NotificationService notification)
	    {
		    this.context = context;
		    this.NotificationService = notification;
	    }

		/// <summary>
		/// Zpracování formuláře.
		/// </summary>
		public async Task<FormProcessingResult> FormProcessing(ContactFormularRequest contactFormularRequest)
        {
            var result = new FormProcessingResult();
            var validationResults = contactFormularRequest.Validate(new ValidationContext(contactFormularRequest)).ToList();

            if (validationResults.Any())
            {
                result.IsSuccess = false;
                result.Errors = validationResults;
                return result;
            }
			var contactFormular = ContactForm.Create(
				Guid.NewGuid(), 
				contactFormularRequest.FirstName,
				contactFormularRequest.LastName,
				contactFormularRequest.Email,
				contactFormularRequest.PhoneNumber,
				contactFormularRequest.Message,
				contactFormularRequest.DateSend = DateTime.Now
			);
			NotificationService.CreateNotification($"New contact form from {contactFormularRequest.FirstName} {contactFormularRequest.LastName}.");
			context.ContactForms.Add(contactFormular);
			await context.SaveChangesAsync();
			result.IsSuccess = true;
            return result;
        }

		/// <summary>
		/// Získání všech formulářů.
		/// </summary>
		public async Task<List<ContactFormularDto>> GetAllForms()
		{
			var contactForms = await context.ContactForms.ToListAsync();

			var contactFormDtos = contactForms.Select(cf => new ContactFormularDto
			{
				FirstName = cf.FirstName,
				LastName = cf.LastName,
				Email = cf.Email,
				PhoneNumber = cf.PhoneNumber,
				Message = cf.FeedBack,
				SendTime = cf.Date
			}).ToList();

			return contactFormDtos;
		}

	}
}

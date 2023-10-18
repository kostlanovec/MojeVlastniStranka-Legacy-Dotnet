using System.ComponentModel.DataAnnotations;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.ApplicationCore.Requests;


namespace MojeVlastniStranka.ApplicationCore.Services
{

    public class ContactFormService
    {
		private readonly DataManagementService dataManagementService;
		public ContactFormService(DataContext context)
		{
			this.dataManagementService = new DataManagementService(context);
		}

		public async Task<FormProcessingResult> FormProcessing(ContactFormularRequest contactFormRequest)
        {
            var result = new FormProcessingResult();
            var validationResults = contactFormRequest.Validate(new ValidationContext(contactFormRequest)).ToList();

            if (validationResults.Any())
            {
                result.IsSuccess = false;
                result.Errors = validationResults;
                return result;
            }

            await dataManagementService.AddContactForm(contactFormRequest);
            result.IsSuccess = true;
            return result;
        }

		public async Task<List<ContactFormularDto>> GetAllForms()
		{
			var contactForms = await dataManagementService.GetAllContactForms();

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

using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IFormService
    {
		void AddForm(ContactFormularDto contactForm);
		List<ContactForm> GetAllForms();
		void DeleteForm(Guid id);
    }
}

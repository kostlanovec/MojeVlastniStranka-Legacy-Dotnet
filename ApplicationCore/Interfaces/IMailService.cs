using MailKit.Net.Smtp;
using MimeKit;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface IMailService
    {
		Task SendMail(NewsLetterRequest newsLetterRequest);
		Task SendVeritificationEmailAsync();
		bool AddEmailForNewsLetter(string email);
		Task<List<NewsLetter>> GetAllNewsletterEmails();
    }
}

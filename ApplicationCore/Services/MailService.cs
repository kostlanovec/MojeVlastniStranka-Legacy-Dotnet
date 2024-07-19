using MailKit.Net.Smtp;
using MimeKit;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class MailService
	{

		private readonly DataContext context;

		public MailService(DataContext context)
        {
            this.context = context;
        }

		// todo logování

		/// <summary>
		/// Posílá newsletter.
		/// </summary>
		public void SendMail(NewsLetterRequest newsLetterRequest)
		{
			var message = new MimeMessage();
			// todo tohle předělat, možná číst z appsettings?
			message.From.Add(new MailboxAddress("Jan Sebastián Kostlán", "kostlan@kostlanovec.cz"));
			message.To.Add(new MailboxAddress("Jan Sebastián Kostlán", "info@kostlanovec.cz"));
			message.Subject = newsLetterRequest.Subject;

			message.Body = new TextPart("html")
			{
				Text = newsLetterRequest.Body
			};

			Client(message, "", "");
		}

		public void SendVeritificationEmail()
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Jan Sebastián Kostlán", "kostlan@kostlanovec.cz"));
			message.To.Add(new MailboxAddress("Jan Sebastián Kostlán", "info@kostlanovec.cz"));
			//message.Subject = newsLetterRequest.Subject;

			//message.Body = new TextPart("html")
			//{
			//	Text = newsLetterRequest.Body
			//};

			Client(message, "", "");
		}

		/// <summary>
		/// Klient na připojení k webmailu a následného odeslání emailu s přihlášením.
		/// </summary>
		/// <param name="message">Zpráva</param>
		/// <param name="email">emailová adresa.</param>
		/// <param name="password">Heslo.</param>
		private void Client(MimeMessage message, string email, string password)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					client.Connect("mail.example.com", 587, false);
				}
				catch (Exception)
				{
					client.Connect("mail.infifire.com", 465, true);
				}

				// todo čtení z jsonu
				client.Authenticate("kostlan@kostlanovec.cz", "[REDACTED]");
				client.Send(message);
				client.Disconnect(true);
			}
		}

		/// <summary>
		/// Přidá email pro newsletter.
		/// </summary>
		public void AddEmailForNewsLetter(string email)
		{
            var newsLetterEmail = NewsLetter.Create(email);

			context.NewsLetters.Add(newsLetterEmail);
            context.SaveChanges();
        }
    }
}

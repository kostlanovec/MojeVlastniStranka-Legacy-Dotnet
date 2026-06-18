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
		private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;

		public MailService(DataContext context, Microsoft.Extensions.Configuration.IConfiguration configuration)
		{
			this.context = context;
			this.configuration = configuration;
		}

		/// <summary>
		/// Posílá newsletter.
		/// </summary>
		public async Task SendMail(NewsLetterRequest newsLetterRequest)
		{
			var message = new MimeMessage();
			var emails = await GetAllNewsletterEmails();

			if (emails != null)
			{
				foreach (var email in emails)
				{
					message.From.Add(new MailboxAddress("Jan Sebastián Kostlán", "kostlan@kostlanovec.cz"));
					message.To.Add(new MailboxAddress(email.Email, email.Email));
					message.Subject = newsLetterRequest.Subject;

					message.Body = new TextPart("html")
					{
						Text = newsLetterRequest.Body
					};

					var emailAddress = configuration["EmailSettings:Username"] ?? "kostlan@kostlanovec.cz";
					var password = configuration["EmailSettings:Password"] ?? "HESLO-Z-APPSETTINGS";
					Client(message, emailAddress, password);
				}
			}
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

			var emailAddress = configuration["EmailSettings:Username"] ?? "kostlan@kostlanovec.cz";
			var password = configuration["EmailSettings:Password"] ?? "HESLO-Z-APPSETTINGS";
			Client(message, emailAddress, password);
		}

		/// <summary>
		/// Klient na připojení k webmailu a následného odeslání emailu s přihlášením.
		/// </summary>
		/// <param name="message">Zpráva</param>
		/// <param name="email">Emailová adresa.</param>
		/// <param name="password">Heslo.</param>
		private void Client(MimeMessage message, string email, string password)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					// Připojení k hlavnímu SMTP serveru
					client.Connect("smtp.example.com", 587, false);  // Port 587 pro TLS
				}
				catch (Exception ex)
				{
					// Zpracování chyby připojení
					Console.WriteLine("Chyba připojení k SMTP serveru: " + ex.Message);
					return;
				}

				try
				{
					// Autentizace pomocí poskytnutých přihlašovacích údajů
					client.Authenticate(email, password);

					// Odeslání zprávy
					client.Send(message);
				}
				catch (Exception ex)
				{
					// Zpracování chyby při odesílání
					Console.WriteLine("Chyba při odesílání emailu: " + ex.Message);
				}
				finally
				{
					// Odpojení od serveru
					client.Disconnect(true);
				}
			}
		}


		/// <summary>
		/// Přidá email pro newsletter.
		/// </summary>
		/// <param name="email">Emailová adresa</param>
		/// <returns>Vrací true, pokud byl email úspěšně přidán, jinak false</returns>
		public bool AddEmailForNewsLetter(string email)
		{
			bool emailExist = context.NewsLetters.Any(x => x.Email == email);
			if (emailExist)
			{
				return false; // Email již existuje
			}

			var newsLetterEmail = NewsLetter.Create(email);
			context.NewsLetters.Add(newsLetterEmail);
			context.SaveChanges();
			return true; // Email byl úspěšně přidán
		}

		public async Task<List<NewsLetter>> GetAllNewsletterEmails()
		{
			return await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(context.NewsLetters);
		}
	}
}

using MailKit.Net.Smtp;
using MimeKit;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class MailService : IMailService
	{
		private readonly DataContext _context;
		private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
		private readonly ILogger<MailService> _logger;

		public MailService(DataContext context, Microsoft.Extensions.Configuration.IConfiguration configuration, ILogger<MailService> logger)
		{
			_context = context;
			_configuration = configuration;
			_logger = logger;
		}

		/// <summary>
		/// Posílá newsletter asynchronně a optimalizovaně bez opakovaného připojování.
		/// </summary>
		public async Task SendMail(NewsLetterRequest newsLetterRequest)
		{
			var emails = await GetAllNewsletterEmails();

			if (emails != null && emails.Any())
			{
				var emailAddress = _configuration["EmailSettings:Username"];
				var password = _configuration["EmailSettings:Password"];

				if (string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
				{
					_logger.LogError("Chybí konfigurace EmailSettings:Username nebo EmailSettings:Password.");
					return;
				}

				using var client = new SmtpClient();
				try
				{
					await client.ConnectAsync("smtp.example.com", 587, SecureSocketOptions.StartTls);
					await client.AuthenticateAsync(emailAddress, password);

					foreach (var email in emails)
					{
						var message = new MimeMessage();
						message.From.Add(new MailboxAddress("Jan Sebastián Kostlán", emailAddress));
						message.To.Add(new MailboxAddress(email.Email, email.Email));
						message.Subject = newsLetterRequest.Subject;

						message.Body = new TextPart("html")
						{
							Text = newsLetterRequest.Body
						};

						try
						{
							await client.SendAsync(message);
						}
						catch (Exception ex)
						{
							_logger.LogError(ex, "Chyba při odesílání newsletteru na email: {Email}", email.Email);
						}
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Chyba při připojování k SMTP serveru pro newsletter.");
				}
				finally
				{
					if (client.IsConnected)
					{
						await client.DisconnectAsync(true);
					}
				}
			}
		}

		/// <summary>
		/// Odesílá verifikační email.
		/// </summary>
		public async Task SendVeritificationEmailAsync()
		{
			var emailAddress = _configuration["EmailSettings:Username"];
			var password = _configuration["EmailSettings:Password"];
			
			if (string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
			{
				_logger.LogError("Chybí konfigurace EmailSettings:Username nebo EmailSettings:Password.");
				return;
			}

			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Jan Sebastián Kostlán", emailAddress));
			message.To.Add(new MailboxAddress("Jan Sebastián Kostlán", "info@kostlanovec.cz"));
			message.Subject = "Verifikace";
			message.Body = new TextPart("html") { Text = "Verifikační email." };

			using var client = new SmtpClient();
			try
			{
				await client.ConnectAsync("smtp.example.com", 587, SecureSocketOptions.StartTls);
				await client.AuthenticateAsync(emailAddress, password);
				await client.SendAsync(message);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Chyba při odesílání verifikačního emailu.");
			}
			finally
			{
				if (client.IsConnected)
				{
					await client.DisconnectAsync(true);
				}
			}
		}

		/// <summary>
		/// Přidá email pro newsletter.
		/// </summary>
		public bool AddEmailForNewsLetter(string email)
		{
			bool emailExist = _context.NewsLetters.Any(x => x.Email == email);
			if (emailExist)
			{
				return false;
			}

			var newsLetterEmail = NewsLetter.Create(email);
			_context.NewsLetters.Add(newsLetterEmail);
			_context.SaveChanges();
			return true;
		}

		public async Task<List<NewsLetter>> GetAllNewsletterEmails()
		{
			return await _context.NewsLetters.AsNoTracking().ToListAsync();
		}
	}
}

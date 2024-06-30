using Google.Protobuf.Reflection;
using MailKit.Net.Smtp;
using MimeKit;
using MojeVlastniStranka.ApplicationCore.Requests;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class MailService
	{
		/// <summary>
		/// Posílá newsletter.
		/// </summary>
		public void SendMail(NewsLetterRequest newsLetterRequest)
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Jan Sebastián Kostlán", "kostlan@kostlanovec.cz"));
			message.To.Add(new MailboxAddress("Jan Sebastián Kostlán", "info@kostlanovec.cz"));
			message.Subject = newsLetterRequest.Subject;

			message.Body = new TextPart("html")
			{
				Text = newsLetterRequest.Body
			};

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
				client.Authenticate("kostlan@kostlanovec.cz", "[REDACTED]");
				client.Send(message);
				client.Disconnect(true);
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
				client.Authenticate("kostlan@kostlanovec.cz", "[REDACTED]");
				client.Send(message);
				client.Disconnect(true);
			}
		}

		public void SendEmailForNewsLetter(string email)
		{
			// generate token and save to database with email
			// send email with token
			// user click on link with token
		}
	}
}

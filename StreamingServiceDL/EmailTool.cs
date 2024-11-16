using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace StreamingServiceDL
{
    public class EmailTool
    {
        public void SendEmail(string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Watchlist", "do-not-reply@watchlist.com"));
            message.To.Add(new MailboxAddress("User", "user@mailkit.com"));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = $"<h1>{subject}</h1> <p>{body}</p>"
            };

            using (var client = new SmtpClient())
            {

                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("667fbdf9398671", "46fdc321c6aeed");
                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Sending Email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}

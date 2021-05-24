using System;
using MimeKit;
using MailKit.Net.Smtp;
using Ways_DAO.Models;
using Ways_DAO.Repositories;
using Ways_DAO.Tools;

namespace Ways_DAO.Services
{
    public class Mailer
    {
        public void SendEmail(User[] recipients, string senderName, string subject, string messageBody)
        {
            var mailMessage = new MimeMessage();

            ParameterRepository parameterRepository = new ParameterRepository();
            
            string smtpEmail = parameterRepository.FindParameterValueByName("SMTP_EMAIL");
            string smtpHost = parameterRepository.FindParameterValueByName("SMTP_HOST");
            int smtpPort = Convert.ToInt32(parameterRepository.FindParameterValueByName("SMTP_PORT"));
            string smtpPassword = parameterRepository.FindParameterValueByName("SMTP_PASSWORD");

            mailMessage.From.Add(new MailboxAddress(senderName, smtpEmail));
            foreach (User recipient in recipients)
            {
                mailMessage.To.Add(
                    new MailboxAddress(
                        $"{recipient.FirstName} {recipient.LastName}", 
                        recipient.Email)
                    );
            }

            mailMessage.Subject = subject;
            mailMessage.Body = new TextPart("plan")
            {
                Text = messageBody
            };

            using (var client = new SmtpClient())
            {
                client.Connect(smtpHost, smtpPort, true);
                client.Authenticate(smtpEmail,smtpPassword);
                client.Send(mailMessage);
                client.Disconnect(true);
            }
        }
    }
}
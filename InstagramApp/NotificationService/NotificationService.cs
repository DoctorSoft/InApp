using System;
using System.Net;
using System.Net.Mail;

namespace NotificationService
{
    public static class NotificationService
    {
        public static void SendNotification(string text, params string[] receivers)
        {
            var email = "SysDocRemainder@gmail.com";
            const string password = "MeganFox1";

            foreach (var receiver in receivers)
            {

                try
                {
                    var fromAddress = new MailAddress(email, email);
                    var toAddress = new MailAddress(receiver, receiver);
                    const string fromPassword = password;
                    const string subject = "Напоминалка";
                    string body = text;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    /*using (SmtpClient client = new SmtpClient("smtp.gmail.com", 465))
                    {
                        // Configure the client
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(email, password);
                        // client.UseDefaultCredentials = true;

                        // A client has been created, now you need to create a MailMessage object
                        MailMessage message = new MailMessage(
                                                 email, // From field
                                                 receiver, // Recipient field
                                                 "System Doctor Remainder", // Subject of the email message
                                                 text
                                              );

                        // Send the message
                        client.Send(message);
                    }*/
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}

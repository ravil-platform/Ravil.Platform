namespace Common.Utilities.Senders
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            try
            {
                var mailMessage = new MailMessage();
                var smtpServer = new SmtpClient("");

                mailMessage.From = new MailAddress("", "");
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                smtpServer.Port = 25;
                smtpServer.Credentials = new System.Net.NetworkCredential("", "");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mailMessage);
            }
            catch
            {
                throw;
            }
        }
    }
}

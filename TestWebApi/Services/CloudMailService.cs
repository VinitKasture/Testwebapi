namespace TestWebApi.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailFrom = String.Empty;
        private string _mailTo = String.Empty;

        public CloudMailService(IConfiguration configuration) 
        {
            _mailFrom = configuration["MailSettings:MailFrom"];
            _mailTo = configuration["MailSettings:MailTo"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($@"Sending email via {nameof(CloudMailService)}");
            Console.WriteLine("Sending email to " + _mailTo);
            Console.WriteLine("Sending email successful!");
        }
    }
}

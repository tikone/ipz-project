using System;

namespace TravelAgency.Infrastructure
{
    class EmailAgentFake : IEmailAgent
    {
        public void sendEmail(string targetAddress, string subject, string body)
        {
            Console.WriteLine("==== Email ===== ");
            Console.Write("To: ");
            Console.WriteLine(targetAddress);
            Console.Write("Subject: ");
            Console.WriteLine(subject);
            Console.WriteLine();
            Console.WriteLine(body);
            Console.WriteLine();
            Console.WriteLine("==== End Email ===== ");
            Console.WriteLine();
        }
    }
}

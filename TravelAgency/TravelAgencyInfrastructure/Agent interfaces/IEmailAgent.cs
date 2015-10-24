using System;

namespace TravelAgency.Infrastructure
{
    public interface IEmailAgent
    {
        void sendEmail(string targetAddress, string subject, string body);
    }
}

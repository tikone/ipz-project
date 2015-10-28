namespace TravelAgency.Infrastructure
{
    public static class InfrastructureFactory
    {
        public static IEmailAgent CreateEmailAgent()
        {
            return new EmailAgentFake();
        }
    }
}
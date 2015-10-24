using System;

namespace TravelAgency.Infrastructure
{
    public interface IPaymentAgent
    {
        bool makePaymentTransaction(
                decimal amount,
                string cardCode,
                string cardHolder,
                out int transactionId
        );

        void rollbackTransaction(int transactionId);
    }
}
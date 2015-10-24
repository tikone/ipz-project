using System;

namespace TravelAgency.Infrastructure
{
    class PaymentAgentFake : IPaymentAgent
    {
        public bool makePaymentTransaction(
                decimal amount,
                string cardCode,
                string cardHolder,
                out int transactionId
        )
        {
            transactionId = new Random().Next();

            Console.WriteLine("==== Bank Transaction ====");

            Console.Write("TransactionID = ");
            Console.WriteLine(transactionId);

            Console.Write("Amount = $");
            Console.WriteLine(amount);

            Console.Write("Card Code = ");
            Console.WriteLine(cardCode);

            Console.Write("Card Holder = ");
            Console.WriteLine(cardHolder);

            Console.WriteLine("==== End Bank Transaction ====");
            Console.WriteLine();

            return true;
        }

        public void rollbackTransaction(int transactionId)
        {
            Console.WriteLine("==== Bank Transaction Rollback  ====");

            Console.Write("TransactionID = ");
            Console.WriteLine(transactionId);

            Console.WriteLine("==== End Bank Transaction Rollback ====");
            Console.WriteLine();
        }
    }
}
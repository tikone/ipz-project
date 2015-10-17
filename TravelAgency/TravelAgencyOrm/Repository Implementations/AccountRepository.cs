using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    class AccountRepository
        : BasicRepository< Account >
        , IAccountRepository
    {
        public AccountRepository( TravelAgencyDbContext dbContext )
            : base( dbContext, dbContext.Accounts )
        {
        }
    }
}

using System;
using System.Linq;

using TravelAgencyModel;

namespace TravelAgencyOrm
{
    class ExcursionRepository
        : BasicRepository< Excursion >
        , IExcursionRepository
    {
        public ExcursionRepository( TravelAgencyDbContext dbContext )
            : base( dbContext, dbContext.Excursions )
        {
        }
    }
}

namespace TravelAgencyOrm
{
    public static class RepositoryFactory
    {
        public static IAccountRepository createAccountRepository( TravelAgencyDbContext dbContext )
        {
            return new AccountRepository( dbContext );
        }

        public static IAirlineRepository createAirlineRepository( TravelAgencyDbContext dbContext )
        {
            return new AirlineRepository( dbContext );
        }

        public static ICustomerRepository createCustomerRepository( TravelAgencyDbContext dbContext )
        {
            return new CustomerRepository( dbContext );
        }

        public static IExcursionRepository createExcursionRepository( TravelAgencyDbContext dbContext )
        {
            return new ExcursionRepository( dbContext );
        }

        public static IHotelRepository createHotelRepository( TravelAgencyDbContext dbContext )
        {
            return new HotelRepository( dbContext );
        }

        public static ITourRepository createTourRepository( TravelAgencyDbContext dbContext )
        {
            return new TourRepository( dbContext );
        }

        public static IRoomRepository createRoomRepository( TravelAgencyDbContext dbContext )
        {
            return new RoomRepository( dbContext );
        }

        public static ITicketRepository createTicketRepository( TravelAgencyDbContext dbContext )
        {
            return new TicketRepository( dbContext );
        }
    }
}

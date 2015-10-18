namespace TravelAgencyOrm
{
    public static class RepositoryFactory
    {
        public static IAccountRepository CreateAccountRepository( TravelAgencyDbContext dbContext )
        {
            return new AccountRepository( dbContext );
        }

        public static IAirlineRepository CreateAirlineRepository( TravelAgencyDbContext dbContext )
        {
            return new AirlineRepository( dbContext );
        }

        public static ICustomerRepository CreateCustomerRepository( TravelAgencyDbContext dbContext )
        {
            return new CustomerRepository( dbContext );
        }

        public static IExcursionRepository CreateExcursionRepository( TravelAgencyDbContext dbContext )
        {
            return new ExcursionRepository( dbContext );
        }

        public static IHotelRepository CreateHotelRepository( TravelAgencyDbContext dbContext )
        {
            return new HotelRepository( dbContext );
        }

        public static ITourRepository CreateTourRepository( TravelAgencyDbContext dbContext )
        {
            return new TourRepository( dbContext );
        }

        public static IRoomRepository CreateRoomRepository( TravelAgencyDbContext dbContext )
        {
            return new RoomRepository( dbContext );
        }

        public static ITicketRepository CreateTicketRepository( TravelAgencyDbContext dbContext )
        {
            return new TicketRepository( dbContext );
        }

        public static ITourOrderRepository CreateTourOrderRepository(TravelAgencyDbContext dbContext)
        {
            return new TourOrderRepository(dbContext);
        }
    }
}

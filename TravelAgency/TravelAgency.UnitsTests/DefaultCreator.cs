using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TravelAgencyModel;

namespace TravelAgency.UnitsTests
{
    public static class DefaultCreator
    {
        static Int32 customerId = 0;

        #region Account

        public static Account createAccount(
                String _login = @"test_login"
            ,   String _mail = @"test.mail@gmail.ua"
        )
        {
            return
                new Account(
                        1
                    ,   _login
                    ,   _mail
                    ,   12345
                );
        }

        #endregion

        #region Hotel

            public static Hotel createHotel(
                    HotelType _type = HotelType.FiveStar
                ,   Int32 _numberOfRooms = 10
            )
            {
                return
                    new Hotel(
                            @"Test"
                        ,   @"Test_street"
                        ,   _type
                        ,   createRooms( _numberOfRooms )
                    );
            }

            public static HashSet< Room > createRooms( Int32 _number = 1 )
            {
                var rooms = new HashSet< Room >();

                for( int i = 0; i < _number; ++i )
                    rooms.Add( createRoom( i ) );

                return rooms;
            }

            public static Room createRoom( Int32 _number )
            {
                var generatorNumber = new Random();

                return
                    new Room(
                            _number
                        ,   generatorNumber.Next( 1, 4 )
                        ,   BedType.Single
                        ,   RoomType.Luxury
                    );
            }

        #endregion

        #region Excursion

            public static Excursion createExursion( DateTime _dateTime )
            {
                var generatorNumber = new Random();

                return
                    new Excursion(
                            @"test_excursion"
                        ,   generatorNumber.Next( 100, 1000 )
                        , _dateTime
                    );
            }

            public static Guide createGuide(
                String _language = @"Ukrainian"
            )
            {
                var guide =
                    new Guide(
                            @"Test_Guide"
                        ,    _language
                        ,   12345678
                    );

                guide.AddLanguage( @"English" );

                return guide;
            }

        #endregion

        #region Airline

            public static Airline createAirline(
                    Int32 _numberOfTickets = 100
                ,   String _name = @"test_airline" 
            )
            {
                var airline = new Airline(_name);

                var baseDate = createDateTime();
                for( Int32 i = 0; i < _numberOfTickets; ++i )
                {
                    var departure = baseDate.AddDays( i );
                    var ticket =
                        createTicket(
                                departure
                            ,   baseDate.AddWeeks()
                        );

                    airline.AddTicket( ticket );
                }

                return airline;

            }

            public static Ticket createTicket(
                    DateTime _departure
                ,   DateTime _arrival
                ,   TicketType _type = TicketType.BusinessClass
            )
            {
                return
                    new Ticket(
                            _departure
                        ,   _arrival
                        ,   "test_flight"
                        ,   "UA"
                        ,   _type
                    );
            }

        #endregion

        #region DateTime

            public static DateTime createDateTime(
                       Int32 _year = 2015
                   , Int32 _month = 7
                   , Int32 _day = 17
                )
            {
                return new DateTime(_year, _month, _day);
            }

        #endregion

        #region Customer

            public static Customer createCustomer(
                    String _name = @"Test_John"
                ,   String _surname = @"Test_Doe"
            )
            {
                return new Customer( _name, _surname );
            }

            public static Customer createRegistrateCustomer()
            {
                var customer = new Customer(@"Test_John", @"Test_Doe");

                customer.Registrate(
                        ++customerId
                    ,   @"test_log"
                    ,   @"test.mail@gmail.ua"
                    ,   0
                );

                return customer;
            }

        #endregion

        #region Tour

            public static Tour createTour(
                    String _country = @"UA"
                ,   String _description = @"description"
            )
            {
                return new Tour( _country, _description, TourType.Beer);
            }

        #endregion

        #region TourOrder

            public static TourOrder createTourOrder(
                    Tour _tour
                ,   Customer _customer
                ,   Double _price = 999.9
                ,   Int32 _amountPeople = 1
            )
            {
                return
                    new TourOrder(
                            _tour
                        ,   createDateTime()
                        ,   _price
                        ,   _customer
                        ,   _amountPeople
                    );
            }

        #endregion

    }
}

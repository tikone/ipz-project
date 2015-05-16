using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using TravelAgencyModel;

namespace TravelAgency.UnitsTests
{

    [ TestFixture ]
    class TourTest
    {
        //[ Test ]
        //public void CreateTour()
        //{
        //    var tour = DefaultCreator.createTour();
        //
        //}

        #region AddExcursion

            [ Test ]
            public void AddExcursion_AddOneExcursion()
            {
                var tour = DefaultCreator.createTour();

                var excursion =
                    DefaultCreator.createExursion(
                        DefaultCreator.createDateTime()
                    );

                tour.AddExcursion(
                    excursion
                );

                Assert.IsTrue( tour.GetExcursion().Contains( excursion ) );

            }

            [Test]
            public void AddExcursion_AddFewExcursion()
            {
                var tour = DefaultCreator.createTour();

                var excursion1 =
                    DefaultCreator.createExursion(
                        DefaultCreator.createDateTime()
                    );

                var excursion2 =
                    DefaultCreator.createExursion(
                        DefaultCreator.createDateTime()
                );

                tour.AddExcursion(
                    excursion1
                );

                tour.AddExcursion(
                    excursion2
                );

                Assert.IsTrue(tour.GetExcursion().Contains(excursion1));
                Assert.IsTrue(tour.GetExcursion().Contains(excursion2));

            }

            [Test]
            public void AddExcursion_TwiceAddOneExcursion()
            {
                var tour = DefaultCreator.createTour();

                var excursion =
                    DefaultCreator.createExursion(
                        DefaultCreator.createDateTime()
                    );

                tour.AddExcursion( excursion );

                Assert.Throws< Exception >(
                    () => tour.AddExcursion( excursion )
                );
            }

        #endregion

        #region ReserveRoom

            [ Test ]
            public void ReserveNullRoom()
            {
                var tour = DefaultCreator.createTour();

                Room room = null;

                Assert.Throws< Exception >(
                    () => tour.ReserveRoom( room )
                );

            }

            [Test]
            public void ReserveOneRoom()
            {
                var tour = DefaultCreator.createTour( DefaultCreator.createHotel() );

                var room = tour.Hotel.NotReservedRoom()[ 0 ];

                tour.ReserveRoom( room );

                Assert.IsTrue( room.Reserved );

            }

            [Test]
            public void ReserveFewRooms()
            {
                var tour = DefaultCreator.createTour(DefaultCreator.createHotel());

                var avalibleRooms = tour.Hotel.NotReservedRoom();

                tour.ReserveRoom( avalibleRooms[ 0 ] );
                tour.ReserveRoom( avalibleRooms[ 1 ] );

                Assert.IsTrue( avalibleRooms[ 0 ].Reserved );
                Assert.IsTrue( avalibleRooms[ 1 ].Reserved );
            }

            [Test]
            public void ReserveRoomOfAnotherHotel()
            {
                var tour = DefaultCreator.createTour(DefaultCreator.createHotel());

                var secondHotel =
                    new Hotel(
                            @"another"
                        ,   @"address"
                        ,   HotelType.FiveStar
                        ,   DefaultCreator.createRooms( 2 )
                    );

                var room = secondHotel.NotReservedRoom()[0];

                Assert.Throws< Exception >(
                    () => tour.ReserveRoom(room)
                );
            }

            [Test]
            public void TwiceReserveOneRoom()
            {
                var tour = DefaultCreator.createTour(DefaultCreator.createHotel());

                var room = tour.Hotel.NotReservedRoom()[0];

                tour.ReserveRoom(room);

                Assert.Throws< Exception >(
                    () => tour.ReserveRoom(room)
                );

            }

        #endregion

        #region ReserveTicket

            [Test]
            public void ReserveNullTicket()
            {
                var tour = DefaultCreator.createTour();

                Ticket ticket = null;

                Assert.Throws<Exception>(
                    () => tour.ReserveTicket( ticket )
                );

            }

            [Test]
            public void ReserveOneTicket()
            {
                var tour = DefaultCreator.createTour();

                var ticket = tour.Airline.GetAvailableTicket()[ 0 ];

                tour.ReserveTicket( ticket );
                Assert.IsTrue( ticket.Reserved );
            }

            [Test]
            public void ReserveFewTickets()
            {
                var tour = DefaultCreator.createTour();

                var ticket1 = tour.Airline.GetAvailableTicket()[0];

                var ticket2 = tour.Airline.GetAvailableTicket()[1];

                tour.ReserveTicket( ticket1 );
                tour.ReserveTicket( ticket2 );
                Assert.IsTrue( ticket1.Reserved && ticket2.Reserved );
            }

            [Test]
            public void ReserveTicketOfAnotherAirline()
            {
                var tour = DefaultCreator.createTour();

                var airline = DefaultCreator.createAirline( 2 );

                var ticket = airline.GetAvailableTicket()[ 0 ];

                Assert.Throws< Exception >(
                    () => tour.ReserveTicket( ticket )
                );
            }

            [Test]
            public void TwiceReserveOneTicket()
            {
                var tour = DefaultCreator.createTour();

                var ticket = tour.Airline.GetAvailableTicket()[0];

                tour.ReserveTicket( ticket );
                Assert.Throws< Exception >(
                    () => tour.ReserveTicket( ticket )
                );
            }

        #endregion


        #region AddHotel

            [Test, Ignore]
            public void addHotel()
            {
                var hotel = DefaultCreator.createHotel();

                var tour = DefaultCreator.createTour( hotel, 322, 2 );

                Assert.AreSame( tour.Hotel, hotel );
            }

        #endregion
    }
}

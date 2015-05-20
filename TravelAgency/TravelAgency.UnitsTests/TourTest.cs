using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using TravelAgencyModel;

using NSubstitute;

namespace TravelAgency.UnitsTests
{

    [ TestFixture ]
    class TourTest
    {

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

                tour.AddExcursion(excursion);

                Assert.Throws<ArgumentException>(
                    () => tour.AddExcursion(excursion)
                );
            }

            [Test]
            public void AddExcursion_DateInTourLessThenDateOfExcursions()
            {
                var tour = DefaultCreator.createTour();

                var excursion =
                    DefaultCreator.createExursion(
                        DefaultCreator.createDateTime()
                    );

                tour.AddExcursion( excursion );
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
                    () => tour.ReserveRoom( room )
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

            [Test]
            public void CountryInReservedTicketIsEqualCountryInTour()
            {
                var tour = DefaultCreator.createTour();

                var ticket = tour.Airline.GetAvailableTicket()[0];
                Assert.AreEqual(ticket.ArrivalCountry, tour.Country);
                Assert.DoesNotThrow(
                    () => tour.ReserveTicket( ticket )
                );
            }

            [Test]
            public void CountryInReservedTicketIsNotEqualCountryInTour()
            {
                var tour = DefaultCreator.createTour( null, 1000, @"UK" );
                var depart = DefaultCreator.createDateTime( 2000, 2, 2 );
                var arrive = DefaultCreator.createDateTime( 2200, 2, 2 );
                var ticket = DefaultCreator.createTicket( depart, arrive );

                Assert.AreNotEqual(ticket.ArrivalCountry, tour.Country);
                Assert.Throws< ArgumentException >(
                    () => tour.ReserveTicket( ticket )
                );
            }

        #endregion

        #region Fields

            [Test]
            public void CheckCountry()
            {
                var tour = DefaultCreator.createTour();

                Assert.AreSame( tour.Country, @"UA" );
            }

            [Test]
            public void EmptyCountryFieldIsForbidden()
            {
                Assert.Throws<ArgumentException>(
                   () => DefaultCreator.createTour( null, 500, "" )
               );

            }

            [Test]
            public void CheckDate()
            {       
                var tour = DefaultCreator.createTour();

                Assert.AreEqual( tour.Date_Time, DefaultCreator.createDateTime() );
            }

            [Test]
            public void ChangeDate()
            {
                var tour = DefaultCreator.createTour();
                var date = DefaultCreator.createDateTime( 2015, 5, 17 );
                tour.Date_Time = date;

                Assert.AreEqual( tour.Date_Time, date );
            }

            [Test]
            public void AddHotel()
            {
                var hotel = DefaultCreator.createHotel();

                var tour = DefaultCreator.createTour( hotel, 322 );

                Assert.AreEqual(tour.Hotel, hotel);
            }

            [Test]
            public void InitiallyDefaultValueAmountOfPeople()
            {
                var tour = DefaultCreator.createTour();

                Assert.AreEqual( tour.AmountPeople, 1 );
            }

            [Test]
            public void ChangeAmmounOfPeopleToNonPositive()
            {
                var tour = DefaultCreator.createTour();

                Assert.Throws<ArgumentException>(
                   () => tour.AmountPeople = -1
               );

            }

            [Test]
            public void ChangeAmountPeople()
            {
                var tour = DefaultCreator.createTour();
                tour.AmountPeople = 2;

                Assert.AreEqual( tour.AmountPeople, 2 );
            }

            [Test]
            public void SendingTour()
            {
                var tour = DefaultCreator.createTour();

                var mockHandler = Substitute.For<EventHandler>();
                tour.SendingTour += mockHandler;

                tour.SendTourForOperator();

                mockHandler.Received(1).Invoke( tour, EventArgs.Empty );
            }

        #endregion
    }
}

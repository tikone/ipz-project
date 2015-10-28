using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using TravelAgencyModel;

using NSubstitute;

namespace TravelAgency.UnitsTests
{

    [TestFixture]
    class TourOrderTest
    {

        #region AddExcursion

            [ Test ]
            public void AddExcursion_AddOneExcursion()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                        DefaultCreator.createTour()
                    ,   DefaultCreator.createCustomer() );

                var excursion =
                    DefaultCreator.createExursion( DefaultCreator.createDateTime() );

                tourOrder.AddExcursion( excursion );

                Assert.IsTrue( tourOrder.GetExcursion().Contains( excursion ) );

            }

            [Test]
            public void AddExcursion_AddFewExcursion()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                    DefaultCreator.createTour()
                ,   DefaultCreator.createCustomer() );

                Excursion excursion1 =
                    DefaultCreator.createExursion( DefaultCreator.createDateTime() );

                Excursion excursion2 =
                    DefaultCreator.createExursion( DefaultCreator.createDateTime() );

                tourOrder.AddExcursion( excursion1 );
                tourOrder.AddExcursion( excursion2 );

                Assert.IsTrue( tourOrder.GetExcursion().Contains( excursion1 ) );
                Assert.IsTrue( tourOrder.GetExcursion().Contains( excursion2 ) );

            }

            [Test]
            public void AddExcursion_TwiceAddOneExcursion()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                        DefaultCreator.createTour()
                    ,   DefaultCreator.createCustomer() );

                Excursion excursion =
                    DefaultCreator.createExursion( DefaultCreator.createDateTime() );

                tourOrder.AddExcursion( excursion );

                Assert.Throws<ArgumentException>(
                    () => tourOrder.AddExcursion(excursion)
                );
            }

            [Test]
            public void AddExcursion_DateInTourLessThenDateOfExcursions()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                    DefaultCreator.createTour()
                ,   DefaultCreator.createCustomer() );

                var excursion =
                    DefaultCreator.createExursion(
                        DefaultCreator.createDateTime()
                    );

                tourOrder.AddExcursion(excursion);
            }

        #endregion

        /*#region ReserveRoom

            [ Test ]
            public void ReserveNullRoom()
            {
                var tourOrder = DefaultCreator.createTourOrder(DefaultCreator.createTour());

                Room room = null;

                Assert.Throws< Exception >(
                    () => tourOrder.ReserveRoom(room)
                );

            }

            [Test]
            public void ReserveOneRoom()
            {
                var tourOrder = DefaultCreator.createTourOrder(DefaultCreator.createTour());

                //var room = tourOrder.Hotel.NotReservedRoom()[0];

                //tourOrder.ReserveRoom(room);

                Assert.IsTrue( false /*room.Reserved* );

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

        #endregion*/

        #region Fields

            [Test]
            public void CheckDate()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                        DefaultCreator.createTour()
                    ,   DefaultCreator.createCustomer() );

                Assert.AreEqual(tourOrder.Date_Time, DefaultCreator.createDateTime());
            }

            [Test]
            public void ChangeDate()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                        DefaultCreator.createTour()
                    ,   DefaultCreator.createCustomer() );

                var date = DefaultCreator.createDateTime( 2015, 5, 17 );
                tourOrder.Date_Time = date;

                Assert.AreEqual(tourOrder.Date_Time, date);
            }

            /*
            [Test]
            public void AddHotel()
            {
                var hotel = DefaultCreator.createHotel();

                var tour = DefaultCreator.createTour( hotel, 322 );

                Assert.AreEqual(tour.Hotel, hotel);
            }*/

            [Test]
            public void InitiallyDefaultValueAmountOfPeople()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                    DefaultCreator.createTour()
                ,   DefaultCreator.createCustomer() );

                Assert.AreEqual(tourOrder.AmountPeople, 1);
            }

            [Test]
            public void ChangeAmmounOfPeopleToNonPositive()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                    DefaultCreator.createTour()
                ,   DefaultCreator.createCustomer() );

                Assert.Throws<ArgumentException>(
                   () => tourOrder.AmountPeople = -1
               );

            }

            [Test]
            public void ChangeAmountPeople()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                    DefaultCreator.createTour()
                ,   DefaultCreator.createCustomer() );

                tourOrder.AmountPeople = 2;

                Assert.AreEqual(tourOrder.AmountPeople, 2);
            }

            [Test]
            public void SendingTour()
            {
                var tourOrder = DefaultCreator.createTourOrder(
                    DefaultCreator.createTour()
                ,   DefaultCreator.createCustomer() );

                var mockHandler = Substitute.For< EventHandler >();
                tourOrder.SendingTour += mockHandler;

                tourOrder.SendTourForOperator();

                mockHandler.Received(1).Invoke(tourOrder, EventArgs.Empty);
            }

        #endregion
    }
}

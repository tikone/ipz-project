using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using TravelAgencyModel;
using TravelAgencyController.Controller;

namespace TravelAgencyDemoApp
{
    class Program
    {
        static void Main( string[] args )
        {
            FillTestModel();

            DisplayTours();

            CreateTestOrder1();

            CreateTestOrder2();

            DisplayTourOrders();

        }

        private static void FillTestModel()
        {
            using( var controller = ControllerFactory.CreateManageTourController() )
            {
                AddBeerTour( controller );
                AddBeachTour(controller);
            }
        }

        private static void AddBeerTour ( IManageTourController _controller )
        {
            _controller.CreateNewTour(
                    @"UA"
                ,   @"best tour EU"
                ,   TourType.Beer
            );

        }

        private static void AddBeachTour(IManageTourController _controller)
        {
            _controller.CreateNewTour(
                    @"UA"
                ,   @"nice tour"
                ,   TourType.Beach
            );

        }


        private static void CreateTestOrder1()
        {
            using( var controller = ControllerFactory.CreateOrderController() )
            {
                var manageController = ControllerFactory.CreateManageTourController();

                var tour = manageController.GetAllToursLINQ().Where(
                    _tour => _tour.Country.Equals( @"UA" ) && _tour.Description.Equals( @"best tour EU" )
                );

                controller.CreateNewTourOrder(
                        tour.First().TourID
                    ,   new DateTime(2015, 5, 12)
                    ,   999.99
                );

            }
        }

        private static void CreateTestOrder2()
        {
            using (var controller = ControllerFactory.CreateOrderController())
            {
                var manageController = ControllerFactory.CreateManageTourController();

                var tour = manageController.GetAllToursLINQ().Where(
                    _tour => _tour.Country.Equals(@"UA") && _tour.Description.Equals(@"nice tour")
                );

                controller.CreateNewTourOrder(
                        tour.First().TourID
                    , new DateTime(2015, 9, 12)
                    , 339.99
                );

            }
        }

        private static void DisplayTours()
        {
            using( var manageController = ControllerFactory.CreateManageTourController() )
            {
                ReportGenerator generator = new ReportGenerator( Console.Out );

                foreach( var tour in manageController.GetAllTours() )
                    generator.ShowTour( tour );

            }
        }

        private static void DisplayTourOrders()
        {
            using (var manageController = ControllerFactory.CreateOrderController())
            {
                ReportGenerator generator = new ReportGenerator(Console.Out);

                foreach (var tour in manageController.GetAllOrders() )
                    generator.ShowTourOrder(tour);

            }
        }

       private TravelAgency travelAgency = new TravelAgency();
    }
}

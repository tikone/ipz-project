using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TravelAgencyModel;
using TravelAgencyController.Controller;
using TravelAgencyController.ViewModel;

namespace TravelAgencyWebApp.Controllers
{
    public class ManageTourController : Controller
    {
        public ManageTourController()
        {
            manageTourController = ControllerFactory.CreateManageTourController();
        }

        // GET: /ManageTour/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTour(TourView _viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    manageTourController.CreateNewTour(
                            _viewModel.Country
                        ,   _viewModel.Description
                        ,   ( TourType ) Enum.Parse( typeof( TourType ), _viewModel.Type, true ) 
                    );
                }
                catch( Exception _ex )
                {
                    TempData["errorMessage"] = _ex.Message;
                    ViewBag.Tours = manageTourController.ViewAllTours();
                    return View( _viewModel );
                }

                //return Index();
                return Redirect("/ManageTour/_TourCreated");
            }
            ViewBag.Tours = manageTourController.ViewAllTours();
            return View(_viewModel);
        }
        
        private IManageTourController manageTourController;
	}
}
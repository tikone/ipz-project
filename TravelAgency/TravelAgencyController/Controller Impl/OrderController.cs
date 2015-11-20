using System;
using System.Linq;
using System.Collections.Generic;

using TravelAgencyModel;
using TravelAgencyOrm;
using TravelAgencyController.ViewModel;
using TravelAgencyController.Notifier;
using TravelAgency.Infrastructure;

namespace TravelAgencyController.Controller
{
    class OrderController : BasicController, IOrderController
    {
        public OrderController()
        {
            this.m_orderRepository = RepositoryFactory.CreateTourOrderRepository( GetDBContext() );
            this.emailNotifier = new EmailNotifier( InfrastructureFactory.CreateEmailAgent() );
        }

        public TourOrder[] GetAllOrders()
        {
            return m_orderRepository.LoadAll().ToArray();
        }

        public ICollection< TourOrderView > ViewAllTourOrders()
        {
            var query = m_orderRepository.LoadAll();
            return ViewModelsFactory.BuildViewModels(query, ViewModelsFactory.BuildTourOrderView);
        }

        public void CreateNewTourOrder(
                Int32 _id
            ,   DateTime _dateTime
            ,   Double _price
            ,   Customer _customer
            ,   Int32 _amountPeople
        )
        {
            using( var tourController = ControllerFactory.CreateManageTourController() )
            {
                var order = new TourOrder(
                        tourController.GetTour( _id )
                    ,   _dateTime
                    ,   _price
                    ,   _customer
                    ,   _amountPeople
                );
                m_orderRepository.Add( order );
                m_orderRepository.Commit();

                emailNotifier.SendOrderRegistered( order );
            }

        }

        public void UpdateDateTime(Int32 _id, DateTime _dateTime)
        {
            TourOrder tourOrder = FindObjectById<TourOrder>( m_orderRepository, _id );
            FindObjectById< TourOrder >( m_orderRepository, _id ).Date_Time = _dateTime;
            m_orderRepository.Commit();

            emailNotifier.SendDateChanged( tourOrder );
        }

        public void DropOrder(Int32 _id)
        {
            TourOrder tourOrder = FindObjectById<TourOrder>(m_orderRepository, _id);
            m_orderRepository.Remove( tourOrder );
            m_orderRepository.Commit();

            emailNotifier.SendOrderCancelled( tourOrder );

        }

        private ITourOrderRepository m_orderRepository;
        private EmailNotifier emailNotifier;
    }
}

using System;
using System.Linq;

using TravelAgencyModel;
using TravelAgencyOrm;

namespace TravelAgencyController.Controller
{
    class OrderController : BasicController, IOrderController
    {
        public OrderController()
        {
            this.m_orderRepository = RepositoryFactory.CreateTourOrderRepository(GetDBContext());
        }

        public TourOrder[] GetAllOrders()
        {
            return m_orderRepository.LoadAll().ToArray();
        }

        public void CreateNewTourOrder(
                Int32 _id
            , DateTime _dateTime
            , Double _price
            , Int32 _amountPeople
        )
        {
            using( var tourController = ControllerFactory.CreateManageTourController() )
            {
                var order = new TourOrder(
                        tourController.GetTour( _id )
                    ,   _dateTime
                    ,   _price
                    ,   _amountPeople
                );
                m_orderRepository.Add( order );
                m_orderRepository.Commit();
            }

        }

        public void UpdateDateTime(Int32 _id, DateTime _dateTime)
        {
            FindObjectById< TourOrder >( m_orderRepository, _id ).Date_Time = _dateTime;
            m_orderRepository.Commit();
        }

        public void DropOrder(Int32 _id)
        {
            m_orderRepository.Remove( FindObjectById( m_orderRepository, _id ) );
            m_orderRepository.Commit();
        }

        private ITourOrderRepository m_orderRepository;

    }
}

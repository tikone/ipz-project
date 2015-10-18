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
                Tour _tour
            , DateTime _dateTime
            , Double _price
            , Int32 _amountPeople
        )
        {
            var order = new TourOrder( _tour, _dateTime, _price, _amountPeople );
            m_orderRepository.Add( order );

        }

        public void UpdateDateTime(Int32 _id, DateTime _dateTime)
        {
            FindObjectById< TourOrder >( m_orderRepository, _id ).Date_Time = _dateTime;
        }

        public void DropOrder(Int32 _id)
        {
            m_orderRepository.Remove( FindObjectById( m_orderRepository, _id ) );
        }

        private ITourOrderRepository m_orderRepository;

    }
}

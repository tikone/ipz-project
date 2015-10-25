﻿using System;
using System.Linq;
using System.Collections.Generic;

using TravelAgencyModel;
using TravelAgencyOrm;

namespace TravelAgencyController.Controller
{
    class ManageTourController : BasicController, IManageTourController
    {
        public ManageTourController()
        {
            this.m_tourRepository = RepositoryFactory.CreateTourRepository( GetDBContext() );
        }

        public Tour[] GetAllTours()
        {
            return m_tourRepository.LoadAll().ToArray();
        }

        public List< Tour > GetAllToursLINQ()
        {
            return m_tourRepository.LoadAll().ToList();
        }

        public Tour GetTour( Int32 _id )
        {
            return m_tourRepository.LoadAll().Where( tour => tour.TourID == _id ) as TravelAgencyModel.Tour;
        }

        public Int32 CreateNewTour(
                String _country
            ,   String _description
            ,   TourType _type
        )
        {
            Tour tour = new Tour( _country, _description, _type );
            m_tourRepository.Add( tour );
            m_tourRepository.Commit();
            return tour.TourID;

        }

        public void UpdateCountry(Int32 _id, String _country)
        {
            Tour tour = FindObjectById( m_tourRepository, _id );

            tour.Country = _country;
            m_tourRepository.Commit();
        }

        public void UpdateDescription(Int32 _id, String _description)
        {
            Tour tour = FindObjectById(m_tourRepository, _id);

            tour.Description = _description;
            m_tourRepository.Commit();
        }

        public void UpdateType(Int32 _id, TourType _type)
        {
            Tour tour = FindObjectById(m_tourRepository, _id);

            tour.Type = _type;
            m_tourRepository.Commit();
        }

        private ITourRepository m_tourRepository;
    }
}

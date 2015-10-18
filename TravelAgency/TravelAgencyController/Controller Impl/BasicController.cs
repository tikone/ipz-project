using System;

using TravelAgencyOrm;

namespace TravelAgencyController.Controller
{
    class BasicController
    {

        protected TravelAgencyDbContext GetDBContext ()
        {
            if( m_dbContext == null )
                m_dbContext = new TravelAgencyDbContext();

            return m_dbContext;

        }

        public void Dispose ()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose ( bool _disposing )
        {
            if ( _disposing && m_dbContext != null )
                m_dbContext.Dispose();
        }

        public static T FindObjectById< T >( 
              IRepository< T > _repository
            , int _objectID
        )
            where T : class
        {
            T result = _repository.Load( _objectID );
            if (result == null)
                throw new SystemException(
                      typeof(T).Name
                    + " with #" 
                    + _objectID 
                    + " could't find in database"
                );

            return result;
        }

        private TravelAgencyDbContext m_dbContext;

    }
}

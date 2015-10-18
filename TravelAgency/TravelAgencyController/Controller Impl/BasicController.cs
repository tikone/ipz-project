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

        private TravelAgencyDbContext m_dbContext;

    }
}

using System;
using System.Data.Entity;
using System.Linq;

namespace TravelAgencyOrm
{
    class BasicRepository< T >
        where T : class
    {
        protected BasicRepository( TravelAgencyDbContext dbContext, DbSet<T> dbSet)
        {
            this.dbContext = dbContext;
            this.dbSet     = dbSet;
        }

        protected TravelAgencyDbContext GetDBContext()
        {
            return this.dbContext;
        }

        protected DbSet GetDBSet ()
        {
            return this.dbSet;
        }

        public void Add ( T obj )
        {
            dbSet.Add( obj );
        }

        public void Commit ()
        {
            dbContext.ChangeTracker.DetectChanges();
            dbContext.SaveChanges();
        }

        public IQueryable< T > LoadAll ()
        {
            return dbSet;
        }

        public T Load ( int id )
        {
            return dbSet.Find( id );
        }

        private TravelAgencyDbContext dbContext;
        private DbSet< T > dbSet;
    }
}
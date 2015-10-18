using System;
using System.Linq;

using System.Data.Entity;

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

        public void Remove( T obj )
        {
            dbSet.Remove( obj );
        }

        public void Commit ()
        {
            dbContext.ChangeTracker.DetectChanges();
            dbContext.SaveChanges();
        }

        public void RevertChanges()
        {
            foreach ( System.Data.Entity.Infrastructure.DbEntityEntry<  T> entry in 
                dbContext.ChangeTracker.Entries<T>() )
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    default: 
                        break;
                }
            } 
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
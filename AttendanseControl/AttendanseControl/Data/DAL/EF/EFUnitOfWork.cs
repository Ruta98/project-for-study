using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private AttendanseControlContext db;
        private UserRepository osbbRepository;
        private PresenceRepository streetRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new AttendanseControlContext(options);
        }
        public IRepository<User> Users
        {
            get
            {
                if (osbbRepository == null)
                    osbbRepository = new UserRepository(db);
                return osbbRepository;
            }
        }
        
        public IRepository<Presence> Streets
        {
            get
            {
                if (streetRepository == null)
                    streetRepository = new PresenceRepository(db);
                
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        
        private bool disposed = false;
        
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

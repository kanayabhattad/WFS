using WFS.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WFS.WebApi.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        readonly ApplicationDbContext _dbContext = new ApplicationDbContext();


        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }



        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeTierArchPractice.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

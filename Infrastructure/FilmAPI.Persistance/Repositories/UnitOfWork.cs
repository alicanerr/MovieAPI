using FilmAPI.Application.Abstraction;
using FilmAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Persistance.Repositories
{
    public class UnitOfWork : IGenericUnitOfWork
    {
        private readonly MovieAPIDbContext _context;

        public UnitOfWork(MovieAPIDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

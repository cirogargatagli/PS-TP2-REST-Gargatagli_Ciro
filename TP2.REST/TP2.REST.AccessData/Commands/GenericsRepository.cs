using System;
using TP2.REST.Domain.Commands;

namespace TP2.REST.AccessData.Commands
{
    public class GenericsRepository : IGenericRepository
    {
        private readonly BibliotecaContext dbcontext;
        public GenericsRepository (BibliotecaContext context)
        {
            dbcontext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            dbcontext.Add(entity);
            dbcontext.SaveChanges();
        }
    }
}
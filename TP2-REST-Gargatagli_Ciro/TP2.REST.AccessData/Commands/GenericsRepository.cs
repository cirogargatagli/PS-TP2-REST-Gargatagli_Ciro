using System.Collections.Generic;
using TP2.REST.Domain.Interfaces.Commands;

namespace TP2.REST.AccessData.Commands
{
    public class GenericsRepository : IGenericRepository
    {
        private readonly BibliotecaContext dbcontext;

        public GenericsRepository(BibliotecaContext context)
        {
            dbcontext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            dbcontext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            dbcontext.Update(entity);
        }

        public void UpdateRange<T>(List<T> entitys) where T : class
        {
            dbcontext.UpdateRange(entitys);
        }

        public void SaveChanges()
        {
            dbcontext.SaveChanges();
        }
    }
}
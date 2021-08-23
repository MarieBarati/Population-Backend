using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;

namespace WebApplication2.Data.Repo
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public ICountryRepository countryRepository => 
            new CountryRepository(dataContext);

        public async Task<bool> SaveAsync()
        {
          return  await dataContext.SaveChangesAsync()>0;
        }
    }
}

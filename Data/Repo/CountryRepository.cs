using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Data.Repo
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext dataContext;

        public CountryRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddCountry(Country country)
        {
            dataContext.Countries.Add(country);
        }

        public void DeleteCounry(int CountryId)
        {
            var country = dataContext.Countries.Find(CountryId);
            dataContext.Countries.Remove(country);
        }

        public async Task<Country> FindCountry(int Id)
        {
            return await dataContext.Countries.FindAsync(Id);
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
           return await dataContext.Countries.ToListAsync();
        }

    }
}

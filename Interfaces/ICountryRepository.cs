using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        void AddCountry(Country country);
        void DeleteCounry(int CountryId);
        Task<Country> FindCountry(int Id);

    }
}

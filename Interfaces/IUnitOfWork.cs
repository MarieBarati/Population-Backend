using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
   public interface IUnitOfWork
    {
        ICountryRepository countryRepository { get; }
        Task<bool> SaveAsync();
    }
}

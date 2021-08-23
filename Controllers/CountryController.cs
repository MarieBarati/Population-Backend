
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication2.Dtoes;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CountryController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountreis()
        {
            var countries = await unitOfWork.countryRepository.GetCountries();
            return Ok(countries);
        }
        [HttpPost("add/{country}")]
        [HttpPost("post")]
        public async Task<IActionResult> AddCountry(CountryDto countryDto)
        {
            var country = mapper.Map<Country>(countryDto);
             unitOfWork.countryRepository.AddCountry(country);
            await unitOfWork.SaveAsync();
            return StatusCode(201);

        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            unitOfWork.countryRepository.DeleteCounry(id);            
            await unitOfWork.SaveAsync();
            return Ok(id);

        }


    }
}


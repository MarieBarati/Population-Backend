
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCountry(int id,CountryDto countryDto)
        {
            var country_db = await unitOfWork.countryRepository.FindCountry(id);
            mapper.Map(countryDto, country_db);
            await unitOfWork.SaveAsync();
            return Ok(200);

        }
        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCountrypatch(int id, JsonPatchDocument<Country> countryToPatch)
        {
            var country_db = await unitOfWork.countryRepository.FindCountry(id);
            
            countryToPatch.ApplyTo(country_db, ModelState);
            await unitOfWork.SaveAsync();
            return Ok(200);

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


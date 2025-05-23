using Microsoft.AspNetCore.Mvc;
using Shopping_API_Jueves_práctica.DAL.Entities;
using Shopping_API_Jueves_práctica.Domain.Interfaces;

namespace Shopping_API_Jueves_práctica.Controllers
{
    [Route("Api/[controller]")] //Este es el nombre inicial de mi ruta, url o path
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCoutriesAsync()
        {
            var countries = await _countryService.GetCoutriesAsync();

            if (countries == null || !countries.Any())
            {
                return NotFound();
            }

            return Ok(countries);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByID/{id}")] //url: api/countries/get
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);

            if (country == null)
            {
                return NotFound(); //Status code 404
            }

            return Ok(country); // 200
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);
                if (newCountry == null) return NotFound();
                return Ok(newCountry);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("ya existe", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);
                if (editedCountry == null) return NotFound();   
                return Ok(editedCountry);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("ya existe", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteountryAsync(Guid id)
        {
               
           
                var deletedCountry = await _countryService.DeleteCountryAsync(id);
                if (deletedCountry == null) return NotFound();
                return Ok(deletedCountry);
            
    
        }

    }
}

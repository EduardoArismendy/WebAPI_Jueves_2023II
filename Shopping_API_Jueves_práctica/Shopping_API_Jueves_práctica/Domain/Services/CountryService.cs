using Microsoft.EntityFrameworkCore;
using Shopping_API_Jueves_práctica.DAL.Entities;
using Shopping_API_Jueves_práctica.Domain.Interfaces;

namespace Shopping_API_Jueves_práctica.Domain.Services
{
    public class CountryService : ICountryService
    {
        //Conexión a DB _Context
        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }


        //Service o metodos
        public  async Task<Country> CreateCountryAsync(Country country)
        {
           
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country); // add crea el objeto en DB // Guardado virtual

                await _context.SaveChangesAsync(); //Guarda el pais // Guardado físico

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);
                if (country == null)
                {
                    return null;
                }

                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;

                _context.Countries.Update(country); //Virtualizar el objeto

                await _context.SaveChangesAsync(); //Guardo

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            

            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id); //Si no encuentra trae objeto
                                                                                             //Otras dos formas de traer un objeto desde DB
                var country2 = await _context.Countries.FindAsync(id);
                var country3 = await _context.Countries.FirstAsync(c => c.Id == id); //Si no trae null

                return country;
            }
            catch(DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public  async Task<IEnumerable<Country>> GetCoutriesAsync()
        {
            try
            {
                var countries = await _context.Countries
                      .Include(c => c.States)
                      .ToListAsync();

                return countries;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
    }
}

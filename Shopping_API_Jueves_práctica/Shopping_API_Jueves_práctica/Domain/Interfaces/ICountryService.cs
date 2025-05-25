using Shopping_API_Jueves_práctica.DAL.Entities;

namespace Shopping_API_Jueves_práctica.Domain.Interfaces
{
    public interface ICountryService
    {

        //Firmas de un método
        Task <IEnumerable<Country>> GetCoutriesAsync();

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryByIdAsync(Guid id);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);


    }
}

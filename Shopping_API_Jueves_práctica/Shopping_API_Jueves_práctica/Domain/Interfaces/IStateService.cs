using Shopping_API_Jueves_práctica.DAL.Entities;

namespace Shopping_API_Jueves_práctica.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesAsync();

        Task<State> CreateStateAsync(State state);

        Task<State> GetStateByIdAsync(Guid id);

        Task<State> EditStateAsync(State state);

        Task<State> DeleteStateAsync(Guid id);
    }

}

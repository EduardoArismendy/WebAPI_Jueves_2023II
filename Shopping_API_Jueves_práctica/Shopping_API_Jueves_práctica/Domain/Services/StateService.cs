using Microsoft.EntityFrameworkCore;
using Shopping_API_Jueves_práctica.DAL.Entities;
using Shopping_API_Jueves_práctica.Domain.Interfaces;

namespace Shopping_API_Jueves_práctica.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;

        public StateService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                _context.States.Add(state);

                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                                    dbUpdateException.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await GetStateByIdAsync(id);
                if (state == null)
                {
                    return null;
                }

                _context.States.Remove(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                                    dbUpdateException.Message);
            }
        }

        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _context.States.Update(state);

                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                                    dbUpdateException.Message);
            }
        }

        public async Task<State> GetStateByIdAsync(Guid id)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(s => s.Id == id);
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                                    dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            try
            {
                var states = await _context.States.ToListAsync();
                return states;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                                    dbUpdateException.Message);
            }
        }
    }

}

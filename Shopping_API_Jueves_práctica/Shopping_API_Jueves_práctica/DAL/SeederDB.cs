using Shopping_API_Jueves_práctica.DAL.Entities;

namespace Shopping_API_Jueves_práctica.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //Crearemos un método llamado SeederAsync
        //Este método es una especie de MAIN()
        // Este método tendrá la responsabilidad de repoblar mis diferentes tablas de la DB.

        public  async Task SeederAsync()
        {
            //Primero: Agregarpe un metodo propio de EF que hace las veces del comando "update-database"

            await _context.Database.EnsureCreatedAsync();

            //A partir de aqui vamos a ir creando métodos que me sirvan para repoblar mi DB

            await PopulateCountriesAsync();

            await _context.SaveChangesAsync(); // Guarda los datos


        }

        #region Private Methos

        private async Task PopulateCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State 
                        { 
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        
                        },

                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"

                        },
                    }
                });

                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "España",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Madrid"

                        },

                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Torre vieja"

                        },
                    }
                });
            }
        }

        #endregion
    }
}

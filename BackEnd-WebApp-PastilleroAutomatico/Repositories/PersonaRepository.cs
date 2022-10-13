using BackEnd_WebApp_PastilleroAutomatico.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Persona> AddPersona(Persona persona)
        {

            _context.Add(persona);

            await _context.SaveChangesAsync();

            return persona;
        }

        public async Task DeletePersona(Persona persona)
        {
            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Persona>> GetListPersona()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task<Persona> GetPersona(int id)
        {
            return await _context.Persona.FindAsync(id);
        }

        public async Task UpdatePersona(Persona persona)
        {
            var personaItem = await _context.Persona.FirstOrDefaultAsync(x => x.Id == persona.Id);

            if (personaItem != null)
            {
                personaItem.nombrePersona = persona.nombrePersona;
                personaItem.apellidoPersona = persona.apellidoPersona;
                personaItem.fechaNacimientoPersona = persona.fechaNacimientoPersona;

                _context.Update(personaItem);

                await _context.SaveChangesAsync();
            }
        }
    }
}

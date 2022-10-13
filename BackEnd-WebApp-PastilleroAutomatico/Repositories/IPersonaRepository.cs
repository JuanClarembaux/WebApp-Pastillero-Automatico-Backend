using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetListPersona();
        Task<Persona> GetPersona(int id);
        Task DeletePersona(Persona persona);
        Task<Persona> AddPersona(Persona persona);
        Task UpdatePersona(Persona persona);
    }
}

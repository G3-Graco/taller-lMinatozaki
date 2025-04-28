using Core.Entities;
namespace Core.Interfaces.Services
{
    public interface IUbicacionService : IBaseService<Ubicacion>
    {
        Task<string> Moverse(int idPersonaje, int nuevaUbicacionId);
    }
}
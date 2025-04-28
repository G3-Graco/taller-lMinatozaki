using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IEquipoService : IBaseService<Equipo>
    {
        Task<Equipo> Equipar(int equipoId, int objetoId);
        Task<Equipo> Desequipar(int equipoId, int ranuraId);
    }
}
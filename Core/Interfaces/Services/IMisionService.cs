using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IMisionService : IBaseService<Mision>
    {
        Task<Mision> AceptarMision(int misionId);
        Task<Mision> IndicarProgresoMision(int misionId, string nuevoObjetivo);
        Task<Mision> CompletarMision(int misionId);
    }
}
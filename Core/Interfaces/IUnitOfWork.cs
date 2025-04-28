using Core.Interfaces.Repositories;
namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
    {
        IPersonajeRepository PersonajeRepository { get; }
        IHabilidadRepository HabilidadRepository { get; }
        IEnemigoRepository EnemigoRepository { get; }
        IEquipoRepository EquipoRepository { get; }
        IMisionRepository MisionRepository { get; }
        IObjetoRepository ObjetoRepository { get; }
        IUbicacionRepository UbicacionRepository { get; }
        ITipoPersonajeRepository TipoPersonajeRepository { get; }
        ITipoEstadisticaRepository TipoEstadisticaRepository { get; }
        IEstadisticaRepository EstadisticaRepository { get; }
        IRanuraRepository RanuraRepository { get; }
        ITipoObjetoRepository TipoObjetoRepository { get; }

    Task<int> CommitAsync();
    }
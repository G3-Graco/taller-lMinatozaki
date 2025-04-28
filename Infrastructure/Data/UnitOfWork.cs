using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private PersonajeRepository  _personajeRepository;
        private HabilidadRepository  _habilidadRepository;
        private EnemigoRepository _enemigoRepository;
        private EquipoRepository _equipoRepository;
        private MisionRepository _misionRepository;
        private ObjetoRepository _objetoRepository;
        private UbicacionRepository _ubicacionRepository;
        private TipoPersonajeRepository _tipoPersonajeRepository;
        private TipoEstadisticaRepository _tipoEstadisticaRepository;
        private TipoObjetoRepository _tipoObjetoRepository;
        private EstadisticaRepository _estadisticaRepository;
        private RanuraRepository _ranuraRepository;
        private PersonajeMisionRepository _personajeMision;
        private ObjetivoRepository _objetivoRepository;
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IPersonajeRepository PersonajeRepository => _personajeRepository ??= new PersonajeRepository(_context);
        public IHabilidadRepository HabilidadRepository => _habilidadRepository ??= new HabilidadRepository(_context);
        public IEnemigoRepository EnemigoRepository => _enemigoRepository ??= new EnemigoRepository(_context);  
        public IEquipoRepository EquipoRepository => _equipoRepository ??= new EquipoRepository(_context);   
        public IMisionRepository MisionRepository => _misionRepository ??= new MisionRepository(_context);
        public IObjetoRepository ObjetoRepository => _objetoRepository ??= new ObjetoRepository(_context);
        public IUbicacionRepository UbicacionRepository => _ubicacionRepository ??= new UbicacionRepository(_context);
        public ITipoPersonajeRepository TipoPersonajeRepository => _tipoPersonajeRepository ??= new TipoPersonajeRepository(_context);
        public ITipoEstadisticaRepository TipoEstadisticaRepository => _tipoEstadisticaRepository ??= new TipoEstadisticaRepository(_context);
        public ITipoObjetoRepository TipoObjetoRepository => _tipoObjetoRepository ??= new TipoObjetoRepository(_context);
        public IEstadisticaRepository EstadisticaRepository => _estadisticaRepository ??= new EstadisticaRepository(_context);
        public IRanuraRepository RanuraRepository => _ranuraRepository ??= new RanuraRepository(_context);
        public IPersonajeMisionRepository PersonajeMisionRepository => _personajeMision ??= new PersonajeMisionRepository(_context);
        public IObjetivoRepository ObjetivoRepository => _objetivoRepository ??= new ObjetivoRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EquipoRepository : BaseRepository<Equipo>, IEquipoRepository
    {
        public EquipoRepository(AppDbContext context) : base(context){}
    }
}
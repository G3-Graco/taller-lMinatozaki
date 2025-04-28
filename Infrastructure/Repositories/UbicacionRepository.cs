using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UbicacionRepository: BaseRepository<Ubicacion>, IUbicacionRepository
    {
        public UbicacionRepository(AppDbContext context) : base(context) {}
    }
}
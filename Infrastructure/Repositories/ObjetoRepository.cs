using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ObjetoRepository: BaseRepository<Objeto>, IObjetoRepository
    {
        public ObjetoRepository(AppDbContext context) : base(context){}
    }
}
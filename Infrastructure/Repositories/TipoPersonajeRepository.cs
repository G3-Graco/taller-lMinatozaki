using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TipoPersonajeRepository : BaseRepository<TipoPersonaje>, ITipoPersonajeRepository
    {
        public TipoPersonajeRepository(AppDbContext context) : base(context) { }

    }

}

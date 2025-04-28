using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonajeMisionRepository : BaseRepository<PersonajeMision>, IPersonajeMisionRepository
    {
        public PersonajeMisionRepository(AppDbContext context) : base(context) { }

        

    }
}

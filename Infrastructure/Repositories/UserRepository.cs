using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {

    }

    public async ValueTask<User> GetUser(string username, string password = null)
    {
        return await base.dbSet.FirstOrDefaultAsync(user => user.UserName == username);
    }
    
    //esto es viejo pero me sirve de referencia
    public virtual async ValueTask<User> Login(string username, string password)
    {
        return await dbSet.Where(u => u.UserName.Equals(username) && u.Password.Equals(password)).FirstOrDefaultAsync();
    }

}
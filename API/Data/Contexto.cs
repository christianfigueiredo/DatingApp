using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { }

        public DbSet<AppUser> Users {get; set;}        
    }
    

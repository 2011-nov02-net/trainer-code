using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SimpleStore.DataModel.Model
{
    public class AppDbContext : DbContext
    {
        // dbsets for my tables
        // (if there's some dbset you won't use directly, you can leave it out here)

        // onmodelcreating override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}

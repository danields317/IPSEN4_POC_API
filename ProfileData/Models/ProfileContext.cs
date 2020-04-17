using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProfileData.Models.ModelConfigurations;

namespace ProfileData.Models
{
    public class ProfileContext : DbContext
    {

        public ProfileContext(DbContextOptions<ProfileContext> options)
            :base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //builder.ApplyConfiguration(new ProfileConfiguration());
        //}

        public DbSet<Profile> profile { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProfileData.Models.ModelConfigurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(prop => prop.profile_id);
            builder.Property(prop => prop.first_name);
            builder.Property(prop => prop.enabled);
        }
    }
}

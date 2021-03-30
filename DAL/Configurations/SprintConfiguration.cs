using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlannerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerApi.DAL.Configurations
{
    public class SprintConfiguration: IEntityTypeConfiguration<Sprint>
    {
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            builder
                .HasMany(s => s.Tasks)
                .WithOne(t => t.Sprint);
        }
    }
}

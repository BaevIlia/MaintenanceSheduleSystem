﻿using MaintenanceSheduleSystem.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceSheduleSystem.Persistance.Configurations
{
    public class HandbookEntityConfiguration : IEntityTypeConfiguration<HandbookEntity>
    {
        public void Configure(EntityTypeBuilder<HandbookEntity> builder)
        {
            builder.HasKey(h => h.Id);

            builder.HasOne(h => h.MachineArea)
                .WithMany(ma => ma.Handbooks)
                .HasForeignKey(h => h.AreaId);

            builder.HasMany(h => h.Equipments)
                .WithMany(eq => eq.Handbooks)
                .UsingEntity<HandbookEquipmentEntity>();
            
        }
    }
}

﻿using Demo.DataAccess.Models.DepartmentModels;

namespace Demo.DataAccess.Data.Configurations
{
    internal class DepartmentConfiguration :BaseConfiguration<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
           builder.Property(d=>d.Id).UseIdentityColumn(10,10);

           builder.Property(d=>d.Name).HasColumnType("varchar(20)");

           builder.Property(d=>d.Code).HasColumnType("varchar(20)");


            builder.HasMany(d => d.Employees).WithOne(d=>d.Department).HasForeignKey(emp=>emp.DepartmentId).OnDelete(DeleteBehavior.SetNull);


            base.Configure(builder);

        }
    }
}

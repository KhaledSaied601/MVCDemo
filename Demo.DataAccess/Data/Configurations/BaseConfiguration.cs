using Demo.DataAccess.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configurations
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {

            //If Row Is Inserted WithOut Value , Default Value will be Used
            //On Insert 
            //Can't Reference Other Columns
            //Can Be Overriden
            builder.Property(t => t.CreatedOn).HasDefaultValueSql("GETDATE()");



            //Value Is Computed Every Time The Record Changed
            //On Update
            //Can Reference Other Columns
            //Can't Be Overriden
            builder.Property(t => t.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}

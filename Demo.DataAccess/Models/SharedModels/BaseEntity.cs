using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Models.SharedModels
{
    public class BaseEntity
    {
        public int Id { get; set; }//PK
        public int CreatedBy { get; set; }//UserId
        public DateTime? CreatedOn { get; set; }

        public int LastModifiedBy { get; set; }//UserId

        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }//Flag For Sot Delete

    }
}

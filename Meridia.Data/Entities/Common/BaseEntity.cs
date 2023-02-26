using System;
namespace Meridia.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}


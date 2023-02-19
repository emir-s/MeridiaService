using System;
namespace Meridia.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset LastUpdatedDate { get; set; }
    }
}


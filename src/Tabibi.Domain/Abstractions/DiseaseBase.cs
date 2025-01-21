using Tabibi.Domain.Shared.Entities;

namespace Tabibi.Domain.Abstractions
{
    public abstract class DiseaseBase : FullAuditedEntity
    {
        public string Name { get; protected set; }
        public Guid PatientId { get; protected set; }

        public virtual void Update(string name, Guid userId)
        {
            Name = name;
            LastModifiedAt = DateTime.UtcNow;
            LastModifiedBy = userId;
        }
    }
}

namespace Tabibi.Domain.Shared.Entities
{
    public abstract class FullAuditedEntity
    {
        public Guid Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }
        public Guid? CreatedBy { get; protected set; }

        public DateTime? LastModifiedAt { get; protected set; }
        public Guid? LastModifiedBy { get; protected set; }

        public bool IsDeleted { get; protected set; }
        public Guid? DeletedBy { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }

        protected FullAuditedEntity()
        {
            Id = Guid.CreateVersion7();
            IsDeleted = false;
        }

        public void Delete(Guid deleterId)
        {
            IsDeleted = true;
            DeletedAt = DateTime.Now;
            DeletedBy = deleterId;
        }
    }

}

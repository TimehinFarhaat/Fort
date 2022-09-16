namespace Fort.Contract
{
    public class Auditable_entity:base_Entity,Iauditable_entity,IsoftDelete
    {
        public int CreatedBy { get; set; }


        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


        public int LastModifiedBy { get; set; }


        public DateTime? LastModifiedOn { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedOn { get; set; }
        
        public DateTime?  LoggedInTime { get; set; }
        public DateTime?  LoggedOutTime { get; set; }
        public DateTime?  PreviousLoggedInTime { get; set; }

        public int? DeletedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}

using System;
using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema
{
    [Table(Name = "sys.objects")]
    public class BaseObject : BaseEntity 
    { 
        [Column(Name = "name")]  
        public string Name;

        [Column(Name = "object_id")] 
        public int Id;
        
        [Column(Name = "parent_object_id")] 
        public int ParentId;

        [Column(Name = "type")] 
        public string Type;
        
        [Column(Name = "create_date")] 
        public DateTime CreationDate;    
        
        [Column(Name = "modify_date")] 
        public DateTime ModificationDate;

        [Column(Name = "is_ms_shipped")]
        public bool IsSystem;
    }
}

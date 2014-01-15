using System;
using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name = "sys.tables")]
    public class SysTable 
    { 
        [Column(Name = "name")]  
        public string Name;  
        
        [Column(Name = "object_id")] 
        public int Id;  
        
        [Column(Name = "create_date")] 
        public DateTime CreationDate;  
        
        [Column(Name = "modify_date")] 
        public DateTime ModifyDate;  
        
        [Column(Name = "is_ms_shipped")] 
        public bool IsSystem;  
        
        [Column(Name = "schema_id")] 
        public int SchemaId; 
        
        public override string ToString() 
        { 
            return Name; 
        }
    }


}

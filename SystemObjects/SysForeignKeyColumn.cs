using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name = "sys.foreign_key_columns")]
    public class SysForeignKeyColumn
    {
        [Column(Name = "constraint_object_id", DbType = "int")]
        public int ConstraintObjectId { get; set; }

        [Column(Name = "constraint_column_id", DbType = "int")]
        public int ConstraintColId { get; set; }

        [Column(Name = "parent_object_id", DbType = "int")]
        public int ParentObjectId { get; set; }

        [Column(Name = "parent_column_id", DbType = "int")]
        public int ParentColId { get; set; }

        [Column(Name = "referenced_object_id", DbType = "int")]
        public int RefObjectId { get; set; }

        [Column(Name = "referenced_column_id", DbType = "int")]
        public int RefeColId { get; set; }

    }
}

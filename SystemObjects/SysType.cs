using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name = "sys.types")]
    public class SyType
    {
        [Column(Name = "name", CanBeNull = false, DbType = "nvarchar(256)")]
        public string Name { get; set; }

        [Column(Name = "system_type_id", DbType = "tinyint")]
        public int SystemTypeId { get; set; }

        [Column(Name = "user_type_id", DbType = "int")]
        public int UserTypeId { get; set; }

        [Column(Name = "schema_id", DbType = "int")]
        public int SchemaId { get; set; }

        [Column(Name = "principal_id", DbType = "int")]
        public int? PrincipalId { get; set; }
        [Column(Name = "max_length", DbType = "smallint")]
        public int MaxLength { get; set; }

        [Column(Name = "precision", DbType = "tinyint")]
        public int Precision { get; set; }

        [Column(Name = "scale", DbType = "tinyint")]
        public int Scale { get; set; }

        [Column(Name = "collation_name", DbType = "nvarchar(256)")]
        public string CollationName { get; set; }

        [Column(Name = "is_nullable", DbType = "bit")]
        public bool? IsNullable { get; set; }

        [Column(Name = "is_user_defined", DbType = "bit")]
        public bool IsUserDefined { get; set; }

        [Column(Name = "is_assembly_type", DbType = "bit")]
        public bool IsAssemblyType { get; set; }

        [Column(Name = "default_object_id", DbType = "int")]
        public int DefaultObjectId { get; set; }

        [Column(Name = "rule_object_id", DbType = "int")]
        public int RuleObjectId { get; set; }

        [Column(Name = "is_table_type", DbType = "bit")]
        public bool IsTableType { get; set; }

    }
}

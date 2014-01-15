using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name = "sys.sql_expression_dependencies")]
    public class SysSqlExpressionDependencies
    {
        [Column(Name = "referencing_id", DbType = "int")]
        public int ReferencingId { get; set; }
        [Column(Name = "referencing_minor_id", DbType = "int")]
        public int ReferencingMinorId { get; set; }
        [Column(Name = "referencing_class", DbType = "tinyint")]
        public int? ReferencingClass { get; set; }
        [Column(Name = "referencing_class_desc", DbType = "nvarchar(120)")]
        public string ReferencingClassDesc { get; set; }
        [Column(Name = "is_schema_bound_reference", DbType = "bit")]
        public bool IsSchemaBoundReference { get; set; }
        [Column(Name = "referenced_class", DbType = "tinyint")]
        public int? ReferencedClass { get; set; }
        [Column(Name = "referenced_class_desc", DbType = "nvarchar(120)")]
        public string ReferencedClassDesc { get; set; }
        [Column(Name = "referenced_server_name", DbType = "nvarchar(256)")]
        public string ReferencedServerName { get; set; }
        [Column(Name = "referenced_database_name", DbType = "nvarchar(256)")]
        public string ReferencedDatabaseName { get; set; }
        [Column(Name = "referenced_schema_name", DbType = "nvarchar(256)")]
        public string ReferencedSchemaName { get; set; }
        [Column(Name = "referenced_entity_name", DbType = "nvarchar(256)")]
        public string ReferencedEntityName { get; set; }
        [Column(Name = "referenced_id", DbType = "int")]
        public int? ReferencedId { get; set; }
        [Column(Name = "referenced_minor_id", DbType = "int")]
        public int ReferencedMinorId { get; set; }
        [Column(Name = "is_caller_dependent", DbType = "bit")]
        public bool IsCallerDependent { get; set; }
        [Column(Name = "is_ambiguous", DbType = "bit")]
        public bool IsAmbiguous { get; set; }
    }
}

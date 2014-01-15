using System;
using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name = "sys.system_views")]
    public class SysSystemViews
    {
        [Column(Name = "name", CanBeNull = false, DbType = "nvarchar(256)")]
        public string Name { get; set; }

        [Column(Name = "object_id", DbType = "int")]
        public int ObjectId { get; set; }

        [Column(Name = "principal_id", DbType = "int")]
        public int? PrincipalId { get; set; }

        [Column(Name = "schema_id", DbType = "int")]
        public int SchemaId { get; set; }

        [Column(Name = "parent_object_id", DbType = "int")]
        public int ParentObjectId { get; set; }

        [Column(Name = "type", CanBeNull = false, DbType = "char(2)")]
        public string Type { get; set; }

        [Column(Name = "type_desc", DbType = "nvarchar(120)")]
        public string TypeDesc { get; set; }

        [Column(Name = "create_date", DbType = "datetime")]
        public DateTime DateCreated { get; set; }

        [Column(Name = "modify_date", DbType = "datetime")]
        public DateTime DateModified { get; set; }

        [Column(Name = "is_ms_shipped", DbType = "bit")]
        public bool IsSystem { get; set; }

        [Column(Name = "is_published", DbType = "bit")]
        public bool IsPublished { get; set; }

        [Column(Name = "is_schema_published", DbType = "bit")]
        public bool IsSchemaPublished { get; set; }

        [Column(Name = "is_replicated", DbType = "bit")]
        public bool IsReplicated { get; set; }

        [Column(Name = "has_replication_filter", DbType = "bit")]
        public bool HasReplicationFilter { get; set; }

        [Column(Name = "has_opaque_metadata", DbType = "bit")]
        public bool HasOpaqueMetadata { get; set; }

        [Column(Name = "has_unchecked_assembly_data", DbType = "bit")]
        public bool HasUncheckedAssemblyData { get; set; }

        [Column(Name = "with_check_option", DbType = "bit")]
        public bool WithCheckOption { get; set; }

        [Column(Name = "is_date_correlation_view", DbType = "bit")]
        public bool IsDateCorrelationView { get; set; }

        [Column(Name = "is_tracked_by_cdc", DbType = "bit")]
        public bool IsTrackedByCDC { get; set; }
    }
}

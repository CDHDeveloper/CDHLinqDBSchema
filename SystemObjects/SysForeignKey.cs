using System;
using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name = "sys.foreign_keys")]
    public class SysForeignKey
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

        [Column(Name = "ype_desc", DbType = "nvarchar(120)")]
        public string TypeDescription { get; set; }

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

        [Column(Name = "referenced_object_id", DbType = "int")]
        public int? RefeObjectId { get; set; }

        [Column(Name = "key_index_id", DbType = "int")]
        public int? KeyIndexId { get; set; }

        [Column(Name = "is_disabled", DbType = "bit")]
        public bool IsDisabled { get; set; }

        [Column(Name = "is_not_for_replication", DbType = "bit")]
        public bool NotForReplication { get; set; }

        [Column(Name = "is_not_trusted", DbType = "bit")]
        public bool NotTrusted { get; set; }

        [Column(Name = "delete_referential_action", DbType = "tinyint")]
        public int? DelRefAction { get; set; }


        [Column(Name = "delete_referential_action_desc", DbType = "nvarchar(120)")]
        public string DeleRefActionDesc { get; set; }

        [Column(Name = "update_referential_action", DbType = "tinyint")]
        public int? UpdateRefAction { get; set; }

        [Column(Name = "update_referential_action_desc", DbType = "nvarchar(120)")]
        public string UpdateRefActionDesc { get; set; }

        [Column(Name = "is_system_named", DbType = "bit")]
        public bool IsSystemNamed { get; set; }
    }
}

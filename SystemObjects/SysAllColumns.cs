using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name = "sys.all_columns")]
    public class SysAllColumns
    {
        [Column(Name = "object_id", DbType = "int")]
        public int ObjectId { get; set; }

        [Column(Name = "name", DbType = "nvarchar(256)")]
        public string Name { get; set; }

        [Column(Name = "column_id", DbType = "int")]
        public int ColumnId { get; set; }

        [Column(Name = "system_type_id", DbType = "tinyint")]
        public int SysTypeId { get; set; }

        [Column(Name = "user_type_id", DbType = "int")]
        public int UserTypeId { get; set; }

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

        [Column(Name = "is_ansi_padded", DbType = "bit")]
        public bool IsAnsiPadded { get; set; }

        [Column(Name = "is_rowguidcol", DbType = "bit")]
        public bool IsRowGuidCol { get; set; }

        [Column(Name = "is_identity", DbType = "bit")]
        public bool IsIdentity { get; set; }

        [Column(Name = "is_computed", DbType = "bit")]
        public bool IsComputed { get; set; }

        [Column(Name = "is_filestream", DbType = "bit")]
        public bool IsFilestream { get; set; }

        [Column(Name = "is_replicated", DbType = "bit")]
        public bool? IsReplicated { get; set; }

        [Column(Name = "is_non_sql_subscribed", DbType = "bit")]
        public bool? IsNonSqlSubscribed { get; set; }

        [Column(Name = "is_merge_published", DbType = "bit")]
        public bool? IsMergePublished { get; set; }

        [Column(Name = "is_dts_replicated", DbType = "bit")]
        public bool? IsDTSReplicated { get; set; }

        [Column(Name = "is_xml_document", DbType = "bit")]
        public bool IsXmlDocument { get; set; }

        [Column(Name = "xml_collection_id", DbType = "int")]
        public int XmlCollectionId { get; set; }

        [Column(Name = "default_object_id", DbType = "int")]
        public int DefaultObjectId { get; set; }

        [Column(Name = "rule_object_id", DbType = "int")]
        public int RuleObjectId { get; set; }

        [Column(Name = "is_sparse", DbType = "bit")]
        public bool? IsSparse { get; set; }

        [Column(Name = "is_column_set", DbType = "bit")]
        public bool? IsColumnSet { get; set; }

    }
}

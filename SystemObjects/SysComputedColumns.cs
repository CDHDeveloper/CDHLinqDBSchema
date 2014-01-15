using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
	[Table(Name="sys.computed_columns")]
    public class SysComputedColumns
    {
        public int ObjectId { get; set; }

        public string Name { get; set; }

        [Column(Name = "column_id", DbType = "Int NOT NULL")]
        private int ColumnId { get; set; }

        [Column(Name = "system_type_id", DbType = "TinyInt NOT NULL")]
        private byte SystemTypeId { get; set; }

        [Column(Name="user_type_id", DbType = "Int NOT NULL")]
        private int UserTypeId { get; set; }

        [Column(Name="max_length", DbType = "SmallInt NOT NULL")]
        private short MaxLength { get; set; }

        [Column(Name="precision", DbType = "TinyInt NOT NULL")]
        private byte Precision { get; set; }

        [Column(Name="scale", DbType = "TinyInt NOT NULL")]
        private byte Scale { get; set; }

        [Column(Name="collation_name", DbType = "NVarChar(128)")]
        private string CollationName { get; set; }

        [Column(Name="is_nullable", DbType = "Bit")]
        private bool? IsNullable { get; set; }

        [Column(Name="is_ansi_padded", DbType = "Bit NOT NULL")]
        private bool IsAnsiPadded { get; set; }

        [Column(Name="is_rowguidcol", DbType = "Bit NOT NULL")]
        private bool IsRowGuidCol { get; set; }

        [Column(Name = "is_identity", DbType = "Bit NOT NULL")]
        private bool IsIdentity { get; set; }

        [Column(Name="is_filestream", DbType = "Bit NOT NULL")]
        private bool IsFilestream { get; set; }

        [Column(Name="is_replicated", DbType = "Bit")]
        private bool? IsReplicated { get; set; }

        [Column(Name="is_non_sql_subscribed", DbType = "Bit")]
        private bool? IsNonSqlSubscribed { get; set; }

        [Column(Name="is_merge_published", DbType = "Bit")]
        private bool? IsMergePublished { get; set; }

        [Column(Name="is_dts_replicated", DbType = "Bit")]
        private bool? IsDTSReplicated { get; set; }

        [Column(Name="is_xml_document", DbType = "Bit NOT NULL")]
        private bool IsXmlDocument { get; set; }

        [Column(Name="xml_collection_id", DbType = "Int NOT NULL")]
        private int XmlCollectionId { get; set; }

        [Column(Name = "default_object_id", DbType = "Int NOT NULL")]
        private int DefaultObjectId { get; set; }

        [Column(Name="rule_object_id", DbType = "Int NOT NULL")]
        private int RuleObjectId { get; set; }

        [Column(Name="definition", DbType = "NVarChar(MAX)")]
        private string Definition { get; set; }

        [Column(Name="uses_database_collation", DbType = "Bit NOT NULL")]
        private bool UsesDatabaseCollation { get; set; }

        [Column(Name="is_persisted", DbType = "Bit NOT NULL")]
        private bool IsPersisted { get; set; }

        [Column(Name="is_computed", DbType = "Bit NOT NULL")]
        private bool IsComputed { get; set; }

        [Column(Name="is_sparse", DbType = "Bit NOT NULL")]
        private bool IsSparse { get; set; }

        [Column(Name="is_column_set", DbType = "Bit NOT NULL")]
        private bool IsColumnSet { get; set; }
    }
}

using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name = "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE")]
    public class InfoSchemaConstraintColumnUsage
    {
        [Column(Name="TABLE_CATALOG", DbType = "NVarChar(128)")]
        public string TableCatalog { get; set; }

        [Column(Name="TABLE_SCHEMA", DbType = "NVarChar(128)")]
        public string TableSchema { get; set; }

        [Column(Name="TABLE_NAME", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
        public string TableName { get; set; }

        [Column(Name="COLUMN_NAME", DbType = "NVarChar(128)")]
        public string ColumnName { get; set; }

        [Column(Name = "CONSTRAINT_CATALOG", DbType = "NVarChar(128)")]
        public string ConstraintCatalog { get; set; }

        [Column(Name="CONSTRAINT_SCHEMA", DbType = "NVarChar(128)")]
        public string ConstraintSchema { get; set; }

        [Column(Name="CONSTRAINT_NAME", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
        public string ConstraintName { get; set; }
    }
}

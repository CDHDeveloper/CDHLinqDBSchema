using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name="INFORMATION_SCHEMA.TABLES")]
    public class InfoSchemaTables
    {
        [Column(Name="TABLE_CATALOG", DbType = "NVarChar(128)")]
        public string TableCatalog { get; set; }

        [Column(Name="TABLE_SCHEMA", DbType = "NVarChar(128)")]
        public string TableSchema { get; set; }

        [Column(Name="TABLE_NAME", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
        public string TableName { get; set; }

        [Column(Name="TABLE_TYPE", DbType = "VarChar(10)")]
        public string TableType { get; set; }
    }
}

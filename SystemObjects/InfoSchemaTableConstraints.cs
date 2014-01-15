using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name="INFORMATION_SCHEMA.TABLE_CONSTRAINTS")]
    public class InfoSchemaTableConstraints
    {
        [Column(Name="CONSTRAINT_CATALOG", DbType = "NVarChar(128)")]
        public string ConstraintCatalog{ get; set; }

        [Column(Name="CONSTRAINT_SCHEMA", DbType = "NVarChar(128)")]
        public string ConstraintSchema{ get; set; }

        [Column(Name="CONSTRAINT_NAME", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
        public string ConstraintName{ get; set; }

        [Column(Name="TABLE_CATALOG", DbType = "NVarChar(128)")]
        public string TableCatalog{ get; set; }

        [Column(Name="TABLE_SCHEMA", DbType = "NVarChar(128)")]
        public string TableSchema{ get; set; }

        [Column(Name="TABLE_NAME", DbType = "NVarChar(128)")]
        public string TableName{ get; set; }

        [Column(Name="CONSTRAINT_TYPE", DbType = "VarChar(11)")]
        public string ConstraintType{ get; set; }

        [Column(Name="IS_DEFERRABLE", DbType = "VarChar(2) NOT NULL", CanBeNull = false)]
        public string IsDeferrable{ get; set; }

        [Column(Name="INITIALLY_DEFERRED", DbType = "VarChar(2) NOT NULL", CanBeNull = false)]
        public string InitiallyDeferred{ get; set; }
    }
}

using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
	[Table(Name="INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS")]
    public class InfoSchemaReferentialConstraint
    {
        [Column(Name = "CONSTRAINT_CATALOG", DbType = "NVarChar(128)")]
        public string ConstraintCatalog { get; set; }

        [Column(Name = "CONSTRAINT_SCHEMA", DbType = "NVarChar(128)")]
        public string ConstraintSchema { get; set; }

        [Column(Name = "CONSTRAINT_NAME", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
        public string ConstraintName { get; set; }

        [Column(Name = "UNIQUE_CONSTRAINT_CATALOG", DbType = "NVarChar(128)")]
        public string UniqueConstraintCatalog { get; set; }

        [Column(Name = "UNIQUE_CONSTRAINT_SCHEMA", DbType = "NVarChar(128)")]
        public string UniqueConstraintSchema { get; set; }

        [Column(Name = "UNIQUE_CONSTRAINT_NAME", DbType = "NVarChar(128)")]
        public string UniqueConstraintName { get; set; }

        [Column(Name = "MATCH_OPTION", DbType = "VarChar(7)")]
        public string MatchOption { get; set; }

        [Column(Name = "UPDATE_RULE", DbType = "VarChar(11)")]
        public string UpdateRule { get; set; }
		
		[Column(Name="DELETE_RULE", DbType="VarChar(11)")]
        public string DeleteRule { get; set; }
        
    }
}

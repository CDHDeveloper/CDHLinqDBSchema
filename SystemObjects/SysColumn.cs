using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name = "sys.columns")]
    public class SysColumn : BaseSingle
    {
        [Column(Name = "object_id")]
        public int ParentId;

        [Column(Name = "name")]
        public string Name;
        /*
        [Column(Name = "TABLE_SCHEMA")]
        public string TableName;

        [Column(Name ="TABLE_NAME")]
        public string TableName;
        */
        [Column(Name = "column_id")]
        public int Id;

        [Column(Name = "user_type_id")]
        public int UserTypeId;

        [Column(Name = "max_length")]
        public short MaxLength;

        [Column(Name = "collation_name")]
        public string Collation;

        [Column(Name = "IS_NULLABLE")]
        public bool IsNullable;

        [Column(Name = "is_identity")]
        public bool IsIdentity;

        [Column(Name = "is_computed")]
        public bool IsComputed;

        [Column(Name = "is_replicated")]
        public bool IsReplicated;
    }
    /*
        SELECT        TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, COLUMN_DEFAULT, IS_NULLABLE, DATA_TYPE, 
                                 CHARACTER_MAXIMUM_LENGTH, CHARACTER_OCTET_LENGTH, NUMERIC_PRECISION, NUMERIC_PRECISION_RADIX, NUMERIC_SCALE, DATETIME_PRECISION, 
                                 CHARACTER_SET_CATALOG, CHARACTER_SET_SCHEMA, CHARACTER_SET_NAME, COLLATION_CATALOG, COLLATION_SCHEMA, COLLATION_NAME, 
                                 DOMAIN_CATALOG, DOMAIN_SCHEMA, DOMAIN_NAME
        FROM            INFORMATION_SCHEMA.COLUMNS
     * */
}

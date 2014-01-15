using System.Data.Linq.Mapping;

namespace CDH.LinqDBSchema.SystemObjects
{
    [Table(Name="INFORMATION_SCHEMA.COLUMNS")]
    public class InfoSchemaColumns
    {
        [Column(Name = "TABLE_SCHEMA")]
        public string TableSchema { get; set; }

        [Column(Name ="TABLE_NAME")]
        public string TableName { get; set; }

        [Column(Name ="TABLE_CATALOG")]
        public string TableCatalog { get; set; }

        [Column(Name ="COLUMN_NAME")]
        public string ColumnName { get; set; }

        [Column(Name ="ORDINAL_POSITION")]
        public int? OrdinalPos { get; set; }

        [Column(Name ="COLUMN_DEFAULT")]
        public string ColumnDefault { get; set; }

        [Column(Name ="IS_NULLABLE")]
        public string IsNullable { get; set; }

        [Column(Name ="DATA_TYPE")]
        public string DataType { get; set; }

        [Column(Name ="CHARACTER_MAXIMUM_LENGTH")]
        public int? CharMaxLen { get; set; }

        [Column(Name ="CHARACTER_OCTET_LENGTH")]
        public int? CharOctetLen { get; set; }

        [Column(Name ="NUMERIC_PRECISION")]
        public byte? NumericPrecision { get; set; }

        [Column(Name ="NUMERIC_PRECISION_RADIX")]
        public short? NumericPrecisionRadix { get; set; }

        [Column(Name ="NUMERIC_SCALE")]
        public int? NumericScale { get; set; }

        [Column(Name ="DATETIME_PRECISION")]
        public short? DateTimePrecision { get; set; }

        [Column(Name ="CHARACTER_SET_CATALOG")]
        public string CharSetCatalog { get; set; }

        [Column(Name ="CHARACTER_SET_SCHEMA")]
        public string CharSetSchema { get; set; }

        [Column(Name ="CHARACTER_SET_NAME")]
        public string CharSetName { get; set; }

        [Column(Name ="COLLATION_CATALOG")]
        public string CollationCatalog { get; set; }

        [Column(Name ="COLLATION_SCHEMA")]
        public string CollationSchema { get; set; }

        [Column(Name ="COLLATION_NAME")]
        public string CollationName { get; set; }

        [Column(Name ="DOMAIN_CATALOG")]
        public string DomainCatalog { get; set; }

        [Column(Name ="DOMAIN_SCHEMA")]
        public string DomainSchema { get; set; }

        [Column(Name ="DOMAIN_NAME")]
        public string DomainName { get; set; }
    }
}

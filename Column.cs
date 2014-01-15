namespace CDH.LinqDBSchema
{
    public class Column
    {
        public int Id { get; set; }

        public string TableName { get; set; }

        public string SchemaName { get; set; }

        public string CatalogName { get; set; }

        public string Name { get; set; }

        public string DBDataType { get; set; }

        public int MaxLength;

        public int Precision { get; set; }

        public int Scale { get; set;  }

        public bool IsNullable { get;  set; }

        public bool IsIdentity { get; set; }

        public bool IsComputed { get; set; }

        public bool IsPrimaryKey { get; set; }
        public string PrimaryKeyName { get; set; }
        public bool IsForeignKey { get; set; }
        public string ForeignKeyName { get; set; }

    }
    /*
        SELECT        TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, COLUMN_DEFAULT, IS_NULLABLE, DATA_TYPE, 
                                 CHARACTER_MAXIMUM_LENGTH, CHARACTER_OCTET_LENGTH, NUMERIC_PRECISION, NUMERIC_PRECISION_RADIX, NUMERIC_SCALE, DATETIME_PRECISION, 
                                 CHARACTER_SET_CATALOG, CHARACTER_SET_SCHEMA, CHARACTER_SET_NAME, COLLATION_CATALOG, COLLATION_SCHEMA, COLLATION_NAME, 
                                 DOMAIN_CATALOG, DOMAIN_SCHEMA, DOMAIN_NAME
        FROM            INFORMATION_SCHEMA.COLUMNS
     * */
}

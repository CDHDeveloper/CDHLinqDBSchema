namespace CDH.LinqDBSchema
{
    public class ForeignKey
    {
        // Info specific to the foreing key
        public string ForeignKeyName { get; set; }
        public string ForeignCatalogName { get; set; }
        public string ForeignSchemaName { get; set; }
        public string ForeignTableName { get; set; }
        public string ForeignColumnName { get; set; }
        public string MatchOption { get; set; }
        public string UpdateRule { get; set; }
        public string DeleteRule { get; set; }

        // Info specific to the Primary Key
        public string PrimaryKeyName { get; set; }
        public string PrimaryCatalogName { get; set; }
        public string PrimarySchemaName { get; set; }
        public string PrimaryTableName { get; set; }
        public string PrimaryColumnName { get; set; }

    }
 
}

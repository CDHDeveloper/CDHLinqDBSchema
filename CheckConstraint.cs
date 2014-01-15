using CDH.LinqDBSchema.Enums;

namespace CDH.LinqDBSchema
{
    public class CheckConstraint
    {
        public string CatalogName { get; set; }
        public string SchemaName { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string ConstraintName { get; set; }
        public ConstraintType ConstraintType { get; set; }
        public bool IsDeferrable { get; set; }
        public bool IsInitiallyDeferred { get; set; }
    }
}

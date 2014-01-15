namespace CDH.LinqDBSchema.Enums
{
    /// <summary>
    /// Enumeration of all sql objects types
    /// </summary>
    public enum ObjectType
    {
        CheckConstraint,
        CLRScalarFunction,
        CLRTableValuedFunction,
        DefaultConstraint,
        ForeignKeyConstraint,
        InternalTable,
        PrimaryKeyConstraint,
        ServiceQueue,
        SqlScalarFunction,
        SqlStoredProcedure,
        SqlTableValuedFunction,
        SqlTrigger,
        SystemTable,
        UniqueConstraint,
        UserTable,
        View
    }

    /// <summary>
    /// Provide a static class with values of sql objects different types
    /// </summary>
    public static class SystemObjectType
    {
        public static string CheckConstraint = "C ";
        public static string CLRScalarFunction = "FS";
        public static string CLRTableValuedFunction = "FT";
        public static string DefaultConstraint = "D ";
        public static string ForeignKeyConstraint = "F ";
        public static string InternalTable = "IT";
        public static string PrimaryKeyConstraint = "PK";
        public static string ServiceQueue = "SQ";
        public static string SqlScalarFunction = "FN";
        public static string SqlStoredProcedure = "P ";
        public static string SqlTableValuedFunction = "TF";
        public static string SqlTrigger = "TR";
        public static string SystemTable = "S ";
        public static string UniqueConstraint = "UQ";
        public static string UserTable = "U ";
        public static string View = "V ";
    }
}

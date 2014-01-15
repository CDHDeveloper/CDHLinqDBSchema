using System.Data.Linq;
using CDH.LinqDBSchema.SystemObjects;
using System.Collections.Generic;

namespace CDH.LinqDBSchema
{
    /// <summary>
    /// The base class for handling the linq connection context to the database
    /// </summary>
    public class DatabaseContext : DataContext
    {
        #region Entities

        public Table<BaseObject> Objects;
        public Table<SysColumn> SysColumns;
        public Table<InfoSchemaColumns> InfoSchemaColumns;
        public Table<InfoSchemaTables> InfoSchemaTables;
        public Table<InfoSchemaTableConstraints> InfoSchemaTableConstaints;
        public Table<InfoSchemaConstraintColumnUsage> InfoSchemaColConstraints;
        public Table<InfoSchemaReferentialConstraint> InfoSchemaReferentialConstraints;

        #endregion

        #region Properties/Fields
        public string ConnectionString { get; set; }
        public Table<Table> Tables;
        public List<Procedure> Procedures { get; set; }
        public List<Function> Functions { get; set; }
        public List<Schema> Schemas { get; set; }
        public List<View> Views { get; set; }
        #endregion

        #region Constructor
        public DatabaseContext(string s) : base(s) 
        {
        }
        #endregion

    }
}

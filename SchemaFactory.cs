using System;
using System.Collections.Generic;
using System.Linq;

namespace CDH.LinqDBSchema
{
    public class SchemaFactory
    {
        #region Members
        public DatabaseContext DataBase { get; set; }
        public List<BaseObject> Objects
        {
            get
            {
                return (
                    from o in DataBase.Objects
                    where !o.IsSystem
                    select o
                    ).ToList();

            }
        }

        public List<Table> Tables
        {
            get
            {
                return (
                    from t in DataBase.Tables
                    select t).ToList();
            }
        }

        public static string ConnectionString { get; set; }
        #endregion

        #region Constructor
        protected SchemaFactory(string connectionString)
        {
            ConnectionString = connectionString;
            DataBase = new DatabaseContext(connectionString);
            foreach (var tbl in DataBase.Tables)
            {
                var name = tbl.Name;
                var schemaName = DataBase.InfoSchemaTables.Single(t => t.TableName == name).TableSchema;
                tbl.FillInSchema(schemaName);
            }

        }

        private static SchemaFactory _instance;
        public static SchemaFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (ConnectionString == null)
                    {
                        throw new Exception("Must provide Connection string to Schema Factory");    
                    }
                    _instance = new SchemaFactory(ConnectionString);
                }
                return _instance;
            }
        }
        #endregion

        #region Methods

        public static SchemaFactory CreateSchemaFactory(string connectionString)
        {
            _instance = new SchemaFactory(connectionString);
            return _instance;
        }
        public List<Table> GetTables()
        {
            return (
                from t in DataBase.Tables
                select t
                ).ToList();
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using CDH.LinqDBSchema.SystemObjects;

namespace CDH.LinqDBSchema
{
    [Table(Name = "sys.tables")]
    public class Table 
    { 
        [Column(Name = "name")]  
        public string Name;  
        
        [Column(Name = "object_id")] 
        public int Id;  
        
        [Column(Name = "create_date")] 
        public DateTime CreationDate;  
        
        [Column(Name = "modify_date")] 
        public DateTime ModifyDate;  
        
        [Column(Name = "is_ms_shipped")] 
        public bool IsSystem;  
        
        [Column(Name = "schema_id")] 
        public int SchemaId;


        public List<CheckConstraint> CheckConstraints { get; set; }

        private string _schemaName;
        public string SchemaName
        {
            get { return _schemaName ?? (_schemaName = GetSchema()); }
            set { _schemaName = value; }
        }

        private List<Column> _columns;
        public List<Column> Columns 
        {
            get { return _columns ?? (_columns = GetColumns()); }
            set { _columns = value; }
        }

        private List<PrimaryKey> _primaryKeys;
        public List<PrimaryKey> PrimaryKeys 
        {
            get { return _primaryKeys ?? (_primaryKeys = GetPrimaryKeys()); }
            set { _primaryKeys = value; }
        } 

        private List<ForeignKey> _foreignKeys;
        public List<ForeignKey> ForeignKeys
        {
            get { return _foreignKeys ?? (_foreignKeys = GetForeignKeys()); }
            set { _foreignKeys = value; }
        }

        private List<HasMany> _HasManys;
        public List<HasMany> HasManys
        {
            get { return _HasManys ?? (_HasManys = GetHasManys()); }
            set { _HasManys = value; }
        }

        public Table()
        {
        }

        public Table(string name) 
        {
            Name = name;
            Columns = GetColumns();
            PrimaryKeys = GetPrimaryKeys();
            ForeignKeys = GetForeignKeys();
            HasManys = GetHasManys();
        }

        private string GetSchema()
        {
            var infoSchemaTable = SchemaFactory.Instance.DataBase.InfoSchemaTables.Single(t => t.TableName == Name);
            return infoSchemaTable.TableSchema;
        }

        public List<Column> GetColumns()
        {
            // Get the SysColumn info for the columns in this table
            var query1 =
                from c in SchemaFactory.Instance.DataBase.SysColumns
                join c2 in SchemaFactory.Instance.DataBase.InfoSchemaColumns on c.Name equals c2.ColumnName
                where c.ParentId == Id && c2.TableName == Name
                select new Column 
                    {
                        Name = c.Name,
                        TableName = c2.TableName,
                        SchemaName = c2.TableSchema,
                        DBDataType = c2.DataType,
                        IsNullable = (c2.IsNullable != "NO"),
                        MaxLength =  (c2.CharMaxLen == null) ? 0 : Convert.ToInt32(c2.CharMaxLen),
                        Precision = (c2.NumericPrecision == null) ? 0 : Convert.ToInt32(c2.NumericPrecision),
                        Scale = (c2.NumericScale == null) ? 0 : Convert.ToInt32(c2.NumericScale),
                        Id = c.Id,
                        IsComputed = c.IsComputed,
                        IsIdentity = c.IsIdentity
                    };

            if (query1.Any() && SchemaName == null)
                SchemaName = query1.FirstOrDefault().SchemaName;
             
            return query1.ToList();
        }

        public List<PrimaryKey> GetPrimaryKeys()
        {
            // Make a "View" of the Column and Table Constraints
            var query1 = from pk1 in SchemaFactory.Instance.DataBase.InfoSchemaTableConstaints
                         join pk2 in SchemaFactory.Instance.DataBase.InfoSchemaColConstraints 
                         on pk1.ConstraintName equals pk2.ConstraintName
                         where pk1.TableName == Name && pk1.ConstraintType == "PRIMARY KEY"
                         select new PrimaryKey
                                    {
                                        CatalogName = pk1.ConstraintCatalog,
                                        ColumnName = pk2.ColumnName,
                                        KeyName = pk2.ConstraintName,
                                        SchemaName = pk1.ConstraintSchema,
                                        TableName = pk1.TableName
                                    };
            if (!query1.Any())
                return null;

            foreach (var primaryKey in query1)
            {
                var key = primaryKey;
                var col = Columns.SingleOrDefault(c => (c.Name == key.ColumnName) && (c.TableName == key.TableName));
                var columnName = key.ColumnName;
                if (col != default(Column))
                {
                    Columns.SingleOrDefault(c => (c.Name == columnName) && (c.TableName == key.TableName)).IsPrimaryKey = true;
                }
            }
            return query1.ToList();
        }

        public List<ForeignKey> GetForeignKeys()
        {
            var locFKs = new List<ForeignKey>();
            var query1 = from fk1 in SchemaFactory.Instance.DataBase.InfoSchemaTableConstaints
                         where fk1.TableName == Name && fk1.ConstraintType == "FOREIGN KEY"
                         select fk1;
            // if no foreign keys for this table then just get out
            if (!query1.Any())
                return null;

            // Get all of the FKs in the DB
            var query2 = from fk2 in SchemaFactory.Instance.DataBase.InfoSchemaReferentialConstraints
                select fk2;
           
            // Get column constraint info for all. This is so we can get FKs and PKs
            var query3 = from pk3 in SchemaFactory.Instance.DataBase.InfoSchemaColConstraints 
                         where pk3.TableName == Name
                         select pk3;

            foreach (var query2Data in query2)
            {
                var fk = new ForeignKey {ForeignKeyName = query2Data.ConstraintName};
                var stuff1 = query3.SingleOrDefault(c => c.ConstraintName == fk.ForeignKeyName);
                if (stuff1 == default(InfoSchemaConstraintColumnUsage))
                    continue; // this must not be for this table.
                fk.ForeignCatalogName = query2Data.ConstraintCatalog;
                fk.ForeignSchemaName = query2Data.ConstraintSchema;
                fk.PrimaryCatalogName = query2Data.UniqueConstraintCatalog;
                fk.PrimaryKeyName = query2Data.UniqueConstraintName;

                var stuff2 = SchemaFactory.Instance.DataBase.InfoSchemaColConstraints.SingleOrDefault
                                                                (c => c.ConstraintName == fk.PrimaryKeyName);
                fk.PrimaryColumnName = stuff2.ColumnName;
                fk.PrimarySchemaName = stuff2.ConstraintSchema;
                fk.PrimaryTableName = stuff2.TableName;
                fk.MatchOption = query2Data.MatchOption;
                fk.DeleteRule = query2Data.DeleteRule;
                fk.UpdateRule = query2Data.UpdateRule;
                fk.ForeignColumnName = stuff1.ColumnName;
                fk.ForeignTableName = stuff1.TableName;
                locFKs.Add(fk);
            }
            return locFKs;
        }

        public List<HasMany> GetHasManys()
        {
            var query = (from a in SchemaFactory.Instance.DataBase.InfoSchemaReferentialConstraints
                         join b in SchemaFactory.Instance.DataBase.InfoSchemaTableConstaints on
                             new { a.ConstraintSchema, a.UniqueConstraintName }
                             equals
                             new { b.ConstraintSchema, UniqueConstraintName = b.ConstraintName }
                         join c in SchemaFactory.Instance.DataBase.InfoSchemaTableConstaints on
                             new { a.ConstraintSchema, a.ConstraintName }
                             equals
                             new { c.ConstraintSchema, c.ConstraintName }
                         where b.TableName == Name
                         let pk_table = b.TableName
                         let fk_table = c.TableName
                         orderby pk_table, fk_table
                         select new
                         {
                             pk_table,
                             fk_table
                         }).Distinct();

            List<HasMany> hasManys = new List<HasMany>();
            foreach (var rec in query)
            {
                var hasMany = new HasMany();
                hasMany.Reference = rec.fk_table;
                hasManys.Add(hasMany);
            }
            return hasManys;
        }

        public override string ToString() 
        { 
            return Name; 
        }
    }


}

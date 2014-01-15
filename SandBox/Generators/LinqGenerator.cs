using CDH.LinqDBSchema;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SandBox.Generators
{
    public class LinqGenerator : AbstractGenerator
    {
        public string LinqDirectory;
        public LinqGenerator(Solution.Solution solution, SchemaFactory dbInfo)
            : base(solution, dbInfo)
        {
            LinqDirectory = Path.Combine(Solution.BaseDirectory, "LINQ");
            if (!Directory.Exists(LinqDirectory))
                Directory.CreateDirectory(LinqDirectory);

        }

        public bool Generate()
        {
            bool succeeded = false;
            if (Solution.Settings.LinqSettings.MakeDataContextCSFile)
                succeeded = WriteDataContextCSFile();

            succeeded = WriteTableCSFiles();

            return succeeded;
        }

        public bool WriteDataContextCSFile()
        {
            var source = WriteUsings();
            var className = DBInfo.DataBase.Connection.Database + "Context";
            source += WriteNameSpaceHeader();
            source += WriteDataContextClassHeader();
            source += WriteDataContextClass(className);
            source += WriteNameSpaceFooter();
            File.WriteAllText(Path.Combine(LinqDirectory, className + ".cs"), source);
            return true;
        }

        public bool WriteTableCSFiles()
        {
            bool succeeded = true;
            foreach (var tbl in DBInfo.DataBase.Tables)
            {
                var source = WriteUsings();
                source += WriteNameSpaceHeader();
                source += WriteTableClassHeader(tbl);

                foreach (var col in tbl.Columns)
                {
                    source += WriteColumnAttribute(col, tbl);
                    source += WriteColumnProperty(col);
                }
                source += WriteClassFooter();
                source += WriteNameSpaceFooter();
                File.WriteAllText(Path.Combine(LinqDirectory, tbl.Name + ".cs"), source);
                // this.textBox4.Text = source;
            }
            return succeeded;
        }

        private static string WriteUsings()
        {
            var returnString = string.Empty;
            var assemblies = new List<string>
                                 {
                                     "System",
                                     "System.Linq",
                                     "System.Data",
                                     "System.Data.Linq",
                                     "System.Collections.Generic"
                                 };

            foreach (var assm in assemblies)
            {
                returnString += string.Format("using {0};\r\n", assm);
            }
            returnString += "\r\n";
            return returnString;
        }

        private string WriteDataContextClassHeader()
        {
            return string.Format("\t[Database(Name=\"{0}\")]\r\n", DBInfo.DataBase.Connection.Database);
        }

        private string WriteDataContextClass(string className)
        {
            var output = string.Empty;
            output += string.Format("\tpublic class {0} : System.Data.Linq.DataContext\r\n\t{1}\r\n", className, "{");
            output += WriteDataContextConstructor(className);
            foreach (var tbl in DBInfo.DataBase.Tables)
            {
                output += WriteTableProperty(tbl);
            }
            return output;
        }

        private string WriteDataContextConstructor(string className)
        {
            return string.Format("\t\tpublic {0}(string connection) : base(connection)\r\n\t\t{1}\r\n\t\t{2}\r\n\r\n", className, "{", "}");
        }

        private static string WriteTableProperty(Table tbl)
        {
            var source = string.Empty;
            source += string.Format("\t\tpublic Table<{0}> {1}\r\n", tbl.Name, Utility.Utility.Pluralize(tbl.Name));
            source += string.Format("\t\t{0}\r\n\t\t\tget\r\n", "{");
            source += string.Format("\t\t\t{0}\r\n", "{");
            source += string.Format("\t\t\t\treturn GetTable<{0}>();\r\n\t\t\t{1}\r\n\t\t{2}\r\n\r\n", tbl.Name, "}", "}");
            return source;
        }

        private static string WriteTableClassHeader(Table tbl)
        {
            var retString = string.Empty;

            retString += WriteTableAttribute(tbl);
            retString += string.Format("\tclass {0}\r\n\t{1}\r\n", tbl.Name, "{");
            return retString;
        }

        private static string WriteTableAttribute(Table tbl)
        {
            if (tbl.SchemaName == null)
            {
                tbl.SchemaName = tbl.Columns[0].SchemaName;
            }
            var retString = string.Format("\t[Table(Name=\"{0}.{1}\")]\r\n", tbl.SchemaName, tbl.Name);
            return retString;
        }

        private static string WriteColumnAttribute(Column col, Table tbl)
        {
            var dbType = FormatDBDataType(col);
            var canBeNull = string.Empty;
            if (col.IsNullable == false)
            {
                canBeNull = ", CanBeNull=false";
            }
            var isPrimaryKey = string.Empty;
            if (col.IsPrimaryKey || (tbl.PrimaryKeys != null && tbl.PrimaryKeys.SingleOrDefault(p => p.ColumnName == col.Name) != default(PrimaryKey)))
            {
                isPrimaryKey = ", IsPrimaryKey=true";
            }
            var retString = string.Format("\t\t[Column(Name=\"{0}\", DBType=\"{1}\" {2} {3})]\r\n", col.Name, dbType, canBeNull, isPrimaryKey);
            return retString;
        }

        // Note: Maybe make a class in AbstractGenerator to generically write a property declaration
        private static string WriteColumnProperty(Column col)
        {
            return string.Format("\t\tpublic {0} {1} {2} get; set; {3}\r\n\r\n", GetCSDataType(col), col.Name, "{", "}");
        }

        #region Possibly should go into Utility class or AbstractGenerator class
        private static string FormatDBDataType(Column col)
        {
            var dbTypeSpec = string.Empty;
            switch (col.DBDataType.ToLower())
            {
                case "bigint":
                case "binary":
                case "bit":
                case "datetime":
                case "smalldatetime":
                case "date":
                case "decimal":
                case "float":
                case "image":
                case "int":
                case "money":
                case "numeric":
                case "smallmoney":
                case "real":
                case "smallint":
                case "sql_variant":
                case "timestamp":
                case "tinyint":
                case "uniqueidentifier":
                case "varbinary":
                    dbTypeSpec = col.DBDataType;
                    break;
                case "char":
                case "ntext":
                case "nvarchar":
                case "sysname":
                case "text":
                case "varchar":
                    var myString = col.DBDataType.ToLower();
                    var maxLen = (col.MaxLength <= 0) ? "MAX" : col.MaxLength.ToString();
                    myString += string.Format("({0})", maxLen);
                    dbTypeSpec = myString;
                    break;

            }
            if (col.IsNullable == false)
            {
                dbTypeSpec += " NOT NULL ";
            }
            return dbTypeSpec;
        }

        private static string GetCSDataType(Column col)
        {
            switch (col.DBDataType.ToLower())
            {
                case "bigint":
                    return "long";
                case "binary":
                    return "byte[]";
                case "bit":
                    return "bool";
                case "datetime":
                case "smalldatetime":
                case "date":
                    return "DateTime";
                case "decimal":
                    return "decimal";
                case "float":
                    return "double";
                case "image":
                    return "byte[]";
                case "int":
                    return "int";
                case "money":
                case "numeric":
                case "smallmoney":
                    return "decimal";
                case "char":
                case "ntext":
                case "nvarchar":
                case "sysname":
                case "text":
                case "varchar":
                    return "string";
                case "real":
                    return "float";
                case "smallint":
                    return "short";
                case "sql_variant":
                    return "object";
                case "timestamp":
                    return "long";
                case "tinyint":
                    return "byte";
                case "uniqueidentifier":
                    return "Guid";
                case "varbinary":
                    return "byte[]";

            }
            return "string"; // just doing this for now will work up a method later.
        }
        #endregion 
    }
}

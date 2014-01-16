using CDH.LinqDBSchema;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SandBox.Generators
{
    public class FluentNHGenerator : AbstractGenerator
    {
        public string FNHDirectory;
        public FluentNHGenerator(Solution.Solution solution, SchemaFactory dbInfo)
            : base(solution, dbInfo)
        {
            FNHDirectory = Path.Combine(Solution.BaseDirectory, "FNH");
            if (!Directory.Exists(FNHDirectory))
                Directory.CreateDirectory(FNHDirectory);
        }

        public bool Generate()
        {
            foreach (var tbl in DBInfo.DataBase.Tables)
            {
                GenerateMappingFile(tbl);
            }
            return true;
        }

        private void GenerateMappingFile(Table tbl)
        {
            string baseClass = tbl.Name;
            string mapClass = tbl.Name + "Map";
 	        string fileName = mapClass + ".cs";

            string source = WriteUsings();
            source += WriteNamespaceHeader();
            source += WriteClassHeader(mapClass, baseClass);
            source += WriteConstructor(mapClass, tbl, DBInfo.DataBase.Connection.Database);
            source += WriteClassFooter();
            source += WriteNameSpaceFooter();
            SaveSource(source, fileName);
        }

        private string WriteUsings()
        {
            var returnString = string.Empty;
            var assemblies = new List<string>
                                 {
                                     "System",
                                     "FluentNHibernate.Mapping",
                                     "System.Collections.Generic"
                                 };

            foreach (var assm in assemblies)
            {
                returnString += string.Format("using {0};\r\n", assm);
            }
            returnString += "\r\n";
            return returnString;
        }

        private string WriteNamespaceHeader()
        {
            return string.Format("namespace {0}.Mapping\r\n{1}\r\n", Solution.Namespace, "{");
        }

        private string WriteClassHeader(string mapClass, string baseClass)
        {
            return string.Format("\tpublic class {0} : ClassMap<{1}>\r\n{2}\r\n", mapClass, baseClass, "\t{");
        }

        private string WriteConstructor(string mapClass, Table tbl, string dbName)
        {
            string source = string.Format("\t\tpublic {0}()\r\n{1}\r\n", mapClass, "\t\t{");
            source += string.Format("\t\t\tTable(\"[{0}].[{1}].[{2}]\");\r\n", dbName, tbl.SchemaName, tbl.Name);
            if (tbl.PrimaryKeys != null)
            {
                source += string.Format("\t\t\tId(x => x.Id, \"{0}\").GeneratedBy.{1}();\r\n", tbl.PrimaryKeys[0], GetFNHTypeGeneratorName(tbl));
            }

            if (tbl.ForeignKeys != null)
            {
                source += GetReferences(tbl);
            }
            // Now do the rest of the columns
            foreach (var column in tbl.Columns)
            {
                if (tbl.ForeignKeys == null || tbl.ForeignKeys.FirstOrDefault(c => c.ForeignColumnName == column.Name) == default(ForeignKey))
                { // If not Foreiqn Keyed
                    source += GetMappingLineForColumn(column);
                }
            }
            // Put in refs for each one table that has this as a foreign key
            source += GetHasManys(tbl);
            source += GetHasOnes(tbl);
            source += "\n\t\t}\n";
            return source;
        }

        private string GetHasOnes(Table tbl)
        {
            string source = string.Empty;
            return source;
        }

        private string GetHasManys(Table tbl)
        {
            string source = "";
            foreach (var hasMany in tbl.HasManys)
            {
                source += string.Format("\t\t\tHasMany(x => x.{0});\r\n",
                                    Utility.Utility.Pluralize(hasMany.Reference));
            }
            return source;
        }

        private string GetReferences(Table tbl)
        {
            string source = "";
            foreach (var fk in tbl.ForeignKeys)
            {
                source += string.Format("\t\t\tReferences(x => x.{0}).Column(\"{1}\");\r\n", fk.PrimaryTableName, fk.ForeignColumnName);
            }
            return source;
        }

        private string GetMappingLineForColumn(Column column)
        {
            string source = string.Format("\t\t\tMap(x => x.{0}, \"{1}\")", column.Name, column.Name);

            if (column.IsNullable == false)
            {
                source += ".Not.Nullable()";
            }
            if (column.MaxLength > 0)
            {
                source += string.Format(".Length({0})", column.MaxLength);
            }

            source += ";\r\n";

            return source;
        }

        private string GetFNHTypeGeneratorName(Table tbl)
        {
            Column col = tbl.Columns.First(c => c.TableName == tbl.Name && c.IsPrimaryKey == true);
                // c.PrimaryKeyName == tbl.PrimaryKeys[0].KeyName);
            string csTypeName = Utility.Utility.GetCSDataType(col.DBDataType);
            if (csTypeName == "int" || csTypeName == "long" 
                || csTypeName == "uint" || csTypeName == "ulong")
                return "Identity";
            return "Assigned";
        }

        private void SaveSource(string source, string fileName)
        {
            File.WriteAllText(Path.Combine(FNHDirectory,fileName), source);
        }
    }
}

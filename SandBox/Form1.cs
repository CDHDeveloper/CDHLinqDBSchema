﻿using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using CDH.LinqDBSchema;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using SandBox.Generators;
using SandBox.Properties;
using Column = CDH.LinqDBSchema.Column;

namespace SandBox
{
    public partial class Form1 : Form
    {
        private SchemaFactory _schemaFactory;
        private Solution.Solution Solution { get; set; }

        public Form1()
        {
            InitializeComponent();
            if (Solution == null)
                Solution = new Solution.Solution();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You need to supply a connection string");
                return;
            }
            _schemaFactory = SchemaFactory.CreateSchemaFactory(textBox1.Text);
            foreach (var tbl in _schemaFactory.DataBase.Tables)
            {
                tbl.GetPrimaryKeys();
                tbl.GetForeignKeys();
            }
            MessageBox.Show("Database has been loaded");
        }

        private void Button2Click(object sender, EventArgs e)
        {
            // Validate that the info needed is there
            if (_schemaFactory == null)
            {
                MessageBox.Show("You need to click Load to load the database before you can generate the source files");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("You need to fill in the Source Directory");
                return;
            }
            if (!Directory.Exists(textBox2.Text))
            {
                MessageBox.Show("The Source Directory must be a valid existent directory");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("You need to fill in the Namespace");
                return;
            }
            /*
            if (chkGenerateDataContextClass.Checked)
            {
                Solution.Settings.LinqSettings.MakeDataContextCSFile = true;
                var source = WriteUsings();
                var className = _schemaFactory.DataBase.Connection.Database + "Context";
                source += WriteNameSpaceHeader();
                source += WriteDataContextClassHeader();
                source += WriteDataContextClass(className);
                source += WriteNameSpaceFooter();
                File.WriteAllText(Path.Combine(textBox2.Text, className + ".cs"), source);

            }
            foreach (var tbl in _schemaFactory.DataBase.Tables)
            {
                var srcDir = textBox2.Text;
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
                File.WriteAllText(Path.Combine(srcDir, tbl.Name + ".cs"), source);
                // this.textBox4.Text = source;
            }
            */

            // Init Solution info
            Solution.Solution solution = new Solution.Solution();
            Solution.BaseDirectory = textBox2.Text;
            Solution.Namespace = textBox3.Text;
            if (Solution.Settings == null)
                Solution.Settings = new Solution.SolutionSettings();
            if (Solution.Settings.LinqSettings == null)
                Solution.Settings.LinqSettings = new Solution.LinqSettings();
            Solution.Settings.LinqSettings.Generate = true;
            Solution.Settings.LinqSettings.MakeDataContextCSFile = chkGenerateDataContextClass.Checked;
            
            // Generate the Linq files
            var linqGenerator = new LinqGenerator(Solution, _schemaFactory);
            linqGenerator.Generate();

            // Generate the FNH Files
            var FNHGenerator = new FluentNHGenerator(Solution, _schemaFactory);
            FNHGenerator.Generate();

            // Generate the HBM files
            var hbmGenerator = new HBMGenerator(Solution, _schemaFactory);
            hbmGenerator.Generate();

            MessageBox.Show(string.Format("All Source files have been written to: {0}", textBox2.Text));
        }

        private string WriteDataContextClass(string className)
        {
            var output = string.Empty;
            output += string.Format("\tpublic class {0}\r\n\t{1}\r\n", className, "{");
            foreach (var tbl in _schemaFactory.DataBase.Tables)
            {
                output += WriteTableProperty(tbl);
            }
            return output;
        }

        private static string WriteTableProperty(Table tbl)
        {
            var source = string.Empty;
            source += string.Format("\t\tpublic Table<{0}> {1}\r\n", tbl.Name, Pluralize(tbl.Name));
            source += string.Format("\t\t{0}\r\n\t\t\tget\r\n", "{");
            source += string.Format("\t\t\t{0}\r\n", "{");
            source += string.Format("\t\t\t\treturn GetTable<{0}>();\r\n\t\t\t\t{1}\r\n\t\t\t{2}\r\n\r\n", tbl.Name, "}", "}");
            return source;
        }

        private static string Pluralize(string tableName)
        {
            // Admittedly braindead algorithm right now. Will fix
            return tableName + "s";
        }

        private string WriteDataContextClassHeader()
        {
            return string.Format("\t[Database(Name=\"{0}\")]\r\n", _schemaFactory.DataBase.Connection.Database);
        }

        private static string WriteNameSpaceFooter()
        {
            return "}\r\n";
        }

        private static string WriteClassFooter()
        {
            return "\t}\r\n";
        }

        private static string WriteColumnProperty(Column col)
        {
            return string.Format("\t\tpublic {0} {1} {2} get; set; {3}\r\n\r\n", GetCSDataType(col), col.Name, "{", "}");
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

        private string WriteNameSpaceHeader()
        {
            var retString = string.Format("namespace {0}\r\n{1}\r\n", textBox3.Text, "{");
            return retString;
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
    }
}
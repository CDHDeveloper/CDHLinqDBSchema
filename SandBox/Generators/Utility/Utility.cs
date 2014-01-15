namespace SandBox.Generators.Utility
{
    public static class Utility
    {
        public static string GetCSDataType(string dbDataType)
        {
            switch (dbDataType.ToLower())
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

        public static string Pluralize(string input)
        {
            // making this brain dead right now but will 
            // make more intelligent later
            return input + "s";
        }

        public static string Singularize(string input)
        {
            return input;
        }

        public static string StripUnderscores(string input)
        {
            return StripUnderscores(input, true);
        }

        public static string StripUnderscores(string input, bool CapIt)
        {
            string output = string.Empty;
            bool CapNext = false;
            foreach (char c in input)
            {
                if (c == '_')
                {
                   if (CapIt)
                   {
                       CapNext = true;
                       continue;
                   }
                }
                else
                {
                    CapNext = false;
                }
                if (CapNext)
                {
                    output += char.ToUpper(c);
                }
                else
                {
                    output += c;
                }
            }
            return output;
        }
    }   
}

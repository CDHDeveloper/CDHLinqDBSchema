using System.Collections.Generic;
using CDH.LinqDBSchema;

namespace SandBox.Generators
{
    public class AbstractGenerator : IGenerator
    {
        public AbstractGenerator(Solution.Solution solution, SchemaFactory dbInfo)
        {
            Solution = solution;
            DBInfo = dbInfo;
        }

        public SchemaFactory DBInfo { get; set; }
        public List<GeneratorError> Errors { get; set; }
        public Solution.Solution Solution { get; set; }
        public virtual bool Generate()
        {

            return true;
        }

        public string WriteNameSpaceHeader()
        {
            return string.Format("namespace {0}\r\n{1}\r\n", Solution.Namespace, "{");
        }

        public virtual string WriteNameSpaceFooter()
        {
            return "}\r\n";
        }

        public virtual string WriteClassFooter()
        {
            return "\t}\r\n";
        }
    }
}

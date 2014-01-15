using System.Collections.Generic;
using CDH.LinqDBSchema;

namespace SandBox.Generators
{
    public interface IGenerator
    {
        Solution.Solution Solution { get; set; }
        List<GeneratorError> Errors { get; set; }
        SchemaFactory DBInfo { get; set; }
        bool Generate();
    }
}

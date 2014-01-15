using CDH.LinqDBSchema.Interfaces;

namespace CDH.LinqDBSchema
{
    public class Schema : ISchema
    {

        public string Name { get; set; }
        public string Authoriaztion { get; set; }

        public User User { get; set; }

    }
}

using CDH.LinqDBSchema.Enums;
using CDH.LinqDBSchema.Interfaces;

namespace CDH.LinqDBSchema
{
    /// <summary>      
    /// base class for all Sql objects      
    /// </summary>      
    public abstract class BaseEntity : IBaseEntity      
    {
        public ObjectType SqlType;
    }  
}

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using SandBox.EnumsAndConstants;

namespace SandBox.Solution
{
    [Serializable]
    public class DatabaseSettings
    {
        [XmlAttribute(AttributeName = "DBName")]
        public string DBName { get; set; }

        [XmlAttribute(AttributeName = "ClassName")]
        public string ClassName { get; set; }

        [XmlAttribute(AttributeName = "Type")]
        public DBServerTypes ServerType { get; set; }

        [XmlElement(ElementName = "ConnectionString")]
        public string ConnectionString { get; set; }

        [XmlArray(ElementName = "Tables")]
        public List<TableSettings> Tables;
    }
}

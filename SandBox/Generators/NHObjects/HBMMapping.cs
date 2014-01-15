using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SandBox.Generators.NHObjects
{
    [Serializable]
    [XmlRoot(ElementName = "hibernate-mapping")]
    public class HBMMapping
    {
        [XmlAttribute(AttributeName = "namespace", DataType = "string")]
        public string Namespace { get; set; }

        [XmlAttribute(AttributeName = "assembly", DataType = "string")]
        public string Assembly { get; set; }

        [XmlAttribute(AttributeName = "xmlns", DataType = "string")]
        public string XMLNS { get; set; }

        [XmlElement(ElementName = "class")]
        public HBMClass Class;
    }

    [Serializable]
    public class HBMClass
    {
        // Attributes
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "table")]
        public string Table { get; set; }

        [XmlAttribute(AttributeName = "schema")]
        public string Schema { get; set; }

        // Elements
        [XmlElement(ElementName = "Id")]
        public HBMIdentity Identity { get; set; }

        // Primary Key is either an identity (see above) or CompositeId
        [XmlElement(ElementName = "composite-id" )]
        public CompositeId CompositeId { get; set; }

        [XmlArray(ElementName ="")]
        [XmlArrayItem(ElementName = "property")]
        public List<HBMProperty> Properties { get; set; }

        [XmlArrayItem(ElementName = "bag")]
        public List<HBMBag> Bags { get; set; }

        [XmlArrayItem(ElementName="one-to-one")]
        public List<HBMOneToOne> OneToOnes { get; set; }
    }

    [Serializable]
    public class HBMIdentity
    {
        // Attributes

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        // Elements
        [XmlElement(ElementName = "generator")]
        public IdGenerator IdGenerator { get; set; }

    }

    [Serializable]
    public class IdGenerator
    {
        // Attributes
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [Serializable]
    public class CompositeId
    {
        [XmlArrayItem(ElementName = "key-property")]
        public List<HBMKeyProperty> KeyProperties { get; set; }
    }

    [Serializable]
    public class HBMKeyProperty
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set;  }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }


    [Serializable]
    public class HBMProperty
    {
        // Attributes 
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "length")]
        public int Length { get; set; }

        [XmlAttribute(AttributeName = "precision")]
        public int Precision { get; set; }

        [XmlAttribute(AttributeName = "not-null")]
        public bool NotNull { get; set; }
    }

    [Serializable]
    public class HBMBag
    {
        [XmlAttribute(AttributeName="name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "table")]
        public string Table { get; set; }

        [XmlElement(ElementName="key")]
        public HBMKey Key { get; set; }

        [XmlElement(ElementName="one-to-many")]
        public HBMOneToMany OneToMany { get; set; }

    }

    [Serializable]
    public class HBMKey
    {
        [XmlAttribute(AttributeName = "column")]
        public string Column { get; set; }
    }

    [Serializable]
    public class HBMOneToOne
    {
        [XmlAttribute(AttributeName="name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
    }

    [Serializable]
    public class HBMOneToMany
    {
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
    }
}

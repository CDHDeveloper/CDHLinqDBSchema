using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SandBox.Solution
{
    [Serializable]
    public class Solution
    {
        [XmlAttribute(AttributeName="name")]
        public string Name;

        [XmlElement(ElementName="Path")]
        public string BaseDirectory;

        [XmlElement(ElementName="Namespace")]
        public string Namespace { get; set; }

        [XmlArray("Settings")]
        public SolutionSettings Settings;

        [XmlArray(ElementName="Properties", IsNullable=true)]
        public Properties Properties;

        public List<DatabaseSettings> Databases;

    }

    [Serializable]
    public class SolutionSettings
    {
        [XmlElement(ElementName="LinqSettings")]
        public LinqSettings LinqSettings;


        [XmlElement(ElementName = "NHSettings")]
        public NHibernateSettings NHSettings;

        [XmlElement(ElementName = "EFSettings")]
        public EFSettings EFSettings;

        [XmlElement(ElementName = "WCFSettings")]
        public WCFSettings WCFSettings;

        [XmlElement(ElementName = "AppLayerSettings")]
        public AppLayerSettings AppLayerSettings;

        [XmlElement(ElementName = "DomainSettings")]
        public DomainSettings DomainSettings;

        [XmlElement(ElementName = "MVCSettings")]
        public MVCSettings MVCSettings;
    }

    [Serializable]
    public class LinqSettings
    {
        public bool Generate;
        public bool MakeDataContextCSFile;
    }

    [Serializable]
    public class NHibernateSettings
    {
        public bool Generate;
    }

    [Serializable]
    public class EFSettings
    {
        public bool Generate;
    }

    [Serializable]
    public class WCFSettings
    {
        public bool Generate;
        public bool UseSerializedQueries;
        public List<WCFService> Services;
    }

    [Serializable]
    public class WCFService
    {
        public string Name { get; set; }
    }

    [Serializable]
    public class AppLayerSettings
    {
        public bool Generate;
    }

    [Serializable]
    public class DomainSettings
    {
        public bool Generate;
    }

    [Serializable]
    public class MVCSettings
    {
        public bool Generate;
    }


    [Serializable]
    public class Properties
    {
    }

    [Serializable]
    public class Databases
    {
    }

    [Serializable]
    public class Database
    {
    }

}

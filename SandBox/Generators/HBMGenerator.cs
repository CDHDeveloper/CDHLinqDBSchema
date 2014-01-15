using System.Collections.Generic;
using CDH.LinqDBSchema;
using SandBox.Generators.NHObjects;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using SandBox.EnumsAndConstants;


namespace SandBox.Generators
{
    public class HBMGenerator : AbstractGenerator
    {
        
        public HBMMapping Mapping = new HBMMapping();
        public HBMGenerator(Solution.Solution solution, SchemaFactory dbInfo) : base(solution, dbInfo)
        {
            
        }

        public override bool Generate()
        {
            foreach (var tbl in DBInfo.DataBase.Tables)
            {
                Mapping.Class = new HBMClass
                                    {
                                        Schema = tbl.SchemaName, 
                                        Name = tbl.Name, 
                                        Table = tbl.Name
                                    };

                // Fill in class attributes

                // Generate primary key info
                if (tbl.PrimaryKeys == null)
                {
                    Mapping.Class.Identity = null;
                    
                }
                else if (tbl.PrimaryKeys.Count == 1)
                {
                    Mapping.Class.Identity = GetIdentity(tbl);
                }
                else if (tbl.PrimaryKeys.Count > 1)
                {
                    Mapping.Class.CompositeId = GetCompositeId(tbl);
                }

                // Generate the properties
                foreach (var column in tbl.Columns)
                {
                    if (!column.IsPrimaryKey)
                    {
                        var prop = new HBMProperty();
                        prop.Name = column.Name;
                        prop.Length = column.MaxLength;
                        prop.Precision = column.Precision;
                        prop.Type = Utility.Utility.GetCSDataType(column.DBDataType);
                        prop.NotNull = column.IsNullable;

                        if (Mapping.Class.Properties == null)
                            Mapping.Class.Properties = new List<HBMProperty>();
                        Mapping.Class.Properties.Add(prop);
                    }
                    
                }

                if (tbl.ForeignKeys != null)
                {
                    // Put out the one to many's (bags)
                    foreach (var foreignKey in tbl.ForeignKeys)
                    {
                        var bag = new HBMBag 
                            { 
                                Name = Utility.Utility.Pluralize(foreignKey.ForeignTableName), 
                                Table = foreignKey.ForeignTableName,
                                Key = new HBMKey { Column = foreignKey.ForeignColumnName},
                                OneToMany = new HBMOneToMany { Class = Utility.Utility.Singularize(foreignKey.ForeignTableName) } 
                            };
                    }
                }
                WriteHBMFile(Mapping);
            }


            // Now output the results
            return true;
        }

        private static CompositeId GetCompositeId(Table tbl)
        {
            throw new System.NotImplementedException();
        }

        private static HBMIdentity GetIdentity(Table tbl)
        {
            var ident = new HBMIdentity {Name = tbl.PrimaryKeys[0].ColumnName};
            ident.Type = Utility.Utility.GetCSDataType(tbl.Columns.First(c => c.Name == ident.Name).DBDataType);
            ident.IdGenerator = new IdGenerator();
            if (ident.Type == "int" || ident.Type == "long"
                || ident.Type == "uint" || ident.Type == "ulong")
            {
                ident.IdGenerator.Class = "identity";
            }
            ident.IdGenerator.Class = "assigned";
            return ident;
        }

        public void WriteHBMFile(HBMMapping mapping)
        {
            XElement hbm = MakeHBMXml();
            var hbmPath = Path.Combine(Solution.BaseDirectory, "HBMs");
            if (!Directory.Exists(hbmPath))
            {
                Directory.CreateDirectory(hbmPath);
            }
            hbmPath = Path.Combine(hbmPath, mapping.Class.Name + NHStrings.HBMExtension);
            string hbmString = hbm.ToString();
            hbm.Save(hbmPath);
        }

        public XElement MakeHBMXml()
        {
            XNamespace ns = NHStrings.HibernateNamespace; 

            // the element defining the class that represents the table/object
            XElement elem = MakeClassXElement(ns); 

            // Main nhibernate document
            XElement mainElem = new XElement(ns + NHStrings.HBMRootNodeName, elem);
           

            return mainElem;
        }

        public XElement MakeClassXElement(XNamespace ns)
        {
            XElement classElement = new XElement("class",
                    new XAttribute("name", Mapping.Class.Name),
                    new XAttribute("table", Mapping.Class.Table),
                    MakeIdentityXElement(),
                    MakePropertyXElements(),
                    MakeBagXElements());
            return classElement;
        }

        private XElement[] MakeBagXElements()
        {
            if (Mapping.Class.Bags == null)
                return default(XElement[]);

            List<XElement> bagElements = new List<XElement>();
            foreach (var bag in Mapping.Class.Bags)
            {
                XElement elem = new XElement("bag",
                    new XAttribute("name", bag.Name),
                    new XAttribute("table", bag.Table),
                    new XAttribute("lazy", true),
                    new XElement("key",
                        new XAttribute("column", bag.Key.Column)),
                    new XElement("one-to-many", bag.OneToMany.Class));
                bagElements.Add(elem);
            }
            return bagElements.ToArray();
        }

        public XElement MakeIdentityXElement()
        {
            if (Mapping.Class == null || Mapping.Class.Identity == null)
                return null;
            XElement xElement = new XElement("identity", 
                    new XAttribute("name", Mapping.Class.Identity.Name),
                    new XAttribute("type", Mapping.Class.Identity.Type),
                    new XAttribute("column", Mapping.Class.Identity.Name),
                    new XElement("generator",
                        new XAttribute("class", Mapping.Class.Identity.IdGenerator.Class)));
            return xElement;
        }

        public XElement[] MakePropertyXElements()
        {
            List<XElement> propElements = new List<XElement>();
            foreach (HBMProperty prop in Mapping.Class.Properties)
            {
                XElement elem = new XElement("property",
                    new XAttribute("name", prop.Name),
                    new XAttribute("column", prop.Name),
                    new XAttribute("type", prop.Type));

                if (prop.NotNull == true)
                    elem.Add(new XAttribute("not-null", true));
                if (prop.Length > 0)
                    elem.Add(new XAttribute("length", prop.Length));
                if (prop.Precision > 0)
                    elem.Add(new XAttribute("precision", prop.Precision));

                propElements.Add(elem);
            }
            return propElements.ToArray();
        }
    }
}

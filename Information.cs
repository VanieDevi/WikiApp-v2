using System;
using System.Globalization;
using System.Xml.Linq;

namespace WikiApp_v2
{
    public class Information : IComparable<Information>
    {
        //Private Attributes
        private string Name;
        private string Category;
        private string Structure;
        private string Definition;

        // Default constructor
        public Information()
        {}
        public Information(string name)
        {
            Name = name;
        }

        public Information(string name, string category)
        {
            Name = name;
            Category = category;
            Structure = "";
            Definition = "";
        }

        public Information(string name, string category, string structure, string definition)
        {
            Name = name;
            Category = category;
            Structure = structure;
            Definition = definition;
        }

        public string GetName()
        {
            return Name;
        }
        //Assessor Methods
        public string GetCategory()
        {
            return Category;
        }

        public string GetStructure()
        {
            return Structure;
        }
        public string GetDefinition()
        {
            return Definition;
        }

        public void SetName(string inName)
        {
            TextInfo nameTI = new CultureInfo("en-US", false).TextInfo;
            Name = nameTI.ToTitleCase(inName);
        }

        public void SetCategory(string inCategory)
        {
            Category=inCategory;
        }
        
        public void SetStructure(string inStructure)
        {
            Structure=inStructure;
        }
        public void SetDefinition(string inDefinition)
        {
            Definition=inDefinition;
        }

        public int CompareTo(Information other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}

using System;
using System.Xml.Serialization;

namespace SerializationCSharp
{
    [XmlRoot("People")]

    public class Tutorial
    {
        [XmlAttribute("FullName")]
        public string name = "Siphiwe";
        [XmlElement("IDNo.")]
        public int idNumber;
        [XmlElement("Age")]
        public int ageNo;

        public Tutorial() { }

        public Tutorial(string fullName, int idNo, int age)
        {
            this.name = fullName;
            this.idNumber = idNo;
            this.ageNo = age;
        }

        private void GetPersonName(string _name)
        {
            this.name = _name;
            Console.WriteLine(name);
        }
    }
}
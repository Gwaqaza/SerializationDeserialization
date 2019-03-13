using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace SerializationCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tutorial> myList = new List<Tutorial>();

            myList.AddRange(new Tutorial[]
            {
                new Tutorial("Sipho Ndlovu", 12345678, 21),
                new Tutorial("Sisi Lvu", 24680864, 26),
                new Tutorial("Dave Scoll", 09876543, 30)
            });


            using (Stream stream = File.OpenWrite(Environment.CurrentDirectory + "\\myPerson.xml"))
            {
                XmlSerializer xmlSerialize = new XmlSerializer(typeof(List<Tutorial>));

                xmlSerialize.Serialize(stream, myList);
            };

            //Deserialization
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Tutorial>));
            using (TextReader reader = new StreamReader(
                @"C:\Users\bbdnet1963\source\repos\SerializationCSharp\SerializationCSharp\bin\Debug\myPerson.xml"))
            {
                List<Tutorial> obj = (List<Tutorial>)deserializer.Deserialize(reader);
                List<Tutorial> xmlData = obj;
            }

            // Reflection
            var instance = new Tutorial();
            var method = typeof(Tutorial)
                .GetMethod("GetPersonName",
                BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(instance, new[] {"Philani"});
            
            //
            //method.Invoke(instance.name, null);
            Console.ReadKey();
        }
    }
}

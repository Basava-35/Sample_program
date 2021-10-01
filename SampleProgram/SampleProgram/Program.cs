using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Serializer
{
    public class DataStructure
    {
        public string Name { get; set; }
        public List<int> Identifiers { get; set; }

        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Identifiers: " + string.Join<int>(",", Identifiers));
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    class Program
    {
        const string filePath = @"C:\D_Drive\Practise_programs\CSharp_Programs\nuget_understand_program\NugetUnderstandCsharpProgram\Json_files\json.txt";

        public static void Serialize(object obj)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static object Deserialize(string path)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamReader(path))
            using (var reader = new JsonTextReader(sw))
            {
                return serializer.Deserialize(reader);
            }
        }

        static void Main(string[] args)
        {
            var data = new DataStructure
            {
                Name = "Henry",
                Identifiers = new List<int> { 1, 2, 3, 4 }
            };

            Console.WriteLine("Object before serialization:");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            data.Print();

            Serialize(data);

            var deserialized = Deserialize(filePath);

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);

            Console.ReadLine();
        }
    }
}
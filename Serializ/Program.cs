using System.Text.Json;
using System.Xml.Serialization;

namespace Serializ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Person vasya = new Person()
            {
                Name = "Vasyl",
                Surname = "Popov",
                Age = 30,
                Height = 120
            };

            Student v = new Student()
            {
                Person = vasya,
                uniName = "ChNU",
                groupId = 643,
                Lessons = new List<string> { "Math", "Eng", "Science", "History" }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            using (FileStream fs = new FileStream("natashaobj.xml", FileMode.OpenOrCreate))
            {
                //XML serialization
                serializer.Serialize(fs, v);

                //XML deserialization
                Student? student = (Student?)serializer.Deserialize(fs);
                if (student != null)
                {
                    Console.WriteLine(student.Person.Surname);
                }
            }

            //json serialization
            string json = JsonSerializer.Serialize(v);
            File.WriteAllText("natashadata.json", json);

            //json deserialization
            string json2 = File.ReadAllText("natashadata.json");
            Student vasya2 = JsonSerializer.Deserialize<Student>(json2);
            Console.WriteLine(vasya2.Person.Name + vasya2.Person.Surname);
            foreach (var lesson in vasya2.Lessons)
            {
                Console.WriteLine(lesson);
            }
        }
    }
}
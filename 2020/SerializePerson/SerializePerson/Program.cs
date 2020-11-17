using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializePerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                FirstName = "Arthur",
                LastName = "Morgan",
                Brother = new Person { FirstName = "John" }
            };

            /*
             * System.Test.Json
             */

            JsonSerializerOptions serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string json = System.Text.Json.JsonSerializer.Serialize(person, serializeOptions);

            Console.WriteLine(json);

            JsonSerializerOptions deserializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Person person1 = System.Text.Json.JsonSerializer.Deserialize<Person>(json, deserializeOptions);

            Console.WriteLine();

            /*
             * Newtonsoft.Json
             */

            string newtonsoftJson = JsonConvert.SerializeObject(person, new JsonSerializerSettings 
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            Console.WriteLine(newtonsoftJson);

            Person person2 = JsonConvert.DeserializeObject<Person>(newtonsoftJson);


            Console.ReadKey();
        }                     
    }
}

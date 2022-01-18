using DomainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetClassrooms();

            Console.ReadLine();
        }

        private static async void GetClassrooms()
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44357/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("https://localhost:44357/classroom");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    List<Classroom> classrooms = JsonConvert.DeserializeObject<List<Classroom>>(content);

                    foreach (Classroom classroom in classrooms)
                    {
                        Console.WriteLine($"{classroom.Name} (id {classroom.ClassroomID})");
                    }
                }
            }
        }
    }
}

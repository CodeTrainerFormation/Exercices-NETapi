using DomainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetClassrooms();

            //GetClassroom();


            //var classroom = new Classroom()
            //{
            //    Name = "Salle Anders Hejlsberg",
            //    Floor = 8,
            //    Corridor = "Gris"
            //};

            //PostClassroom(classroom);


            //var classroom = new Classroom()
            //{
            //    ClassroomID = 5,
            //    Name = "Salle Anders Hejlsberg",
            //    Floor = 8,
            //    Corridor = "Gris"
            //};

            //PutClassroom(classroom);


            //DeleteClassroom(1);

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

        private static async void GetClassroom()
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44357/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("https://localhost:44357/classroom/1");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Classroom classroom = JsonConvert.DeserializeObject<Classroom>(content);

                    Console.WriteLine($"{classroom.Name} (id {classroom.ClassroomID})");
                }
            }
        }

        private static async void PostClassroom(Classroom classroom)
        {
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("https://localhost:44357/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(classroom);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://localhost:44357/classroom", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    classroom = JsonConvert.DeserializeObject<Classroom>(responseContent);

                    Console.WriteLine($"{classroom.Name} (id {classroom.ClassroomID})");
                }
            }
        }

        private static async void PutClassroom(Classroom classroom)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(classroom);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"classroom/{classroom.ClassroomID}", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Contenu modifié");
                }
            }
        }

        private static async void DeleteClassroom(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44357/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"classroom/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var classroom = JsonConvert.DeserializeObject<Classroom>(responseContent);

                    Console.WriteLine($"{classroom.Name} (id {classroom.ClassroomID})");
                }
            }
        }
    }
}

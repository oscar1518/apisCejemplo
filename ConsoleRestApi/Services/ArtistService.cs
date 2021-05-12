using ConsoleRestApi.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleRestApi
{
    class ArtistService
    {
        public static async Task getArtistData()
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Artist/GetAll");
            var response = await client.ExecuteAsync(request);

            List<string> list = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                List<Artist> result = JsonConvert.DeserializeObject<List<Artist>>(rawResponse);

                foreach (Artist a in result)
                {
                    list.Add("\n-Artista-");
                    list.Add("Id: " + a.Id.ToString());
                    list.Add("Nombre: " + a.Name);
                    list.Add("Edad: " + a.Age.ToString());
                    list.Add("Género: " + a.Genre);
                    list.Add("Albums: ");

                    foreach (Album album in a.Albums)
                    {
                        list.Add("  -Id: " + album.id.ToString());
                        list.Add("  -Nombre: " + album.name.ToString() + "\n");
                    }
                }

                foreach (string r in list)
                {
                    Console.WriteLine(r);
                }
            }
            else
            {
                Console.WriteLine("Nada encontrado");
            }
        }

        public static void getArtistId(int id)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Artist/GetById/" + id + "");
            var response = client.Execute(request);

            List<string> list = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Artist result = JsonConvert.DeserializeObject<Artist>(rawResponse);

                list.Add("-Artista-");
                list.Add("Id: " + result.Id.ToString());
                list.Add("Nombre: " + result.Name);
                list.Add("Edad: " + result.Age.ToString());
                list.Add("Género: " + result.Genre);
                list.Add("Albums: ");
                foreach (Album album in result.Albums)
                {
                    list.Add("  -Id: " + album.id.ToString());
                    list.Add("  -Nombre: " + album.name.ToString() + "\n");
                }


                foreach (string r in list)
                {
                    Console.WriteLine(r);
                }

                Console.WriteLine(list.ToString());
            }
            else
            {
                Console.WriteLine("Nada encontrado");
            }
        }

        public static void getArtistName(string name)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Artist/GetByName/" + name + "");
            var response = client.Execute(request);

            List<string> list = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Artist result = JsonConvert.DeserializeObject<Artist>(rawResponse);


                list.Add("-Artista-");
                list.Add("Id: " + result.Id.ToString());
                list.Add("Nombre: " + result.Name);
                list.Add("Edad: " + result.Age.ToString());
                list.Add("Género: " + result.Genre);
                list.Add("Albums: ");
                foreach (Album album in result.Albums)
                {
                    list.Add("  -Id: " + album.id.ToString());
                    list.Add("  -Nombre: " + album.name.ToString() + "\n");
                }

                foreach (string r in list)
                {
                    Console.WriteLine(r);
                }

                Console.WriteLine(list.ToString());
            }
            else
            {
                Console.WriteLine("Nada encontrado");
            }
        }

        public static async Task postArtist(string name, int age, string genere)
        {

            // Create a New NameValueCollection

            ArtistDTO values = new ArtistDTO();

            values.Name = name;
            values.Age = age;
            values.Genre = genere;

            var json = JsonConvert.SerializeObject(values);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44334/apiPrueba/Artist";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = await response.Content.ReadAsStringAsync();

            if (result == "true")
            {
                Console.WriteLine("Usuario registrado");
            }
        }

        public static async Task putArtist(int id, string name, int age, string genere)
        {
            using (var client = new HttpClient())
            {

                Artist p = new Artist { Id = id, Name = name, Age = age, Genre = genere };

                var json = JsonConvert.SerializeObject(p);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "apiPrueba/Artist";

                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = await client.PutAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Usuario modificado");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Elemento no existe");
                }
                else
                {
                    Console.Write("Error sin controlar");
                }
            }
        }

        public static async Task deleteArtist(int id)
        {
            using (var client = new HttpClient())
            {


                var url = "apiPrueba/Artist/" + id;
                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = (await client.DeleteAsync(url));


                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Artista eliminado");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Elemento no existe");
                }
                else
                    Console.Write("El artista no se pudo eliminar");
            }
        }
    }
}





//public class ResponseDto
//{
//    string code;

//    object response;
//}
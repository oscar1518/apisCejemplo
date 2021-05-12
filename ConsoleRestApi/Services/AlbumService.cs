using ConsoleRestApi.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRestApi.Services
{
    class AlbumService
    {

        public static void getAlbumData()
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Album/GetAll");
            var response = client.Execute(request);

            List<string> list = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                List<Album> result = JsonConvert.DeserializeObject<List<Album>>(rawResponse);
                int count = 1;
                foreach (Album a in result)
                {

                    list.Add("\n-Album-");
                    list.Add("Id: " + a.id.ToString());
                    list.Add("Nombre: " + a.name);
                    list.Add("Canciones: ");

                    foreach (Song song in a.songs)
                    {
                        list.Add("    " + count + "-Id: " + song.id.ToString());
                        list.Add("     -Nombre: " + song.name.ToString() + "");
                        count++;
                    }
                    count = 1;
                    list.Add("Artista: " + a.artist.Name);
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

        public static void getAlbumId(int id)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Album/GetById/" + id + "");
            var response = client.Execute(request);

            List<string> list = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Album result = JsonConvert.DeserializeObject<Album>(rawResponse);

                list.Add("-Album-");
                list.Add("Id: " + result.id.ToString());
                list.Add("Nombre: " + result.name);
                list.Add("Canciones: ");

                foreach (Song song in result.songs)
                {
                    list.Add("  -Id: " + song.id.ToString());
                    list.Add("  -Nombre: " + song.name.ToString() + "");
                }

                list.Add("Artista: " + result.artist.Name);

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

        public static void getAlbumName(string name)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Album/GetByName/" + name + "");
            var response = client.Execute(request);

            List<string> list = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Album result = JsonConvert.DeserializeObject<Album>(rawResponse);


                list.Add("-Album-");
                list.Add("Id: " + result.id.ToString());
                list.Add("Nombre: " + result.name);
                list.Add("Canciones: ");
                foreach (Song song in result.songs)
                {
                    list.Add("  -Id: " + song.id.ToString());
                    list.Add("  -Nombre: " + song.name.ToString() + "\n");
                }
                list.Add("Artista: " + result.artist.Name);
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

        public static async Task postAlbum(string name, int id)
        {

            AlbumDTO values = new AlbumDTO();

            values.Name = name;
            values.ArtistId = id;

            var json = JsonConvert.SerializeObject(values);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44334/apiPrueba/Album";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;

            if (result == "true")
            {
                Console.WriteLine("Usuario registrado");
            }
        }

        public static async Task putAlbum(int id, string name, int idArtist)
        {
            using (var client = new HttpClient())
            {
                Album a = new Album { id = id, name = name, ArtistId = idArtist };

                string json = JsonConvert.SerializeObject(a);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                string url = "apiPrueba/Album";

                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = await client.PutAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Album modificado");
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

        public static async Task deleteAlbum(int id)
        {
            using (var client = new HttpClient())
            {

                string url = "apiPrueba/Album/" + id;
                client.BaseAddress = new Uri("https://localhost:44334/");
                HttpResponseMessage response = (await client.DeleteAsync(url));

                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Album eliminado");
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

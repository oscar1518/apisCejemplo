using ConsoleRestApi.DTO;
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
    class SongService
    {

        public static void getSongData()
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Song/GetAll");
            var response = client.Execute(request);

            List<string> list = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                List<Song> result = JsonConvert.DeserializeObject<List<Song>>(rawResponse);
                foreach (Song a in result)
                {

                    list.Add("\n-Song-");
                    list.Add("Id: " + a.id.ToString());
                    list.Add("Nombre: " + a.name.ToString());
                    list.Add("Publicación: " + a.publishDate);
                    list.Add("Album: "+ a.Album.name);

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

        public static void getSongId(int id)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Song/GetById/" + id + "");
            var response = client.Execute(request);

            List<string> list = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Song result = JsonConvert.DeserializeObject<Song>(rawResponse);

                list.Add("-Cancion-");
                list.Add("Id: " + result.id.ToString());
                list.Add("Nombre: " + result.name);
                list.Add("Publicacion: " + result.publishDate);
                list.Add("Album: " + result.Album.name);

               



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

        public static void getSongByName(string name)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Song/GetByName/" + name + "");
            var response = client.Execute(request);

            List<string> list = new List<string>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Song result = JsonConvert.DeserializeObject<Song>(rawResponse);


                list.Add("-Song-");
                list.Add("Id: " + result.id.ToString());
                list.Add("Nombre: " + result.name);
                list.Add("Fecha publicación: " + result.publishDate);
                list.Add("Album: " + result.Album.name);
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

        public static async Task postSong(string name, string date, int albumId)
        {

            SongDTO values = new SongDTO();

            values.name = name;
            values.publishDate = Convert.ToDateTime(date);
            values.albumId = albumId;

            var json = JsonConvert.SerializeObject(values);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44334/apiPrueba/Song";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;

            if (result == "true")
            {
                Console.WriteLine("Cancion registrada");
            }
        }

        public static async Task putSong(int id, string name, int albumId, string date )
        {
            using (var client = new HttpClient())
            {
                Song a = new Song { id = id, name = name, publishDate = Convert.ToDateTime(date), albumId = albumId };

                string json = JsonConvert.SerializeObject(a);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                string url = "apiPrueba/Song";

                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = await client.PutAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Cancion modificada");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("El elemento no existe");
                }
                else
                {
                    Console.Write("Error sin controlar");
                }
            }
        }

        public static async Task deleteSong(int id)
        {
            using (var client = new HttpClient())
            {

                string url = "apiPrueba/Song/" + id;
                client.BaseAddress = new Uri("https://localhost:44334/");
                HttpResponseMessage response = (await client.DeleteAsync(url));

                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Canción eliminada");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Elemento no existe");
                }
                else
                    Console.Write("La canción no se pudo eliminar");
            }
        }
    }
}


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
using System.Windows;
using WPFClient.DTO;
using WPFClient.Models;
namespace WPFClient.Services
{
    class SongService
    {
        public static async Task<List<Song>> getAll()
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Song/GetAll");
            var response = await client.ExecuteAsync(request);

            List<Song> song = new List<Song>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                song = JsonConvert.DeserializeObject<List<Song>>(rawResponse);
            }
            return song;
        }

        public static async Task<Song> getById(int id)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Song/GetById/" + id + "");
            var response = await client.ExecuteAsync(request);

            Song song = new Song();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                song = JsonConvert.DeserializeObject<Song>(rawResponse);
            }

            return song;
        }

        public static async Task<Song> getByName(string name)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Song/GetByName/" + name + "");
            var response = await client.ExecuteAsync(request);

            Song song = new Song();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                song = JsonConvert.DeserializeObject<Song>(rawResponse);
            }
            return song;
        }

        public static async Task post(int id, string name, string publishDate)
        {

            // Create a New NameValueCollection

            SongDTO values = new SongDTO();

            values.albumId = id;
            values.name = name;
            values.publishDate = Convert.ToDateTime(publishDate);


            var json = JsonConvert.SerializeObject(values);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44334/apiPrueba/Song";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = await response.Content.ReadAsStringAsync();

            if (result == "true")
            {
                MessageBox.Show("Cancion Registrada");
            }
        }

        public static async Task Put(int id, string name, int albumId, string publishDate)
        {
            using (var client = new HttpClient())
            {
                SongDTO artist = new SongDTO { id = id, name = name, albumId = albumId , publishDate = Convert.ToDateTime(publishDate) };

                string json = JsonConvert.SerializeObject(artist);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "apiprueba/Song";

                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = await client.PutAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cancion modificado");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Cancion no encontrado");
                }
                else
                {
                    MessageBox.Show("Error sin reconocer");
                }
            }
        }


        public static async Task Delete(int id)
        {
            using (var client = new HttpClient())
            {


                var url = "apiPrueba/Song/" + id;
                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cancion eliminado");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Elemento no existe");
                }
                else
                    MessageBox.Show("El Cancion no se pudo eliminar");
            }
        }
    }
}

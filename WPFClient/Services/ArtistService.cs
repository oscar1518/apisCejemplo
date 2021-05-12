
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
using WPFClient.Models;

namespace WPFClient.Services
{
    class ArtistService
    {

        public static async Task<List<Artist>> getAll()
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Artist/GetAll");
            var response = await client.ExecuteAsync(request);

            List<Artist> artists = new List<Artist>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                artists = JsonConvert.DeserializeObject<List<Artist>>(rawResponse);
            }
            return artists;
        }

        public static async Task<Artist> getById(int id)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Artist/GetById/" + id + "");
            var response = await client.ExecuteAsync(request);

            Artist artists = new Artist();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                artists = JsonConvert.DeserializeObject<Artist>(rawResponse);
            }

            return artists;
        }

        public static async Task<Artist> getByName(string name)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Artist/GetByName/" + name + "");
            var response = await client.ExecuteAsync(request);

            Artist artist = new Artist();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                artist = JsonConvert.DeserializeObject<Artist>(rawResponse);
            }
            return artist;
        }

        public static async Task post(string name, int age, string genere)
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
                MessageBox.Show("Usuario Registrado");
            }
        }

        public static async Task Put(int id, string name, int age, string genere)
        {
            using (var client = new HttpClient())
            {
                ArtistDTO artist = new ArtistDTO { Id = id, Name = name, Age = age, Genre = genere };

                var json = JsonConvert.SerializeObject(artist);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "apiprueba/artist";

                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = await client.PutAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario modificado");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Usuario no encontrado");
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


                var url = "apiPrueba/Artist/" + id;
                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = (await client.DeleteAsync(url));


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Artista eliminado");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Elemento no existe");
                }
                else
                    MessageBox.Show("El artista no se pudo eliminar");
            }
        }
    }
}





//public class ResponseDto
//{
//    string code;

//    object response;
//}
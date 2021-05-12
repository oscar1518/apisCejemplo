
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
    class AlbumService
    {

        public static async Task<List<Album>> getAll()
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Album/GetAll");
            var response = await client.ExecuteAsync(request);

            List<Album> album = new List<Album>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                album = JsonConvert.DeserializeObject<List<Album>>(rawResponse);
            }
            return album;
        }

        public static async Task<Album> getById(int id)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Album/GetById/" + id + "");
            var response = await client.ExecuteAsync(request);

            Album album = new Album();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                album = JsonConvert.DeserializeObject<Album>(rawResponse);
            }

            return album;
        }

        public static async Task<Album> getByName(string name)
        {
            var client = new RestClient("https://localhost:44334/apiPrueba/");
            var request = new RestRequest("Album/GetByName/" + name + "");
            var response = await client.ExecuteAsync(request);

            Album album = new Album();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                album = JsonConvert.DeserializeObject<Album>(rawResponse);
            }
            return album;
        }

        public static async Task post(string name, int age)
        {

            // Create a New NameValueCollection

            AlbumDTO values = new AlbumDTO();

            values.Name = name;
            values.ArtistId = age;


            var json = JsonConvert.SerializeObject(values);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44334/apiPrueba/Album";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = await response.Content.ReadAsStringAsync();

            if (result == "true")
            {
                MessageBox.Show("Usuario Registrado");
            }
        }

        public static async Task Put(int id, string name, int artistId)
        {
            using (var client = new HttpClient())
            {
                AlbumDTO artist = new AlbumDTO { Id = id, Name = name, ArtistId = artistId};

                string json = JsonConvert.SerializeObject(artist);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "apiprueba/Album";

                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = await client.PutAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Album modificado");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Album no encontrado");
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


                var url = "apiPrueba/Album/" + id;
                client.BaseAddress = new Uri("https://localhost:44334/");
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Album eliminado");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Elemento no existe");
                }
                else
                    MessageBox.Show("El Album no se pudo eliminar");
            }
        }
    }
}


